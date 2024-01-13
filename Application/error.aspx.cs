using System;

namespace Template
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        /**
        * Removes all session values and redirects the user back to the log in page
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("logout.aspx", false);
        }
    }
}