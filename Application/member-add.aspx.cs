using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
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
                                #region Titles
                                contentHeader.Text = Maintenance.content_description;
                                mainBreadcrumb.Text = Maintenance.content_description;
                                subItemBreadcrumb.Text = Maintenance.mode;
                                //cardTitle.Text = Maintenance.mode + " " + Maintenance.content_description;
                                #endregion

                                #region Dropdowns
                                _BLL.GetMinistryDropdown(ddMinistry, "--Select--");
                                _BLL.GetMinistryDepartmentDropdown(ddMinistryDepartment, "--Select--", ddMinistry.SelectedValue);
                                _BLL.GetPepsolDropdown(ddPepsol, "--Select--");
                                #endregion

                                divCard.Visible = true;
                            }

                        }

                    }
                }
            }


        }

        #region Methods
        protected void clearValues()
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            ddGender.SelectedIndex = 0;
            txtBirthday.Text = "";
            txtEmail.Text = "";
            txtMobileNumber.Text = "";
            ddMinistry.SelectedIndex = 0;
            ddMinistryDepartment.SelectedIndex = 0;
            txtDateFirstAttend.Text = "";
            ddCellGroup.SelectedIndex = 0;
            ddBaptismalStatus.SelectedIndex = 0;
            ddPepsol.SelectedIndex = 0;
        }


        #endregion

        #region LinkButtons
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Response.Redirect("member-search.aspx", false);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                SetMemberStatus();
                if (_BLL.AddMember(txtFirstName.Text.Trim(), txtMiddleName.Text.Trim(), txtLastName.Text.Trim(), ddGender.SelectedValue, txtBirthday.Text,txtEmail.Text.Trim()
                    , txtMobileNumber.Text.Trim(), ddMinistry.SelectedValue, ddMinistryDepartment.SelectedValue,
                    ddCellGroup.Text, ddBaptismalStatus.SelectedValue, ddPepsol.SelectedValue,Convert.ToString(ViewState["MemberStatus"]), txtDateFirstAttend.Text, ddStatus.SelectedValue, Employee.user_id) == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!','Unable to add the user.','error');", true);
                }
                else
                {
                    string transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmm") + "-" + DateTime.Now.ToString("ssffff");
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Member Details has been added.','" + transactionReferenceNumber + "');", true);

                    _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Add", "TRN: " + transactionReferenceNumber, Request.UserHostAddress.ToString());

                    clearValues();
                }
            }
        }

        #endregion

        protected void ddMinistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                _BLL.GetMinistryDepartmentDropdown(ddMinistryDepartment, "--Select--", ddMinistry.SelectedValue);

                SetMemberStatus();


            }

        }

        protected void SetMemberStatus()
        {
            if (ddMinistry.SelectedValue == "0")
            {
                ViewState["MemberStatus"] = "1";
            }
            else
            {
                ViewState["MemberStatus"] = "2";
            }
        }
    }
}