using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class BLL
{
    private readonly DAL _DAL = new DAL();

    public BLL()
    {
    }

    /*****CHECK SESSION STATUS*****/
    /**
    * Checks if the current user's session state is active
    * 
    * @since version 1.5
    * @return Boolean true if active, false otherwise
    */
    public Boolean SessionIsActive(Page page)
    {
        if (string.IsNullOrEmpty(Employee.user_id))
        {
            ScriptManager.RegisterStartupScript(page, GetType(), "Script", "noAccessRedirect('logout.aspx');", true);

            return false;
        }
        else
        {
            if (GetActiveSession(Convert.ToString(HttpContext.Current.Session["SessionID"]), Employee.user_id) == false)
            {
                ScriptManager.RegisterStartupScript(page, GetType(), "Script", "sessionRedirect('logout.aspx');", true);

                return false;
            }
            else
                return true;
        }
    }

    /*****MAINTENANCE FUNCTIONS*****/

    #region Contents
    /**
    * Filters the data table of maintenance type that match the filter string
    * 
    * @since version 1.0 
    * @param string value - unique code identifier
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetContentType(string value)
    {
        DataTable dt = _DAL.GetContentType(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.content_description = Convert.ToString(dt.Rows[0]["description"]);
            Maintenance.content_type = Convert.ToString(dt.Rows[0]["content_type"]);

            return true;
        }
    }

    /**
    * Gets the list of entries in the database and binds it to a dropdown
    * 
    * @since version 1.0 
    * @param ListBox box - list box where the list will be binded
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetBackendListBox(ListBox box)
    {
        try
        {
            DataTable dt = _DAL.FilterContents("", "0");
            box.DataSource = dt;
            box.DataValueField = "code";
            box.DataTextField = "description";
            box.DataBind();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /**
    * Gets the list of entries in the database and binds it to a dropdown
    * 
    * @since version 1.0 
    * @param ListBox box - list box where the list will be binded
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetFrontendListBox(ListBox box)
    {
        try
        {
            DataTable dt = _DAL.FilterContents("", "1");
            box.DataSource = dt;
            box.DataValueField = "code";
            box.DataTextField = "description";
            box.DataBind();
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region Application Parameters
    /**
    * Edits the application parameters with the given values
    * 
    * @since version 1.0 
    * @param string auditLogPurgeDays - number of days the audit logs will be kept before being purged from the system
	* @param string retentionDaysSuccess - number of days that successful transactions will be retained before being automatically purged from the system
	* @param string retentionDaysPending - number of days that pending transactions will be retained before being automatically purged from the system
	* @param string churchEmailAddress - email address of the church that will be part of the email body of transaction notifications
	* @param string churchHotline - phone numbers of the church that will be part of the email body of transaction notifications
    * @param string churchName - name of the church that will be part of the email body of transaction notifications
	* @param string profileExpirationDays - number of days from the current date that will appear as the default date for user Profile Expiration Date
	* @param string ceasPassingScore - passing Score for CEAS
	* @param string emailEngineSenderAddress - sender email address that will appear when receiving an email from the church
	* @param string maxAllowedMobileDevices - maximum number of mobile devices to be enrolled in mobile application
	* @param string profileExpirationWarningDays - number of days from the password expiry date before the user’s profile will be expired
	* @param string passwordExpirationWarningDays - number of days from the password expiry date before the client will be sent a password expiry reminder
	* @param string reportHeader - header for the reports
	* @param string allowedSpecialCharacters - list of special characters allowed in the application
	* @param string restrictedUsernameSpecialCharacters - list of characters that will not be accepted when validating user names or user ID
	* @param string taskSummaryPurgeDays - date range for purging task summary. All data from the current date until the number of days specified will be saved and the rest will be purged
	* @param string maxExtractableRecordCount - maximum number of record count of data table to be downloaded via pdf and xls
    * @return Boolean true if successful, false otherwise
    */
    public Boolean EditApplicationParameters(string websiteUrl, string auditLogPurgeDays, string retentionDaysSuccess, string retentionDaysPending, string churchEmailAddress,
                                             string churchHotline, string churchName, string profileExpirationDays, string ceasPassingScore, string emailEngineSenderAddress,
                                             string maxAllowedMobileDevices, string profileExpirationWarningDays, string passwordExpirationWarningDays, string reportHeader,
                                             string allowedSpecialCharacters, string restrictedUsernameSpecialCharacters, string taskSummaryPurgeDays, string maxExtractableRecordCount,
                                             string workHoursStartTime, string workHoursEndTime, string lunchHourStartTime, string lunchHourEndTime)
    {
        if (_DAL.EditApplicationParameters(websiteUrl, auditLogPurgeDays, retentionDaysSuccess, retentionDaysPending, churchEmailAddress,
                                           churchHotline, churchName, profileExpirationDays, ceasPassingScore, emailEngineSenderAddress,
                                           maxAllowedMobileDevices, profileExpirationWarningDays, passwordExpirationWarningDays, reportHeader,
                                           allowedSpecialCharacters, restrictedUsernameSpecialCharacters, taskSummaryPurgeDays, maxExtractableRecordCount,
                                           workHoursStartTime, workHoursEndTime, lunchHourStartTime, lunchHourEndTime) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Filters the data table of application parameters
    * 
    * @since version 1.0 
    * @param 
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetApplicationParameters()
    {
        DataTable dt = _DAL.GetApplicationParameters();

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.website_url = Convert.ToString(dt.Rows[0]["website_url"]);
            Maintenance.audit_log_purge_days = Convert.ToString(dt.Rows[0]["audit_log_purge_days"]);
            Maintenance.bank_email_address = Convert.ToString(dt.Rows[0]["church_email_address"]);
            Maintenance.bank_hotline = Convert.ToString(dt.Rows[0]["church_hotline"]);
            Maintenance.bank_name = Convert.ToString(dt.Rows[0]["church_name"]);
            Maintenance.profile_expiration_days = Convert.ToString(dt.Rows[0]["profile_expiration_days"]);
            Maintenance.email_engine_sender_address = Convert.ToString(dt.Rows[0]["email_engine_sender_address"]);
            Maintenance.max_allowed_mobile_devices = Convert.ToString(dt.Rows[0]["max_allowed_mobile_devices"]);
            Maintenance.profile_expiration_warning_days = Convert.ToString(dt.Rows[0]["profile_expiration_warning_days"]);
            Maintenance.password_expiration_warning_days = Convert.ToString(dt.Rows[0]["password_expiration_warning_days"]);
            Maintenance.report_header = Convert.ToString(dt.Rows[0]["report_header"]);
            Maintenance.allowed_special_characters_application = Convert.ToString(dt.Rows[0]["allowed_special_characters"]);
            Maintenance.restricted_username_special_characters = Convert.ToString(dt.Rows[0]["restricted_username_special_characters"]);
            Maintenance.task_summary_purge_days = Convert.ToString(dt.Rows[0]["task_summary_purge_days"]);
            Maintenance.max_extractable_record_count = Convert.ToString(dt.Rows[0]["max_extractable_record_count"]);

            return true;
        }
    }

    #endregion

    #region Branch
    /**
    * Adds a branch entry with the given details to the database
    * 
    * @since version 1.0 
    * @param string branchCode - unique code to identify the branch entry
    * @param string description - name or description of the entry
    * @return Boolean true if successful, false otherwise
    */
    public Boolean AddBranch(string branchCode, string description, string region, string email)
    {
        if (_DAL.AddBranch(branchCode, description, region, email) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Edits the branch entry that matches the code with the given description
    * 
    * @since version 1.0 
    * @param string branchCode - unique code to identify the branch entry
    * @param string description - name or description of the entry
    * @return Boolean true if successful, false otherwise
    */
    public Boolean EditBranch(string branchCode, string description, string email, string region_code)
    {
        //8/16/2023 Additional Parameter for Region
        if (_DAL.EditBranch(branchCode, description, email, region_code) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Deletes the branch entry that matches the given code
    * 
    * @since version 1.0 
    * @param string branchCode - unique code to identify the branch entry
    * @return Boolean true if successful, false otherwise
    */
    public Boolean DeleteBranch(string branchCode)
    {
        if (_DAL.DeleteBranch(branchCode) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Filters the data table of branches that match the filter string
    * 
    * @since version 1.0 
    * @param GridView pObj - grid view where the data table will be binded to
    * @param string code - code to search
    * @param string description - description to search
    * @return Boolean true if successful, false otherwise
    */
    public Boolean FilterBranch(GridView pObj, string code, string description)
    {
        DataTable dt = _DAL.FilterBranch(code, description);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    /**
    * Assigns the values of the row that matches the search string to the corresponding fields of the Maintenance Class
    * 
    * @since version 1.0 
    * @param string value - unique code identifier
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetBranch(string value)
    {
        DataTable dt = _DAL.GetBranch(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.code = Convert.ToString(dt.Rows[0]["code"]);
            Maintenance.description = Convert.ToString(dt.Rows[0]["description"]);
            Maintenance.branch_email = Convert.ToString(dt.Rows[0]["email"]);
            //8-15-2023
            Maintenance.region = Convert.ToString(dt.Rows[0]["region_code"]);
            Maintenance.region_name = Convert.ToString(dt.Rows[0]["desc_region"]);
            return true;
        }
    }

    /**
    * Gets the list of entries in the database and binds it to a dropdown
    * 
    * @since version 1.0 
    * @param DropDownList dd - dropdown where the list will be binded
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetBranchDropDown(DropDownList dd, string item)
    {
        try
        {
            DataTable dt = _DAL.FilterBranch("", "");
            dd.DataSource = dt;
            dd.DataValueField = "code";
            dd.DataTextField = "description";
            dd.DataBind();
            dd.Items.Insert(0, new ListItem(item, "0"));
            return true;
        }
        catch
        {
            return false;
        }
    }

    /**
    * Gets the list of entries in the database and binds it to a dropdown
    * 
    * @since version 1.0 
    * @param DropDownList dd - dropdown where the list will be binded
    * @param item - determines the default dropdown item to be added
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetBranchListBox(ListBox box)
    {
        try
        {
            DataTable dt = _DAL.FilterBranch("", "");
            box.DataSource = dt;
            box.DataValueField = "code";
            box.DataTextField = "description";
            box.DataBind();
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region Department
    /**
    * Adds a department entry with the given details to the database
    * 
    * @since version 1.0 
    * @param string departmentCode - unique code to identify the department entry
    * @param string description - name or description of the entry
    * @return Boolean true if successful, false otherwise
    */
    public Boolean AddDepartment(string departmentCode, string description, string divisionCode)
    {
        if (_DAL.AddDepartment(departmentCode, description, divisionCode) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Edits the department entry that matches the code with the given description
    * 
    * @since version 1.0 
    * @param string departmentCode - unique code to identify the department entry
    * @param string description - name or description of the entry
    * @return Boolean true if successful, false otherwise
    */
    public Boolean EditDepartment(string departmentCode, string description, string divisionCode)
    {
        if (_DAL.EditDepartment(departmentCode, description, divisionCode) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Deletes the department entry that matches the given code
    * 
    * @since version 1.0 
    * @param string departmentCode - unique code to identify the department entry
    * @return Boolean true if successful, false otherwise
    */
    public Boolean DeleteDepartment(string departmentCode)
    {
        if (_DAL.DeleteDepartment(departmentCode) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Filters the data table of departments that match the filter string
    * 
    * @since version 1.0 
    * @param GridView pObj - grid view where the data table will be binded to
    * @param string code - code to search
    * @param string description - description to search
    * @return Boolean true if successful, false otherwise
    */
    public Boolean FilterDepartment(GridView pObj, string code, string description, string division)
    {
        DataTable dt = _DAL.FilterDepartment(code, description, division);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    /**
    * Assigns the values of the row that matches the search string to the corresponding fields of the Maintenance Class
    * 
    * @since version 1.0 
    * @param string value - unique code identifier
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetDepartment(string value)
    {
        DataTable dt = _DAL.GetDepartment(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.code = Convert.ToString(dt.Rows[0]["code"]);
            Maintenance.description = Convert.ToString(dt.Rows[0]["description"]);
            Maintenance.ministry_code = Convert.ToString(dt.Rows[0]["ministry_code"]);

            return true;
        }
    }

    /**
    * Gets the list of entries in the database and binds it to a dropdown
    * 
    * @since version 1.0 
    * @param DropDownList dd - dropdown where the list will be binded
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetDepartmentDropDown(DropDownList dd, string item)
    {
        try
        {
            DataTable dt = _DAL.FilterDepartment("", "", "0");
            dd.DataSource = dt;
            dd.DataValueField = "code";
            dd.DataTextField = "description";
            dd.DataBind();
            dd.Items.Insert(0, new ListItem(item, "0"));
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region Division
    /**
    * Adds a division entry with the given details to the database
    * 
    * @since version 1.0 
    * @param string divisionCode - unique code to identify the division entry
    * @param string description - name or description of the entry
    * @return Boolean true if successful, false otherwise
    */
    public Boolean AddDivision(string divisionCode, string description)
    {
        if (_DAL.AddDivision(divisionCode, description) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Edits the division entry that matches the code with the given description
    * 
    * @since version 1.0 
    * @param string divisionCode - unique code to identify the division entry
    * @param string description - name or description of the entry
    * @return Boolean true if successful, false otherwise
    */
    public Boolean EditDivision(string divisionCode, string description)
    {
        if (_DAL.EditDivision(divisionCode, description) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Deletes the division entry that matches the given code
    * 
    * @since version 1.0 
    * @param string divisionCode - unique code to identify the division entry
    * @return Boolean true if successful, false otherwise
    */
    public Boolean DeleteDivision(string divisionCode)
    {
        if (_DAL.DeleteDivision(divisionCode) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Filters the data table of divisions that match the filter string
    * 
    * @since version 1.0 
    * @param GridView pObj - grid view where the data table will be binded to
    * @param string code - code to search
    * @param string description - description to search
    * @return Boolean true if successful, false otherwise
    */
    public Boolean FilterDivision(GridView pObj, string code, string description)
    {
        DataTable dt = _DAL.FilterDivision(code, description);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    /**
    * Assigns the values of the row that matches the search string to the corresponding fields of the Maintenance Class
    * 
    * @since version 1.0 
    * @param string value - unique code identifier
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetDivision(string value)
    {
        DataTable dt = _DAL.GetDivision(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.code = Convert.ToString(dt.Rows[0]["code"]);
            Maintenance.description = Convert.ToString(dt.Rows[0]["description"]);

            return true;
        }
    }

    /**
    * Gets the list of entries in the database and binds it to a dropdown
    * 
    * @since version 1.0 
    * @param DropDownList dd - dropdown where the list will be binded
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetDivisionDropDown(DropDownList dd, string item)
    {
        try
        {
            DataTable dt = _DAL.FilterDivision("", "");
            dd.DataSource = dt;
            dd.DataValueField = "code";
            dd.DataTextField = "description";
            dd.DataBind();
            dd.Items.Insert(0, new ListItem(item, "0"));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Boolean GetRegionDropdown(DropDownList dd, string item)
    {
        try
        {
            DataTable dt = _DAL.GetRegion();
            dd.DataSource = dt;
            dd.DataValueField = "code";
            dd.DataTextField = "description";
            dd.DataBind();
            dd.Items.Insert(0, new ListItem(item, "0"));
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region Security Parameters
    /**
    * Edits the security parameters with the given values
    * 
    * @since version 1.0 
    * @param string minPasswordLength - minimum number of characters for passwords of users
	* @param string passwordExpirationDays - number of days before a front and back end user’s password will expire
	* @param string maxLengthRepeatingCharacters - number of times a character can be used in a password
	* @param string maxLengthSequentialCharacters - length of sequential letters or numbers that can be used in a password
	* @param string maxCumulativeInvalidPasswordTries - number of cumulative invalid passwords during login before a user will be tagged as Locked
	* @param string maxInvalidPasswordTries - number of invalid passwords during login before a user will be tagged as Locked
	* @param string maxRestrictedRecentPasswords - number of previously used passwords that cannot be used as the current password
	* @param string allowedSpecialCharacters - defines the list of characters that will be allowed if the password type allows special characters
	* @param string passwordType - defines the allowable character combination for passwords.
                                    Values are:
                                    •	1 - alphabetic characters only 
                                    •	2 - numeric characters only
                                    •	3 - alphanumeric characters only
                                    •	4 - alphanumeric characters with the special characters allowed in a password
	* @param string mobileActivationMinutes - time the user should input the mobile activation code before it expires
    * @return Boolean true if successful, false otherwise
    */
    public Boolean EditSecurityParameters(string minPasswordLength, string passwordExpirationDays, string maxLengthRepeatingCharacters, string maxLengthSequentialCharacters, string maxCumulativeInvalidPasswordTries, string maxInvalidPasswordTries, string maxRestrictedRecentPasswords, string allowedSpecialCharacters, string passwordType, string mobileActivationMinutes)
    {
        if (_DAL.EditSecurityParameters(minPasswordLength, passwordExpirationDays, maxLengthRepeatingCharacters, maxLengthSequentialCharacters, maxCumulativeInvalidPasswordTries, maxInvalidPasswordTries, maxRestrictedRecentPasswords, allowedSpecialCharacters, passwordType, mobileActivationMinutes) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Filters the data table of security parameters
    * 
    * @since version 1.0 
    * @param 
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetSecurityParameters()
    {
        DataTable dt = _DAL.GetSecurityParameters();

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.min_password_length = Convert.ToString(dt.Rows[0]["min_password_length"]);
            Maintenance.password_expiration_days = Convert.ToString(dt.Rows[0]["password_expiration_days"]);
            Maintenance.max_length_repeating_characters = Convert.ToString(dt.Rows[0]["max_length_repeating_characters"]);
            Maintenance.max_length_sequential_characters = Convert.ToString(dt.Rows[0]["max_length_sequential_characters"]);
            Maintenance.max_cumulative_invalid_password_tries = Convert.ToString(dt.Rows[0]["max_cumulative_invalid_password_tries"]);
            Maintenance.max_invalid_password_tries = Convert.ToString(dt.Rows[0]["max_invalid_password_tries"]);
            Maintenance.max_restricted_recent_passwords = Convert.ToString(dt.Rows[0]["max_restricted_recent_passwords"]);
            Maintenance.allowed_special_characters_password = Convert.ToString(dt.Rows[0]["allowed_special_characters"]);
            Maintenance.password_type = Convert.ToString(dt.Rows[0]["password_type"]);
            Maintenance.mobile_activation_minutes = Convert.ToString(dt.Rows[0]["mobile_activation_minutes"]);

            return true;
        }
    }
    #endregion

    #region User
    /**
    * Adds a user with the given details to the database
    * 
    * @since version 1.0 
    * @param string employeeNumber - employee number
    * @param string userID - user ID of the employee
    * @param string firstName - first name of the employee
    * @param string middleName - middle name of the employee
    * @param string lastName - last name of the employee
    * @param string userGroup - user group the employee belongs to
    * @param string department - department of the employee
    * @param string branch - branch of the employee
    * @param string profileExpirationDate - date the profile will expire
    * @param string email - email of the employee
    * @param string mobileNumber - mobile number of the employee
    * @param string status - user account status (1 - Active, 0 - Disabled)
    * @param string created_by - name of the employee who added the user
    * @return Boolean true if successful, false otherwise
    */
    public Boolean AddUser(string employeeNumber, string userID, string firstName, string middleName, string lastName, string userGroup, string department, string branch, string profileExpirationDate, string email, string mobileNumber, string status, string createdBy)
    {
        if (_DAL.AddUser(employeeNumber, userID, firstName, middleName, lastName, userGroup, department, branch, profileExpirationDate, email, mobileNumber, status, createdBy) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Edits a user with the given details in the database
    * 
    * @since version 1.0 
    * @param string employeeNumber - employee number
    * @param string userID - user ID of the employee
    * @param string firstName - first name of the employee
    * @param string middleName - middle name of the employee
    * @param string lastName - last name of the employee
    * @param string userGroup - user group the employee belongs to
    * @param string department - department of the employee
    * @param string branch - branch of the employee
    * @param string profileExpirationDate - date the profile will expire
    * @param string email - email of the employee
    * @param string mobileNumber - mobile number of the employee
    * @param string status - user account status (1 - Active, 0 - Disabled)
    * @param string created_by - name of the employee who added the user
    * @return Boolean true if successful, false otherwise
    */
    public Boolean EditUser(string employeeNumber, string userID, string firstName, string middleName, string lastName, string userGroup, string department, string branch, string profileExpirationDate, string email, string mobileNumber, string status)
    {
        if (_DAL.EditUser(employeeNumber, userID, firstName, middleName, lastName, userGroup, department, branch, profileExpirationDate, email, mobileNumber, status) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Deletes the user with the given employee number
    * 
    * @since version 1.0 
    * @param string userId - unique identifier of the user
    * @return Boolean true if successful, false otherwise
    */
    public Boolean DeleteUser(string userId)
    {
        if (_DAL.DeleteUser(userId) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Filters the data table of users that match the filter string
    * 
    * @since version 1.0 
    * @param GridView pObj - grid view where the data table will be binded to
    * @param string code - code to search
    * @param string description - description to search
    * @param string userId - user ID of the current user
    * @return Boolean true if successful, false otherwise
    */
    public Boolean FilterUser(GridView pObj, string code, string lastName, string firstName, string middleName, string userId, string userGroup, string division, string department, string branch, string status)
    {
        DataTable dt = _DAL.FilterUser(code, lastName, firstName, middleName, userId, userGroup, division, department, branch, status);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    /**
    * Filters the data table of users that match the filter string
    * 
    * @since version 1.0 
    * @param GridView pObj - grid view where the data table will be binded to
    * @param string code - code to search
    * @param string description - description to search
    * @param string userId - user ID of the current user
    * @return Boolean true if successful, false otherwise
    */
    public Boolean FilterLockedUser(GridView pObj, string code, string lastName, string firstName, string middleName, string userId, string userGroup, string division, string department, string branch, string status)
    {
        DataTable dt = _DAL.FilterLockedUser(code, lastName, firstName, middleName, userId, userGroup, division, department, branch, status);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    /**
    * Filters the data table row of the user that matches the given user ID
    * 
    * @since version 1.0 
    * @param string value - user ID
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetUser(string value)
    {
        DataTable dt = _DAL.GetUser(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.member_number = Convert.ToString(dt.Rows[0]["member_number"]);
            Maintenance.user_id = Convert.ToString(dt.Rows[0]["user_id"]);
            Maintenance.first_name = Convert.ToString(dt.Rows[0]["first_name"]);
            Maintenance.middle_name = Convert.ToString(dt.Rows[0]["middle_name"]);
            Maintenance.last_name = Convert.ToString(dt.Rows[0]["last_name"]);
            Maintenance.user_group = Convert.ToString(dt.Rows[0]["user_group"]);
            Maintenance.access_rights = Convert.ToString(dt.Rows[0]["access_rights"]);
            Maintenance.department = Convert.ToString(dt.Rows[0]["department"]);
            Maintenance.branch = Convert.ToString(dt.Rows[0]["branch"]);
            Maintenance.email = Convert.ToString(dt.Rows[0]["email"]);
            Maintenance.mobile_number = Convert.ToString(dt.Rows[0]["mobile_number"]);
            Maintenance.status = Convert.ToString(dt.Rows[0]["status"]);
            Maintenance.profile_expiration_date = (DateTime)dt.Rows[0]["profile_expiration_date"];

            return true;
        }
    }

    /**
    * Filters the data table row of the user that matches the given user ID
    * 
    * @since version 1.0 
    * @param string value - user ID
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetCurrentUserDetails(string value)
    {
        DataTable dt = _DAL.GetUser(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Employee.member_number = Convert.ToString(dt.Rows[0]["member_number"]);
            Employee.user_id = Convert.ToString(dt.Rows[0]["user_id"]);
            Employee.first_name = Convert.ToString(dt.Rows[0]["first_name"]);
            Employee.middle_name = Convert.ToString(dt.Rows[0]["middle_name"]);
            Employee.last_name = Convert.ToString(dt.Rows[0]["last_name"]);
            Employee.user_group = Convert.ToString(dt.Rows[0]["user_group"]);
            Employee.user_group_name = Convert.ToString(dt.Rows[0]["user_group_name"]);
            Employee.access_rights = Convert.ToString(dt.Rows[0]["access_rights"]);
            Employee.department = Convert.ToString(dt.Rows[0]["department"]);
            Employee.branch = Convert.ToString(dt.Rows[0]["branch"]);
            Employee.email = Convert.ToString(dt.Rows[0]["email"]);
            Employee.mobile_number = Convert.ToString(dt.Rows[0]["mobile_number"]);
            Employee.password = Convert.ToString(dt.Rows[0]["password"]);
            Employee.status = Convert.ToString(dt.Rows[0]["status"]);
            Employee.created_by = Convert.ToString(dt.Rows[0]["created_by"]);
            Employee.date_created = Convert.ToString(dt.Rows[0]["date_created"]);
            Employee.profile_expiration_date = (DateTime)dt.Rows[0]["profile_expiration_date"];
            Employee.remaining_password_attempts = Convert.ToInt32(dt.Rows[0]["remaining_password_attempts"]);
            Employee.cumulative_invalid_password_attempts = Convert.ToInt32(dt.Rows[0]["cumulative_invalid_password_attempts"]);
            Employee.using_default_password = Convert.ToString(dt.Rows[0]["using_default_password"]);
            Employee.password_expiration_date = (DateTime)dt.Rows[0]["password_expiration_date"];
            Employee.last_login_date = (DateTime)dt.Rows[0]["last_login_date"];

            return true;
        }
    }

    /**
    * Assigns the values of the access rights column to the Employee class
    * 
    * @since version 1.0 
    * @param string value - unique code identifier
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetUserAccessRights(string value)
    {
        DataTable dt = _DAL.GetUserGroup(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Employee.access_rights = Convert.ToString(dt.Rows[0]["access_rights"]);

            return true;
        }
    }

    /**
    * Sets the status of the user with the given employee number with the given status
    * 
    * @since version 1.0 
    * @param string userId - unique identifier of the user
    * @param int status - 1 - Active, 0 - Disabled
    * @return Boolean true if successful
    */
    public Boolean SetUserStatus(string userId, string status)
    {
        if (_DAL.SetUserStatus(userId, status) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Sets the last login date of the user with the given employee number to the current date
    * 
    * @since version 1.0 
    * @param string userId - unique identifier of the user
    * @return Boolean true if successful
    */
    public Boolean SetLastLoginDate(string userId)
    {
        if (_DAL.SetLastLoginDate(userId) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Returns the data table row that matches the given values
    * 
    * @since version 1.0 
    * @param string userId - ID of the user
    * @return Boolean true if successful
    */
    public Boolean GetLatestLoginDate(string userId)
    {
        DataTable dt = _DAL.GetLatestLoginDate(userId);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Employee.last_login_attempt_date = (DateTime)dt.Rows[0]["log_date"];
            Employee.last_login_attempt_status = Convert.ToString(dt.Rows[0]["status"]);

            return true;
        }
    }

    #endregion

    #region User Group
    /**
    * Adds a user group entry with the given details to the database
    * 
    * @since version 1.0 
    * @param string groupCode - unique code to identify the user group entry
    * @param string description - name or description of the entry
    * @param string createdBy - user ID of the one who created the group
    * @param string accessRights - determines the accessible content
    * @return Boolean true if successful, false otherwise
    */
    public Boolean AddUserGroup(string groupCode, string description, string createdBy, string accessRights)
    {
        if (_DAL.AddUserGroup(groupCode, description, createdBy, accessRights) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Edits the user group that matches the code with the given description
    * 
    * @since version 1.0 
    * @param string groupCode - unique code to identify the user group entry
    * @param string description - name or description of the entry
    * @param string updatedBy - user ID of the one who updated the group
    * @param string accessRights - determines the accessible content
    * @return Boolean true if successful, false otherwise
    */
    public Boolean EditUserGroup(string groupCode, string description, string updatedBy, string accessRights)
    {
        if (_DAL.EditUserGroup(groupCode, description, updatedBy, accessRights) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Deletes the user group that matches the given code
    * 
    * @since version 1.0 
    * @param string groupCode - unique code to identify the user group entry
    * @return Boolean true if successful, false otherwise
    */
    public Boolean DeleteUserGroup(string groupCode)
    {
        if (_DAL.DeleteUserGroup(groupCode) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Filters the data table of user groups that match the filter string
    * 
    * @since version 1.0 
    * @param GridView pObj - grid view where the data table will be binded to
    * @param string code - code to search
    * @param string description - description to search
    * @param string userGroup - code of the user group of the current user
    * @return Boolean true if successful, false otherwise
    */
    public Boolean FilterUserGroup(GridView pObj, string code, string description, string userGroup)
    {
        DataTable dt = _DAL.FilterUserGroup(code, description, userGroup);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    /**
    * Assigns the values of the row that matches the search string to the corresponding fields of the Maintenance Class
    * 
    * @since version 1.0 
    * @param string value - unique code identifier
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetUserGroup(string value)
    {
        DataTable dt = _DAL.GetUserGroup(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.code = Convert.ToString(dt.Rows[0]["code"]);
            Maintenance.description = Convert.ToString(dt.Rows[0]["description"]);
            Maintenance.access_rights = Convert.ToString(dt.Rows[0]["access_rights"]);
            Maintenance.user_list = Convert.ToString(dt.Rows[0]["user_list"]);

            return true;
        }
    }

    /**
    * Gets the list of entries in the database and binds it to a dropdown
    * 
    * @since version 1.0 
    * @param DropDownList dd - dropdown where the list will be binded
    * @param item - determines the default dropdown item to be added
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetUserGroupDropDown(DropDownList dd, string item)
    {
        try
        {
            DataTable dt = _DAL.FilterUserGroup("", "", "");
            dd.DataSource = dt;
            dd.DataValueField = "code";
            dd.DataTextField = "description";
            dd.DataBind();
            dd.Items.Insert(0, new ListItem(item, "0"));
            return true;
        }
        catch
        {
            return false;
        }
    }

    /**
    * Gets the list of entries in the database and binds it to a dropdown
    * 
    * @since version 1.0 
    * @param DropDownList dd - dropdown where the list will be binded
    * @param item - determines the default dropdown item to be added
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetUserGroupListBox(ListBox box)
    {
        try
        {
            DataTable dt = _DAL.FilterUserGroup("", "", "");
            box.DataSource = dt;
            box.DataValueField = "code";
            box.DataTextField = "description";
            box.DataBind();
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion

    /*****OTHER FUNCTIONS*****/

    #region Active Session
    /**
    * Adds a session to the database
    * 
    * @since version 1.0 
    * @param string sessionId - unique identifier of the session
    * @param string userId - unique identifier of the user
    * @return Boolean true if successful
    */
    public Boolean AddActiveSession(string sessionId, string userId)
    {
        if (_DAL.AddActiveSession(sessionId, userId) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Deletes the active sessions of the given user in the database
    * 
    * @since version 1.0 
    * @param string userId - unique identifier of the user
    * @return Boolean true if successful
    */
    public Boolean DeleteActiveSessionByUserId(string userId)
    {
        if (_DAL.DeleteActiveSessionByUserId(userId) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Deletes the active session with the given session ID in the database
    * 
    * @since version 1.0 
    * @param string sessionId - unique identifier of the session
    * @return Boolean true if successful
    */
    public Boolean DeleteActiveSessionBySessionId(string sessionId)
    {
        if (_DAL.DeleteActiveSessionBySessionId(sessionId) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Selects the active sessions in the database with the given filters
    * 
    * @since version 1.0 
    * @param GridView pObj - grid view where the data table will be binded to
    * @param string sessionId - unique identifier of the session
    * @param string userId - unique identifier of the user
    * @return Boolean true if successful
    */
    public Boolean FilterActiveSession(GridView pObj, string sessionId, string userId)
    {
        DataTable dt = _DAL.FilterActiveSession(sessionId, userId);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();
            return true;
        }
    }

    /**
    * Selects the active session in the database that matches the given values
    * 
    * @since version 1.0 
    * @param string sessionId - unique identifier of the session
    * @param string userId - unique identifier of the user
    * @return Boolean true if successful
    */
    public Boolean GetActiveSession(string sessionId, string userId)
    {
        DataTable dt = _DAL.GetActiveSession(sessionId, userId);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.session_id = Convert.ToString(dt.Rows[0]["session_id"]);
            Maintenance.user_id = Convert.ToString(dt.Rows[0]["user_id"]);

            return true;
        }
    }

    /**
    * Checks if the given user ID has an active session in the database
    * 
    * @since version 1.0 
    * @param string userId - unique identifier of the user
    * @return Boolean true if successful
    */
    public Boolean CheckActiveSession(string userId)
    {
        if (_DAL.CheckActiveSession(userId).Rows.Count < 1)
        {
            return false;
        }
        else return true;
    }
    #endregion

    #region Append deleted item
    /**
    * Appends a deleted entry to the dropdown
    * 
    * @since version 1.0 
    * @param DropDownList dd - dropdown where the list will be binded
    * @param string maintenanceType - code of the maintenance data
    * @param string code - code of the deleted item
    * @return Boolean true if successful, false otherwise
    */
    public Boolean AppendDeletedItem(DropDownList dd, string maintenanceType, string code)
    {
        try
        {
            DataTable dt = new DataTable();

            if (maintenanceType == "3")
            {
                dt = _DAL.GetDepartment(code);
            }
            else if (maintenanceType == "4")
            {
                dt = _DAL.GetUserGroup(code);
            }
            else if (maintenanceType == "7")
            {
                dt = _DAL.GetBranch(code);
            }
            else if (maintenanceType == "8")
            {
                dt = _DAL.GetDivision(code);
            }

            dd.Items.Add(new ListItem(Convert.ToString(dt.Rows[0]["description"]) + " (Deleted)", Convert.ToString(dt.Rows[0]["code"])));
            dt.Dispose();

            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region Cache
    public void RemoveFromCache(string cacheKey)
    {
        if (HttpContext.Current != null)
        {
            List<string> itemsToRemove = new List<string>();
            IDictionaryEnumerator enumerator = HttpContext.Current.Cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().ToLower().StartsWith(cacheKey.ToLower()))
                {
                    itemsToRemove.Add(enumerator.Key.ToString());
                }
            }

            foreach (string itemToRemove in itemsToRemove)
            {
                HttpContext.Current.Cache.Remove(itemToRemove);
            }
        }
    }

    #endregion

    #region Email Notification
    /**
    * Sends an email notification with the given values
    * 
    * @since version 1.0 
    * @param string userId - ID of the user
    * @param string actionMessage - action done to the user account
    * @return Boolean true if successful, false otherwise
    */
    public Boolean SendEmailNotificationUser(string userId, string actionMessage)
    {
        if (_DAL.SendEmailNotificationUser(userId, actionMessage) == false)
        {
            return false;
        }
        else return true;
    }

    #endregion

    #region Logging
    /**
    * Adds an entry to the access log table
    * 
    * @since version 1.0 
    * @param string code - code of the content that the user was accessing
    * @param string userId - ID of the user
    * @param string status - determines if the access was successful or not
    * @param string terminalId - IP address of the workstation
    * @return Boolean true if successful, false otherwise
    */
    public Boolean AddAccessLogEntry(string code, string userId, string status, string terminalId)
    {
        if (_DAL.AddAccessLogEntry(code, userId, status, terminalId) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Adds an entry to the audit log table
    * 
    * @since version 1.0 
    * @param string userId - ID of the user
    * @param string content - content section where the action took place
    * @param string function - function that was done
    * @param string details - other details of the log
    * @param string terminalId - IP address of the workstation
    * @return Boolean true if successful, false otherwise
    */
    public Boolean AddAuditLogEntry(string userId, string content, string function, string details, string terminalId)
    {
        DataTable dt = _DAL.AddAuditLogEntry(userId, content, function, details, terminalId);

        if (dt != null && dt.Rows.Count > 0)
        {
            Maintenance.sequence_number = Convert.ToString(dt.Rows[0]["sequence_number"]);

            return true;
        }
        else
        {
            return false;
        }
    }

    /**
    * Selects the highest sequence number in the database
    * 
    * @since version 1.0 
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetSequenceNumber()
    {
        DataTable dt = _DAL.GetSequenceNumber();

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.sequence_number = Convert.ToString(dt.Rows[0]["sequence_number"]);

            return true;
        }
    }

    /**
    * Returns the server time
    * 
    * @since version 1.0 
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetServerTime()
    {
        DataTable dt = _DAL.GetServerTime();

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.server_time = (DateTime)dt.Rows[0]["server_time"];

            return true;
        }
    }

    /**
    * Returns the data table of activity logs that match the filter string
    * 
    * @since version 1.0 
    * @param GridView pObj - grid view where the data table will be binded to
    * @param string userId - user ID to be filtered in the activity log table
    * @return Boolean true if successful, false otherwise
    */
    public Boolean FilterRecentActivity(GridView pObj, string userId)
    {
        DataTable dt = _DAL.FilterRecentActivity(userId);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    /**
    * Adds an entry to the exception log table
    * 
    * @since version 1.0 
    * @param Exception ex - exception encountered
    * @return Boolean true if successful, false otherwise
    */
    public Boolean AddExceptionLogEntry(Exception ex)
    {
        if (_DAL.AddExceptionLogEntry(ex) == false)
        {
            return false;
        }
        else return true;
    }

    #endregion

    #region Password
    /**
    * Changes the password of the user with the given employee number
    * 
    * @since version 1.0 
    * @param string userId - unique identifier of the user
    * @param string password - the new password
    * @return Boolean true if successful
    */
    public Boolean ChangePassword(string userId, string password)
    {
        if (_DAL.ChangePassword(userId, password) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Resets the password of the user with the given employee number
    * 
    * @since version 1.0 
    * @param string userId - unique identifier of the user
    * @return Boolean true if successful
    */
    public Boolean ResetPassword(string userId)
    {
        if (_DAL.ResetPassword(userId) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Sets the remaining password attempts of the user with the given user ID before their account is locked
    * 
    * @since version 1.0 
    * @param string userId - unique identifier of the user
    * @param int attempts - the number of remaining attempts
    * @return Boolean true if successful
    */
    public Boolean SetPasswordAttempts(string userId, int attempts)
    {
        if (_DAL.SetPasswordAttempts(userId, attempts) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Sets the cumulative invalid password attempts of the user with the given ID
    * 
    * @since version 1.0 
    * @param string userId - unique identifier of the user
    * @param int invalidAttempts - the number of invalid password attempts
    * @return Boolean true if successful
    */
    public Boolean SetCumulativeInvalidPasswordAttempts(string userId, int invalidAttempts)
    {
        if (_DAL.SetCumulativeInvalidPasswordAttempts(userId, invalidAttempts) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Sets the default password attempts for all users to the given value in the security parameters
    * 
    * @since version 1.0 
    * @return Boolean true if successful
    */
    public Boolean SetDefaultPasswordAttempts()
    {
        if (_DAL.SetDefaultPasswordAttempts() == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Adds an entry to the password history table
    * 
    * @since version 1.0 
    * @param string userId - ID of the user
    * @param string password - password of the user
    * @return Boolean true if successful, false otherwise
    */
    public Boolean AddPasswordHistory(string userId, string password)
    {
        if (_DAL.AddPasswordHistory(userId, password) == false)
        {
            return false;
        }
        else return true;
    }

    /**
    * Returns the data table row that matches the given values
    * 
    * @since version 1.0 
    * @param string userId - ID of the user
    * @param string password - password to be checked
    * @return Boolean true if password is restricted, false otherwise
    */
    public Boolean CheckIfPasswordHistoryRestricted(string userId, string password)
    {
        if (GetSecurityParameters() == false)
        {
            return false;
        }
        else
        {
            DataTable dt = _DAL.FilterPasswordHistory(userId, Convert.ToInt16(Maintenance.max_restricted_recent_passwords));

            if (dt == null || dt.Rows.Count < 1)
            {
                return false;
            }
            else
            {
                DataRow[] foundRows = dt.Select("password = '" + password + "'");
                if (foundRows.Length != 0)
                {
                    return true;
                }
                else return false;
            }
        }
    }

    #endregion

    #region Reports

    /**
    * Gets the list of entries in the database and binds it to a dropdown
    * 
    * @since version 1.0 
    * @param DropDownList dd - dropdown where the list will be binded
    * @param string reports - determines which reports are included
    * @return Boolean true if successful, false otherwise
    */
    public Boolean GetReportsDropDown(DropDownList dd, string reports)
    {
        try
        {
            DataTable dt = _DAL.FilterReports(reports);
            dd.DataSource = dt;
            dd.DataValueField = "code";
            dd.DataTextField = "description";
            dd.DataBind();
            dd.Items.Insert(0, new ListItem("--Select--", "0"));
            return true;
        }
        catch
        {
            return false;
        }
    }

    /**
    * Gets the report that matches the given filters
    * 
    * @since version 1.0 
    * @return boolean true if successful, false otherwise
    */
    public Boolean GetReportUserGroupAccessMatrix(GridView pObj, string userGroupList)
    {
        DataTable dt = _DAL.GetReportUserGroupAccessMatrix(userGroupList);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();

            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    #endregion

    #region UPCI

    #region Member
    public Boolean AddMember(string firstName, string middleName, string lastName, string gender, string birthdate, string email, string mobileNumber, string ministry, string ministryDepartment
        , string dateFirstAttend, string cell, string baptismal, string pepsol, string membershipStatus, string createdBy)
    {
        if (_DAL.AddMember(firstName, middleName, lastName, gender, birthdate, email, mobileNumber, ministry, ministryDepartment, dateFirstAttend, cell, baptismal, pepsol, membershipStatus, createdBy) == false)
        {
            return false;
        }
        else return true;
    }
    public Boolean EditMember(string memberId, string firstName, string middleName, string lastName, string gender, string birthdate, string email, string mobileNumber, string ministry, string ministryDepartment
        , string dateFirstAttend, string cell, string baptismal, string pepsol, string membershipStatus)
    {
        if (_DAL.EditMember(memberId, firstName, middleName, lastName, gender, birthdate, email, mobileNumber, ministry, ministryDepartment, dateFirstAttend, cell, baptismal, pepsol, membershipStatus) == false)
        {
            return false;
        }
        else return true;
    }
    /**
    * Filters the data table of users that match the filter string
    * 
    * @since version 1.0 
    * @param GridView pObj - grid view where the data table will be binded to
    * @param string code - code to search
    * @param string description - description to search
    * @param string userId - user ID of the current user
    * @return Boolean true if successful, false otherwise
    */
    public Boolean FilterMembers(GridView pObj, string name)
    {
        DataTable dt = _DAL.FilterMember(name);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    public Boolean GetMemberDeatils(string value)
    {
        DataTable dt = _DAL.GetMemberDetails(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Member.member_id = Convert.ToString(dt.Rows[0]["Member ID"]);
            Member.first_name = Convert.ToString(dt.Rows[0]["first_name"]);
            Member.middle_name = Convert.ToString(dt.Rows[0]["middle_name"]);
            Member.last_name = Convert.ToString(dt.Rows[0]["last_name"]);
            Member.email = Convert.ToString(dt.Rows[0]["Email"]);
            Member.gender = Convert.ToString(dt.Rows[0]["gender_desc"]);
            Member.birthday = Convert.ToString(dt.Rows[0]["Birthday"]);
            Member.mobile_number = Convert.ToString(dt.Rows[0]["Mobile Number"]);

            Member.ministry = Convert.ToString(dt.Rows[0]["ministry_desc"]);
            Member.ministry_department = Convert.ToString(dt.Rows[0]["ministry_dept"]);
            Member.cell_status = Convert.ToString(dt.Rows[0]["cell_desc"]);
            Member.baptismal_status = Convert.ToString(dt.Rows[0]["baptismal_desc"]);
            Member.pepsol_level = Convert.ToString(dt.Rows[0]["pepsol_desc"]);
            Member.membership_status = Convert.ToString(dt.Rows[0]["status_desc"]);

            Member.gender_code = Convert.ToString(dt.Rows[0]["gender"]);
            Member.ministry_code = Convert.ToString(dt.Rows[0]["ministry"]);
            Member.ministry_dept_code = Convert.ToString(dt.Rows[0]["ministry_department"]);
            Member.cell_status_code = Convert.ToString(dt.Rows[0]["cell"]);
            Member.baptismal_status_code = Convert.ToString(dt.Rows[0]["baptismal"]);
            Member.pepsol_level_code = Convert.ToString(dt.Rows[0]["pepsol"]);
            Member.membership_status_code = Convert.ToString(dt.Rows[0]["membership_status"]);
            return true;
        }
    }
    #endregion

    #region Ministry Department
    public Boolean AddMinistryDepartment(string code, string ministryCode, string description, string createdBy)
    {
        if (_DAL.AddMinistryDepartment(code, ministryCode, description, createdBy) == false)
        {
            return false;
        }
        else return true;
    }

    public Boolean EditMinistryDepartment(string code, string description, string ministryCode)
    {
        if (_DAL.EditMinistryDepartment(code, description, ministryCode) == false)
        {
            return false;
        }
        else return true;
    }

    public Boolean DeleteMinistryDepartment(string code)
    {
        if (_DAL.DeleteMinistryDepartment(code) == false)
        {
            return false;
        }
        else return true;
    }
    public Boolean FilterMinistryDepartment(GridView pObj, string code, string description)
    {
        DataTable dt = _DAL.FilterMinistryDepartment(code, description);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    public Boolean GetMinistryDepartmentDetails(string value)
    {
        DataTable dt = _DAL.GetMinistryDepartmentDetails(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.code = Convert.ToString(dt.Rows[0]["code"]);
            Maintenance.description = Convert.ToString(dt.Rows[0]["description"]);
            Maintenance.ministry_description = Convert.ToString(dt.Rows[0]["ministry_desc"]);
            Maintenance.ministry_code = Convert.ToString(dt.Rows[0]["ministry_code"]);

            return true;
        }
    }

    #endregion

    #region Ministry
    public Boolean DeleteMinistry(string code)
    {
        if (_DAL.DeleteMinistry(code) == false)
        {
            return false;
        }
        else return true;
    }
    public Boolean EditMinistry(string code, string description)
    {
        if (_DAL.EditMinistry(code, description) == false)
        {
            return false;
        }
        else return true;
    }
    public Boolean AddMinistry(string code, string description, string createdBy)
    {
        if (_DAL.AddMinistry(code, description, createdBy) == false)
        {
            return false;
        }
        else return true;
    }

    public Boolean FilterMinistry(GridView pObj, string code, string description)
    {
        DataTable dt = _DAL.FilterMinistry(code, description);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    public Boolean GetMinistryDetails(string value)
    {
        DataTable dt = _DAL.GetMinistryDetails(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.code = Convert.ToString(dt.Rows[0]["code"]);
            Maintenance.description = Convert.ToString(dt.Rows[0]["description"]);

            return true;
        }
    }
    #endregion

    #region Pepsol
    public Boolean AddPepsol(string code, string description, string createdBy)
    {
        if (_DAL.AddPepsol(code, description, createdBy) == false)
        {
            return false;
        }
        else return true;
    }

    public Boolean EditPepsol(string code, string description)
    {
        if (_DAL.EditPepsol(code, description) == false)
        {
            return false;
        }
        else return true;
    }

    public Boolean DeletePepsol(string code)
    {
        if (_DAL.DeletePepsol(code) == false)
        {
            return false;
        }
        else return true;
    }
    public Boolean FilterPepsol(GridView pObj, string code, string description)
    {
        DataTable dt = _DAL.FilterPepsol(code, description);

        if (dt == null || dt.Rows.Count < 1)
        {
            pObj.DataSource = null;
            pObj.DataBind();
            return false;
        }
        else
        {
            pObj.DataSource = dt;
            pObj.DataBind();

            return true;
        }
    }

    public Boolean GetPepsolDetails(string value)
    {
        DataTable dt = _DAL.GetPepsolDetails(value);

        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }
        else
        {
            Maintenance.code = Convert.ToString(dt.Rows[0]["code"]);
            Maintenance.description = Convert.ToString(dt.Rows[0]["description"]);

            return true;
        }
    }

    #endregion

    #region Dropdowns
    public Boolean GetMinistryDropdown(DropDownList dd, string item)
    {
        try
        {
            DataTable dt = _DAL.GetMinistryDropdown();
            dd.DataSource = dt;
            dd.DataValueField = "code";
            dd.DataTextField = "description";
            dd.DataBind();
            dd.Items.Insert(0, new ListItem(item, "0"));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Boolean GetMinistryDepartmentDropdown(DropDownList dd, string item, string ministryCode)
    {
        try
        {
            DataTable dt = _DAL.GetMinistryDepartmentDropdown(ministryCode);
            dd.DataSource = dt;
            dd.DataValueField = "code";
            dd.DataTextField = "description";
            dd.DataBind();
            dd.Items.Insert(0, new ListItem(item, "0"));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Boolean GetPepsolDropdown(DropDownList dd, string item)
    {
        try
        {
            DataTable dt = _DAL.GetPepsolDropdown();
            dd.DataSource = dt;
            dd.DataValueField = "code";
            dd.DataTextField = "description";
            dd.DataBind();
            dd.Items.Insert(0, new ListItem(item, "0"));
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #endregion

}