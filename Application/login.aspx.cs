using System;
using System.Web.UI;

namespace Template
{
    public partial class login : System.Web.UI.Page
    {
        private BLL _BLL = new BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.Browser == "IE" || Request.Browser.Browser == "InternetExplorer")
            {
                Response.Write("<script language='javascript'>window.alert('This application is not compatible with Internet Explorer.');window.location='about:blank';</script>");
            }
            else
            {
                this.lblError.Text = "";

                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Employee.user_id as string))
                        Response.Redirect("home.aspx", false);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (_BLL.GetCurrentUserDetails(txtUserId.Text) == false)
                {
                    lblError.Text = "Invalid user ID and/or password.";
                    return;
                }
                else
                {
                    _BLL.GetApplicationParameters();
                    _BLL.GetSecurityParameters();

                    if (Employee.status == VG.s_disabled || Employee.remaining_password_attempts == 0)
                    {
                        _BLL.AddAccessLogEntry(VG.access_login, txtUserId.Text, VG.action_fail, Request.UserHostAddress.ToString());

                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Your account is disabled!', 'Please contact IT Security (Loc. " + VG.usb_itsec_local + " or " + VG.usb_itsec_email + ") to unlock your account.', 'error');", true);
                        return;
                    }
                    else if (Employee.status == VG.s_deleted || Employee.remaining_password_attempts == 0)
                    {
                        _BLL.AddAccessLogEntry(VG.access_login, txtUserId.Text, VG.action_fail, Request.UserHostAddress.ToString());

                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Your account has been deleted!', 'Please contact IT Security (Loc. " + VG.usb_itsec_local + " or " + VG.usb_itsec_email + ") for support.', 'error');", true);
                        return;
                    }
                    else if (Employee.status == VG.s_expired || Employee.remaining_password_attempts == 0)
                    {
                        _BLL.AddAccessLogEntry(VG.access_login, txtUserId.Text, VG.action_fail, Request.UserHostAddress.ToString());

                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Your account has expired!', 'Please contact IT Security (Loc. " + VG.usb_itsec_local + " or " + VG.usb_itsec_email + ") for support.', 'error');", true);
                        return;
                    }
                    else if (Employee.password != txtPassword.Text)
                    {
                        _BLL.AddAccessLogEntry(VG.access_login, txtUserId.Text, VG.action_fail, Request.UserHostAddress.ToString());

                        Employee.remaining_password_attempts -= 1;
                        _BLL.SetPasswordAttempts(Employee.user_id, Employee.remaining_password_attempts);

                        Employee.cumulative_invalid_password_attempts += 1;
                        _BLL.SetCumulativeInvalidPasswordAttempts(Employee.user_id, Employee.cumulative_invalid_password_attempts);

                        if (Employee.cumulative_invalid_password_attempts == Convert.ToInt32(Maintenance.max_cumulative_invalid_password_tries))
                        {
                            Employee.status = VG.s_disabled;
                            _BLL.SetUserStatus(Employee.user_id, VG.s_disabled);
                            _BLL.AddAuditLogEntry(Employee.user_id, VG.c_access, "View", "Account disabled due to accumulated invalid password attempts", Request.UserHostAddress.ToString());
                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Your account has been disabled!', 'Your cumulative invalid password attempts have reached the maximum allowed number. Please contact IT Personell (Loc. " + VG.usb_itsec_local + " or " + VG.usb_itsec_email + ") to unlock your account.', 'error');", true);
                        }
                        else if (Employee.remaining_password_attempts >= 1)
                        {
                            this.lblError.Text = "Invalid user ID and/or password.";
                        }
                        else if (Employee.remaining_password_attempts < 1)
                        {
                            Employee.status = VG.s_disabled;
                            _BLL.SetUserStatus(Employee.user_id, VG.s_disabled);
                            _BLL.AddAuditLogEntry(Employee.user_id, VG.c_access, "View", "Account disabled due to exhausted password attempts", Request.UserHostAddress.ToString());
                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Your account has been disabled!', 'Your invalid password attempts have reached the maximum allowed number. Please contact IT Personell (Loc. " + VG.usb_itsec_local + " or " + VG.usb_itsec_email + ") to unlock your account.', 'error');", true);
                        }

                        return;
                    }
                    else
                    {
                        Page.Validate();

                        if (Page.IsValid)
                        {
                            _BLL.SetPasswordAttempts(Employee.user_id, Convert.ToInt32(Maintenance.max_invalid_password_tries));

                            if (Employee.profile_expiration_date < DateTime.Now && Employee.profile_expiration_date.ToString("yyyy-MM-dd") != "1900-01-01")
                            {
                                Employee.status = VG.s_expired;
                                _BLL.SetUserStatus(Employee.user_id, VG.s_expired);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Your account has expired!', 'Please contact IT Security (Loc. " + VG.usb_itsec_local + " or " + VG.usb_itsec_email + ") for support.', 'error');", true);
                            }
                            else if (Employee.password_expiration_date < DateTime.Now)
                            {
                                if (Employee.using_default_password == "1")
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Your temporary password has expired!', 'Please contact IT Security (Loc. " + VG.usb_itsec_local + " or " + VG.usb_itsec_email + ") to request for another password.', 'error');", true);
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "warningRedirect('password-force-change.aspx','Your password has expired!', 'Click OK to change your password.');", true);
                                }
                            }
                            else if (Employee.using_default_password == "1")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "warningRedirect('password-force-change.aspx','You are using a default password!', 'Click OK to change your password.');", true);
                            }
                            else if (_BLL.CheckActiveSession(Employee.user_id))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "OpenActiveSessionModal();", true);
                            }
                            else
                            {
                                if ((Employee.profile_expiration_date - DateTime.Now).TotalDays <= Convert.ToDouble(Maintenance.profile_expiration_warning_days) && Employee.profile_expiration_date.ToString("yyyy-MM-dd") != "1900-01-01")
                                {
                                    Employee.warn_profile_expiration = true;
                                }

                                if ((Employee.password_expiration_date - DateTime.Now).TotalDays <= Convert.ToDouble(Maintenance.password_expiration_warning_days))
                                {
                                    Employee.warn_password_expiration = true;
                                }

                                Maintenance.first_login = true;

                                _BLL.SetLastLoginDate(Employee.user_id);

                                Session["SessionID"] = Employee.user_id + DateTime.Now.ToString("MMddyyHHmmssfff");

                                if (_BLL.AddActiveSession(Convert.ToString(Session["SessionID"]), Employee.user_id))
                                    _BLL.RemoveFromCache("FilterActiveSession");

                                _BLL.GetLatestLoginDate(txtUserId.Text);
                                _BLL.AddAccessLogEntry(VG.access_login, txtUserId.Text, VG.action_success, Request.UserHostAddress.ToString());

                                Response.Redirect("home.aspx", false);
                            }
                        }
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    _BLL.AddExceptionLogEntry(ex);
            //    Session.Clear();
            //}
        }

        protected void lbActiveSessionModal_Click(object sender, EventArgs e)
        {
            if (_BLL.DeleteActiveSessionByUserId(txtUserId.Text) == false)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to log out the session.', 'error');", true);
            }
            else
            {
                _BLL.RemoveFromCache("FilterActiveSession");
                _BLL.RemoveFromCache("GetActiveSession" + txtUserId.Text);
                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Session logged out!', 'Please try logging in again.', 'success');", true);
            }
        }
    }
}