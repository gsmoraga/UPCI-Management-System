﻿using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Template
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private BLL _BLL = new BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cName.Text = cName2.Text = Employee.first_name + " " + Employee.middle_name + " " + Employee.last_name;
                cUserGroup.Text = Employee.user_group_name;

                if (Maintenance.first_login)
                {
                    Maintenance.first_login = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "loginSuccess();", true);
                }

                if (_BLL.GetUserAccessRights(Employee.user_group) == false)
                {
                }
                else
                {
                    LoadMenu();
                }
            }
        }

        public void LoadMenu()
        {
            string accessRights = Employee.access_rights;

            #region Reports
            if (accessRights.Contains("&r"))
            {
                liReports.Visible = true;
                lbReports.Attributes.Add("href", "view-report.aspx");
            }
            #endregion

            #region Maintenance
            Regex r = new Regex("&m[0-9]", RegexOptions.IgnoreCase);
            if (r.Match(accessRights).Success)
            {
                menuMaintenance.Attributes.Add("style", "z-index:1031");

                if (accessRights.Contains(VG.ar_security_parameters) || accessRights.Contains(VG.ar_application_parameters))
                {
                    menuApplicationAdministration.Visible = true;

                    if (accessRights.Contains(VG.ar_security_parameters))
                        lbSecurityParameters.Visible = true;

                    if (accessRights.Contains(VG.ar_application_parameters))
                        lbApplicationParameters.Visible = true;
                }

                if (accessRights.Contains(VG.ar_department) ||
                    accessRights.Contains(VG.ar_user_group) ||
                    accessRights.Contains(VG.ar_user) ||
                    accessRights.Contains(VG.ar_branch) ||
                    accessRights.Contains(VG.ar_division))
                {
                    menuUserManagement.Visible = true;

                    if (accessRights.Contains(VG.ar_department))
                    {
                        menuDepartment.Visible = true;

                        if (accessRights.Contains("&m3a,"))
                            lbDepartmentAdd.Visible = true;
                        if (accessRights.Contains("&m3d,") || accessRights.Contains("&m3e,") || accessRights.Contains("&m3v,"))
                            lbDepartmentSearch.Visible = true;
                    }

                    if (accessRights.Contains(VG.ar_user_group))
                    {
                        menuUserGroup.Visible = true;

                        if (accessRights.Contains("&m4a,"))
                            lbUserGroupAdd.Visible = true;
                        if (accessRights.Contains("&m4d,") || accessRights.Contains("&m4e,") || accessRights.Contains("&m4v,"))
                            lbUserGroupSearch.Visible = true;
                    }

                    if (accessRights.Contains(VG.ar_user))
                    {
                        menuUser.Visible = true;

                        if (accessRights.Contains("&m5a,"))
                            lbUserAdd.Visible = true;
                        if (accessRights.Contains("&m5d,") || accessRights.Contains("&m5e,") || accessRights.Contains("&m5v,"))
                            lbUserSearch.Visible = true;
                    }

                    if (accessRights.Contains(VG.ar_branch))
                    {
                        menuBranch.Visible = true;

                        if (accessRights.Contains("&m7a,"))
                            lbBranchAdd.Visible = true;

                        if (accessRights.Contains("&m7d,") || accessRights.Contains("&m7e,") || accessRights.Contains("&m7v,"))
                            lbBranchSearch.Visible = true;
                    }

                    if (accessRights.Contains(VG.ar_division))
                    {
                        menuDivision.Visible = true;

                        if (accessRights.Contains("&m8a,"))
                            lbDivisionAdd.Visible = true;
                        if (accessRights.Contains("&m8d,") || accessRights.Contains("&m8e,") || accessRights.Contains("&m8v,"))
                            lbDivisionSearch.Visible = true;
                    }
                }

                if (accessRights.Contains(VG.ar_bank_user_security))
                {
                    menuBankUserSecurity.Visible = true;

                    if (accessRights.Contains(VG.ar_bank_user_security_unlock))
                        lbUnlockUser.Visible = true;

                    if (accessRights.Contains(VG.ar_bank_user_security_reset))
                        lbResetPassword.Visible = true;

                    if (accessRights.Contains(VG.ar_bank_user_security_session))
                        lbActiveSessions.Visible = true;
                }


            }
            //Survey Maintenance
            if (accessRights.Contains(VG.ar_civil_status))
            {
                menuCivilStatus.Visible = true;

                if (accessRights.Contains("&m10a,"))
                    lbCivilStatusAdd.Visible = true;
                if (accessRights.Contains("&m10d,") || accessRights.Contains("&m10e,"))
                    lbCivilStatusSearch.Visible = true;
            }
            if (accessRights.Contains(VG.ar_civil_status))
            {
                menuEducationalAttainment.Visible = true;

                if (accessRights.Contains("&m11a,"))
                    lbEducationalAttainmentAdd.Visible = true;
                if (accessRights.Contains("&m11d,") || accessRights.Contains("&m11e,"))
                    lbEducationalAttainmentSearch.Visible = true;
            }
            if (accessRights.Contains(VG.ar_region))
            {
                menuRegion.Visible = true;

                if (accessRights.Contains("&m12a,"))
                    lbRegionResidenceAdd.Visible = true;
                if (accessRights.Contains("&m12d,") || accessRights.Contains("&m12e,"))
                    lbRegionResidenceSearch.Visible = true;
            }
            if (accessRights.Contains(VG.ar_age_group))
            {
                menuAgeGroup.Visible = true;

                if (accessRights.Contains("&m13a,"))
                    lbAgeGroupAdd.Visible = true;
                if (accessRights.Contains("&m13d,") || accessRights.Contains("&m13e,"))
                    lbAgeGroupSearch.Visible = true;
            }

            if (accessRights.Contains(VG.ar_services))
            {
                menuServices.Visible = true;

                if (accessRights.Contains("&m14a,"))
                    lbServiceAvailedAdd.Visible = true;
                if (accessRights.Contains("&m14d,") || accessRights.Contains("&m14e,"))
                    lbServiceAvailedSearch.Visible = true;
            }

            if (accessRights.Contains(VG.ar_working_status))
            {
                menuWorkingStatus.Visible = true;

                if (accessRights.Contains("&m15a,"))
                    lbWorkingStatusAdd.Visible = true;
                if (accessRights.Contains("&m15d,") || accessRights.Contains("&m15e,"))
                    lbWorkingStatusSearch.Visible = true;
            }

            if (accessRights.Contains(VG.ar_branch_services))
            {
                menuBranchServices.Visible = true;

                if (accessRights.Contains("&m16a,"))
                    lbBranchServicesAdd.Visible = true;
                if (accessRights.Contains("&m16d,") || accessRights.Contains("&m16e,"))
                    lbBranchServicesSearch.Visible = true;
            }
            #endregion

            #region Change Password

            //lbChangePW.Attributes.Add("href", "password-change.aspx");

            #endregion



            #region Active State
            if (Request.ServerVariables["URL"].Contains("home"))
            {
                btnHome.Attributes.Add("style", "color:#285192; background-color:#cccccc");
                lbReports.Attributes.Remove("style");
                MaintenanceDropDown.Attributes.Remove("style");
                lbChangePW.Attributes.Remove("style");
            }

            else if (Request.ServerVariables["URL"].Contains("report"))
            {
                btnHome.Attributes.Remove("style");
                lbReports.Attributes.Add("style", "color:#285192; background-color:#cccccc");
                MaintenanceDropDown.Attributes.Remove("style");
                lbChangePW.Attributes.Remove("style");
            }

            else if (Request.ServerVariables["URL"].Contains("maintenance"))
            {
                btnHome.Attributes.Remove("style");
                lbReports.Attributes.Remove("style");
                MaintenanceDropDown.Attributes.Add("style", "color:#285192; background-color:#cccccc");
                lbChangePW.Attributes.Remove("style");
            }

            else if (Request.ServerVariables["URL"].Contains("password"))
            {
                btnHome.Attributes.Remove("style");
                lbReports.Attributes.Remove("style");
                MaintenanceDropDown.Attributes.Remove("style");
                lbChangePW.Attributes.Add("style", "color:#285192; background-color:#cccccc");
            }
            #endregion
        }

        protected void lbSecurityParameters_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_security_parameters;
            Maintenance.bank_user_security = false;

            ResetMaintenanceFilters();

            if (_BLL.GetSecurityParameters() == false)
            {
                //error message
            }
            else
            {
                _BLL.GetContentType(Maintenance.content_code);
                Response.Redirect("maintenance-parameters.aspx", false);
            }
        }

        protected void lbApplicationParameters_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_application_parameters;
            Maintenance.bank_user_security = false;

            ResetMaintenanceFilters();

            if (_BLL.GetApplicationParameters() == false)
            {
                //error message
            }
            else
            {
                _BLL.GetContentType(Maintenance.content_code);
                Response.Redirect("maintenance-parameters.aspx", false);
            }
        }

        protected void lbBranchAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_branch;
            Maintenance.bank_user_security = false;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("maintenance-parameters.aspx", false);
        }

        protected void lbBranchSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_branch;
            Maintenance.bank_user_security = false;

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }

        protected void lbDepartmentAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_department;
            Maintenance.bank_user_security = false;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("maintenance-parameters.aspx", false);
        }

        protected void lbDepartmentSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_department;
            Maintenance.bank_user_security = false;

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }

        protected void lbDivisionAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_division;
            Maintenance.bank_user_security = false;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("maintenance-parameters.aspx", false);
        }

        protected void lbDivisionSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_division;
            Maintenance.bank_user_security = false;

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }

        protected void lbUserGroupAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_user_group;
            Maintenance.bank_user_security = false;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("maintenance-parameters.aspx", false);
        }

        protected void lbUserGroupSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_user_group;
            Maintenance.bank_user_security = false;

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }

        protected void lbUserAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_user;
            Maintenance.bank_user_security = false;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("maintenance-parameters.aspx", false);
        }

        protected void lbUserSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_user;
            Maintenance.bank_user_security = false;

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }

        protected void lbUnlockUser_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_user;
            Maintenance.bank_user_security = true;
            Maintenance.bank_user_security_mode = "Unlock";

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }

        protected void lbResetPassword_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_user;
            Maintenance.bank_user_security = true;
            Maintenance.bank_user_security_mode = "Reset";

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }

        protected void lbActiveSessions_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_active_session;
            Maintenance.bank_user_security = true;
            Maintenance.bank_user_security_mode = "Session";

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }

        protected void lbReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("view-report.aspx", false);
        }

        protected void lbChangePW_Click(object sender, EventArgs e)
        {
            Response.Redirect("password-change.aspx", false);
        }

        public void ResetMaintenanceFilters()
        {
            Maintenance.code_filter = "";
            Maintenance.description_filter = "";
            Maintenance.page_index = 0; ;
        }

        protected void lbAgeGroupAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_age_group;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("add_age_group.aspx", false);
        }

        protected void lbAgeGroupSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_age_group;
            Maintenance.mode = "Search";

            ResetMaintenanceFilters();

            Response.Redirect("search_age_group.aspx", false);
        }

        protected void lbCivilStatusAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_civil_status;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("add_civil_status.aspx", false);
        }

        protected void lbCivilStatusSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_civil_status;
            Maintenance.mode = "Search";

            ResetMaintenanceFilters();

            Response.Redirect("search_civil_status.aspx", false);
        }

        protected void lbEducationalAttainmentAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_educational_attainment;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();
            Response.Redirect("add_educational_attainment.aspx", false);
        }

        protected void lbEducationalAttainmentSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_educational_attainment;
            Maintenance.mode = "Search";

            ResetMaintenanceFilters();

            Response.Redirect("search_educational_attainment.aspx", false);
        }

        protected void lbRegionResidenceAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_region;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("add_region_of_residence.aspx", false);
        }

        protected void lbRegionResidenceSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_region;
            Maintenance.mode = "Search";

            ResetMaintenanceFilters();

            Response.Redirect("search_region_of_residence.aspx", false);
        }

        protected void lbServiceAvailedAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_services;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("add_service_availed.aspx", false);
        }

        protected void lbServiceAvailedSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_services;
            Maintenance.mode = "Search";

            ResetMaintenanceFilters();

            Response.Redirect("search_service_availed.aspx", false);
        }

        protected void lbWorkingStatusAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_working_status;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("add_working_status.aspx", false);
        }

        protected void lbWorkingStatusSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_working_status;
            Maintenance.mode = "Search";

            ResetMaintenanceFilters();

            Response.Redirect("search_working_status.aspx", false);
        }
        protected void lbBranchServicesAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_branch_services;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("add_branch_services.aspx", false);
        }

        protected void lbBranchServicesSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_branch_services;
            Maintenance.mode = "Search";

            ResetMaintenanceFilters();

            Response.Redirect("search_branch_services.aspx", false);
        }


        protected void lbSurveyInquiry_Click(object sender, EventArgs e)
        {

        }

        protected void lbSurveyQuestionsAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_questions.aspx", false);
        }

        protected void lbSurveyQuestionSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("search_questions.aspx", false);
        }

        
    }
}