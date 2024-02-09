<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="user-search.aspx.cs" Inherits="Template.user_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="contents/css/gridview-pager.css" />
    <link rel="stylesheet" href="contents/AdminLTE/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css">
    <link rel="stylesheet" href="contents/AdminLTE/plugins/datatables-responsive/css/responsive.bootstrap4.min.css">
    <link rel="stylesheet" href="contents/AdminLTE/plugins/datatables-buttons/css/buttons.bootstrap4.min.css">
    <link rel="stylesheet" href="contents/AdminLTE/plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css">

    <!-- Nice Admin -->
    <link href="contents/NiceAdmin/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
    <link href="contents/NiceAdmin/vendor/boxicons/css/boxicons.min.css" rel="stylesheet">
    <!-- maan template -->
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/main.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Main content -->
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
                            <li class="breadcrumb-item active">
                                <asp:Label ID="mainBreadcrumb" runat="server"></asp:Label></li>
                        </ol>
                    </div>
                </div>
            </div>
        </section>
        <section class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">
                                    <asp:Label ID="cardTitle" runat="server"></asp:Label>
                                </h3>
                            </div>
                            <div class="card-body">
                                <div class="dataTables_wrapper dt-bootstrap4">
                                    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="lbSearch">
                                        <div class="row">
                                            <div class="col-sm-12 col-md-6" id="divExport" runat="server" visible="false">
                                                <div class="dt-buttons btn-group flex-wrap">
                                                    <asp:LinkButton ID="lbExportExcel" runat="server" CssClass="btn btn-sm btn-outline-success buttons-excel buttons-html5" OnClick="lbExportExcel_Click"><i class="fa fa-file-excel mr-2"></i>Excel</asp:LinkButton>
                                                    <asp:LinkButton ID="lbExportPdf" runat="server" CssClass="btn btn-sm btn-outline-danger buttons-pdf buttons-html5" OnClick="lbExportPdf_Click"><i class="fa fa-file-pdf mr-2"></i>PDF</asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-sm-12 col-md-6" id="divSearch" runat="server" visible="false">
                                                <div class="dataTables_filter">
                                                    <asp:LinkButton ID="lbAdd" runat="server" CssClass="btn btn-sm btn-primary" OnClick="lbAdd_Click" Visible="false"><i class="fa fa-plus-circle mr-2"></i>Add</asp:LinkButton>
                                                    <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control form-control-sm" placeholder="Search User ID" autocomplete="off"></asp:TextBox>
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-sm" placeholder="Search Name" autocomplete="off"></asp:TextBox>
                                                    <asp:LinkButton ID="lbSearch" runat="server" CssClass="btn btn-sm" OnClick="lbSearch_Click" ToolTip="Search"><i class="fa fa-search"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lbRefresh" runat="server" CssClass="btn btn-sm" OnClick="lbRefresh_Click" ToolTip="Refresh"><i class="bi bi-arrow-repeat text-dark"></i></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <!-- Gridview -->
                                            <asp:GridView ID="gvMaintenance" runat="server" AllowPaging="True" CssClass="table table-bordered table-striped dataTable dtr-inline"
                                                GridLines="None" CellPadding="4" PageSize="10" ForeColor="#333333" AllowSorting="true"
                                                OnPageIndexChanging="gvMaintenance_PageIndexChanging" OnRowDataBound="gvMaintenance_RowDataBound"
                                                OnSorting="gvMaintenance_Sorting" OnRowCreated="gvMaintenance_OnRowCreated" PagerSettings-Mode="NumericFirstLast"
                                                PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last">
                                                <AlternatingRowStyle BackColor="White" />
                                                <EditRowStyle BackColor="#0A9D4E" />
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <%--<HeaderStyle BackColor="#212529" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
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
                                                                Text="" OnClick="lbView_Click" class="mr-2"><i class="fa fa-eye text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                                            <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("Code")%>' ToolTip="Edit"
                                                                Text="" OnClick="lbEdit_Click" Visible="false" class="mr-2"><i class="fas fa-edit text-primary" style="text-decoration:none"></i></asp:LinkButton>
                                                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("Code")%>'
                                                                ToolTip="Delete" OnClientClick="return deleteAlert(this);" Text="" OnClick="lbDelete_Click"
                                                                Visible="false" class="mr-2"><i class="bi bi-trash-fill text-danger" style="text-decoration:none"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <!-- Gridview -->
                                            <div id="divPager" runat="server" class="form-inline mb-3" visible="false">
                                                <asp:LinkButton ID="lbFirstPage" runat="server" ToolTip="First" OnClick="lbFirstPage_Click" Visible="false"><i class="fas fa-angle-double-left text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                                &nbsp; Page&nbsp;
                                            <asp:DropDownList ID="ddPageNumber" runat="server" CssClass="custom-select" OnSelectedIndexChanged="ddPageNumber_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                                &nbsp; of&nbsp;
                                            <asp:Label ID="lblTotalPageCount" runat="server" />
                                                &nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="lbPreviousPage" runat="server" ToolTip="Previous" OnClick="lbPreviousPage_Click"><i class="fas fa-angle-left text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                                &emsp;
                                            <asp:LinkButton ID="lbNextPage" runat="server" ToolTip="Next" OnClick="lbNextPage_Click"><i class="fas fa-angle-right  text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lbLastPage" runat="server" ToolTip="Last" OnClick="lbLastPage_Click" Visible="false"><i class="fas fa-angle-double-right text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                                &emsp;
                                            </div>
                                        </div>
                                    </div>
                                </div>






                            </div>
                            <!--card body-->
                        </div>
                        <!-- card-->
                    </div>
                </div>
            </div>
        </section>
    </div>



    <!-- Script -->
    <script src="contents/AdminLTE/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="contents/AdminLTE/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js"></script>
    <script src="contents/AdminLTE/plugins/datatables-responsive/js/dataTables.responsive.min.js"></script>
    <script src="contents/AdminLTE/plugins/datatables-responsive/js/responsive.bootstrap4.min.js"></script>
    <script src="contents/AdminLTE/plugins/datatables-buttons/js/dataTables.buttons.min.js"></script>
    <script src="contents/AdminLTE/plugins/datatables-buttons/js/buttons.bootstrap4.min.js"></script>
    <script src="contents/AdminLTE/plugins/jszip/jszip.min.js"></script>
    <script src="contents/AdminLTE/plugins/pdfmake/pdfmake.min.js"></script>
    <script src="contents/AdminLTE/plugins/pdfmake/vfs_fonts.js"></script>
    <script src="contents/AdminLTE/plugins/datatables-buttons/js/buttons.html5.min.js"></script>
    <script src="contents/AdminLTE/plugins/datatables-buttons/js/buttons.print.min.js"></script>
    <script src="contents/AdminLTE/plugins/datatables-buttons/js/buttons.colVis.min.js"></script>
</asp:Content>
