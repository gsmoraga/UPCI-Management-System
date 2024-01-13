<%@ Page Title="" Language="C#" MasterPageFile="~/UPCI.Master" AutoEventWireup="true"
    CodeBehind="view-maintenance.aspx.cs" Inherits="Template.view_maintenance" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="contents/css/gridview-pager.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>


    <%--<style type="text/css">
        .dropdown-item:hover {
            color: #FFFFFF;
            background-color: #6777ef !important;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div ondragstart="return false" draggable="false">
        <div class="row justify-content-center m-1">
            <div class="col-md-10 text-md-center">
                <asp:Label runat="server" ID="lblHeader" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <br />
                &nbsp;
            </div>
        </div>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="lbSearch">
            <div class="row justify-content-center m-2 ">
                <div class="col-md-12 text-md-left card-body">
                    <div id="divSearch" runat="server" visible="false" class="col-md-12">
                        <div class="form-group row align-items-center mb-2">
                            <label for="txtCode" class="col-md-4 form-label text-md-right" id="lblCode" runat="server">
                                Code</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtCode" MaxLength="50" autocomplete="off" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="CodeValidation" runat="server" ValidationGroup="searchValidation"
                                    ErrorMessage="Must be alphanumeric." ControlToValidate="txtCode" ValidationExpression="^[a-zA-Z0-9\s]*$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center mb-2" id="divDescription" runat="server">
                            <label for="txtDescription" class="col-md-4 form-label text-md-right" id="lblDescription"
                                runat="server">
                                Description</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtDescription" MaxLength="50" autocomplete="off"
                                    class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="searchValidation"
                                    ErrorMessage="Must be alphanumeric." ControlToValidate="txtDescription" ValidationExpression="^[a-zA-Z0-9\s]*$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div id="divIndividualName" runat="server" visible="false">
                            <div class="form-group row align-items-center mb-2">
                                <label for="txtLastName" class="col-md-4 col-form-label text-md-right">
                                    Last Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtLastName" MaxLength="50" autocomplete="off"
                                        class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="searchValidation"
                                        ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed."
                                        ControlToValidate="txtLastName" ValidationExpression="[ña-zA-Z.\s-]+$"
                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group row align-items-center mb-2">
                                <label for="txtFirstName" class="col-md-4 col-form-label text-md-right">
                                    First Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" autocomplete="off"
                                        class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="searchValidation"
                                        ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed."
                                        ControlToValidate="txtFirstName" ValidationExpression="[ña-zA-Z.\s-]+$"
                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group row align-items-center mb-2">
                                <label for="txtMiddleName" class="col-md-4 col-form-label text-md-right">
                                    Middle Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtMiddleName" MaxLength="50" autocomplete="off"
                                        class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="searchValidation"
                                        ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed."
                                        ControlToValidate="txtMiddleName" ValidationExpression="[ña-zA-Z.\s-]+$"
                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row align-items-center mb-2" id="divUserGroup" runat="server" visible="false">
                            <label for="ddUserGroup" class="col-md-4 col-form-label text-md-right">
                                User Group</label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddUserGroup" CssClass="form-select">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row align-items-center mb-2" id="divDivision" runat="server" visible="false">
                            <label for="ddDivision" class="col-md-4 col-form-label text-md-right">
                                Division</label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddDivision" CssClass="form-select">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row align-items-center mb-2" id="divDepartment" runat="server" visible="false">
                            <label for="ddDepartment" class="col-md-4 col-form-label text-md-right">
                                Department</label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddDepartment" CssClass="form-select">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row align-items-center mb-2" id="divBranch" runat="server" visible="false">
                            <label for="ddBranch" class="col-md-4 col-form-label text-md-right">
                                Branch</label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddBranch" CssClass="form-select">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row align-items-center mb-2" id="divStatus" runat="server" visible="false">
                            <label for="ddStatus" class="col-md-4 col-form-label text-md-right">
                                Status</label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddStatus" CssClass="form-select">
                                    <asp:ListItem Value="-1">All</asp:ListItem>
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">Disabled</asp:ListItem>
                                    <asp:ListItem Value="3">Expired</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8 offset-md-4 text-md-left mr-1">
                        <asp:LinkButton class="btn btn-primary mr-2" runat="server" ID="lbSearch" OnClick="lbSearch_Click"
                            OnClientClick="if(Page_ClientValidate('searchValidation')) {if(this.value === 'Searching...') { return false; } else { this.value = 'Searching...'; }}"
                            CausesValidation="true" ValidationGroup="searchValidation" Visible="false"><i class="bi bi-search"></i>&nbsp;&nbsp;Search</asp:LinkButton>
                        <asp:LinkButton class="btn btn-primary mr-2" runat="server" ID="lbRefresh" OnClick="lbRefresh_Click"><i class="bi bi-arrow-clockwise"></i>&nbsp;&nbsp;Refresh</asp:LinkButton>
                        <br />
                        &nbsp;
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div class="row justify-content-center" id="divExport" runat="server" visible="false">
            <div class="col-md-10">
                <div class="row justify-content-center">
                    <div class="disappear pr-0">
                        &nbsp;
                    </div>
                    <div class="col-md-10 m-3">
                        <div class="float-right">
                            <div class="dropdown">
                                <button class="btn btn-success dropdown-toggle" type="button" id="btnExport" data-toggle="dropdown"
                                    aria-haspopup="true" aria-expanded="false">
                                    <i class="fas fa-save"></i>&nbsp;&nbsp;Save As...
                                </button>
                                <div class="dropdown-menu" aria-labelledby="btnExport">
                                    <asp:LinkButton class="dropdown-item" runat="server" ID="lbExportExcel" OnClick="lbExportExcel_Click"><i class="bi bi-file-excel-fill text-success"></i>&nbsp;&nbsp;Excel</asp:LinkButton>
                                    <asp:LinkButton class="dropdown-item" runat="server" ID="lbExportPdf" OnClick="lbExportPdf_Click"><i class="bi bi-file-pdf-fill text-danger"></i>&nbsp;&nbsp;PDF</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row justify-content-center m-1">
            <div class="col-md-10 text-md-center table-responsive">
                <div class="row justify-content-center">
                    <div id="divDeleteCheckbox" runat="server" visible="false" class="disappear pr-0 ml-n3 mr-n3 col-md-1 transparent-border">
                        <asp:GridView ID="gvCheckBox" runat="server" AllowPaging="True" CssClass="table "
                            ShowFooter="true" AutoGenerateColumns="false" GridLines="None" CellPadding="4"
                            PageSize="10" ForeColor="#333333">
                            <FooterStyle BackColor="White" Font-Bold="True" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="White" Font-Bold="True" HorizontalAlign="Right" />
                            <RowStyle BackColor="White" HorizontalAlign="Right" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="DeleteCheckbox" runat="server" ToolTip="Select" />&nbsp;
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-10">
                        <asp:GridView ID="gvMaintenance" runat="server" AllowPaging="True" CssClass="table table-striped"
                            GridLines="None" CellPadding="4" PageSize="10" ForeColor="#333333" AllowSorting="true"
                            OnPageIndexChanging="gvMaintenance_PageIndexChanging" OnRowDataBound="gvMaintenance_RowDataBound"
                            OnRowCreated="gvMaintenance_OnRowCreated" OnSorting="gvMaintenance_Sorting" PagerSettings-Mode="NumericFirstLast"
                            PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#0A9D4E" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#6777ef" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
                            <PagerStyle BackColor="#DEE2E6" HorizontalAlign="Left" CssClass="gridview-pager"
                                Font-Size="Large" />
                            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" />
                            <EmptyDataTemplate>
                                <label style="color: Red; font-size: large">
                                    No records found.</label>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# Eval("Code")%>' ToolTip="View"
                                            Text="" OnClick="lbView_Click" class="mr-2"><i class="bi bi-eye-fill text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("Code")%>' ToolTip="Edit"
                                            Text="" OnClick="lbEdit_Click" Visible="false" class="mr-2"><i class="bi bi-pencil-square text-primary" style="text-decoration:none"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("Code")%>'
                                            ToolTip="Delete" OnClientClick="return deleteAlert(this);" Text="" OnClick="lbDelete_Click"
                                            Visible="false" class="mr-2"><i class="bi bi-trash-fill text-danger" style="text-decoration:none"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbUnlock" runat="server" CommandArgument='<%# Eval("Code")%>'
                                            ToolTip="Unlock" OnClientClick="return unlockUserAlert(this);" Text="" OnClick="lbUnlock_Click"
                                            Visible="false" class="mr-2"><i class="bi bi-unlock-fill text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbResetPassword" runat="server" CommandArgument='<%# Eval("Code")%>'
                                            ToolTip="Reset Password" OnClientClick="return resetPasswordAlert(this);" Text=""
                                            OnClick="lbResetPassword_Click" Visible="false" class="mr-2"><i class="bx bx-reset text-success" style="text-decoration:none"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbRemoveSession" runat="server" CommandArgument='<%# Eval("Code")%>'
                                            ToolTip="Remove Session" OnClientClick="return deleteAlert(this);" Text="" OnClick="lbRemoveSession_Click"
                                            Visible="false" class="mr-2"><i class="bi bi-ban-fill text-danger" style="text-decoration:none"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div id="divDeleteSelectedButton" runat="server" visible="false" class="row justify-content-center">
                    <div>
                        &emsp;&emsp;
                    </div>
                    <div class="disappear col-md-10 text-left mb-3">
                        <asp:LinkButton runat="server" ID="lbDeleteSelected" OnClick="lbDeleteSelected_Click"
                            OnClientClick="return deleteAlert(this);" class="btn btn-danger"><i class="bi bi-trash"></i>&nbsp;&nbsp;Delete</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
