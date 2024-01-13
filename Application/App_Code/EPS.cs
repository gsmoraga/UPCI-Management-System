using System;
using System.Web;


public class EPS
{
    public static string workflow_status
    {
        get
        {
            if (HttpContext.Current.Session["WorkflowStatus"] != null)
                return Convert.ToString(HttpContext.Current.Session["WorkflowStatus"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["WorkflowStatus"] = value;
        }
    }

    public static string file_name
    {
        get
        {
            if (HttpContext.Current.Session["FileName"] != null)
                return Convert.ToString(HttpContext.Current.Session["FileName"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["FileName"] = value;
        }
    }

    public static Byte[] attachment
    {
        get
        {
            if (HttpContext.Current.Session["Attachment"] != null)
                return (Byte[])HttpContext.Current.Session["Attachment"];
            else return null;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["Attachment"] = value;
        }
    }


    public static string file_code
    {
        get
        {
            if (HttpContext.Current.Session["FileCode"] != null)
                return Convert.ToString(HttpContext.Current.Session["FileCode"]);
            else return string.Empty;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["FileCode"] = value;
        }
    }

    public static int page_index
    {
        get
        {
            if (HttpContext.Current.Session["LoanInquiryPageIndex"] != null)
                return Convert.ToInt32(HttpContext.Current.Session["LoanInquiryPageIndex"]);
            else return 0;
        }
        set
        {
            if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["LoanInquiryPageIndex"] = value;
        }
    }
}
