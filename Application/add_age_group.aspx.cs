using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class add_age_group : System.Web.UI.Page
    {
        DAL _DAL = new DAL();
        BLL _BLL = new BLL();
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
                        if (_BLL.GetContentType(Maintenance.content_code) == false)
                        {
                        }
                        else
                        {
                            lblHeader.Text = Maintenance.content_description + " Maintenance";
                            Maintenance.mode = "Add";
                            
                            cardHeaderDesc.Text = Maintenance.mode + " " + Maintenance.content_description;
                            
                            codeDescCard.Visible = true;
                            txtCode.Focus();
                        }

                    }
                }
            }
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                //DataTable dt = _DAL.dtResidentAgeGroup(txtCode.Text, "", "","CHK");
                //if (Convert.ToInt32(dt.Rows[0][0]) == 0)
                //{
                //    Boolean result = false;

                //    //if (Maintenance.content_code == VG.c_supplier)
                //    //{
                //    //result = _DAL.boolResidentAgeGroup(txtCode.Text.Trim(), txtDescription.Text.Trim(), Employee.user_id, "ADD");
                //    if (result == false)
                //    {
                //        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to add.', 'error');", true);
                //    }
                //    else
                //    {
                //        string transactionReferenceNumber = "";
                //        if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, Maintenance.mode, "Code: " + txtCode.Text, Request.UserHostAddress.ToString()))
                //            transactionReferenceNumber = VG.application_name+"-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmmss") + "-" + DateTime.Now.ToString("HHmmssffff");

                //        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been added.','" + transactionReferenceNumber + "');", true);

                //        ClearValues();
                //        //ClearValues(new TextBox[] { txtCode, txtDescription, txtMinAge, txtMaxAge });
                //    }
                //    //}

                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Code is already in use.', '', 'error');", true);
                //}



            }
        }
        
        void ClearValues()
        {
            txtCode.Text = "";
            txtDescription.Text = "";

        }

        
    }
}