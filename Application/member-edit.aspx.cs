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
    public partial class member_edit : System.Web.UI.Page
    {
        private BLL _BLL = new BLL();
        private DAL _DAL = new DAL();
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
                            {}
                            else
                            {
                                _BLL.GetMinistryDropdown(ddMinistry, "--Select--");
                                _BLL.GetMinistryDepartmentDropdown(ddMinistryDepartment, "--Select--", ddMinistry.SelectedValue);
                                _BLL.GetPepsolDropdown(ddPepsol, "--Select--");
                                LoadEditDetails(Maintenance.entry_code);
                            }
                        }
                    }
                }

            }
        }

        protected void LoadEditDetails(string memberId)
        {
            if (_BLL.GetMemberDeatils(Maintenance.entry_code) == false)
            {}
            else
            {
                txtFirstName.Text = Member.first_name;
                txtMiddleName.Text = Member.middle_name;
                txtLastName.Text = Member.last_name;
                ddGender.SelectedValue = Member.gender_code;
                txtBirthday.Text = Member.birthday;
                txtEmail.Text = Member.email;
                txtMobileNumber.Text = Member.mobile_number;
                ddMinistry.SelectedValue = Member.ministry_code;
                ddMinistryDepartment.SelectedValue = Member.ministry_dept_code;
                ddStatus.SelectedValue = Member.membership_status_code;
                ddCellGroup.SelectedValue = Member.cell_status_code;
                ddBaptismalStatus.SelectedValue = Member.baptismal_status_code;
                ddPepsol.SelectedValue = Member.pepsol_level_code;
            }
            
        }
        protected void ddMinistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            _BLL.GetMinistryDepartmentDropdown(ddMinistryDepartment, "--Select--", ddMinistry.SelectedValue);
        }

        #region Link Buttons
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Response.Redirect("member-search.aspx", false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Boolean result = false;
                result = _BLL.EditMember(Maintenance.entry_code,txtFirstName.Text.Trim(), txtMiddleName.Text.Trim(), txtLastName.Text.Trim(), ddGender.SelectedValue, txtBirthday.Text, txtEmail.Text.Trim()
                    , txtMobileNumber.Text.Trim(), ddMinistry.SelectedValue, ddMinistryDepartment.SelectedValue, txtDateFirstAttend.Text,
                    ddCellGroup.Text, ddBaptismalStatus.SelectedValue, ddPepsol.SelectedValue, ddStatus.SelectedValue);

                if (result == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to update the entry.', 'error');", true);
                }
                else
                {
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, Maintenance.mode, "Code: " + Maintenance.entry_code, Request.UserHostAddress.ToString()) == false)
                    {}
                    else
                    {
                        
                        string transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmm") + "-" + DateTime.Now.ToString("ssff");
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been updated.','" + transactionReferenceNumber + "');", true);
                    }
                    
                }
            }
        }
        #endregion

        
    }
}