<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true"
    CodeBehind="password-change.aspx.cs" Inherits="Template.password_change" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="contents/AdminLTE/plugins/fontawesome-free/css/all.min.css">
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="contents/AdminLTE/plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="contents/AdminLTE/dist/css/adminlte.min.css">
    <!-- Maan Template -->
    <link rel="stylesheet" type="text/css" href="contents/css/jquery-ui.min.css" />
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <script type="text/javascript" src="contents/js/main.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="content-wrapper">
        <div class="content">
            <br />
            <div class="row justify-content-center">
                <div class="col-md-10">
                    <div class="card card-outline card-primary">
                        <div class="card-header text-center">
                            <img alt="" src="contents/images/ums-logo.png" height="120" width="340" />
                        </div>
                        <div class="card-body">
                            <p class="login-box-msg">You are only one step a way from your new password, change your password now.</p>
                            <br />
                            <p class="login-box-msg"><b>Password Guidelines</b></p>
                            <div class="form-group row align-items-baseline">
                                <label for="lblPasswordGuidelines" class="col-md-4 col-form-label text-md-right">
                                </label>
                                <div class="col-md-4">
                                    <i class="chevron right icon"></i>
                                    <asp:Label runat="server" ID="lblNewPasswordErrorMessage"></asp:Label><br />
                                    <br />
                                    <i class="chevron right icon"></i>
                                    <asp:Label runat="server" ID="lblNewPasswordRepeatingErrorMessage"></asp:Label><br />
                                    <br />
                                    <i class="chevron right icon"></i>
                                    <asp:Label runat="server" ID="lblNewPasswordSequentialErrorMessage"></asp:Label>
                                </div>
                            </div>
                            <form action="" method="post">
                                <div class="form-group row align-items-start">
                                    <label for="txtCurrentPassword" class="col-md-4 col-form-label text-md-right">
                                        Current Password</label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtCurrentPassword" MaxLength="50" TextMode="Password"
                                            class="form-control" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="changePasswordValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtCurrentPassword" ForeColor="Red"
                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row align-items-start">
                                    <label for="txtNewPassword" class="col-md-4 col-form-label text-md-right">
                                        New Password</label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtNewPassword" MaxLength="50" TextMode="Password"
                                            class="form-control" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="changePasswordValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtNewPassword" ForeColor="Red"
                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="NewPasswordValidator" runat="server" ValidationGroup="changePasswordValidation"
                                            ErrorMessage="First condition not met.<br/>" ControlToValidate="txtNewPassword"
                                            ValidationExpression="" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator ID="NewPasswordRepeatingValidator" runat="server"
                                            ValidationGroup="changePasswordValidation" Enabled="false" ErrorMessage="Second condition not met.<br/>"
                                            ControlToValidate="txtNewPassword" ValidationExpression="" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator ID="NewPasswordSequentialValidator" runat="server"
                                            ValidationGroup="changePasswordValidation" Enabled="false" ErrorMessage="Third condition not met.<br/>"
                                            ControlToValidate="txtNewPassword" ValidationExpression="" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group row align-items-start">
                                    <label for="txtConfirmPassword" class="col-md-4 col-form-label text-md-right">
                                        Confirm Password</label>
                                    <div class="col-md-4">
                                        <asp:TextBox runat="server" ID="txtConfirmPassword" MaxLength="50" TextMode="Password"
                                            class="form-control" autocomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="changePasswordValidation"
                                            ErrorMessage="Required field." ControlToValidate="txtConfirmPassword" ForeColor="Red"
                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="New password and confirmation password do not match."
                                            ValidationGroup="changePasswordValidation" ControlToCompare="txtNewPassword"
                                            ControlToValidate="txtConfirmPassword" ForeColor="RED" Display="Dynamic"></asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="col-md-6 offset-md-3 text-center">
                                    <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
                                    <br />
                                    &nbsp;
                                </div>
                                <div class="col-md-4 offset-md-4">
                                    <asp:LinkButton runat="server" class="btn btn-primary" ID="lbChangePassword" OnClick="lbChangePassword_Click"
                                        OnClientClick="if(Page_ClientValidate('changePasswordValidation')) {if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                                        Text="Change Password" CausesValidation="true" ValidationGroup="changePasswordValidation"></asp:LinkButton>
                                </div>
                            </form>

                        </div>
                        <!-- /.login-card-body -->
                    </div>



                </div>
            </div>

        </div>
    </div>


    <!-- jQuery -->
    <script src="contents/AdminLTE/plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="contents/AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- AdminLTE App -->
    <script src="contents/AdminLTE/dist/js/adminlte.min.js"></script>
</asp:Content>
