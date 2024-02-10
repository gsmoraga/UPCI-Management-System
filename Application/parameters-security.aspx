<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="parameters-security.aspx.cs" Inherits="Template.parameters_security" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1><asp:Label ID="contentHeader" runat="server"></asp:Label>
                        </h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="home.aspx">Home</a></li>
                            <li class="breadcrumb-item">
                                <asp:Label ID="mainBreadcrumb" runat="server"></asp:Label></li>
                        </ol>
                    </div>
                </div>

            </div>
            <!-- /.container-fluid -->
        </section>

        <!-- Main content -->
        <section class="content">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title"><asp:label ID="cardTitle" runat="server"></asp:label>
                            </h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="txtCode" id="Label1" runat="server">Minimum password length</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtMinPasswordLength" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the minimum number of characters for passwords of users"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtMinPasswordLength" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator38" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be positive integer ranging from 1 to 50." ControlToValidate="txtMinPasswordLength" ValidationExpression="^(?:[1-9]|[1-4][0-9]|50)$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" runat="server">Default no. of days for password expiration</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtPasswordExpiration" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of days before a front and back end user’s password will expire"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtPasswordExpiration" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtPasswordExpiration" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" runat="server">No. of allowed repeating characters in a password</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtAllowedRepeatingCharacters" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of times a character can be used in a password"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtAllowedRepeatingCharacters" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator41" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtAllowedRepeatingCharacters" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" runat="server">No. of allowed sequential characters in a password</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtAllowedSequentialCharacters" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the length of sequential letters or numbers that can be used in a password"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtAllowedSequentialCharacters" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtAllowedSequentialCharacters" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label5" runat="server">Maximum no. of cumulative invalid password retries</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtCumulativeInvalidPassword" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of cumulative invalid passwords during login before a user account will be disabled"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtCumulativeInvalidPassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtCumulativeInvalidPassword" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label2" runat="server">Maximum no. of invalid password retries</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtInvalidPasswordTries" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of invalid passwords during login before a user account will be disabled"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtInvalidPasswordTries" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator45" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtInvalidPasswordTries" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label3" runat="server">No. of recent passwords that cannot be used</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtRecentPasswordsNotAllowed" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of previously used passwords that cannot be used as the current password"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtRecentPasswordsNotAllowed" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator46" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtRecentPasswordsNotAllowed" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label4" runat="server">Special characters allowed in a password</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtSpecialCharactersAllowedSP" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the list of characters that will be allowed if the password type allows special characters"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtSpecialCharactersAllowedSP" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator48" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must consist of special characters." ControlToValidate="txtSpecialCharactersAllowedSP" ValidationExpression="[^\w\s]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label6" runat="server">Password Type</label>
                                <div class="input-group">
                                    <asp:DropDownList runat="server" ID="ddPasswordType" CssClass="custom-select">
                                        <asp:ListItem Value="1">Alphabetic</asp:ListItem>
                                        <asp:ListItem Value="2">Numeric</asp:ListItem>
                                        <asp:ListItem Value="3">Alphanumeric</asp:ListItem>
                                        <asp:ListItem Value="4">Alphanumeric with special characters</asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the allowed character combination for passwords."></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label7" runat="server">Validity of mobile activation (minutes)</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtMobileActivation" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the time the user should input the mobile activation code before it expires"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtMobileActivation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator47" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtMobileActivation" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>







                        </div>
                        <!-- Card body-->

                    </div>
                    <!-- Card -->
                </div>

            </div>
            <div class="row">
                <div class="col-10">
                    <asp:LinkButton runat="server" class="btn btn-success float-right" ID="lbSaveSecurityParameters" OnClick="lbSaveSecurityParameters_Click" Text="Save Changes"
                        OnClientClick="if(Page_ClientValidate('securityParametersValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                        CausesValidation="true" ValidationGroup="securityParametersValidation"></asp:LinkButton>
                </div>
            </div>
            <br />
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
