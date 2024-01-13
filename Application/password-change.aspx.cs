using System;
using System.Web.UI;

namespace Template
{
    public partial class password_change : System.Web.UI.Page
    {
        private BLL _BLL = new BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.Browser == "IE" || Request.Browser.Browser == "InternetExplorer")
            {
                Response.Write("<script language='javascript'>window.alert('This application is not compatible with Internet Explorer.');window.location='about:blank';</script>");
                return;
            }
            else
            {
                if (_BLL.SessionIsActive(this))
                {
                    Maintenance.content_description = "Change Password";
                    #region Load password validation

                    _BLL.GetSecurityParameters();

                    string passwordType = "";
                    string passwordTypeRegex = "";
                    string passwordTypeRegexReq = "";
                    string passwordTypeRegexReqText = "";

                    if (Maintenance.password_type == "1")
                    {
                        passwordType = " alphabetic characters";
                        passwordTypeRegex = "a-zA-Z";
                        passwordTypeRegexReq = "(?=.*?[a-z])(?=.*?[A-Z])";
                        passwordTypeRegexReqText = " containing at least one uppercase letter and one lowercase letter.";
                    }
                    else if (Maintenance.password_type == "2")
                    {
                        passwordType = " numeric characters";
                        passwordTypeRegex = "0-9";
                        passwordTypeRegexReq = "";
                        passwordTypeRegexReqText = "";
                    }
                    else if (Maintenance.password_type == "3")
                    {
                        passwordType = " alphanumeric characters";
                        passwordTypeRegex = "a-zA-Z0-9";
                        passwordTypeRegexReq = "(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])";
                        passwordTypeRegexReqText = " containing at least one uppercase letter, one lowercase letter, and one digit.";
                    }
                    else if (Maintenance.password_type == "4")
                    {
                        passwordType = " alphanumeric and allowed special characters <kbd>" + Maintenance.allowed_special_characters_password + "</kbd>";
                        passwordTypeRegex = "a-zA-Z0-9" + Maintenance.allowed_special_characters_password;
                        passwordTypeRegexReq = "(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[" + Maintenance.allowed_special_characters_password + "])";
                        passwordTypeRegexReqText = " containing at least one uppercase letter, one lowercase letter, one special character, and one digit.";
                    }

                    NewPasswordValidator.ValidationExpression = "^(?=[" + passwordTypeRegex + "]{" + Maintenance.min_password_length + ",}$)" + passwordTypeRegexReq + ".*$";
                    lblNewPasswordErrorMessage.Text = "Password must have at least " + Maintenance.min_password_length + passwordType + passwordTypeRegexReqText;

                    if (Convert.ToInt32(Maintenance.max_length_repeating_characters) > 0)
                    {
                        NewPasswordRepeatingValidator.Enabled = true;

                        NewPasswordRepeatingValidator.ValidationExpression = "^(?!.*([" + passwordTypeRegex + "])\\1{" + Maintenance.max_length_repeating_characters + ",}).*$";

                        if (Convert.ToInt32(Maintenance.max_length_repeating_characters) == 1)
                            lblNewPasswordRepeatingErrorMessage.Text = "No consecutive repeating characters allowed.";
                        else
                            lblNewPasswordRepeatingErrorMessage.Text = "Only up to " + Maintenance.max_length_repeating_characters + " consecutive repeating characters allowed.";
                    }

                    if (Convert.ToInt32(Maintenance.max_length_sequential_characters) > 0)
                    {
                        NewPasswordSequentialValidator.Enabled = true;

                        NewPasswordSequentialValidator.ValidationExpression = "(?!.*(?:0(?=1)|1(?=2)|2(?=3)|3(?=4)|4(?=5)|5(?=6)|6(?=7)|7(?=8)|8(?=9)){" + Maintenance.max_length_sequential_characters + ",}\\d|" +
                                                                              ".*(?:9(?=8)|8(?=7)|7(?=6)|6(?=5)|5(?=4)|4(?=3)|3(?=2)|2(?=1)|1(?=0)){" + Maintenance.max_length_sequential_characters + ",}\\d|" +
                                                                              ".*(?:[zZ](?=[yY])|[yY](?=[xX])|[xX](?=[wW])|[wW](?=[vV])|[vV](?=[uU])|[uU](?=[tT])|[tT](?=[sS])|[sS](?=[rR])|[rR](?=[qQ])|[qQ](?=[pP])|[pP](?=[oO])|[oO](?=[nN])|[nN](?=[mM])|[mM](?=[lL])|[lL](?=[kK])|[kK](?=[jJ])|[jJ](?=[iI])|[iI](?=[hH])|[hH](?=[gG])|[gG](?=[fF])|[fF](?=[eE])|[eE](?=[dD])|[dD](?=[cC])|[cC](?=[bB])|[bB](?=[aA])){" + Maintenance.max_length_sequential_characters + ",}\\w|" +
                                                                              ".*(?:[aA](?=[bB])|[bB](?=[cC])|[cC](?=[dD])|[dD](?=[eE])|[eE](?=[fF])|[fF](?=[gG])|[gG](?=[hH])|[hH](?=[iI])|[iI](?=[jJ])|[jJ](?=[kK])|[kK](?=[lL])|[lL](?=[mM])|[mM](?=[nN])|[nN](?=[oO])|[oO](?=[pP])|[pP](?=[qQ])|[qQ](?=[rR])|[rR](?=[sS])|[sS](?=[tT])|[tT](?=[uU])|[uU](?=[vV])|[vV](?=[wW])|[wW](?=[xX])|[xX](?=[yY])|[yY](?=[zZ])){" + Maintenance.max_length_sequential_characters + ",}\\w).*";

                        if (Convert.ToInt32(Maintenance.max_length_sequential_characters) == 1)
                            lblNewPasswordSequentialErrorMessage.Text = "No sequential characters allowed.";
                        else
                            lblNewPasswordSequentialErrorMessage.Text = "Only up to " + Maintenance.max_length_sequential_characters + " sequential characters allowed.";
                    }

                    #endregion
                }
            }
        }

        /**
        * Validates the inputted password. If the input passes, the password in the database is updated to the newly inputted password
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbChangePassword_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (Employee.password != txtCurrentPassword.Text)
                {
                    lblError.Text = "Incorrect password.";
                    return;
                }
                else if (Employee.password == txtNewPassword.Text)
                {
                    lblError.Text = "Your new password cannot be the same as your current password.";
                    return;
                }
                else if (_BLL.CheckIfPasswordHistoryRestricted(Employee.user_id, txtNewPassword.Text))
                {
                    lblError.Text = "This password is restricted based on your recent password history. Please create a different password.";
                    return;
                }
                else if (Page.IsValid)
                {
                    if (_BLL.ChangePassword(Employee.user_id, txtConfirmPassword.Text) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to change your password.', 'error');", true);
                    }
                    else
                    {
                        //HttpContext.Current.Cache.Remove(("GetUser" + txtUserId.Text).ToLower());
                        _BLL.AddPasswordHistory(Employee.user_id, txtNewPassword.Text);
                        _BLL.AddAuditLogEntry(Employee.user_id, VG.c_user, "Edit", "Change Password", Request.UserHostAddress.ToString());
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "successRedirect('logout.aspx','Your password has been changed! Please log in again.');", true);
                    }
                }
            }
        }
    }
}