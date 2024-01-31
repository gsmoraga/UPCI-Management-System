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

                if (accessRights.Contains(VG.ar_department) ||
                    accessRights.Contains(VG.ar_user_group) ||
                    accessRights.Contains(VG.ar_user) ||
                    accessRights.Contains(VG.ar_branch) ||
                    accessRights.Contains(VG.ar_division))
                {
                    menuUserManagement.Visible = true;

                    if (accessRights.Contains(VG.ar_department))
                    {
                        if (accessRights.Contains("&m3a"))
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

                    if (accessRights.Contains(VG.ar_division))
                    {
                        menuMinistry.Visible = true;

                        if (accessRights.Contains("&m8a,"))
                            lbMinistryAdd.Visible = true;
                        if (accessRights.Contains("&m8d,") || accessRights.Contains("&m8e,") || accessRights.Contains("&m8v,"))
                            lbministrySearch.Visible = true;
                    }

                    if (accessRights.Contains(VG.ar_branch))
                    {
                        menuMembers.Visible = true;

                        if (accessRights.Contains("&m7a,"))
                            lbMemberList.Visible = true;
                    }
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
            Response.Redirect("manage-members.aspx");
        }

        #endregion

        #region Lockscreen
        protected void lbLockscreen_Click(object sender, EventArgs e)
        {
            Response.Redirect("lockscreen.aspx", false);
        }

        #endregion

    }
}