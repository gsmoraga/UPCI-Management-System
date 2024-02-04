<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="dept-ministry-view.aspx.cs" Inherits="Template.dept_ministry_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Ministry Department Maintenance</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item"><a>Ministry Department Maintenance</a></li>
                            <li class="breadcrumb-item active">View</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>

        <!-- Main content -->
        <section class="content">
            <!-- Default box -->
            <div class="card">
                <div class="card-header">
                    <h3 class="card-title">View</h3>
                    <div class="card-tools">
                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                            <i class="fas fa-minus"></i>
                        </button>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-12 col-md-12 col-lg-8 order-2 order-md-1">
                            <%--<h3 class="text-dark">Ministry Details</h3>--%>
                            <div class="row">
                                <div class="col-12 col-sm-12">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">Code</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblCode" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-12">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">Description</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblDescription" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-12">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">Ministry</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblMinistry" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
            <div class="row">
                <div class="col-12">
                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-secondary" OnClick="btnCancel_Click">Back</asp:LinkButton>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
