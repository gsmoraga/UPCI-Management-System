using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class view_purchase_requisition_form : System.Web.UI.Page
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
                        if (_BLL.GetContentType(Maintenance.content_code) == false)
                        { }
                        else
                        {


                            hfTransRefNumber.Value = Convert.ToString(Session["transactionReferenceNumber"]);
                            LoadDetailsFromSession(hfTransRefNumber.Value);

                            GetUserDropdown(hfTransRefNumber.Value);

                            lblBreadcrumbHead.Text = "Purchase Requisition";
                            lblBreadcrumbMain.Text = "View";

                            if (Maintenance.mode == "Inquiry")
                            {
                                lbBack.Visible = true;
                            }

                            string accessRights = Employee.access_rights;

                            #region Division Head
                            if (accessRights.Contains(VG.ar_div_head))
                            {
                                if (Maintenance.mode == "For Action")
                                {
                                    if (EPS.workflow_status == VG.ws_recommend_by_budget_custodian)
                                    {
                                        divBudgetFunds.Visible = true;
                                        if (accessRights.Contains(VG.ar_div_head_approve))
                                        {
                                            lbApprove.Visible = true;
                                        }
                                        if (accessRights.Contains(VG.ar_div_head_return))
                                        {
                                            lbReturn.Visible = true;
                                        }
                                        if (accessRights.Contains(VG.ar_div_head_decline))
                                        {
                                            lbDecline.Visible = true;
                                        }

                                        divRemarks.Visible = true;
                                        GetUserDropdown(hfTransRefNumber.Value);


                                    }
                                }

                            }
                            #endregion

                            if (EPS.workflow_status == VG.ws_approved_by_division_head)
                            {
                                lbPRFForm.Visible = true;

                            }
                        }
                    }

                }
            }
        }




        #region LinkButton Events
        protected void lbBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("inquiry-all.aspx", false);
        }

        protected void lbApprove_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                string accessRights = Employee.access_rights;
                string message = "approved";

                //_DAL.UpdateWorkflowStatus(hfTransRefNumber.Value, VG.ws_approved_by_division_head, VG.pending);
                //_DAL.UpdateApproverSignature(hfTransRefNumber.Value, Employee.user_id);
                //_DAL.UpdateRemarks(hfTransRefNumber.Value, txtRemarks.Text.Trim());

                string transactionReferenceNumber = "";
                if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "TRN: " + transactionReferenceNumber, Request.UserHostAddress.ToString()))
                    transactionReferenceNumber = hfTransRefNumber.Value;

                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "alertRedirect('Homepage.aspx','Purchase Request application " + message + "!','" + transactionReferenceNumber + "','success');", true);

                //_DAL.SendEmailNoficationSubmitted("", "e-Procurement Approve Notification", " has been approved", transactionReferenceNumber, lblProcurementUnit.Text.Trim(), txtRemarks.Text.Trim(), VG.pending, VG.ws_approved_by_division_head, VG.ar_proc_dept_recommend);
            }
        }

        protected void lbPRFForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("procurement-request-form.aspx", false);
        }

        protected void lbDeclineModal_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                //_DAL.UpdateWorkflowStatus(hfTransRefNumber.Value, VG.ws_declined_by_division_head, VG.declined);

                string transactionReferenceNumber = "";
                if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "TRN: " + transactionReferenceNumber, Request.UserHostAddress.ToString()))
                    transactionReferenceNumber = hfTransRefNumber.Value;

                //_BLL.SendEmailNotificationWorkflowActor(hfLoanApplicationCode.Value, "", "", "LOS Decline Notification", "has been declined", Loan.loan_type.Text,
                //                                        Loan.transaction_reference_number, GetClientName(), Loan.amount_finance + " Php", txtRemarks.Text, "3", workflowStatus);

                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "alertRedirect('Homepage.aspx','Purchase Request application declined!','" + transactionReferenceNumber + "','error');", true);
            }
        }

        protected void lbReturn_Click(object sender, EventArgs e)
        {
            
        }

        protected void lbDecline_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                //_DAL.UpdateWorkflowStatus(hfTransRefNumber.Value, VG.ws_declined_by_division_head, VG.declined);
                //_DAL.AddActionLog(hfTransRefNumber.Value, Employee.user_id, VG.ar_div_head, txtRemarks.Text, VG.ws_declined_by_division_head);

                string transactionReferenceNumber = "";
                if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "TRN: " + transactionReferenceNumber, Request.UserHostAddress.ToString()))
                    transactionReferenceNumber = hfTransRefNumber.Value;

                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "alertRedirect('Homepage.aspx','Purchase Request application returned!','" + transactionReferenceNumber + "','success');", true);

                //_DAL.SendEmailNotificationDeclined("", "e-Procurement Decline Notification", " has been declined", hfTransRefNumber.Value, lblProcurementUnit.Text, txtRemarks.Text, VG.declined, VG.ws_declined_by_division_head);
            }


        }

        protected void lbReturnModal_Click(object sender, EventArgs e)
        {
            

            if (_BLL.SessionIsActive(this))
            {
                string workflowStatus = "";
                string accessRight = "";

                //_DAL.UpdateWorkflowStatus(hfTransRefNumber.Value, VG.ws_returned_by_division_head, VG.pending);
                //_DAL.AddActionLog(hfTransRefNumber.Value, Employee.user_id, VG.ar_div_head, txtRemarks.Text, VG.ws_returned_by_division_head);

                string transactionReferenceNumber = "";
                if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "View", "TRN: " + transactionReferenceNumber, Request.UserHostAddress.ToString()))
                    transactionReferenceNumber = hfTransRefNumber.Value;

                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "alertRedirect('Homepage.aspx','Purchase Request application returned!','" + transactionReferenceNumber + "','success');", true);


                //_DAL.SendEmailNoficationReturnSelectedUser(ddReturnUser.SelectedValue, "e-Procurement System - Returned Notification", " has been returned", hfTransRefNumber.Value, lblProcurementUnit.Text, txtRemarks.Text, VG.pending, workflowStatus);
            }


            
        }

        protected void GetUserDropdown(string transaactionRedNumber)
        {
            DataTable dt = new DataTable();
            //dt = _DAL.GetUserDropdown(transaactionRedNumber);

            ddReturnUser.DataSource = dt;
            ddReturnUser.DataValueField = "user_id";
            ddReturnUser.DataTextField = "Name";
            ddReturnUser.DataBind();
            ddReturnUser.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        #endregion

        #region Events
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
        #endregion

        #region Method
        protected void LoadDetailsFromSession(string transactionReferenceNumber)
        {
            DataTable dt = new DataTable();
            //dt = _DAL.GetRequestDetails(transactionReferenceNumber);

            EPS.workflow_status = Convert.ToString(dt.Rows[0]["workflow_status"]);


            lblProcurementUnit.Text = Convert.ToString(dt.Rows[0]["procurement_unit"]);
            lblControlNo.Text = Convert.ToString(dt.Rows[0]["control_no"]);

            rblProcureItems.SelectedValue = Convert.ToString(dt.Rows[0]["procure_items"]);
            rblProcurementNature.SelectedValue = Convert.ToString(dt.Rows[0]["nature_of_procurement"]);

            lblModeOfProcurement.Text = Convert.ToString(dt.Rows[0]["mode_of_procurement"]);
            lblItemDescription.Text = Convert.ToString(dt.Rows[0]["item_description"]);
            lblEstimatedMonthsToUse.Text = Convert.ToString(dt.Rows[0]["estimated_months_to_use"]);
            lblMonthlyAverageUsage.Text = Convert.ToString(dt.Rows[0]["monthly_average_usage"]);
            lblThisRequisition.Text = Convert.ToString(dt.Rows[0]["this_requisition"]);

            lblBudgetYear.Text = Convert.ToString(dt.Rows[0]["budget_year"]);
            lblAccount.Text = Convert.ToString(dt.Rows[0]["account"]);
            lblAmount.Text = Convert.ToString(dt.Rows[0]["amount"]);
            lblChargeableUnit.Text = Convert.ToString(dt.Rows[0]["unit_department"]);

            lblQuantity.Text = Convert.ToString(dt.Rows[0]["quantity"]);
            lblUnitCost.Text = Convert.ToString(dt.Rows[0]["unit_cost"]);
            lblTotal.Text = Convert.ToString(dt.Rows[0]["total"]);
            lblBalanceOnHand.Text = Convert.ToString(dt.Rows[0]["balance_on_hand"]);

            rblProcureItems_SelectedIndexChanged(null, null);

            lblReportDate.Text = Convert.ToString(dt.Rows[0]["replacement_date"]);
            lblOthers.Text = Convert.ToString(dt.Rows[0]["others"]);
            lblNumberOfExistingUnits.Text = Convert.ToString(dt.Rows[0]["number_of_existing_units"]);
            lblAllowedUnitsPerFFFE.Text = Convert.ToString(dt.Rows[0]["allowed_units_per_FFFE"]);

            lblPurpose.Text = Convert.ToString(dt.Rows[0]["purpose"]);


        }

        #endregion



    }
}