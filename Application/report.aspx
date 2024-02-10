<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="report.aspx.cs" Inherits="Template.report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="contents/AdminLTE/plugins/fontawesome-free/css/all.min.css">
    <!-- Select2 -->
    <link rel="stylesheet" href="contents/AdminLTE/plugins/select2/css/select2.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="contents/AdminLTE/dist/css/adminlte.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper">
        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <h2 class="text-center display-4">
                    <asp:Label ID="lblReportDesc" runat="server"></asp:Label>
                    Report</h2>
                <form action="enhanced-results.html">
                    <div class="row">
                        <div class="col-md-10 offset-md-1">
                            <div class="row">
                                <div class="col-6">
                                    <div class="form-group">
                                        <label>Report Type:</label>
                                        <asp:DropDownList ID="ddReport" class="custom-select" Style="width: 100%;" runat="server" OnSelectedIndexChanged="ddReport_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-3">
                                    <div class="form-group">
                                        <label>Age Group</label>
                                        <asp:DropDownList ID="ddAgeGroup" runat="server" CssClass="custom-select">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="M">Mens</asp:ListItem>
                                            <asp:ListItem Value="W">Womens</asp:ListItem>
                                            <asp:ListItem Value="YA">Young Adults</asp:ListItem>
                                            <asp:ListItem Value="Y">Youth</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-3">
                                    <div class="form-group">
                                        <label>Membership Status</label>
                                        <asp:DropDownList ID="ddMembershipStatus" runat="server" CssClass="custom-select">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">Workers</asp:ListItem>
                                            <asp:ListItem Value="2">Non-Workers</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group input-group-lg">
                                    <asp:TextBox ID="txtMemberId" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                                    <%--<input type="search" class="form-control form-control-lg" placeholder="Type your keywords here" value="Lorem ipsum">--%>
                                    <div class="input-group-append">
                                        <button type="submit" class="btn btn-lg btn-default">
                                            <i class="fa fa-search"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
                <div class="row mt-3">
                    <div class="col-md-10 offset-md-1">
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
                                <%--<asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# Eval("Code")%>' ToolTip="View"
                                            Text="" OnClick="lbView_Click" class="mr-2"><i class="fa fa-eye text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("Code")%>' ToolTip="Edit"
                                            Text="" OnClick="lbEdit_Click" Visible="false" class="mr-2"><i class="fas fa-edit text-primary" style="text-decoration:none"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("Code")%>'
                                            ToolTip="Delete" OnClientClick="return deleteAlert(this);" Text="" OnClick="lbDelete_Click"
                                            Visible="false" class="mr-2"><i class="bi bi-trash-fill text-danger" style="text-decoration:none"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
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
        </section>
    </div>
    <!-- jQuery -->
    <script src="contents/AdminLTE/plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="contents/AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Select2 -->
    <script src="contents/AdminLTE/plugins/select2/js/select2.full.min.js"></script>
    <!-- AdminLTE App -->
    <script src="contents/AdminLTE/dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="contents/AdminLTE/dist/js/demo.js"></script>
    <script>
        $(function () {
            $('.select2').select2()
        });
    </script>
</asp:Content>
