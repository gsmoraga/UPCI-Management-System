using System;
using System.Web;

namespace Template
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            BLL _BLL = new BLL();
            Exception ex = Server.GetLastError();

            if (_BLL.AddExceptionLogEntry(ex) == false)
            {
            }

            if (ex is HttpRequestValidationException)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.Write(@"
                    <html xmlns='http://www.w3.org/1999/xhtml'>
                        <head runat='server'>
                            <title>Error: HTML not allowed</title>    
                            <link href='css/bootstrap.min.css' rel='stylesheet' type='text/css' />
                        </head>
                        <body>
                            <form id='form1' runat='server'>
                                <div align='center' style='font-family: Arial' >
                                    <h1></h1>
                                    <h1>Warning</h1>
                                    <p>HTML entry is not allowed on that page.</p>
                                    <p>Please make sure that your entries do not contain any angle brackets like &lt; or &gt;.</p>
                                    <button class='btnmaintenance' onclick='javascript:back()'>Back</button>
                                </div>
                            </form>
                        </body>
                    </html>
                    ");
                Response.End();
            }
        }

        public void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var hasPostParams = (Request.QueryString["__EVENTTARGET"] ??
                               Request.QueryString["__VIEWSTATE"] ??
                               Request.QueryString["__EVENTARGUMENT"] ??
                               Request.QueryString["__EVENTVALIDATION"]) != null;

            if (hasPostParams)
            {
                //log error
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            BLL _BLL = new BLL();

            if (_BLL.DeleteActiveSessionBySessionId(Convert.ToString(Session["SessionID"])) == false)
            {
            }
            else
            {
                _BLL.RemoveFromCache("FilterActiveSession");
                _BLL.RemoveFromCache("GetActiveSession" + Convert.ToString(Session["EmployeeUserID"]));
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            if (Server != null)
            {
                //BLL _BLL = new BLL();

                //if (_BLL.DeleteActiveSessionBySessionId("ALL") == false)
                //{
                //}
                //else
                //{
                //    _BLL.RemoveFromCache("FilterActiveSession");
                //    _BLL.RemoveFromCache("GetActiveSession");
                //}
            }
        }
    }
}