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
    public partial class member_view : System.Web.UI.Page
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
                            LoadMemberDetails(Maintenance.entry_code);
                        }
                    }
                }
            }

        }

        protected void LoadMemberDetails(string memberId)
        {
            if (_BLL.GetMemberDeatils(memberId) == false)
            { }
            else
            {
                lblMemberId.Text = Member.member_id;
                lblFirstName.Text = Member.first_name;
                lblMiddleName.Text = Member.middle_name;
                lblLastName.Text = Member.last_name;
                lblEmail.Text = Member.email;
                lblGender.Text = Member.gender;
                lblBirthday.Text = Member.birthday;
                lblMobileNumber.Text = Member.mobile_number;
                lblMinistry.Text = Member.ministry;
                lblMinistryDepartment.Text = Member.ministry_department;
                lblCell.Text = Member.cell_status;
                lblBaptismal.Text = Member.baptismal_status;
                lblPepsol.Text = Member.pepsol_level;
                lblStatus.Text = Member.membership_status;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Response.Redirect("member-search.aspx", false);
            }
        }
    }
}