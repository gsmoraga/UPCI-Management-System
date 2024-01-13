<%@ Page Title="" Language="C#" MasterPageFile="~/UPCI.Master" AutoEventWireup="true" CodeBehind="procurement-purchase-requesition-form.aspx.cs" Inherits="Template.purchase_request_form" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<link rel="stylesheet" type="text/css" href="contents/css/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="contents/css/bootstrap.min.css" />
    <script type="text/javascript" src="contents/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="contents/js/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="contents/js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="contents/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript" src="contents/js/sweetalert2.all.min.js"></script>
    <script type="text/javascript" src="contents/js/main.js"></script>--%>
    <style type="text/css">
        .col-form-label {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfTransRefNumber" runat="server" />
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
                    <asp:Label ID="lblBreadcrumbHead" runat="server"></asp:Label>
                </li>
                <li class="breadcrumb-item active">
                    <asp:Label ID="lblBreadcrumbMain" runat="server"></asp:Label></li>

            </ol>
        </nav>
    </div>
    <div class="row justify-content-center">
        <div class="col-md-10 text-md-center">
            <asp:Label runat="server" ID="lblHeader" Font-Bold="true" Font-Size="X-Large" Text="PROCUREMENT REQUEST FORM (PRF)"></asp:Label>
            <br />
            &nbsp;
        </div>

    </div>
    <div class="row justify-content-center" ondragstart="return false" draggable="false">
        <div class="col-md-10">
            <br />
            &nbsp;
        </div>
        <div class="col-md-10">
            <asp:Panel ID="pnlFirstPage" runat="server" Visible="false">
                <div class="card">
                    <div class="card-header">

                        <%--<div class="form-inline">
                            <div id="hCard" runat="server">
                            </div>
                            &emsp;
                        <div id="divReturnRemarks" runat="server" visible="false" class="text-danger font-weight-bold">
                            Return Remarks:
                            <asp:Label ID="lblReturnRemarks" runat="server"></asp:Label>
                        </div>
                        </div>--%>
                    </div>
                    <div class="card-body">
                        <div class="card-title">
                            Procurement Information
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Procurement Unit</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtProcurementUnit" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtProcurementUnit" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Only alphabetic characters are allowed."
                                    ControlToValidate="txtProcurementUnit" ValidationExpression="[ña-zA-Z.\s-&@!]+$" ForeColor="Red"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">PRF Control No.</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtControlNo" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtControlNo" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-6 col-form-label text-md-left">Please procure the item/s listed below.</label>
                            <div class="col-md-12">
                                <asp:RadioButtonList ID="rblFFFE" runat="server" CssClass="form-check" onclick="MutExChkList(this);" OnSelectedIndexChanged="rblFFFE_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="ITM001">&nbsp;Initial requisition and within the Fixed Assets, Furniture, Fixtures and Equipment Policy(FFFE)</asp:ListItem>
                                    <asp:ListItem Value="ITM002">&nbsp;Replacement of Unserviceable Item. Attached is ITD Evaluation Report Dated ____________________</asp:ListItem>
                                    <asp:ListItem Value="ITM003">&nbsp;Not within FFFE</asp:ListItem>
                                    <asp:ListItem Value="ITM004">&nbsp;Additional Items:</asp:ListItem>
                                    <asp:ListItem Value="ITM005">&nbsp;Others</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="Please select a value.<br />"
                                    ControlToValidate="rblFFFE" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="procurementValidation" />
                            </div>
                        </div>
                        <!-- Report Date Accordion -->
                        <div class="accordion" id="divAccordionReportDated" runat="server" visible="false">
                            <div class="accordion-item">
                                <h2 class="accordion-header">
                                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseReportDate" aria-expanded="true" aria-controls="collapseReportDate">
                                        Report Dated
                                    </button>
                                </h2>
                                <div id="collapseReportDate" class="accordion-collapse collapse show" aria-labelledby="headingReportDate" data-bs-parent="#accordionReportDate">
                                    <div class="accordion-body">
                                        <div class="form-group row align-items-center">
                                            <label class="col-md-4 col-form-label text-md-right">Report Date</label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtReportDate" CssClass="form-control datepicker" runat="server" autocomplete="off"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Additional Items Accordion -->
                        <div class="accordion" id="divAccordionAdditionalItems" runat="server" visible="false">
                            <div class="accordion-item">
                                <h2 class="accordion-header">
                                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseAdditionalItems" aria-expanded="true" aria-controls="collapseAdditionalItems">
                                        Additional Items
                                    </button>
                                </h2>

                                <div id="collapseAdditionalItems" class="accordion-collapse collapse show" aria-labelledby="headingAdditionalItems" data-bs-parent="#accordionAdditionalItems">
                                    <div class="accordion-body">
                                        <div class="form-group row align-items-center">
                                            <label class="col-md-4 col-form-label text-md-right">Number Of Existing Units</label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtNumberOfExistingUnits" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row align-items-center">
                                            <label class="col-md-4 col-form-label text-md-right">Allowed Number of Units per FFFE</label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtAllowedNumberOfUnitsPerFFFE" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="accordion" id="divAccordionOthers" runat="server" visible="false">
                            <div class="accordion-item">
                                <h2 class="accordion-header">
                                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOthers" aria-expanded="true" aria-controls="collapseOthers">
                                        Others
                                    </button>
                                </h2>
                                <div id="collapseOthers" class="accordion-collapse collapse show" aria-labelledby="headingOthers" data-bs-parent="#accordionOthers">
                                    <div class="accordion-body">
                                        <div class="form-group row align-items-center">
                                            <label class="col-md-4 col-form-label text-md-right">Others <span>(Please Specify):</span></label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtOthers" CssClass="form-control" runat="server" autocomplete="off"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <hr class="dropdown-divider" />
                        <div class="form-group row align-items-right">
                            <label class="col-md-6 col-form-label text-md-left">Nature of Procurement</label>
                            <div class="col-md-12">
                                <asp:RadioButtonList ID="rblNatureOfProcurement" runat="server" CssClass="form-check-inline" onclick="MutExChkList(this);">
                                    <asp:ListItem Value="NOP001">&nbsp;Goods and Services</asp:ListItem>
                                    <asp:ListItem Value="NOP002">&nbsp;Civil Works</asp:ListItem>
                                    <asp:ListItem Value="NOP003">&nbsp;Consultancy</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Please select a value.<br />"
                                    ControlToValidate="rblNatureOfProcurement" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="procurementValidation" />

                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-sm-4 col-form-label text-md-right">Mode of Procurement in accordance with the approved APP</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtModeOfProcurement" CssClass="form-control" runat="server" automcomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtModeOfProcurement" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RevInvoiceNumber" runat="server"
                                    CssClass="personal-info-validation" ValidationGroup="procurementValidation"
                                    SetFocusOnError="true" ErrorMessage="Only alphanumeric characters, periods, commas, and hyphens are allowed."
                                    ControlToValidate="txtModeOfProcurement" ValidationExpression="^[ña-zA-Z\d\s-.,]+$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Purpose</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPurpose" CssClass="form-control" runat="server" automcomplete="off"></asp:TextBox>

                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtPurpose" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                    CssClass="personal-info-validation" ValidationGroup="procurementValidation"
                                    SetFocusOnError="true" ErrorMessage="Only alphanumeric characters, periods, commas, and hyphens are allowed."
                                    ControlToValidate="txtPurpose" ValidationExpression="^[ña-zA-Z\d\s-.,]+$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <hr class="dropdown-divider" />

                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Item Description and/or Technical Specifications/Scope of Works/Terms of Reference</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtItemDescription" CssClass="form-control" runat="server" automcomplete="off"></asp:TextBox>

                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtItemDescription" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                    CssClass="personal-info-validation" ValidationGroup="procurementValidation"
                                    SetFocusOnError="true" ErrorMessage="Only alphanumeric characters, periods, commas, and hyphens are allowed."
                                    ControlToValidate="txtItemDescription" ValidationExpression="^[ña-zA-Z\d\s-.,]+$"
                                    ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Quantity</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtQuantity" CssClass="form-control" onkeypress="return isNumberKey(event)" OnTextChanged="txtQuantity_TextChanged" runat="server" AutoPostBack="true" Onpaste="return false" automcomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtQuantity" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <hr class="dropdown-divider" />
                        <div class="card-title">
                            Estimated Cost
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-sm-4 col-form-label text-md-right">Unit Cost</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtUnitCost" CssClass="form-control" onkeypress="return isNumberKey(event)" OnTextChanged="txtUnitCost_TextChanged" runat="server" AutoPostBack="true" Onpaste="return false" onblur="decimal(this)" automcomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="rfvUnitCost" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtUnitCost" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row align-items-center">
                            <label class="col-sm-4 col-form-label text-md-right">Total</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTotal" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>

                        <hr class="dropdown-divider" />
                        <div class="card-title">
                            Stock Position Sheet(if applicable)
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Balance on Hand</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtBalanceOnHand" CssClass="form-control" runat="server" automcomplete="off" Onpaste="return false" onblur="decimal(this)" OnTextChanged="txtBalanceOnHand_TextChanged" AutoPostBack="true" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="rfvBalanceOnHand" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtBalanceOnHand" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Monthly Average Usage</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtMoAveUsage" CssClass="form-control" runat="server" automcomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtBalanceOnHand" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">This Requisition</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtThisRequisition" CssClass="form-control" runat="server" automcomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtThisRequisition" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Estimated Month/s to Use</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtEstimateMonthsToUse" CssClass="form-control" runat="server" automcomplete="off"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="procurementValidation"
                                    CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                    ControlToValidate="txtEstimateMonthsToUse" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                    </div>
                </div>
                <!-- card-->
                <div class="text-center">
                    <asp:LinkButton ID="lbNext" ValidationGroup="procurementValidation" CssClass="btn btn-primary" runat="server" OnClick="lbNext_Click" Width="150px" Visible="false">Next&nbsp;&nbsp;<i class="bi bi-arrow-right"></i></asp:LinkButton>
                </div>

            </asp:Panel>
            <asp:Panel ID="pnlConfirmationPage" runat="server" Visible="false">
                <div class="card">
                    <div class="card-header">
                        <%--<div class="form-inline">
                            <div id="hCard" runat="server">
                            </div>
                            &emsp;
                        <div id="divReturnRemarks" runat="server" visible="false" class="text-danger font-weight-bold">
                            Return Remarks:
                            <asp:Label ID="lblReturnRemarks" runat="server"></asp:Label>
                        </div>
                        </div>--%>
                    </div>
                    <div class="card-body">
                        <div class="card-title">
                            Procurement Information
                        </div>
                        <hr class="dropdown-divider">
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Procurement Unit</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblProcurementUnit" runat="server" CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">PRF Control No.</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblControlNo" runat="server" CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-6 col-form-label">Please procure the item/s listed below.</label>
                            <div class="col-md-12">
                                <asp:RadioButtonList ID="rblProcureItems" runat="server" CssClass="form-check" onclick="MutExChkList(this);" OnSelectedIndexChanged="rblProcureItems_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
                                    <asp:ListItem Value="ITM001">&nbsp;Initial requisition and within the Fixed Assets, Furniture, Fixtures and Equipment Policy(FFFE)</asp:ListItem>
                                    <asp:ListItem Value="ITM002">&nbsp;Replacement of Unserviceable Item. Attached is ITD Evaluation Report Dated ____________________</asp:ListItem>
                                    <asp:ListItem Value="ITM003">&nbsp;Not within FFFE</asp:ListItem>
                                    <asp:ListItem Value="ITM004">&nbsp;Additional Items:</asp:ListItem>
                                    <asp:ListItem Value="ITM005">&nbsp;Others</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <!-- Report Date Accordion -->
                        <div class="accordion" id="divAccordionReportDated2" runat="server" visible="false">
                            <div class="accordion-item">
                                <h2 class="accordion-header">
                                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseReportDate2" aria-expanded="true" aria-controls="collapseReportDate2">
                                        Report Dated
                                    </button>
                                </h2>
                                <div id="collapseReportDate2" class="accordion-collapse collapse show" aria-labelledby="headingReportDate2" data-bs-parent="#accordionReportDate2">
                                    <div class="accordion-body">
                                        <div class="form-group row align-items-center">
                                            <label class="col-md-4 col-form-label text-md-right">Report Date</label>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblReportDate" runat="server" CssClass="form-label"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Additional Items Accordion -->
                        <div class="accordion" id="divAccordionAdditionalItems2" runat="server" visible="false">
                            <div class="accordion-item">
                                <h2 class="accordion-header">
                                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseAdditionalItems2" aria-expanded="true" aria-controls="collapseAdditionalItems2">
                                        Additional Items
                                    </button>
                                </h2>

                                <div id="collapseAdditionalItems2" class="accordion-collapse collapse show" aria-labelledby="headingAdditionalItems2" data-bs-parent="#accordionAdditionalItems2">
                                    <div class="accordion-body">
                                        <div class="form-group row align-items-center">
                                            <label class="col-md-4 col-form-label text-md-right">Number Of Existing Units</label>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblNumberOfExistingUnits" runat="server" CssClass="form-label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group row align-items-center">
                                            <label class="col-md-4 col-form-label text-md-right">Allowed Number of Units per FFFE</label>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblAllowedUnitsPerFFFE" runat="server" CssClass="form-label"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="accordion" id="divAccordionOthers2" runat="server" visible="false">
                            <div class="accordion-item">
                                <h2 class="accordion-header">
                                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOthers2" aria-expanded="true" aria-controls="collapseOthers2">
                                        Others
                                    </button>
                                </h2>
                                <div id="collapseOthers2" class="accordion-collapse collapse show" aria-labelledby="headingOthers2" data-bs-parent="#accordionOthers2">
                                    <div class="accordion-body">
                                        <div class="form-group row align-items-center">
                                            <label class="col-md-4 col-form-label text-md-right">Others <span>(Please Specify):</span></label>
                                            <div class="col-md-4">
                                                <asp:Label ID="lblOthers" runat="server" CssClass="form-label"></asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <hr class="dropdown-divider">
                        <div class="form-group row align-items-right">
                            <label class="col-md-6 col-form-label text-md-right">Nature of Procurement</label>
                            <div class="col-md-12">
                                <asp:RadioButtonList ID="rblProcurementNature" runat="server" CssClass="form-check-inline" onclick="MutExChkList(this);" Enabled="false">
                                    <asp:ListItem Value="NOP001">&nbsp;Goods and Services</asp:ListItem>
                                    <asp:ListItem Value="NOP002">&nbsp;Civil Works</asp:ListItem>
                                    <asp:ListItem Value="NOP003">&nbsp;Consultancy</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Mode of Procurement in accordance with the approved APP</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblModeOfProcurement" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Purpose</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblPurpose" runat="server" CssClass="form-label"></asp:Label>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <hr class="dropdown-divider">
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Item Description and/or Technical Specifications/Scope of Works/Terms of Reference</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblItemDescription" CssClass="form-label" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Quantity</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblQuantity" CssClass="form-label" runat="server"></asp:Label>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>
                        <div class="card-title">
                            Estimated Cost
                        </div>

                        <div class="form-group row align-items-center">
                            <label class="col-sm-4 col-form-label">Unit Cost</label>
                            <div class="col-sm-4">
                                <asp:Label ID="lblUnitCost" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Total</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblTotal" CssClass="form-label" runat="server"></asp:Label>
                            </div>
                        </div>
                        <hr class="dropdown-divider">
                        <div class="card-title">
                            Stock Position Sheet(if applicable)
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Balance on Hand</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblBalanceOnHand" CssClass="form-label" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Monthly Average Usage</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblMonthlyAverageUsage" CssClass="form-label" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">This Requisition</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblThisRequisition" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row align-items-center">
                            <label class="col-md-4 col-form-label text-md-right">Estimated Month/s to Use</label>
                            <div class="col-md-4">
                                <asp:Label ID="lblEstimatedMonthsToUse" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div id="divBudgetFunds" runat="server" visible="false">
                            <hr class="dropdown-divider">
                            <div class="card-title">
                                Budget/Funds Availability
                            </div>
                            <asp:Panel ID="pnlBudget" runat="server">
                                <div class="form-group row align-items-center">
                                    <label class="col-md-4 col-form-label text-md-right">Budget Year</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtBudgetYear" CssClass="form-control" runat="server" automcomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="budgetValidation"
                                            CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                            ControlToValidate="txtBudgetYear" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row align-items-center">
                                    <label class="col-md-4 col-form-label text-md-right">Account</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtAccount" CssClass="form-control" runat="server" automcomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="budgetValidation"
                                            CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                            ControlToValidate="txtAccount" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row align-items-center">
                                    <label class="col-md-4 col-form-label text-md-right">Amount</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" Onpaste="return false" onblur="decimal(this)" OnTextChanged="txtAmount_TextChanged" AutoPostBack="true" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ValidationGroup="budgetValidation"
                                            CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                            ControlToValidate="txtAmount" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row align-items-center">
                                    <label class="col-md-4 col-form-label text-md-right">Chargeable Unit/Department</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtDepartment" CssClass="form-control" runat="server" automcomplete="off"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="budgetValidation"
                                            CssClass="personal-info-validation" SetFocusOnError="true" ErrorMessage="Required field."
                                            ControlToValidate="txtDepartment" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>




                            </asp:Panel>
                            <asp:Panel ID="pnlBudgetConfirmationPage" runat="server" Visible="false">
                                <div class="form-group row align-items-center">
                                    <label class="col-md-4 col-form-label text-md-right">Budget Year</label>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblBudgetYear" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group row align-items-center">
                                    <label class="col-md-4 col-form-label text-md-right">Account</label>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblAccount" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group row align-items-center">
                                    <label class="col-md-4 col-form-label text-md-right">Amount</label>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group row align-items-center">
                                    <label class="col-md-4 col-form-label text-md-right">Chargeable Unit/Department</label>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblChargeableUnit" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>

                    </div>
                </div>
                <div id="divRemarks" runat="server" visible="false">
                    <hr />
                    <div class="form-group row align-items-start">
                        <label for="txtRemarks" class="col-md-4 col-form-label text-md-right">
                            Action Remarks</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" MaxLength="300"
                                autocomplete="off" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ValidationGroup="returnDeclineValidation"
                                SetFocusOnError="true" ErrorMessage="Remarks are required before your action can push through."
                                ControlToValidate="txtRemarks" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRemarks" runat="server"
                                ValidationGroup="returnDeclineValidation" SetFocusOnError="true" ErrorMessage="Must consist of up to 300 alphanumeric characters, commas, and periods only."
                                ControlToValidate="txtRemarks" ValidationExpression="^[a-zA-Z0-9\s.,]{0,300}$" ForeColor="Red"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <br />
                    &nbsp;
                </div>
                <div class="text-center">
                    <asp:LinkButton runat="server" class="btn btn-secondary" Width="150px" ID="lbBack"
                        OnClick="lbBack_Click" Visible="false"><i class="ri-arrow-left-fill"></i>&nbsp;&nbsp;Back</asp:LinkButton>
                    <asp:LinkButton runat="server" class="btn btn-primary" Width="150px" ID="lbSubmit"
                        Visible="false" OnClientClick="return confirmApplication(this,'submit');"
                        CausesValidation="true" OnClick="lbSubmit_Click"><i class="ri-send-plane-fill"></i>&nbsp;&nbsp;Submit</asp:LinkButton>

                    <asp:LinkButton runat="server" class="btn btn-secondary" Width="150px" ID="lbBackBudget"
                        OnClick="lbBackBudget_Click" Visible="false"><i class="ri-arrow-left-fill"></i>&nbsp;&nbsp;Back</asp:LinkButton>
                    <%--<asp:LinkButton ID="lbNextBudget" CssClass="btn btn-primary" runat="server" OnClick="lbNextBudget_Click" Width="150px" Visible="false">Next&nbsp;&nbsp;<i class="bi bi-arrow-right"></i></asp:LinkButton>--%>
                    <asp:LinkButton runat="server" class="btn btn-primary m-2" Width="150px" ID="lbReturn"
                        Visible="false" OnClick="lbReturn_Click" OnClientClick="return confirmApplication(this, 'return');"
                        CausesValidation="true" ValidationGroup="returnDeclineValidation"><i class="ri-arrow-go-back-fill"></i>&nbsp;&nbsp;Return</asp:LinkButton>
                    <asp:LinkButton runat="server" class="btn btn-primary m-2" Width="150px" ID="lbRecommend"
                        Visible="false" OnClick="lbRecommend_Click" OnClientClick="return confirmApplication(this, 'recommend');" ValidationGroup="budgetValidation">Recommend&nbsp;&nbsp;<i class="ri-arrow-go-forward-fill"></i></asp:LinkButton>
                </div>
            </asp:Panel>





        </div>
    </div>

    <script type="text/javascript">
        function MutExChkList(chk) {
            var chkList = chk.parentNode.parentNode.parentNode;
            var chks = chkList.getElementsByTagName("input");
            for (var i = 0; i < chks.length; i++) {
                if (chks[i] != chk && chk.checked) {
                    chks[i].checked = false;
                }
            }
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46 && charCode != 44)
                return false;
            //                {   alert("test");
            //                    if (charCode.value.split('.').length === 2) {
            //                        alert("test2");

            //                        }
            //                }
            return true;
        }

        function format(input) {
            if (input.value == 0)
                input.value = '';
            else {
                var nStr = input.value + '';
                nStr = nStr.replace(/([^0-9.])/g, "");
                x = nStr.split('.');
                x1 = x[0];
                x2 = x.length > 1 ? '.' + x[1] : '';
                var rgx = /(\d+)(\d{3})/;

                while (rgx.test(x1))
                    x1 = x1.replace(rgx, '$1' + ',' + '$2');

                while (x2.length > 3)
                    x2 = x2.substring(0, 3);

                input.value = x1 + x2;
            }
        }

        function decimal(input) {
            var nStr = input.value + '';
            if (nStr.length > 0) {
                x = nStr.split('.');
                x1 = x[0];
                x2 = x.length > 1 ? x[1] : '';

                if (x2.length == 1)
                    x2 = '.' + x2 + '0';
                else if (x2.length == 2)
                    x2 = '.' + x2;
                else
                    x2 = '.00';

                input.value = x1 + x2;
            }
        }
    </script>

</asp:Content>
