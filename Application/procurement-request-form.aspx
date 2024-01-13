<%@ Page Title="" Language="C#" MasterPageFile="~/Procurement.Master" AutoEventWireup="true" CodeBehind="procurement-request-form.aspx.cs" Inherits="Template.procurement_request_from" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .table {
            border: 1px solid black;
        }

            .table td, .table-bordered tr {
                border: 1px solid black;
            }
    </style>
    <script src="contents/js/printThis.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfTransRefNumber" runat="server" />
    <div align="center" ondragstart="return false" draggable="false">
        <div class="row justify-content-center m-1">

            <div class="col-md-10" runat="server">
                <asp:LinkButton runat="server" class="btn btn-success m-2 float-left" ID="lbBackTop"
                    OnClick="lbBackTop_Click" Visible="false"><i class="arrow left icon"></i>Back</asp:LinkButton>
                <asp:LinkButton runat="server" class="btn btn-success m-2" ID="lbPrintTop" OnClick="lbPrintTop_Click"
                    Visible="false"><i class="print icon"></i>Print</asp:LinkButton>
                <div class="card" runat="server">


                    <div id="divPrintInd" style="font-size: 12px" class="table-responsive print-sm">
                        <div class="col-md-10 text-md-center" runat="server" id="divHeader">

                            <h6>UCPB SAVINGS BANK INC.</h6>
                            <h1>PROCUREMENT REQUEST FORM (PRF)</h1>
                            <%--<asp:HiddenField ID="hfLoanApplicationCode" runat="server" />--%>
                            <br />
                            &nbsp;
                        </div>
                        <br />
                        &nbsp;
                        <table class="table table-sm" style="border: 1px solid black">
                            <tr>
                                <td class="align-middle" style="font-size: 14px" colspan="6" width="80%">
                                    <span class="font-weight-bolder">FOR:&nbsp;&nbsp;
                                    </span>
                                    <asp:Label runat="server" CssClass="control-label" ID="lblProcurementUnit"></asp:Label>
                                    
                                </td>
                                <td colspan="6">
                                    <span class="font-weight-bolder">PRF Control No:&nbsp;&nbsp;</span>
                                    <asp:Label runat="server" CssClass="control-label" ID="lblControlNo"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="table table-sm">
                            <tr class="font-weight-bold">
                                <td colspan="12">Please procure the item/s listed below. Item/s requisitioned is necessary and will be used for the purpose stated.
                                </td>
                            </tr>
                            <tr class="font-weight-normal" style="font-size: 14px">
                                <td colspan="12">
                                    <asp:CheckBox ID="CHK001" runat="server" Enabled="false" />
                                    <span>Initial requisition and within the Fixed Assets, Furniture, Fixtures and Equipment Policy (FFFE) </span>&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr class="font-weight-normal" style="font-size: 14px">
                                <td colspan="12">
                                    <asp:CheckBox ID="CHK002" runat="server" Enabled="false" />
                                    <span>Replacement of Unserviceable Item. Attached is ITD Evaluation Report dated
                                        <asp:Label ID="lblReportDate" runat="server" CssClass="form-label" Visible="false"></asp:Label></span>&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr class="font-weight-normal" style="font-size: 14px">
                                <td colspan="12">
                                    <asp:CheckBox ID="CHK003" runat="server" Enabled="false" />
                                    <span>Not within FFFE</span>&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr class="font-weight-normal" style="font-size: 14px">
                                <td colspan="12">
                                    <asp:CheckBox ID="CHK004" runat="server" Enabled="false" />
                                    <span>Additional Items:</span>&nbsp;&nbsp;&nbsp;
                                    Number of Existing Units&nbsp;&nbsp;<asp:Label ID="lblNumberOfExistingUnits" runat="server" CssClass="form-label" Visible="false"></asp:Label>&nbsp;&nbsp;
                                    Allowed number of units per FFFE &nbsp;&nbsp;<asp:Label ID="lblAllowedUnitsPerFFFE" runat="server" CssClass="form-label" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr class="font-weight-normal" style="font-size: 14px">
                                <td colspan="12">
                                    <asp:CheckBox ID="CHK005" runat="server" Enabled="false" />
                                    <span>Others (Please specify): Building Renovation and Repair works at UCPB Savings Head Office for COA Office</span>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblOthers" runat="server" CssClass="form-label" Visible="true"></asp:Label>
                                </td>
                            </tr>
                            <tr colspan="12">
                                <td colspan="12">Nature of Procurement:
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:CheckBox ID="CHKGoodAndServices" runat="server" Enabled="false" />
                                    <span>Goods and Services</span>
                                </td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CHKCivilWorks" runat="server" Enabled="false" />
                                    <span>Civil Works</span>
                                </td>
                                <td colspan="4">
                                    <asp:CheckBox ID="CHKConsultancy" runat="server" Enabled="false" />
                                    <span>Consultancy</span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="12">Mode of Procurement in accordance with the approved APP: 
                                    <asp:Label ID="lblModeOfProcurement" runat="server" CssClass="control-label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="12" style="font-weight: bold">PURPOSE:
                                    <asp:Label ID="lblPurpose" runat="server" CssClass="control-label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="text-align: center; font-weight: bold">
                                <td colspan="5" rowspan="2">Item Description and/or Technical Specifications/Scope of Works/Terms of Reference
                                    
                                </td>
                                <td colspan="1" rowspan="2">Qty
                                    
                                </td>
                                <td colspan="2">Estimated Cost
                                    
                                </td>
                                <td colspan="4">Stock Position Sheet (if applicable)
                                </td>
                            </tr>
                            <tr style="text-align: center; font-weight: bold">
                                <td colspan="1">Unit Cost</td>
                                <td colspan="1">Total</td>
                                <td colspan="1">Balance on Hand</td>
                                <td colspan="1">Mo. Ave. Usage</td>
                                <td colspan="1">This Requisition</td>
                                <td colspan="1">Est. Mo./s to use</td>
                            </tr>
                            <tr style="text-align: center">
                                <td colspan="5" style="height: 70px;">
                                    <asp:Label ID="lblItemDescription" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="1" style="height: 70px;">
                                    <asp:Label ID="lblQuantity" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="1" style="height: 70px;">
                                    <asp:Label ID="lblUnitCost" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="1" style="height: 70px;">
                                    <asp:Label ID="lblTotal" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="1" style="height: 70px;">
                                    <asp:Label ID="lblBalanceOnHand" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="1" style="height: 70px;">
                                    <asp:Label ID="lblMonthlyAverageUsage" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="1" style="height: 70px;">
                                    <asp:Label ID="lblThisRequisition" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="1" style="height: 70px;">
                                    <asp:Label ID="lblEstimatedMonthsToUse" runat="server" CssClass="control-label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="12"></td>
                            </tr>
                            <tr>
                                <td colspan="4">Prepared By: (End User/Project Owner)
                                    <br />
                                    <asp:Label ID="lblPreparedBy" runat="server" CssClass="control-label"></asp:Label>
                                    <br />
                                    ________________________________________
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Signatured over Printed Name)
                                </td>
                                <td colspan="4">Endorsed By:
                                    <br />
                                    <asp:Label ID="lblEndorsedBy" runat="server" CssClass="control-label"></asp:Label>
                                    <br />
                                    ____________________________________________
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Signature Over Printed Name)
                                </td>
                                <td colspan="4">Approved By:
                                    <br />
                                    <asp:Label ID="lblApprovedBy" runat="server" CssClass="control-label"></asp:Label>
                                    <br />
                                    ____________________________________________
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Signature Over Printed Name)
                                </td>
                            </tr>
                            <tr style="font-weight: bold">
                                <td colspan="12" style="text-align: center">BUDGET/FUNDS AVAILABILITY:
                                </td>
                            </tr>
                            <tr style="text-align: center; font-weight: bold">
                                <td colspan="2">Budget Year</td>
                                <td colspan="2">Account</td>
                                <td colspan="2">Amount</td>
                                <td colspan="2">Chargeable Unit/Department</td>
                                <td colspan="2">Certified By</td>
                                <td colspan="2">Certified Date</td>
                            </tr>
                            <tr style="text-align: center">
                                <td colspan="2">
                                    <asp:Label ID="lblBudgetYear" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="2">
                                    <asp:Label ID="lblAccount" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="2">
                                    <asp:Label ID="lblAmount" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="2">
                                    <asp:Label ID="lblChargeableUnit" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="2">
                                    <asp:Label ID="lblCertifiedBy" runat="server" CssClass="control-label"></asp:Label></td>
                                <td colspan="2">
                                    <asp:Label ID="lblCertifiedDate" runat="server" CssClass="control-label"></asp:Label></td>
                            </tr>
                            <tr colspan="12">
                                <td colspan="12"></td>
                            </tr>
                            <tr colspan="12">
                                <td colspan="12" style="text-align: center; font-weight: bold;">CERTIFICATE OF ACCEPTANCE
                                </td>
                            </tr>
                            <tr>
                                <td colspan="12" style="text-align: center;">
                                    <p>I hereby certify to have accepted each and every article delivered/service rendered by as listed in the attached Invoice</p>
                                    <p>No. _____________________ dated ___________________ which has/have been inspected and was/were found to be in accordance with the </p>
                                    <p>specifications stipulated under Purchase Order No. _____________________ dated ___________________</p>
                                    <br />
                                    <p>Name of Property Supply Officer: ____________________________________ Signature/Date: _________________________________</p>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="12"></td>
                            </tr>
                        </table>
                        <div class="text-center mt-3">
                            <label id="lblEndNote" runat="server" visible="false">
                                <b>Note</b>: System-generated approval. No signature required.</label>
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
                <div class="text-md-center" id="divLinkButtons" runat="server" visible="false">
                    <asp:LinkButton runat="server" class="btn btn-danger m-2" Width="150px" ID="lbDecline"
                        data-toggle="modal" data-target="#declineModal" CausesValidation="true" ValidationGroup="returnDeclineValidation" Visible="false"><i class="ri-forbid-fill"></i>&nbsp;&nbsp;Decline</asp:LinkButton>
                    <asp:LinkButton runat="server" class="btn btn-primary m-2" Width="150px" ID="lbReturn"
                        Visible="false" OnClientClick="return confirmApplication(this, 'return');"
                        CausesValidation="true" ValidationGroup="returnDeclineValidation"><i class="ri-arrow-go-back-fill"></i>&nbsp;&nbsp;Return</asp:LinkButton>
                    <asp:LinkButton runat="server" class="btn btn-primary m-2" Width="150px" ID="lbApprove"
                        Visible="false" OnClientClick="return confirmApplication(this, 'approve');" OnClick="lbApprove_Click"><i class="ri-check-fill"></i>&nbsp;&nbsp;Approve</asp:LinkButton>
                    <asp:LinkButton runat="server" class="btn btn-primary m-2" Width="150px" ID="lbRecommend"
                        Visible="false" OnClientClick="return confirmApplication(this, 'recommend');" ValidationGroup="budgetValidation" OnClick="lbRecommend_Click">Recommend&nbsp;&nbsp;<i class="ri-arrow-go-forward-fill"></i></asp:LinkButton>
                </div>



            </div>

            <div>
            </div>
        </div>
    </div>
</asp:Content>
