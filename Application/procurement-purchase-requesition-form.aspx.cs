using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class purchase_request_form : System.Web.UI.Page
    {
        BLL _BLL = new BLL();
        DAL _DAL = new DAL();
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
                        if (_BLL.GetContentType(Maintenance.content_code) == false)
                        { }
                        else
                        {

                            lblBreadcrumbHead.Text = "Purchase Requisition";
                            string accessRights = Employee.access_rights;

                            #region Requesting Officer
                            if (accessRights.Contains(VG.ar_req_officer))
                            {
                                lblBreadcrumbMain.Text = "Request";
                                pnlFirstPage.Visible = true;
                                lbNext.Visible = true;
                            }
                            #endregion

                            #region Budget Custodian
                            if (accessRights.Contains(VG.ar_budg_cust))
                            {
                                lblBreadcrumbMain.Text = "View";
                                divBudgetFunds.Visible = true;
                                pnlConfirmationPage.Visible = true;
                                pnlBudget.Visible = true;
                                divRemarks.Visible = true;

                                if (accessRights.Contains(VG.ar_budg_cust_recommend))
                                {
                                    lbRecommend.Visible = true;
                                }
                                if (accessRights.Contains(VG.ar_budg_cust_return))
                                {
                                    lbReturn.Visible = true;
                                }


                                hfTransRefNumber.Value = Convert.ToString(Session["transactionReferenceNumber"]);
                                LoadDetailsFromSession(hfTransRefNumber.Value);
                            }
                            #endregion
                        }

                    }
                }
            }

        }

        #region LinkButton Events

        #region Requesting Officer
        protected void lbNext_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Next();
            }

        }
        protected void lbBack_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Back();
            }
        }
        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                string transactionReferenceNumber ="EPS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + DateTime.Now.ToString("HHmmssffff");

                //_DAL.AddPurchaseRequstInfo(transactionReferenceNumber, Convert.ToString(ViewState["ProcurementUnit"]), Convert.ToString(ViewState["ControlNo"]), Convert.ToString(ViewState["ProcureItems"]), Convert.ToString(ViewState["NatureOfProcurement"]), Convert.ToString(ViewState["ModeOfProcurement"]), Convert.ToString(ViewState["Purpose"]), Convert.ToString(ViewState["EstimatedMonthsToUse"]), Convert.ToString(ViewState["MonthlyAverageUsage"]), Convert.ToString(ViewState["ThisRequisition"]), VG.pending, VG.ws_submitted_by_requesting_officer);
                //_DAL.AddPurchaseRequestCost(transactionReferenceNumber, Convert.ToString(ViewState["ItemDescription"]), Convert.ToString(ViewState["Quantity"]), Convert.ToString(ViewState["UnitCost"]), Convert.ToString(ViewState["Total"]), Convert.ToString(ViewState["BalanceOnHand"]));
                //_DAL.AddPurchaseSignature(transactionReferenceNumber, Employee.user_id);
                //_DAL.AddPurchaseProcureItems(transactionReferenceNumber, rblProcureItems.SelectedValue, Convert.ToString(ViewState["ReportDate"]), Convert.ToString(ViewState["NumberOfExistingUnits"]), lblAllowedUnitsPerFFFE.Text = Convert.ToString(ViewState["AllowedUnitsPerFFFE"]));
                //_DAL.UpdateRemarks(transactionReferenceNumber, txtRemarks.Text.Trim());

                #region Logs
                //_DAL.AddActionLog(transactionReferenceNumber, Employee.user_id, VG.ar_req_officer, txtRemarks.Text.Trim(), VG.ws_submitted_by_requesting_officer);
                _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Add", "TRN: " + transactionReferenceNumber, Request.UserHostAddress.ToString());
                #endregion

                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Application has been submmitted to Division Budget Custodian','" + transactionReferenceNumber + "');", true);

                #region Email Notification
                //_DAL.SendEmailNoficationSubmitted("", "e-Procurement Notification", " has been submitted", transactionReferenceNumber, Convert.ToString(ViewState["ProcurementUnit"]), txtRemarks.Text.Trim(), VG.pending, VG.ws_submitted_by_requesting_officer, VG.ar_budg_cust_recommend);
                #endregion

                #region Show/Hide 
                pnlFirstPage.Visible = true;
                pnlConfirmationPage.Visible = false;
                lbBack.Visible = false;
                lbSubmit.Visible = false;
                lbNext.Visible = true;
                #endregion

                ClearValues();
            }
        }
        #endregion

        #region Budget Custodian
        protected void lbBackBudget_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                BackBudget();
            }
        }
        protected void lbNextBudget_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                NextBudget();
            }
        }

        protected void lbRecommend_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (Employee.access_rights.Contains(VG.ar_budg_cust))
                {

                    //_DAL.AddPurchaseRequestBudget(hfTransRefNumber.Value, txtBudgetYear.Text.Trim(), txtAccount.Text.Trim(), txtAmount.Text.Trim(), txtDepartment.Text.Trim(), Employee.user_id);
                    //_DAL.UpdateWorkflowStatus(hfTransRefNumber.Value, VG.ws_recommend_by_budget_custodian, VG.pending);
                    //_DAL.UpdateEndorserSignature(hfTransRefNumber.Value, Employee.user_id);
                    //_DAL.AddActionLog(hfTransRefNumber.Value, Employee.user_id, VG.ar_budg_cust, txtRemarks.Text.Trim(), VG.ws_recommend_by_budget_custodian);



                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "TRN: " + transactionReferenceNumber, Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = hfTransRefNumber.Value;

                    //_DAL.SendEmailNoficationSubmitted("", "e-Procurement System - Recommend Notification", " recommended", transactionReferenceNumber, lblProcurementUnit.Text.Trim(), txtRemarks.Text.Trim(), VG.pending, VG.ws_recommend_by_budget_custodian, VG.ar_div_head_approve);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "alertRedirect('Homepage.aspx','Application successfully Recommended!','" + hfTransRefNumber.Value + "','success');", true);
                }

                pnlBudget.Visible = true;
                //lbNextBudget.Visible = true;

                pnlBudgetConfirmationPage.Visible = false;
                lbRecommend.Visible = false;
                lbReturn.Visible = false;
            }
        }

        protected void lbReturn_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                //_DAL.UpdateWorkflowStatus(hfTransRefNumber.Value, VG.ws_returned_by_budget_custodian, VG.pending);
                //_DAL.AddActionLog(hfTransRefNumber.Value, Employee.user_id, VG.ar_budg_cust, txtRemarks.Text.Trim(), VG.ws_returned_by_budget_custodian);
                //_DAL.UpdateRemarks(hfTransRefNumber.Value, txtRemarks.Text);

                string transactionReferenceNumber = "";
                if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "TRN: " + transactionReferenceNumber, Request.UserHostAddress.ToString()))
                    transactionReferenceNumber = hfTransRefNumber.Value;
               
                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "alertRedirect('Homepage.aspx','Application has been returned!','" + transactionReferenceNumber + "','success');", true);
                //_DAL.SendEmailNoficationReturn("", "e-Procurement System - Returned Notification", " has been returned", hfTransRefNumber.Value, lblProcurementUnit.Text, txtRemarks.Text, VG.pending, VG.ws_returned_by_budget_custodian, VG.ar_req_officer);
            }
        }



        #endregion

        #endregion

        #region Events
        protected void rblFFFE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFFFE.Items[1].Selected)
                divAccordionReportDated.Visible = true;
            else
                divAccordionReportDated.Visible = false;

            if (rblFFFE.Items[3].Selected)
                divAccordionAdditionalItems.Visible = true;
            else
                divAccordionAdditionalItems.Visible = false;

            if (rblFFFE.Items[4].Selected)
                divAccordionOthers.Visible = true;
            else
                divAccordionOthers.Visible = false;
        }

        protected void rblProcureItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblProcureItems.Items[1].Selected)
                divAccordionReportDated2.Visible = true;
            else
                divAccordionReportDated2.Visible = false;

            if (rblProcureItems.Items[3].Selected)
                divAccordionAdditionalItems2.Visible = true;
            else
                divAccordionAdditionalItems2.Visible = false;

            if (rblProcureItems.Items[4].Selected)
                divAccordionOthers2.Visible = true;
            else
                divAccordionOthers2.Visible = false;
        }

        protected void txtUnitCost_TextChanged(object sender, EventArgs e)
        {
            if (rfvUnitCost.IsValid && txtUnitCost.Text.Length > 0)
            {
                txtUnitCost.Text = Convert.ToDecimal(txtUnitCost.Text).ToString("#,##0.00");
            }

            decimal quantity = 0;
            decimal unitCost = 0;
            decimal total = 0;


            if (decimal.TryParse((String.IsNullOrEmpty(txtQuantity.Text) ? "0" : txtQuantity.Text), out quantity) &&
                decimal.TryParse((String.IsNullOrEmpty(txtUnitCost.Text) ? "0" : txtUnitCost.Text), out unitCost))
            {
                txtTotal.Text = (quantity * unitCost).ToString("#,##0.00");
                total = Convert.ToDecimal(txtTotal.Text);
            }

        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            decimal quantity = 0;
            decimal unitCost = 0;
            decimal total = 0;


            if (decimal.TryParse((String.IsNullOrEmpty(txtQuantity.Text) ? "0" : txtQuantity.Text), out quantity) &&
                decimal.TryParse((String.IsNullOrEmpty(txtUnitCost.Text) ? "0" : txtUnitCost.Text), out unitCost))
            {
                txtTotal.Text = (quantity * unitCost).ToString("#,##0.00");
                total = Convert.ToDecimal(txtTotal.Text);
            }
        }

        protected void txtBalanceOnHand_TextChanged(object sender, EventArgs e)
        {
            if (rfvBalanceOnHand.IsValid && txtBalanceOnHand.Text.Length > 0)
            {
                txtBalanceOnHand.Text = Convert.ToDecimal(txtBalanceOnHand.Text).ToString("#,##0.00");
            }
        }

        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (rfvAmount.IsValid && txtAmount.Text.Length > 0)
            {
                txtAmount.Text = Convert.ToDecimal(txtAmount.Text).ToString("#,##0.00");
            }
        }

        #endregion

        #region Methods

        protected void ClearValues()
        {
            txtProcurementUnit.Text = "";
            txtControlNo.Text = "";

            rblFFFE.SelectedIndex = 0;
            txtReportDate.Text = "";
            txtNumberOfExistingUnits.Text = "";
            txtAllowedNumberOfUnitsPerFFFE.Text = "";
            txtOthers.Text = "";
            rblNatureOfProcurement.SelectedIndex = 0;

            txtModeOfProcurement.Text = "";
            txtPurpose.Text = "";
            txtItemDescription.Text = "";
            txtQuantity.Text = "";
            txtUnitCost.Text = "";
            txtTotal.Text = "";

            txtBalanceOnHand.Text = "";
            txtMoAveUsage.Text = "";
            txtEstimateMonthsToUse.Text = "";
            txtThisRequisition.Text = "";


        }
        protected void LoadDetailsFromSession(string transactionReferenceNumber)
        {
            DataTable dt = new DataTable();
            //dt = _DAL.GetRequestDetails(transactionReferenceNumber);

            lblProcurementUnit.Text = Convert.ToString(dt.Rows[0]["procurement_unit"]);
            lblControlNo.Text = Convert.ToString(dt.Rows[0]["control_no"]);

            rblProcureItems.SelectedValue = Convert.ToString(dt.Rows[0]["procure_items"]);
            rblProcurementNature.SelectedValue = Convert.ToString(dt.Rows[0]["nature_of_procurement"]);

            lblModeOfProcurement.Text = Convert.ToString(dt.Rows[0]["mode_of_procurement"]);
            lblEstimatedMonthsToUse.Text = Convert.ToString(dt.Rows[0]["estimated_months_to_use"]);
            lblMonthlyAverageUsage.Text = Convert.ToString(dt.Rows[0]["monthly_average_usage"]);
            lblThisRequisition.Text = Convert.ToString(dt.Rows[0]["this_requisition"]);

            lblItemDescription.Text = Convert.ToString(dt.Rows[0]["item_description"]);
            lblQuantity.Text = Convert.ToString(dt.Rows[0]["quantity"]);
            lblUnitCost.Text = Convert.ToString(dt.Rows[0]["unit_cost"]);
            lblTotal.Text = Convert.ToString(dt.Rows[0]["total"]);
            lblBalanceOnHand.Text = Convert.ToString(dt.Rows[0]["balance_on_hand"]);
        }

        protected void BackBudget()
        {
            txtBudgetYear.Text = Convert.ToString(ViewState["budgetYear"]);
            txtAccount.Text = Convert.ToString(ViewState["account"]);
            txtAmount.Text = Convert.ToString(ViewState["amount"]);
            txtDepartment.Text = Convert.ToString(ViewState["unitDepartment"]);

            //lbNextBudget.Visible = true;
            pnlBudget.Visible = true;
            pnlBudgetConfirmationPage.Visible = false;
            lbRecommend.Visible = false;
            lbBackBudget.Visible = false;
            lbReturn.Visible = false;

        }
        protected void Back()
        {
            #region Details

            txtProcurementUnit.Text = Convert.ToString(ViewState["ProcurementUnit"]);
            txtControlNo.Text = Convert.ToString(ViewState["ControlNo"]);
            txtModeOfProcurement.Text = Convert.ToString(ViewState["ModeOfProcurement"]);
            txtPurpose.Text = Convert.ToString(ViewState["Purpose"]);
            txtItemDescription.Text = Convert.ToString(ViewState["ItemDescription"]);
            txtQuantity.Text = Convert.ToString(ViewState["Quantity"]);
            txtUnitCost.Text = Convert.ToString(ViewState["UnitCost"]);
            txtTotal.Text = Convert.ToString(ViewState["Total"]);
            txtBalanceOnHand.Text = Convert.ToString(ViewState["BalanceOnHand"]);
            txtMoAveUsage.Text = Convert.ToString(ViewState["MonthlyAverageUsage"]);
            txtThisRequisition.Text = Convert.ToString(ViewState["ThisRequisition"]);
            txtEstimateMonthsToUse.Text = Convert.ToString(ViewState["EstimatedMonthsToUse"]);

            rblFFFE.SelectedValue = Convert.ToString(ViewState["ProcureItems"]);
            rblNatureOfProcurement.SelectedValue = Convert.ToString(ViewState["NatureOfProcurement"]);


            lbNext.Visible = true;
            lbSubmit.Visible = false;
            pnlFirstPage.Visible = true;
            pnlConfirmationPage.Visible = false;
            divRemarks.Visible = false;

            #endregion


        }

        protected void Next()
        {
            pnlFirstPage.Visible = false;
            pnlConfirmationPage.Visible = true;
            lbNext.Visible = false;
            lbSubmit.Visible = true;
            lbBack.Visible = true;
            divRemarks.Visible = true;

            #region Details
            ViewState["ProcurementUnit"] = txtProcurementUnit.Text;
            ViewState["ControlNo"] = txtControlNo.Text;
            ViewState["ModeOfProcurement"] = txtModeOfProcurement.Text;
            ViewState["Purpose"] = txtPurpose.Text;
            ViewState["ItemDescription"] = txtItemDescription.Text;
            ViewState["Quantity"] = txtQuantity.Text;
            ViewState["UnitCost"] = txtUnitCost.Text;
            ViewState["Total"] = txtTotal.Text;
            ViewState["BalanceOnHand"] = txtBalanceOnHand.Text;
            ViewState["MonthlyAverageUsage"] = txtMoAveUsage.Text;
            ViewState["ThisRequisition"] = txtThisRequisition.Text;
            ViewState["EstimatedMonthsToUse"] = txtEstimateMonthsToUse.Text;

            ViewState["ProcureItems"] = rblFFFE.SelectedValue;
            ViewState["NatureOfProcurement"] = rblNatureOfProcurement.SelectedValue;

            ViewState["ReportDate"] = txtReportDate.Text;
            ViewState["Others"] = txtOthers.Text;
            ViewState["NumberOfExistingUnits"] = txtNumberOfExistingUnits.Text;
            ViewState["AllowedUnitsPerFFFE"] = txtAllowedNumberOfUnitsPerFFFE.Text;

            #region Labels
            lblProcurementUnit.Text = Convert.ToString(ViewState["ProcurementUnit"]);
            lblControlNo.Text = Convert.ToString(ViewState["ControlNo"]);
            lblModeOfProcurement.Text = Convert.ToString(ViewState["ModeOfProcurement"]);
            lblPurpose.Text = Convert.ToString(Convert.ToString(ViewState["Purpose"]));
            lblItemDescription.Text = Convert.ToString(ViewState["ItemDescription"]);
            lblQuantity.Text = Convert.ToString(ViewState["Quantity"]);
            lblUnitCost.Text = Convert.ToString(ViewState["UnitCost"]);
            lblTotal.Text = Convert.ToString(ViewState["Total"]);
            lblBalanceOnHand.Text = Convert.ToString(ViewState["BalanceOnHand"]);
            lblMonthlyAverageUsage.Text = Convert.ToString(ViewState["MonthlyAverageUsage"]);
            lblThisRequisition.Text = Convert.ToString(ViewState["ThisRequisition"]);
            lblEstimatedMonthsToUse.Text = Convert.ToString(ViewState["EstimatedMonthsToUse"]);

            rblProcureItems.SelectedValue = Convert.ToString(ViewState["ProcureItems"]);
            rblProcurementNature.SelectedValue = Convert.ToString(ViewState["NatureOfProcurement"]);
            rblProcureItems_SelectedIndexChanged(null, null);

            lblReportDate.Text = Convert.ToString(ViewState["ReportDate"]);
            lblOthers.Text = Convert.ToString(ViewState["Others"]);
            lblNumberOfExistingUnits.Text = Convert.ToString(ViewState["NumberOfExistingUnits"]);
            lblAllowedUnitsPerFFFE.Text = Convert.ToString(ViewState["AllowedUnitsPerFFFE"]);

            #endregion


            #endregion
        }

        protected void NextBudget()
        {

            pnlBudgetConfirmationPage.Visible = true;
            lbRecommend.Visible = true;
            lbReturn.Visible = true;
            lbBackBudget.Visible = true;
            //lbNextBudget.Visible = false;
            pnlBudget.Visible = false;


            #region Details
            ViewState["budgetYear"] = txtBudgetYear.Text;
            ViewState["account"] = txtAccount.Text;
            ViewState["amount"] = txtAmount.Text;
            ViewState["unitDepartment"] = txtDepartment.Text;

            lblBudgetYear.Text = Convert.ToString(ViewState["budgetYear"]);
            lblAccount.Text = Convert.ToString(ViewState["account"]);
            lblAmount.Text = Convert.ToString(ViewState["amount"]);
            lblChargeableUnit.Text = Convert.ToString(ViewState["unitDepartment"]);

            #endregion
        }
        #endregion
    }
}