using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.Reporting.WebForms;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace Template
{
    public partial class view_report : System.Web.UI.Page
    {
        private BLL _BLL = new BLL();
        private DAL _DAL = new DAL();
        StringBuilder sb = new StringBuilder();
        char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.Browser == "IE" || Request.Browser.Browser == "InternetExplorer")
            {
                Response.Write("<script language='javascript'>window.alert('This application is not compatible with Internet Explorer.');window.location='about:blank';</script>");
                return;
            }
            else
            {
                if (!IsPostBack)
                {
                    if (_BLL.SessionIsActive(this))
                    {
                        string accessRights = Employee.access_rights;

                        if (!accessRights.Contains("&r"))
                        {
                            _BLL.AddAccessLogEntry(VG.access_reports, Employee.user_id, "0", Request.UserHostAddress.ToString());

                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "noAccessRedirect('../Logout.aspx');", true);
                        }
                        else
                        {
                            sb.Clear();
                            if (accessRights.Contains(VG.ar_r_audit_log))
                                sb.Append(VG.ar_r_audit_log);
                            if (accessRights.Contains(VG.ar_r_password_aging))
                                sb.Append(VG.ar_r_password_aging);
                            if (accessRights.Contains(VG.ar_r_user))
                                sb.Append(VG.ar_r_user);
                            if (accessRights.Contains(VG.ar_r_user_group))
                                sb.Append(VG.ar_r_user_group);
                            if (accessRights.Contains(VG.ar_r_user_group_access_matrix))
                                sb.Append(VG.ar_r_user_group_access_matrix);

                           

                            _BLL.GetReportsDropDown(ddReport, Convert.ToString(sb));
                        }

                        Employee.page_index = 0;

                        
                    }
                }
            }
        }

        /**
        * Called when the report dropdown index has changed and changes the displayed elements according to the selected index
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void ddReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.Visible = false;

            if (ddReport.SelectedValue == VG.ar_r_audit_log)
            {
                if (_BLL.GetFrontendListBox(lboxFrontend))
                    SelectAllItems(lboxFrontend);

                if (_BLL.GetBackendListBox(lboxBackend))
                    SelectAllItems(lboxBackend);


                HideOtherReports();

                auditLogCard.Visible = true;
            }
            else if (ddReport.SelectedValue == VG.ar_r_password_aging || ddReport.SelectedValue == VG.ar_r_user)
            {
                _BLL.GetUserGroupDropDown(ddUserGroup, "All");

                HideOtherReports();

                userCard.Visible = true;


                if (ddReport.SelectedValue == VG.ar_r_user)
                {
                    divUserColumns.Visible = true;
                    divPasswordAgingColumns.Visible = false;
                }
                else
                {
                    divUserColumns.Visible = false;
                    divPasswordAgingColumns.Visible = true;
                }
            }
            else if (ddReport.SelectedValue == VG.ar_r_user_group)
            {
                HideOtherReports();

                userGroupCard.Visible = true;

            }
            else if (ddReport.SelectedValue == VG.ar_r_user_group_access_matrix)
            {
                if (_BLL.GetUserGroupListBox(lboxUserGroup))
                    SelectAllItems(lboxUserGroup);

                HideOtherReports();

                userGroupAccessMatrixCard.Visible = true;
            }

            
            else
            {
                HideOtherReports();
                ClearValues();
            }


        }

        void HideOtherReports()
        {
            auditLogCard.Visible = false;
            userCard.Visible = false;
            userGroupCard.Visible = false;
            userGroupAccessMatrixCard.Visible = false;
            divReportTransactions.Visible = false;
            divReportPerCustomer.Visible = false;
            divReportSurveyNationwide.Visible = false;
            divReportSurveyPerBranch.Visible = false;
        }
        /**
        * Generates the audit log report based on the inputted filters
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbAuditLog_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                DataTable dt = new DataTable();

                string details = "";
                _BLL.AddAuditLogEntry(Employee.user_id, VG.c_r_audit_log, "View", details, Request.UserHostAddress.ToString());

                dt = _DAL.GetReportAuditLog(GetSelectedItems(lboxFrontend) + GetSelectedItems(lboxBackend), GetSelectedItems(lboxFunction), txtStartingDate.Text, txtEndingDate.Text, txtUserIdAL.Text);

                if (dt.Rows.Count < 1)
                {
                    lblError.Text = "No records found.";
                    ReportViewer1.Visible = false;
                    return;
                }
                else
                {
                    SetReportParameters(dt);
                }
            }
        }

        /**
        * Generates the user report based on the inputted filters
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbUser_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                DataTable dt = new DataTable();
                sb.Clear();

                if (txtUserId.Text.Length > 0) sb.Append(" User ID: " + txtUserId.Text + ",");
                if (txtFirstName.Text.Length > 0) sb.Append(" First Name: " + txtFirstName.Text + ",");
                if (txtMiddleName.Text.Length > 0) sb.Append(" Middle Name: " + txtMiddleName.Text + ",");
                if (txtLastName.Text.Length > 0) sb.Append(" Last Name: " + txtLastName.Text + ",");
                if (txtDateCreated.Text.Length > 0) sb.Append(" Date Created: " + txtDateCreated.Text + ",");
                sb.Append(" User Group: " + ddUserGroup.SelectedValue + ",");
                sb.Append(" Status: " + ddStatus.SelectedValue);

                if (ddReport.SelectedValue == VG.ar_r_user)
                {
                    _BLL.AddAuditLogEntry(Employee.user_id, VG.c_r_user, "View", Convert.ToString(sb), Request.UserHostAddress.ToString());
                    dt = _DAL.GetReportUser(txtUserId.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, ddUserGroup.SelectedValue, ddStatus.SelectedValue, txtDateCreated.Text);

                    if (dt.Rows.Count < 1)
                    {
                        lblError.Text = "No records found.";
                        ReportViewer1.Visible = false;
                        return;
                    }
                    else
                    {
                        SetReportParameters(dt);
                    }
                }
                else if (ddReport.SelectedValue == VG.ar_r_password_aging)
                {
                    _BLL.AddAuditLogEntry(Employee.user_id, VG.c_r_password_aging, "View", Convert.ToString(sb), Request.UserHostAddress.ToString());
                    dt = _DAL.GetReportPasswordAging(txtUserId.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, ddUserGroup.SelectedValue, ddStatus.SelectedValue, txtDateCreated.Text);

                    if (dt.Rows.Count < 1)
                    {
                        lblError.Text = "No records found.";
                        ReportViewer1.Visible = false;
                        return;
                    }
                    else
                    {
                        SetReportParameters(dt);
                    }
                }
            }
        }

        /**
        * Generates the user group report based on the inputted filters
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbUserGroup_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                DataTable dt = new DataTable();
                sb.Clear();

                if (txtCreatedBy.Text.Length > 0) sb.Append(" Created By: " + txtCreatedBy.Text + ",");
                if (txtDateCreatedUG.Text.Length > 0) sb.Append(" Date Created: " + txtDateCreatedUG.Text + ",");
                if (txtUpdatedBy.Text.Length > 0) sb.Append(" Updated By: " + txtUpdatedBy.Text + ",");
                if (txtDateUpdated.Text.Length > 0) sb.Append(" Date Updated: " + txtDateUpdated.Text + ",");
                sb.Append(" User Group: " + ddUserGroupUG.SelectedValue);

                _BLL.AddAuditLogEntry(Employee.user_id, VG.c_r_user_group, "View", Convert.ToString(sb), Request.UserHostAddress.ToString());
                dt = _DAL.GetReportUserGroup(ddUserGroupUG.SelectedValue, txtCreatedBy.Text, txtDateCreatedUG.Text, txtUpdatedBy.Text, txtDateUpdated.Text, ddStatusUserGroup.SelectedValue);

                if (dt.Rows.Count < 1)
                {
                    lblError.Text = "No records found.";
                    ReportViewer1.Visible = false;
                    return;
                }
                else
                {
                    SetReportParameters(dt);
                }
            }
        }

        /**
        * Generates the user group access matrix report based on the inputted filters
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbUserGroupAccessMatrix_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                _BLL.AddAuditLogEntry(Employee.user_id, VG.c_r_user_group_access_matrix, "View", "", Request.UserHostAddress.ToString());

                if (_BLL.GetReportUserGroupAccessMatrix(gvReport, GetSelectedItems(lboxUserGroup)) == false)
                {
                    divExport.Visible = false;
                    lblError.Text = "No records found.";
                    return;
                }
                else
                {
                    divExport.Visible = true;
                }
            }
        }

        /**
        * Disables text-wrapping and hides the code column.
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param GridViewRowEventArgs e - contains the event data
        */
        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
            }

            if (e.Row.RowType != DataControlRowType.Pager)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Data.DataView dv = (e.Row.DataItem as System.Data.DataRowView).DataView;
                ViewState["Sorting"] = dv.ToTable();
            }
        }

        /**
        * Exports the GridView of the selected maintenance item to Microsoft Excel
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbExportExcel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (gvReport.Rows.Count > 0)
                {
                    gvReport.AllowPaging = false;
                    gvReport.AllowSorting = false;
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt = (DataTable)ViewState["Sorting"];

                    dt.Columns.RemoveAt(1); //display order
                    dt.Columns.RemoveAt(0); //code

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=\"LOS User Group Access Matrix" + " " + DateTime.Now.ToString("yyyyMMdd") + ".xlsx\"");

                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add("User Group Access Matrix");
                        wsDt.Cells["A1"].Value = Maintenance.report_header;
                        wsDt.Cells["A2"].LoadFromDataTable(dt, true, TableStyles.Medium2);
                        wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();

                        Response.BinaryWrite(pck.GetAsByteArray());
                    }

                    Response.Flush();
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Nothing to export.', 'error');", true);
                }
            }
        }

        /**
        * Exports the GridView of the selected maintenance item to Adobe PDF
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbExportPdf_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (gvReport.Rows.Count > 0)
                {
                    gvReport.AllowPaging = false;
                    gvReport.AllowSorting = false;

                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt = (DataTable)ViewState["Sorting"];

                    _BLL.GetApplicationParameters();
                    int maxExtractableCount = 1;
                    if (Convert.ToInt32(Maintenance.max_extractable_record_count) > dt.Rows.Count)
                        maxExtractableCount = dt.Rows.Count;
                    else
                        maxExtractableCount = Convert.ToInt32(Maintenance.max_extractable_record_count);

                    DataTable dtn = dt.Clone();
                    for (int i = 0; i < maxExtractableCount; i++)
                    {
                        dtn.ImportRow(dt.Rows[i]);
                    }

                    gvReport.DataSource = dtn;
                    gvReport.DataBind();

                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            gvReport.RenderControl(hw);
                            StringReader sr = new StringReader(sw.ToString());
                            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                            pdfDoc.Open();
                            Paragraph para = new Paragraph(Maintenance.report_header, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16));
                            para.Alignment = Element.ALIGN_CENTER;
                            Paragraph space = new Paragraph("\n");
                            pdfDoc.Add(para);
                            pdfDoc.Add(space);
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            pdfDoc.Close();
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=\"LOS User Group Access Matrix " + DateTime.Now.ToString("yyyyMMdd") + ".pdf\"");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.Write(pdfDoc);
                            Response.End();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Nothing to export.', 'error');", true);
                }
            }
        }

        /**
        * Required to correctly export the GridView data
        * 
        * @since version 1.0 
        * @return Control control - element that is raising the event
        */
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        /**
        * Renders the report to the ReportViewer and sets the parameters for displaying and exporting the report
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void SetReportParameters(DataTable dt)
        {
            _BLL.GetApplicationParameters();

            ReportParameter[] parameters = new ReportParameter[dt.Columns.Count + 1];

            parameters[0] = new ReportParameter("report_header", Maintenance.report_header);

            #region Audit Log
            if (ddReport.SelectedValue == VG.ar_r_audit_log)
            {
                if (auditLogColumns.Items[0].Selected)
                    parameters[1] = new ReportParameter("log_date_visible", "True");
                else
                    parameters[1] = new ReportParameter("log_date_visible", "False");

                if (auditLogColumns.Items[1].Selected)
                    parameters[2] = new ReportParameter("user_id_visible", "True");
                else
                    parameters[2] = new ReportParameter("user_id_visible", "False");

                if (auditLogColumns.Items[2].Selected)
                    parameters[3] = new ReportParameter("content_visible", "True");
                else
                    parameters[3] = new ReportParameter("content_visible", "False");

                if (auditLogColumns.Items[3].Selected)
                    parameters[4] = new ReportParameter("function_visible", "True");
                else
                    parameters[4] = new ReportParameter("function_visible", "False");

                if (auditLogColumns.Items[4].Selected)
                    parameters[5] = new ReportParameter("details_visible", "True");
                else
                    parameters[5] = new ReportParameter("details_visible", "False");

                if (auditLogColumns.Items[5].Selected)
                    parameters[6] = new ReportParameter("terminal_id_visible", "True");
                else
                    parameters[6] = new ReportParameter("terminal_id_visible", "False");

            }
            #endregion

            #region User
            else if (ddReport.SelectedValue == VG.ar_r_user)
            {
                if (userColumns.Items[0].Selected)
                    parameters[1] = new ReportParameter("user_id_visible", "True");
                else
                    parameters[1] = new ReportParameter("user_id_visible", "False");

                if (userColumns.Items[1].Selected)
                    parameters[2] = new ReportParameter("first_name_visible", "True");
                else
                    parameters[2] = new ReportParameter("first_name_visible", "False");

                if (userColumns.Items[2].Selected)
                    parameters[3] = new ReportParameter("middle_name_visible", "True");
                else
                    parameters[3] = new ReportParameter("middle_name_visible", "False");

                if (userColumns.Items[3].Selected)
                    parameters[4] = new ReportParameter("last_name_visible", "True");
                else
                    parameters[4] = new ReportParameter("last_name_visible", "False");

                if (userColumns.Items[4].Selected)
                    parameters[5] = new ReportParameter("user_group_visible", "True");
                else
                    parameters[5] = new ReportParameter("user_group_visible", "False");

                if (userColumns.Items[5].Selected)
                    parameters[6] = new ReportParameter("status_visible", "True");
                else
                    parameters[6] = new ReportParameter("status_visible", "False");

                if (userColumns.Items[6].Selected)
                    parameters[7] = new ReportParameter("date_created_visible", "True");
                else
                    parameters[7] = new ReportParameter("date_created_visible", "False");

                if (userColumns.Items[7].Selected)
                    parameters[8] = new ReportParameter("last_login_date_visible", "True");
                else
                    parameters[8] = new ReportParameter("last_login_date_visible", "False");
            }
            #endregion

            #region User Group
            else if (ddReport.SelectedValue == VG.ar_r_user_group)
            {
                if (userGroupColumns.Items[0].Selected)
                    parameters[1] = new ReportParameter("group_code_visible", "True");
                else
                    parameters[1] = new ReportParameter("group_code_visible", "False");

                if (userGroupColumns.Items[1].Selected)
                    parameters[2] = new ReportParameter("description_visible", "True");
                else
                    parameters[2] = new ReportParameter("description_visible", "False");

                if (userGroupColumns.Items[2].Selected)
                    parameters[3] = new ReportParameter("created_by_visible", "True");
                else
                    parameters[3] = new ReportParameter("created_by_visible", "False");

                if (userGroupColumns.Items[3].Selected)
                    parameters[4] = new ReportParameter("date_created_visible", "True");
                else
                    parameters[4] = new ReportParameter("date_created_visible", "False");

                if (userGroupColumns.Items[4].Selected)
                    parameters[5] = new ReportParameter("updated_by_visible", "True");
                else
                    parameters[5] = new ReportParameter("updated_by_visible", "False");

                if (userGroupColumns.Items[5].Selected)
                    parameters[6] = new ReportParameter("date_updated_visible", "True");
                else
                    parameters[6] = new ReportParameter("date_updated_visible", "False");

                if (userGroupColumns.Items[6].Selected)
                    parameters[7] = new ReportParameter("user_list_visible", "True");
                else
                    parameters[7] = new ReportParameter("user_list_visible", "False");

                if (userGroupColumns.Items[7].Selected)
                    parameters[8] = new ReportParameter("status_visible", "True");
                else
                    parameters[8] = new ReportParameter("status_visible", "False");
            }
            #endregion

            #region Password Aging
            else if (ddReport.SelectedValue == VG.ar_r_password_aging)
            {
                if (passwordAgingColumns.Items[0].Selected)
                    parameters[1] = new ReportParameter("user_id_visible", "True");
                else
                    parameters[1] = new ReportParameter("user_id_visible", "False");

                if (passwordAgingColumns.Items[1].Selected)
                    parameters[2] = new ReportParameter("first_name_visible", "True");
                else
                    parameters[2] = new ReportParameter("first_name_visible", "False");

                if (passwordAgingColumns.Items[2].Selected)
                    parameters[3] = new ReportParameter("middle_name_visible", "True");
                else
                    parameters[3] = new ReportParameter("middle_name_visible", "False");

                if (passwordAgingColumns.Items[3].Selected)
                    parameters[4] = new ReportParameter("last_name_visible", "True");
                else
                    parameters[4] = new ReportParameter("last_name_visible", "False");

                if (passwordAgingColumns.Items[4].Selected)
                    parameters[5] = new ReportParameter("user_group_visible", "True");
                else
                    parameters[5] = new ReportParameter("user_group_visible", "False");

                if (passwordAgingColumns.Items[5].Selected)
                    parameters[6] = new ReportParameter("branch_visible", "True");
                else
                    parameters[6] = new ReportParameter("branch_visible", "False");

                if (passwordAgingColumns.Items[6].Selected)
                    parameters[7] = new ReportParameter("department_visible", "True");
                else
                    parameters[7] = new ReportParameter("department_visible", "False");

                if (passwordAgingColumns.Items[7].Selected)
                    parameters[8] = new ReportParameter("status_visible", "True");
                else
                    parameters[8] = new ReportParameter("status_visible", "False");

                if (passwordAgingColumns.Items[8].Selected)
                    parameters[9] = new ReportParameter("date_created_visible", "True");
                else
                    parameters[9] = new ReportParameter("date_created_visible", "False");

                if (passwordAgingColumns.Items[9].Selected)
                    parameters[10] = new ReportParameter("last_login_date_visible", "True");
                else
                    parameters[10] = new ReportParameter("last_login_date_visible", "False");

                if (passwordAgingColumns.Items[10].Selected)
                    parameters[11] = new ReportParameter("password_change_date_visible", "True");
                else
                    parameters[11] = new ReportParameter("password_change_date_visible", "False");

                if (passwordAgingColumns.Items[11].Selected)
                    parameters[12] = new ReportParameter("profile_expiration_date_visible", "True");
                else
                    parameters[12] = new ReportParameter("profile_expiration_date_visible", "False");

                if (passwordAgingColumns.Items[12].Selected)
                    parameters[13] = new ReportParameter("password_expiration_date_visible", "True");
                else
                    parameters[13] = new ReportParameter("password_expiration_date_visible", "False");

                if (passwordAgingColumns.Items[13].Selected)
                    parameters[14] = new ReportParameter("password_age_visible", "True");
                else
                    parameters[14] = new ReportParameter("password_age_visible", "False");
            }
            #endregion

            string rdlcName = ddReport.SelectedItem.Text.Replace(" ", "");

            lblError.Text = "";
            ReportViewer1.Reset();
            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.ReportPath = @"bin\contents\Reports\" + rdlcName + ".rdlc";
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource(rdlcName, dt));
            ReportViewer1.LocalReport.SetParameters(parameters);

            DateTime dateTime = DateTime.UtcNow.Date;
            ReportViewer1.LocalReport.DisplayName = ddReport.SelectedItem.Text + " Report " + dateTime.ToString("yyyyMMdd");
            ReportViewer1.LocalReport.Refresh();
        }

        /**
        * Returns the selected item values in the given ListBox control
        * 
        * @since version 1.0 
        * @return string concatenated string of selected item values
        */
        protected string GetSelectedItems(ListBox lb)
        {
            StringBuilder sb = new StringBuilder();

            foreach (System.Web.UI.WebControls.ListItem li in lb.Items)
            {
                if (li.Selected)
                {
                    sb.Append(li.Value + ",");
                }
            }

            return Convert.ToString(sb);
        }

        /**
        * Selects all items in the given ListBox control
        * 
        * @since version 1.0
        */
        protected void SelectAllItems(ListBox lb)
        {
            for (int i = 0; i < lb.Items.Count; i++)
            {
                lb.Items[i].Selected = true;
            }
        }

        #region Survey Report Transactions
        protected void lbReportTransactions_Click(object sender, EventArgs e)
        {

            SurveyReportTransactions();


        }
        #region GridView
        protected void gvSurveyReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
            }


            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {

            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Data.DataView dv = (e.Row.DataItem as System.Data.DataRowView).DataView;
                ViewState["Sorting"] = dv.ToTable();

            }

        }

        protected void gvSurveyReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSurveyReport.PageIndex = e.NewPageIndex;
            Employee.page_index = e.NewPageIndex;
            BindGridView();
        }

        #region Custom Pager

        private void PopulatePager(int pageCount)
        {
            lblTotalRowCount.Text = Convert.ToString(DTSorting.Rows.Count);
            lblTotalPageCount.Text = Convert.ToString(pageCount);

            ddPageNumber.Items.Clear();
            for (int i = 1; i <= pageCount; i++)
            {
                ddPageNumber.Items.Add(new System.Web.UI.WebControls.ListItem(Convert.ToString(i), Convert.ToString(i - 1)));
            }
            if (pageCount > Employee.page_index)
                ddPageNumber.SelectedValue = Convert.ToString(Employee.page_index);
            else
                ddPageNumber.SelectedIndex = -1;
        }

        /**
        * 
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void ddPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvSurveyReport.PageSize = Convert.ToInt16(ddPageSize.SelectedValue);
            BindGridView();
            PopulatePager(gvSurveyReport.PageCount);
        }

        /**
        * 
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void ddPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvSurveyReport.PageIndex = Convert.ToInt16(ddPageNumber.SelectedValue);
            Employee.page_index = Convert.ToInt16(ddPageNumber.SelectedValue);
            BindGridView();
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbFirstPage_Click(object sender, EventArgs e)
        {
            if (gvSurveyReport.PageIndex > 0)
            {
                gvSurveyReport.PageIndex = Convert.ToInt16(ddPageNumber.Items[0].Value);
                Employee.page_index = Convert.ToInt16(ddPageNumber.Items[0].Value);
                BindGridView();
                ddPageNumber.SelectedValue = Convert.ToString(Employee.page_index);
            }
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbPreviousPage_Click(object sender, EventArgs e)
        {
            if (gvSurveyReport.PageIndex > 0)
            {
                Employee.page_index -= 1;
                gvSurveyReport.PageIndex -= 1;
                BindGridView();
                ddPageNumber.SelectedValue = Convert.ToString(Employee.page_index);
            }
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbNextPage_Click(object sender, EventArgs e)
        {
            if (gvSurveyReport.PageIndex < gvSurveyReport.PageCount - 1)
            {
                Employee.page_index += 1;
                gvSurveyReport.PageIndex += 1;
                BindGridView();
                ddPageNumber.SelectedValue = Convert.ToString(Employee.page_index);
            }
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbLastPage_Click(object sender, EventArgs e)
        {
            if (gvSurveyReport.PageIndex < gvSurveyReport.PageCount)
            {
                Employee.page_index = gvSurveyReport.PageCount - 1;
                gvSurveyReport.PageIndex = gvSurveyReport.PageCount - 1;
                BindGridView();
                ddPageNumber.SelectedValue = Convert.ToString(Employee.page_index);
            }
        }

        #endregion

        protected void BindGridView()
        {
            gvSurveyReport.DataSource = DTSorting;
            gvSurveyReport.DataBind();

            if (ViewState["z_sortexpression"] != null)
            {
                SortGridView(gvSurveyReport, Convert.ToString(ViewState["z_sortexpression"]), Convert.ToString(ViewState["CurrentSortDirection"]));
            }
        }



        protected void lbSRPExportExcel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (gvSurveyReport.Rows.Count > 0)
                {
                    System.Threading.Thread.Sleep(2000);
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt = (DataTable)ViewState["Sorting"];

                    _BLL.GetApplicationParameters();
                    int maxExtractableCount = 1;
                    if (Convert.ToInt32(Maintenance.max_extractable_record_count) > dt.Rows.Count)
                        maxExtractableCount = dt.Rows.Count;
                    else
                        maxExtractableCount = Convert.ToInt32(Maintenance.max_extractable_record_count);

                    DataTable dtn = dt.Clone();
                    for (int i = 0; i < maxExtractableCount; i++)
                    {
                        dtn.ImportRow(dt.Rows[i]);
                    }
                    

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentEncoding = System.Text.Encoding.UTF8;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=\"" + VG.application_name + "-" + ddReport.SelectedItem.Text + "-" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx\"");

                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add(ddReport.SelectedItem.Text);
                        wsDt.Cells["A1:" + alphabet[dtn.Columns.Count - 1].ToString() + "1"].Merge = true;
                        wsDt.Cells["A1"].Value = VG.application_name + "-" + Maintenance.report_header;
                        wsDt.Cells["A2"].LoadFromDataTable(dtn, true, TableStyles.Medium2);
                        wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();

                        Response.BinaryWrite(pck.GetAsByteArray());
                    }

                    Response.Flush();
                    Response.End();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Nothing to export.', 'error');", true);
                }
            }
        }
        string columnIndexToColumnLetter(int columnNumber)
        {
            string columnName = "";

            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }

            return columnName;
        }
        protected void lbSRPExportPdf_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (gvSurveyReport.Rows.Count > 0)
                {

                    string size = "";
                    string ReportHeader = "";
                    size = this.gvSurveyReport.Font.Size.ToString();

                    //this.gvLoanApplication.Columns[0].Visible = false;
                    gvSurveyReport.AllowPaging = false;
                    gvSurveyReport.AllowSorting = false;

                    this.gvSurveyReport.Font.Size = FontUnit.Point(40);
                    ReportHeader = ddReport.SelectedItem.Text;

                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt = (DataTable)ViewState["Sorting"];

                    _BLL.GetApplicationParameters();
                    int maxExtractableCount = 1;
                    if (Convert.ToInt32(Maintenance.max_extractable_record_count) > dt.Rows.Count)
                        maxExtractableCount = dt.Rows.Count;
                    else
                        maxExtractableCount = Convert.ToInt32(Maintenance.max_extractable_record_count);

                    DataTable dtn = dt.Clone();
                    for (int i = 0; i < maxExtractableCount; i++)
                    {
                        dtn.ImportRow(dt.Rows[i]);
                    }

                    gvSurveyReport.DataSource = dtn;
                    gvSurveyReport.DataBind();

                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {

                            gvSurveyReport.RenderControl(hw);
                            StringReader sr = new StringReader(sw.ToString());
                            Document pdfDoc = new Document();
                            pdfDoc = new Document(PageSize.ARCH_E.Rotate(), 10f, 10f, 10f, 10f);
                            pdfDoc.SetPageSize(iTextSharp.text.PageSize.ARCH_E.Rotate());
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                            pdfDoc.Open();
                            Paragraph para = new Paragraph(ReportHeader, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 40));
                            para.Alignment = Element.ALIGN_CENTER;
                            Paragraph space = new Paragraph("\n");
                            pdfDoc.Add(para);
                            pdfDoc.Add(space);
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            pdfDoc.Close();
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=\"" + VG.application_name + "-" + ddReport.SelectedItem.Text + " - " + DateTime.Now.ToString("yyyyMMdd") + ".pdf\"");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.Write(pdfDoc);
                            Response.End();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Nothing to export.', 'error');", true);
                }
            }
        }



        protected void gvSurveyReport_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            ViewState["z_sortexpression"] = e.SortExpression;
            if (GridViewSortDirection == SortDirection.Ascending)
            {
                ViewState["CurrentSortDirection"] = "DESC";
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(gvSurveyReport, sortExpression, "DESC");
            }
            else
            {
                ViewState["CurrentSortDirection"] = "ASC";
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(gvSurveyReport, sortExpression, "ASC");
            }
        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;
                return (SortDirection)ViewState["sortDirection"];
            }
            set
            {
                ViewState["sortDirection"] = value;
            }
        }

        /**
        * Binds the newly sorted data to the table
        * 
        * @since version 1.0 
        * @param GridView gv - GridView to be sorted
        * @param string sortExpression - determines which column to sort by
        * @param string direction - determines the sorting direction
        */
        private void SortGridView(GridView gv, string sortExpression, string direction)
        {
            DTSorting = new DataView(DTSorting, "", sortExpression + " " + direction, DataViewRowState.CurrentRows).ToTable();
            gv.DataSource = DTSorting;
            gv.DataBind();
        }

        /**
        * Allows sorting of the GridView
        * 
        * @since version 1.0 
        * @return DataTable sorted
        */
        public DataTable DTSorting
        {
            get
            {
                if (ViewState["Sorting"] != null)
                {
                    return (DataTable)ViewState["Sorting"];
                }
                else
                    return null;
            }
            set
            {
                ViewState["Sorting"] = value;
            }
        }




        #endregion

        #endregion

        #region Survey Results per Customer – Demographic
        protected void lbReportPerCustomer_Click(object sender, EventArgs e)
        {
            SurveyReportTransactions();
        }
        #endregion

        #region Survey Report Nationwide
        protected void lbReportNationwide_Click(object sender, EventArgs e)
        {
            SurveyReportTransactions();
        }
        #endregion

        void SurveyReportTransactions()
        {
            gvSurveyReport.PageIndex = 0;
            Employee.page_index = 0;

            DataTable dt = new DataTable();

            gvSurveyReport.DataSource = dt;
            gvSurveyReport.DataBind();
            


            if (dt.Rows == null || dt.Rows.Count == 0)
            {
                divSRPExport.Visible = false;
                divPager.Visible = false;
            }
            else
            {
                divPager.Visible = true;
                PopulatePager(gvSurveyReport.PageCount);

                divSRPExport.Visible = true;
            }

            divGridView.Visible = true;
            gvSurveyReport.Visible = true;
        }

        protected void lbReportPerBranch_Click(object sender, EventArgs e)
        {
            SurveyReportTransactions();
        }

        void GetDropdowns()
        {

            //DataTable dtServices = _DAL.dtServiceAvailed("", "", "","", "GET");
            //LoadDropdownValues(ddServices, dtServices, "code", "description", true);

            //LoadDropdownValues(ddTransactionsServices, dtServices, "code", "description", true);

            //DataTable dtServiceType = _DAL.GetServiceType();
            //LoadDropdownValues(ddCustomerServiceType, dtServiceType, "code", "description", true);

            //LoadDropdownValues(ddCustomerService, dtServices, "code", "description", true);
            
            //DataTable dtBranch = _DAL.GetBranchDropdown();
            //LoadDropdownValues(ddTransactionsBranch, dtBranch, "code", "description", true);
            

            
        }

        void LoadDropdownValues(DropDownList dd, DataTable dt, string value, string text, bool hasSelectText)
        {

            dd.DataSource = dt;
            dd.DataValueField = value;
            dd.DataTextField = text;
            dd.DataBind();
            if (hasSelectText)
            {
                dd.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- All --", ""));
            }

        }

        void ClearValues()
        {
            //Branch
            ddBranch.SelectedIndex = -1;
            ddServicesPerBranch.SelectedIndex = -1;
            txtPerBranchEndDate.Text = "";
            txtPerBranchStartDate.Text = "";

            //Nationwide
            txtStartDate.Text = "";
            txtEndDate.Text = "";
    
            ddServices.SelectedIndex = -1;

            //Transactions
            ddTransactionsBranch.SelectedIndex = -1;
            ddTransactionsBranch.SelectedIndex = -1;
            txtYearDate.Text = "";

            //Customer


        }

        protected void ddCustomerServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dtServices = _DAL.dtServiceAvailed("", "", ddCustomerServiceType.SelectedValue, "", "GET");
            //LoadDropdownValues(ddCustomerService, dtServices, "code", "description", true);
        }
    }
}