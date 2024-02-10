using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class application_parameters : System.Web.UI.Page
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
                                #region Validation
                                revChurchName.ValidationExpression = Validation.RegexAlphanumericWithSpace;
                                revChurchName.ErrorMessage = Validation.ErrorMessageAlphanumericWithSpace;
                                revReportHeader.ValidationExpression = Validation.RegexAlphabeticWithSpace;
                                revReportHeader.ErrorMessage = Validation.ErrorMessageAlphabeticWithSpace;
                                #endregion

                                LoadApplicationParameters();

                                #region Titles
                                contentHeader.Text = Maintenance.content_description + " Maintenance";
                                mainBreadcrumb.Text = Maintenance.content_description;
                                subItemBreadcrumb.Text = Maintenance.mode;
                                cardTitle.Text = Maintenance.content_description;
                                #endregion
                            }
                        }
                    }
                }
            }
        }

        protected void lbSaveApplicationParameters_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (_BLL.EditApplicationParameters(txtWebsiteUrl.Text, "", "", "", txtEmail.Text,
                    txtChurchHotline.Text, txtChurchName.Text, txtProfileExpiration.Text, "", txtEmailEngineSender.Text,
                    txtMaxMobileDevices.Text, txtProfileExpiryReminder.Text, txtPasswordExpiryReminder.Text, txtReportHeader.Text, txtSpecialCharactersAllowed.Text,
                    txtSpecialCharactersNotAllowed.Text, txtTaskSummaryPurge.Text, txtMaxRecordCount.Text,
                    "", "", "", "") == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to update the Application Parameters.', 'error');", true);
                }
                else
                {
                    HttpContext.Current.Cache.Remove(("GetApplicationParameters").ToLower());

                    string transactionReferenceNumber = "";
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Edit", "", Request.UserHostAddress.ToString()))
                        transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmm") + "-" + DateTime.Now.ToString("ssff");

                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Application Parameters have been updated.','" + transactionReferenceNumber + "');", true);
                }
            }
        }


        protected void LoadApplicationParameters()
        {
            if (_BLL.SessionIsActive(this))
            {
                #region Load Application Parameters
                if (Maintenance.content_code == VG.c_application_parameters)
                {
                    txtWebsiteUrl.Text = Maintenance.website_url;
                    txtEmail.Text = Maintenance.church_email_address;
                    txtChurchHotline.Text = Maintenance.church_hotline;
                    txtChurchName.Text = Maintenance.church_name;
                    txtProfileExpiration.Text = Maintenance.profile_expiration_days;
                    txtEmailEngineSender.Text = Maintenance.email_engine_sender_address;
                    txtMaxMobileDevices.Text = Maintenance.max_allowed_mobile_devices;
                    txtProfileExpiryReminder.Text = Maintenance.profile_expiration_warning_days;
                    txtPasswordExpiryReminder.Text = Maintenance.password_expiration_warning_days;
                    txtReportHeader.Text = Maintenance.report_header;
                    txtSpecialCharactersAllowed.Text = Maintenance.allowed_special_characters_application;
                    txtSpecialCharactersNotAllowed.Text = Maintenance.restricted_username_special_characters;
                    txtTaskSummaryPurge.Text = Maintenance.task_summary_purge_days;
                    txtMaxRecordCount.Text = Maintenance.max_extractable_record_count;

                }
                #endregion
            }
        }


    }
}