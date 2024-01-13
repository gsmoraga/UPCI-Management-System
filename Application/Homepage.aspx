<%@ Page Title="" Language="C#" MasterPageFile="~/UPCI.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Template.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .card-title {
            font-size: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Main Content -->
    <section class="section dashboard">
        <div class="row">
            <div class="col-lg-8">
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <h1 class="card-title">Welcome,
                                    <asp:Label runat="server" ID="lblName"></asp:Label>
                                </h1>
                                <hr />
                                <asp:Label ID="lblLatestLogInDate" runat="server"></asp:Label><br />
                                <asp:Label ID="lblExpirationAlert" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
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
    </section>


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
