using System;
using System.Web;

public class Employee
{
    public static Boolean warn_profile_expiration
    {
        get
        {
            if (HttpContext.Current.Session["WarnProfileExpiration"] != null)
                return Convert.ToBoolean(HttpContext.Current.Session["WarnProfileExpiration"]);
            else return false;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["WarnProfileExpiration"] = value;
        }
    }
    public static Boolean warn_password_expiration
    {
        get
        {
            if (HttpContext.Current.Session["WarnPasswordExpiration"] != null)
                return Convert.ToBoolean(HttpContext.Current.Session["WarnPasswordExpiration"]);
            else return false;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["WarnPasswordExpiration"] = value;
        }
    }
    public static string member_number
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeNumber"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeNumber"] = value;
        }
    }
    public static string user_id
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeUserID"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeUserID"] = value;
        }
    }
    public static string first_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeFirstName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeFirstName"] = value;
        }
    }
    public static string middle_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeMiddleName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeMiddleName"] = value;
        }
    }
    public static string last_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeLastName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeLastName"] = value;
        }
    }
    public static string user_group
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeUserGroup"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeUserGroup"] = value;
        }
    }
    public static string user_group_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeUserGroupName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeUserGroupName"] = value;
        }
    }
    public static string access_rights
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeAccessRights"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeAccessRights"] = value;
        }
    }
    public static string department
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeDepartment"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeDepartment"] = value;
        }
    }
    public static string branch
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeBranch"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeBranch"] = value;
        }
    }
    public static DateTime profile_expiration_date
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToDateTime(HttpContext.Current.Session["EmployeeProfileExpirationDate"]);
            else return Convert.ToDateTime("1900-01-01");
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeProfileExpirationDate"] = value;
        }
    }
    public static string email
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeEmail"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeEmail"] = value;
        }
    }
    public static string mobile_number
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeMobileNumber"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeMobileNumber"] = value;
        }
    }
    public static string password
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeePassword"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeePassword"] = value;
        }
    }
    public static int remaining_password_attempts
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToInt32(HttpContext.Current.Session["EmployeeRemainingPasswordAttempts"]);
            else return 0;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeRemainingPasswordAttempts"] = value;
        }
    }
    public static int cumulative_invalid_password_attempts
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToInt32(HttpContext.Current.Session["EmployeeCumulativeInvalidPasswordAttempts"]);
            else return 0;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeCumulativeInvalidPasswordAttempts"] = value;
        }
    }
    public static string using_default_password
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeUsingDefaultPassword"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeUsingDefaultPassword"] = value;
        }
    }
    public static DateTime password_expiration_date
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToDateTime(HttpContext.Current.Session["EmployeePasswordExpirationDate"]);
            else return Convert.ToDateTime("1900-01-01");
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeePasswordExpirationDate"] = value;
        }
    }
    public static string status
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeStatus"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeStatus"] = value;
        }
    }
    public static string created_by
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeCreatedBy"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeCreatedBy"] = value;
        }
    }
    public static string date_created
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeDateCreated"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeDateCreated"] = value;
        }
    }
    public static DateTime last_login_date
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToDateTime(HttpContext.Current.Session["EmployeeLastLoginDate"]);
            else return Convert.ToDateTime("1900-01-01");
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeLastLoginDate"] = value;
        }
    }
    public static DateTime last_login_attempt_date
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToDateTime(HttpContext.Current.Session["EmployeeLastLoginAttemptDate"]);
            else return Convert.ToDateTime("1900-01-01");
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeLastLoginAttemptDate"] = value;
        }
    }
    public static string last_login_attempt_status
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["EmployeeLastLoginAttemptStatus"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["EmployeeLastLoginAttemptStatus"] = value;
        }
    }

    public static int page_index
    {
        get
        {
            if (HttpContext.Current.Session["ClicksPageIndex"] != null)
                return Convert.ToInt32(HttpContext.Current.Session["ClicksPageIndex"]);
            else return 0;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["ClicksPageIndex"] = value;
        }
    }

}