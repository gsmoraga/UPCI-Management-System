using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace Template
{
    public partial class view_maintenance : System.Web.UI.Page
    {
        private BLL _BLL = new BLL();
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
                        Regex r = new Regex("&m[0-9]", RegexOptions.IgnoreCase);

                        if (!r.Match(accessRights).Success)
                        {
                            _BLL.AddAccessLogEntry(VG.access_maintenance, Employee.user_id, "0", Request.UserHostAddress.ToString());

                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "noAccessRedirect('logout.aspx');", true);
                        }
                        else
                        {
                            if (_BLL.GetContentType(Maintenance.content_code) == false)
                            {
                            }
                            else
                            {
                                lblHeader.Text = Maintenance.content_description + " Maintenance";

                                if (Maintenance.content_code == VG.c_ministry_department)
                                {
                                    _BLL.GetDivisionDropDown(ddDivision, "All");
                                    divDivision.Visible = true;
                                }
                                else if (Maintenance.content_code == VG.c_user)
                                {
                                    lblCode.InnerText = "User ID";

                                    divDescription.Visible = false;
                                    divIndividualName.Visible = true;

                                    _BLL.GetUserGroupDropDown(ddUserGroup, "All");
                                    divUserGroup.Visible = true;

                                    _BLL.GetDivisionDropDown(ddDivision, "All");
                                    divDivision.Visible = true;

                                    _BLL.GetDepartmentDropDown(ddDepartment, "All");
                                    divDepartment.Visible = true;

                                    _BLL.GetBranchDropDown(ddBranch, "All");
                                    divBranch.Visible = true;

                                    divStatus.Visible = true;

                                    if (Maintenance.bank_user_security)
                                    {
                                        if (Maintenance.bank_user_security_mode == "Unlock")
                                            lblHeader.Text = "Unlock User Maintenance";
                                        else if (Maintenance.bank_user_security_mode == "Reset")
                                            lblHeader.Text = "Reset Password Maintenance";
                                    }
                                }
                                else if (Maintenance.content_code == VG.c_active_session)
                                {
                                    lblDescription.InnerText = "User ID";
                                }

                                if (accessRights.Contains("&m" + Maintenance.content_code + "d,") || accessRights.Contains("&m" + Maintenance.content_code + "e,") ||
                                    (Convert.ToBoolean(Session["BankUserSecurity"]) && accessRights.Contains("&m5bank,")))
                                {
                                    divSearch.Visible = true;
                                    lbSearch.Visible = true;
                                    divExport.Visible = true;

                                    if (accessRights.Contains("&m" + Maintenance.content_code + "d,") && Maintenance.bank_user_security_mode != "Unlock" && Maintenance.bank_user_security_mode != "Reset")
                                    {
                                        divDeleteCheckbox.Visible = true;
                                        divDeleteSelectedButton.Visible = true;
                                    }
                                }

                                if (Maintenance.back)
                                {
                                    Maintenance.back = false;

                                    txtCode.Text = Maintenance.code_filter;
                                    txtDescription.Text = Maintenance.description_filter;
                                    gvMaintenance.PageIndex = Maintenance.page_index;
                                }

                                LoadMaintenanceData(Maintenance.content_code, txtCode.Text, txtDescription.Text);

                                _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "", Request.UserHostAddress.ToString());
                            }
                        }
                    }
                }
            }
        }

        /**
        * Selects the data to be displayed in the GridView
        * 
        * @since version 1.0 
        * @param string code - unique code of the maintenance item to be loaded
        * @param string description - description of the maintenance item to be loaded
        */
        protected void LoadMaintenanceData(string contentCode, string code, string description)
        {
            Boolean result = false;

            if (contentCode == VG.c_ministry_department)
            {
                result = _BLL.FilterDepartment(gvMaintenance, code, description, ddDivision.SelectedValue);
            }
            else if (contentCode == VG.c_user_group)
            {
                result = _BLL.FilterUserGroup(gvMaintenance, code, description, Employee.user_group);
            }
            else if (contentCode == VG.c_user)
            {
                if (Maintenance.bank_user_security && Maintenance.bank_user_security_mode == "Unlock")
                {
                    result = _BLL.FilterLockedUser(gvMaintenance, code, txtLastName.Text, txtFirstName.Text, txtMiddleName.Text, Employee.user_id, ddUserGroup.SelectedValue, ddDivision.SelectedValue, ddDepartment.SelectedValue, ddBranch.SelectedValue, ddStatus.SelectedValue);
                }
                else
                {
                    result = _BLL.FilterUser(gvMaintenance, code, txtLastName.Text, txtFirstName.Text, txtMiddleName.Text, Employee.user_id, ddUserGroup.SelectedValue, ddDivision.SelectedValue, ddDepartment.SelectedValue, ddBranch.SelectedValue, ddStatus.SelectedValue);
                }
            }
            else if (contentCode == VG.c_active_session)
            {
                result = _BLL.FilterActiveSession(gvMaintenance, code, description);
            }
            else if (contentCode == VG.c_pepsol)
            {
                result = _BLL.FilterBranch(gvMaintenance, code, description);
            }
            else if (contentCode == VG.c_ministry)
            {
                result = _BLL.FilterDivision(gvMaintenance, code, description);
            }

            if (result == false)
            {
                gvCheckBox.Visible = false;
                lbDeleteSelected.Visible = false;
                divExport.Visible = false;
            }
            else
            {
                gvCheckBox.Visible = true;
                lbDeleteSelected.Visible = true;
                divExport.Visible = true;
            }
        }

        /**
        * Disables text-wrapping and hides the code column.
        * Displays or hides action buttons depending on the user access rights.
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param GridViewRowEventArgs e - contains the event data
        */
        protected void gvMaintenance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
            }

            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                if (Maintenance.content_code == VG.c_user_group)
                {
                    e.Row.Cells[2].Visible = false;
                }
                else if (Maintenance.content_code == VG.c_user || Maintenance.content_code == VG.c_active_session)
                {
                    e.Row.Cells[0].Visible = false;

                    if (Maintenance.content_code == VG.c_user)
                        e.Row.Cells[8].Visible = false;
                }
            }

            string accessRights = Employee.access_rights;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (!Maintenance.bank_user_security)
                {
                    if (accessRights.Contains("&m" + Maintenance.content_code + "d,"))
                    {
                        LinkButton lb = (LinkButton)e.Row.FindControl("lbDelete");
                        lb.Visible = true;
                    }
                    if (accessRights.Contains("&m" + Maintenance.content_code + "e,"))
                    {
                        LinkButton lb = (LinkButton)e.Row.FindControl("lbEdit");
                        lb.Visible = true;
                    }
                }
                else
                {
                    if (Maintenance.bank_user_security_mode == "Unlock")
                    {
                        LinkButton lb = (LinkButton)e.Row.FindControl("lbUnlock");
                        lb.Visible = true;
                    }
                    else if (Maintenance.bank_user_security_mode == "Reset")
                    {
                        LinkButton lb = (LinkButton)e.Row.FindControl("lbResetPassword");
                        lb.Visible = true;
                    }
                    else if (Maintenance.bank_user_security_mode == "Session")
                    {
                        LinkButton lb = (LinkButton)e.Row.FindControl("lbRemoveSession");
                        lb.Visible = true;

                        LinkButton lbv = (LinkButton)e.Row.FindControl("lbView");
                        lbv.Visible = false;
                    }
                }

                System.Data.DataView dv = (e.Row.DataItem as System.Data.DataRowView).DataView;
                ViewState["Sorting"] = dv.ToTable();

                if (!Maintenance.bank_user_security && accessRights.Contains("&m" + Maintenance.content_code + "d,"))
                {
                    int numRows = 0;
                    if (gvMaintenance.Rows.Count > 9)
                        numRows = 10;
                    else
                        numRows = gvMaintenance.Rows.Count;

                    List<int> rows = new List<int>();

                    for (int i = 0; i <= numRows; i++)
                    {
                        rows.Add(i);
                    }
                    gvCheckBox.DataSource = rows;
                    gvCheckBox.DataBind();
                }
            }
        }

        /**
        * Moves the Action column of the GridView when the rows are created
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param GridViewRowEventArgs e - contains the event data
        */
        protected void gvMaintenance_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;
            List<TableCell> columns = new List<TableCell>();
            foreach (DataControlField column in gvMaintenance.Columns)
            {
                TableCell cell = row.Cells[0];
                row.Cells.Remove(cell);
                columns.Add(cell);
            }

            row.Cells.AddRange(columns.ToArray());
        }

        /**
        * Allows paging of the GridView
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param GridViewPageEventArgs e - contains the event data
        */
        protected void gvMaintenance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Maintenance.page_index = e.NewPageIndex;
            gvMaintenance.PageIndex = e.NewPageIndex;
            gvMaintenance.DataSource = DTSorting;
            gvMaintenance.DataBind();

            if (ViewState["z_sortexpresion"] != null)
            {
                SortGridView(gvMaintenance, Convert.ToString(ViewState["z_sortexpresion"]), Convert.ToString(ViewState["CurrentSortDirection"]));
            }
        }

        /**
        * Redirects the user to the add page of the selected maintenance item
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Maintenance.code_filter = txtCode.Text = "";
                Maintenance.description_filter = txtDescription.Text = "";
                Maintenance.page_index = 0;
                Maintenance.mode = "Add";

                Response.Redirect("maintenance-parameters.aspx", false);
            }
        }

        /**
        * Refreshes the maintenance GridView back to its default unfiltered state
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbRefresh_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LoadMaintenanceData(Maintenance.content_code, "", "");
                Maintenance.code_filter = txtCode.Text = "";
                Maintenance.description_filter = txtDescription.Text = "";
                Maintenance.page_index = 0;
            }
        }

        /**
        * Filters the maintenance GridView depending on the inputted filters
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbSearch_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Maintenance.code_filter = txtCode.Text;
                Maintenance.description_filter = txtDescription.Text;
                Maintenance.page_index = 0;

                LoadMaintenanceData(Maintenance.content_code, txtCode.Text, txtDescription.Text);
                _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Search", txtCode.Text + " " + txtDescription.Text, Request.UserHostAddress.ToString());
            }
        }

        /**
        * Soft deletes the selected row
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbDelete_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbDelete = (LinkButton)sender;
                string code = lbDelete.CommandArgument;
                Boolean result = false;

                if (Maintenance.content_code == VG.c_ministry_department)
                {
                    result = _BLL.DeleteDepartment(code);
                }
                else if (Maintenance.content_code == VG.c_user_group)
                {
                    string userList = "";

                    foreach (GridViewRow r in gvMaintenance.Rows)
                    {
                        if (r.Cells[0].Text.Equals(code))
                        {
                            userList = r.Cells[2].Text;
                            break;
                        }
                    }

                    if (userList.Length > 0 && !userList.Equals("&nbsp;"))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to delete the user group because it is still being used by the following users: " + userList + "', 'error');", true);
                        return;
                    }
                    else
                    {
                        result = _BLL.DeleteUserGroup(code);
                    }
                }
                else if (Maintenance.content_code == VG.c_user)
                {
                    result = _BLL.DeleteUser(code);
                }
                else if (Maintenance.content_code == VG.c_active_session)
                {
                    _BLL.DeleteActiveSessionBySessionId(code);
                }
                else if (Maintenance.content_code == VG.c_pepsol)
                {
                    result = _BLL.DeleteBranch(code);
                }
                else if (Maintenance.content_code == VG.c_ministry)
                {
                    result = _BLL.DeleteDivision(code);
                }

                if (result == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to delete the entry.', 'error');", true);
                }
                else
                {
                    _BLL.RemoveFromCache("Filter" + Maintenance.content_code + "&");

                    if (Maintenance.content_code == VG.c_user)
                        _BLL.RemoveFromCache("Filter" + VG.c_user_group + "&");

                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Delete", "Code: " + code, Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = "CLICKS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been deleted.','" + transactionReferenceNumber + "');", true);
                    LoadMaintenanceData(Maintenance.content_code, txtCode.Text, txtDescription.Text);
                }
            }
        }

        /**
        * Redirects the user to the edit page of the selected maintenance item
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbEdit_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbEdit = (LinkButton)sender;
                Maintenance.entry_code = lbEdit.CommandArgument;
                Maintenance.mode = "Edit";

                Response.Redirect("maintenance-parameters.aspx", false);
            }
        }

        /**
        * Redirects the user to the view page of the selected maintenance item
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbView_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbView = (LinkButton)sender;
                Maintenance.entry_code = lbView.CommandArgument;
                Maintenance.mode = "View";

                _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "Code: " + Maintenance.entry_code, Request.UserHostAddress.ToString());

                Response.Redirect("maintenance-parameters.aspx", false);
            }
        }

        /**
        * Changes the selected user's status from Disabled to Active to unlock their account
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbUnlock_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbUnlock = (LinkButton)sender;
                string userId = lbUnlock.CommandArgument;

                if (_BLL.SetUserStatus(userId, VG.s_active) == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to unlock the user.', 'error');", true);
                }
                else
                {
                    //HttpContext.Current.Cache.Remove(("GetUser" + txtUserId.Text).ToLower());

                    _BLL.FilterLockedUser(gvMaintenance, txtCode.Text, txtLastName.Text, txtFirstName.Text, txtMiddleName.Text, Employee.user_id, ddUserGroup.SelectedValue, ddDivision.SelectedValue, ddDepartment.SelectedValue, ddBranch.SelectedValue, ddStatus.SelectedValue);

                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Edit", "Code: " + userId, Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = "CLICKS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('User has been unlocked and an email notification has been sent to the user.','" + transactionReferenceNumber + "');", true);

                    if (_BLL.SendEmailNotificationUser(userId, "has been unlocked") == false)
                    {
                    }
                }
            }
        }

        /**
        * Resets the selected user's password to a random computer-generated password
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbResetPassword_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbResetPassword = (LinkButton)sender;
                string userId = lbResetPassword.CommandArgument;

                if (_BLL.ResetPassword(userId) == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to reset the password.', 'error');", true);
                }
                else
                {
                    //HttpContext.Current.Cache.Remove(("GetUser" + txtUserId.Text).ToLower());

                    if (_BLL.SendEmailNotificationUser(userId, "password has been reset") == false)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to send email notification. Please try again.', 'error');", true);
                    }
                    else
                    {
                        string transactionReferenceNumber = "";
                        if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Edit", "Reset password, User ID: " + userId, Request.UserHostAddress.ToString()))
                            transactionReferenceNumber = "CLICKS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Password has been reset and an email notification has been sent to the user.','" + transactionReferenceNumber + "');", true);
                    }
                }
            }
        }

        /**
        * Deletes the selected session from the database
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbRemoveSession_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbRemoveSession = (LinkButton)sender;
                string userId = lbRemoveSession.CommandArgument;

                if (_BLL.DeleteActiveSessionByUserId(userId) == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to remove the session.', 'error');", true);
                }
                else
                {
                    _BLL.RemoveFromCache("FilterActiveSession");
                    _BLL.RemoveFromCache("GetActiveSession" + userId);

                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Delete", "User ID: " + userId, Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = "CLICKS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Session has been removed.','" + transactionReferenceNumber + "');", true);
                    LoadMaintenanceData(Maintenance.content_code, txtCode.Text, txtDescription.Text);
                }
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
                if (gvMaintenance.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt = (DataTable)ViewState["Sorting"];

                    if (Maintenance.content_code == VG.c_user || Maintenance.content_code == VG.c_active_session)
                    {
                        dt.Columns.RemoveAt(0);
                    }

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
                    Response.AddHeader("content-disposition", "attachment;filename=\"CLICKS-" + Maintenance.content_description + " " + DateTime.Now.ToString("yyyyMMdd") + ".xlsx\"");

                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add(Maintenance.content_description);
                        wsDt.Cells["A1:" + alphabet[dtn.Columns.Count - 1].ToString() + "1"].Merge = true;
                        wsDt.Cells["A1"].Value = Maintenance.report_header;
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
                if (gvMaintenance.Rows.Count > 0)
                {
                    this.gvMaintenance.Columns[0].Visible = false;
                    gvMaintenance.AllowPaging = false;
                    gvMaintenance.AllowSorting = false;

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

                    gvMaintenance.DataSource = dtn;
                    gvMaintenance.DataBind();

                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            gvMaintenance.RenderControl(hw);
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
                            Response.AddHeader("content-disposition", "attachment;filename=\"CLICKS" + Maintenance.content_description + " " + DateTime.Now.ToString("yyyyMMdd") + ".pdf\"");
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
        * Called when the column headers are clicked and sorts te GridView accordingly
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param GridViewSortEventArgs e - contains the event data
        */
        protected void gvMaintenance_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            ViewState["z_sortexpresion"] = e.SortExpression;
            if (GridViewSortDirection == SortDirection.Ascending)
            {
                ViewState["CurrentSortDirection"] = "DESC";
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(gvMaintenance, sortExpression, "DESC");
            }
            else
            {
                ViewState["CurrentSortDirection"] = "ASC";
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(gvMaintenance, sortExpression, "ASC");
            }
        }

        /**
        * Determines if the sorting is by ascending or descending
        * 
        * @since version 1.0 
        * @return SortDirection
        */
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

        protected Boolean AtLeastOneChecked()
        {
            for (int i = 0; i < gvCheckBox.Rows.Count; i++)
            {
                GridViewRow row = gvCheckBox.Rows[i];

                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox check = (CheckBox)row.FindControl("DeleteCheckbox");

                    if (check != null && check.Checked)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected void lbDeleteSelected_Click(object sender, EventArgs e)
        {
            if (AtLeastOneChecked())
            {
                if (_BLL.SessionIsActive(this))
                {
                    StringBuilder builder = new StringBuilder();

                    for (int i = 0; i < gvCheckBox.Rows.Count; i++)
                    {
                        GridViewRow row = gvCheckBox.Rows[i];

                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox check = (CheckBox)row.FindControl("DeleteCheckbox");

                            if (check != null && check.Checked)
                            {
                                builder.Append(gvMaintenance.Rows[i].Cells[0].Text + ",");

                                if (Maintenance.content_code == VG.c_ministry_department)
                                {
                                    _BLL.DeleteDepartment(gvMaintenance.Rows[i].Cells[0].Text);
                                }
                                else if (Maintenance.content_code == VG.c_user_group)
                                {
                                    string userList = "";

                                    foreach (GridViewRow r in gvMaintenance.Rows)
                                    {
                                        if (r.Cells[0].Text.Equals(gvMaintenance.Rows[i].Cells[0].Text))
                                        {
                                            userList = r.Cells[2].Text;
                                            break;
                                        }
                                    }

                                    if (userList.Length > 0 && !userList.Equals("&nbsp;"))
                                    {
                                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to delete the user group because it is still being used by the following users: " + userList + "', 'error');", true);
                                        return;
                                    }
                                    else
                                    {
                                        _BLL.DeleteUserGroup(gvMaintenance.Rows[i].Cells[0].Text);
                                    }
                                }
                                else if (Maintenance.content_code == VG.c_user)
                                {
                                    _BLL.DeleteUser(gvMaintenance.Rows[i].Cells[0].Text);
                                }
                                else if (Maintenance.content_code == VG.c_active_session)
                                {
                                    _BLL.DeleteActiveSessionByUserId(gvMaintenance.Rows[i].Cells[0].Text);
                                }
                                else if (Maintenance.content_code == VG.c_pepsol)
                                {
                                    _BLL.DeleteBranch(gvMaintenance.Rows[i].Cells[0].Text);
                                }
                                else if (Maintenance.content_code == VG.c_ministry)
                                {
                                    _BLL.DeleteDivision(gvMaintenance.Rows[i].Cells[0].Text);
                                }
                            }
                        }
                    }

                    _BLL.RemoveFromCache("Filter" + Maintenance.content_code + "&");

                    if (Maintenance.content_code == VG.c_user)
                        _BLL.RemoveFromCache("Filter" + VG.c_user_group + "&");

                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Delete", "Code: " + builder.ToString(0, builder.Length - 1), Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = "CLICKS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been deleted.','" + transactionReferenceNumber + "');", true);

                    LoadMaintenanceData(Maintenance.content_code, txtCode.Text, txtDescription.Text);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Please select at least one entry.', 'error');", true);
            }
        }
    }
}