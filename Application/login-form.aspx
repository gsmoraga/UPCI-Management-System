<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login-form.aspx.cs" Inherits="Template.login_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">




    <!-- Vendor CSS Files -->
    <link href="contents/NiceAdmin/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="contents/NiceAdmin/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />


    <!-- Template Main CSS File -->
    <link href="contents/NiceAdmin/css/style.css" rel="stylesheet" />


    <link rel="stylesheet" type="text/css" href="contents/css/semantic.min.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <%--<link rel="stylesheet" type="text/css" href="contents/css/signin.css" />--%>
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <style>
        @font-face {
            font-family: poppinsBold;
            src: url(contents/fonts/Poppins-Bold.ttf);
        }
    </style>
</head>
<body>
    <form runat="server">
        <main>
            <div class="container">

                <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-4">
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center">

                                <div class="d-flex justify-content-center py-4">
                                    <a href="#" class="logo d-flex align-items-center w-auto">
                                        <img src="contents/images/upci-logo.png" style="width: auto; height: auto" />
                                        <span class="d-none d-lg-block">LOGIN</span>
                                    </a>
                                </div>
                                <!-- End Logo -->

                                <div class="card mb-3">
                                    <div class="card-body">
                                        <div class="pt-4 pb-2">
                                            <h5 class="card-title text-center pb-0 fs-4">Login</h5>
                                            <%--<p class="text-center small">Information System</p>--%>
                                        </div>

                                        <div class="row g-3 ">
                                            <div class="col-12">
                                                <div class="form-floating">
                                                    <asp:TextBox ID="txtUserId" runat="server" class="form-control" placeholder="User ID"
                                                        autocomplete="off" MaxLength="50" autofocus></asp:TextBox>
                                                    <label for="yourUsername" class="form-label">User ID</label>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-floating">
                                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"
                                                        placeholder="Password" autocomplete="off" MaxLength="50"></asp:TextBox>
                                                    <label for="yourPassword" class="form-label">Password</label>
                                                </div>
                                            </div>
                                            <p id="pCapslockWarning" style="color: red; display: none">
                                                WARNING: Caps lock is ON.
                                            </p>
                                            <div class="mb-3">
                                                <asp:Label runat="server" ID="lblError" ForeColor="Red">&nbsp;</asp:Label>
                                            </div>
                                            <div class="col-12">
                                                <div class="form-check">
                                                    <input class="form-check-input" type="checkbox" onclick="showPassword()" />
                                                    <label class="form-check-label" for="rememberMe">Show Password</label>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary w-100" Font-Size="Medium"
                                                    Text="LOGIN" OnClientClick="if(Page_ClientValidate()) { if(this.value === 'Logging in...') { return false; } else { this.value = 'Logging in...'; } }"
                                                    OnClick="btnLogin_Click" />
                                                <%--<button class="btn btn-primary w-100" type="submit">Login</button>--%>
                                            </div>
                                        </div>


                                    </div>
                                </div>

                                <div class="credits">
                                    <a href="#">2023 Universal Pentecostal Church Inc.</a>
                                </div>

                            </div>
                        </div>
                    </div>

                </section>

            </div>
        </main>
        <!-- End #main -->

        <div class="modal fade" id="activeSessionModal" tabindex="-1">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="activeSessionModalTitle">Active Session Alert</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
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

        <!-- Template Main JS File -->
        <script src="contents/NiceAdmin/js/main.js"></script>


    </form>
</body>
</html>
