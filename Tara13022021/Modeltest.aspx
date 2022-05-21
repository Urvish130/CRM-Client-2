<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Modeltest.aspx.cs" Inherits="Modeltest" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../../bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../../dist/css/skins/_all-skins.min.css">



    <style>
        .example-modal .modal {
            position: relative;
            top: auto;
            bottom: auto;
            right: auto;
            left: auto;
            text-align:left;
            display: block;
            z-index: 1;
        }

        .example-modal .modal {
            background: transparent !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <asp:Button ID="btnShow" CausesValidation="false" runat="server" Text="Show Modal Popup" />
        <asp:Panel ID="pnlnbussinesstype" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div style="height: 60px">
                <div class="example-modal">
                    <div class="modal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btnclosebtype" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align:center">Create Bussiness Type</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Business type Name<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtName" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                                            Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Business type Name<span class="required">* </span>
                                                        </label>
                                                      
                                                        <asp:DropDownList ID="DropDownList1" class="form-control" runat="server"></asp:DropDownList>

                                                    </div>


                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="btnSave" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                                        <asp:LinkButton ID="btnUpdate" Visible="false" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                                        <asp:LinkButton ID="btnDelete" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                    <!-- /.modal -->
                </div>
            </div>
            <asp:Button ID="btnClose" runat="server" Text="Close" />
        </asp:Panel>


        <asp:ModalPopupExtender ID="mpbtype" runat="server" PopupControlID="pnlnbussinesstype" TargetControlID="btnShow"
            CancelControlID="btnclosebtype" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
    </div>
</asp:Content>

