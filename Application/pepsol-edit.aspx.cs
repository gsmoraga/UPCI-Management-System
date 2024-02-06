using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class pepsol_edit : System.Web.UI.Page
    {
        private BLL _BLL = new BLL();
        private DAL _DAL = new DAL();
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
                                LoadDetails(Maintenance.entry_code);
                            }
                        }
                    }
                }

            }

        }

        protected void LoadDetails(string code)
        {
            if (_BLL.GetPepsolDetails(code) == false)
            { }
            else
            {
                lblCode.Text = Maintenance.code;
                txtDescription.Text = Maintenance.description;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Response.Redirect("pepsol-search.aspx", false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Boolean result = false;
                result = _BLL.EditPepsol(Maintenance.entry_code, txtDescription.Text.Trim());

                if (result == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to update the entry.', 'error');", true);
                }
                else
                {
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, Maintenance.mode, "Code: " + Maintenance.entry_code, Request.UserHostAddress.ToString()) == false)
                    { }
                    else
                    {

                        string transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmm") + "-" + DateTime.Now.ToString("ssff");
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been updated.','" + transactionReferenceNumber + "');", true);
                    }

                }
            }
        }


    }
}