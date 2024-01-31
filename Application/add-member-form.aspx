<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="add-member-form.aspx.cs" Inherits="Template.add_member_form" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="contents/css/progress-map.css" rel="stylesheet" />
    <!-- Maan Contents Template -->
    <link rel="stylesheet" type="text/css" href="contents/css/jquery-ui.min.css" />
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <%--<script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>--%>
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
                        <h1>Membership Form</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Add Member</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- Main content -->
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-md-6">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">Personal Information</h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="txtFirstName">First Name</label>
                                <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" AutoComplete="false"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtMiddleName">Middle Name</label>
                                <asp:TextBox ID="txtMiddleName" CssClass="form-control" runat="server" AutoComplete="false"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtLastName">Last Name</label>
                                <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" AutoComplete="false"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="inputStatus">Gender</label>
                                <asp:DropDownList ID="ddGender" CssClass="form-control custom-select" runat="server">
                                    <asp:ListItem Value="">--Select One--</asp:ListItem>
                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="txtBirthday">Birthday</label>
                                <asp:TextBox ID="txtBirthday" CssClass="form-control datepicker" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="inputProjectLeader">Email</label>
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" AutoComplete="false" placeholder="Optional"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtMobileNumber">Mobile Number</label>
                                <asp:TextBox ID="txtMobileNumber" CssClass="form-control" runat="server" AutoComplete="false" placeholder="Optional"></asp:TextBox>
                            </div>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
                <div class="col-md-6">
                    <div class="card card-secondary">
                        <div class="card-header">
                            <h3 class="card-title">Church Details</h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="inputSpentBudget">Ministry</label>
                                <asp:DropDownList ID="ddMinistry" CssClass="form-control custom-select" runat="server">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="inputEstimatedDuration">Ministry Department</label>
                                <asp:DropDownList ID="ddDepartment" CssClass="form-control custom-select" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="txtDateFirstAttend">Date First Attend</label>
                                <asp:TextBox ID="txtDateFirstAttend" CssClass="form-control datepicker" runat="server" placeholder="Optional"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="inputStatus">Membership Status</label>
                                <asp:DropDownList ID="ddStatus" CssClass="form-control custom-select" runat="server">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="inputStatus">Cell Group</label>
                                <asp:DropDownList ID="ddCellGroup" CssClass="form-control custom-select" runat="server">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="inputStatus">Baptismal Status</label>
                                <asp:DropDownList ID="ddBaptismalStatus" CssClass="form-control custom-select" runat="server">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="inputStatus">PEPSOL Level</label>
                                <asp:DropDownList ID="ddPepsol" CssClass="form-control custom-select" runat="server">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Pre-Encounter</asp:ListItem>
                                    <asp:ListItem>Post Encounter</asp:ListItem>
                                    <asp:ListItem>School of Leaders 1</asp:ListItem>
                                    <asp:ListItem>School of Leaders 2</asp:ListItem>
                                    <asp:ListItem>School of Leaders 3</asp:ListItem>
                                </asp:DropDownList>
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
                    <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-success float-right" OnClick="btnSubmit_Click">Add Member</asp:LinkButton>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>

</asp:Content>
