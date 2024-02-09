using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class user_edit : System.Web.UI.Page
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
                                #region Titles
                                contentHeader.Text = Maintenance.content_description + " Maintenance";
                                mainBreadcrumb.Text = Maintenance.content_description;
                                subItemBreadcrumb.Text = Maintenance.mode;
                                cardTitle.Text = Maintenance.mode + " " + Maintenance.content_description;
                                #endregion

                                LoadUserDetails(Maintenance.entry_code);
                                _BLL.GetMinistryDropdown(ddMinistry, "--Select--");
                                ddMinistry_SelectedIndexChanged(null, e);
                                _BLL.GetUserGroupDropDown(ddUserGroup, "--Select--");
                            }
                        }
                    }
                }

            }
        }

        protected void LoadUserDetails(string userID)
        {
            if (_BLL.GetUser(userID) == false)
            { }
            else
            {
                lblMemberID.Text = Maintenance.member_id;
                lblUserID.Text = Maintenance.user_id;
                txtFirstName.Text = Maintenance.first_name;
                txtMiddleName.Text = Maintenance.middle_name;
                txtLastName.Text = Maintenance.last_name;
                ddUserGroup.SelectedValue = Maintenance.user_group;
                ddMinistry.SelectedValue = Maintenance.ministry_code;
                ddMinistryDepartment.SelectedValue = Maintenance.ministry_dept_code;
                txtEmail.Text = Maintenance.email;
                txtMobileNumber.Text = Maintenance.mobile_number;
                ddStatus.SelectedValue = Maintenance.status;
                DateTime dateProfile = (DateTime)Maintenance.profile_expiration_date;
                if (dateProfile != Convert.ToDateTime("1900-01-01"))
                    txtProfileExpirationUser.Text = dateProfile.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                else
                    txtProfileExpirationUser.Text = "";
            }
        }

        protected void ddMinistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                _BLL.GetMinistryDepartmentDropdown(ddMinistryDepartment, "--Select--", ddMinistry.SelectedValue);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Boolean result = false;
                result = _BLL.EditUser(lblUserID.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, ddUserGroup.SelectedValue, ddMinistryDepartment.SelectedValue, ddMinistry.SelectedValue, txtProfileExpirationUser.Text, txtEmail.Text, txtMobileNumber.Text, ddStatus.SelectedValue);

                if (result == false)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to update the entry.', 'error');", true);
                }
                else
                {
                    if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, Maintenance.mode, "Code: " + Maintenance.entry_code, Request.UserHostAddress.ToString()) == false)
                    { }
                    else
                    {

                        string transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmm") + "-" + DateTime.Now.ToString("ssff");
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('Entry has been updated.','" + transactionReferenceNumber + "');", true);
                    }

                }
            }
        }

        #endregion

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
            //if (ddUserGroup.SelectedValue != "0")
            //{
            //    tvAccessRightsModal.Nodes.Clear();
            //    LoadTreeView(tvAccessRightsModal, ddUserGroup.SelectedValue, "All", true);

            //    tvAccessRightsModal.ExpandAll();
            //    accessRightsModalTitle.InnerText = ddUserGroup.SelectedItem.Text + " Access Rights";

            //    lbViewUserGroup.Visible = true;
            //}
            //else
            //{
            //    lbViewUserGroup.Visible = false;
            //}
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
    }
}