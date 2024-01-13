<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user-manual.aspx.cs" Inherits="Template.user_manual" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="refresh" content="2500" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <title>CLICKS | Survey Form</title>
    <link rel="shortcut icon" href="contents/images/favicon.ico" />
    <link rel="stylesheet" type="text/css" href="contents/css/semantic.min.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <script type="text/javascript" src="contents/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="contents/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <script type="text/javascript" src="contents/js/main.js"></script>
    <script type="text/javascript" src="contents/js/template.js"></script>


    <!-- Font Awesome -->
    <link
        rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" />

    <!-- sweet alert-->
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>

    <style type="text/css">
        @font-face {
            font-family: poppinsMedium;
            src: url(contents/fonts/Poppins-Medium.ttf);
        }

        .user-manual {
            font-size: 70px;
            font-weight: 700;
            font-family: poppinsMedium;
            max-width: 1400px;
        }

        .user-card {
            padding-top: 90px;
            padding-bottom: 90px;
            background-color: #282A35 !important;
            color: white !important;
            text-align: center !important;
        }

        #main {
            padding: 0;
            border-right: none;
            width: 100%;
            margin-top: 88px;
        }

        .section1 {
            background-color: #D9EEE1 !important;
            color: black !important;
            padding-top: 32px !important;
            padding-bottom: 32px !important;
        }

        .section2 {
            background-color: #FFF4A3 !important;
            color: black !important;
            padding-top: 32px !important;
            padding-bottom: 32px !important;
        }

        .section3 {
            background-color: #282A35 !important;
            color: white !important;
            padding-top: 32px !important;
            padding-bottom: 32px !important;
        }

        .section4 {
            background-color: #F3ECEA !important;
            color: black !important;
            padding-top: 32px !important;
            padding-bottom: 32px !important;
        }

        .section5 {
            background-color: #96D4D4 !important;
            color: black !important;
            padding-top: 32px !important;
            padding-bottom: 32px !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div class="user-card">
                <div class="card-body">
                    <h1 class="user-manual">User Manual</h1>
                </div>
            </div>
            <div class="section1">

                <div class="content-1" style="max-width: 980px; margin-left: auto; margin-right: auto;">
                    <div style="text-align: center!important; padding: 3%; width: 49.99999%;">
                        <h1 style="font-size: 70px; font-weight: 700; margin-top: -18px!important;">Homepage</h1>
                        <p style="font-size: 19px; margin-top: 1.2em; margin-bottom: 1.2em">Steps:</p>
                    </div>

                </div>



            </div>
            <div class="section2">
                <div class="content-2" style="max-width: 980px; margin-left: auto; margin-right: auto;">
                    <h1 style="font-size: 70px; font-weight: 700; margin-top: -18px!important;">Survey Form - First Page</h1>
                    <p style="font-size: 19px; margin-top: 1.2em; margin-bottom: 1.2em">Steps:</p>
                    <div style="padding: 3%">
                        <div style="background-color: #E7E9EB; color: #000; border-radius: 5px; padding: 16px;">
                            <div style="height: 300px; border-left: 4px solid #04AA6D; font-size: 15px; margin-top: 16px!important; margin-bottom: 16px!important; background-color: #fff; color: #000; padding: 8px 12px; word-wrap: break-word;">
                                <input type="image" src="img_submit.gif" alt="Submit" width="48" height="48" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="section3">
                <div class="content-3" style="max-width: 980px; margin-left: auto; margin-right: auto;">
                    <h1 style="font-size: 70px; font-weight: 700; margin-top: -18px!important;">Survey Form - Second Page</h1>
                    <p style="font-size: 19px; margin-top: 1.2em; margin-bottom: 1.2em">Steps:</p>
                    <div style="padding: 3%">
                        <div style="background-color: #E7E9EB; color: #000; border-radius: 5px; padding: 16px;">
                            <div style="height: 300px; border-left: 4px solid #04AA6D; font-size: 15px; margin-top: 16px!important; margin-bottom: 16px!important; background-color: #fff; color: #000; padding: 8px 12px; word-wrap: break-word;">
                                <input type="image" src="img_submit.gif" alt="Submit" width="48" height="48" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="section4">
                <div class="content-4" style="max-width: 980px; margin-left: auto; margin-right: auto;">
                    <h1 style="font-size: 70px; font-weight: 700; margin-top: -18px!important;">Survey Form - Acknowledgement Page</h1>
                    <p style="font-size: 19px; margin-top: 1.2em; margin-bottom: 1.2em">Steps:</p>
                    <div style="padding: 3%">
                        <div style="background-color: #E7E9EB; color: #000; border-radius: 5px; padding: 16px;">
                            <div style="height: 300px; border-left: 4px solid #04AA6D; font-size: 15px; margin-top: 16px!important; margin-bottom: 16px!important; background-color: #fff; color: #000; padding: 8px 12px; word-wrap: break-word;">
                                <input type="image" src="img_submit.gif" alt="Submit" width="48" height="48" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="section5">
            </div>
        </div>
    </form>
</body>

</html>
