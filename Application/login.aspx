<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Template.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Standard Meta -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
    <title>Login</title>
    <link rel="icon" href="contents/images/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="contents/css/semantic.min.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/signin.css" />
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <style type="text/css">
        @font-face {
            font-family: poppinsMedium;
            src: url(contents/fonts/Poppins-Medium.ttf);
        }

        .btn {
            font-family: poppinsMedium;
        }

        .form-control {
            font-family: poppinsMedium;
        }
    </style>
</head>
<body class="text-center" ondragstart="return false" draggable="false" style="background-color: azure">
    <form id="Form1" class="form-signin" action="" runat="server">


        <img src="../contents/images/UCPB Logo.png" class="img-fluid" alt="Application" />


        <div class="card">
            <div class="card-body">

                <label for="txtUserId" class="sr-only">
                    User ID</label>
                <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" placeholder="User ID"
                    autocomplete="off" MaxLength="50" required autofocus></asp:TextBox>
                <label for="txtPassword" class="sr-only">
                    Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"
                    placeholder="Password" autocomplete="off" MaxLength="50" required></asp:TextBox>
                <p id="pCapslockWarning" style="color: red; display: none">
                    WARNING: Caps lock is ON.
                </p>
                <div class="mb-3">
                    <asp:Label runat="server" ID="lblError" ForeColor="Red">&nbsp;</asp:Label>
                </div>
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-outline-primary btn-block" Font-Size="Medium"
                    Text="LOGIN" OnClientClick="if(Page_ClientValidate()) { if(this.value === 'Logging in...') { return false; } else { this.value = 'Logging in...'; } }"
                    OnClick="btnLogin_Click" Style="border-radius: 20px;" />

                <div class="row justify-content-start mt-2" style="font-family: poppinsMedium;">

                    <div class="col-md-6">
                        <p class="mt-1 text-muted small" style="text-align: right">
                            <input type="checkbox" runat="server" onclick="showPassword()" />
                            &nbsp;
                        Show Password
                        </p>
                    </div>
                    <div class="col-md-6">
                        <p class="mt-1 text-muted small" style="text-align: right">
                            Version 1.0
                        </p>
                    </div>

                </div>

                <p class="mt-4 mb-3 text-muted" style="font-family: poppinsMedium;">
                    <i class="copyright icon"></i>2023 UCPB Savings Bank
                </p>
            </div>

        </div>
        <div class="modal fade" id="activeSessionModal" runat="server" tabindex="-1" role="dialog"
            aria-labelledby="activeSessionModalTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header bg-maan3">
                        <h5 class="modal-title" id="activeSessionModalTitle">Active Session Alert</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        You have an existing active session on another device. Would you like to log out
                    that session?
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton class="btn btn-maan1 mr-2" runat="server" ID="lbActiveSessionModal"
                            OnClick="lbActiveSessionModal_Click" OnClientClick="if(this.value === 'Logging out...') { return false; } else { this.value = 'Logging out...'; }">Yes</asp:LinkButton>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">
                            No</button>
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
    </form>
</body>
</html>
