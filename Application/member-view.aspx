<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="member-view.aspx.cs" Inherits="Template.member_view" %>

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
                        <h1>Member Details</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Member Detail</li>
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
                    <h3 class="card-title">Member Details</h3>
                    <div class="card-tools">
                        <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                            <i class="fas fa-minus"></i>
                        </button>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-12 col-md-12 col-lg-8 order-2 order-md-1">
                            <h3 class="text-dark">General Information</h3>
                            <div class="row">
                                <div class="col-12 col-sm-4">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">Member ID</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblMemberId" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-4">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">First Name</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblFirstName" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-4">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">Middle Name</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblMiddleName" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-4">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">Last Name</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblLastName" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-12 col-sm-12">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">Email</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblEmail" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-12 col-sm-4">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">Gender</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblGender" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-4">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">Birthday</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblBirthday" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-4">
                                    <div class="info-box bg-light">
                                        <div class="info-box-content">
                                            <span class="info-box-text text-center text-muted">Mobile Number</span>
                                            <span class="info-box-number text-center text-muted mb-0">
                                                <asp:Label ID="lblMobileNumber" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                </div>
                            </div>



                        </div>

                        <div class="col-12 col-md-12 col-lg-4 order-1 order-md-2">
                            <h3 class="text-dark">Church Information</h3>
                            <div class="text-muted">
                                <p class="text-md">
                                    Ministry
                                    <b class="d-block">
                                        <asp:Label ID="lblMinistry" runat="server"></asp:Label></b>
                                </p>
                            </div>
                            <div class="text-muted">
                                <p class="text-md">
                                    Ministry Department
                                    <b class="d-block">
                                        <asp:Label ID="lblMinistryDepartment" runat="server"></asp:Label></b>
                                </p>
                            </div>
                            <div class="text-muted">
                                <p class="text-md">
                                    Cell
                                    <b class="d-block">
                                        <asp:Label ID="lblCell" runat="server"></asp:Label></b>
                                </p>
                            </div>
                            <div class="text-muted">
                                <p class="text-md">
                                    Baptismal
                                    <b class="d-block">
                                        <asp:Label ID="lblBaptismal" runat="server"></asp:Label></b>
                                </p>
                            </div>
                            <div class="text-muted">
                                <p class="text-md">
                                    PEPSOL
                                    <b class="d-block">
                                        <asp:Label ID="lblPepsol" runat="server"></asp:Label></b>
                                </p>
                            </div>
                            <div class="text-muted">
                                <p class="text-md">
                                    Membership Status
                                    <b class="d-block">
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label></b>
                                </p>
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
