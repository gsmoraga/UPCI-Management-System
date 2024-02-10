<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Template.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="contents/AdminLTE/plugins/fontawesome-free/css/all.min.css" />
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="contents/AdminLTE/plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="contents/AdminLTE/dist/css/adminlte.min.css" />

    <link rel="stylesheet" type="text/css" href="contents/css/semantic.min.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <%--<link rel="stylesheet" type="text/css" href="contents/css/signin.css" />--%>
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <style type="text/css">
        @font-face {
            font-family: poppinsBold;
            src: url(contents/fonts/Poppins-Bold.ttf);
        }
    </style>
</head>
<body class="hold-transition login-page">
    <form id="Form1" class="form-signin" action="" runat="server">
        <div class="login-box">
            <!-- /.login-logo -->
            
            
            <div class="card card-outline card-primary">
                <div class="card-header text-center">
                    <img alt="" src="contents/images/ums-logo.png" height="120" width="340" />
                </div>
                <div class="card-body">
                    <p class="login-box-msg">Sign in to start your session</p>

                    <form  action="../../index3.html" method="post">
                        <div class="input-group mb-3">
                            <asp:TextBox ID="txtUserId" runat="server" class="form-control" placeholder="User ID"
                                autocomplete="off" MaxLength="50" autofocus></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="input-group mb-3">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"
                                placeholder="Password" autocomplete="off" MaxLength="50"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-lock"></span>
                                </div>
                            </div>
                        </div>
                        <p id="pCapslockWarning" style="color: red; display: none">
                            WARNING: Caps lock is ON.
                        </p>
                        <div class="mb-3">
                            <asp:Label runat="server" ID="lblError" ForeColor="Red">&nbsp;</asp:Label>
                        </div>
                        <%--<div class="col-12">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" onclick="showPassword()" />
                                <label class="form-check-label" for="rememberMe">Show Password</label>
                            </div>
                        </div>--%>
                        <div class="row">
                            <!-- /.col -->
                            <div class="col-12">
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary w-100" Font-Size="Medium"
                                    Text="LOGIN" OnClientClick="if(Page_ClientValidate()) { if(this.value === 'Logging in...') { return false; } else { this.value = 'Logging in...'; } }"
                                    OnClick="btnLogin_Click" />
                            </div>
                            <!-- /.col -->
                        </div>
                    </form>

                    <div class="social-auth-links text-center mt-2 mb-3">
                    </div>
                    <!-- /.social-auth-links -->
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.login-box -->
        <div class="modal fade" id="activeSessionModal" tabindex="-1">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="activeSessionModalTitle">Active Session Alert</h5>
                        <button type="button" class="btn btn-close" data-bs-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        You have an existing active session on another device. Would you like to log out
            that session?
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton class="btn btn-primary mr-2" runat="server" ID="lbActiveSessionModal"
                            OnClick="lbActiveSessionModal_Click" OnClientClick="if(this.value === 'Logging out...') { return false; } else { this.value = 'Logging out...'; }">Yes</asp:LinkButton>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">
                            No</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Vertically centered Modal-->

        <div class="modal fade" id="activeSessionModals" runat="server" tabindex="-1" role="dialog"
            aria-labelledby="activeSessionModalTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header bg-maan3">
                        <h5 class="modal-title"></h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        You have an existing active session on another device. Would you like to log out
            that session?
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript">
            function warningRedirect(linkURL, title, message) {
                Swal.fire({
                    titleText: title,
                    text: message,
                    type: "warning",
                    allowEscapeKey: false
                }).then(function () {
                    window.location.href = linkURL;
                })
            }

            function OpenActiveSessionModal() {
                $('#activeSessionModal').modal('show');
            }

            var input = document.getElementById("<%=txtPassword.ClientID%>");
            var text = document.getElementById("pCapslockWarning");

            input.addEventListener("keyup", function (event) {
                if (event.getModifierState("CapsLock")) {
                    text.style.display = "block";
                } else {
                    text.style.display = "none"
                }
            });

            function showPassword() {
                var x = document.getElementById("txtPassword");
                if (x.type === "password") {
                    x.type = "text";
                } else {
                    x.type = "password";
                }
            }
        </script>


        <!-- jQuery -->
        <script type="text/javascript" src="contents/AdminLTE/plugins/jquery/jquery.min.js"></script>
        <!-- Bootstrap 4 -->
        <script type="text/javascript" src="contents/AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- AdminLTE App -->
        <script type="text/javascript" src="contents/AdminLTE/dist/js/adminlte.min.js"></script>
    </form>
</body>
</html>
