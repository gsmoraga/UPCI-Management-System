using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;


public class DAL
{
    public DAL()
    {
    }

    /*****MAINTENANCE FUNCTIONS*****/

    #region Contents
    /**
    * Returns the data table of maintenance type that match the filter string
    * 
    * @since version 1.0 
    * @param string value - search/filter string (returns all if blank)
    * @return DataTable rows that match the string
    */
    public DataTable GetContentType(string value)
    {
        string cacheKey = "GetContentType" + value;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetContentType";
                            cmd.Parameters.AddWithValue("@code", value);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache[cacheKey.ToLower()] = dt;

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    /**
    * Returns the data table of maintenance type that match the filter string
    * 
    * @since version 1.0 
    * @param string value - search/filter string (returns all if blank)
    * @param string frontOrBackEnd - determines the content type (1 - frontend, 2 - backend)
    * @return DataTable rows that match the string
    */
    public DataTable FilterContents(string value, string accessRightsParentCode)
    {
        string cacheKey = "FilterContents" + value + accessRightsParentCode;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spFilterContents";
                            cmd.Parameters.AddWithValue("@search_string", value);
                            cmd.Parameters.AddWithValue("@access_rights_parent_code", accessRightsParentCode);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache[cacheKey.ToLower()] = dt;

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
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
	* @param string bankEmailAddress - email address of the bank that will be part of the email body of transaction notifications
	* @param string bankHotline - phone numbers of the bank that will be part of the email body of transaction notifications
    * @param string bankName - name of the bank that will be part of the email body of transaction notifications
	* @param string profileExpirationDays - number of days from the current date that will appear as the default date for user Profile Expiration Date
	* @param string ceasPassingScore - passing Score for CEAS
	* @param string emailEngineSenderAddress - sender email address that will appear when receiving an email from the bank
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
    public Boolean EditApplicationParameters(string websiteUrl, string auditLogPurgeDays, string retentionDaysSuccess, string retentionDaysPending, string bankEmailAddress,
                                             string bankHotline, string bankName, string profileExpirationDays, string ceasPassingScore, string emailEngineSenderAddress,
                                             string maxAllowedMobileDevices, string profileExpirationWarningDays, string passwordExpirationWarningDays, string reportHeader,
                                             string allowedSpecialCharacters, string restrictedUsernameSpecialCharacters, string taskSummaryPurgeDays, string maxExtractableRecordCount,
                                             string workHoursStartTime, string workHoursEndTime, string lunchHourStartTime, string lunchHourEndTime)
    {
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spEditApplicationParameters";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@website_url", websiteUrl);
                    cmd.Parameters.AddWithValue("@audit_log_purge_days", auditLogPurgeDays);
                    cmd.Parameters.AddWithValue("@retention_days_success", retentionDaysSuccess);
                    cmd.Parameters.AddWithValue("@retention_days_pending", retentionDaysPending);
                    cmd.Parameters.AddWithValue("@bank_email_address", bankEmailAddress);
                    cmd.Parameters.AddWithValue("@bank_hotline", bankHotline);
                    cmd.Parameters.AddWithValue("@bank_name", bankName);
                    cmd.Parameters.AddWithValue("@profile_expiration_days", profileExpirationDays);
                    cmd.Parameters.AddWithValue("@ceas_passing_score", ceasPassingScore);
                    cmd.Parameters.AddWithValue("@email_engine_sender_address", emailEngineSenderAddress);
                    cmd.Parameters.AddWithValue("@max_allowed_mobile_devices", maxAllowedMobileDevices);
                    cmd.Parameters.AddWithValue("@profile_expiration_warning_days", profileExpirationWarningDays);
                    cmd.Parameters.AddWithValue("@password_expiration_warning_days", passwordExpirationWarningDays);
                    cmd.Parameters.AddWithValue("@report_header", reportHeader);
                    cmd.Parameters.AddWithValue("@allowed_special_characters", allowedSpecialCharacters);
                    cmd.Parameters.AddWithValue("@restricted_username_special_characters", restrictedUsernameSpecialCharacters);
                    cmd.Parameters.AddWithValue("@task_summary_purge_days", taskSummaryPurgeDays);
                    cmd.Parameters.AddWithValue("@max_extractable_record_count", maxExtractableRecordCount);
                    cmd.Parameters.AddWithValue("@work_hours_start_time", workHoursStartTime);
                    cmd.Parameters.AddWithValue("@work_hours_end_time", workHoursEndTime);
                    cmd.Parameters.AddWithValue("@lunch_hour_start_time", lunchHourStartTime);
                    cmd.Parameters.AddWithValue("@lunch_hour_end_time", lunchHourEndTime);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Returns the data table of application parameters
    * 
    * @since version 1.0 
    * @param 
    * @return DataTable rows 
    */
    public DataTable GetApplicationParameters()
    {
        string cacheKey = "GetApplicationParameters";
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetApplicationParameters";

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spAddBranch";

                    cmd.Parameters.AddWithValue("@branch_code", branchCode);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@region_code", region);
                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spEditBranch";

                    cmd.Parameters.AddWithValue("@branch_code", branchCode);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@email", email);
                    //8/16/2023 Additional Parameter for Region
                    cmd.Parameters.AddWithValue("@region", region_code);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spDeleteBranch";

                    cmd.Parameters.AddWithValue("@branch_code", branchCode);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Returns the data table of branches that match the filter string
    * 
    * @since version 1.0 
    * @param string code - code to search
    * @param string description - description to search
    * @return DataTable rows that match the string
    */
    public DataTable FilterBranch(string code, string description)
    {
        string cacheKey = "Filter" + VG.c_branch + "&" + code + "&" + description;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spFilterBranch";

                            cmd.Parameters.AddWithValue("@code", code);
                            cmd.Parameters.AddWithValue("@description", description);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    /**
    * Returns the data table row that matches the given unique code
    * 
    * @since version 1.0 
    * @param string code - unique code identifier
    * @return DataTable row that matches the code
    */
    public DataTable GetBranch(string code)
    {
        string cacheKey = "GetBranch" + code;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetBranch";
                            cmd.Parameters.AddWithValue("@code", code);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    public DataTable GetRegion()
    {
        //string cacheKey = "GetBranch" + code;
        //DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        DataTable dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spGetRegion";
                        //cmd.Parameters.AddWithValue("@code", code);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        //HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spAddDepartment";

                    cmd.Parameters.AddWithValue("@department_code", departmentCode);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@ministry_code", divisionCode);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spEditDepartment";

                    cmd.Parameters.AddWithValue("@department_code", departmentCode);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@ministry_code", divisionCode);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spDeleteDepartment";

                    cmd.Parameters.AddWithValue("@department_code", departmentCode);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Returns the data table of departments that match the filter string
    * 
    * @since version 1.0 
    * @param string code - code to search
    * @param string description - description to search
    * @return DataTable rows that match the string
    */
    public DataTable FilterDepartment(string code, string description, string division)
    {
        string cacheKey = "Filter" + VG.c_ministry_department + "&" + code + "&" + description + "&" + division;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spFilterDepartment";

                            cmd.Parameters.AddWithValue("@code", code);
                            cmd.Parameters.AddWithValue("@description", description);
                            cmd.Parameters.AddWithValue("@division", division);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    /**
    * Returns the data table row that matches the given unique code
    * 
    * @since version 1.0 
    * @param string code - unique code identifier
    * @return DataTable row that matches the code
    */
    public DataTable GetDepartment(string code)
    {
        string cacheKey = "GetDepartment" + code;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetDepartment";

                            cmd.Parameters.AddWithValue("@code", code);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spAddDivision";

                    cmd.Parameters.AddWithValue("@code", divisionCode);
                    cmd.Parameters.AddWithValue("@description", description);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spEditDivision";

                    cmd.Parameters.AddWithValue("@code", divisionCode);
                    cmd.Parameters.AddWithValue("@description", description);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spDeleteDivision";

                    cmd.Parameters.AddWithValue("@code", divisionCode);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Returns the data table of divisions that match the filter string
    * 
    * @since version 1.0 
    * @param string code - code to search
    * @param string description - description to search
    * @return DataTable rows that match the string
    */
    public DataTable FilterDivision(string code, string description)
    {
        string cacheKey = "Filter" + VG.c_ministry + "&" + code + "&" + description;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spFilterDivision";

                            cmd.Parameters.AddWithValue("@code", code);
                            cmd.Parameters.AddWithValue("@description", description);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    /**
    * Returns the data table row that matches the given unique code
    * 
    * @since version 1.0 
    * @param string code - unique code identifier
    * @return DataTable row that matches the code
    */
    public DataTable GetDivision(string code)
    {
        string cacheKey = "GetDivision" + code;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetDivision";

                            cmd.Parameters.AddWithValue("@code", code);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spEditSecurityParameters";

                    cmd.Parameters.AddWithValue("@min_password_length", minPasswordLength);
                    cmd.Parameters.AddWithValue("@password_expiration_days", passwordExpirationDays);
                    cmd.Parameters.AddWithValue("@max_length_repeating_characters", maxLengthRepeatingCharacters);
                    cmd.Parameters.AddWithValue("@max_length_sequential_characters", maxLengthSequentialCharacters);
                    cmd.Parameters.AddWithValue("@max_cumulative_invalid_password_tries", maxCumulativeInvalidPasswordTries);
                    cmd.Parameters.AddWithValue("@max_invalid_password_tries", maxInvalidPasswordTries);
                    cmd.Parameters.AddWithValue("@max_restricted_recent_passwords", maxRestrictedRecentPasswords);
                    cmd.Parameters.AddWithValue("@allowed_special_characters", allowedSpecialCharacters);
                    cmd.Parameters.AddWithValue("@password_type", passwordType);
                    cmd.Parameters.AddWithValue("@mobile_activation_minutes", mobileActivationMinutes);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Returns the data table of Security parameters
    * 
    * @since version 1.0 
    * @param 
    * @return DataTable rows 
    */
    public DataTable GetSecurityParameters()
    {
        string cacheKey = "GetSecurityParameters";
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetSecurityParameters";

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spAddUser";

                    cmd.Parameters.AddWithValue("@employee_number", employeeNumber);
                    cmd.Parameters.AddWithValue("@user_id", userID);
                    cmd.Parameters.AddWithValue("@first_name", firstName);
                    cmd.Parameters.AddWithValue("@middle_name", middleName);
                    cmd.Parameters.AddWithValue("@last_name", lastName);
                    cmd.Parameters.AddWithValue("@user_group", userGroup);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@branch", branch);
                    cmd.Parameters.AddWithValue("@profile_expiration", profileExpirationDate);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@mobile_number", mobileNumber);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@created_by", createdBy);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spEditUser";

                    cmd.Parameters.AddWithValue("@employee_number", employeeNumber);
                    cmd.Parameters.AddWithValue("@user_id", userID);
                    cmd.Parameters.AddWithValue("@first_name", firstName);
                    cmd.Parameters.AddWithValue("@middle_name", middleName);
                    cmd.Parameters.AddWithValue("@last_name", lastName);
                    cmd.Parameters.AddWithValue("@user_group", userGroup);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@branch", branch);
                    cmd.Parameters.AddWithValue("@profile_expiration", profileExpirationDate);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@mobile_number", mobileNumber);
                    cmd.Parameters.AddWithValue("@status", status);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spDeleteUser";

                    cmd.Parameters.AddWithValue("@user_id", userId);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Returns the data table of users that match the filter string
    * 
    * @since version 1.0 
    * @param string code - code to search
    * @param string description - description to search
    * @param string userId - user ID of the current user
    * @return DataTable rows that match the string
    */
    public DataTable FilterUser(string code, string lastName, string firstName, string middleName, string userId, string userGroup, string division, string department, string branch, string status)
    {
        string cacheKey = "Filter" + VG.c_user + "&" + code + "&" + lastName + "&" + firstName + "&" + middleName + "&" + userId + "&" + userGroup + "&" + division + "&" + department + "&" + branch + "&" + status;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spFilterUser";
                            cmd.Parameters.AddWithValue("@code", code);
                            cmd.Parameters.AddWithValue("@last_name", lastName);
                            cmd.Parameters.AddWithValue("@first_name", firstName);
                            cmd.Parameters.AddWithValue("@middle_name", middleName);
                            cmd.Parameters.AddWithValue("@user_id", userId);
                            cmd.Parameters.AddWithValue("@user_group", userGroup);
                            cmd.Parameters.AddWithValue("@division", division);
                            cmd.Parameters.AddWithValue("@department", department);
                            cmd.Parameters.AddWithValue("@branch", branch);
                            cmd.Parameters.AddWithValue("@status", status);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    /**
    * Returns the data table of users that match the filter string
    * 
    * @since version 1.0 
    * @param string code - code to search
    * @param string description - description to search
    * @param string userId - user ID of the current user
    * @return DataTable rows that match the string
    */
    public DataTable FilterLockedUser(string code, string lastName, string firstName, string middleName, string userId, string userGroup, string division, string department, string branch, string status)
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spFilterLockedUser";

                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@last_name", lastName);
                        cmd.Parameters.AddWithValue("@first_name", firstName);
                        cmd.Parameters.AddWithValue("@middle_name", middleName);
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@user_group", userGroup);
                        cmd.Parameters.AddWithValue("@division", division);
                        cmd.Parameters.AddWithValue("@department", department);
                        cmd.Parameters.AddWithValue("@branch", branch);
                        cmd.Parameters.AddWithValue("@status", status);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
    }

    /**
    * Returns the data table row of the user that matches the given user ID
    * 
    * @since version 1.0 
    * @param string userId = unique ID of the user
    * @return DataTable row that match the ID
    */
    public DataTable GetUser(string userId)
    {
        //string cacheKey = "GetUser" + userId;
        //DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        //if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            DataTable dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetUser";

                            cmd.Parameters.AddWithValue("@user_id", userId);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            //HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        //else return dt;
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spSetLastLoginDate";

                    cmd.Parameters.AddWithValue("@user_id", userId);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Returns the data table row that matches the given values
    * 
    * @since version 1.0 
    * @param string userId - ID of the user
    * @return DataTable row that matches the code
    */
    public DataTable GetLatestLoginDate(string userId)
    {
        string cacheKey = "GetLatestLoginDate" + userId;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetLatestLogInDate";

                            cmd.Parameters.AddWithValue("@user_id", userId);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddMinutes(5), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spSetUserStatus";

                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@status", status);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    #endregion

    #region User Group
    /**
    * Adds a user group with the given details to the database
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spAddUserGroup";

                    cmd.Parameters.AddWithValue("@group_code", groupCode);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@created_by", createdBy);
                    cmd.Parameters.AddWithValue("@access_rights", accessRights);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spEditUserGroup";

                    cmd.Parameters.AddWithValue("@group_code", groupCode);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@updated_by", updatedBy);
                    cmd.Parameters.AddWithValue("@access_rights", accessRights);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spDeleteUserGroup";

                    cmd.Parameters.AddWithValue("@group_code", groupCode);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Returns the data table of user groups that match the filter string
    * 
    * @since version 1.0 
    * @param string code - code to search
    * @param string description - description to search
    * @param string userGroup - code of the user group of the current user
    * @return DataTable rows that match the string
    */
    public DataTable FilterUserGroup(string code, string description, string userGroup)
    {
        string cacheKey = "Filter" + VG.c_user_group + "&" + code + "&" + description + "&" + userGroup;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spFilterUserGroup";

                            cmd.Parameters.AddWithValue("@code", code);
                            cmd.Parameters.AddWithValue("@description", description);
                            cmd.Parameters.AddWithValue("@user_group", userGroup);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    /**
    * Returns the data table row that matches the given unique code
    * 
    * @since version 1.0 
    * @param string code - unique code identifier
    * @return DataTable row that matches the code
    */
    public DataTable GetUserGroup(string code)
    {
        string cacheKey = "GetUserGroup" + code;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetUserGroup";

                            cmd.Parameters.AddWithValue("@code", code);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    public List<string> AccessRights(string userGroupCode = "")
    {
        string cacheKey = "AccessRights" + userGroupCode;
        List<string> ar = HttpContext.Current.Cache[cacheKey.ToLower()] as List<string>;

        if (ar == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        ar = new List<string>();

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "spGetAccessRights";

                        cmd.Parameters.AddWithValue("@group_code", userGroupCode);

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.ExecuteNonQuery();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ar.Add(dr["access_rights"].ToString());
                            }

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), ar, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return ar;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return ar; }
        }
        else
            return ar;
    }

    public DataSet Dataset_UserGroup(string rootCode)
    {
        string cacheKey = "Dataset_UserGroup" + rootCode;
        DataSet ds = HttpContext.Current.Cache[cacheKey.ToLower()] as DataSet;

        if (ds == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        ds = new DataSet();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "spGetAccessRightsTreeView";

                        cmd.Parameters.AddWithValue("@root_code", rootCode);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            ds.Relations.Add("ChildRows", ds.Tables[0].Columns["code"], ds.Tables[0].Columns["parent_code"]);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), ds, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return ds;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return ds; }
        }
        else
            return ds;
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spAddActiveSession";

                    cmd.Parameters.AddWithValue("@session_id", sessionId);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spDeleteActiveSessionByUserId";

                    cmd.Parameters.AddWithValue("@user_id", userId);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spDeleteActiveSessionBySessionId";

                    cmd.Parameters.AddWithValue("@session_id", sessionId);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Selects the active sessions in the database with the given filters
    * 
    * @since version 1.0 
    * @param string sessionId - unique identifier of the session
    * @param string userId - unique identifier of the user
    * @return DataTable row that matches the code
    */
    public DataTable FilterActiveSession(string sessionId, string userId)
    {
        string cacheKey = "FilterActiveSession" + sessionId + userId;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spFilterActiveSession";

                            cmd.Parameters.AddWithValue("@session_id", sessionId);
                            cmd.Parameters.AddWithValue("@user_id", userId);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    /**
    * Selects the active session in the database that matches the given values
    * 
    * @since version 1.0 
    * @param string sessionId - unique identifier of the session
    * @param string userId - unique identifier of the user
    * @return DataTable row that matches the code
    */
    public DataTable GetActiveSession(string sessionId, string userId)
    {
        string cacheKey = "GetActiveSession" + userId + sessionId;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spGetActiveSession";

                            cmd.Parameters.AddWithValue("@session_id", sessionId);
                            cmd.Parameters.AddWithValue("@user_id", userId);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    /**
    * Checks if the given user ID has an active session in the database
    * 
    * @since version 1.0 
    * @param string userId - unique identifier of the user
    * @return DataTable row that matches the code
    */
    public DataTable CheckActiveSession(string userId)
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spCheckActiveSession";

                        cmd.Parameters.AddWithValue("@user_id", userId);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spEmailNotificationUser";

                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@action_message", actionMessage);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spAddAccessLogEntry";

                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@terminal_id", terminalId);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
    public DataTable AddAuditLogEntry(string userId, string content, string function, string details, string terminalId)
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spAddAuditLogEntry";

                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@content", content);
                        cmd.Parameters.AddWithValue("@function", function);
                        cmd.Parameters.AddWithValue("@details", details);
                        cmd.Parameters.AddWithValue("@terminal_id", terminalId);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
    }

    /**
    * Selects the highest sequence number in the database
    * 
    * @since version 1.0 
    * @return DataTable row of the sequence number
    */
    public DataTable GetSequenceNumber()
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "spGetSequenceNumber";

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
    }

    /**
    * Returns the server time
    * 
    * @since version 1.0 
    * @return DataTable row of server time
    */
    public DataTable GetServerTime()
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "spGetServerTime";

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
    }

    /**
    * Returns the data table of activity logs that match the filter string
    * 
    * @since version 1.0 
    * @param string userId - user ID to be filtered in the activity log table
    * @return DataTable rows that match the string
    */
    public DataTable FilterRecentActivity(string userId)
    {
        string cacheKey = "FilterRecentActivity" + userId;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spFilterRecentActivity";

                            cmd.Parameters.AddWithValue("@user_id", userId);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddMinutes(1), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
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
        try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spAddExceptionLogEntry";

                    cmd.Parameters.AddWithValue("@user_id", Employee.user_id);
                    cmd.Parameters.AddWithValue("@terminal_id", Convert.ToString(HttpContext.Current.Request.UserHostAddress));
                    cmd.Parameters.AddWithValue("@exception_url", HttpContext.Current.Request.Url.ToString());
                    cmd.Parameters.AddWithValue("@exception_message", Convert.ToString(ex.Message));
                    cmd.Parameters.AddWithValue("@exception_type", Convert.ToString(ex.GetType().Name));

                    if (ex.InnerException != null)
                    {
                        cmd.Parameters.AddWithValue("@exception_source", Convert.ToString(ex.InnerException));
                    }
                    else
                    {
                        var st = new StackTrace(ex, true);
                        var frame = st.GetFrame(st.FrameCount - 1);
                        cmd.Parameters.AddWithValue("@exception_source", Convert.ToString(frame));
                    }

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        catch { return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spChangePassword";

                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@password", password);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spResetPassword";

                    cmd.Parameters.AddWithValue("@user_id", userId);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spSetPasswordAttempts";

                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@password_attempts", attempts);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spSetCumulativeInvalidPasswordAttempts";

                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@invalid_password_attempts", invalidAttempts);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Sets the default password attempts for all users to the given value in the security parameters
    * 
    * @since version 1.0 
    * @return Boolean true if successful
    */
    public Boolean SetDefaultPasswordAttempts()
    {
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spSetDefaultPasswordAttempts";

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
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
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spAddPasswordHistory";

                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@password", password);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    /**
    * Returns the data table row that matches the given values
    * 
    * @since version 1.0 
    * @param string userId - ID of the user
    * @param int numberOfPasswords - number of passwords to retrieve based on the security parameters
    * @return DataTable row that matches the code
    */
    public DataTable FilterPasswordHistory(string userId, int numberOfPasswords)
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spFilterPasswordHistory";

                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@number_of_passwords", numberOfPasswords);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
    }

    #endregion

    #region Reports
    /**
    * Returns the data table rows of reports that match the filter string
    * 
    * @since version 1.0 
    * @param string reports - determines which reports are included
    * @return DataTable rows that match the string
    */
    public DataTable FilterReports(string reports)
    {
        string cacheKey = "FilterReports" + reports;
        DataTable dt = HttpContext.Current.Cache[cacheKey.ToLower()] as DataTable;

        if (dt == null)
        {
            //    try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter adp = new SqlDataAdapter())
                        {
                            dt = new DataTable();

                            cmd.Connection = connection; cmd.CommandTimeout = 360;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spFilterReports";
                            cmd.Parameters.AddWithValue("@reports", reports);

                            adp.SelectCommand = cmd;
                            adp.Fill(dt);

                            HttpContext.Current.Cache.Insert(cacheKey.ToLower(), dt, null, DateTime.Now.AddHours(10), System.Web.Caching.Cache.NoSlidingExpiration);

                            return dt;
                        }
                    }
                }
            }
            //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        }
        else return dt;
    }

    /**
    * Gets the report that matches the given filters
    * 
    * @since version 1.0 
    * @param string content - determines which logs are included or not
    * @param string function - determines which functions are included or not
    * @param string startingDate - starting date of the period to be filtered
    * @param string endingDate - ending date of the period to be filtered
    * @param string userId - user ID to be filtered
    * @return DataTable of the report
    */
    public DataTable GetReportAuditLog(string content, string function, string startingDate, string endingDate, string userId)
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spReportAuditLog";

                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@starting_date", startingDate);
                        cmd.Parameters.AddWithValue("@ending_date", endingDate);
                        cmd.Parameters.AddWithValue("@function", function);
                        cmd.Parameters.AddWithValue("@content", content);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
    }

    /**
    * Gets the report that matches the given filters
    * 
    * @since version 1.0 
    * @param string userId - user ID to be filtered
    * @param string firstName - first name to be filtered
    * @param string middleName - middle name to be filtered
    * @param string lastName - last name to be filtered
    * @param string userGroup - user group to be filtered
    * @param string status - status to be filtered
    * @param string dateCreated - date created to be filtered
    * @return DataTable of the report
    */
    public DataTable GetReportPasswordAging(string userId, string firstName, string middleName, string lastName, string userGroup, string status, string dateCreated)
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spReportPasswordAging";

                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@first_name", firstName);
                        cmd.Parameters.AddWithValue("@middle_name", middleName);
                        cmd.Parameters.AddWithValue("@last_name", lastName);
                        cmd.Parameters.AddWithValue("@user_group", userGroup);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@date_created", dateCreated);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
    }

    /**
    * Gets the report that matches the given filters
    * 
    * @since version 1.0 
    * @param string userId - user ID to be filtered
    * @param string firstName - first name to be filtered
    * @param string middleName - middle name to be filtered
    * @param string lastName - last name to be filtered
    * @param string userGroup - user group to be filtered
    * @param string status - status to be filtered
    * @param string dateCreated - date created to be filtered
    * @return DataTable of the report
    */
    public DataTable GetReportUser(string userId, string firstName, string middleName, string lastName, string userGroup, string status, string dateCreated)
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spReportUser";

                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@first_name", firstName);
                        cmd.Parameters.AddWithValue("@middle_name", middleName);
                        cmd.Parameters.AddWithValue("@last_name", lastName);
                        cmd.Parameters.AddWithValue("@user_group", userGroup);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@date_created", dateCreated);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
    }

    /**
    * Gets the report that matches the given filters
    * 
    * @since version 1.0 
    * @param string groupCode - group code to be filtered
    * @param string createdBy - user ID who created the group to be filtered
    * @param string dateCreated - date created to be filtered
    * @param string updatedBy - user ID who last updated the group to be filtered
    * @param string dateUpdated - date updated to be filtered
    * @return DataTable of the report
    */
    public DataTable GetReportUserGroup(string groupCode, string createdBy, string dateCreated, string updatedBy, string dateUpdated, string status)
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spReportUserGroup";

                        cmd.Parameters.AddWithValue("@group_code", groupCode);
                        cmd.Parameters.AddWithValue("@created_by", createdBy);
                        cmd.Parameters.AddWithValue("@date_created", dateCreated);
                        cmd.Parameters.AddWithValue("@updated_by", updatedBy);
                        cmd.Parameters.AddWithValue("@date_updated", dateUpdated);
                        cmd.Parameters.AddWithValue("@status", status);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
    }

    /**
    * Gets the report that matches the given filters
    * 
    * @since version 1.0 
    * @return DataTable of the report
    */
    public DataTable GetReportUserGroupAccessMatrix(string userGroupList)
    {
        DataTable dt = new DataTable();

        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spReportUserGroupAccessMatrix";

                        cmd.Parameters.AddWithValue("@user_group_list", userGroupList);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
    }

    #endregion


    #region UPCI

    #region Member
    public Boolean AddMember(string firstName, string middleName, string lastName, string gender, string birthdate, string email, string mobileNumber, string ministry, string ministryDepartment, string dateFirstAttend
        , string cell, string baptismal, string pepsol, string membershipStatus, string createdBy)
    {
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spMemberAdd";

                    cmd.Parameters.AddWithValue("@first_name", firstName);
                    cmd.Parameters.AddWithValue("@middle_name", middleName);
                    cmd.Parameters.AddWithValue("@last_name", lastName);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@birthday", birthdate);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@mobile_number", mobileNumber);
                    cmd.Parameters.AddWithValue("@ministry", ministry);
                    cmd.Parameters.AddWithValue("@ministry_department", ministryDepartment);
                    cmd.Parameters.AddWithValue("@date_first_attend", dateFirstAttend);
                    cmd.Parameters.AddWithValue("@cell", cell);
                    cmd.Parameters.AddWithValue("@baptismal", baptismal);
                    cmd.Parameters.AddWithValue("@pepsol", pepsol);
                    cmd.Parameters.AddWithValue("@membership_status", membershipStatus);
                    cmd.Parameters.AddWithValue("@created_by", createdBy);


                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    public Boolean EditMember(string memberId, string firstName, string middleName, string lastName, string gender, string birthdate, string email, string mobileNumber, string ministry, string ministryDepartment, string dateFirstAttend
        , string cell, string baptismal, string pepsol, string membershipStatus)
    {
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spMemberEdit";

                    cmd.Parameters.AddWithValue("@first_name", firstName);
                    cmd.Parameters.AddWithValue("@middle_name", middleName);
                    cmd.Parameters.AddWithValue("@last_name", lastName);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@birthday", birthdate);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@mobile_number", mobileNumber);
                    cmd.Parameters.AddWithValue("@ministry", ministry);
                    cmd.Parameters.AddWithValue("@ministry_department", ministryDepartment);
                    cmd.Parameters.AddWithValue("@date_first_attend", dateFirstAttend);
                    cmd.Parameters.AddWithValue("@cell", cell);
                    cmd.Parameters.AddWithValue("@baptismal", baptismal);
                    cmd.Parameters.AddWithValue("@pepsol", pepsol);
                    cmd.Parameters.AddWithValue("@membership_status", membershipStatus);
                    cmd.Parameters.AddWithValue("@member_id", memberId);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    public DataTable GetMemberDetails(string memberId)
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spMemberGet";

                        cmd.Parameters.AddWithValue("@member_id", memberId);
                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    public DataTable FilterMember(string name)
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spMemberFilter";

                        cmd.Parameters.AddWithValue("@full_name", name);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    #endregion

    #region Maintenance

    #region Ministry Department
    public DataTable CheckDepartmentMinistry(string code)
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spDeptMinistryCheckExist";

                        cmd.Parameters.AddWithValue("@code", code);
                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    public Boolean AddMinistryDepartment(string code,string ministryCode,string description, string createdBy)
    {
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spDeptMinistryAdd";

                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@ministry_code", ministryCode);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@created_by", createdBy);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    public DataTable FilterMinistryDepartment(string code,string description)
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spDeptMinsitryFilter";

                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@description", description);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    public DataTable GetMinistryDepartmentDetails(string code)
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spDeptMinistryGet";

                        cmd.Parameters.AddWithValue("@code", code);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    public DataTable GetMinistryDepartmentDropdown(string ministryCode)
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spGetMinistryDepartmentDropdown";

                        cmd.Parameters.AddWithValue("@ministry_code", ministryCode);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }
    #endregion

    #region Ministry
    public Boolean AddMinistry(string code, string description, string createdBy)
    {
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spMinistryAdd";

                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@created_by", createdBy);

                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }
    public Boolean EditMinistry(string code, string description)
    {
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spMinistryEdit";

                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@description", description);


                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    public Boolean DeleteMinistry(string code)
    {
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "spMinistryDelete";

                    cmd.Parameters.AddWithValue("@code", code);


                    cmd.Connection = connection; cmd.CommandTimeout = 360;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return false; }
    }

    public DataTable GetMinistryDetails(string code)
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spMinistryGet";

                        cmd.Parameters.AddWithValue("@code", code);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    public DataTable GetMinistryDropdown()
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spGetMinistryDropdown";

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    public DataTable CheckExistingMinistry(string code)
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spMinistryCheckExist";

                        cmd.Parameters.AddWithValue("@code", code);
                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    public DataTable FilterMinistry(string code, string description)
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spMinistryFilter";

                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@description", description);

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }
    #endregion

    #region PEPSOL
    public DataTable GetPepsolDropdown()
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spGetPepsolDropdown";



                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }
    #endregion

    #endregion

    #region Counts
    public DataTable WomensCount()
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spGetWomensCount";

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    public DataTable MensCount()
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spGetMensCount";

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    public DataTable YouthCounts()
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spGetYouthCount";

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }

    public DataTable YoungAdult()
    {
        DataTable dt = new DataTable();

        //if (dt == null)
        //{
        //    try
        {
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MainDatabase"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        dt = new DataTable();

                        cmd.Connection = connection; cmd.CommandTimeout = 360;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spGetYoungAdultsCount";

                        adp.SelectCommand = cmd;
                        adp.Fill(dt);



                        return dt;
                    }
                }
            }
        }
        //catch (Exception ex) { AddExceptionLogEntry(ex); return dt; }
        //}
        //else return dt;
    }
    #endregion

    #endregion




}