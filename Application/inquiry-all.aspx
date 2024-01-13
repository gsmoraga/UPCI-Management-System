<%@ Page Title="" Language="C#" MasterPageFile="~/UPCI.Master" AutoEventWireup="true" CodeBehind="inquiry-all.aspx.cs" Inherits="Template.inquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="contents/css/gridview-pager.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>

    <link rel="stylesheet" type="text/css" href="contents/css/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <script type="text/javascript" src="contents/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="contents/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="contents/js/main.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div ondragstart="return false" draggable="false">
        <div class="row justify-content-center m-1">
            <div class="col-md-8 text-md-center">
                <asp:Label runat="server" ID="lblHeader" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                <br />
                &nbsp;
            </div>
        </div>
        <div class="row justify-content-center card-body">
            <asp:Panel ID="pnlInquiry" runat="server" DefaultButton="lbSearch">
                <div class="row justify-content-center m-1">
                    <div class="col-md-10 text-md-left card-body">
                        <div id="divSearch" runat="server" visible="true">
                            <div class="form-group row align-items-center">
                                <label for="txtCode" class="col-md-4 col-form-label text-md-right" id="lblTransRefNumber" runat="server">Transaction Reference Number</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtTransRefNumber" MaxLength="50" autocomplete="off" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <%--<asp:RegularExpressionValidator ID="CodeValidation" runat="server" ValidationGroup="searchValidation"
                                    ErrorMessage="Must be alphanumeric." ControlToValidate="txtTransRefNumber" ValidationExpression="^[a-zA-Z0-9\s]*$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                                </div>
                            </div>
                            <div class="form-group row align-items-center" id="divDescription" runat="server">
                                <label for="txtDescription" class="col-md-4 col-form-label text-md-right" id="lblControlNo"
                                    runat="server">
                                    Control No</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtControlNo" MaxLength="50" autocomplete="off"
                                        class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="searchValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtControlNo" ValidationExpression="^[a-zA-Z0-9\s]*$"
                                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group row align-items-center" id="div1" runat="server">
                                <label for="txtDescription" class="col-md-4 col-form-label text-md-right" id="Label1"
                                    runat="server">
                                    Transaction Status</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddTransactionStatus" runat="server" CssClass="form-select">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="1">Pending</asp:ListItem>
                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                        <asp:ListItem Value="3">Declined</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row align-items-center" id="div2" runat="server">
                                <label for="txtDescription" class="col-md-4 col-form-label text-md-right" id="Label2"
                                    runat="server">
                                    Workflow Status</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddWorkflowStatus" runat="server" CssClass="form-select"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row align-items-center" id="div3" runat="server">
                            <label for="txtDescription" class="col-md-4 col-form-label text-md-right" id="Label3"
                                runat="server">
                                Date From</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtDateFrom" MaxLength="50" autocomplete="off"
                                    class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <div class="form-group row align-items-center" id="div4" runat="server">
                            <label for="txtDescription" class="col-md-4 col-form-label text-md-right" id="Label4"
                                runat="server">
                                Date To</label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtDateTo" MaxLength="50" autocomplete="off"
                                    class="form-control datepicker"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <div class="col-md-8 offset-md-4 text-md-left">
                            <asp:LinkButton class="btn btn-primary mr-2" runat="server" ID="lbSearch"
                                OnClientClick="if(Page_ClientValidate('searchValidation')) {if(this.value === 'Searching...') { return false; } else { this.value = 'Searching...'; }}"
                                CausesValidation="true" ValidationGroup="searchValidation" OnClick="lbSearch_Click" Visible="true"><i class="bi bi-search"></i>&nbsp;&nbsp;Search</asp:LinkButton>
                            <asp:LinkButton class="btn btn-primary mr-2" runat="server" ID="lbRefresh" OnClick="lbRefresh_Click"><i class="bi bi-arrow-clockwise"></i>&nbsp;&nbsp;Refresh</asp:LinkButton>
                            <br />
                            &nbsp;
                        </div>




                    </div>

                </div>
            </asp:Panel>
            <div class="col-md-8 text-md-center">
                <br />
                <asp:Label runat="server" ID="lblSearchError" Font-Size="Large" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <div class="row justify-content-center m-1" id="divExport" runat="server">
            <div class="col-md-10">
                <div class="float-right">
                    <div class="dropdown">
                        <button class="btn btn-maan1 dropdown-toggle" type="button" id="btnExport" data-toggle="dropdown"
                            aria-haspopup="true" aria-expanded="false">
                            <i class="save icon"></i>Save As...
                        </button>
                        <div class="dropdown-menu" aria-labelledby="btnExport">
                            <%--<asp:LinkButton class="dropdown-item" runat="server" ID="lbExportExcel" OnClick="lbExportExcel_Click"><i class="file excel icon green"></i>Excel</asp:LinkButton>
                            <asp:LinkButton class="dropdown-item" runat="server" ID="lbExportPdf" OnClick="lbExportPdf_Click"><i class="file pdf icon red"></i>PDF</asp:LinkButton>--%>
                        </div>
                    </div>
                </div>
                <br />
                &nbsp;
            </div>
        </div>
        <div class="row justify-content-center m-1">
            <div class="col-md-10 text-md-center table-responsive">
                <asp:GridView ID="gvApplication" runat="server" AllowPaging="True" CssClass="table"
                    GridLines="None" CellPadding="4" PageSize="10" ForeColor="#333333" AllowSorting="true"
                    OnPageIndexChanging="gvApplication_PageIndexChanging" OnRowDataBound="gvApplication_RowDataBound"
                    OnSorting="gvApplication_Sorting" PagerSettings-Mode="NumericFirstLast" PagerSettings-FirstPageText="First"
                    PagerSettings-Visible="false" PagerSettings-LastPageText="Last">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#0A9D4E" />
                    <FooterStyle BackColor="#DEE2E6" />
                    <HeaderStyle BackColor="#185ece" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#DEE2E6" HorizontalAlign="Left" CssClass="gridview-pager"
                        Font-Size="Large" />
                    <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# Eval("Transaction Reference Number") %>'
                                    ToolTip="View" Text="" OnClick="lbView_Click" class="mr-2">
                                    <i class="bi bi-eye-fill text-dark" style="text-decoration: none"></i></asp:LinkButton>
                                <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("Transaction Reference Number") %>'
                                    ToolTip="Edit" Text="" OnClick="lbEdit_Click" Visible="false"><i class="bi bi-pencil-square text-primary" style="text-decoration:none"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div id="divPager" runat="server" class="form-inline mb-3" visible="false">
                    <asp:LinkButton ID="lbFirstPage" runat="server" ToolTip="First" OnClick="lbFirstPage_Click"><i class="bi bi-skip-backward-fill text-dark" style="text-decoration:none"></i></asp:LinkButton>
                    <asp:LinkButton ID="lbPreviousPage" runat="server" ToolTip="Previous" OnClick="lbPreviousPage_Click"><i class="bi bi-skip-start-fill text-dark" style="text-decoration:none"></i></asp:LinkButton>
                    |&nbsp; Page&nbsp;
                    <asp:DropDownList ID="ddPageNumber" runat="server" CssClass="custom-select" OnSelectedIndexChanged="ddPageNumber_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    &nbsp; of&nbsp;
                    <asp:Label ID="lblTotalPageCount" runat="server" />
                    &nbsp;&nbsp;|&nbsp;
                    <asp:LinkButton ID="lbNextPage" runat="server" ToolTip="Next" OnClick="lbNextPage_Click"><i class="bi bi-skip-end-fill  text-dark" style="text-decoration:none"></i></asp:LinkButton>
                    <asp:LinkButton ID="lbLastPage" runat="server" ToolTip="Last" OnClick="lbLastPage_Click"><i class="bi bi-skip-forward-fill text-dark" style="text-decoration:none"></i></asp:LinkButton>
                    &emsp;
                    <asp:DropDownList ID="ddPageSize" runat="server" CssClass="custom-select" OnSelectedIndexChanged="ddPageSize_SelectedIndexChanged"
                        AutoPostBack="true">
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                    </asp:DropDownList>
                    <%--&emsp;|&emsp; Total&nbsp;Count:&nbsp;<asp:Label ID="lblTotalRowCount" runat="server" />--%>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
