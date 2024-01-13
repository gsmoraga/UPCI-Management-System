public class VG
{
    /** 
     * Global Variables
     */

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



    /** Content Codes **/
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

    public static string c_department
    {
        get { return "3"; }
        set { c_department = value; }
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

    public static string c_division
    {
        get { return "8"; }
        set { c_division = value; }
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

    //survey




    /** Access Rights **/
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

    public static string ar_department
    {
        get { return "&m3,"; }
        set { ar_department = value; }
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

    public static string ar_division
    {
        get { return "&m8,"; }
        set { ar_division = value; }
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



    /** Access Log Codes **/
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



    /** User Status Codes **/
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
        get { return "EPS"; }
        set { application_name = value; }
    }

    public static int max_file_size_in_bytes
    {
        get { return 10485760; }
        set { max_file_size_in_bytes = value; }
    }
    //Survey Form
    #region Survey

    #region Access Rights
    public static string ar_civil_status
    {
        get { return "&m10,"; }
        set { ar_civil_status = value; }
    }

    public static string ar_educational_attainment
    {
        get { return "&m11,"; }
        set { ar_educational_attainment = value; }
    }

    public static string ar_region
    {
        get { return "&m12,"; }
        set { ar_region = value; }
    }

    public static string ar_age_group
    {
        get { return "&m13,"; }
        set { ar_age_group = value; }
    }

    public static string ar_services
    {
        get { return "&m14,"; }
        set { ar_services = value; }
    }

    public static string ar_working_status
    {
        get { return "&m15,"; }
        set { ar_working_status = value; }
    }
    public static string ar_branch_services
    {
        get { return "&m16,"; }
        set { ar_branch_services = value; }
    }
    public static string ar_survey_report_per_branch
    {
        get { return "&r106g,"; }
        set { ar_survey_report_per_branch = value; }
    }

    public static string ar_survey_report_nationwide
    {
        get { return "&r107g,"; }
        set { ar_survey_report_nationwide = value; }
    }
    public static string ar_survey_report_transactions
    {
        get { return "&r108g,"; }
        set { ar_survey_report_transactions = value; }
    }

    public static string ar_survey_report_per_customer
    {
        get { return "&r109g,"; }
        set { ar_survey_report_per_customer = value; }
    }
    #endregion

    #region Contents
    //content codes
    public static string c_civil_status
    {
        get { return "10"; }
        set { c_civil_status = value; }
    }

    public static string c_educational_attainment
    {
        get { return "11"; }
        set { c_educational_attainment = value; }
    }

    public static string c_region
    {
        get { return "12"; }
        set { c_region = value; }
    }

    public static string c_age_group
    {
        get { return "13"; }
        set { c_age_group = value; }
    }

    public static string c_services
    {
        get { return "14"; }
        set { c_services = value; }
    }

    public static string c_working_status
    {
        get { return "15"; }
        set { c_working_status = value; }
    }

    public static string c_branch_services
    {
        get { return "16"; }
        set { c_branch_services = value; }
    }
    #endregion

    #endregion


    /*
     * * Content Codes
     */
    public static string c_purchase_request
    {
        get { return "1000"; }
        set { c_purchase_request = value; }
    }

    public static string c_quotation_request
    {
        get { return "2000"; }
        set { c_quotation_request = value; }
    }


    /*
     * Transaction Status
     * */
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

    /*
     * Workflow Status
     */
    public static string ws_submitted_by_requesting_officer
    {
        get { return "100"; }
        set { ws_submitted_by_requesting_officer = value; }
    }

    public static string ws_recommend_by_budget_custodian
    {
        get { return "200"; }
        set { ws_recommend_by_budget_custodian = value; }
    }
    public static string ws_returned_by_budget_custodian
    {
        get { return "201"; }
        set { ws_returned_by_budget_custodian = value; }
    }

    public static string ws_approved_by_division_head
    {
        get { return "300"; }
        set { ws_approved_by_division_head = value; }
    }
    public static string ws_returned_by_division_head
    {
        get { return "301"; }
        set { ws_returned_by_division_head = value; }
    }
    public static string ws_declined_by_division_head
    {
        get { return "302"; }
        set { ws_declined_by_division_head = value; }
    }

    public static string ws_recommended_by_procurement_department
    {
        get { return "400"; }
        set { ws_recommended_by_procurement_department = value; }
    }

    public static string ws_returned_by_procurement_department
    {
        get { return "401"; }
        set { ws_returned_by_procurement_department = value; }
    }

    public static string ws_declined_by_procurement_department
    {
        get { return "402"; }
        set { ws_declined_by_procurement_department = value; }
    }

    public static string ws_submitted_to_bac
    {
        get { return "403"; }
        set { ws_submitted_to_bac = value; }
    }

    public static string ws_approved_by_hope
    {
        get { return "500"; }
        set { ws_approved_by_hope = value; }
    }

    public static string ws_returned_by_hope
    {
        get { return "501"; }
        set { ws_returned_by_hope = value; }
    }

    public static string ws_declined_by_hope
    {
        get { return "502"; }
        set { ws_declined_by_hope = value; }
    }

    public static string ws_approved_by_bac
    {
        get { return "600"; }
        set { ws_approved_by_bac = value; }
    }

    public static string ws_returned_by_bac
    {
        get { return "601"; }
        set { ws_returned_by_bac = value; }
    }

    public static string ws_declined_by_bac
    {
        get { return "602"; }
        set { ws_declined_by_bac = value; }
    }
    /*
     * Access Rights 
     */


    #region Access Rights
    public static string ar_req_officer
    {
        get { return "&fRO,"; }
        set { ar_req_officer = value; }
    }

    public static string ar_budg_cust
    {
        get { return "&fdBcus,"; }
        set { ar_budg_cust = value; }
    }

    public static string ar_budg_cust_recommend
    {
        get { return "&fdBcusRec,"; }
        set { ar_budg_cust_recommend = value; }
    }

    public static string ar_budg_cust_return
    {
        get { return "&fBcusRet,"; }
        set { ar_budg_cust_return = value; }
    }


    public static string ar_div_head
    {
        get { return "&fdivHead,"; }
        set { ar_div_head = value; }
    }
    public static string ar_div_head_approve
    {
        get { return "&fdHeadApp,"; }
        set { ar_div_head_approve = value; }
    }

    public static string ar_div_head_return
    {
        get { return "&fdHeadRet,"; }
        set { ar_div_head_return = value; }
    }
    public static string ar_div_head_decline
    {
        get { return "&fdHeadDec,"; }
        set { ar_div_head_decline = value; }
    }
    public static string ar_proc_dept
    {
        get { return "&fProcDep,"; }
        set { ar_proc_dept = value; }
    }

    public static string ar_proc_dept_recommend
    {
        get { return "&fProcDepApp,"; }
        set { ar_proc_dept_recommend = value; }
    }
    public static string ar_proc_dept_return
    {
        get { return "&fProcDepRet,"; }
        set { ar_proc_dept_return = value; }
    }

    public static string ar_proc_dept_decline
    {
        get { return "&fProcDepDec,"; }
        set { ar_proc_dept_decline = value; }
    }
    public static string ar_hope
    {
        get { return "&fHope,"; }
        set { ar_hope = value; }
    }

    public static string ar_bac
    {
        get { return "&fBAC,"; }
        set { ar_bac = value; }
    }

    public static string ar_bac_approve
    {
        get { return "&fBacApp,"; }
        set { ar_bac_approve = value; }
    }
    #endregion


}