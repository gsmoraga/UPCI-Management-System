<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lockscreen.aspx.cs" Inherits="Template.lockscreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>UPCI | Lockscreen</title>

    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="contents/AdminLTE/plugins/fontawesome-free/css/all.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="contents/AdminLTE/dist/css/adminlte.min.css" />
</head>
<body class="hold-transition lockscreen">
    <!-- Automatic element centering -->
    <div class="lockscreen-wrapper">
        <div class="lockscreen-logo">
            <a href="#"><b>UPCI</b>Management System</a>
        </div>
        <!-- User name -->
        <div class="lockscreen-name">
            <asp:Label ID="lblFullName" CssClass="form-label" runat="server"></asp:Label></div>

        <!-- START LOCK SCREEN ITEM -->
        <div class="lockscreen-item">
            <!-- lockscreen image -->
            <div class="lockscreen-image">
                <img src="contents/images/upci.png" alt="User Image">
            </div>
            <!-- /.lockscreen-image -->

            <!-- lockscreen credentials (contains the form) -->
            <form class="lockscreen-credentials" runat="server">
                <div class="input-group">
                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server" placeholder="password" autocomplete="off" MaxLength="50"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:LinkButton ID="lbLogin" runat="server" CssClass="btn" OnClick="lbLogin_Click"><i class="fas fa-arrow-right text-muted"></i></asp:LinkButton>
                    </div>
                </div>
                <p id="pCapslockWarning" style="color: red; display: none">
                    WARNING: Caps lock is ON.
                </p>
                <div class="mb-3">
                    <asp:Label runat="server" ID="lblError" ForeColor="Red">&nbsp;</asp:Label>
                </div>
            </form>
            <!-- /.lockscreen credentials -->

        </div>
        <!-- /.lockscreen-item -->
        <div class="help-block text-center">
            Enter your password to retrieve your session
        </div>
        <div class="text-center">
            <a href="logout.aspx">Or sign in as a different user</a>
        </div>
        <div class="lockscreen-footer text-center">
            Copyright &copy; <span id="year"></span> <b><a href="https://www.facebook.com/UPCIPunturin/" class="text-black">Universal Pentecostal Church Inc.</a></b><br>
            All rights reserved
        </div>
    </div>
    <!-- /.center -->

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

    //function OpenActiveSessionModal() {
    //    $('#activeSessionModal').modal('show');
    //}
    document.getElementById("year").innerHTML = new Date().getFullYear();

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
    <script src="contents/AdminLTE/plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="contents/AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
</body>
</html>
