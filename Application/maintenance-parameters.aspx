<%@ Page Title="" Language="C#" MasterPageFile="~/UPCI.Master" AutoEventWireup="true"
    CodeBehind="maintenance-parameters.aspx.cs" Inherits="Template.maintenance_parameters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="contents/js/treeviewcheckbox-style.js"></script>
    <script type="text/javascript" src="contents/js/treeview-check-uncheck.js"></script>
    <script type="text/javascript">

        $(function () {
            $('[data-toggle="tooltip"]').tooltip()
        })

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main class="my-form" ondragstart="return false" draggable="false">
        <div class="row justify-content-center m-1">
            <div class="col-md-8 text-md-center">
                <asp:Label runat="server" ID="lblHeader" Font-Bold="true" Font-Size="X-Large" CssClass="custom-header"></asp:Label>
                <br />
                &nbsp;
            </div>
        </div>
        <div class="container">
            <div class="row justify-content-left">
                <div class="col-md-12">
                    <div class="card" id="codeDescCard" runat="server" visible="false">
                        <div class="card-header" id="hCodeDesc" runat="server"></div>
                        <div class="card-body">
                            <div class="form-group row align-items-center" id="rowCode" runat="server">
                                <label for="txtCode" class="col-md-4 col-form-label text-md-right" id="lblCode" runat="server">Code</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtCode" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtCode" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revCode" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtCode" ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtDescription" class="col-md-4 col-form-label text-md-right">Description</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtDescription" MaxLength="350" class="form-control" autocomplete="off"></asp:TextBox>
                                    <asp:Label ID="lblDescription" runat="server" Text="" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtDescription" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revDescription" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtDescription" ValidationExpression="^[a-zA-Z0-9\s.,\-()]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center" id="rowCode2" runat="server" visible="false">
                                <label for="ddCode" class="col-md-4 col-form-label text-md-right" id="lblCode2" runat="server">Code</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddCode" runat="server" CssClass="form-select" autocomplete="off"></asp:DropDownList>
                                    <asp:Label runat="server" ID="lblDdCode" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator66" runat="server" ValidationGroup="codeDescValidation"
                                        ErrorMessage="Please select a value." ControlToValidate="ddCode" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center" id="rowRegion" runat="server" visible="false">
                                <label for="ddBranch" class="col-md-4 col-form-label text-md-right">Region</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddRegion" runat="server" CssClass="form-select" autocomplete="off">
                                    </asp:DropDownList>
                                    <asp:Label runat="server" ID="lblRegion" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Please select a value." ControlToValidate="ddRegion" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="form-group row align-items-center" id="rowEmail" runat="server" visible="false">
                                <label for="txtCodeDescEmail" class="col-md-4 col-form-label text-md-right">Email</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtCodeDescEmail" MaxLength="50" class="form-control" autocomplete="off" placeholder="Optional"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator44" runat="server" ValidationGroup="codeDescValidation" SetFocusOnError="true"
                                        ErrorMessage="Invalid email." ControlToValidate="txtCodeDescEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-md-4 offset-md-4">
                                <asp:LinkButton runat="server" class="btn btn-primary" ID="lbCodeDescCard" OnClick="lbCodeDescCard_Click" Text="Save"
                                    OnClientClick="if(Page_ClientValidate('codeDescValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                                    CausesValidation="true" ValidationGroup="codeDescValidation"></asp:LinkButton>
                                <asp:LinkButton runat="server" class="btn btn-outline-primary" ID="lbBackCodeDesc" OnClick="lbBack_Click" Text="Back"></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <!-- User Maintenance -->
                    <div class="card author-box card-primary" id="userCard" runat="server" visible="false">
                        <div class="card-header font-weight-bold" id="hUser" runat="server"></div>
                        <div class="card-body">
                            <div class="form-group row align-items-center">
                                <label for="txtUserId" class="col-md-4 col-form-label text-md-right">User ID</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtUserId" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtUserId" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="UserIDValidator" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtUserId" ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtEmployeeNumber" class="col-md-4 col-form-label text-md-right">Employee Number</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtEmployeeNumber" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtEmployeeNumber" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Must be numeric and have at least four digits." ControlToValidate="txtEmployeeNumber" ValidationExpression="^[0-9]{4,}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtFirstName" class="col-md-4 col-form-label text-md-right">First Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtFirstName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed." ControlToValidate="txtFirstName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtMiddleName" class="col-md-4 col-form-label text-md-right">Middle Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtMiddleName" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed." ControlToValidate="txtMiddleName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtLastName" class="col-md-4 col-form-label text-md-right">Last Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtLastName" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtLastName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Only alphabetic characters, periods, and hyphens are allowed." ControlToValidate="txtLastName" ValidationExpression="[ña-zA-Z.\s-]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="ddUserGroup" class="col-md-4 col-form-label text-md-right">User Group</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddUserGroup" runat="server" CssClass="form-select" autocomplete="off"
                                        OnSelectedIndexChanged="ddUserGroup_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:Label runat="server" ID="lblUserGroup" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="lbViewUserGroup" runat="server" ToolTip="View access rights" data-toggle="modal" data-target="#accessRightsModal" Visible="false"
                                                Text="" class="mr-2"><i class="eye large icon text-dark" style="text-decoration:none"></i></asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddUserGroup" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator63" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Please select a value." ControlToValidate="ddUserGroup" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="ddDepartment" class="col-md-4 col-form-label text-md-right">Department</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddDepartment" runat="server" CssClass="form-select" autocomplete="off"></asp:DropDownList>
                                    <asp:Label runat="server" ID="lblDepartment" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator64" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Please select a value." ControlToValidate="ddDepartment" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="ddBranch" class="col-md-4 col-form-label text-md-right">Branch</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddBranch" runat="server" CssClass="form-select" autocomplete="off"></asp:DropDownList>
                                    <asp:Label runat="server" ID="lblBranch" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator65" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Please select a value." ControlToValidate="ddBranch" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtProfileExpirationUser" class="col-md-4 col-form-label text-md-right">Profile Expiration Date</label>
                                <div class="col-md-4">

                                    <asp:TextBox runat="server" ID="txtProfileExpirationUser" MaxLength="50" class="form-control datepicker" autocomplete="off" placeholder="(Leave blank if no expiration)"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Must be of the format MM/DD/YYYY." ControlToValidate="txtProfileExpirationUser" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtEmail" class="col-md-4 col-form-label text-md-right">Email</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtEmail" MaxLength="50" class="form-control" autocomplete="off" placeholder="Optional"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Invalid email." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtMobileNumber" class="col-md-4 col-form-label text-md-right">Mobile Number</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtMobileNumber" MaxLength="50" class="form-control" autocomplete="off" placeholder="Optional"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Invalid mobile number." ControlToValidate="txtMobileNumber" ValidationExpression="(\+?\d{2}?\s?\d{3}\s?\d{3}\s?\d{4})|([0]\d{3}\s?\d{3}\s?\d{4})" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center" id="divStatus" runat="server" visible="false">
                                <label for="ddStatus" class="col-md-4 col-form-label text-md-right">Status</label>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" ID="ddStatus" CssClass="custom-select">
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="0">Disabled</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label runat="server" ID="lblStatus" Visible="false"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-8 offset-md-4">
                                <asp:LinkButton runat="server" class="btn btn-primary" ID="lbUser" OnClick="lbUser_Click" Text="Save"
                                    OnClientClick="if(Page_ClientValidate('userValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                                    CausesValidation="true" ValidationGroup="userValidation"></asp:LinkButton>
                                <asp:LinkButton runat="server" class="btn btn-outline-primary" ID="lbBackUser" OnClick="lbBack_Click" Text="Back"></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <!-- Application Maintenance -->
                    <div class="card author-box card-primary" id="applicationParametersCard" runat="server" visible="false">
                        <div class="card-body">
                            <div class="form-group row align-items-center">
                                <label for="txtWebsiteUrl" class="col-md-4 col-form-label text-md-right">Website URL</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtWebsiteUrl" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the URL of the website's default page that will appear in email notifications"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtWebsiteUrl" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator67" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a valid URL containg the protocol and domain." ControlToValidate="txtWebsiteUrl" ValidationExpression="https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtAuditLogPurge" class="col-md-4 col-form-label text-md-right">Audit log batch purging date range</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtAuditLogPurge" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of days the audit logs will be kept before being purged from the system"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtAuditLogPurge" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtAuditLogPurge" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center" runat="server" visible="false">
                                <label for="txtRetentionSuccess" class="col-md-4 col-form-label text-md-right">Retention days for all successful transactions</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtRetentionSuccess" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of days that successful transactions will be retained before being automatically purged from the system"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtRetentionSuccess" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtRetentionSuccess" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center" visible="false" runat="server">
                                <label for="txtRetentionPending" class="col-md-4 col-form-label text-md-right">Retention days for all pending transactions</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtRetentionPending" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of days that pending transactions will be retained before being automatically purged from the system"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtRetentionPending" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtRetentionPending" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtBankEmail" class="col-md-4 col-form-label text-md-right">Bank email address</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtBankEmail" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the email address of the bank that will be part of the email body of transaction notifications"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtBankEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Invalid email." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtBankHotline" class="col-md-4 col-form-label text-md-right">Bank hotline no.</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtBankHotline" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the Phone numbers of the bank that will be part of the email body of transaction notifications"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtBankHotline" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtBankHotline" ValidationExpression="^[a-zA-Z0-9\s-()]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtBankName" class="col-md-4 col-form-label text-md-right">Bank name</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtBankName" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the name of the bank that will be part of the email body of transaction notifications"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtBankName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtBankName" ValidationExpression="^[a-zA-Z0-9\s]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtProfileExpiration" class="col-md-4 col-form-label text-md-right">Default no. of days for profile expiration</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtProfileExpiration" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of days before a profile will expire"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtProfileExpiration" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtProfileExpiration" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center" runat="server" visible="false">
                                <label for="txtCeasPassingScore" class="col-md-4 col-form-label text-md-right">CEAS passing score</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtCeasPassingScore" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the passing score for the Credit Evaluation Approval Sheet"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtCeasPassingScore" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtCeasPassingScore" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtEmailEngineSender" class="col-md-4 col-form-label text-md-right">Email engine - sender address (from)</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtEmailEngineSender" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the sender email address that will appear when receiving an email from the bank"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtEmailEngineSender" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ValidationGroup="userValidation"
                                        ErrorMessage="Invalid email." ControlToValidate="txtEmailEngineSender" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtMaxMobileDevices" class="col-md-4 col-form-label text-md-right">Maximum number of mobile devices allowed</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtMaxMobileDevices" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the maximum number of mobile devices to be enrolled in mobile application"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtMaxMobileDevices" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtMaxMobileDevices" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtProfileExpiryReminder" class="col-md-4 col-form-label text-md-right">No. of days before profile expiry reminder</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtProfileExpiryReminder" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of days from the profile expiration date the user will be reminded about the expiration"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtProfileExpiryReminder" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtProfileExpiryReminder" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtPasswordExpiryReminder" class="col-md-4 col-form-label text-md-right">No. of days before password expiry reminder</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtPasswordExpiryReminder" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of days from the password expiration date the user will be reminded about the expiration"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtPasswordExpiryReminder" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtPasswordExpiryReminder" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtReportHeader" class="col-md-4 col-form-label text-md-right">Report header</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtReportHeader" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the header for the reports"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtReportHeader" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtReportHeader" ValidationExpression="^[a-zA-Z0-9\s-]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtSpecialCharactersAllowed" class="col-md-4 col-form-label text-md-right">Special characters allowed</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtSpecialCharactersAllowed" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the list of special characters allowed in the application"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtSpecialCharactersAllowed" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtSpecialCharactersNotAllowed" class="col-md-4 col-form-label text-md-right">Special characters not allowed for username</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtSpecialCharactersNotAllowed" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the list of characters that will not be accepted when validating user IDs"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtSpecialCharactersNotAllowed" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtTaskSummaryPurge" class="col-md-4 col-form-label text-md-right">Recent activity default purging date range</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtTaskSummaryPurge" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of days recent activities will be kept before being purged from the system"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtTaskSummaryPurge" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtTaskSummaryPurge" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtMaxRecordCount" class="col-md-4 col-form-label text-md-right">Maximum record count for data tables</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtMaxRecordCount" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the maximum number of record count of data table that can be downloaded"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtMaxRecordCount" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator35" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtMaxRecordCount" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center" runat="server" visible="false">
                                <label for="txtWorkHoursStartTime" class="col-md-4 col-form-label text-md-right">Work hours start time</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtWorkHoursStartTime" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the official starting time of work hours using the 24-hour clock"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtWorkHoursStartTime" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator39" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a valid time using the format HH:MM:SS." ControlToValidate="txtWorkHoursStartTime" ValidationExpression="^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center" runat="server" visible="false">
                                <label for="txtWorkHoursEndTime" class="col-md-4 col-form-label text-md-right">Work hours end time</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtWorkHoursEndTime" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the official ending time of work hours using the 24-hour clock"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtWorkHoursEndTime" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator49" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a valid time using the format HH:MM:SS." ControlToValidate="txtWorkHoursEndTime" ValidationExpression="^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center" runat="server" visible="false">
                                <label for="txtLunchHourStartTime" class="col-md-4 col-form-label text-md-right">Lunch hour start time</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtLunchHourStartTime" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the official starting time of the lunch hour using the 24-hour clock"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtLunchHourStartTime" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator53" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a valid time using the format HH:MM:SS." ControlToValidate="txtLunchHourStartTime" ValidationExpression="^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center" runat="server" visible="false">
                                <label for="txtLunchHourEndTime" class="col-md-4 col-form-label text-md-right">Lunch hour end time</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtLunchHourEndTime" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the official ending  time of the lunch hour using the 24-hour clock"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtLunchHourEndTime" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator55" runat="server" ValidationGroup="applicationParametersValidation"
                                        ErrorMessage="Must be a valid time using the format HH:MM:SS." ControlToValidate="txtLunchHourEndTime" ValidationExpression="^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-md-4 offset-md-4">
                                <asp:LinkButton runat="server" class="btn btn-primary" ID="lbSaveApplicationParameters" OnClick="lbSaveApplicationParameters_Click" Text="Save"
                                    OnClientClick="if(Page_ClientValidate('applicationParametersValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                                    CausesValidation="true" ValidationGroup="applicationParametersValidation"></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div class="card author-box card-primary" id="securityParametersCard" runat="server" visible="false">
                        <div class="card-body">
                            <div class="form-group row align-items-center">
                                <label for="txtMinPasswordLength" class="col-md-4 col-form-label text-md-right">Minimum password length</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtMinPasswordLength" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the minimum number of characters for passwords of users"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtMinPasswordLength" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator38" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be positive integer ranging from 1 to 50." ControlToValidate="txtMinPasswordLength" ValidationExpression="^(?:[1-9]|[1-4][0-9]|50)$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtPasswordExpiration" class="col-md-4 col-form-label text-md-right">Default no. of days for password expiration</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtPasswordExpiration" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of days before a front and back end user’s password will expire"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtPasswordExpiration" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator40" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtPasswordExpiration" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtAllowedRepeatingCharacters" class="col-md-4 col-form-label text-md-right">No. of allowed repeating characters in a password</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtAllowedRepeatingCharacters" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of times a character can be used in a password"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtAllowedRepeatingCharacters" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator41" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtAllowedRepeatingCharacters" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtAllowedSequentialCharacters" class="col-md-4 col-form-label text-md-right">No. of allowed sequential characters in a password</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtAllowedSequentialCharacters" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the length of sequential letters or numbers that can be used in a password"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtAllowedSequentialCharacters" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator42" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtAllowedSequentialCharacters" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtCumulativeInvalidPassword" class="col-md-4 col-form-label text-md-right">Maximum no. of cumulative invalid password retries</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtCumulativeInvalidPassword" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of cumulative invalid passwords during login before a user account will be disabled"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtCumulativeInvalidPassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator43" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtCumulativeInvalidPassword" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtInvalidPasswordTries" class="col-md-4 col-form-label text-md-right">Maximum no. of invalid password retries</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtInvalidPasswordTries" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of invalid passwords during login before a user account will be disabled"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtInvalidPasswordTries" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator45" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a positive integer." ControlToValidate="txtInvalidPasswordTries" ValidationExpression="^[1-9]\d*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtRecentPasswordsNotAllowed" class="col-md-4 col-form-label text-md-right">No. of recent passwords that cannot be used</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtRecentPasswordsNotAllowed" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the number of previously used passwords that cannot be used as the current password"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtRecentPasswordsNotAllowed" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator46" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtRecentPasswordsNotAllowed" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtSpecialCharactersAllowedSP" class="col-md-4 col-form-label text-md-right">Special characters allowed in a password</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtSpecialCharactersAllowedSP" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the list of characters that will be allowed if the password type allows special characters"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtSpecialCharactersAllowedSP" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator48" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must consist of special characters." ControlToValidate="txtSpecialCharactersAllowedSP" ValidationExpression="[^\w\s]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="ddPasswordType" class="col-md-4 col-form-label text-md-right">Password Type</label>
                                <div class="col-md-4 input-group">
                                    <asp:DropDownList runat="server" ID="ddPasswordType" CssClass="custom-select">
                                        <asp:ListItem Value="1">Alphabetic</asp:ListItem>
                                        <asp:ListItem Value="2">Numeric</asp:ListItem>
                                        <asp:ListItem Value="3">Alphanumeric</asp:ListItem>
                                        <asp:ListItem Value="4">Alphanumeric with special characters</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label runat="server" ID="lblPasswordType" Visible="false"></asp:Label>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the allowed character combination for passwords."></i>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtMobileActivation" class="col-md-4 col-form-label text-md-right">Validity of mobile activation (minutes)</label>
                                <div class="col-md-4 input-group">
                                    <asp:TextBox runat="server" ID="txtMobileActivation" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <i class="ri ri-question-line" data-toggle="tooltip" data-placement="auto" title="Defines the time the user should input the mobile activation code before it expires"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtMobileActivation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator47" runat="server" ValidationGroup="securityParametersValidation"
                                        ErrorMessage="Must be a non-negative integer." ControlToValidate="txtMobileActivation" ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-md-4 offset-md-4">
                                <asp:LinkButton runat="server" class="btn btn-primary" ID="lbSaveSecurityParameters" OnClick="lbSaveSecurityParameters_Click" Text="Save"
                                    OnClientClick="if(Page_ClientValidate('securityParametersValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                                    CausesValidation="true" ValidationGroup="securityParametersValidation"></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <!-- User Group -->
                    <div class="card author-box card-primary" id="userGroupCard" runat="server" visible="false">
                        <div class="card-header" id="hUserGroup" runat="server"></div>
                        <div class="card-body">
                            <div class="form-group row align-items-center">
                                <label id="Label1" for="txtCodeUG" class="col-md-4 col-form-label text-md-right" runat="server">Code</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtCodeUG" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator69" runat="server" ValidationGroup="userGroupValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtCodeUG" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator37" runat="server" ValidationGroup="userGroupValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtCodeUG" ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label for="txtDescriptionUG" class="col-md-4 col-form-label text-md-right">Description</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtDescriptionUG" MaxLength="50" class="form-control" autocomplete="off"></asp:TextBox>
                                    <asp:Label ID="lblDescriptionUG" runat="server" Text="" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" ValidationGroup="userGroupValidation"
                                        ErrorMessage="Required field." ControlToValidate="txtDescriptionUG" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator63" runat="server" ValidationGroup="userGroupValidation"
                                        ErrorMessage="Must be alphanumeric." ControlToValidate="txtDescriptionUG" ValidationExpression="^[a-zA-Z0-9\s]*$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="form-group row align-items-baseline" id="divUserList" runat="server" visible="false">
                                <label for="lblUserList" class="col-md-4 col-form-label text-md-right">User List</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblUserList" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                            <hr />

                            <div class="form-group row align-items-center">
                                <div class="col-md-12 text-md-center">
                                    Access Rights
                                </div>
                            </div>

                            <div class="form-group row justify-content-center">
                                <div class="col-md-10">
                                    <nav>
                                        <div class="nav nav-tabs" id="nav-tab" role="tablist">
                                            <a class="nav-item nav-link active" id="nav-backend-tab" data-toggle="tab" href="#backend-tab" role="tab" aria-controls="backend-tab" aria-selected="false">Backend</a>
                                            <a class="nav-item nav-link" id="nav-frontend-tab" data-toggle="tab" href="#frontend-tab" role="tab" aria-controls="frontend-tab" aria-selected="true">Frontend</a>
                                            <a class="nav-item nav-link" id="nav-reports-tab" data-toggle="tab" href="#reports-tab" role="tab" aria-controls="reports-tab" aria-selected="false">Reports</a>
                                        </div>
                                    </nav>
                                    <div class="tab-content card-body" id="nav-tab-content">
                                        <div id="backend-tab" class="tab-pane fade show active" role="tabpanel" aria-labelledby="nav-backend-tab">
                                            <div class="los-tree-view">
                                                <asp:TreeView ID="tvAccessRightsBackend" runat="server" onclick="OnTreeClick(event)" ImageSet="Custom" CollapseImageUrl="contents/images/caret-down.png" ExpandImageUrl="contents/images/caret-right.png" ShowCheckBoxes="All" ForeColor="Black" NodeIndent="30">
                                                </asp:TreeView>
                                            </div>
                                        </div>
                                        <div id="frontend-tab" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-frontend-tab">
                                            <div class="los-tree-view">
                                                <asp:TreeView ID="tvAccessRightsFrontend" runat="server" onclick="OnTreeClick(event)" ImageSet="Custom" CollapseImageUrl="contents/images/caret-down.png" ExpandImageUrl="contents/images/caret-right.png" ShowCheckBoxes="All" ForeColor="Black" NodeIndent="30">
                                                </asp:TreeView>
                                            </div>
                                        </div>
                                        <div id="reports-tab" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-reports-tab">
                                            <div class="los-tree-view">
                                                <asp:TreeView ID="tvAccessRightsReports" runat="server" onclick="OnTreeClick(event)" ImageSet="Custom" CollapseImageUrl="contents/images/caret-down.png" ExpandImageUrl="contents/images/caret-right.png" ShowCheckBoxes="All" ForeColor="Black" NodeIndent="30">
                                                </asp:TreeView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />

                            <div class="col-md-4 offset-md-4 text-center">
                                <asp:LinkButton runat="server" class="btn btn-primary" ID="lbUserGroup" OnClick="lbUserGroupCard_Click" Text="Save"
                                    OnClientClick="if(Page_ClientValidate('userGroupValidation')) { if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                                    CausesValidation="true" ValidationGroup="userGroupValidation"></asp:LinkButton>
                                <asp:LinkButton runat="server" class="btn btn-outline-primary" ID="lbBackUserGroup" OnClick="lbBack_Click" Text="Back"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="accessRightsModal" tabindex="-1" role="dialog" aria-labelledby="accessRightsModalTitle"
            aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <h5 class="modal-title" id="accessRightsModalTitle" runat="server">Access Rights</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="los-tree-view">
                                    <asp:TreeView ID="tvAccessRightsModal" runat="server" onclick="OnTreeClick(event)" ImageSet="Custom" CollapseImageUrl="contents/images/caret-down.png" ExpandImageUrl="contents/images/caret-right.png" ShowCheckBoxes="All" ForeColor="Black" NodeIndent="30">
                                    </asp:TreeView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:LinkButton class="btn btn-primary mr-2" runat="server" ID="lbUserGroupShortcut"
                                    OnClick="lbUserGroupShortcut_Click">Edit User Group</asp:LinkButton>
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">
                                    Close</button>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddUserGroup" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
