<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="group-user-edit.aspx.cs" Inherits="Template.group_user_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
                <div class="col-md-12">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">
                                <asp:Label ID="cardTitle" runat="server"></asp:Label></h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="lblCode">Code</label>
                                <div>
                                    <asp:Label ID="lblCode" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtDescription">Description</label>
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
                                <label for="ddMinistry">User List</label>
                                <div>
                                    <asp:Label ID="lblUserList" runat="server"></asp:Label>
                                </div>
                            </div>

                            <hr />

                            <div class="form-group row align-items-center">
                                <div class="col-md-12 text-md-center">
                                    Access Rights
                                </div>
                            </div>

                            <div class="form-group row justify-content-center">
                                <div class="col-md-10">
                                    <nav>
                                        <div class="nav nav-tabs" id="nav-tab" role="tablist">
                                            <a class="nav-item nav-link active" id="nav-backend-tab" data-toggle="tab" href="#backend-tab" role="tab" aria-controls="backend-tab" aria-selected="false">Backend</a>
                                            <a class="nav-item nav-link" id="nav-frontend-tab" data-toggle="tab" href="#frontend-tab" role="tab" aria-controls="frontend-tab" aria-selected="true">Frontend</a>
                                            <a class="nav-item nav-link" id="nav-reports-tab" data-toggle="tab" href="#reports-tab" role="tab" aria-controls="reports-tab" aria-selected="false">Reports</a>
                                        </div>
                                    </nav>
                                    <div class="tab-content card-body" id="nav-tab-content">
                                        <div id="backend-tab" class="tab-pane fade show active" role="tabpanel" aria-labelledby="nav-backend-tab">
                                            <div class="los-tree-view">
                                                <asp:TreeView ID="tvAccessRightsBackend" runat="server" onclick="OnTreeClick(event)" ImageSet="Custom" CollapseImageUrl="contents/images/caret-down.png" ExpandImageUrl="contents/images/caret-right.png" ShowCheckBoxes="All" ForeColor="Black" NodeIndent="30">
                                                </asp:TreeView>
                                            </div>
                                        </div>
                                        <div id="frontend-tab" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-frontend-tab">
                                            <div class="los-tree-view">
                                                <asp:TreeView ID="tvAccessRightsFrontend" runat="server" onclick="OnTreeClick(event)" ImageSet="Custom" CollapseImageUrl="contents/images/caret-down.png" ExpandImageUrl="contents/images/caret-right.png" ShowCheckBoxes="All" ForeColor="Black" NodeIndent="30">
                                                </asp:TreeView>
                                            </div>
                                        </div>
                                        <div id="reports-tab" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-reports-tab">
                                            <div class="los-tree-view">
                                                <asp:TreeView ID="tvAccessRightsReports" runat="server" onclick="OnTreeClick(event)" ImageSet="Custom" CollapseImageUrl="contents/images/caret-down.png" ExpandImageUrl="contents/images/caret-right.png" ShowCheckBoxes="All" ForeColor="Black" NodeIndent="30">
                                                </asp:TreeView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
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
                    <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-primary float-right"
                        OnClientClick="if(Page_ClientValidate('codeDescValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}" CausesValidation="true" ValidationGroup="codeDescValidation" OnClick="btnSave_Click">Save Changes</asp:LinkButton>
                </div>
            </div>
        </section>
        <br />
    </div>
</asp:Content>
