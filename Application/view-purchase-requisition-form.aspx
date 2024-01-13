<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement.Master" AutoEventWireup="true" CodeBehind="view-purchase-requisition-form.aspx.cs" Inherits="Template.view_purchase_requisition_form" %>

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
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-7">
                        </div>
                        <div class="col-md-5">
                            <button type="button" class="btn btn-success float-right m-1" data-toggle="modal" data-target="#progressMapModal" style="width: 140px">
                                <i class="bi bi-map-fill"></i>Progress Map</button>
                            <asp:LinkButton runat="server" ID="lbPRFForm" Visible="false" CssClass="btn btn-primary float-right m-1" Style="width: auto" OnClick="lbPRFForm_Click">
                                    <i class="bi bi-file-earmark-text-fill"></i>&nbsp;&nbsp;PRF Form
                            </asp:LinkButton>
                        </div>
                    </div>
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
                        <div class="col-sm-4">
                        </div>
                    </div>
                    <div class="form-group row align-items-center">
                        <label class="col-md-6 col-form-label text-md-left">Please procure the item/s listed below.</label>
                        <div class="col-md-12">
                            <asp:RadioButtonList ID="rblProcureItems" runat="server" CssClass="form-check" onclick="MutExChkList(this);" OnSelectedIndexChanged="rblProcureItems_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
                                <asp:ListItem Value="ITM001">&nbsp;Initial requisition and within the Fixed Assets, Furniture, Fixtures and Equipment Policy(FFFE)</asp:ListItem>
                                <asp:ListItem Value="ITM002">&nbsp;Replacement of Unserviceable Item. Attached is ITD Evaluation Report Dated ____________________</asp:ListItem>
                                <asp:ListItem Value="ITM003">&nbsp;Not within FFFE</asp:ListItem>
                                <asp:ListItem Value="ITM004">&nbsp;Additional Items:</asp:ListItem>
                                <asp:ListItem Value="ITM005">&nbsp;Others</asp:ListItem>
                            </asp:RadioButtonList>
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
                        <label class="col-md-4 col-form-label text-md-left">Nature of Procurement</label>
                        <div class="col-md-12">
                            <asp:RadioButtonList ID="rblProcurementNature" runat="server" CssClass="form-check-inline" onclick="MutExChkList(this);" Enabled="false">
                                <asp:ListItem Value="NOP001">&nbsp;Goods and Services</asp:ListItem>
                                <asp:ListItem Value="NOP002">&nbsp;Civil Works</asp:ListItem>
                                <asp:ListItem Value="NOP003">&nbsp;Consultancy</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-sm-4">
                        </div>
                    </div>
                    <div class="form-group row align-items-center">
                        <label class="col-md-4 col-form-label text-md-right">Mode of Procurement in accordance with the approved APP</label>
                        <div class="col-md-4">
                            <asp:Label ID="lblModeOfProcurement" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group row align-items-center">
                        <label class="col-md-4 col-form-label text-md-right">Purpose</label>
                        <div class="col-md-4">
                            <asp:Label ID="lblPurpose" runat="server" CssClass="form-label"></asp:Label>
                        </div>

                    </div>
                    <hr class="dropdown-divider">
                    <div class="form-group row align-items-center">
                        <label class="col-md-4 col-form-label text-md-right">Item Description and/or Technical Specifications/Scope of Works/Terms of Reference</label>
                        <div class="col-md-4">
                            <asp:Label ID="lblItemDescription" CssClass="form-label" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                        </div>
                    </div>
                    <div class="form-group row align-items-center">
                        <label class="col-md-4 col-form-label text-md-right">Quantity</label>
                        <div class="col-md-4">
                            <asp:Label ID="lblQuantity" CssClass="form-label" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                        </div>
                    </div>
                    <div class="card-title">
                        Estimated Cost
                    </div>

                    <div class="form-group row align-items-center">
                        <label class="col-md-4 col-form-label text-md-right">Unit Cost</label>
                        <div class="col-md-4">
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

                    <div id="divBudgetFunds" runat="server">
                        <hr class="dropdown-divider">
                        <div class="card-title">
                            Budget/Funds Availability
                        </div>
                        <asp:Panel ID="pnlBudgetConfirmationPage" runat="server">
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
                <asp:LinkButton runat="server" class="btn btn-danger m-2" Width="150px" ID="lbDecline"
                     CausesValidation="true" ValidationGroup="returnDeclineValidation" Visible="false" OnClick="lbDecline_Click"><i class="ri-forbid-fill"></i>&nbsp;&nbsp;Decline</asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-primary m-2" Width="150px" ID="lbReturn"
                    data-toggle="modal" data-target="#returnModal" Visible="false"
                    CausesValidation="true" ValidationGroup="returnDeclineValidation"><i class="ri-arrow-go-back-fill"></i>&nbsp;&nbsp;Return</asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-primary m-2" Width="150px" ID="lbApprove" OnClick="lbApprove_Click"
                    Visible="false" OnClientClick="return confirmApplication(this, 'approve');"><i class="ri-check-fill"></i>&nbsp;&nbsp;Approve</asp:LinkButton>
            </div>
        </div>
    </div>


    <div class="modal fade" id="declineModal" tabindex="-1" role="dialog" aria-labelledby="declineModalTitle"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="declineModalTitle">Decline Request</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row align-items-start">
                        <label for="ddDeclineReason" class="col-md-10 offset-md-1 col-form-label">
                            Reason</label>
                        <div class="col-md-10 offset-md-1">
                            <asp:DropDownList runat="server" ID="ddDeclineReason" CssClass="custom-select">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-10 offset-md-1">
                            <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator6" runat="server"
                                ValidationGroup="declineValidation" ErrorMessage="Please select a value." ControlToValidate="ddDeclineReason"
                                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" class="btn btn-danger m-2" ID="lbDeclineModal"
                        OnClientClick="return confirmApplication(this, 'decline');"
                        CausesValidation="true" ValidationGroup="declineValidation" OnClick="lbDeclineModal_Click"><i class="ban icon"></i>Decline</asp:LinkButton>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">
                        Cancel</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="returnModal" tabindex="-1" role="dialog" aria-labelledby="returnModalTitle"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="returnModalTitle">Return Request</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row align-items-start">
                        <label for="ddDeclineReason" class="col-md-10 offset-md-1 col-form-label">
                            Return to</label>
                        <div class="col-md-10 offset-md-1">
                            <asp:DropDownList runat="server" ID="ddReturnUser" CssClass="custom-select">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-10 offset-md-1">
                            <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" runat="server"
                                ValidationGroup="returnValidation" ErrorMessage="Please select a value." ControlToValidate="ddReturnUser"
                                ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" class="btn btn-danger m-2" ID="lbReturnModal"
                        OnClientClick="return confirmApplication(this, 'decline');"
                        CausesValidation="true" ValidationGroup="returnValidation" OnClick="lbReturnModal_Click"><i class="ban icon"></i>Return</asp:LinkButton>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">
                        Cancel</button>
                </div>
            </div>
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
    </script>

</asp:Content>
