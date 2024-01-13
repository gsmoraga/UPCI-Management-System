using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class search_age_group : System.Web.UI.Page
    {
        DAL _DAL = new DAL();
        BLL _BLL = new BLL();
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
                    //if (_BLL.GetApplicationParameters())
                    //{
                    //}
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
                            { }
                            else
                            {
                                lblHeader.Text = Maintenance.content_description + " Maintenance";

                                if (accessRights.Contains("&m13d,") || accessRights.Contains("&m13e,"))
                                {
                                    divSearch.Visible = true;
                                    lbSearch.Visible = true;
                                    divExport.Visible = true;

                                    if (accessRights.Contains("&m13d,"))
                                    {
                                        divDeleteCheckbox.Visible = true;
                                        divDeleteSelectedButton.Visible = true;
                                    }
                                }
                            }
                        }

                        LoadGridView(gvMaintenance, txtCode.Text, txtDescription.Text);

                        _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "", Request.UserHostAddress.ToString());
                    }
                }
            }

        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                gvMaintenance.PageIndex = 0;

                LoadGridView(gvMaintenance, txtCode.Text, txtDescription.Text);
                _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Search", txtCode.Text + " " + txtDescription.Text, Request.UserHostAddress.ToString());
            }
        }

        protected void lbRefresh_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                gvMaintenance.PageIndex = 0;
                LoadGridView(gvMaintenance, "", "");
                txtCode.Text = "";
                txtDescription.Text = "";

            }
        }

        protected void lbExportExcel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (gvMaintenance.Rows.Count > 0)
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
                    Response.AddHeader("content-disposition", "attachment;filename=\"" + VG.application_name + "-" + Maintenance.content_description + "-" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx\"");

                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add(Maintenance.content_description);
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

        public override void VerifyRenderingInServerForm(Control control)
        {
            //dont delete or your life will be ruin.
        }

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
                            Paragraph para = new Paragraph(VG.application_name + "-" + Maintenance.report_header, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16));
                            para.Alignment = Element.ALIGN_CENTER;
                            Paragraph space = new Paragraph("\n");
                            pdfDoc.Add(para);
                            pdfDoc.Add(space);
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                            pdfDoc.Close();
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=\"" + VG.application_name + "-" + Maintenance.content_description + "-" + DateTime.Now.ToString("yyyyMMdd") + ".pdf\"");
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


                                //_DAL.boolResidentAgeGroup(gvMaintenance.Rows[i].Cells[0].Text, "", "", "DEL");
                                //_DAL.savedDeleted(gvMaintenance.Rows[i].Cells[0].Text, gvMaintenance.Rows[i].Cells[1].Text, Maintenance.content_code, Employee.user_id);

                            }
                        }
                    }
                    _BLL.RemoveFromCache("Filter" + Maintenance.content_code + "&");



                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Delete", "Code: " + builder.ToString(0, builder.Length - 1), Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = VG.application_name + "-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + DateTime.Now.ToString("HHmmssffff");

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been deleted.','" + transactionReferenceNumber + "');", true);

                    LoadGridView(gvMaintenance, "", "");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Please select at least one entry.', 'error');", true);
            }
        }





        #region GridView
        protected void gvMaintenance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
            }

            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {

            }



            string accessRights = Employee.access_rights;

            if (e.Row.RowType == DataControlRowType.DataRow)
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



                System.Data.DataView dv = (e.Row.DataItem as System.Data.DataRowView).DataView;
                ViewState["Sorting"] = dv.ToTable();

                //if (!Maintenance.bank_user_security && accessRights.Contains("&m" + Maintenance.content_code + "d,"))
                //{
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
                //}

                if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
                {

                }
            }
        }
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

        private void SortGridView(GridView gv, string sortExpression, string direction)
        {
            DTSorting = new DataView(DTSorting, "", sortExpression + " " + direction, DataViewRowState.CurrentRows).ToTable();
            gv.DataSource = DTSorting;
            gv.DataBind();
        }

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

        #endregion

        protected void lbView_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbView = (LinkButton)sender;
                string[] commandArgs = lbView.CommandArgument.ToString().Split(new char[] { ';' });
                string code = commandArgs[0];


                Maintenance.mode = "View";
                //DataTable dt = _DAL.dtResidentAgeGroup(code, "", "", "VIEW");

                //lblViewCode.InnerText = Convert.ToString(dt.Rows[0]["code"]);
                //lblViewDescription.InnerText = Convert.ToString(dt.Rows[0]["description"]);
                //lblMinAge.InnerText = Convert.ToString(dt.Rows[0]["min_age"]);
                //lblMaxAge.InnerText = Convert.ToString(dt.Rows[0]["max_age"]);

                //Show Fields for View
                View();

                _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "Code: " + Maintenance.entry_code, Request.UserHostAddress.ToString());
            }


        }
        protected void lbViewBack_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                pnlSearch.Visible = true;
                divExport.Visible = true;

                pnlView.Visible = false;
                pnlEdit.Visible = false;

                LoadGridView(gvMaintenance, "", "");
            }
        }
        protected void lbEdit_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbEdit = (LinkButton)sender;
                string[] commandArgs = lbEdit.CommandArgument.ToString().Split(new char[] { ';' });
                string code = commandArgs[0];


                Maintenance.mode = "Edit";
                //DataTable dt = _DAL.dtResidentAgeGroup(code, "", "", "VIEW");

                //lblEditCode.Text = Convert.ToString(dt.Rows[0]["code"]);
                //txtEditDescription.Text = Convert.ToString(dt.Rows[0]["description"]);
                //txtEditMinAge.Text = Convert.ToString(dt.Rows[0]["min_age"]);
                //txtEditMaxAge.Text = Convert.ToString(dt.Rows[0]["max_age"]);


                //Show Fields for Edit
                Edit();

                _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Edit", "Code: " + Maintenance.entry_code, Request.UserHostAddress.ToString());
            }


        }


        protected void lbDelete_Click(object sender, EventArgs e)
        {
            LinkButton lbDelete = (LinkButton)sender;
            string[] commandArgs = lbDelete.CommandArgument.ToString().Split(new char[] { ';' });
            string code = commandArgs[0];
            string description = commandArgs[1];
            Boolean result = false;
            //result = _DAL.boolResidentAgeGroup(code, "", "", "DEL");


            if (result == false)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to delete the entry.', 'error');", true);
            }
            else
            {

                //_DAL.savedDeleted(code, description, Maintenance.content_code, Employee.user_id);
                string transactionReferenceNumber = "";
                if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Delete", "Code: " + code, Request.UserHostAddress.ToString()))
                    transactionReferenceNumber = VG.application_name+"-"+ DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + DateTime.Now.ToString("HHmmssffff");

                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been deleted.','" + transactionReferenceNumber + "');", true);
                LoadGridView(gvMaintenance, "", "");
            }
        }

        void View()
        {
            divGridView.Visible = false;
            pnlSearch.Visible = false;
            divExport.Visible = false;
            pnlView.Visible = true;
            lblViewDescription.Visible = true;
            ViewDescCard.Visible = true;
            lbViewBack.Visible = true;
        }

        void Edit()
        {
            divGridView.Visible = false;
            pnlSearch.Visible = false;
            divExport.Visible = false;
            pnlView.Visible = false;

            pnlEdit.Visible = true;

            lbEditBack.Visible = true;
            lbEditSave.Visible = true;
        }
        void LoadGridView(GridView gv, string code, string description)
        {
            DataTable dt = new DataTable();

            //dt = _DAL.dtResidentAgeGroup(code, description, "", "FIL");
            gv.DataSource = dt;
            gv.DataBind();

            if (dt.Rows == null || dt.Rows.Count == 0)
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

            divGridView.Visible = true;
        }

        protected void lbEditSave_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (string.IsNullOrWhiteSpace(txtEditDescription.Text) || txtEditDescription.Text.Length < 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Please Enter Details.', '', 'error');", true);
                }
                else
                {

                    //_DAL.boolResidentAgeGroup(lblEditCode.Text.Trim(), txtEditDescription.Text.Trim(),"", "UPD");


                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Edit", "", Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = VG.application_name+"-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + DateTime.Now.ToString("HHmmssffff");

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been updated.','" + transactionReferenceNumber + "');", true);

                    pnlSearch.Visible = true;
                    divExport.Visible = true;


                    LoadGridView(gvMaintenance, "", "");
                    pnlEdit.Visible = false;

                }
            }
        }

        protected void lbEditBack_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                pnlSearch.Visible = true;
                divExport.Visible = true;

                pnlEdit.Visible = false;
                pnlView.Visible = false;

                LoadGridView(gvMaintenance, "", "");
            }
        }
    }
}