using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class pepsol_add : System.Web.UI.Page
    {
        BLL _BLL = new BLL();
        DAL _DAL = new DAL();
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
                            cardMaintenance.Visible = true;
                        }
                    }
                }
            }
        }

        #region Link Buttons
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                DataTable dt = new DataTable();
                dt = _DAL.CheckExistingPepsol(txtCode.Text);
                if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                {
                    if (_BLL.AddPepsol(txtCode.Text.Trim(), txtDescription.Text, Employee.user_id) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!','Unable to add the user.','error');", true);
                    }
                    else
                    {
                        string transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmm") + "-" + DateTime.Now.ToString("ssffff");
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been added.','" + transactionReferenceNumber + "');", true);

                        _BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Add", "TRN: " + transactionReferenceNumber, Request.UserHostAddress.ToString());

                        ClearValues();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Code is already in use.', '', 'error');", true);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Response.Redirect("pepsol-search.aspx", false);
            }
        }
        #endregion

        protected void ClearValues()
        {
            txtCode.Text = "";
            txtDescription.Text = "";
        }
    }
}