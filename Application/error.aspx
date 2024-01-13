<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Template.error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
    <!-- Site Properties -->
    <title>Error encountered!</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
    </script>
</head>
<body ondragstart="return false" draggable="false">
    <form id="form1" runat="server">
    <div class="container text-center" style="font-family: Arial">
        <h1>
        </h1>
        <h1 class="text-center mt-5">
            An unexpected error has occurred.</h1>
        <p class="m-3">
            Please try again in a few minutes.
            <br />
            <br />
            If the error persists, please contact the system administrator with the following
            details:
        </p>
        <p class="col-md-8 offset-md-4 text-left">
            &#9656; Time of the error
            <br />
            &#9656; Actions that led to the error
            <br />
            &#9656; Other details that may be useful
            <br />
        </p>
        <asp:Button runat="server" ID="btnback" Text="Back to Login" class="btn btn-primary m-3"
            OnClick="btnback_Click" />
    </div>
    </form>
</body>
</html>
