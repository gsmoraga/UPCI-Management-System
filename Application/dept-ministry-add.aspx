<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="dept-ministry-add.aspx.cs" Inherits="Template.ministry_dept_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Maan Contents Template -->
    <link rel="stylesheet" type="text/css" href="contents/css/jquery-ui.min.css" />
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <script type="text/javascript" src="contents/js/main.js"></script>
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
                            <li class="breadcrumb-item"><asp:Label ID="mainBreadcrumb" runat="server"></asp:Label></li>
                            <li class="breadcrumb-item active"><asp:Label ID="subItemBreadcrumb" runat="server"></asp:Label></li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card card-primary" id="cardMaintenance" runat="server">
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
                                <label for="txtFirstName">Code</label>
                                <div>
                                    <asp:TextBox ID="txtCode" CssClass="form-control" runat="server" MaxLength="50" autocomplete="off"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtCode" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revCode" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtCode" ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtMiddleName">Description</label>
                                <div>
                                    <asp:TextBox ID="txtDescription" CssClass="form-control" MaxLength="350" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtDescription" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revDescription" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtDescription" ValidationExpression="^[a-zA-Z0-9\s.,\-()]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtFirstName">Ministry</label>
                                <div>
                                    <asp:DropDownList ID="ddMinistry" runat="server" CssClass="custom-select"></asp:DropDownList>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Required field." ControlToValidate="ddMinistry" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-6">
                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-secondary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
                    <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-primary float-right" OnClick="btnSubmit_Click"
                        OnClientClick="if(Page_ClientValidate('codeDescValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}" CausesValidation="true" ValidationGroup="codeDescValidation">Save</asp:LinkButton>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>
</asp:Content>
