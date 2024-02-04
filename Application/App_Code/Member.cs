using System;
using System.Web;


public class Member
{
    public static string member_id
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberId"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberId"] = value;
        }
    }

    public static string first_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberFirstName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberFirstName"] = value;
        }
    }
    public static string middle_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberMiddleName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberMiddleName"] = value;
        }
    }
    public static string last_name
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberLastName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberLastName"] = value;
        }
    }

    public static string gender
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberGender"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberGender"] = value;
        }
    }

    public static string gender_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberGenderCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberGenderCode"] = value;
        }
    }
    public static string birthday
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberBirthday"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberBirthday"] = value;
        }
    }

    public static string email
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberEmail"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberEmail"] = value;
        }
    }

    public static string mobile_number
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberNumber"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberNumber"] = value;
        }
    }

    public static string ministry
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberMinistry"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberMinistry"] = value;
        }
    }
    public static string ministry_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberMinistryCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberMinistryCode"] = value;
        }
    }


    public static string ministry_department
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberMinistryDepartment"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberMinistryDepartment"] = value;
        }
    }

    public static string ministry_dept_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberMinistryDepartmentCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberMinistryDepartmentCode"] = value;
        }
    }

    public static string date_first_attend
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberDateFirstAttend"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberDateFirstAttend"] = value;
        }
    }

    public static string membership_status
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberMembershipStatus"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberMembershipStatus"] = value;
        }
    }

    public static string membership_status_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberMembershipStatusCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberMembershipStatusCode"] = value;
        }
    }

    public static string cell_status
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberCellStatus"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberCellStatus"] = value;
        }
    }

    public static string cell_status_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberCellStatusCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberCellStatusCode"] = value;
        }
    }

    public static string baptismal_status
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberBaptismalStatus"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberBaptismalStatus"] = value;
        }
    }

    public static string baptismal_status_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberBaptismalStatusCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberBaptismalStatusCode"] = value;
        }
    }
    public static string pepsol_level
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberPepsolLevel"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberPepsolLevel"] = value;
        }
    }

    public static string pepsol_level_code
    {
        get
        {
            if (HttpContext.Current.Session != null)
                return Convert.ToString(HttpContext.Current.Session["MemberPepsolLevelCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["MemberPepsolLevelCode"] = value;
        }
    }
}
