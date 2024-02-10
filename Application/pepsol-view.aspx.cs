using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class pepsol_view : System.Web.UI.Page
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
                                cardTitle.Text = Maintenance.mode + " " + Maintenance.content_description;
                                #endregion

                                LoadPepsolDetails(Maintenance.entry_code);
                            }
                            
                        }
                    }
                }
            }
        }
        protected void LoadPepsolDetails(string code)
        {
            if (_BLL.GetPepsolDetails(code) == false)
            { }
            else
            {
                lblCode.Text = Maintenance.code;
                lblDescription.Text = Maintenance.description;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Response.Redirect("pepsol-search.aspx", false);
            }
        }
    }
}