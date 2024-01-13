<%@ Page Title="" Language="C#" MasterPageFile="~/UPCI.Master" AutoEventWireup="true" CodeBehind="add-member-form.aspx.cs" Inherits="Template.add_member_form" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="contents/css/progress-map.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfMembershipNumber" runat="server" />
    <div class="pagetitle">
        <%--<h1>Dashboard</h1>--%>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a href="Homepage.aspx">
                        <i class="bi bi-house-door"></i>
                    </a>
                </li>
                <li class="breadcrumb-item">
                    <asp:Label ID="lblBreadcrumbHead" runat="server" Text="Members Information"></asp:Label>
                </li>
                <li class="breadcrumb-item active">
                    <asp:Label ID="lblBreadcrumbMain" runat="server" Text="Add Members"></asp:Label></li>

            </ol>
        </nav>
    </div>
    <div class="row justify-content-center">
        <div class="row justify-content-center" ondragstart="return false" draggable="false">
            <div class="col-md-10">

                <div class="pt-4 pb-2">
                    <h5 class="card-title text-center pb-0 fs-4">Member Information</h5>
                </div>
                <div class="container">
                    <div class="steps">
                        <span id="stepOne" runat="server" class="circle active">
                            <asp:Label ID="lblOne" runat="server">1</asp:Label><i class="bi bi-check text-primary" id="iconOne" runat="server" visible="false"></i></span>
                        <span id="stepTwo" runat="server" class="circle">
                            <asp:Label ID="lblTwo" runat="server">2</asp:Label><i class="bi bi-check text-primary" id="iconTwo" runat="server" visible="false"></i></span>
                        <span id="stepThree" runat="server" class="circle">
                            <asp:Label ID="lblThree" runat="server">3</asp:Label><i class="bi bi-check text-primary" id="iconThree" runat="server" visible="false"></i></span>
                        <span id="stepFour" runat="server" class="circle">
                            <asp:Label ID="lblFour" runat="server">4</asp:Label><i class="bi bi-check text-primary" id="iconFour" runat="server" visible="false"></i></span>
                        <span id="stepConfirmation" runat="server" class="circle"><i class="bi bi-file-text"></i></span>
                        <%--<span id="stepSuccess" runat="server" class="circle"><i class="bi bi-check"></i></span>--%>
                        <div class="progress-bar">
                            <span id="spanIndicator" runat="server" class="indicator"></span>
                        </div>
                    </div>
                </div>
                <br />

                <asp:Panel ID="pnlFirstPage" runat="server" Visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="pt-4 pb-2">
                                <p class="card-title text-center small">Enter Member Name and ID</p>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Membership ID</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtMembershipId" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="membershipValidation"
                                        CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                        ControlToValidate="txtMembershipId" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="membershipValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Only alphabetic characters are allowed."
                                    ControlToValidate="txtMembershipId" ValidationExpression="[ña-zA-Z.\s-&@!]+$" ForeColor="Red"
                                    Display="Dynamic"></asp:RegularExpressionValidator>--%>
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">First Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" autocomplete="off" AutoPostBack="true"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="membershipValidation"
                                        CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                        ControlToValidate="txtFirstName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Middle Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="membershipValidation"
                                        CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                        ControlToValidate="txtMiddleName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Last Name</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="membershipValidation"
                                        CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                        ControlToValidate="txtLastName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-8 text-right">
                                <asp:LinkButton ID="lbNextFirstPage" CssClass="btn btn-primary" runat="server" OnClick="lbNextFirstPage_Click">Next</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                </asp:Panel>

                <asp:Panel ID="pnlSecondPage" runat="server" Visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="pt-4 pb-2">
                                <p class="card-title text-center small">Enter Member Birthdate and Gender</p>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Gender</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddGender" runat="server" class="custom-select">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" InitialValue="0" ErrorMessage="Please select a value.<br />"
                                        ControlToValidate="ddGender" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="membershipValidation" />
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Birthdate</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtBirthDate" CssClass="form-control datepicker" runat="server" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="ReqBirthdate" ErrorMessage="Please select a value.<br />"
                                        ControlToValidate="txtBirthDate" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="membershipValidation" />
                                    <asp:RegularExpressionValidator ID="RevBirthdate" runat="server" ValidationGroup="membershipValidation"
                                        ErrorMessage="Must be of the format MM/DD/YYYY." ControlToValidate="txtBirthDate" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-8 text-right">
                                <asp:LinkButton ID="lbBackSecondPage" CssClass="btn btn-outline-primary" runat="server" OnClick="lbBackSecondPage_Click">Back</asp:LinkButton>
                                <asp:LinkButton ID="lbNextSecondPage" CssClass="btn btn-primary" runat="server" OnClick="lbNextSecondPage_Click">Next</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlThirdPage" runat="server" Visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="pt-4 pb-2">
                                <p class="card-title text-center small">Enter Member Additional Information</p>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Email</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" autocomplete="off" placeholder="Optional"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator44" runat="server" ValidationGroup="membershipValidation" SetFocusOnError="true"
                                        ErrorMessage="Invalid email." ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Mobile Number</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" autocomplete="off" MaxLength="11" placeholder="Optional"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="membershipValidation" runat="server" ValidationGroup="membershipValidation"
                                        ErrorMessage="Invalid mobile number." ControlToValidate="txtMobileNumber" ValidationExpression="(\+?\d{2}?\s?\d{3}\s?\d{3}\s?\d{4})|([0]\d{3}\s?\d{3}\s?\d{4})" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-8 text-right">
                                <asp:LinkButton ID="lbBackThirdPage" CssClass="btn btn-outline-primary" runat="server" OnClick="lbBackThirdPage_Click">Back</asp:LinkButton>
                                <asp:LinkButton ID="lbNextThirdPage" CssClass="btn btn-primary" runat="server" OnClick="lbNextThirdPage_Click">Next</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                </asp:Panel>

                <asp:Panel ID="pnlFourthPage" runat="server" Visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="pt-4 pb-2">
                                <p class="card-title text-center small">Enter Member Church Information</p>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Ministry</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddMinistry" runat="server" CssClass="form-select"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" InitialValue="0" ErrorMessage="Please select a value.<br />"
                                        ControlToValidate="ddMinistry" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="membershipValidation" />
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Date First Attend</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDateFirstAttend" CssClass="form-control datepicker" runat="server" autocomplete="off" placeholder="Optional"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:RegularExpressionValidator ID="RevDateFirstAttend" runat="server" ValidationGroup="membershipValidation"
                                        ErrorMessage="Must be of the format MM/DD/YYYY." ControlToValidate="txtDateFirstAttend" ValidationExpression="^\d{2}\/\d{2}\/\d{4}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-8 text-right">
                                <asp:LinkButton ID="lbBackFourthPage" CssClass="btn btn-outline-primary" runat="server" OnClick="lbBackFourthPage_Click">Back</asp:LinkButton>
                                <asp:LinkButton ID="lbNextFourthPage" CssClass="btn btn-primary" runat="server" OnClick="lbNextFourthPage_Click">Next</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                </asp:Panel>

                <asp:Panel ID="pnlConfirmationPage" runat="server" Visible="false">
                    <div class="card">
                        <div class="card-body">
                            <div class="pt-4 pb-2">
                                <p class="text-center small">Review Membership Information</p>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Membership ID</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblMembershipId" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">First Name</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Middle Name</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblMiddleName" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Last Name</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Gender</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Birthdate</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblBirthdate" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Email</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Mobile Number</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Ministry</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblMinistry" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="form-group row align-items-center">
                                <label class="col-md-4 col-form-label text-md-right">Date First Attend</label>
                                <div class="col-md-4">
                                    <asp:Label ID="lblDateFirstAttend" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-8 text-right">
                                <asp:LinkButton ID="lbBackConfirmationPage" CssClass="btn btn-outline-primary" runat="server" OnClick="lbBackConfirmationPage_Click">Back</asp:LinkButton>
                                <asp:LinkButton ID="lbSave" CssClass="btn btn-primary" runat="server" OnClick="lbSave_Click">Save</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
