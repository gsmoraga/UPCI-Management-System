using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class group_user_edit : System.Web.UI.Page
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

                                LoadUserGroupDetails(Maintenance.entry_code);
                            }
                        }
                    }
                }

            }
        }

        protected void LoadUserGroupDetails(string code)
        {
            if (_BLL.GetUserGroup(code) == false)
            { }
            else
            {
                LoadTreeView(tvAccessRightsBackend, Maintenance.code, "0");
                LoadTreeView(tvAccessRightsFrontend, Maintenance.code, "1");
                LoadTreeView(tvAccessRightsReports, Maintenance.code, "2");

                lblCode.Text = Maintenance.code;
                txtDescription.Text = Maintenance.description;
                lblUserList.Text = Maintenance.user_list;
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                Response.Redirect("group-user-search.aspx", false);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (_BLL.SessionIsActive(this))
            {
                string accessRights = "";
                StringBuilder builder = new StringBuilder();

                foreach (TreeNode item in tvAccessRightsBackend.CheckedNodes)
                {
                    builder.Append(item.Value + ",");
                }
                foreach (TreeNode item in tvAccessRightsFrontend.CheckedNodes)
                {
                    builder.Append(item.Value + ",");
                }
                foreach (TreeNode item in tvAccessRightsReports.CheckedNodes)
                {
                    builder.Append(item.Value + ",");
                }

                accessRights = Convert.ToString(builder);

                if (accessRights != "")
                {
                    if (_BLL.EditUserGroup(lblCode.Text, txtDescription.Text, Employee.user_id, accessRights) == false)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Unable to update the user group.', 'error');", true);
                    }
                    else
                    {
                        string transactionReferenceNumber = "";
                        if (_BLL.AddAuditLogEntry(Employee.user_id, Maintenance.content_code, "Edit", "Code: " + lblCode.Text, Request.UserHostAddress.ToString()))
                            transactionReferenceNumber = "UPCI-" + DateTime.Now.ToString("MMddyy") + "-" + DateTime.Now.ToString("HHmm") + "-" + DateTime.Now.ToString("ssff");

                        ScriptManager.RegisterStartupScript(this, GetType(), "Script", "transactionAlert('User group has been updated.','" + transactionReferenceNumber + "');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Script", "Swal.fire('Error encountered!', 'Please tick at least one of the access rights.', 'error');", true);
                }
            }
        }
    }
}