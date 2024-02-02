<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="manage-members.aspx.cs" Inherits="Template.manage_members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <h2 class="text-center display-4">Member List</h2>

                <div class="row">
                    <div class="col-md-10 offset-md-1">
                        <div class="row">
                            <div class="col-6">
                                <div class="form-group">
                                    <asp:LinkButton ID="lbAdd" runat="server" CssClass="btn btn-primary" OnClick="lbAdd_Click"><i class="fa fa-plus-circle mr-2"></i>Add Member</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group input-group-lg">
                                <asp:TextBox ID="txtSearch" runat="server" AutoCompleteType="Search" CssClass="form-control form-control-lg" placeholder="Type Member Name here"></asp:TextBox>
                                <div class="input-group-append">
                                    <button type="submit" class="btn btn-lg btn-default">
                                        <i class="fa fa-search"></i>
                                        
                                    </button>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Gridview -->
                <div class="row mt-3">
                    <div class="col-md-10 offset-md-1">
                        <div class="list-group">
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
                                            <%--<asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# Eval("Code")%>' ToolTip="View"
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
                                                Visible="false" class="mr-2"><i class="bi bi-ban-fill text-danger" style="text-decoration:none"></i></asp:LinkButton>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>

            </div>
        </section>
    </div>
</asp:Content>
