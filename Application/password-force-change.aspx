<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="password-force-change.aspx.cs"
    Inherits="Template.password_force_change" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Standard Meta -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
    <title>Change Password</title>
<%--    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <script type="text/javascript" src="contents/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>--%>

    <!-- Contents -->

    <!-- Nice Admin Template
    <!-- Vendor CSS Files -->
    <link href="contents/NiceAdmin/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="contents/NiceAdmin/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
    <link href="contents/NiceAdmin/vendor/boxicons/css/boxicons.min.css" rel="stylesheet" />
    <link href="contents/NiceAdmin/vendor/remixicon/remixicon.css" rel="stylesheet" />
    <!-- Template Main CSS File -->
    <link href="contents/NiceAdmin/css/style.css" rel="stylesheet" />

    <!-- Maan Contents Template -->
    <link rel="stylesheet" type="text/css" href="contents/css/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <script type="text/javascript" src="contents/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="contents/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <script type="text/javascript" src="contents/js/main.js"></script>
</head>
<body>
    <div class="text-center mb-3">
        <img src="contents/images/upci-logo.png" alt="UPCI Management System" />
    </div>
    <form id="Form1" runat="server">
        <div class="row justify-content-center">
            <div class="col-md-8" style="font-size: small">
                <div class="card">
                    <div class="card-header">
                        Change Password
                    </div>
                    <div class="card-body">
                        <div class="form-group row align-items-baseline">
                            <label for="lblPasswordGuidelines" class="col-md-4 col-form-label text-md-right">
                                Password Guidelines</label>
                            <div class="col-md-4">
                                <li>
                                    <asp:Label runat="server" ID="lblNewPasswordErrorMessage"></asp:Label></li>
                                <br />
                                <li><i class="chevron right icon"></i>
                                    <asp:Label runat="server" ID="lblNewPasswordRepeatingErrorMessage"></asp:Label></li>
                                <br />
                                <li><i class="chevron right icon"></i>
                                    <asp:Label runat="server" ID="lblNewPasswordSequentialErrorMessage"></asp:Label></li>
                            </div>
                        </div>
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
                            <asp:LinkButton runat="server" class="btn btn-primary btn-sm" ID="lbChangePassword"
                                OnClick="lbChangePassword_Click" OnClientClick="if(Page_ClientValidate('changePasswordValidation')) {if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                                Text="Change Password" CausesValidation="true" ValidationGroup="changePasswordValidation"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript" language="javascript">
            if (window.history.replaceState) {
                window.history.replaceState(null, null, window.location.href);
            }
        </script>
        <script type="text/javascript">
            function successRedirect(linkURL, message) {
                Swal.fire({
                    titleText: "Success!",
                    text: message,
                    type: "success",
                    allowEscapeKey: false
                }).then(function () {
                    window.location.href = linkURL;
                })
            }
        </script>
        <script type="text/javascript">
            function noAccessRedirect(linkURL) {
                Swal.fire({
                    titleText: "You are not authorized to view this page.",
                    type: "error",
                    allowOutsideClick: false,
                    allowEscapeKey: false,
                    backdrop: `
                rgba(105,105,105,1)
              `
                }).then(function () {
                    window.location.href = linkURL;
                })
            }
        </script>
    </form>
</body>
</html>
