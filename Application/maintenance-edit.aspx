<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="maintenance-edit.aspx.cs" Inherits="Template.maintenance_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="contents/js/treeviewcheckbox-style.js"></script>
    <script type="text/javascript" src="contents/js/treeview-check-uncheck.js"></script>
    <script type="text/javascript">

        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })

    </script>
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
                            <asp:Label runat="server" ID="lblHeader" Font-Bold="true" Font-Size="X-Large" CssClass="custom-header"></asp:Label></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Maintenance</li>
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
                    <asp:Panel ID="codeDescCard" runat="server" Visible="false">
                        <div class="card card-primary">
                            <div class="card-header">
                                <h3 class="card-title">
                                    <asp:Label ID="lblCardTitle" runat="server"></asp:Label>
                                </h3>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="form-group">
                                    <label for="txtCode" id="lblCode" runat="server">Code</label>
                                    <asp:TextBox runat="server" ID="txtCode" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtCode" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revCode" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtCode" ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label for="txtDescription">Description</label>
                                    <asp:TextBox runat="server" ID="txtDescription" MaxLength="350" class="form-control" autocomplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtDescription" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revDescription" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtDescription" ValidationExpression="^[a-zA-Z0-9\s.,\-()]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label for="ddCode" id="lblCode2" runat="server">Code</label>
                                    <asp:DropDownList ID="ddCode" runat="server" CssClass="custom-select" autocomplete="off"></asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator66" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Please select a value." ControlToValidate="ddCode" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="ddBranch">Region</label>
                                    <asp:DropDownList ID="ddRegion" runat="server" CssClass="custom-select" autocomplete="off">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Please select a value." ControlToValidate="ddRegion" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="txtCodeDescEmail">Email</label>
                                    <asp:TextBox runat="server" ID="txtCodeDescEmail" MaxLength="50" class="form-control" autocomplete="off" placeholder="Optional"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator44" runat="server" ValidationGroup="codeDescValidation" SetFocusOnError="true"
                                        ErrorMessage="Invalid email." ControlToValidate="txtCodeDescEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->
                        <div class="row">
                            <div class="col-12">
                                <a href="#" class="btn btn-secondary">Cancel</a>
                                <input type="submit" value="Save Changes" class="btn btn-success float-right">
                            </div>
                        </div>
                    </asp:Panel>


                    <!-- User Maintenance -->
                    <asp:Panel ID="userCard" runat="server" Visible="false">
                        <div class="card card-primary">
                            <div class="card-header">
                                <h3 class="card-title">User</h3>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="form-group">
                                    <label for="txtCode" id="Label1" runat="server">User ID</label>
                                    <div>
                                        <asp:TextBox runat="server" ID="txtUserId" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="userValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtUserId" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="UserIDValidator" runat="server" ValidationGroup="userValidation"
                                            ErrorMessage="Must be alphanumeric." ControlToValidate="txtUserId" ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtEmployeeNumber">Employee Number</label>
                                    <div>
                                        <asp:TextBox runat="server" ID="txtEmployeeNumber" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="userValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtEmployeeNumber" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="userValidation"
                                            ErrorMessage="Must be numeric and have at least four digits." ControlToValidate="txtEmployeeNumber" ValidationExpression="^[0-9]{4,}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtEmployeeNumber">First Name</label>
                                    <div>
                                        <asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="userValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtEmployeeNumber" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="userValidation"
                                            ErrorMessage="Must be numeric and have at least four digits." ControlToValidate="txtEmployeeNumber" ValidationExpression="^[0-9]{4,}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>



                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->
                        <div class="row">
                            <div class="col-12">
                                <a href="#" class="btn btn-secondary">Cancel</a>
                                <input type="submit" value="Save Changes" class="btn btn-success float-right">
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>

        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
