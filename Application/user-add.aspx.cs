using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class user_add : System.Web.UI.Page
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
                                if (accessRights.Contains("&m" + Maintenance.content_code + "a,"))
                                {
                                    #region Validation
                                    UserIDValidator.ValidationExpression = "^[a-zA-Z0-9][^" + Maintenance.restricted_username_special_characters + "]*$";
                                    UserIDValidator.ErrorMessage = "Must be alphanumeric and without the " + Maintenance.restricted_username_special_characters + " special characters.";
                                    #endregion
                                    _BLL.GetApplicationParameters();
                                    userCard.Visible = true;
                                    
                                }

                                #region Titles
                                contentHeader.Text = Maintenance.content_description;
                                mainBreadcrumb.Text = Maintenance.content_description;
                                subItemBreadcrumb.Text = Maintenance.mode;
                                cardTitle.Text = Maintenance.mode + " " + Maintenance.content_description+ " Information";
                                #endregion

                                _BLL.GetMinistryDropdown(ddMinistry, "--Select--");
                                ddMinistry_SelectedIndexChanged(null,null);
                                //_BLL.GetMinistryDepartmentDropdown(ddMinistryDepartment, "--Select--", "0");
                                _BLL.GetMemberDropdown(ddMemberID, "--Select--");
                                _BLL.GetUserGroupDropDown(ddUserGroup, "--Select--");
                            }
                        }
                    }
                }
                else
                {
                    
                }
            }
        }

        #region Link Buttons
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Response.Redirect("user-search.aspx", false);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                DataTable dt = new DataTable();
                dt = _DAL.CheckExistingUser(txtUserId.Text);

                if (Convert.ToInt16(dt.Rows[0][0]) == 0)
                {
                    GenerateRandomStrings();
                    string randomStrings = Convert.ToString(ViewState["randomStrings"]);
                    if (_BLL.AddUser(ddMemberID.SelectedValue, txtUserId.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, ddUserGroup.SelectedValue, ddMinistry.SelectedValue, ddMinistryDepartment.SelectedValue, txtProfileExpirationUser.Text, txtEmail.Text, txtMobileNumber.Text, Convert.ToString(ViewState["randomStrings"]), ddStatus.SelectedValue, Employee.user_id) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to add the user.', 'error');", true);
                    }
                    else
                    {

                        string transactionReferenceNumber = "";
                        if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, Maintenance.mode, "User ID: " + txtUserId.Text, Request.UserHostAddress.ToString()))
                            transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmm") + "-" + DateTime.Now.ToString("ssff");

                        //ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('User has been added.','" + transactionReferenceNumber + "');", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('User has been added.<br/> NOTE: Copy your password below.','Password: " + Convert.ToString(ViewState["randomStrings"]) + "','success');", true);

                        ClearValues();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Code is already in use.', '', 'error');", true);
                }
            }
        }
        #endregion
        protected void ddMemberID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                if (_BLL.GetMemberDeatils(ddMemberID.SelectedValue) == false)
                { }
                else
                {
                    txtUserId.Text = Member.member_id;
                    txtFirstName.Text = Member.first_name;
                    txtMiddleName.Text = Member.middle_name;
                    txtLastName.Text = Member.last_name;
                    txtEmail.Text = Member.email;
                    //lblGender.Text = Member.gender;
                    //lblBirthday.Text = Member.birthday;
                    txtMobileNumber.Text = Member.mobile_number;
                    ddMinistry.SelectedValue = Member.ministry_code;
                    ddMinistryDepartment.Text = Member.ministry_dept_code;
                }
            }
        }
        protected void ddMinistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                _BLL.GetMinistryDepartmentDropdown(ddMinistryDepartment, "--Select--", ddMinistry.SelectedValue);
            }
        }

        #region User Group
        /**
        * Determines which child rows of the access rights tree will be displayed
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        private void GetChildRows(DataRow dataRow, TreeNode treeNode, List<string> ar, bool displayAccessOnly = false)
        {
            DataRow[] childRows = dataRow.GetChildRows("ChildRows");
            if (displayAccessOnly == false)
            {
                foreach (DataRow row in childRows)
                {
                    TreeNode childTreeNode = new TreeNode();
                    childTreeNode.Text = row["description"].ToString();
                    childTreeNode.Value = row["code"].ToString();
                    //display all child nodes
                    treeNode.ChildNodes.Add(childTreeNode);

                    if (ar.Contains(row["code"].ToString()))
                    {
                        childTreeNode.Checked = true;
                    }

                    if (row.GetChildRows("ChildRows").Length > 0)
                    {
                        GetChildRows(row, childTreeNode, ar, displayAccessOnly);
                    }
                }
            }
            else if (displayAccessOnly == true)
            {
                foreach (DataRow row in childRows)
                {
                    TreeNode childTreeNode = new TreeNode();
                    childTreeNode.ShowCheckBox = false;
                    childTreeNode.Text = row["description"].ToString();
                    childTreeNode.Value = row["code"].ToString();
                    childTreeNode.SelectAction = TreeNodeSelectAction.None;

                    if (ar.Contains(row["code"].ToString()))
                    {
                        childTreeNode.Checked = true;
                        treeNode.ChildNodes.Add(childTreeNode);
                    }

                    if (row.GetChildRows("ChildRows").Length > 0)
                    {
                        GetChildRows(row, childTreeNode, ar, displayAccessOnly);
                    }
                }
            }
        }
        /**
        * Loads the access rights tree for the User Group maintenance from the database
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void LoadTreeView(TreeView tv, string userGroupCode, string rootCode, bool displayAccessOnly = false)
        {
            if (_BLL.SessionIsActive(this))
            {
                DAL _DAL = new DAL();

                List<string> ar = _DAL.AccessRights(userGroupCode).ToList();
                DataSet ds = _DAL.Dataset_UserGroup(rootCode);

                foreach (DataRow level1DataRow in ds.Tables[0].Rows)
                {
                    if (displayAccessOnly == false)
                    {
                        if (string.IsNullOrEmpty(level1DataRow["parent_code"].ToString()))
                        {
                            TreeNode parentTreeNode = new TreeNode();
                            parentTreeNode.Text = level1DataRow["description"].ToString();
                            parentTreeNode.Value = level1DataRow["code"].ToString();
                            if (ar.Contains(level1DataRow["code"].ToString()))
                            {
                                parentTreeNode.Checked = true;
                            }
                            tv.Nodes.Add(parentTreeNode);
                            GetChildRows(level1DataRow, parentTreeNode, ar, displayAccessOnly);
                        }
                    }
                    else if (displayAccessOnly == true)
                    {
                        if (string.IsNullOrEmpty(level1DataRow["parent_code"].ToString()))
                        {
                            TreeNode parentTreeNode = new TreeNode();
                            parentTreeNode.ShowCheckBox = false;
                            parentTreeNode.Text = level1DataRow["description"].ToString();
                            parentTreeNode.Value = level1DataRow["code"].ToString();
                            parentTreeNode.SelectAction = TreeNodeSelectAction.None;
                            if (ar.Contains(level1DataRow["code"].ToString()))
                            {
                                parentTreeNode.Checked = true;
                                tv.Nodes.Add(parentTreeNode);
                                GetChildRows(level1DataRow, parentTreeNode, ar, displayAccessOnly);
                            }
                        }
                    }
                }
            }
        }

        protected void ddUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddUserGroup.SelectedValue != "0")
            {
                tvAccessRightsModal.Nodes.Clear();
                LoadTreeView(tvAccessRightsModal, ddUserGroup.SelectedValue, "All", true);

                tvAccessRightsModal.ExpandAll();
                accessRightsModalTitle.InnerText = ddUserGroup.SelectedItem.Text + " Access Rights";

                lbViewUserGroup.Visible = true;
            }
            else
            {
                lbViewUserGroup.Visible = false;
            }
        }

        /**
        * Redirects user to the selected user group's edit page
        * 
        * @since version 1.0 
        * @param object sender - reference to the object that raised the event
        * @param EventArgs e - contains the event data
        */
        protected void lbUserGroupShortcut_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                //Maintenance.content_code = VG.c_user_group;
                //Maintenance.bank_user_security = false;

                //if (_BLL.GetContentType(Maintenance.content_code) == false)
                //{
                //}
                //else
                //{
                //    Maintenance.code_filter = "";
                //    Maintenance.description_filter = "";
                //    Maintenance.page_index = 0;

                //    Maintenance.entry_code = ddUserGroup.SelectedValue;
                //    Maintenance.mode = "Edit";

                //    Response.Redirect("maintenance-parameters.aspx", false);
                //}
            }
        }
        #endregion
        protected void ClearValues()
        {
            txtUserId.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            ddUserGroup.SelectedIndex = -1;
            ddMinistry.SelectedIndex = -1;
            ddMinistryDepartment.SelectedIndex = -1;
            txtProfileExpirationUser.Text = "";
            txtEmail.Text = "";
            txtMobileNumber.Text = "";
        }
        protected void GenerateRandomStrings()
        {
            Random res = new Random();

            // String that contain both alphabets and numbers 
            String str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int stringlen = Convert.ToInt16(Maintenance.min_password_length);

            // Initializing the empty string 
            String randomstring = "";

            for (int i = 0; i < stringlen; i++)
            {

                // Selecting a index randomly 
                int x = res.Next(str.Length);

                // Appending the character at the  
                // index to the random alphanumeric string. 
                randomstring = randomstring + str[x];
            }

            ViewState["randomStrings"] = randomstring;
        }

        
    }
}