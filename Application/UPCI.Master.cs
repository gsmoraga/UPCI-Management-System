using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class Procurement : System.Web.UI.MasterPage
    {
        BLL _BLL = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


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
                    #region Names
                    if (Employee.first_name.Length > 0)
                        lblName.Text = Employee.first_name.Substring(0, 1) + ". " + Employee.last_name;
                    else
                        lblName.Text = "[first_name]. [last_name]";

                    if (Employee.first_name.Length > 0)
                    {
                        lblFullName.Text = Employee.first_name + " " + Employee.last_name;
                    }
                    else
                    {
                        lblFullName.Text = "[first_name] [last_name]";
                    }

                    if (Employee.user_group_name.Length > 0)
                    {
                        lblUserGroup.Text = Employee.user_group_name;
                    }
                    else
                    {
                        lblUserGroup.Text = "[user_group]";
                    }
                    #endregion

                    LoadMenu();
                }
            }

        }

        public void LoadMenu()
        {
            #region Active State
            //if (Request.ServerVariables["URL"].Contains("Homepage"))
            //{
            //    lblBreadcrumbHead.Text = "Home";
            //    lblBreadcrumbMain.Text = Maintenance.content_description;
            //    //lbHome.Attributes.Add("style", "color:#FFFFFF; background-color:#6777ef");
            //}
            //else if (Request.ServerVariables["URL"].Contains("report"))
            //{
            //    lblBreadcrumbHead.Text = "Report";
            //    lblBreadcrumbMain.Text = "Reports";
            //    //lbReports.Attributes.Add("style", "color:#FFFFFF; background-color:#6777ef");
            //}
            //else if (Request.ServerVariables["URL"].Contains("maintenance"))
            //{
            //    lblBreadcrumbHead.Text = "Maintenance";
            //    lblBreadcrumbMain.Text = Maintenance.content_description;
            //}
            //else if (Request.ServerVariables["URL"].Contains("procurement-purchase-requisition-form"))
            //{
            //    lblBreadcrumbHead.Text = "Purchase Requisition";
            //    lblBreadcrumbMain.Text = "Request";
            //}
            //else if (Request.ServerVariables["URL"].Contains("inquiry-all"))
            //{
            //    lblBreadcrumbHead.Text = "Purchase Requisition";
            //    lblBreadcrumbMain.Text = "Inquiry";
            //}
            //else if (Request.ServerVariables["URL"].Contains("inquiry-for-action"))
            //{
            //    lblBreadcrumbHead.Text = "Purchase Requisition";
            //    lblBreadcrumbMain.Text = "For Action";
            //}
            //else if (Request.ServerVariables["URL"].Contains("password-change"))
            //{
            //    lblBreadcrumbHead.Text = "Password Change";
            //    //lblBreadcrumbMain.Text = "";
            //}
            //else if (Request.ServerVariables["URL"].Contains("view-purchase-requisition-form"))
            //{
            //    lblBreadcrumbHead.Text = "Purchase Requisition";
            //    lblBreadcrumbMain.Text = "View";
            //}
            #endregion


            string accessRights = Employee.access_rights;

            #region Reports
            if (accessRights.Contains("&r"))
            {
                reportHeader.Visible = true;
                liReports.Visible = true;
                lbReports.Attributes.Add("href", "view-report.aspx");
            }
            #endregion

            #region Maintenance
            Regex r = new Regex("&m[0-9]", RegexOptions.IgnoreCase);
            if (r.Match(accessRights).Success)
            {
                menuMaintenance.Visible = true;
                //Application Administration
                if (accessRights.Contains(VG.ar_security_parameters) || accessRights.Contains(VG.ar_application_parameters))
                {
                    menuApplicationAdministration.Visible = true;

                    if (accessRights.Contains(VG.ar_security_parameters))
                        lbSecurityParameters.Visible = true;

                    if (accessRights.Contains(VG.ar_application_parameters))
                        lbApplicationParameters.Visible = true;
                }

                //User Management

                if (accessRights.Contains(VG.ar_ministry_department) ||
                    accessRights.Contains(VG.ar_user_group) ||
                    accessRights.Contains(VG.ar_user) ||
                    accessRights.Contains(VG.ar_pepsol) ||
                    accessRights.Contains(VG.ar_ministry))
                {
                    menuUserManagement.Visible = true;

                    if (accessRights.Contains(VG.ar_ministry_department))
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

                    if (accessRights.Contains(VG.ar_pepsol))
                    {
                        menuBranch.Visible = true;

                        if (accessRights.Contains("&m7a,"))
                            lbBranchAdd.Visible = true;

                        if (accessRights.Contains("&m7d,") || accessRights.Contains("&m7e,") || accessRights.Contains("&m7v,"))
                            lbBranchSearch.Visible = true;
                    }

                    if (accessRights.Contains(VG.ar_ministry))
                    {
                        menuDivision.Visible = true;

                        if (accessRights.Contains("&m8a,"))
                            lbDivisionAdd.Visible = true;
                        if (accessRights.Contains("&m8d,") || accessRights.Contains("&m8e,") || accessRights.Contains("&m8v,"))
                            lbDivisionSearch.Visible = true;
                    }
                }
            }
            #endregion

            #region Bank User Security Maintenance
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
            #endregion

            #region Frontend
            menuMembershipInfo.Visible = true;
            lbAddMember.Visible = true;
            lbSearchMember.Visible = true;
            pagesHeader.Visible = true;
            //if (accessRights.Contains("&staff,"))
            //{
            //    menuMembershipInfo.Visible = true;

            //    if (accessRights.Contains("&staffAdd,"))
            //    {
            //        lbAddMember.Visible = true;
            //    }
            //}
            #endregion
        }
        protected void lbHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx", false);
        }

        #region Application Administration
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
        #endregion

        #region User Management

        #region Branch
        protected void lbBranchAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_pepsol;
            Maintenance.bank_user_security = false;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("maintenance-parameters.aspx", false);
        }
        protected void lbBranchSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_pepsol;
            Maintenance.bank_user_security = false;

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }
        #endregion

        #region Department
        protected void lbDepartmentAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_ministry_department;
            Maintenance.bank_user_security = false;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("maintenance-parameters.aspx", false);
        }
        protected void lbDepartmentSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_ministry_department;
            Maintenance.bank_user_security = false;

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }
        #endregion

        #region Division
        protected void lbDivisionAdd_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_ministry;
            Maintenance.bank_user_security = false;
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("maintenance-parameters.aspx", false);
        }

        protected void lbDivisionSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_ministry;
            Maintenance.bank_user_security = false;

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }
        #endregion

        #region User
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
            Maintenance.mode = "Add";

            ResetMaintenanceFilters();

            Response.Redirect("view-maintenance.aspx", false);
        }
        #endregion

        #region User Group
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
        #endregion

        #endregion

        #region Bank User Security
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

        #endregion

        #region Reports
        protected void lbReports_Click(object sender, EventArgs e)
        {

            Response.Redirect("view-report.aspx", false);
        }
        #endregion

        protected void lbChangePW_Click(object sender, EventArgs e)
        {
            Maintenance.content_description = "Change Password";
            Response.Redirect("password-change.aspx", false);
        }



        #region Pages
        protected void lbAddMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("add-member-form.aspx",false);
        }

        protected void lbSearchMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("manage-members.aspx", false);
        }
        #endregion

        public void ResetMaintenanceFilters()
        {
            Maintenance.code_filter = "";
            Maintenance.description_filter = "";
            Maintenance.page_index = 0; ;
        }

       
    }
}