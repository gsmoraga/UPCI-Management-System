using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using OfficeOpenXml.Table;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Template
{
    public partial class minsitry_dept_search : System.Web.UI.Page
    {
        DAL _DAL = new DAL();
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
                            { }
                            else
                            {
                                if (accessRights.Contains("&m3d,") || accessRights.Contains("&m3e,"))
                                {
                                    divSearch.Visible = true;
                                    lbSearch.Visible = true;
                                    divExport.Visible = true;
                                }
                                if (accessRights.Contains("&m3a,"))
                                {
                                    lbAdd.Visible = true;
                                }
                            }
                        }

                        gvMaintenance.PagerSettings.Visible = false; //hide Gridview Pager 
                        LoadMaintenanceData("", "");

                        _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "", Request.UserHostAddress.ToString());
                    }
                }
            }



        }

        #region Search
        protected void LoadMaintenanceData(string code, string description)
        {
            Boolean result = false;
            result = _BLL.FilterMinistryDepartment(gvMaintenance, code, description);

            if (result == false)
            {
                divExport.Visible = false;
                divPager.Visible = false;
            }
            else
            {
                divExport.Visible = true;
                divPager.Visible = true;
                PopulatePager(gvMaintenance.PageCount);
            }

            
        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LoadMaintenanceData(txtCode.Text, txtDescription.Text);
            }

        }

        protected void lbRefresh_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                txtCode.Text = "";
                txtDescription.Text = "";
                LoadMaintenanceData(txtCode.Text, txtDescription.Text);
            }
        }
        #endregion

        #region Action Buttons
        protected void lbView_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbView = (LinkButton)sender;
                Maintenance.entry_code = lbView.CommandArgument;
                Maintenance.content_code = VG.c_ministry_department;
                Maintenance.mode = "View";

                _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "Code: " + Maintenance.entry_code, Request.UserHostAddress.ToString());

                Response.Redirect("dept-ministry-view.aspx", false);
            }
        }

        protected void lbEdit_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbEdit = (LinkButton)sender;
                Maintenance.entry_code = lbEdit.CommandArgument;
                Maintenance.content_code = VG.c_ministry_department;
                Maintenance.mode = "Edit";

                Response.Redirect("dept-ministry-edit.aspx", false);
            }
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Maintenance.content_code = VG.c_ministry_department;
                Maintenance.mode = "Add";
                Response.Redirect("dept-ministry-add.aspx", false);
            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                LinkButton lbDelete = (LinkButton)sender;
                string code = lbDelete.CommandArgument;
                Boolean result = false;

                result = _BLL.DeleteMinistryDepartment(code);

                if (result == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to delete the entry.', 'error');", true);
                }
                else
                {

                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Delete", "Code: " + code, Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmm") + "-" + DateTime.Now.ToString("ssff");

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Ministry has been deleted.','" + transactionReferenceNumber + "');", true);
                    LoadMaintenanceData("", "");
                }
            }
        }
        #endregion

        #region GridView
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

            }

            string accessRights = Employee.access_rights;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (accessRights.Contains("&m" + Maintenance.content_code + "d,"))
                {
                    LinkButton lb = (LinkButton)e.Row.FindControl("lbEdit");
                    lb.Visible = true;
                }
                if (accessRights.Contains("&m" + Maintenance.content_code + "d,"))
                {
                    LinkButton lb = (LinkButton)e.Row.FindControl("lbDelete");
                    lb.Visible = true;
                }

                System.Data.DataView dv = (e.Row.DataItem as System.Data.DataRowView).DataView;
                ViewState["Sorting"] = dv.ToTable();

                //if (!Maintenance.bank_user_security && accessRights.Contains("&m" + Maintenance.content_code + "d,"))
                //{
                //    int numRows = 0;
                //    if (gvMaintenance.Rows.Count > 9)
                //        numRows = 10;
                //    else
                //        numRows = gvMaintenance.Rows.Count;

                //    List<int> rows = new List<int>();

                //    for (int i = 0; i <= numRows; i++)
                //    {
                //        rows.Add(i);
                //    }
                //    //gvCheckBox.DataSource = rows;
                //    //gvCheckBox.DataBind();
                //}
            }
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
            BindGridView();
        }

        #region Custom Pager


        private void PopulatePager(int pageCount)
        {
            //lblTotalRowCount.Text = Convert.ToString(DTSorting.Rows.Count);
            lblTotalPageCount.Text = Convert.ToString(pageCount);

            ddPageNumber.Items.Clear();
            for (int i = 1; i <= pageCount; i++)
            {

                ddPageNumber.Items.Add(new System.Web.UI.WebControls.ListItem(Convert.ToString(i), Convert.ToString(i - 1)));

            }
            if (pageCount > Maintenance.page_index)
            {

                ddPageNumber.SelectedValue = Convert.ToString(Maintenance.page_index);
            }
            else
            {
                ddPageNumber.SelectedIndex = -1;

            }
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
            //gvMaintenance.PageSize = Convert.ToInt16(ddPageSize.SelectedValue);
            //BindGridView();
            //PopulatePager(gvMaintenance.PageCount);
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
            gvMaintenance.PageIndex = Convert.ToInt16(ddPageNumber.SelectedValue);
            Maintenance.page_index = Convert.ToInt16(ddPageNumber.SelectedValue);
            BindGridView();
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbFirstPage_Click(object sender, EventArgs e)
        {
            if (gvMaintenance.PageIndex > 0)
            {
                gvMaintenance.PageIndex = Convert.ToInt16(ddPageNumber.Items[0].Value);
                Maintenance.page_index = Convert.ToInt16(ddPageNumber.Items[0].Value);
                BindGridView();
                ddPageNumber.SelectedValue = Convert.ToString(Maintenance.page_index);
            }
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbPreviousPage_Click(object sender, EventArgs e)
        {
            if (gvMaintenance.PageIndex > 0)
            {
                Maintenance.page_index -= 1;
                gvMaintenance.PageIndex -= 1;
                BindGridView();
                ddPageNumber.SelectedValue = Convert.ToString(Maintenance.page_index);
            }
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbNextPage_Click(object sender, EventArgs e)
        {
            if (gvMaintenance.PageIndex < gvMaintenance.PageCount - 1)
            {
                Maintenance.page_index += 1;
                gvMaintenance.PageIndex += 1;
                BindGridView();
                ddPageNumber.SelectedValue = Convert.ToString(Maintenance.page_index);
            }
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbLastPage_Click(object sender, EventArgs e)
        {
            if (gvMaintenance.PageIndex < gvMaintenance.PageCount)
            {
                Maintenance.page_index = gvMaintenance.PageCount - 1;
                gvMaintenance.PageIndex = gvMaintenance.PageCount - 1;
                BindGridView();
                ddPageNumber.SelectedValue = Convert.ToString(Maintenance.page_index);
            }
        }

        #endregion


        protected void BindGridView()
        {
            gvMaintenance.DataSource = DTSorting;
            gvMaintenance.DataBind();

            if (ViewState["z_sortexpression"] != null)
            {
                SortGridView(gvMaintenance, Convert.ToString(ViewState["z_sortexpression"]), Convert.ToString(ViewState["CurrentSortDirection"]));
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
                    Response.AddHeader("content-disposition", "attachment;filename=\"" + VG.application_name + "-" + Maintenance.content_description + " - " + DateTime.Now.ToString("yyyyMMdd") + ".xlsx\"");

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
                            Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
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

        #endregion

    }
}