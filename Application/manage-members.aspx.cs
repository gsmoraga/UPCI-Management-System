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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class manage_members : System.Web.UI.Page
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


                        //lblHeader.Text = "Inquiry-All";
                        //pnlInquiry.Visible = true;

                        //LoadDropdowns();
                        //LoadMaintenanceData(gvMaintenance,"","","","","","");
                    }
                }
            }
        }

        protected void LoadDropdowns()
        {
            //DataTable dtMinistry = new DataTable();
            //dtMinistry = _DAL.GetMinistry();
            //ddMinistry.DataSource = dtMinistry;
            //ddMinistry.DataValueField = "Code";
            //ddMinistry.DataTextField = "Description";
            //ddMinistry.DataBind();
            //ddMinistry.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--All--", "0"));

            //DataTable dtStatus = new DataTable();
            //dtStatus = _DAL.GetMembershipStatus();
            //ddMembershipStatus.DataSource = dtStatus;
            //ddMembershipStatus.DataValueField = "Code";
            //ddMembershipStatus.DataTextField = "Description";
            //ddMembershipStatus.DataBind();
            //ddMembershipStatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--All--", "0"));


        }
        protected void LoadMaintenanceData(GridView gv, string memberId, string name, string gender, string membershipStatus, string ministry,string status)
        {
            Boolean result = false;
            result = _BLL.FilterMembers(gv, memberId, name, gender, membershipStatus, ministry, status);
            
            if (result == false)
            {
                //gvCheckBox.Visible = false;
                //lbDeleteSelected.Visible = false;
                //divExport.Visible = false;
            }
            else
            {
                //gvCheckBox.Visible = true;
                //lbDeleteSelected.Visible = true;
                //divExport.Visible = true;
            }
        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            //LoadMaintenanceData(txtMemberId.Text, txtName.Text, ddGender.SelectedValue, ddMembershipStatus.SelectedValue, ddMinistry.SelectedValue,ddStatus.SelectedValue);
        }

        protected void lbRefresh_Click(object sender, EventArgs e)
        {
            //txtMemberId.Text = "";
            //txtName.Text = "";
            //ddGender.SelectedIndex = 0; 
            //ddMembershipStatus.SelectedIndex = 0; 
            //ddMinistry.SelectedIndex = 0;
            //ddStatus.SelectedIndex = 0;
            

            //LoadMaintenanceData(txtMemberId.Text, txtName.Text, ddGender.SelectedValue, ddMembershipStatus.SelectedValue, ddMinistry.SelectedValue,ddStatus.SelectedValue);
        }

        protected void lbView_Click(object sender, EventArgs e)
        {
            //if (_BLL.SessionIsActive(this))
            //{
            //    LinkButton lbView = (LinkButton)sender;
            //    Maintenance.entry_code = lbView.CommandArgument;

            //    Maintenance.mode = "Inquiry";

            //    Session["transactionReferenceNumber"] = lbView.CommandArgument;

            //    _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "Code: " + Maintenance.entry_code, Request.UserHostAddress.ToString());

            //    //Response.Redirect("view-purchase-requisition-form.aspx", false);
            //}
        }

        protected void lbEdit_Click(object sender, EventArgs e)
        {
            //if (_BLL.SessionIsActive(this))
            //{
            //    LinkButton lbEdit = (LinkButton)sender;
            //    Maintenance.entry_code = lbEdit.CommandArgument;
            //    Maintenance.mode = "Edit";

            //    //Response.Redirect("maintenance-parameters.aspx", false);
            //}
        }

        

        #region Gridview
        protected void gvApplication_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string accessRights = Employee.access_rights;

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
            }
        }
        /**
        * Allows paging of the GridView
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param GridViewPageEventArgs e - contains the event data
        */
        protected void gvApplication_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gvApplication.PageIndex = e.NewPageIndex;
            //EPS.page_index = e.NewPageIndex;
            //BindGridView();
        }

        #region Custom Pager

        private void PopulatePager(int pageCount)
        {
            //lblTotalRowCount.Text = Convert.ToString(DTSorting.Rows.Count);
            //lblTotalPageCount.Text = Convert.ToString(pageCount);

            //ddPageNumber.Items.Clear();
            //for (int i = 1; i <= pageCount; i++)
            //{
            //    ddPageNumber.Items.Add(new System.Web.UI.WebControls.ListItem(Convert.ToString(i), Convert.ToString(i - 1)));
            //}
            //if (pageCount > EPS.page_index)
            //    ddPageNumber.SelectedValue = Convert.ToString(EPS.page_index);
            //else
            //    ddPageNumber.SelectedIndex = -1;
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
            //gvApplication.PageSize = Convert.ToInt16(ddPageSize.SelectedValue);
            //BindGridView();
            //PopulatePager(gvApplication.PageCount);
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
            //gvApplication.PageIndex = Convert.ToInt16(ddPageNumber.SelectedValue);
            //EPS.page_index = Convert.ToInt16(ddPageNumber.SelectedValue);
            //BindGridView();
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbFirstPage_Click(object sender, EventArgs e)
        {
            //if (gvApplication.PageIndex > 0)
            //{
            //    gvApplication.PageIndex = Convert.ToInt16(ddPageNumber.Items[0].Value);
            //    EPS.page_index = Convert.ToInt16(ddPageNumber.Items[0].Value);
            //    BindGridView();
            //    ddPageNumber.SelectedValue = Convert.ToString(EPS.page_index);
            //}
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbPreviousPage_Click(object sender, EventArgs e)
        {
            //if (gvApplication.PageIndex > 0)
            //{
            //    EPS.page_index -= 1;
            //    gvApplication.PageIndex -= 1;
            //    BindGridView();
            //    ddPageNumber.SelectedValue = Convert.ToString(EPS.page_index);
            //}
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbNextPage_Click(object sender, EventArgs e)
        {
            //if (gvApplication.PageIndex < gvApplication.PageCount - 1)
            //{
            //    EPS.page_index += 1;
            //    gvApplication.PageIndex += 1;
            //    BindGridView();
            //    ddPageNumber.SelectedValue = Convert.ToString(EPS.page_index);
            //}
        }

        /**
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbLastPage_Click(object sender, EventArgs e)
        {
            //if (gvApplication.PageIndex < gvApplication.PageCount)
            //{
            //    EPS.page_index = gvApplication.PageCount - 1;
            //    gvApplication.PageIndex = gvApplication.PageCount - 1;
            //    BindGridView();
            //    ddPageNumber.SelectedValue = Convert.ToString(EPS.page_index);
            //}
        }

        #endregion

        protected void BindGridView()
        {
            //gvApplication.DataSource = DTSorting;
            //gvApplication.DataBind();

            //if (ViewState["z_sortexpression"] != null)
            //{
            //    SortGridView(gvApplication, Convert.ToString(ViewState["z_sortexpression"]), Convert.ToString(ViewState["CurrentSortDirection"]));
            //}
        }

        protected void lbExportExcel_Click(object sender, EventArgs e)
        {
            //if (_BLL.SessionIsActive(this))
            //{
            //    if (gvApplication.Rows.Count > 0)
            //    {
            //        DataTable dt = new DataTable();
            //        dt.Clear();
            //        dt = (DataTable)ViewState["Sorting"];

            //        if (Maintenance.content_code == VG.c_user || Maintenance.content_code == VG.c_active_session)
            //        {
            //            dt.Columns.RemoveAt(0);
            //        }

            //        _BLL.GetApplicationParameters();
            //        int maxExtractableCount = 1;
            //        if (Convert.ToInt32(Maintenance.max_extractable_record_count) > dt.Rows.Count)
            //            maxExtractableCount = dt.Rows.Count;
            //        else
            //            maxExtractableCount = Convert.ToInt32(Maintenance.max_extractable_record_count);

            //        DataTable dtn = dt.Clone();
            //        for (int i = 0; i < maxExtractableCount; i++)
            //        {
            //            dtn.ImportRow(dt.Rows[i]);
            //        }

            //        Response.Clear();
            //        Response.Buffer = true;
            //        Response.Charset = "";
            //        Response.ContentEncoding = System.Text.Encoding.UTF8;
            //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //        Response.AddHeader("content-disposition", "attachment;filename=\"EPS " + Maintenance.content_description + " " + DateTime.Now.ToString("yyyyMMdd") + ".xlsx\"");

            //        using (ExcelPackage pck = new ExcelPackage())
            //        {
            //            ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add(Maintenance.content_description);
            //            wsDt.Cells["A1:" + alphabet[dtn.Columns.Count - 1].ToString() + "1"].Merge = true;
            //            wsDt.Cells["A1"].Value = Maintenance.report_header;
            //            wsDt.Cells["A2"].LoadFromDataTable(dtn, true, TableStyles.Medium2);
            //            wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();

            //            Response.BinaryWrite(pck.GetAsByteArray());
            //        }

            //        Response.Flush();
            //        Response.End();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Nothing to export.', 'error');", true);
            //    }
            //}
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
            //if (_BLL.SessionIsActive(this))
            //{
            //    if (gvApplication.Rows.Count > 0)
            //    {
            //        this.gvApplication.Columns[0].Visible = false;
            //        gvApplication.AllowPaging = false;
            //        gvApplication.AllowSorting = false;

            //        DataTable dt = new DataTable();
            //        dt.Clear();
            //        dt = (DataTable)ViewState["Sorting"];

            //        _BLL.GetApplicationParameters();
            //        int maxExtractableCount = 1;
            //        if (Convert.ToInt32(Maintenance.max_extractable_record_count) > dt.Rows.Count)
            //            maxExtractableCount = dt.Rows.Count;
            //        else
            //            maxExtractableCount = Convert.ToInt32(Maintenance.max_extractable_record_count);

            //        DataTable dtn = dt.Clone();
            //        for (int i = 0; i < maxExtractableCount; i++)
            //        {
            //            dtn.ImportRow(dt.Rows[i]);
            //        }

            //        gvApplication.DataSource = dtn;
            //        gvApplication.DataBind();

            //        using (StringWriter sw = new StringWriter())
            //        {
            //            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            //            {
            //                gvApplication.RenderControl(hw);
            //                StringReader sr = new StringReader(sw.ToString());
            //                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //                pdfDoc.Open();
            //                Paragraph para = new Paragraph(Maintenance.report_header, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16));
            //                para.Alignment = Element.ALIGN_CENTER;
            //                Paragraph space = new Paragraph("\n");
            //                pdfDoc.Add(para);
            //                pdfDoc.Add(space);
            //                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            //                pdfDoc.Close();
            //                Response.ContentType = "application/pdf";
            //                Response.AddHeader("content-disposition", "attachment;filename=\"EPS " + Maintenance.content_description + " " + DateTime.Now.ToString("yyyyMMdd") + ".pdf\"");
            //                Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //                Response.Write(pdfDoc);
            //                Response.End();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Nothing to export.', 'error');", true);
            //    }
            //}
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
        protected void gvApplication_Sorting(object sender, GridViewSortEventArgs e)
        {
            //string sortExpression = e.SortExpression;
            //ViewState["z_sortexpression"] = e.SortExpression;
            //if (GridViewSortDirection == SortDirection.Ascending)
            //{
            //    ViewState["CurrentSortDirection"] = "DESC";
            //    GridViewSortDirection = SortDirection.Descending;
            //    SortGridView(gvApplication, sortExpression, "DESC");
            //}
            //else
            //{
            //    ViewState["CurrentSortDirection"] = "ASC";
            //    GridViewSortDirection = SortDirection.Ascending;
            //    SortGridView(gvApplication, sortExpression, "ASC");
            //}
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



        #endregion

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Response.Redirect("add-member-form.aspx", false);
            }
        }
    }
}