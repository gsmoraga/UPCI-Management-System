<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Template.Homepage" %>

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
                            <li class="breadcrumb-item active">Dashboard v1</li>
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
                <!-- Small boxes (Stat box) -->
                <div class="row">
                    <div class="col-lg-3 col-6">
                        <!-- small box -->
                        <div class="small-box bg-info">
                            <div class="inner">
                                <h3>150</h3>

                                <p>Young Professionals</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-bag"></i>
                            </div>
                            <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-6">
                        <!-- small box -->
                        <div class="small-box bg-success">
                            <div class="inner">
                                <h3>53<sup style="font-size: 20px">%</sup></h3>

                                <p>Youth</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-stats-bars"></i>
                            </div>
                            <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-6">
                        <!-- small box -->
                        <div class="small-box bg-warning">
                            <div class="inner">
                                <h3>44</h3>

                                <p>Mens</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-person-add"></i>
                            </div>
                            <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-6">
                        <!-- small box -->
                        <div class="small-box bg-danger">
                            <div class="inner">
                                <h3>65</h3>

                                <p>Womens</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-pie-graph"></i>
                            </div>
                            <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                        </div>
                    </div>
                    <!-- ./col -->
                </div>

                <div class="row">

                    <!-- Welcome Card -->
                    <div class="col-lg-8">
                        <div class="row">
                            <div class="col-12">
                                <div class="card">
                                    <div class="card-body">
                                        <h1 class="card-title">Welcome,<asp:Label runat="server" ID="lblName"></asp:Label></h1>
                                        <hr class="divider" />
                                        <asp:Label ID="lblLatestLogInDate" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblExpirationAlert" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Recent Activity -->
                    <div class="col-lg-4">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">Recent Activity
                                </h5>
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

                </div>


            </div>
        </section>




    </div>



    <footer class="main-footer">
        <strong>Copyright &copy; 2014-2021 <a href="https://adminlte.io">AdminLTE.io</a>.</strong>
        All rights reserved.
        <div class="float-right d-none d-sm-inline-block">
            <b>Version</b> 3.1.0
        </div>
    </footer>

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
