using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class parameters_security : System.Web.UI.Page
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
                            {
                            }
                            else
                            {
                                txtMinPasswordLength.Text = Maintenance.min_password_length;
                                txtPasswordExpiration.Text = Maintenance.password_expiration_days;
                                txtAllowedRepeatingCharacters.Text = Maintenance.max_length_repeating_characters;
                                txtAllowedSequentialCharacters.Text = Maintenance.max_length_sequential_characters;
                                txtCumulativeInvalidPassword.Text = Maintenance.max_cumulative_invalid_password_tries;
                                txtInvalidPasswordTries.Text = Maintenance.max_invalid_password_tries;
                                Session["InvalidPasswordTries"] = Maintenance.max_invalid_password_tries;
                                txtRecentPasswordsNotAllowed.Text = Maintenance.max_restricted_recent_passwords;
                                txtSpecialCharactersAllowedSP.Text = Maintenance.allowed_special_characters_password;
                                ddPasswordType.SelectedValue = Maintenance.password_type;
                                txtMobileActivation.Text = Maintenance.mobile_activation_minutes;
                            }
                        }
                    }
                }
            }
        }
        protected void lbSaveSecurityParameters_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (_BLL.EditSecurityParameters(txtMinPasswordLength.Text, txtPasswordExpiration.Text, txtAllowedRepeatingCharacters.Text,
                    txtAllowedSequentialCharacters.Text, txtCumulativeInvalidPassword.Text, txtInvalidPasswordTries.Text, txtRecentPasswordsNotAllowed.Text,
                    txtSpecialCharactersAllowedSP.Text, ddPasswordType.SelectedValue, txtMobileActivation.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to update the Security Parameters.', 'error');", true);
                }
                else
                {
                    if (Convert.ToString(Session["InvalidPasswordTries"]) != txtInvalidPasswordTries.Text)
                    {
                        if (_BLL.SetDefaultPasswordAttempts() == false)
                        {
                        }
                    }

                    HttpContext.Current.Cache.Remove(("GetSecurityParameters").ToLower());

                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Edit", "", Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmm") + "-" + DateTime.Now.ToString("ssff");

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Security Parameters have been updated.','" + transactionReferenceNumber + "');", true);
                }
            }
        }
    }
}