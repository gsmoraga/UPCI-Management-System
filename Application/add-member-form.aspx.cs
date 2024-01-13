using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class add_member_form : System.Web.UI.Page
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
                        string accessRights = Employee.access_rights;
                        pnlFirstPage.Visible = true;
                        lbNextFirstPage.Visible = true;
                        //lbSave.Visible = true;
                        LoadDropdowns();
                    }
                }
            }


        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                //DataTable dt = new DataTable();
                //dt = _DAL.CheckExist(txtMembershipId.Text);


                //if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                //{
                //    string transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + DateTime.Now.ToString("HHmmssffff");
                //    _DAL.AddMember(transactionReferenceNumber, txtFirstName.Text.Trim(), txtMiddleName.Text.Trim(), txtLastName.Text.Trim(), ddGender.SelectedValue, ddMinistry.SelectedValue, txtBirthDate.Text, txtDateFirstAttend.Text, txtEmail.Text.Trim(), txtMobileNumber.Text.Trim(), txtMembershipId.Text);
                //    _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Add", "TRN: " + transactionReferenceNumber, Request.UserHostAddress.ToString());

                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Member Info has been saved!','" + "" + "');", true);
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Code is already in use.', '', 'error');", true);
                //}


                clearValues();
            }
        }

        #region Methods


        protected void LoadDropdowns()
        {
            DataTable dtMinistry = new DataTable();
            dtMinistry = _DAL.GetMinistry();
            ddMinistry.DataSource = dtMinistry;
            ddMinistry.DataTextField = "Description";
            ddMinistry.DataValueField = "Code";
            ddMinistry.DataBind();
            //ddMinistry.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            ddMinistry.Items.Insert(0, new ListItem("--Select--", "0"));



        }
        void clearValues()
        {
            txtMembershipId.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            ddGender.SelectedIndex = 0;
            ddMinistry.SelectedIndex = 0;
            txtBirthDate.Text = "";
            txtDateFirstAttend.Text = "";
            txtEmail.Text = "";
            txtMobileNumber.Text = "";

            pnlConfirmationPage.Visible = false;
            pnlFirstPage.Visible = true;

            stepTwo.Attributes.Remove("class");
            stepTwo.Attributes.Add("class", "circle");

            stepThree.Attributes.Remove("class");
            stepThree.Attributes.Add("class", "circle");

            stepFour.Attributes.Remove("class");
            stepFour.Attributes.Add("class", "circle");

            stepConfirmation.Attributes.Remove("class");
            stepConfirmation.Attributes.Add("class", "circle");

            spanIndicator.Style.Add("width", "0%");

            #region Icon/label Hide Show
            lblOne.Visible = true;
            lblTwo.Visible = true;
            lblThree.Visible = true;
            lblFour.Visible = true;

            iconOne.Visible = false;
            iconTwo.Visible = false;
            iconThree.Visible = false;
            iconFour.Visible = false;
            #endregion
        }
        #endregion

        protected void lbNextFirstPage_Click(object sender, EventArgs e)
        {
            stepTwo.Attributes.Remove("class");
            stepTwo.Attributes.Add("class", "circle active");
            spanIndicator.Style.Add("width", "25%");
            pnlFirstPage.Visible = false;
            pnlSecondPage.Visible = true;
            lblOne.Visible = false;
            iconOne.Visible = true;
        }

        //Second Page Buttons
        protected void lbNextSecondPage_Click(object sender, EventArgs e)
        {
            stepThree.Attributes.Remove("class");
            stepThree.Attributes.Add("class", "circle active");
            spanIndicator.Style.Add("width", "45%");
            pnlSecondPage.Visible = false;
            pnlThirdPage.Visible = true;
            lblTwo.Visible = false;
            iconTwo.Visible = true;
        }

        protected void lbBackSecondPage_Click(object sender, EventArgs e)
        {
            stepTwo.Attributes.Remove("class");
            stepTwo.Attributes.Add("class", "circle");
            spanIndicator.Style.Add("width", "0%");
            pnlSecondPage.Visible = false;
            pnlFirstPage.Visible = true;
            lblOne.Visible = true;
            iconOne.Visible = false;
        }

        
        //Third Page Buttons
        protected void lbNextThirdPage_Click(object sender, EventArgs e)
        {
            stepFour.Attributes.Remove("class");
            stepFour.Attributes.Add("class", "circle active");
            spanIndicator.Style.Add("width", "65%");
            pnlThirdPage.Visible = false;
            pnlFourthPage.Visible = true;
            lblThree.Visible = false;
            iconThree.Visible = true;
        }
        protected void lbBackThirdPage_Click(object sender, EventArgs e)
        {
            stepThree.Attributes.Remove("class");
            stepThree.Attributes.Add("class", "circle");
            spanIndicator.Style.Add("width", "45%");
            pnlThirdPage.Visible = false;
            pnlSecondPage.Visible = true;
            lblTwo.Visible = true;
            iconTwo.Visible = false;
        }


        //Fourth Page Buttons
        protected void lbNextFourthPage_Click(object sender, EventArgs e)
        {
            stepConfirmation.Attributes.Remove("class");
            stepConfirmation.Attributes.Add("class", "circle active");
            spanIndicator.Style.Add("width", "100%");
            pnlFourthPage.Visible = false;
            pnlConfirmationPage.Visible = true;
            lblFour.Visible = false;
            iconFour.Visible = true;
            LoadDetails();
        }
        protected void lbBackFourthPage_Click(object sender, EventArgs e)
        {
            stepFour.Attributes.Remove("class");
            stepFour.Attributes.Add("class", "circle");
            spanIndicator.Style.Add("width", "45%");
            pnlFourthPage.Visible = false;
            pnlThirdPage.Visible = true;
            lblThree.Visible = true;
            iconThree.Visible = false;
        }

        //Confirmation Buttons
        protected void lbBackConfirmationPage_Click(object sender, EventArgs e)
        {
            stepConfirmation.Attributes.Remove("class");
            stepConfirmation.Attributes.Add("class", "circle");
            spanIndicator.Style.Add("width", "65%");
            pnlConfirmationPage.Visible = false;
            pnlFourthPage.Visible = true;
            lblFour.Visible = true;
            iconFour.Visible = false;
        }

        void LoadDetails()
        {
            ViewState["MembershipId"] = lblMembershipId.Text = txtMembershipId.Text;
            ViewState["FirstName"] = lblFirstName.Text = txtFirstName.Text;
            ViewState["MiddleName"] = lblMiddleName.Text = txtMiddleName.Text;
            ViewState["LastName"] = lblLastName.Text = txtLastName.Text;
            ViewState["Gender"] = ddGender.SelectedValue; 
                lblGender.Text = ddGender.SelectedItem.Text;
            ViewState["Birthdate"] = lblBirthdate.Text = txtBirthDate.Text;
            ViewState["Email"] = lblEmail.Text = txtEmail.Text;
            ViewState["MobileNumber"] = lblMobileNumber.Text = txtMobileNumber.Text;
            ViewState["Ministry"] = ddMinistry.SelectedValue;
                lblMinistry.Text = ddMinistry.SelectedItem.Text;
            ViewState["DateFirstAttend"] = lblDateFirstAttend.Text = txtDateFirstAttend.Text;
            
        }
    }
}