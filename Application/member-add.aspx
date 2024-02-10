<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="member-add.aspx.cs" Inherits="Template.add_member_form" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Maan Contents Template -->
    <link rel="stylesheet" type="text/css" href="contents/css/jquery-ui.min.css" />
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <script type="text/javascript" src="contents/js/main.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfMembershipNumber" runat="server" />
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>
                            <asp:Label ID="contentHeader" runat="server"></asp:Label></h1>
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
            <div class="row">
                <div class="col-md-6">
                    <div id="divCard" runat="server" class="card card-primary" visible="false">
                        <div class="card-header">
                            <h3 class="card-title">General Information</h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <div>
                                        <label for="txtFirstName">First Name</label>
                                        <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" MaxLength="50" autocomplete="false"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:RequiredFieldValidator ID="reqFirstName" runat="server" ValidationGroup="memberValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtFirstName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revFirstName" runat="server" ValidationGroup="memberValidation"
                                            ErrorMessage="Only alphabetic charactes, periods, and hypens are allowed." ControlToValidate="txtFirstName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="txtMiddleName">Middle Name</label>
                                    <asp:TextBox ID="txtMiddleName" CssClass="form-control" MaxLength="50" runat="server" AutoComplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqMiddleName" runat="server" ValidationGroup="memberValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtMiddleName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMiddleName" runat="server" ValidationGroup="memberValidation"
                                        ErrorMessage="Only alphabetic charactes, periods, and hypens are allowed." ControlToValidate="txtMiddleName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="txtLastName">Last Name</label>
                                    <asp:TextBox ID="txtLastName" CssClass="form-control" MaxLength="50" runat="server" AutoComplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqLastName" runat="server" ValidationGroup="memberValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtLastName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revLastName" runat="server" ValidationGroup="memberValidation"
                                        ErrorMessage="Only alphabetic charactes, periods, and hypens are allowed." ControlToValidate="txtLastName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label for="inputStatus">Gender</label>
                                    <asp:DropDownList ID="ddGender" CssClass="form-control custom-select" runat="server">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="reqGender" runat="server" ValidationGroup="memberValidation"
                                        ErrorMessage="Required field." ControlToValidate="ddGender" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="txtBirthday">Birthday</label>
                                    <asp:TextBox ID="txtBirthday" CssClass="form-control datepicker" runat="server" AutoComplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqBirthdate" runat="server" ValidationGroup="memberValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtBirthday" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revBirthdate" runat="server" ValidationGroup="memberValidation"
                                        ErrorMessage="Must be of the format MM/DD/YYYY." ControlToValidate="txtBirthday" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputProjectLeader">Email</label>
                                <asp:TextBox ID="txtEmail" CssClass="form-control" MaxLength="50" runat="server" AutoComplete="false" placeholder="Optional"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationGroup="memberValidation"
                                    ErrorMessage="Invalid email." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtMobileNumber">Mobile Number</label>
                                <asp:TextBox ID="txtMobileNumber" CssClass="form-control" MaxLength="50" runat="server" AutoComplete="false" placeholder="Optional"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revMobileNumber" runat="server" ValidationGroup="memberValidation"
                                    ErrorMessage="Invalid mobile number." ControlToValidate="txtMobileNumber" ValidationExpression="(\+?\d{2}?\s?\d{3}\s?\d{3}\s?\d{4})|([0]\d{3}\s?\d{3}\s?\d{4})" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <div class="col-md-6">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Church Information</h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label for="ddMinistry">Ministry</label>
                                    <asp:DropDownList ID="ddMinistry" CssClass="form-control custom-select" OnSelectedIndexChanged="ddMinistry_SelectedIndexChanged" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="ddMinistryDepartment">Ministry Department</label>
                                    <asp:DropDownList ID="ddMinistryDepartment" CssClass="form-control custom-select" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <label for="ddCellGroup">Cell Status</label>
                                    <asp:DropDownList ID="ddCellGroup" CssClass="form-control custom-select" runat="server">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="rfvCellGroup" runat="server" ValidationGroup="memberValidation"
                                        ErrorMessage="Required field." ControlToValidate="ddCellGroup" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="ddBaptismalStatus">Baptismal Status</label>
                                    <asp:DropDownList ID="ddBaptismalStatus" CssClass="form-control custom-select" runat="server">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="rfvBaptismalStatus" runat="server" ValidationGroup="memberValidation"
                                        ErrorMessage="Required field." ControlToValidate="ddBaptismalStatus" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-md-4">
                                    <label for="ddPepsol">PEPSOL Level</label>
                                    <asp:DropDownList ID="ddPepsol" CssClass="form-control custom-select" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="rfvPepsol" runat="server" ValidationGroup="memberValidation"
                                        ErrorMessage="Required field." ControlToValidate="ddPepsol" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDateFirstAttend">Date First Attend</label>
                                <asp:TextBox ID="txtDateFirstAttend" CssClass="form-control datepicker" runat="server" placeholder="Optional"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revDatedFirstAttend" runat="server" ValidationGroup="memberValidation"
                                    ErrorMessage="Must be of the format MM/DD/YYYY." ControlToValidate="txtDateFirstAttend" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="ddStatus">Status</label>
                                <asp:DropDownList ID="ddStatus" CssClass="form-control custom-select" runat="server">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator InitialValue="0" ID="rfvStatus" runat="server" ValidationGroup="memberValidation"
                                    ErrorMessage="Required field." ControlToValidate="ddStatus" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-secondary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
                    <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-success float-right" OnClick="btnSubmit_Click"
                        OnClientClick="if(Page_ClientValidate('memberValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}" CausesValidation="true" ValidationGroup="memberValidation">Add</asp:LinkButton>
                </div>
            </div>
        </section>
        <!-- /.content -->

        <br />
    </div>

</asp:Content>
