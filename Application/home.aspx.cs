using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class home : System.Web.UI.Page
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
                        if (_BLL.GetLatestLoginDate(Employee.user_id))
                        {
                            if (Employee.last_login_attempt_status == "1")
                                lblLatestLogInDate.Text = "Your last login date was on " + Employee.last_login_attempt_date.ToString("dd MMMM yyyy h:mm:ss tt") + ".";
                            else if (Employee.last_login_attempt_status == "0")
                                lblLatestLogInDate.Text = "There was an unsuccessful login attempt to your account on " + Employee.last_login_attempt_date.ToString("dd MMMM yyyy h:mm:ss tt") + ".";
                        }

                        if (Employee.warn_profile_expiration)
                        {
                            lblExpirationAlert.Text += " Your profile will expire on " + Employee.profile_expiration_date.ToString("dd MMMM yyyy") + ".";
                        }

                        if (Employee.warn_password_expiration)
                        {
                            lblExpirationAlert.Text += " Your password will expire on " + Employee.password_expiration_date.ToString("dd MMMM yyyy") + ".";
                        }

                        if (lblExpirationAlert.Text.Length > 0)
                        {
                            lblExpirationAlert.Visible = true;
                        }

                        if (Employee.first_name.Length > 0)
                            lblName.Text = Employee.first_name;
                        else
                            lblName.Text = "[first_name]";

                        if (_BLL.FilterRecentActivity(gvRecentActivity, Employee.user_id) == false)
                        {
                        }

                        LoadCount();
                    }
                }
            }
        }

        protected void gvRecentActivity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Pager)
            {
                DateTime aDate;
                if (DateTime.TryParse(e.Row.Cells[0].Text, CultureInfo.InvariantCulture, DateTimeStyles.None, out aDate))
                {
                    e.Row.Cells[0].Text = aDate.ToString("MM/dd/yyyy h:mm:ss tt");
                }
            }
        }

        protected void LoadCount()
        {
            DataTable dtWomens = new DataTable();
            dtWomens = _DAL.WomensCount();

            lblWomens.Text = Convert.ToString(dtWomens.Rows[0]["womens"]);

            DataTable dtMens = new DataTable();
            dtMens = _DAL.MensCount();
            lblMens.Text = Convert.ToString(dtMens.Rows[0]["mens"]);

            DataTable dtYouth = new DataTable();
            dtYouth = _DAL.YouthCounts();
            lblYouth.Text = Convert.ToString(dtYouth.Rows[0]["youth"]);

            DataTable dtYoungAdult = new DataTable();
            dtYoungAdult = _DAL.YoungAdult();
            lblYoungAdults.Text = Convert.ToString(dtYoungAdult.Rows[0]["young_adults"]);
        }
    }
}