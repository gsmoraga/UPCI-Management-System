using System;
using System.Web;

public class Maintenance
{
    /**/
    public static Boolean first_login
    {
        get
        {
            if (HttpContext.Current.Session["MaintenanceFirstLogin"] != null)
                return Convert.ToBoolean(HttpContext.Current.Session["MaintenanceFirstLogin"]);
            else return false;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceFirstLogin"] = value;
        }
    }
    public static Boolean bank_user_security
    {
        get
        {
            if (HttpContext.Current.Session["BankUserSecurity"] != null)
                return Convert.ToBoolean(HttpContext.Current.Session["BankUserSecurity"]);
            else return false;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["BankUserSecurity"] = value;
        }
    }
    public static string bank_user_security_mode
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["BankUserSecurityMode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["BankUserSecurityMode"] = value;
        }
    }
    public static string mode
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceMode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceMode"] = value;
        }
    }
    public static string entry_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EntryCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EntryCode"] = value;
        }
    }

    public static string code_filter
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceCodeFilter"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceCodeFilter"] = value;
        }
    }
    public static string description_filter
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceDescriptionFilter"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceDescriptionFilter"] = value;
        }
    }
    public static int page_index
    {
        get
        {
            if (HttpContext.Current.Session["MaintenancePageIndex"] != null)
                return Convert.ToInt32(HttpContext.Current.Session["MaintenancePageIndex"]);
            else return 0;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenancePageIndex"] = value;
        }
    }
    public static Boolean back
    {
        get
        {
            if (HttpContext.Current.Session["MaintenanceBack"] != null)
                return Convert.ToBoolean(HttpContext.Current.Session["MaintenanceBack"]);
            else return false;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceBack"] = value;
        }
    }

    /*Maintenance tables*/
    public static string code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceCode"] = value;
        }
    }
    public static string description
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceDescription"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceDescription"] = value;
        }
    }
    public static string group_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceGroupCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceGroupCode"] = value;
        }
    }
    public static string ministry_description
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceMinistryDesc"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceMinistryDesc"] = value;
        }
    }
    public static string ministry_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceMinistryCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceMinistryCode"] = value;
        }
    }

    public static string ministry_dept_desc
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceMinistryDeptDesc"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceMinistryDeptDesc"] = value;
        }
    }
    public static string ministry_dept_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceMinistryDeptCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceMinistryDeptCode"] = value;
        }
    }
    public static string content_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["ContentCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["ContentCode"] = value;
        }
    }
    public static string content_description
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceContentDescription"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceContentDescription"] = value;
        }
    }
    public static string content_type
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceContentType"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceContentType"] = value;
        }
    }
    public static string access_rights
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceAccessRights"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceAccessRights"] = value;
        }
    }
    public static string branch_email
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["BranchEmail"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["BranchEmail"] = value;
        }
    }

    //8-15-2023
    public static string region
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["RegionCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["RegionCode"] = value;
        }
    }

    public static string region_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["RegionName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["RegionName"] = value;
        }

    }

    /*User*/
    public static string member_id
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceEmployeeNumber"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceEmployeeNumber"] = value;
        }
    }
    public static string first_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceFirstName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceFirstName"] = value;
        }
    }
    public static string middle_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceMiddleName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceMiddleName"] = value;
        }
    }
    public static string last_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceLastName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceLastName"] = value;
        }
    }
    public static string user_group
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceUserGroup"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceUserGroup"] = value;
        }
    }
    public static string user_group_desc
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceUserGroupDesc"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceUserGroupDesc"] = value;
        }
    }
    public static string department
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceDepartment"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceDepartment"] = value;
        }
    }
    public static string branch
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceBranch"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceBranch"] = value;
        }
    }
    public static DateTime profile_expiration_date
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToDateTime(HttpContext.Current.Session["MaintenanceProfileExpirationDate"]);
            else return Convert.ToDateTime("1900-01-01");
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceProfileExpirationDate"] = value;
        }
    }
    public static string email
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceEmail"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceEmail"] = value;
        }
    }
    public static string mobile_number
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceMobileNumber"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceMobileNumber"] = value;
        }
    }
    public static string status
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceStatus"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceStatus"] = value;
        }
    }

    public static string status_description
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceStatusDesc"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceStatusDesc"] = value;
        }
    }
    public static string user_list
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceUserList"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceUserList"] = value;
        }
    }

    /*Application Parameters*/
    public static string website_url
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["WebsiteUrl"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["WebsiteUrl"] = value;
        }
    }
    public static string audit_log_purge_days
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["AuditLogPurgeDays"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["AuditLogPurgeDays"] = value;
        }
    }
    public static string retention_days_success
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["RetentionDaysSuccess"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["RetentionDaysSuccess"] = value;
        }
    }
    public static string retention_days_pending
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["RetentionDaysPending"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["RetentionDaysPending"] = value;
        }
    }
    public static string bank_email_address
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["BankEmailAddress"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["BankEmailAddress"] = value;
        }
    }
    public static string bank_hotline
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["BankHotline"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["BankHotline"] = value;
        }
    }
    public static string bank_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["BankName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["BankName"] = value;
        }
    }
    public static string profile_expiration_days
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["ProfileExpirationDays"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["ProfileExpirationDays"] = value;
        }
    }
    public static string ceas_passing_score
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["CeasPassingScore"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["CeasPassingScore"] = value;
        }
    }
    public static string email_engine_sender_address
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmailEngineSenderAddress"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmailEngineSenderAddress"] = value;
        }
    }
    public static string max_allowed_mobile_devices
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaxAllowedMobileDevices"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaxAllowedMobileDevices"] = value;
        }
    }
    public static string profile_expiration_warning_days
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["ProfileExpirationWarningDays"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["ProfileExpirationWarningDays"] = value;
        }
    }
    public static string password_expiration_warning_days
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["PasswordExpirationWarningDays"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["PasswordExpirationWarningDays"] = value;
        }
    }
    public static string report_header
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["ReportHeader"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["ReportHeader"] = value;
        }
    }
    public static string allowed_special_characters_application
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["AllowedSpecialCharactersInApplication"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["AllowedSpecialCharactersInApplication"] = value;
        }
    }
    public static string restricted_username_special_characters
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["RestrictedUsernameSpecialCharacters"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["RestrictedUsernameSpecialCharacters"] = value;
        }
    }
    public static string task_summary_purge_days
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["TaskSummaryPurgeDays"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["TaskSummaryPurgeDays"] = value;
        }
    }
    public static string max_extractable_record_count
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaxExtractableRecordCount"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaxExtractableRecordCount"] = value;
        }
    }
    public static string work_hours_start_time
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["WorkHoursStartTime"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["WorkHoursStartTime"] = value;
        }
    }
    public static string work_hours_end_time
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["WorkHoursEndTime"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["WorkHoursEndTime"] = value;
        }
    }
    public static string lunch_hour_start_time
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["LunchHourStartTime"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["LunchHourStartTime"] = value;
        }
    }
    public static string lunch_hour_end_time
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["LunchHourEndTime"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["LunchHourEndTime"] = value;
        }
    }

    /*Security Parameters*/
    public static string min_password_length
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MinPasswordLength"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MinPasswordLength"] = value;
        }
    }
    public static string allowed_special_characters_password
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["AllowedSpecialCharactersInPassword"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["AllowedSpecialCharactersInPassword"] = value;
        }
    }
    public static string password_expiration_days
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["PasswordExpirationDays"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["PasswordExpirationDays"] = value;
        }
    }
    public static string max_length_repeating_characters
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaxLengthRepeatingCharacters"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaxLengthRepeatingCharacters"] = value;
        }
    }
    public static string max_length_sequential_characters
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaxLengthSequentialCharacters"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaxLengthSequentialCharacters"] = value;
        }
    }
    public static string max_cumulative_invalid_password_tries
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaxCumulativeInvalidPasswordTries"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaxCumulativeInvalidPasswordTries"] = value;
        }
    }
    public static string max_invalid_password_tries
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaxInvalidPasswordTries"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaxInvalidPasswordTries"] = value;
        }
    }
    public static string max_restricted_recent_passwords
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaxRestrictedRecentPasswords"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaxRestrictedRecentPasswords"] = value;
        }
    }
    public static string password_type
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["PasswordType"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["PasswordType"] = value;
        }
    }
    public static string mobile_activation_minutes
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MobileActivationMinutes"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MobileActivationMinutes"] = value;
        }
    }
    public static string sequence_number
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["SequenceNumber"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["SequenceNumber"] = value;
        }
    }

    /*Session*/
    public static string session_id
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MaintenanceSessionID"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MaintenanceSessionID"] = value;
        }
    }
    public static string user_id
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["SessionUserID"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["SessionUserID"] = value;
        }
    }
    public static DateTime server_time
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToDateTime(HttpContext.Current.Session["ServerTime"]);
            else return DateTime.Now;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["ServerTime"] = value;
        }
    }
}