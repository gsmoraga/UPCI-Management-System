using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class maintenance_parameters : System.Web.UI.Page
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
                                lblHeader.Text = Maintenance.content_description + " Maintenance";

                                if (Maintenance.mode == "Add")
                                {
                                    lbBackCodeDesc.Visible = false;
                                    lbBackUser.Visible = false;
                                    lbBackUserGroup.Visible = false;
                                }

                                #region Validation

                                revCode.ValidationExpression = Validation.RegexAlphanumeric;
                                revCode.ErrorMessage = Validation.ErrorMessageAlphanumeric;

                                revDescription.ValidationExpression = Validation.RegexAlphanumericWithSpace;
                                revDescription.ErrorMessage = Validation.ErrorMessageAlphanumericWithSpace;

                                #endregion

                                #region Load Application Parameters
                                if (Maintenance.content_code == VG.c_application_parameters)
                                {
                                    txtWebsiteUrl.Text = Maintenance.website_url;
                                    txtAuditLogPurge.Text = Maintenance.audit_log_purge_days;
                                    txtRetentionSuccess.Text = Maintenance.retention_days_success;
                                    txtRetentionPending.Text = Maintenance.retention_days_pending;
                                    txtBankEmail.Text = Maintenance.bank_email_address;
                                    txtBankHotline.Text = Maintenance.bank_hotline;
                                    txtBankName.Text = Maintenance.bank_name;
                                    txtProfileExpiration.Text = Maintenance.profile_expiration_days;
                                    txtCeasPassingScore.Text = Maintenance.ceas_passing_score;
                                    txtEmailEngineSender.Text = Maintenance.email_engine_sender_address;
                                    txtMaxMobileDevices.Text = Maintenance.max_allowed_mobile_devices;
                                    txtProfileExpiryReminder.Text = Maintenance.profile_expiration_warning_days;
                                    txtPasswordExpiryReminder.Text = Maintenance.password_expiration_warning_days;
                                    txtReportHeader.Text = Maintenance.report_header;
                                    txtSpecialCharactersAllowed.Text = Maintenance.allowed_special_characters_application;
                                    txtSpecialCharactersNotAllowed.Text = Maintenance.restricted_username_special_characters;
                                    txtTaskSummaryPurge.Text = Maintenance.task_summary_purge_days;
                                    txtMaxRecordCount.Text = Maintenance.max_extractable_record_count;
                                    txtWorkHoursStartTime.Text = Maintenance.work_hours_start_time;
                                    txtWorkHoursEndTime.Text = Maintenance.work_hours_end_time;
                                    txtLunchHourStartTime.Text = Maintenance.lunch_hour_start_time;
                                    txtLunchHourEndTime.Text = Maintenance.lunch_hour_end_time;

                                    applicationParametersCard.Visible = true;
                                }
                                #endregion

                                #region Load Security Parameters
                                else if (Maintenance.content_code == VG.c_security_parameters)
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

                                    securityParametersCard.Visible = true;
                                }
                                #endregion

                                #region Load Add Maintenance
                                else if (Maintenance.mode == "Add")
                                {
                                    if (Maintenance.content_type == "1")
                                    {
                                        lbCodeDescCard.Text = Maintenance.mode;
                                        hCodeDesc.InnerText = Maintenance.mode + " " + Maintenance.content_description;
                                        codeDescCard.Visible = true;

                                        if (Maintenance.content_code == VG.c_ministry_department)
                                        {
                                            lblCode.InnerText = "Department Code";
                                            lblCode2.InnerText = "Division";
                                            _BLL.GetDivisionDropDown(ddCode, "--Select--");
                                            rowCode2.Visible = true;
                                        }
                                        else if (Maintenance.content_code == VG.c_pepsol)
                                        {
                                            _BLL.GetRegionDropdown(ddRegion, "--Select--");
                                            rowEmail.Visible = true;
                                            rowRegion.Visible = true;
                                        }
                                    }

                                    else if (Maintenance.content_type == "2")
                                    {
                                        lbCodeDescCard.Text = Maintenance.mode;
                                        hCodeDesc.InnerText = Maintenance.mode + " " + Maintenance.content_description;
                                        codeDescCard.Visible = false;

                                        if (Maintenance.content_code == VG.c_user_group)
                                        {
                                            LoadTreeView(tvAccessRightsBackend, "", "0");
                                            tvAccessRightsBackend.Attributes.Add("onclick", "OnTreeClick(event)");
                                            LoadTreeView(tvAccessRightsFrontend, "", "1");
                                            tvAccessRightsFrontend.Attributes.Add("onclick", "OnTreeClick(event)");
                                            LoadTreeView(tvAccessRightsReports, "", "2");
                                            tvAccessRightsReports.Attributes.Add("onclick", "OnTreeClick(event)");
                                            lbUserGroup.Text = Maintenance.mode;
                                            hUserGroup.InnerText = Maintenance.mode + " " + Maintenance.content_description;

                                            userGroupCard.Visible = true;
                                        }
                                        else if (Maintenance.content_code == VG.c_user)
                                        {
                                            lbUser.Text = Maintenance.mode;
                                            hUser.InnerText = Maintenance.mode + " " + Maintenance.content_description;
                                            _BLL.GetUserGroupDropDown(ddUserGroup, "--Select--");
                                            _BLL.GetBranchDropDown(ddBranch, "--Select--");
                                            _BLL.GetDepartmentDropDown(ddDepartment, "--Select--");
                                            divStatus.Visible = false;

                                            _BLL.GetApplicationParameters();
                                            UserIDValidator.ValidationExpression = "^[a-zA-Z0-9][^" + Maintenance.restricted_username_special_characters + "]*$";
                                            UserIDValidator.ErrorMessage = "Must be alphanumeric and without the " + Maintenance.restricted_username_special_characters + " special characters.";

                                            userCard.Visible = true;
                                        }
                                    }
                                }
                                #endregion

                                #region Load Edit Maintenance
                                else if (Maintenance.mode == "Edit")
                                {
                                    #region Content Type 1
                                    if (Maintenance.content_type == "1")
                                    {
                                        txtCode.ReadOnly = true;
                                        txtCode.Attributes.Add("class", "form-control-plaintext");
                                        hCodeDesc.InnerText = Maintenance.mode + " " + Maintenance.content_description;
                                        codeDescCard.Visible = true;

                                        #region Department
                                        if (Maintenance.content_code == VG.c_ministry_department)
                                        {
                                            txtCode.ReadOnly = true;
                                            txtCode.Attributes.Add("class", "form-control-plaintext");
                                            hCodeDesc.InnerText = Maintenance.mode + " " + Maintenance.content_description;
                                            codeDescCard.Visible = true;

                                            lblCode.InnerText = "Department Code";
                                            lblCode2.InnerText = "Division";
                                            _BLL.GetDivisionDropDown(ddCode, "--Select--");
                                            rowCode2.Visible = true;

                                            if (_BLL.GetDepartment(Maintenance.entry_code) == false)
                                            {
                                            }
                                            else
                                            {
                                                ddCode.SelectedValue = Maintenance.ministry_code;
                                            }
                                        }
                                        #endregion

                                        #region Branch
                                        else if (Maintenance.content_code == "7")
                                        {
                                            
                                            rowEmail.Visible = true;
                                            //8/16/2023 Additional for Region
                                            _BLL.GetRegionDropdown(ddRegion, "--Select--");
                                            rowRegion.Visible = true;


                                            if (_BLL.GetBranch(Maintenance.entry_code) == false)
                                            {
                                            }
                                            else
                                            {
                                                txtCodeDescEmail.Text = Maintenance.branch_email;
                                                //8/16/2023 Additional for Region
                                                ddRegion.SelectedValue = Maintenance.region;
                                            }
                                        }
                                        #endregion

                                        #region Division
                                        else if (Maintenance.content_code == VG.c_ministry)
                                        {
                                            if (_BLL.GetDivision(Maintenance.entry_code) == false)
                                            {
                                            }
                                        }
                                        #endregion

                                        txtCode.Text = Maintenance.code;
                                        txtDescription.Text = Maintenance.description;
                                    }
                                    #endregion

                                    #region Content Type 2
                                    else if (Maintenance.content_type == "2")
                                    {
                                        #region User
                                        if (Maintenance.content_code == VG.c_user)
                                        {
                                            txtUserId.ReadOnly = true;
                                            txtUserId.Attributes.Add("class", "form-control-plaintext");
                                            hUser.InnerText = Maintenance.mode + " " + Maintenance.content_description;
                                            _BLL.GetUserGroupDropDown(ddUserGroup, "--Select--");
                                            _BLL.GetBranchDropDown(ddBranch, "--Select--");
                                            _BLL.GetDepartmentDropDown(ddDepartment, "--Select--");
                                            divStatus.Visible = true;
                                            userCard.Visible = true;

                                            if (_BLL.GetUser(Maintenance.entry_code) == false)
                                            {

                                            }
                                            else
                                            {
                                                if (ddUserGroup.Items.FindByValue(Maintenance.user_group) == null)
                                                {
                                                    _BLL.AppendDeletedItem(ddUserGroup, VG.c_user_group, Maintenance.user_group);
                                                }

                                                if (ddBranch.Items.FindByValue(Maintenance.branch) == null)
                                                {
                                                    _BLL.AppendDeletedItem(ddBranch, VG.c_pepsol, Maintenance.branch);
                                                }

                                                if (ddDepartment.Items.FindByValue(Maintenance.department) == null)
                                                {
                                                    _BLL.AppendDeletedItem(ddDepartment, VG.c_ministry_department, Maintenance.department);
                                                }

                                                txtEmployeeNumber.Text = Maintenance.member_number;
                                                txtUserId.Text = Maintenance.user_id;
                                                txtFirstName.Text = Maintenance.first_name;
                                                txtMiddleName.Text = Maintenance.middle_name;
                                                txtLastName.Text = Maintenance.last_name;
                                                ddUserGroup.SelectedValue = Maintenance.user_group;
                                                ddUserGroup_SelectedIndexChanged(this, e);
                                                ddDepartment.SelectedValue = Maintenance.department;
                                                ddBranch.SelectedValue = Maintenance.branch;
                                                DateTime dateProfile = (DateTime)Maintenance.profile_expiration_date;
                                                if (dateProfile != Convert.ToDateTime("1900-01-01"))
                                                    txtProfileExpirationUser.Text = dateProfile.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                                                else
                                                    txtProfileExpirationUser.Text = "";
                                                txtEmail.Text = Maintenance.email;
                                                txtMobileNumber.Text = Maintenance.mobile_number;
                                                ddStatus.SelectedValue = Maintenance.status;

                                                if (Maintenance.user_group == Employee.user_group)
                                                    lbUserGroupShortcut.Visible = false;
                                            }
                                        }
                                        #endregion

                                        #region User Group
                                        else if (Maintenance.content_code == VG.c_user_group)
                                        {
                                            txtCodeUG.ReadOnly = true;
                                            txtCodeUG.Attributes.Add("class", "form-control-plaintext");
                                            hUserGroup.InnerText = Maintenance.mode + " " + Maintenance.content_description;
                                            userGroupCard.Visible = true;

                                            if (_BLL.GetUserGroup(Maintenance.entry_code) == false)
                                            {

                                            }
                                            else
                                            {
                                                LoadTreeView(tvAccessRightsBackend, Maintenance.code, "0");
                                                LoadTreeView(tvAccessRightsFrontend, Maintenance.code, "1");
                                                LoadTreeView(tvAccessRightsReports, Maintenance.code, "2");

                                                txtCodeUG.Text = Maintenance.code;
                                                txtDescriptionUG.Text = Maintenance.description;
                                                lblUserList.Text = Maintenance.user_list;
                                                divUserList.Visible = true;
                                            }
                                        }
                                        #endregion
                                    }

                                    #endregion
                                }
                                #endregion

                                #region Load View Maintenance
                                else if (Maintenance.mode == "View")
                                {
                                    #region Content Type 1
                                    if (Maintenance.content_type == "1")
                                    {
                                        hCodeDesc.InnerText = Maintenance.mode + " " + Maintenance.content_description;
                                        txtCode.ReadOnly = true;
                                        txtCode.Attributes.Add("class", "form-control-plaintext");
                                        txtDescription.Visible = false;
                                        lblDescription.Visible = true;
                                        lbCodeDescCard.Visible = false;
                                        codeDescCard.Visible = true;

                                        if (Maintenance.content_code == VG.c_ministry_department)
                                        {
                                            lblCode.InnerText = "Department Code";
                                            lblCode2.InnerText = "Division";
                                            _BLL.GetDivisionDropDown(ddCode, "--Select--");
                                            rowCode2.Visible = true;

                                            if (_BLL.GetDepartment(Maintenance.entry_code) == false)
                                            {
                                            }
                                            else
                                            {
                                                ddCode.SelectedValue = Maintenance.ministry_code;
                                                lblDdCode.Text = ddCode.SelectedItem.Text;
                                                lblDdCode.Visible = true;
                                            }
                                        }
                                        else if (Maintenance.content_code == VG.c_pepsol)
                                        {
                                            if (_BLL.GetBranch(Maintenance.entry_code) == false)
                                            {
                                            }
                                            txtCodeDescEmail.Text = Maintenance.branch_email;
                                            txtCodeDescEmail.ReadOnly = true;
                                            txtCodeDescEmail.Attributes.Add("class", "form-control-plaintext");
                                            txtCodeDescEmail.Attributes.Remove("placeholder");
                                            rowEmail.Visible = true;

                                            //8/15/2023
                                            rowRegion.Visible = true;
                                            lblRegion.Text = Maintenance.region_name;
                                            lblRegion.Visible = true;
                                            ddRegion.Visible = false;
                                        }
                                        else if (Maintenance.content_code == VG.c_ministry)
                                        {
                                            if (_BLL.GetDivision(Maintenance.entry_code) == false)
                                            {
                                            }
                                        }

                                        txtCode.Text = Maintenance.code;
                                        lblDescription.Text = Maintenance.description;
                                    }
                                    #endregion

                                    #region Content Type 2
                                    else if (Maintenance.content_type == "2")
                                    {
                                        #region User
                                        if (Maintenance.content_code == VG.c_user)
                                        {
                                            hUser.InnerText = Maintenance.mode + " " + Maintenance.content_description;
                                            txtEmployeeNumber.ReadOnly = true;
                                            txtEmployeeNumber.Attributes.Add("class", "form-control-plaintext");
                                            txtUserId.ReadOnly = true;
                                            txtUserId.Attributes.Add("class", "form-control-plaintext");
                                            txtFirstName.ReadOnly = true;
                                            txtFirstName.Attributes.Add("class", "form-control-plaintext");
                                            txtMiddleName.ReadOnly = true;
                                            txtMiddleName.Attributes.Add("class", "form-control-plaintext");
                                            txtLastName.ReadOnly = true;
                                            txtLastName.Attributes.Add("class", "form-control-plaintext");
                                            ddUserGroup.Visible = false;
                                            lblUserGroup.Visible = true;
                                            ddDepartment.Visible = false;
                                            lblDepartment.Visible = true;
                                            ddBranch.Visible = false;
                                            lblBranch.Visible = true;
                                            txtProfileExpirationUser.ReadOnly = true;
                                            txtProfileExpirationUser.Attributes.Add("class", "form-control-plaintext");
                                            txtEmail.ReadOnly = true;
                                            txtEmail.Attributes.Add("class", "form-control-plaintext");
                                            txtMobileNumber.ReadOnly = true;
                                            txtMobileNumber.Attributes.Add("class", "form-control-plaintext");
                                            ddStatus.Visible = false;
                                            lblStatus.Visible = true;
                                            divStatus.Visible = true;
                                            lbUser.Visible = false;
                                            _BLL.GetUserGroupDropDown(ddUserGroup, "--Select--");
                                            _BLL.GetBranchDropDown(ddBranch, "--Select--");
                                            _BLL.GetDepartmentDropDown(ddDepartment, "--Select--");
                                            userCard.Visible = true;

                                            if (_BLL.GetUser(Maintenance.entry_code) == false)
                                            {

                                            }
                                            else
                                            {
                                                if (ddUserGroup.Items.FindByValue(Maintenance.user_group) == null)
                                                {
                                                    _BLL.AppendDeletedItem(ddUserGroup, VG.c_user_group, Maintenance.user_group);
                                                }

                                                if (ddBranch.Items.FindByValue(Maintenance.branch) == null)
                                                {
                                                    _BLL.AppendDeletedItem(ddBranch, VG.c_pepsol, Maintenance.branch);
                                                }

                                                if (ddDepartment.Items.FindByValue(Maintenance.department) == null)
                                                {
                                                    _BLL.AppendDeletedItem(ddDepartment, VG.c_ministry_department, Maintenance.department);
                                                }

                                                txtEmployeeNumber.Text = Maintenance.member_number;
                                                txtUserId.Text = Maintenance.user_id;
                                                txtFirstName.Text = Maintenance.first_name;
                                                txtMiddleName.Text = Maintenance.middle_name;
                                                txtLastName.Text = Maintenance.last_name;
                                                ddUserGroup.SelectedValue = Maintenance.user_group;
                                                ddUserGroup_SelectedIndexChanged(this, e);
                                                lblUserGroup.Text = ddUserGroup.SelectedItem.Text;
                                                ddDepartment.SelectedValue = Maintenance.department;
                                                lblDepartment.Text = ddDepartment.SelectedItem.Text;
                                                ddBranch.SelectedValue = Maintenance.branch;
                                                lblBranch.Text = ddBranch.SelectedItem.Text;
                                                DateTime dateProfile = (DateTime)Maintenance.profile_expiration_date;
                                                if (dateProfile != Convert.ToDateTime("1900-01-01"))
                                                    txtProfileExpirationUser.Text = dateProfile.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                                                else
                                                {
                                                    txtProfileExpirationUser.Text = "";
                                                    txtProfileExpirationUser.Attributes.Remove("placeholder");
                                                }
                                                txtEmail.Text = Maintenance.email;
                                                txtMobileNumber.Text = Maintenance.mobile_number;
                                                ddStatus.SelectedValue = Maintenance.status;
                                                lblStatus.Text = ddStatus.SelectedItem.Text;

                                                if (Maintenance.user_group == Employee.user_group)
                                                    lbUserGroupShortcut.Visible = false;
                                            }
                                        }
                                        #endregion

                                        #region User Group
                                        else if (Maintenance.content_code == VG.c_user_group)
                                        {
                                            txtCodeUG.ReadOnly = true;
                                            txtCodeUG.Attributes.Add("class", "form-control-plaintext");
                                            txtDescriptionUG.Visible = false;
                                            lblDescriptionUG.Visible = true;
                                            hUserGroup.InnerText = Maintenance.mode + " " + Maintenance.content_description;
                                            lbUserGroup.Visible = false;
                                            userGroupCard.Visible = true;

                                            if (_BLL.GetUserGroup(Maintenance.entry_code) == false)
                                            {

                                            }
                                            else
                                            {
                                                txtCodeUG.Text = Maintenance.code;
                                                lblDescriptionUG.Text = Maintenance.description;
                                                LoadTreeView(tvAccessRightsBackend, Maintenance.code, "0", true);
                                                LoadTreeView(tvAccessRightsFrontend, Maintenance.code, "1", true);
                                                LoadTreeView(tvAccessRightsReports, Maintenance.code, "2", true);
                                                lblUserList.Text = Maintenance.user_list;
                                                divUserList.Visible = true;
                                            }
                                        }
                                        #endregion

                                    }
                                    #endregion
                                }
                                #endregion
                            }
                        }
                    }
                }
            }
        }

        /**
        * Adds or updates the database table of the selected maintenance item with the inputted values.
        * For maintenance items with code, description, and a few other fields only.
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbCodeDescCard_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Boolean result = false;
                string cacheKey = "";

                #region Edit

                if (Maintenance.mode == "Edit")
                {
                    if (Maintenance.content_code == VG.c_ministry_department)
                    {
                        result = _BLL.EditDepartment(Maintenance.entry_code, txtDescription.Text, ddCode.SelectedValue);
                        cacheKey = "GetDepartment" + Maintenance.entry_code;
                    }
                    else if (Maintenance.content_code == VG.c_pepsol)
                    {
                        //8/16/2023 Additional Parameter for Region
                        result = _BLL.EditBranch(Maintenance.entry_code, txtDescription.Text, txtCodeDescEmail.Text, ddRegion.SelectedValue);
                        cacheKey = "GetBranch" + Maintenance.entry_code;
                    }
                    else if (Maintenance.content_code == VG.c_ministry)
                    {
                        result = _BLL.EditDivision(Maintenance.entry_code, txtDescription.Text);
                        cacheKey = "GetDivision" + Maintenance.entry_code;
                    }

                    if (result == false)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to update the entry.', 'error');", true);
                    }
                    else
                    {
                        if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, Maintenance.mode, "Code: " + Maintenance.entry_code, Request.UserHostAddress.ToString()) == false)
                        {
                        }
                        else
                        {
                            _BLL.RemoveFromCache("Filter" + Maintenance.content_code + "&");
                            HttpContext.Current.Cache.Remove(cacheKey.ToLower());

                            string transactionReferenceNumber = "EPS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;
                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been updated.','" + transactionReferenceNumber + "');", true);
                        }
                    }
                }
                #endregion

                #region Add

                else if (Maintenance.mode == "Add")
                {
                    if (IfExisting(Maintenance.content_code, txtCode.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Code is already in use.', '', 'error');", true);
                    }
                    else
                    {
                        if (Maintenance.content_code == VG.c_ministry_department)
                        {
                            result = _BLL.AddDepartment(txtCode.Text, txtDescription.Text, ddCode.SelectedValue);
                            cacheKey = "GetDepartment" + txtCode.Text;
                        }
                        else if (Maintenance.content_code == VG.c_pepsol)
                        {
                            result = _BLL.AddBranch(txtCode.Text, txtDescription.Text,ddRegion.SelectedValue,txtCodeDescEmail.Text);
                            cacheKey = "GetBranch" + txtCode.Text;
                        }
                        else if (Maintenance.content_code == VG.c_ministry)
                        {
                            result = _BLL.AddDivision(txtCode.Text, txtDescription.Text);
                            cacheKey = "GetDivision" + txtCode.Text;
                        }

                        if (result == false)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to add the entry.', 'error');", true);
                        }
                        else
                        {
                            _BLL.RemoveFromCache("Filter" + Maintenance.content_code + "&");
                            HttpContext.Current.Cache.Remove(cacheKey.ToLower());

                            string transactionReferenceNumber = "";
                            if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, Maintenance.mode, "Code: " + txtCode.Text, Request.UserHostAddress.ToString()))
                                transactionReferenceNumber = "EPS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been added.','" + transactionReferenceNumber + "');", true);

                            txtCode.Text = "";
                            txtDescription.Text = "";
                            txtEmail.Text = "";
                            ddRegion.SelectedValue = "0";
                            ddCode.SelectedValue = "0";
                        }
                    }
                }
                #endregion
            }
        }

        /**
        * Adds or updates the user database table with the inputted values.
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbUser_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (Maintenance.mode == "Edit")
                {
                    if (_BLL.EditUser(txtEmployeeNumber.Text, txtUserId.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, ddUserGroup.SelectedValue, ddDepartment.SelectedValue, ddBranch.SelectedValue, txtProfileExpirationUser.Text, txtEmail.Text, txtMobileNumber.Text, ddStatus.SelectedValue) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to update the user information.', 'error');", true);
                    }
                    else
                    {
                        if (_BLL.SetUserStatus(txtUserId.Text, ddStatus.SelectedValue) == false)
                        {
                        }

                        _BLL.RemoveFromCache("Filter" + VG.c_user + "&");
                        //HttpContext.Current.Cache.Remove(("GetUser" + txtUserId.Text).ToLower());

                        string transactionReferenceNumber = "";
                        if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, Maintenance.mode, "User ID: " + txtUserId.Text, Request.UserHostAddress.ToString()))
                            transactionReferenceNumber = "EPS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('User information has been updated.','" + transactionReferenceNumber + "');", true);
                    }
                }
                else if (Maintenance.mode == "Add")
                {
                    if (IfExisting(Maintenance.content_code, txtUserId.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('User ID is already in use.', '', 'error');", true);
                    }
                    else
                    {
                        //HttpContext.Current.Cache.Remove(("GetUser" + txtUserId.Text).ToLower());

                        if (_BLL.AddUser(txtEmployeeNumber.Text, txtUserId.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, ddUserGroup.SelectedValue, ddDepartment.SelectedValue, ddBranch.SelectedValue, txtProfileExpirationUser.Text, txtEmail.Text, txtMobileNumber.Text, ddStatus.SelectedValue, Employee.user_id) == false)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to add the user.', 'error');", true);
                        }
                        else
                        {
                            _BLL.RemoveFromCache("Filter5&");

                            string transactionReferenceNumber = "";
                            if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, Maintenance.mode, "User ID: " + txtUserId.Text, Request.UserHostAddress.ToString()))
                                transactionReferenceNumber = "EPS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('User has been added and an email notification has been sent to their email address.','" + transactionReferenceNumber + "');", true);

                            if (_BLL.SendEmailNotificationUser(txtUserId.Text, "has been created") == false)
                            {
                            }

                            txtUserId.Text = "";
                            txtEmployeeNumber.Text = "";
                            txtFirstName.Text = "";
                            txtMiddleName.Text = "";
                            txtLastName.Text = "";
                            ddUserGroup.SelectedValue = "0";
                            ddDepartment.SelectedValue = "0";
                            ddBranch.SelectedValue = "0";
                            txtProfileExpirationUser.Text = "";
                            txtEmail.Text = "";
                            txtMobileNumber.Text = "";
                        }
                    }
                }
            }
        }

        /**
        * Redirects the user back to the Maintenance overview page
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbBack_Click(object sender, EventArgs e)
        {
            Maintenance.back = true;
            Response.Redirect("view-maintenance.aspx", false);
        }

        /**
        * Updates the database table of the Application Parameters with the inputted values
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbSaveApplicationParameters_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (_BLL.EditApplicationParameters(txtWebsiteUrl.Text, txtAuditLogPurge.Text, txtRetentionSuccess.Text, txtRetentionPending.Text, txtBankEmail.Text,
                    txtBankHotline.Text, txtBankName.Text, txtProfileExpiration.Text, txtCeasPassingScore.Text, txtEmailEngineSender.Text,
                    txtMaxMobileDevices.Text, txtProfileExpiryReminder.Text, txtPasswordExpiryReminder.Text, txtReportHeader.Text, txtSpecialCharactersAllowed.Text,
                    txtSpecialCharactersNotAllowed.Text, txtTaskSummaryPurge.Text, txtMaxRecordCount.Text,
                    txtWorkHoursStartTime.Text, txtWorkHoursEndTime.Text, txtLunchHourStartTime.Text, txtLunchHourEndTime.Text) == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to update the Application Parameters.', 'error');", true);
                }
                else
                {
                    HttpContext.Current.Cache.Remove(("GetApplicationParameters").ToLower());

                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Edit", "", Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = "EPS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Application Parameters have been updated.','" + transactionReferenceNumber + "');", true);
                }
            }
        }

        /**
        * Updates the database table of the Security Parameters with the inputted values
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
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
                        transactionReferenceNumber = "EPS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Security Parameters have been updated.','" + transactionReferenceNumber + "');", true);
                }
            }
        }

        /**
        * Adds or updates the user group database table with the inputted values.
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbUserGroupCard_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                string accessRights = "";
                StringBuilder builder = new StringBuilder();

                foreach (TreeNode item in tvAccessRightsBackend.CheckedNodes)
                {
                    builder.Append(item.Value + ",");
                }
                foreach (TreeNode item in tvAccessRightsFrontend.CheckedNodes)
                {
                    builder.Append(item.Value + ",");
                }
                foreach (TreeNode item in tvAccessRightsReports.CheckedNodes)
                {
                    builder.Append(item.Value + ",");
                }

                accessRights = Convert.ToString(builder);

                if (accessRights != "")
                {
                    if (Maintenance.mode == "Edit")
                    {
                        if (_BLL.EditUserGroup(txtCodeUG.Text, txtDescriptionUG.Text, Employee.user_id, accessRights) == false)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to update the user group.', 'error');", true);
                        }
                        else
                        {
                            _BLL.RemoveFromCache("Filter" + VG.c_user_group + "&");
                            HttpContext.Current.Cache.Remove(("GetUserGroup" + txtCodeUG.Text).ToLower());
                            HttpContext.Current.Cache.Remove(("AccessRights" + txtCodeUG.Text).ToLower());

                            string transactionReferenceNumber = "";
                            if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Edit", "Code: " + txtCodeUG.Text, Request.UserHostAddress.ToString()))
                                transactionReferenceNumber = "EPS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('User group has been updated.','" + transactionReferenceNumber + "');", true);
                        }
                    }
                    else if (Maintenance.mode == "Add")
                    {
                        if (IfExisting(Maintenance.content_code, txtCodeUG.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Code is already in use.', '', 'error');", true);
                        }
                        else
                        {
                            HttpContext.Current.Cache.Remove(("GetUserGroup" + txtCodeUG.Text).ToLower());
                            HttpContext.Current.Cache.Remove(("AccessRights" + txtCodeUG.Text).ToLower());

                            if (_BLL.AddUserGroup(txtCodeUG.Text, txtDescriptionUG.Text, Employee.user_id, accessRights) == false)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to add the user group.', 'error');", true);
                            }
                            else
                            {
                                _BLL.RemoveFromCache("Filter" + VG.c_user_group + "&");

                                string transactionReferenceNumber = "";
                                if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Add", "Code: " + txtCodeUG.Text, Request.UserHostAddress.ToString()))
                                    transactionReferenceNumber = "EPS-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + Maintenance.sequence_number;

                                ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('User group has been added.','" + transactionReferenceNumber + "');", true);
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Please tick at least one of the access rights.', 'error');", true);
                }
            }
        }

        /**
        * Loads the access rights tree for the User Group maintenance from the database
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void LoadTreeView(TreeView tv, string userGroupCode, string rootCode, bool displayAccessOnly = false)
        {
            if (_BLL.SessionIsActive(this))
            {
                DAL _DAL = new DAL();

                List<string> ar = _DAL.AccessRights(userGroupCode).ToList();
                DataSet ds = _DAL.Dataset_UserGroup(rootCode);

                foreach (DataRow level1DataRow in ds.Tables[0].Rows)
                {
                    if (displayAccessOnly == false)
                    {
                        if (string.IsNullOrEmpty(level1DataRow["parent_code"].ToString()))
                        {
                            TreeNode parentTreeNode = new TreeNode();
                            parentTreeNode.Text = level1DataRow["description"].ToString();
                            parentTreeNode.Value = level1DataRow["code"].ToString();
                            if (ar.Contains(level1DataRow["code"].ToString()))
                            {
                                parentTreeNode.Checked = true;
                            }
                            tv.Nodes.Add(parentTreeNode);
                            GetChildRows(level1DataRow, parentTreeNode, ar, displayAccessOnly);
                        }
                    }
                    else if (displayAccessOnly == true)
                    {
                        if (string.IsNullOrEmpty(level1DataRow["parent_code"].ToString()))
                        {
                            TreeNode parentTreeNode = new TreeNode();
                            parentTreeNode.ShowCheckBox = false;
                            parentTreeNode.Text = level1DataRow["description"].ToString();
                            parentTreeNode.Value = level1DataRow["code"].ToString();
                            parentTreeNode.SelectAction = TreeNodeSelectAction.None;
                            if (ar.Contains(level1DataRow["code"].ToString()))
                            {
                                parentTreeNode.Checked = true;
                                tv.Nodes.Add(parentTreeNode);
                                GetChildRows(level1DataRow, parentTreeNode, ar, displayAccessOnly);
                            }
                        }
                    }
                }
            }
        }

        /**
        * Determines which child rows of the access rights tree will be displayed
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        private void GetChildRows(DataRow dataRow, TreeNode treeNode, List<string> ar, bool displayAccessOnly = false)
        {
            DataRow[] childRows = dataRow.GetChildRows("ChildRows");
            if (displayAccessOnly == false)
            {
                foreach (DataRow row in childRows)
                {
                    TreeNode childTreeNode = new TreeNode();
                    childTreeNode.Text = row["description"].ToString();
                    childTreeNode.Value = row["code"].ToString();
                    //display all child nodes
                    treeNode.ChildNodes.Add(childTreeNode);

                    if (ar.Contains(row["code"].ToString()))
                    {
                        childTreeNode.Checked = true;
                    }

                    if (row.GetChildRows("ChildRows").Length > 0)
                    {
                        GetChildRows(row, childTreeNode, ar, displayAccessOnly);
                    }
                }
            }
            else if (displayAccessOnly == true)
            {
                foreach (DataRow row in childRows)
                {
                    TreeNode childTreeNode = new TreeNode();
                    childTreeNode.ShowCheckBox = false;
                    childTreeNode.Text = row["description"].ToString();
                    childTreeNode.Value = row["code"].ToString();
                    childTreeNode.SelectAction = TreeNodeSelectAction.None;

                    if (ar.Contains(row["code"].ToString()))
                    {
                        childTreeNode.Checked = true;
                        treeNode.ChildNodes.Add(childTreeNode);
                    }

                    if (row.GetChildRows("ChildRows").Length > 0)
                    {
                        GetChildRows(row, childTreeNode, ar, displayAccessOnly);
                    }
                }
            }
        }

        /**
        * Called when the user group dropdown index has changed and changes the displayed elements according to the selected index
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void ddUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddUserGroup.SelectedValue != "0")
            {
                tvAccessRightsModal.Nodes.Clear();
                LoadTreeView(tvAccessRightsModal, ddUserGroup.SelectedValue, "All", true);

                tvAccessRightsModal.ExpandAll();
                accessRightsModalTitle.InnerText = ddUserGroup.SelectedItem.Text + " Access Rights";

                lbViewUserGroup.Visible = true;
            }
            else
            {
                lbViewUserGroup.Visible = false;
            }
        }

        /**
        * Redirects user to the selected user group's edit page
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbUserGroupShortcut_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Maintenance.content_code = VG.c_user_group;
                Maintenance.bank_user_security = false;

                if (_BLL.GetContentType(Maintenance.content_code) == false)
                {
                }
                else
                {
                    Maintenance.code_filter = "";
                    Maintenance.description_filter = "";
                    Maintenance.page_index = 0;

                    Maintenance.entry_code = ddUserGroup.SelectedValue;
                    Maintenance.mode = "Edit";

                    Response.Redirect("maintenance-parameters.aspx", false);
                }
            }
        }

        /**
        * Checks if an entry with the given code exists
        * 
        * @since version 1.0 
        * @param string contentCode - code of the content
        * @param string code - unique code identifier
        * @return Boolean true if successful, false otherwise
        */
        public Boolean IfExisting(string contentCode, string code)
        {
            if (Maintenance.content_code == VG.c_ministry_department)
            {
                return _BLL.GetDepartment(code);
            }
            else if (Maintenance.content_code == VG.c_user_group)
            {
                return _BLL.GetUserGroup(code);
            }
            else if (Maintenance.content_code == VG.c_user)
            {
                return _BLL.GetUser(code);
            }
            else if (Maintenance.content_code == VG.c_pepsol)
            {
                return _BLL.GetBranch(code);
            }
            else if (Maintenance.content_code == VG.c_ministry)
            {
                return _BLL.GetDivision(code);
            }
            else return false;
        }
    }
}