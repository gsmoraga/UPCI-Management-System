<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="
    true"
    CodeBehind="user-add.aspx.cs" Inherits="Template.user_add" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Maan Contents Template -->
    <link rel="stylesheet" type="text/css" href="contents/css/jquery-ui.min.css" />
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <script type="text/javascript" src="contents/js/main.js"></script>
    <script type="text/javascript" src="contents/js/treeviewcheckbox-style.js"></script>
    <script type="text/javascript" src="contents/js/treeview-check-uncheck.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>
                            <asp:Label ID="contentHeader" runat="server"></asp:Label>
                        </h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="home.aspx">Home</a></li>
                            <li class="breadcrumb-item">
                                <asp:Label ID="mainBreadcrumb" runat="server"></asp:Label></li>
                            <li class="breadcrumb-item active">
                                <asp:Label ID="subItemBreadcrumb" runat="server"></asp:Label></li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="row" id="userCard" runat="server" visible="false">
                <div class="col-md-6">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">
                                <asp:Label ID="cardTitle" runat="server"></asp:Label>
                            </h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="txtUserId">Member ID</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddMemberID" runat="server" CssClass="custom-select" autocomplete="off"
                                        OnSelectedIndexChanged="ddMemberID_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtUserId">User ID</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtUserId" CssClass="form-control" runat="server" MaxLength="50" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtUserId" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="UserIDValidator" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtUserId" ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="ddUserGroup">User Group</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddUserGroup" runat="server" CssClass="custom-select" autocomplete="off"
                                        OnSelectedIndexChanged="ddUserGroup_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator63" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Please select a value." ControlToValidate="ddUserGroup" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6" runat="server" visible="false">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="lbViewUserGroup" runat="server" ToolTip="View access rights" data-toggle="modal" data-target="#accessRightsModal" Visible="false"
                                                Text="" class="mr-2"><i class="fa fa-eye icon text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddUserGroup" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>


                            </div>
                            <div class="form-group" runat="server" visible="false">
                                <label for="txtFirstName">Employee Number</label>
                                <div>
                                    <asp:TextBox ID="txtEmployeeNumber" CssClass="form-control" runat="server" MaxLength="50" autocomplete="off"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtEmployeeNumber" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Must be numeric and have at least four digits." ControlToValidate="txtEmployeeNumber" ValidationExpression="^[0-9]{4,}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName">First Name</label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtFirstName" CssClass="form-control" MaxLength="50" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtFirstName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed." ControlToValidate="txtFirstName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtMiddleName">Middle Name</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtMiddleName" MaxLength="50" class="form-control" autocomplete="off" placeholder="Optional"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed." ControlToValidate="txtMiddleName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtMiddleName">Last Name</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtLastName" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtLastName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed." ControlToValidate="txtLastName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <div class="col-md-6">
                    <div class="card card-secondary">
                        <div class="card-header">
                            <h3 class="card-title">Other Information</h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="txtEmail">Email</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="50" class="form-control" autocomplete="off" placeholder="Optional"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Invalid email." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtMobileNumber">Mobile Number</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtMobileNumber" MaxLength="50" class="form-control" autocomplete="off" placeholder="Optional"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Invalid mobile number." ControlToValidate="txtMobileNumber" ValidationExpression="(\+?\d{2}?\s?\d{3}\s?\d{3}\s?\d{4})|([0]\d{3}\s?\d{3}\s?\d{4})" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="ddMinistry">Minsitry</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddMinistry" runat="server" CssClass="custom-select" OnSelectedIndexChanged="ddMinistry_SelectedIndexChanged" AutoPostBack="true" autocomplete="off"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator64" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Please select a value." ControlToValidate="ddMinistry" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="ddMinistryDepartment">Minsitry Department</label>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="ddMinistryDepartment" runat="server" CssClass="custom-select" autocomplete="off"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Please select a value." ControlToValidate="ddMinistryDepartment" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtProfileExpirationUser">Profile Expiration Date</label>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="txtProfileExpirationUser" MaxLength="50" class="form-control datepicker" autocomplete="off" placeholder="(Leave blank if no expiration)"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Must be of the format MM/DD/YYYY." ControlToValidate="txtProfileExpirationUser" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtMobileNumber">Status</label>
                                <div class="col-md-8">
                                    <asp:DropDownList runat="server" ID="ddStatus" CssClass="custom-select">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="0">Disabled</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <!-- card body -->
                    </div>
                    <!-- card-->
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-secondary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
                    <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-primary float-right" OnClick="btnSubmit_Click"
                        OnClientClick="if(Page_ClientValidate('userValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}" CausesValidation="true" ValidationGroup="userValidation">Save</asp:LinkButton>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>
    <div class="modal fade" id="accessRightsModal" tabindex="-1" role="dialog" aria-labelledby="accessRightsModalTitle"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title" id="accessRightsModalTitle" runat="server">Access Rights</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="los-tree-view">
                                <asp:TreeView ID="tvAccessRightsModal" runat="server" onclick="OnTreeClick(event)" ImageSet="Custom" CollapseImageUrl="contents/images/caret-down.png" ExpandImageUrl="contents/images/caret-right.png" ShowCheckBoxes="All" ForeColor="Black" NodeIndent="30">
                                </asp:TreeView>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton class="btn btn-primary mr-2" runat="server" ID="lbUserGroupShortcut"
                                OnClick="lbUserGroupShortcut_Click" Visible="false">Edit User Group</asp:LinkButton>
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">
                                Close</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddUserGroup" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
