<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement.Master" AutoEventWireup="true"
    CodeBehind="view-report.aspx.cs" Inherits="Template.view_report" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="contents/js/bootstrap-select.min.js"></script>
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap-select.min.css" />

    <link rel="stylesheet" type="text/css" href="contents/css/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <script type="text/javascript" src="contents/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="contents/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <script type="text/javascript" src="contents/js/main.js"></script>

    <style type="text/css">
        .dropdown-menu .dropdown-item {
            white-space: nowrap;
        }
    </style>

    <%--<link rel="Stylesheet" href="contents/css/survey.css" />--%>
    <link rel="stylesheet" href="contents/css/yearpicker.css" />

    <script type="text/javascript" src="contents/js/yearpicker.js"></script>


 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center m-1">
        <div class="col-md-12 text-md-center">
            <asp:Label runat="server" ID="lblHeader" Font-Bold="true" Font-Size="X-Large" CssClass="custom-label">Reports</asp:Label>
            <br />
            &nbsp;
        </div>
    </div>
    <div class="row justify-content-center m-1">
        <div class="col-md-10">
            <div class="form-group row align-items-center">
                <label for="ddReport" class="col-md-4 col-form-label text-md-right">
                    Report</label>
                <div class="col-md-4">
                    <asp:DropDownList runat="server" ID="ddReport" class="form-select" OnSelectedIndexChanged="ddReport_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

    <div class="row justify-content-center" ondragstart="return false" draggable="false">
        <div class="col-md-12">
            <div class="card" id="auditLogCard" runat="server" visible="false">
                <div class="card-body">
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="lbAuditLog">
                        <div class="form-group row align-items-center">
                            <label for="lboxFrontend" class="col-md-4 col-form-label text-right">
                                Frontend</label>
                            <div class="col-md-6">
                                <asp:ListBox ID="lboxFrontend" runat="server" class="selectpicker" SelectionMode="Multiple"
                                    data-width="100%" data-selected-text-format="count>3" data-actions-box="true"></asp:ListBox>
                            </div>
                            <div class="offset-md-4 col-md-6">
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="lboxBackend" class="col-md-4 col-form-label text-right">
                                Backend</label>
                            <div class="col-md-6">
                                <asp:ListBox ID="lboxBackend" runat="server" class="selectpicker" SelectionMode="Multiple"
                                    data-width="100%" data-selected-text-format="count>3" data-actions-box="true"></asp:ListBox>
                            </div>
                            <div class="offset-md-4 col-md-6">
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="lboxFunction" class="col-md-4 col-form-label text-right">
                                Function</label>
                            <div class="col-md-6">
                                <asp:ListBox ID="lboxFunction" runat="server" class="selectpicker" SelectionMode="Multiple"
                                    data-width="100%" data-selected-text-format="count>5" data-actions-box="true">
                                    <asp:ListItem Value="Add" Selected="True">Add</asp:ListItem>
                                    <asp:ListItem Value="Delete" Selected="True">Delete</asp:ListItem>
                                    <asp:ListItem Value="Edit" Selected="True">Edit</asp:ListItem>
                                    <asp:ListItem Value="Search" Selected="True">Search</asp:ListItem>
                                    <asp:ListItem Value="View" Selected="True">View</asp:ListItem>
                                </asp:ListBox>
                            </div>
                            <div class="offset-md-4 col-md-6">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="auditLogValidation"
                                    ErrorMessage="Please select at least one." ControlToValidate="lboxFunction" ForeColor="Red"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtStartingDate" class="col-md-4 col-form-label text-md-right">
                                Starting Date</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtStartingDate" MaxLength="50" class="datepicker form-control"
                                    autocomplete="off" placeholder="Leave blank to start from the beginning"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationGroup="auditLogValidation"
                                    ErrorMessage="Must be of the format MM/DD/YYYY." ControlToValidate="txtStartingDate"
                                    ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtEndingDate" class="col-md-4 col-form-label text-md-right">
                                Ending Date</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtEndingDate" MaxLength="50" class="datepicker form-control"
                                    autocomplete="off" placeholder="Leave blank to end with the current date"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                    ValidationGroup="auditLogValidation" ErrorMessage="Must be of the format MM/DD/YYYY."
                                    ControlToValidate="txtEndingDate" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtUserIdAL" class="col-md-4 col-form-label text-md-right">
                                User ID</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtUserIdAL" MaxLength="50" class="form-control"
                                    autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationGroup="auditLogValidation"
                                    ErrorMessage="Must be alphanumeric." ControlToValidate="txtUserIdAL" ValidationExpression="^[a-zA-Z0-9]*$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-4 col-form-label text-md-right">
                                Content</label>
                            <div class="btn" data-toggle="collapse" href="#collapseAuditLogColumns" role="button"
                                aria-expanded="false" aria-controls="collapseAuditLogColumns">
                                <i class="large caret square down icon"></i>
                            </div>
                            <div id="collapseAuditLogColumns" class="collapse" style="padding-top: 6px">
                                <asp:CheckBoxList ID="auditLogColumns" runat="server">
                                    <asp:ListItem Value="1" Selected="True">&nbsp;&nbsp;Log Date</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">&nbsp;&nbsp;User ID</asp:ListItem>
                                    <asp:ListItem Value="3" Selected="True">&nbsp;&nbsp;Content</asp:ListItem>
                                    <asp:ListItem Value="4" Selected="True">&nbsp;&nbsp;Function</asp:ListItem>
                                    <asp:ListItem Value="5" Selected="True">&nbsp;&nbsp;Details</asp:ListItem>
                                    <asp:ListItem Value="6" Selected="True">&nbsp;&nbsp;Terminal ID</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            <div class="col-md-4">
                                <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="validateAuditLogColumns"
                                    ValidationGroup="auditLogValidation" ErrorMessage="Please select at least one."
                                    ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="col-md-4 offset-md-4">
                            <asp:LinkButton runat="server" class="btn btn-maan1" ID="lbAuditLog" OnClick="lbAuditLog_Click"
                                OnClientClick="if(Page_ClientValidate('auditLogValidation')) { if(this.value === 'Generating...') { return false; } else { this.value = 'Generating...'; }}"
                                Text="Generate" CausesValidation="true" ValidationGroup="auditLogValidation"></asp:LinkButton>
                        </div>
                    </asp:Panel>
                </div>
            </div>

            <div id="divGridView" runat="server">
                <div class="row justify-content-center m-1" id="divSRPExport" visible="false" runat="server">
                    <div class="col-md-12">
                        <div class="float-right">
                            <div class="dropdown">
                                <button class="btn btn-success dropdown-toggle" type="button" id="btnExport" data-toggle="dropdown"
                                    aria-haspopup="true" aria-expanded="false">
                                    <i class="save icon"></i>Save As...
                                </button>
                                <div class="dropdown-menu" aria-labelledby="btnExport">
                                    <asp:LinkButton class="dropdown-item" runat="server" ID="lbSRPExportExcel" OnClick="lbSRPExportExcel_Click"><i class="bi bi-file-excel-fill text-success"></i>Excel</asp:LinkButton>
                                    <%--<asp:LinkButton class="dropdown-item" runat="server" ID="lbSRPExportPdf" OnClick="lbSRPExportPdf_Click"><i class="file pdf icon red"></i>PDF</asp:LinkButton>--%>
                                </div>
                            </div>
                        </div>
                        <br />
                        &nbsp;
                    </div>
                </div>
                <div class="row justify-content-center m-1">
                    <div class="col-md-12 text-md-center table-responsive">
                        <asp:GridView ID="gvSurveyReport" runat="server" AllowPaging="True" CssClass="table table-striped"
                            GridLines="None" CellPadding="4" PageSize="10" ForeColor="#333333" AllowSorting="true"
                            OnPageIndexChanging="gvSurveyReport_PageIndexChanging" OnRowDataBound="gvSurveyReport_RowDataBound"
                            OnSorting="gvSurveyReport_Sorting" PagerSettings-Mode="NumericFirstLast" PagerSettings-FirstPageText="First" PagerSettings-Visible="false"
                            PagerSettings-LastPageText="Last">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#0A9D4E" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#185ECE" Font-Bold="True" ForeColor="black" HorizontalAlign="Left" />
                            <PagerStyle BackColor="#DEE2E6" HorizontalAlign="Left" CssClass="gridview-pager"
                                Font-Size="Large" />
                            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" />
                            <EmptyDataTemplate>
                                <label style="color: Red; font-size: large">
                                    No records found.</label>
                            </EmptyDataTemplate>
                            <Columns>
                            </Columns>
                        </asp:GridView>
                        <div id="divPager" runat="server" class="form-inline mb-3" visible="false">
                            <asp:LinkButton ID="lbFirstPage" runat="server" ToolTip="First" OnClick="lbFirstPage_Click"><i class="fast backward icon text-dark" style="text-decoration:none"></i></asp:LinkButton>
                            <asp:LinkButton ID="lbPreviousPage" runat="server" ToolTip="Previous" OnClick="lbPreviousPage_Click"><i class="backward icon text-dark" style="text-decoration:none"></i></asp:LinkButton>
                            |&nbsp;
                    Page&nbsp;
                    <asp:DropDownList ID="ddPageNumber" runat="server" CssClass="custom-select" AutoPostBack="true" OnSelectedIndexChanged="ddPageNumber_SelectedIndexChanged"></asp:DropDownList>&nbsp;
                    of&nbsp;
                    <asp:Label ID="lblTotalPageCount" runat="server" />
                            &nbsp;&nbsp;|&nbsp;
                    <asp:LinkButton ID="lbNextPage" runat="server" ToolTip="Next" OnClick="lbNextPage_Click"><i class="forward icon text-dark" style="text-decoration:none"></i></asp:LinkButton>
                            <asp:LinkButton ID="lbLastPage" OnClick="lbLastPage_Click" runat="server" ToolTip="Last"><i class="fast forward icon text-dark" style="text-decoration:none"></i></asp:LinkButton>
                            &emsp;
                    <asp:DropDownList ID="ddPageSize" runat="server" OnSelectedIndexChanged="ddPageSize_SelectedIndexChanged" CssClass="custom-select" AutoPostBack="true">
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                    </asp:DropDownList>
                            &emsp;|&emsp;
                    Total&nbsp;Count:&nbsp;<asp:Label ID="lblTotalRowCount" runat="server" />
                        </div>
                    </div>
                </div>
            </div>


            <div class="card" id="userCard" runat="server" visible="false">
                <div class="card-body">
                    <asp:Panel ID="Panel3" runat="server" DefaultButton="lbUser">
                        <div class="form-group row align-items-center">
                            <label for="txtUserId" class="col-md-4 col-form-label text-md-right">
                                User ID</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtUserId" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                                    ValidationGroup="userValidation" ErrorMessage="Must be alphanumeric." ControlToValidate="txtUserId"
                                    ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtFirstName" class="col-md-4 col-form-label text-md-right">
                                First Name</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" class="form-control"
                                    autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="userValidation"
                                    ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed."
                                    ControlToValidate="txtFirstName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtMiddleName" class="col-md-4 col-form-label text-md-right">
                                Middle Name</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtMiddleName" MaxLength="50" class="form-control"
                                    autocomplete="off"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="userValidation"
                                    ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed."
                                    ControlToValidate="txtMiddleName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtLastName" class="col-md-4 col-form-label text-md-right">
                                Last Name</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtLastName" MaxLength="50" class="form-control"
                                    autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="userValidation"
                                    ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed."
                                    ControlToValidate="txtLastName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="ddUserGroup" class="col-md-4 col-form-label text-md-right">
                                User Group</label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddUserGroup" runat="server" CssClass="custom-select" autocomplete="off">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="ddStatus" class="col-md-4 col-form-label text-md-right">
                                Status</label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddStatus" CssClass="custom-select">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="2">Deleted</asp:ListItem>
                                    <asp:ListItem Value="0">Disabled</asp:ListItem>
                                    <asp:ListItem Value="3">Expired</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtDateCreated" class="col-md-4 col-form-label text-md-right">
                                Date Created</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtDateCreated" MaxLength="50" class="datepicker form-control"
                                    autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server"
                                    ValidationGroup="userValidation" ErrorMessage="Must be of the format MM/DD/YYYY."
                                    ControlToValidate="txtDateCreated" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row" id="divUserColumns" runat="server" visible="false">
                            <label class="col-md-4 col-form-label text-md-right">
                                Content</label>
                            <div class="btn" data-toggle="collapse" href="#collapseUserColumns" role="button"
                                aria-expanded="false" aria-controls="collapseUserColumns">
                                <i class="large caret square down icon"></i>
                            </div>
                            <div id="collapseUserColumns" class="collapse" style="padding-top: 6px">
                                <asp:CheckBoxList ID="userColumns" runat="server">
                                    <asp:ListItem Value="1" Selected="True">&nbsp;&nbsp;User ID</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">&nbsp;&nbsp;First Name</asp:ListItem>
                                    <asp:ListItem Value="3" Selected="True">&nbsp;&nbsp;Middle Name</asp:ListItem>
                                    <asp:ListItem Value="4" Selected="True">&nbsp;&nbsp;Last Name</asp:ListItem>
                                    <asp:ListItem Value="5" Selected="True">&nbsp;&nbsp;User Group</asp:ListItem>
                                    <asp:ListItem Value="6" Selected="True">&nbsp;&nbsp;Status</asp:ListItem>
                                    <asp:ListItem Value="7" Selected="True">&nbsp;&nbsp;Date Created</asp:ListItem>
                                    <asp:ListItem Value="8" Selected="True">&nbsp;&nbsp;Last Login Date</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            <div class="col-md-4">
                                <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="validateUserColumns"
                                    ValidationGroup="userValidation" ErrorMessage="Please select at least one." ForeColor="Red"
                                    Display="Dynamic"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="form-group row" id="divPasswordAgingColumns" runat="server" visible="false">
                            <label class="col-md-4 col-form-label text-md-right">
                                Content</label>
                            <div class="btn" data-toggle="collapse" href="#collapsePasswordAgingColumns" role="button"
                                aria-expanded="false" aria-controls="collapsePasswordAgingColumns">
                                <i class="large caret square down icon"></i>
                            </div>
                            <div id="collapsePasswordAgingColumns" class="collapse" style="padding-top: 6px">
                                <asp:CheckBoxList ID="passwordAgingColumns" runat="server">
                                    <asp:ListItem Value="1" Selected="True">&nbsp;&nbsp;User ID</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">&nbsp;&nbsp;First Name</asp:ListItem>
                                    <asp:ListItem Value="3" Selected="True">&nbsp;&nbsp;Middle Name</asp:ListItem>
                                    <asp:ListItem Value="4" Selected="True">&nbsp;&nbsp;Last Name</asp:ListItem>
                                    <asp:ListItem Value="5" Selected="True">&nbsp;&nbsp;User Group</asp:ListItem>
                                    <asp:ListItem Value="6" Selected="True">&nbsp;&nbsp;Branch</asp:ListItem>
                                    <asp:ListItem Value="7" Selected="True">&nbsp;&nbsp;Department</asp:ListItem>
                                    <asp:ListItem Value="8" Selected="True">&nbsp;&nbsp;Status</asp:ListItem>
                                    <asp:ListItem Value="9" Selected="True">&nbsp;&nbsp;Date Created</asp:ListItem>
                                    <asp:ListItem Value="10" Selected="True">&nbsp;&nbsp;Last Login Date</asp:ListItem>
                                    <asp:ListItem Value="11" Selected="True">&nbsp;&nbsp;Password Change Date</asp:ListItem>
                                    <asp:ListItem Value="12" Selected="True">&nbsp;&nbsp;Profile Expiration Date</asp:ListItem>
                                    <asp:ListItem Value="13" Selected="True">&nbsp;&nbsp;Password Expiration Date</asp:ListItem>
                                    <asp:ListItem Value="14" Selected="True">&nbsp;&nbsp;Password Age</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            <div class="col-md-4">
                                <asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="validatePasswordAgingColumns"
                                    ValidationGroup="userValidation" ErrorMessage="Please select at least one." ForeColor="Red"
                                    Display="Dynamic"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="col-md-4 offset-md-4">
                            <asp:LinkButton runat="server" class="btn btn-maan1" ID="lbUser" OnClick="lbUser_Click"
                                OnClientClick="if(Page_ClientValidate('userValidation')) { if(this.value === 'Generating...') { return false; } else { this.value = 'Generating...'; }}"
                                Text="Generate" CausesValidation="true" ValidationGroup="userValidation"></asp:LinkButton>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="card" id="userGroupCard" runat="server" visible="false">
                <div class="card-body">
                    <asp:Panel ID="Panel4" runat="server" DefaultButton="lbUserGroup">
                        <div class="form-group row align-items-center">
                            <label for="ddUserGroupUG" class="col-md-4 col-form-label text-md-right">
                                User Group</label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddUserGroupUG" runat="server" CssClass="custom-select" autocomplete="off">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtCreatedBy" class="col-md-4 col-form-label text-md-right">
                                Created By</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtCreatedBy" MaxLength="50" class="form-control"
                                    autocomplete="off" placeholder="User ID"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="userGroupValidation"
                                    ErrorMessage="Must be alphanumeric." ControlToValidate="txtCreatedBy" ValidationExpression="^[a-zA-Z0-9]*$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtDateCreatedUG" class="col-md-4 col-form-label text-md-right">
                                Date Created</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtDateCreatedUG" MaxLength="50" class="datepicker form-control"
                                    autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationGroup="userGroupValidation"
                                    ErrorMessage="Must be of the format MM/DD/YYYY." ControlToValidate="txtDateCreatedUG"
                                    ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtUpdatedBy" class="col-md-4 col-form-label text-md-right">
                                Updated By</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtUpdatedBy" MaxLength="50" class="form-control"
                                    autocomplete="off" placeholder="User ID"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="userGroupValidation"
                                    ErrorMessage="Must be alphanumeric." ControlToValidate="txtUpdatedBy" ValidationExpression="^[a-zA-Z0-9]*$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="txtDateUpdated" class="col-md-4 col-form-label text-md-right">
                                Date Updated</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtDateUpdated" MaxLength="50" class="datepicker form-control"
                                    autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationGroup="userGroupValidation"
                                    ErrorMessage="Must be of the format MM/DD/YYYY." ControlToValidate="txtDateUpdated"
                                    ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label for="ddStatusUserGroup" class="col-md-4 col-form-label text-md-right">
                                Status</label>
                            <div class="col-md-4">
                                <asp:DropDownList runat="server" ID="ddStatusUserGroup" CssClass="custom-select">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="2">Deleted</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-md-4 col-form-label text-md-right">
                                Content</label>
                            <div class="btn" data-toggle="collapse" href="#collapseUserGroupColumns" role="button"
                                aria-expanded="false" aria-controls="collapseUserGroupColumns">
                                <i class="large caret square down icon"></i>
                            </div>
                            <div id="collapseUserGroupColumns" class="collapse" style="padding-top: 6px">
                                <asp:CheckBoxList ID="userGroupColumns" runat="server">
                                    <asp:ListItem Value="1" Selected="True">&nbsp;&nbsp;Group Code</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">&nbsp;&nbsp;Description</asp:ListItem>
                                    <asp:ListItem Value="3" Selected="True">&nbsp;&nbsp;Created By</asp:ListItem>
                                    <asp:ListItem Value="4" Selected="True">&nbsp;&nbsp;Date Created</asp:ListItem>
                                    <asp:ListItem Value="5" Selected="True">&nbsp;&nbsp;Updated By</asp:ListItem>
                                    <asp:ListItem Value="6" Selected="True">&nbsp;&nbsp;Date Updated</asp:ListItem>
                                    <asp:ListItem Value="7" Selected="True">&nbsp;&nbsp;User List</asp:ListItem>
                                    <asp:ListItem Value="8" Selected="True">&nbsp;&nbsp;Status</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            <div class="col-md-4">
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="validateUserGroupColumns"
                                    ValidationGroup="userGroupValidation" ErrorMessage="Please select at least one."
                                    ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                            </div>
                        </div>
                        <div class="col-md-4 offset-md-4">
                            <asp:LinkButton runat="server" class="btn btn-maan1" ID="lbUserGroup" OnClick="lbUserGroup_Click"
                                OnClientClick="if(Page_ClientValidate('userGroupValidation')) { if(this.value === 'Generating...') { return false; } else { this.value = 'Generating...'; }}"
                                Text="Generate" CausesValidation="true" ValidationGroup="userGroupValidation"></asp:LinkButton>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="card border-0" id="userGroupAccessMatrixCard" runat="server" visible="false">
                <div class="card-body">
                    <asp:Panel ID="Panel5" runat="server" DefaultButton="lbUserGroupAccessMatrix">
                        <div class="form-group row align-items-center">
                            <label for="lboxUserGroup" class="col-md-4 col-form-label text-right">
                                User Group</label>
                            <div class="col-md-4">
                                <asp:ListBox ID="lboxUserGroup" runat="server" class="selectpicker" SelectionMode="Multiple"
                                    data-width="100%" data-selected-text-format="count>3" data-actions-box="true"></asp:ListBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="userGroupAccessMatrixValidation"
                                    ErrorMessage="Please select at least one." ControlToValidate="lboxUserGroup"
                                    ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-md-4 offset-md-4">
                            <asp:LinkButton runat="server" class="btn btn-maan1" ID="lbUserGroupAccessMatrix"
                                ValidationGroup="userGroupAccessMatrixValidation" CausesValidation="true" OnClientClick="if(Page_ClientValidate()) { if(this.value === 'Generating...') { return false; } else { this.value = 'Generating...'; }}"
                                OnClick="lbUserGroupAccessMatrix_Click" Text="Generate"></asp:LinkButton>
                        </div>
                        <div class="row justify-content-center mt-2 mb-1" id="divExport" runat="server" visible="false">
                            <div class="col-md-12">
                                <div class="float-left">
                                    <asp:LinkButton class="btn btn-maan1" runat="server" ID="lbExportExcel" OnClick="lbExportExcel_Click"><i class="file excel icon"></i>Save as Excel</asp:LinkButton>
                                </div>
                                <br />
                                &nbsp;
                            </div>
                        </div>
                        <div class="row justify-content-center">
                            <div class="col-md-12 text-md-center table-responsive">
                                <asp:GridView ID="gvReport" runat="server" CssClass="table table-responsive-md table-sm"
                                    CellPadding="4" ForeColor="#333333" GridLines="Vertical" OnRowDataBound="gvReport_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#0A9D4E" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#185ece" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" />
                                </asp:GridView>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <div class="row justify-content-center">
        <br />
        &nbsp;
        <div class="col-md-8 text-md-center">
            <asp:Label runat="server" ID="lblError" Font-Size="12pt" ForeColor="Red"></asp:Label>
        </div>
    </div>
    <div class="row justify-content-center">
        <br />
        &nbsp;
        <div class="col-md-8 text-md-center">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Visible="false">
            </rsweb:ReportViewer>
        </div>
    </div>
    <script type="text/javascript">
        function pageLoad() {
            $('.selectpicker').selectpicker();
        }

        function validateAuditLogColumns(source, args) {
            var chkListModules = document.getElementById('<%= auditLogColumns.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }

        function validatePasswordAgingColumns(source, args) {
            var chkListModules = document.getElementById('<%= passwordAgingColumns.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }

        function validateUserColumns(source, args) {
            var chkListModules = document.getElementById('<%= userColumns.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }

        function validateUserGroupColumns(source, args) {
            var chkListModules = document.getElementById('<%= userGroupColumns.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }


    </script>

    <script type="text/javascript">
        $(function () {
            $('.yearpicker').yearpicker();
        });
    </script>

</asp:Content>
