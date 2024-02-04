using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class UMS : System.Web.UI.MasterPage
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
                    //if (Employee.first_name.Length > 0)
                    //    lblName.Text = Employee.first_name.Substring(0, 1) + ". " + Employee.last_name;
                    //else
                    //    lblName.Text = "[first_name]. [last_name]";

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

        protected void LoadMenu()
        {
            string accessRights = Employee.access_rights;

            Regex r = new Regex("&m[0-9]", RegexOptions.IgnoreCase);
            if (r.Match(accessRights).Success)
            {
                menuMaintenance.Visible = true;

                if (accessRights.Contains(VG.ar_security_parameters) || accessRights.Contains(VG.ar_application_parameters))
                {
                    menuApplicationAdministration.Visible = true;

                    if (accessRights.Contains(VG.ar_security_parameters))
                        lbSecurityParameters.Visible = true;

                    if (accessRights.Contains(VG.ar_application_parameters))
                        lbApplicationParameters.Visible = true;
                }

                if (accessRights.Contains(VG.ar_user_group) ||
                    accessRights.Contains(VG.ar_user) ||
                    accessRights.Contains(VG.ar_branch))
                {
                    menuUserManagement.Visible = true;

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

                    if (accessRights.Contains(VG.ar_bank_user_security))
                    {
                        menuUserSecurity.Visible = true;

                        if (accessRights.Contains(VG.ar_bank_user_security_unlock))
                            lbUnlockUser.Visible = true;

                        if (accessRights.Contains(VG.ar_bank_user_security_reset))
                            lbResetPassword.Visible = true;

                        if (accessRights.Contains(VG.ar_bank_user_security_session))
                            lbActiveSessions.Visible = true;
                    }
                }

                if (accessRights.Contains(VG.ar_ministry_department))
                {
                    if (accessRights.Contains("&m3d,") || accessRights.Contains("&m3e,"))
                        lbMinistryDepartmentSearch.Visible = true;
                }

                if (accessRights.Contains(VG.ar_ministry))
                {
                    menuMinistry.Visible = true;
                    if (accessRights.Contains("&m8d,") || accessRights.Contains("&m8e,"))
                        lbMinistrySearch.Visible = true;
                }

                if (accessRights.Contains(VG.ar_member))
                {
                    menuMembers.Visible = true;

                    if (accessRights.Contains("&a9s,") || accessRights.Contains("&a9e,"))
                        lbMemberList.Visible = true;
                }
            }
        }
        protected void lbChangePW_Click(object sender, EventArgs e)
        {
            Maintenance.content_description = "Change Password";
            Response.Redirect("password-change.aspx", false);
        }

        #region Members
        protected void lbMemberList_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_member;
            Response.Redirect("member-search.aspx");
        }

        #endregion

        #region Lockscreen
        protected void lbLockscreen_Click(object sender, EventArgs e)
        {
            Response.Redirect("lockscreen.aspx", false);
        }

        #endregion

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
                Response.Redirect("parameters-application.aspx", false);
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
                Response.Redirect("parameters-security.aspx", false);
            }
        }
        #endregion

        #region Ministry
        protected void lbMinistrySearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_ministry;

            ResetMaintenanceFilters();
            Response.Redirect("ministry-search.aspx", false);
        }
        #endregion

        #region Ministry Department
        protected void lbMinistryDepartmentSearch_Click(object sender, EventArgs e)
        {
            Maintenance.content_code = VG.c_ministry_department;

            ResetMaintenanceFilters();
            Response.Redirect("dept-ministry-search.aspx", false);
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