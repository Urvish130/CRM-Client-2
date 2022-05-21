<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.master"  CodeFile="QuotationReport.aspx.cs" Inherits="QuotationReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .messagealert {
            width: 30%;
            position: fixed;
            top: 0px;
            left: 35%;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }

        .modalBackground {
            background-color: black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            z-index: 99 !important;
        }

        .modalPopup2 {
            background-color: #FFFFFF;
            border: 3px solid black;
            padding-top: 10px;
            padding-left: 10px;
            width: 700px;
            height: auto;
            border-radius: 10px;
            z-index: 100 !important;
        }

            .modalPopup2 .heading {
                background-color: white;
                /*height: 30px;*/
                /*color: red;*/
                /*line-height: 30px;*/
                text-align: center;
                font-weight: bold;
                border-radius: 20px;
            }

        .closeimg2 {
            position: absolute;
            top: 1px;
            right: 1px;
            display: block;
            width: 30px;
            height: 30px;
            font-size: 30px;
            /*text-indent: -9999px;*/
        }

        .modalPopupCust {
            background-color: #FFFFFF;
            padding-top: 10px;
            padding-left: 10px;
            width: auto;
            height: auto;
            /*z-index: 100 !important;*/
        }

            .modalPopupCust .heading {
                background-color: white;
                text-align: center;
                font-weight: bold;
                border-radius: 20px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
            <br />
            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" CssClass="btn btn-primary" Text="SendEmail" runat="server" OnClick="btnExport_Click" />
            <br />
            <ol class="breadcrumb">
                <li><a href="Default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="QuotationRegistry.aspx">Quotation</a></li>
                <li class="active">Quotation Print</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <rsweb:reportviewer ID="ReportViewer1" Font-Names="Verdana" Font-Size="8pt"
                        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                        WaitMessageFont-Size="14pt" Height="800px" Width="745px" runat="server">
                        <LocalReport ReportPath="~/Reports/Quotation.rdlc">
                        </LocalReport>
                    </rsweb:reportviewer>
                    
                </div>
            </div>
        </section>
    </div>
    <asp:HiddenField ID="hfmail" runat="server" />
    <asp:HiddenField ID="hfId" runat="server" />
    <asp:ModalPopupExtender ID="mpmail" runat="server" PopupControlID="pnlmail" TargetControlID="hfmail" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlmail" runat="server" CssClass="modalPopup2">
        <div class="heading">
            <h3>Enter Email ID :</h3>
            <asp:LinkButton ID="lbtncancel" runat="server" class="closeimg2" CausesValidation="false" OnClick="lbtncancel_Click">&times;</asp:LinkButton>
        </div>
        <div class="modalbody">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-warning">
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Email<span class="required">* </span></label>
                                    <asp:TextBox ID="txtmail" CssClass="form-control" TabIndex="2" TextMode="MultiLine" runat="server" ValidationGroup="vgFlpDone"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-bottom: 5px;">
                            <div class="col-md-10">
                                <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="" Style="font-size: 24px; font-weight: 700;"></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: right;">
                                <asp:Button ID="btnsendmail" runat="server" Text="Send" TabIndex="5" CssClass="btn btn-bitbucket btn-flat" ValidationGroup="vgFlpDone" OnClick="btnsendmail_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

