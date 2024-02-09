<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="user-view.aspx.cs" Inherits="Template.user_view" %>

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
                        <h1>
                            <asp:Label ID="contentHeader" runat="server"></asp:Label></h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="home.aspx">Home</a></li>
                            <li class="breadcrumb-item"><a>
                                <asp:Label ID="mainBreadcrumb" runat="server"></asp:Label></a></li>
                            <li class="breadcrumb-item active">
                                <asp:Label ID="subItemBreadcrumb" runat="server"></asp:Label></li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>

        <!-- Main content -->
        <section class="content">
            <!-- Default box -->
            <div class="row">
                <div class="col-md-6">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title">User Information</h3>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="col-12 col-sm-12">
                                <div class="info-box bg-light">
                                    <div class="info-box-content">
                                        <span class="info-box-text text-center text-muted">User ID</span>
                                        <span class="info-box-number text-center text-muted mb-0">
                                            <asp:Label ID="lblUserID" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12">
                                <div class="info-box bg-light">
                                    <div class="info-box-content">
                                        <span class="info-box-text text-center text-muted">User Group</span>
                                        <span class="info-box-number text-center text-muted mb-0">
                                            <asp:Label ID="lblUserGroup" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12">
                                <div class="info-box bg-light">
                                    <div class="info-box-content">
                                        <span class="info-box-text text-center text-muted">First Name</span>
                                        <span class="info-box-number text-center text-muted mb-0">
                                            <asp:Label ID="lblFirstName" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12">
                                <div class="info-box bg-light">
                                    <div class="info-box-content">
                                        <span class="info-box-text text-center text-muted">Middle Name</span>
                                        <span class="info-box-number text-center text-muted mb-0">
                                            <asp:Label ID="lblMiddleName" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12">
                                <div class="info-box bg-light">
                                    <div class="info-box-content">
                                        <span class="info-box-text text-center text-muted">Last Name</span>
                                        <span class="info-box-number text-center text-muted mb-0">
                                            <asp:Label ID="lblLastName" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- card-body -->
                    </div>
                    <!-- card -->

                </div>
                <div class="col-md-6">
                    <div class="card card-secondary">
                        <div class="card-header">
                            <h3 class="card-title">Other Information</h3>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="col-12 col-sm-12">
                                <div class="info-box bg-light">
                                    <div class="info-box-content">
                                        <span class="info-box-text text-center text-muted">Email</span>
                                        <span class="info-box-number text-center text-muted mb-0">
                                            <asp:Label ID="lblEmail" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12">
                                <div class="info-box bg-light">
                                    <div class="info-box-content">
                                        <span class="info-box-text text-center text-muted">Mobile Number</span>
                                        <span class="info-box-number text-center text-muted mb-0">
                                            <asp:Label ID="lblMobileNumber" runat="server"></asp:Label></span>
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
                            <div class="col-12 col-sm-12">
                                <div class="info-box bg-light">
                                    <div class="info-box-content">
                                        <span class="info-box-text text-center text-muted">Ministry Department</span>
                                        <span class="info-box-number text-center text-muted mb-0">
                                            <asp:Label ID="lblMinistryDepartment" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12">
                                <div class="info-box bg-light">
                                    <div class="info-box-content">
                                        <span class="info-box-text text-center text-muted">Profile Expiration Date</span>
                                        <span class="info-box-number text-center text-muted mb-0">
                                            <asp:Label ID="lblProfileExpirationDate" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12">
                                <div class="info-box bg-light">
                                    <div class="info-box-content">
                                        <span class="info-box-text text-center text-muted">Status</span>
                                        <span class="info-box-number text-center text-muted mb-0">
                                            <asp:Label ID="lblStatus" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
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
