using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class user_view : System.Web.UI.Page
    {
        DAL _DAL = new DAL();
        private BLL _BLL = new BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Browser.Browser == "IE" || Request.Browser.Browser == "InternetExplorer")
            {
                Response.Write("<script language='javascript'>window.alert('This application is not compatible with Internet Explorer.');window.location='about:blank';</script>");
                return;
            }
            else
            {
                if (!IsPostBack)
                {
                    if (_BLL.SessionIsActive(this))
                    {
                        string accessRights = Employee.access_rights;
                        Regex r = new Regex("&m[0-9]", RegexOptions.IgnoreCase);

                        if (!r.Match(accessRights).Success)
                        {
                            _BLL.AddAccessLogEntry(VG.access_maintenance, Employee.user_id, "0", Request.UserHostAddress.ToString());

                            ScriptManager.RegisterStartupScript(this, GetType(), "Script", "noAccessRedirect('logout.aspx');", true);
                        }
                        else
                        {
                            if (_BLL.GetContentType(Maintenance.content_code) == false)
                            { }
                            else
                            {
                                #region Titles
                                contentHeader.Text = Maintenance.content_description + " Maintenance";
                                mainBreadcrumb.Text = Maintenance.content_description;
                                subItemBreadcrumb.Text = Maintenance.mode;
                                //cardTitle.Text = Maintenance.mode + " " + Maintenance.content_description;
                                #endregion

                                LoadUserDetails(Maintenance.entry_code);
                            }
                            
                        }
                    }
                }
            }
        }

        protected void LoadUserDetails(string userId)
        {
            if (_BLL.GetUserDetails(userId) == false)
            { }
            else
            {
                lblUserID.Text = Maintenance.user_id;
                lblFirstName.Text = Maintenance.first_name;
                lblMiddleName.Text = Maintenance.middle_name;
                lblLastName.Text = Maintenance.last_name;
                lblUserGroup.Text = Maintenance.user_group_desc;
                lblMinistry.Text = Maintenance.ministry_description;
                lblMinistryDepartment.Text = Maintenance.ministry_dept_desc;
                DateTime dateProfile = (DateTime)Maintenance.profile_expiration_date;
                if (dateProfile != Convert.ToDateTime("1900-01-01"))
                    lblProfileExpirationDate.Text = dateProfile.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                else
                {
                    lblProfileExpirationDate.Text = "";
                }

                lblEmail.Text = Maintenance.email;
                lblMobileNumber.Text = Maintenance.mobile_number;
                lblStatus.Text = Maintenance.status_description;

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Response.Redirect("user-search.aspx", false);
            }
        }




    }
}