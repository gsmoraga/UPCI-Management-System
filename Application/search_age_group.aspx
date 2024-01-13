<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="search_age_group.aspx.cs" Inherits="Template.search_age_group" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link rel="stylesheet" type="text/css" href="contents/css/gridview-pager.css" />

    <style type="text/css">
        @font-face {
            font-family: poppinsLight;
            src: url(contents/fonts/Poppins-Light.ttf);
        }

        @font-face {
            font-family: poppinsMedium;
            src: url(contents/fonts/Poppins-Medium.ttf);
        }

        .custom-header {
            font-family: poppinsMedium;
        }

        .row {
            font-family: poppinsMedium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div ondragstart="return false" draggable="false">
        <div class="row justify-content-center m-1">
            <div class="col-md-8 text-md-center">
                <asp:Label runat="server" ID="lblHeader" Font-Bold="true" Font-Size="X-Large" CssClass="custom-header"></asp:Label>
                <br />
                &nbsp;
            </div>

        </div>
        <asp:Panel ID="pnlSearch" runat="server" DefaultButton="lbSearch">
            <div class="row justify-content-center m-1">
                <div class="col-md-10 text-md-left card-body">
                    <div id="divSearch" runat="server" visible="false">
                        <div class="form-group row align-items-center">
                            <label for="txtCode" class="col-md-4 col-form-label text-md-right" id="lblCode" runat="server">
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
                        <div class="form-group row align-items-center" id="divDescription" runat="server">
                            <label for="txtDescription" class="col-md-4 col-form-label text-md-right" id="lblDescription"
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
                    </div>
                    <div class="col-md-8 offset-md-4 text-md-left">
                        <asp:LinkButton class="btn btn-primary mr-2" runat="server" ID="lbSearch" OnClick="lbSearch_Click"
                            OnClientClick="if(Page_ClientValidate('searchValidation')) {if(this.value === 'Searching...') { return false; } else { this.value = 'Searching...'; }}"
                            CausesValidation="true" ValidationGroup="searchValidation" Visible="false"><i class="search icon"></i>Search</asp:LinkButton>
                        <asp:LinkButton class="btn btn-primary mr-2" runat="server" ID="lbRefresh" OnClick="lbRefresh_Click"><i class="redo icon"></i>Refresh</asp:LinkButton>
                        <br />
                        &nbsp;
                    </div>
                </div>
            </div>
        </asp:Panel>
        <!-- Export -->
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
                                    <i class="save icon"></i>Save As...
                                </button>
                                <div class="dropdown-menu" aria-labelledby="btnExport">
                                    <asp:LinkButton class="dropdown-item" runat="server" ID="lbExportExcel" OnClick="lbExportExcel_Click"><i class="file excel icon green"></i>Excel</asp:LinkButton>
                                    <asp:LinkButton class="dropdown-item" runat="server" ID="lbExportPdf" OnClick="lbExportPdf_Click"><i class="file pdf icon red"></i>PDF</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row justify-content-center m-1" runat="server" id="divGridView">
            <div class="col-md-10 text-md-center table-responsive">
                <div class="row justify-content-center">
                    <div id="divDeleteCheckbox" runat="server" visible="false" class="disappear pr-0 ml-n3 mr-n3 transparent-border">
                        <asp:GridView ID="gvCheckBox" runat="server" AllowPaging="True" CssClass="table"
                            ShowFooter="true" AutoGenerateColumns="false" GridLines="None" CellPadding="4"
                            PageSize="10" ForeColor="#333333">
                            <FooterStyle BackColor="White" Font-Bold="True" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="White" Font-Bold="True" HorizontalAlign="Right" />
                            <%--<RowStyle BackColor="White" HorizontalAlign="Right" />--%>
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
                        <asp:GridView ID="gvMaintenance" runat="server" AllowPaging="True" CssClass="table"
                            GridLines="None" CellPadding="4" PageSize="10" ForeColor="#333333" AllowSorting="true"
                            OnPageIndexChanging="gvMaintenance_PageIndexChanging" OnRowDataBound="gvMaintenance_RowDataBound"
                            OnRowCreated="gvMaintenance_OnRowCreated" OnSorting="gvMaintenance_Sorting" PagerSettings-Mode="NumericFirstLast"
                            PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#0A9D4E" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#185ECE" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
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
                                        <asp:LinkButton ID="lbView" runat="server" CommandArgument='<%# Eval("Code") + ";" + Eval("Description") %>' ToolTip="View"
                                            Text="" OnClick="lbView_Click" class="mr-2"><i class="eye icon text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbEdit" runat="server" CommandArgument='<%# Eval("Code") + ";" + Eval("Description") %>' ToolTip="Edit"
                                            Text="" OnClick="lbEdit_Click" Visible="false" class="mr-2"><i class="edit icon text-primary" style="text-decoration:none"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%# Eval("Code") + ";" + Eval("Description") %>'
                                            ToolTip="Delete" OnClientClick="return deleteAlert(this);" Text="" OnClick="lbDelete_Click"
                                            Visible="false" class="mr-2"><i class="trash icon text-danger" style="text-decoration:none"></i></asp:LinkButton>

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
                            OnClientClick="return deleteAlert(this);" class="btn btn-danger"><i class="trash bin icon"></i>Delete</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <asp:Panel ID="pnlView" runat="server" Visible="false">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-10">
                        <div class="card" id="ViewDescCard" runat="server" visible="true">
                            <div class="card-header" id="hViewDesc" runat="server">
                                View
                            </div>
                            <div class="card-body">
                                <!-- Code -->
                                <div class="form-group row align-items-center" id="rowCode2" runat="server">
                                    <label for="ddCode" class="col-md-4 col-form-label text-md-right" id="lblCode2" runat="server">Code</label>
                                    <div class="col-md-4">
                                        <label id="lblViewCode" runat="server">
                                        </label>
                                    </div>
                                    <div class="col-md-4">
                                    </div>
                                </div>
                                <!-- description -->
                                <div class="form-group row align-items-center">
                                    <label for="txtDescription" class="col-md-4 col-form-label text-md-right">Description</label>
                                    <div class="col-md-4">
                                        <label id="lblViewDescription" runat="server">
                                        </label>
                                    </div>
                                    <div class="col-md-4">
                                    </div>
                                </div>

                                <!--  VIEW BACK BUTTON -->
                                <div class="col-md-4 offset-md-4">
                                    <asp:LinkButton ID="lbViewBack" runat="server" OnClick="lbViewBack_Click" class="btn btn-primary"
                                        Visible="true" CausesValidation="true">Back</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlEdit" runat="server" Visible="false">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-10">
                        <div class="card" id="divEdit" runat="server">
                            <div class="card-header" id="hCodeDesc" runat="server">Edit</div>
                            <div class="card-body">
                                <div class="form-group row align-items-center">
                                    <label for="ddCode" class="col-md-4 col-form-label text-md-right" id="Label1" runat="server">Code</label>
                                    <div class="col-md-4">
                                        <asp:Label runat="server" ID="lblEditCode"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group row align-items-center">
                                    <label for="txtDescription" class="col-md-4 col-form-label text-md-right">Description</label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtEditDescription" MaxLength="50" autocomplete="off"
                                            class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="codeDescValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtEditDescription" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="codeDescValidation"
                                            ErrorMessage="Must be alphanumeric." ControlToValidate="txtEditDescription" ValidationExpression="^[a-zA-Z0-9\s.,\-()]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="col-md-8 offset-md-4">
                                    <asp:LinkButton ID="lbEditSave" runat="server" OnClick="lbEditSave_Click" class="btn btn-primary mr-2"
                                        Visible="true" ValidationGroup="editValidation" CausesValidation="true">Save</asp:LinkButton>
                                    <asp:LinkButton ID="lbEditBack" runat="server" OnClick="lbEditBack_Click" class="btn btn-outline-primary mr-2"
                                        Visible="true" CausesValidation="true">Back</asp:LinkButton>
                                    &nbsp;
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
