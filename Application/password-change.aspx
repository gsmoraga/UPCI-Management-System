<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement.Master" AutoEventWireup="true"
    CodeBehind="password-change.aspx.cs" Inherits="Template.password_change" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center" ondragstart="return false" draggable="false">
        <div class="col-md-10">
            <div class="card">
                <div class="card-header">
                    Change Password</div>
                <div class="card-body">
                    <div class="form-group row align-items-baseline">
                        <label for="lblPasswordGuidelines" class="col-md-4 col-form-label text-md-right">
                            Password Guidelines</label>
                        <div class="col-md-4">
                            <i class="chevron right icon"></i>
                            <asp:Label runat="server" ID="lblNewPasswordErrorMessage"></asp:Label><br />
                            <br />
                            <i class="chevron right icon"></i>
                            <asp:Label runat="server" ID="lblNewPasswordRepeatingErrorMessage"></asp:Label><br />
                            <br />
                            <i class="chevron right icon"></i>
                            <asp:Label runat="server" ID="lblNewPasswordSequentialErrorMessage"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row align-items-start">
                        <label for="txtCurrentPassword" class="col-md-4 col-form-label text-md-right">
                            Current Password</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtCurrentPassword" MaxLength="50" TextMode="Password"
                                class="form-control" autocomplete="off"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="changePasswordValidation"
                                ErrorMessage="Required field." ControlToValidate="txtCurrentPassword" ForeColor="Red"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row align-items-start">
                        <label for="txtNewPassword" class="col-md-4 col-form-label text-md-right">
                            New Password</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtNewPassword" MaxLength="50" TextMode="Password"
                                class="form-control" autocomplete="off"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="changePasswordValidation"
                                ErrorMessage="Required field." ControlToValidate="txtNewPassword" ForeColor="Red"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NewPasswordValidator" runat="server" ValidationGroup="changePasswordValidation"
                                ErrorMessage="First condition not met.<br/>" ControlToValidate="txtNewPassword"
                                ValidationExpression="" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="NewPasswordRepeatingValidator" runat="server"
                                ValidationGroup="changePasswordValidation" Enabled="false" ErrorMessage="Second condition not met.<br/>"
                                ControlToValidate="txtNewPassword" ValidationExpression="" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="NewPasswordSequentialValidator" runat="server"
                                ValidationGroup="changePasswordValidation" Enabled="false" ErrorMessage="Third condition not met.<br/>"
                                ControlToValidate="txtNewPassword" ValidationExpression="" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group row align-items-start">
                        <label for="txtConfirmPassword" class="col-md-4 col-form-label text-md-right">
                            Confirm Password</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtConfirmPassword" MaxLength="50" TextMode="Password"
                                class="form-control" autocomplete="off"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="changePasswordValidation"
                                ErrorMessage="Required field." ControlToValidate="txtConfirmPassword" ForeColor="Red"
                                Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="New password and confirmation password do not match."
                                ValidationGroup="changePasswordValidation" ControlToCompare="txtNewPassword"
                                ControlToValidate="txtConfirmPassword" ForeColor="RED" Display="Dynamic"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="col-md-6 offset-md-3 text-center">
                        <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
                        <br />
                        &nbsp;
                    </div>
                    <div class="col-md-4 offset-md-4">
                        <asp:LinkButton runat="server" class="btn btn-primary" ID="lbChangePassword" OnClick="lbChangePassword_Click"
                            OnClientClick="if(Page_ClientValidate('changePasswordValidation')) {if(this.value === 'Please wait...') { return false; } else { this.value = 'Please wait...'; }}"
                            Text="Change Password" CausesValidation="true" ValidationGroup="changePasswordValidation"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
