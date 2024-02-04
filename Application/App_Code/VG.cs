public class VG
{
    /** 
     * Global Variables
     */
    #region Global Variables
    public static string action_success
    {
        get { return "1"; }
        set { action_success = value; }
    }
    public static string action_fail
    {
        get { return "0"; }
        set { action_fail = value; }
    }

    public static string usb_itsec_local
    {
        get { return "7262/7283"; }
        set { usb_itsec_local = value; }
    }

    public static string usb_itsec_email
    {
        get { return "USB-itsec@ucpbsavings.com"; }
        set { usb_itsec_email = value; }
    }
    #endregion

    /** Content Codes **/
    #region Content Codes
    public static string c_access
    {
        get { return "0"; }
        set { c_access = value; }
    }
    public static string c_security_parameters
    {
        get { return "1"; }
        set { c_security_parameters = value; }
    }

    public static string c_application_parameters
    {
        get { return "2"; }
        set { c_application_parameters = value; }
    }

    public static string c_ministry_department
    {
        get { return "3"; }
        set { c_ministry_department = value; }
    }

    public static string c_user_group
    {
        get { return "4"; }
        set { c_user_group = value; }
    }

    public static string c_user
    {
        get { return "5"; }
        set { c_user = value; }
    }

    public static string c_active_session
    {
        get { return "6"; }
        set { c_active_session = value; }
    }

    public static string c_branch
    {
        get { return "7"; }
        set { c_branch = value; }
    }

    public static string c_ministry
    {
        get { return "8"; }
        set { c_ministry = value; }
    }
    public static string c_member
    {
        get { return "9"; }
        set { c_member = value; }
    }
    public static string c_r_audit_log
    {
        get { return "101"; }
        set { c_r_audit_log = value; }
    }

    public static string c_r_password_aging
    {
        get { return "102"; }
        set { c_r_password_aging = value; }
    }

    public static string c_r_user
    {
        get { return "103"; }
        set { c_r_user = value; }
    }

    public static string c_r_user_group
    {
        get { return "104"; }
        set { c_r_user_group = value; }
    }

    public static string c_r_user_group_access_matrix
    {
        get { return "105"; }
        set { c_r_user_group_access_matrix = value; }
    }
    #endregion

    /** Access Rights **/
    #region Access Rights
    public static string ar_security_parameters
    {
        get { return "&m1e,"; }
        set { ar_security_parameters = value; }
    }

    public static string ar_application_parameters
    {
        get { return "&m2e,"; }
        set { ar_security_parameters = value; }
    }

    public static string ar_ministry_department
    {
        get { return "&m3,"; }
        set { ar_ministry_department = value; }
    }

    public static string ar_user_group
    {
        get { return "&m4,"; }
        set { ar_user_group = value; }
    }

    public static string ar_user
    {
        get { return "&m5,"; }
        set { ar_user = value; }
    }


    public static string ar_bank_user_security
    {
        get { return "&m6,"; }
        set { ar_bank_user_security = value; }
    }

    public static string ar_bank_user_security_unlock
    {
        get { return "&m6u,"; }
        set { ar_bank_user_security_unlock = value; }
    }

    public static string ar_bank_user_security_reset
    {
        get { return "&m6r,"; }
        set { ar_bank_user_security_reset = value; }
    }

    public static string ar_bank_user_security_session
    {
        get { return "&m6s,"; }
        set { ar_bank_user_security_session = value; }
    }

    public static string ar_branch
    {
        get { return "&m7,"; }
        set { ar_branch = value; }
    }

    public static string ar_ministry
    {
        get { return "&m8,"; }
        set { ar_ministry = value; }
    }

    public static string ar_member
    {
        get { return "&a9,"; }
        set { ar_member = value; }
    }

    public static string ar_r_audit_log
    {
        get { return "&r101g,"; }
        set { ar_r_audit_log = value; }
    }

    public static string ar_r_password_aging
    {
        get { return "&r102g,"; }
        set { ar_r_password_aging = value; }
    }

    public static string ar_r_user
    {
        get { return "&r103g,"; }
        set { ar_r_user = value; }
    }

    public static string ar_r_user_group
    {
        get { return "&r104g,"; }
        set { ar_r_user_group = value; }
    }

    public static string ar_r_user_group_access_matrix
    {
        get { return "&r105g,"; }
        set { ar_r_user_group_access_matrix = value; }
    }

    #endregion

    /** Access Log Codes **/
    #region Access Log Codes
    public static string access_login
    {
        get { return "1"; }
        set { access_login = value; }
    }

    public static string access_logout
    {
        get { return "2"; }
        set { access_logout = value; }
    }

    public static string access_maintenance
    {
        get { return "3"; }
        set { access_maintenance = value; }
    }

    public static string access_reports
    {
        get { return "4"; }
        set { access_reports = value; }
    }
    #endregion

    /** User Status Codes **/
    #region User Status codes
    public static string s_disabled
    {
        get { return "0"; }
        set { s_disabled = value; }
    }

    public static string s_active
    {
        get { return "1"; }
        set { s_active = value; }
    }

    public static string s_deleted
    {
        get { return "2"; }
        set { s_deleted = value; }
    }

    public static string s_expired
    {
        get { return "3"; }
        set { s_expired = value; }
    }

    public static string application_name
    {
        get { return "UPCI"; }
        set { application_name = value; }
    }

    public static int max_file_size_in_bytes
    {
        get { return 10485760; }
        set { max_file_size_in_bytes = value; }
    }
    #endregion

    /*
     * Transaction Status
     * */
    #region Transaction Status
    public static string pending
    {
        get { return "1"; }
        set { pending = value; }
    }

    public static string approved
    {
        get { return "2"; }
        set { approved = value; }
    }

    public static string declined
    {
        get { return "3"; }
        set { declined = value; }
    }
    #endregion







}