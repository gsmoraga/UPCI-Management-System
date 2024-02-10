<%@ Page Title="" Language="C#" MasterPageFile="~/UMS.Master" AutoEventWireup="true" CodeBehind="parameters-application.aspx.cs" Inherits="Template.application_parameters" %>

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
                        <h1><asp:Label ID="contentHeader" runat="server"></asp:Label>
                        </h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="home.aspx">Home</a></li>
                            <li class="breadcrumb-item">
                                <asp:Label ID="mainBreadcrumb" runat="server"></asp:Label></li>
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
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card card-primary">
                        <div class="card-header">
                            <h3 class="card-title"><asp:label ID="cardTitle" runat="server"></asp:label>
                            </h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse" title="Collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label for="txtCode" id="Label1" runat="server">Website URL</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtWebsiteUrl" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the URL of the website's default page that will appear in email notifications"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtWebsiteUrl" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator67" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a valid URL containg the protocol and domain." ControlToValidate="txtWebsiteUrl" ValidationExpression="https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <%--<div class="form-group">
                                <label for="txtCode" id="Label2" runat="server">Audit log batch purging date range</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtAuditLogPurge" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of days the audit logs will be kept before being purged from the system"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtAuditLogPurge" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtAuditLogPurge" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label3" runat="server">Retention days for all successful transactions</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtRetentionSuccess" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of days that successful transactions will be retained before being automatically purged from the system"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtRetentionSuccess" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtRetentionSuccess" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label4" runat="server">Retention days for all pending transactions</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtRetentionPending" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of days that pending transactions will be retained before being automatically purged from the system"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtRetentionPending" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtRetentionPending" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <label for="txtCode" id="Label5" runat="server">Church Email Address</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the email address of the church that will be part of the email body of transaction notifications"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Invalid email." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label2" runat="server">Church hotline no.</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtChurchHotline" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the Phone numbers of the church that will be part of the email body of transaction notifications"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtChurchHotline" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtChurchHotline" ValidationExpression="^[a-zA-Z0-9\s-()]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label3" runat="server">Church name</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtChurchName" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the name of the church that will be part of the email body of transaction notifications"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtChurchName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revChurchName" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtChurchName" ValidationExpression="^[a-zA-Z0-9\s]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label4" runat="server">Default no. of days for profile expiration</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtProfileExpiration" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of days before a profile will expire"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtProfileExpiration" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtProfileExpiration" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label6" runat="server">Email engine - sender address (from)</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtEmailEngineSender" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the sender email address that will appear when receiving an email from the bank"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtEmailEngineSender" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Invalid email." ControlToValidate="txtEmailEngineSender" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label7" runat="server">Maximum number of mobile devices allowed</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtMaxMobileDevices" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the maximum number of mobile devices to be enrolled in mobile application"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtMaxMobileDevices" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtMaxMobileDevices" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label8" runat="server">No. of days before profile expiry reminder</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtProfileExpiryReminder" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of days from the profile expiration date the user will be reminded about the expiration"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtProfileExpiryReminder" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtProfileExpiryReminder" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label9" runat="server">No. of days before password expiry reminder</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtPasswordExpiryReminder" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of days from the password expiration date the user will be reminded about the expiration"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtPasswordExpiryReminder" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtPasswordExpiryReminder" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label10" runat="server">Report header</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtReportHeader" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the header for the reports"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtReportHeader" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revReportHeader" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtReportHeader" ValidationExpression="^[a-zA-Z0-9\s-]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label11" runat="server">Special characters allowed</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtSpecialCharactersAllowed" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the list of special characters allowed in the application"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtSpecialCharactersAllowed" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label12" runat="server">Special characters not allowed for username</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtSpecialCharactersNotAllowed" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the list of characters that will not be accepted when validating user IDs"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtSpecialCharactersNotAllowed" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label13" runat="server">Recent activity default purging date range</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtTaskSummaryPurge" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the number of days recent activities will be kept before being purged from the system"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtTaskSummaryPurge" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtTaskSummaryPurge" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtCode" id="Label14" runat="server">Maximum record count for data tables</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtMaxRecordCount" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="fa fa-question-circle" data-toggle="tooltip" data-placement="auto" title="Defines the maximum number of record count of data table that can be downloaded"></i>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtMaxRecordCount" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator35" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtMaxRecordCount" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                        </div>
                        <!-- Card body-->

                    </div>
                    <!-- Card -->
                </div>
            </div>
            <div class="row">
                <div class="col-10">
                    <asp:LinkButton runat="server" class="btn btn-success float-right" ID="lbSaveApplicationParameters" OnClick="lbSaveApplicationParameters_Click" Text="Save Changes"
                        OnClientClick="if(Page_ClientValidate('applicationParametersValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                        CausesValidation="true" ValidationGroup="applicationParametersValidation"></asp:LinkButton>
                </div>
            </div>
            <br />
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
