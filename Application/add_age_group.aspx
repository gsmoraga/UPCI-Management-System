<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="add_age_group.aspx.cs" Inherits="Template.add_age_group" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- custom css -->
    <link rel="Stylesheet" href="contents/css/survey.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main class="my-form" ondragstart="return false" draggable="false">
        <div class="row justify-content-center m-1">
            <div class="col-md-8 text-md-center">
                <asp:Label runat="server" ID="lblHeader" Font-Bold="true" Font-Size="X-Large" CssClass="custom-header"></asp:Label>
                <br />
                &nbsp;
            </div>


            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-10">
                        <div class="card" id="codeDescCard" runat="server" visible="false">
                            <div class="card-header " runat="server"> <asp:Label runat="server" id="cardHeaderDesc"></asp:Label></div>
                            <div class="card-body">
                                <div class="form-group row align-items-center" id="rowCode" runat="server">
                                    <label for="txtCode" class="col-md-4 col-form-label text-md-right" id="lblCode" runat="server">Code</label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtCode" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="codeDescValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtCode" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revCode" runat="server" ValidationGroup="codeDescValidation"
                                            ErrorMessage="Must be alphanumeric." ControlToValidate="txtCode" ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group row align-items-center">
                                    <label for="txtDescription" class="col-md-4 col-form-label text-md-right">Description</label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtDescription" MaxLength="350" class="form-control" autocomplete="off"></asp:TextBox>
                                        <asp:Label ID="lblDescription" runat="server" Text="" Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="codeDescValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtDescription" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revDescription" runat="server" ValidationGroup="codeDescValidation"
                                            ErrorMessage="Must be alphanumeric." ControlToValidate="txtDescription" ValidationExpression="^[a-zA-Z0-9\s.,\-()]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <%--<div class="form-group row align-items-center">
                                    <label for="txtDescription" class="col-md-4 col-form-label text-md-right">Minimum Age
                                    </label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtMinAge" MaxLength="350" class="form-control" onkeypress="return isNumberKey(event)" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="codeDescValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtMinAge" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                                    </div>
                                </div>

                                <div class="form-group row align-items-center">
                                    <label for="txtDescription" class="col-md-4 col-form-label text-md-right">Maximum Age</label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtMaxAge" MaxLength="350" class="form-control" onkeypress="return isNumberKey(event)" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="codeDescValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtMaxAge" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                                    </div>
                                </div>--%>


                                <div class="col-md-4 offset-md-4">
                                    <asp:LinkButton runat="server" class="btn btn-primary" ID="lbAdd" OnClick="lbAdd_Click" Text="Save"
                                        OnClientClick="if(Page_ClientValidate('codeDescValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                                        CausesValidation="true" ValidationGroup="codeDescValidation"></asp:LinkButton>
                                    <%--<asp:LinkButton runat="server" class="btn btn-maan1" ID="lbBackCodeDesc" OnClick="lbBack_Click" Text="Back"></asp:LinkButton>--%>
                                </div>




                            </div>
                        </div>
                    </div>
                </div>

            </div>



        </div>
    </main>


    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
