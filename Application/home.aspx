<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true"
    CodeBehind="home.aspx.cs" Inherits="Template.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .card-title {
            font-size: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0">Dashboard</h1>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Dashboard</li>
                        </ol>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->

        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <!-- Info Boxes -->
                <div class="row">
                    <div class="col-12 col-sm-6 col-md-3">
                        <div class="info-box">
                            <span class="info-box-icon bg-warning elevation-1"><i class="fas fa-users"></i></span>

                            <div class="info-box-content">
                                <span class="info-box-text">Youth</span>
                                <span class="info-box-number">
                                    <asp:Label ID="lblYouth" runat="server"></asp:Label>
                                </span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <div class="col-12 col-sm-6 col-md-3">
                        <div class="info-box">
                            <span class="info-box-icon bg-success elevation-1"><i class="fas fa-users"></i></span>

                            <div class="info-box-content">
                                <span class="info-box-text">Young Adults</span>
                                <span class="info-box-number">
                                    <asp:Label ID="lblYoungAdults" runat="server"></asp:Label>
                                </span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <div class="col-12 col-sm-6 col-md-3">
                        <div class="info-box">
                            <span class="info-box-icon bg-primary elevation-1"><i class="fas fa-users"></i></span>

                            <div class="info-box-content">
                                <span class="info-box-text">Mens</span>
                                <span class="info-box-number">
                                    <asp:Label ID="lblMens" runat="server"></asp:Label>
                                </span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                    <div class="col-12 col-sm-6 col-md-3">
                        <div class="info-box">
                            <span class="info-box-icon bg-danger elevation-1"><i class="fas fa-users"></i></span>

                            <div class="info-box-content">
                                <span class="info-box-text">Womens</span>
                                <span class="info-box-number">
                                    <asp:Label ID="lblWomens" runat="server"></asp:Label>
                                </span>
                            </div>
                            <!-- /.info-box-content -->
                        </div>
                        <!-- /.info-box -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <%--<h5 class="card-title">Monthly Recap Report</h5>--%>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-8">
                                        <p class="text-center">
                                            <strong></strong>
                                        </p>
                                        <h1 class="card-title">Welcome,<asp:Label runat="server" ID="lblName"></asp:Label></h1>
                                        <br />
                                        <br />
                                        <asp:Label ID="lblLatestLogInDate" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblExpirationAlert" runat="server" Visible="false"></asp:Label>
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md-4">
                                        <div class="card">
                                            <div class="card-body">
                                                <p class="text-center">
                                                    <strong>Recent Activity</strong>
                                                </p>
                                                <div class="activity">
                                                    <div class="list-unstyled list-unstyled-border" style="max-height: 350px; overflow: scroll; overflow-x: hidden;">
                                                        <asp:GridView ID="gvRecentActivity" runat="server" AllowPaging="False" CssClass="table"
                                                            GridLines="None" ShowHeader="False" CellPadding="4" ForeColor="#333333" OnRowDataBound="gvRecentActivity_RowDataBound">
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->
                            </div>
                            <!-- ./card-body -->
                        </div>
                        <!-- /.card -->
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->



            </div>
        </section>




    </div>





    <!-- Control Sidebar -->
    <aside class="control-sidebar control-sidebar-dark">
        <!-- Control sidebar content goes here -->
    </aside>


    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandlerHome);

            function EndRequestHandlerHome(sender, args) {
                $("#divTransactionStatusChart, #divBarChart, #divForActionAuto, #divForActionRel, #divRecentActivity").draggable({
                    stack: ".ui-widget-content",
                    containment: "#containment-wrapper",
                    scroll: false,
                    stop: function (event, ui) {
                        positions[this.id] = {
                            'left': ui.position.left,
                            'top': ui.position.top,
                            'clientWidth': document.documentElement.clientWidth
                        };
                        localStorage.positions = JSON.stringify(positions);
                    }
                });
            }
        });

        $('.scrollable-gridview').ready(function () {
            var offset = 220;
            var duration = 500;
            $('.scrollable-gridview').scroll(function () {
                if ($(this).scrollTop() > offset) {
                    $('.back-to-top').fadeIn(duration);
                } else {
                    $('.back-to-top').fadeOut(duration);
                }
            });

            $('.back-to-top').click(function (event) {
                event.preventDefault();
                $('.scrollable-gridview').animate({ scrollTop: 0 }, duration);
                return false;
            })
        });

        $(function () {
            var sSizes = localStorage.sizes || "{}",
                sizes = JSON.parse(sSizes);
            $.each(sizes, function (id, size) {
                $("#" + id).css({ width: size.width + 'px', height: size.height + 'px' });
            })

            $(".scrollable-gridview").resizable({
                containment: "#containment-wrapper",
                handles: 's'
            });

            var sPositions = localStorage.positions || "{}",
                positions = JSON.parse(sPositions);
            $.each(positions, function (id, pos) {
                var el = $("#" + id)[0];
                var left = pos.left;

                var multiplier = -1;

                if (pos.left > 0)
                    multiplier = 1;

                if (pos.clientWidth > document.documentElement.clientWidth) {
                    left = pos.left - (multiplier * ((pos.clientWidth - document.documentElement.clientWidth) / 2));
                }

                $("#" + id).animate({ left: left, top: pos.top }, 1000);
            })

            $("#divRecentActivity").draggable({
                stack: ".ui-widget-content",
                containment: "#containment-wrapper",
                scroll: false,
                stop: function (event, ui) {
                    positions[this.id] = {
                        'left': ui.position.left,
                        'top': ui.position.top,
                        'clientWidth': document.documentElement.clientWidth
                    };
                    localStorage.positions = JSON.stringify(positions);
                }
            });
        });

        function isElementInViewport(el) {
            var rect = el.getBoundingClientRect();

            return (
                rect.top >= 0 &&
                rect.left >= 0 &&
                rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
                rect.right <= (window.innerWidth || document.documentElement.clientWidth)
            );
        }

        $(window).bind('resizeEnd', function () {
            var sPositions = localStorage.positions || "{}",
                positions = JSON.parse(sPositions);
            $.each(positions, function (id, pos) {
                var el = $("#" + id)[0];
                var left = pos.left;

                if (!isElementInViewport(el)) {
                    var multiplier = -1;

                    if (pos.left > 0)
                        multiplier = 1;

                    if (pos.clientWidth > window.innerWidth) {
                        left = pos.left - (multiplier * ((pos.clientWidth - document.documentElement.clientWidth + 5) / 2));
                    }
                }

                $("#" + id).animate({ left: left, top: pos.top }, 1000);
            })
        });

        $(window).on('resize', function () {
            if (this.resizeTO) clearTimeout(this.resizeTO);
            this.resizeTO = setTimeout(function () {
                $(this).trigger('resizeEnd');
            }, 500);
        });
    </script>


</asp:Content>
