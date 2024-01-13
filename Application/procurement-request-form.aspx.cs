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
    public partial class procurement_request_from : System.Web.UI.Page
    {
        DAL _DAL = new DAL();
        BLL _BLL = new BLL();
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
                        hfTransRefNumber.Value = Convert.ToString(Session["transactionReferenceNumber"]);
                        LoadDetailsFromSession(hfTransRefNumber.Value);

                        string accessRights = Employee.access_rights;
                        if (EPS.workflow_status == VG.ws_approved_by_division_head)
                        {
                            lbPrintTop.Visible = true;
                            divRemarks.Visible = true;
                            divLinkButtons.Visible = true;
                            lbRecommend.Visible = true;
                            lbReturn.Visible = true;
                            lbDecline.Visible = true;
                            
                        }
                        if (EPS.workflow_status == VG.ws_recommended_by_procurement_department)
                        {
                            lbPrintTop.Visible = true;
                            divRemarks.Visible = true;
                            divLinkButtons.Visible = true;

                            //if(accessRights.Contains())
                            lbApprove.Visible = true;
                            lbReturn.Visible = true;
                            lbDecline.Visible = true;

                            lbBackTop.Visible = false;

                        }

                        if (EPS.workflow_status == VG.ws_approved_by_hope)
                        {
                            lbBackTop.Visible = true;
                            lbPrintTop.Visible = true;
                        }

                        if (EPS.workflow_status == VG.ws_submitted_to_bac)
                        {
                            lbBackTop.Visible = true;
                            lbPrintTop.Visible = true;
                        }
                    }
                }
            }

        }

        protected void LoadDetailsFromSession(string transactionReferenceNumber)
        {
            DataTable dt = new DataTable();
            //dt = _DAL.GetRequestDetails(transactionReferenceNumber);

            if (dt.Rows.Count == 0 || dt.Rows == null)
            { }
            else
            {
                EPS.workflow_status = Convert.ToString(dt.Rows[0]["workflow_status"]);


                lblProcurementUnit.Text = Convert.ToString(dt.Rows[0]["procurement_unit"]);
                lblControlNo.Text = Convert.ToString(dt.Rows[0]["control_no"]);

                #region Procure Items Checkbox
                string procureItems = Convert.ToString(dt.Rows[0]["procure_items"]);
                if (procureItems == "ITM001")
                {
                    CHK001.Checked = true;
                }
                else if (procureItems == "ITM002")
                {
                    CHK002.Checked = true;
                    lblReportDate.Visible = true;
                    lblReportDate.Text = Convert.ToString(dt.Rows[0]["replacement_date"]);
                }
                else if (procureItems == "ITM003")
                {
                    CHK003.Checked = true;
                }
                else if (procureItems == "ITM004")
                {
                    CHK004.Checked = true;
                    lblNumberOfExistingUnits.Visible = true;
                    lblNumberOfExistingUnits.Text = Convert.ToString(dt.Rows[0]["number_of_existing_units"]);
                    lblAllowedUnitsPerFFFE.Visible = true;
                    lblAllowedUnitsPerFFFE.Text = Convert.ToString(dt.Rows[0]["allowed_units_per_FFFE"]);
                }
                else if (procureItems == "ITM005")
                {
                    CHK005.Checked = true;
                    lblOthers.Visible = true;
                    lblOthers.Text = Convert.ToString(dt.Rows[0]["others"]);
                }
                #endregion

                #region Nature of Procurement
                string natureOfProcurement = Convert.ToString(dt.Rows[0]["nature_of_procurement"]);
                if (natureOfProcurement == "NOP001")
                {
                    CHKGoodAndServices.Checked = true;
                }
                if (natureOfProcurement == "NOP002")
                {
                    CHKCivilWorks.Checked = true;
                }
                if (natureOfProcurement == "NOP003")
                {
                    CHKConsultancy.Checked = true;
                }
                #endregion

                //rblProcureItems.SelectedValue = Convert.ToString(dt.Rows[0]["procure_items"]);
                //rblProcurementNature.SelectedValue = Convert.ToString(dt.Rows[0]["nature_of_procurement"]);


                lblModeOfProcurement.Text = Convert.ToString(dt.Rows[0]["mode_of_procurement"]);

                lblPurpose.Text = Convert.ToString(dt.Rows[0]["purpose"]);

                lblEstimatedMonthsToUse.Text = Convert.ToString(dt.Rows[0]["estimated_months_to_use"]);
                lblMonthlyAverageUsage.Text = Convert.ToString(dt.Rows[0]["monthly_average_usage"]);
                lblThisRequisition.Text = Convert.ToString(dt.Rows[0]["this_requisition"]);

                lblItemDescription.Text = Convert.ToString(dt.Rows[0]["item_description"]);
                lblQuantity.Text = Convert.ToString(dt.Rows[0]["quantity"]);
                lblUnitCost.Text = Convert.ToString(dt.Rows[0]["unit_cost"]);
                lblTotal.Text = Convert.ToString(dt.Rows[0]["total"]);
                lblBalanceOnHand.Text = Convert.ToString(dt.Rows[0]["balance_on_hand"]);

                lblBudgetYear.Text = Convert.ToString(dt.Rows[0]["budget_year"]);
                lblAccount.Text = Convert.ToString(dt.Rows[0]["account"]);
                lblAmount.Text = Convert.ToString(dt.Rows[0]["amount"]);
                lblChargeableUnit.Text = Convert.ToString(dt.Rows[0]["unit_department"]);
                lblCertifiedBy.Text = Convert.ToString(dt.Rows[0]["certified_by"]);
                lblCertifiedDate.Text = Convert.ToString(dt.Rows[0]["date_certified"]);



                //rblProcureItems_SelectedIndexChanged(null, null);






                #region Signature
                lblPreparedBy.Text = Convert.ToString(dt.Rows[0]["prepared_by"]);
                lblEndorsedBy.Text = Convert.ToString(dt.Rows[0]["endorsed_by"]);
                lblApprovedBy.Text = Convert.ToString(dt.Rows[0]["approved_by"]);
                #endregion
            }



        }

        protected void lbPrintTop_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "PrintPRF", "$('#divPrintInd').printThis();", true);
        }



        protected void rblProcureItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rblProcureItems.Items[1].Selected)
            //    rblProcureItems.
            //    //divReportDated2.Visible = true;
            //else
            //    //divReportDated2.Visible = false;

            //if (rblProcureItems.Items[3].Selected)
            //    //divAdditionalItems2.Visible = true;
            //else
            //    //divAdditionalItems2.Visible = false;

            //if (rblProcureItems.Items[4].Selected)
            //    //divOthers2.Visible = true;
            //else
            //    //divOthers2.Visible = false;
        }

        protected void lbBackTop_Click(object sender, EventArgs e)
        {
            if (Maintenance.content_code == VG.c_quotation_request)
            {
                Response.Redirect("procurement-qoutation-request-form.aspx", false);
            }

            //if (Maintenance.content_code == VG.c_purchase_request)
            //{
            //    Response.Redirect("procurement-qoutation-request-form.aspx", false);
            //}
        }

        protected void lbRecommend_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                string workflowStatus = EPS.workflow_status;
                //Recommend to H.O.P.E
                if (workflowStatus == VG.ws_approved_by_division_head)
                {
                    //_DAL.UpdateWorkflowStatus(hfTransRefNumber.Value, VG.ws_recommended_by_procurement_department, VG.approved);
                    //_DAL.AddActionLog(hfTransRefNumber.Value, Employee.user_id, VG.ar_proc_dept, "", VG.ws_recommended_by_procurement_department);
                }

                //Recommended to BAC
                if (workflowStatus == VG.ws_approved_by_hope)
                {
                    //_DAL.UpdateWorkflowStatus(hfTransRefNumber.Value, VG.ws_recommended_by_procurement_department, VG.approved);
                    //_DAL.AddActionLog(hfTransRefNumber.Value, Employee.user_id, VG.ar_proc_dept, "", VG.ws_recommended_by_procurement_department);
                }


                string transactionReferenceNumber = "";
                if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "TRN: " + hfTransRefNumber.Value, Request.UserHostAddress.ToString()))
                    transactionReferenceNumber = hfTransRefNumber.Value;


                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "alertRedirect('Homepage.aspx','Application successfully recommended!','" + hfTransRefNumber.Value + "','success');", true);
            }
        }

        protected void lbApprove_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                //_DAL.UpdateWorkflowStatus(hfTransRefNumber.Value, VG.ws_approved_by_hope, VG.pending);
                //_DAL.AddActionLog(hfTransRefNumber.Value, Employee.user_id, VG.ar_hope, "APP", VG.ws_approved_by_hope);

                string transactionReferenceNumber = "";
                if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "TRN: " + hfTransRefNumber.Value, Request.UserHostAddress.ToString()))
                    transactionReferenceNumber = hfTransRefNumber.Value;


                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "alertRedirect('Homepage.aspx','Application has been approved!','" + hfTransRefNumber.Value + "','success');", true);
            }
        }
    }


}