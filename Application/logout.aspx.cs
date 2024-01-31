using System;

namespace Template
{
    public partial class logout : System.Web.UI.Page
    {
        BLL _BLL = new BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            _BLL.AddAccessLogEntry(VG.access_logout, Employee.user_id, "1", Request.UserHostAddress.ToString());
            _BLL.RemoveFromCache("FilterActiveSession");
            _BLL.RemoveFromCache("GetActiveSession" + Convert.ToString(Session["SessionID"]));
            _BLL.DeleteActiveSessionBySessionId(Convert.ToString(Session["SessionID"]));

            Session.Clear();

            Response.Redirect("login.aspx", false);
        }
    }
}