<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateItem.aspx.cs" Inherits="UpdateItem" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    
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
            text-align: left;
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
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Item Master
                     <asp:Label  class="control-label" ID="lblmsg" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Master</a></li>
                <li class="active">Item Master</li>

                 <asp:Label ID="lblrole" Visible="false" runat="server" Text=""></asp:Label>
                  <asp:Label ID="lblloginid" Visible="false" runat="server" Text=""></asp:Label>
                  <asp:Label ID="lblcomno" runat="server" Text=""></asp:Label>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-primary">
                        
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-6 form-group">
                                    <label>Select Group<span class="required">* </span></label>
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlgroup" runat="server" CssClass="form-control select2" TabIndex="1" data-placeholder="Select Group"></asp:DropDownList>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lbtncreategroupname" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                                    </div>

                                </div>
                                <div class="col-md-6 form-group">
                                    <label>Select Sub Group</label>
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddlsubgroup" runat="server" class="form-control select2" TabIndex="2" data-placeholder="Select SubGroup"></asp:DropDownList>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lbtncreatesubgroupname" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                                    </div>
                                </div>
                                <div class="col-md-6 form-group">
                                    <label>Model No</label>
                                    <asp:TextBox ID="txtModalNo" CssClass="form-control" TabIndex="3" runat="server" onkeyup="myFunction(this.id)"></asp:TextBox>

                                </div>
                                <div class="col-md-6 form-group">
                                    <label>Item Name</label>
                                    <asp:TextBox ID="txtItemName" CssClass="form-control" TabIndex="4" runat="server" onkeyup="myFunction(this.id)"></asp:TextBox>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Item Final Name</label>
                                    <asp:TextBox ID="txtFinalName" CssClass="form-control" TabIndex="5" runat="server" ></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Item Alias</label>
                                    <asp:TextBox ID="txtAlias" CssClass="form-control" TabIndex="6" runat="server" onkeyup="myFunction(this.id)"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label>Item Catalogue Number</label>
                                    <asp:TextBox ID="txtitemcategoryno" CssClass="form-control" TabIndex="6" runat="server" onkeyup="myFunction(this.id)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label>UOM</label>
                                    <div class="input-group">
                                        <asp:DropDownList ID="ddluom" runat="server" CssClass="form-control select2" TabIndex="7" data-placeholder="Select UOM"></asp:DropDownList>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lbtncreatuom" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddluom"
                                        Display="Dynamic" ErrorMessage="Please Select UOM" Text="(*)Required" ForeColor="Red" SetFocusOnError="true"
                                        CssClass="validate" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-3" runat="server" visible="false">
                                    <label class="control-label">Is BOM?</label>
                                    <asp:RadioButtonList ID="rdbBOM" runat="server" CssClass="radioboxlist form-control" RepeatDirection="Horizontal" TabIndex="8">
                                        <asp:ListItem Selected="True">No</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="col-md-3" runat="server" visible="false" style="margin-top: 27px;">
                                    <asp:LinkButton ID="btnBOM" runat="server" CausesValidation="false" TabIndex="9" CssClass="btn btn-adn btn-flat"><i class="fa fa-edit"></i>&nbsp;Create</asp:LinkButton>
                                </div>
                                <div class="col-md-3 form-group">
                                    <label>Rate</label>
                                    <asp:TextBox ID="txtRate" CssClass="form-control" TabIndex="10" runat="server"></asp:TextBox>

                                </div>
                                <div class="col-md-3 form-group">
                                    <label>GST (%)</label>
                                    <asp:TextBox ID="txtGST" CssClass="form-control" TabIndex="11" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3 form-group">
                                    <label>HSN Code</label>
                                    <asp:TextBox ID="txtHSN" CssClass="form-control" TabIndex="12" runat="server"></asp:TextBox>
                                </div>
                            </div>
                              <div class="row" style="margin-top: 10px;">
                                 <div class="col-md-6 form-group">
                                    <label>Import Duty</label>
                                    <asp:TextBox ID="txtImportDuty" CssClass="form-control" TabIndex="12" runat="server"></asp:TextBox>
                                </div>
                                  <div class="col-md-6 form-group">
                                    
                                    <asp:TextBox ID="txtExportDuty" CssClass="form-control"  Visible ="false" TabIndex="12" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 form-group">
                                    <label>Item Description</label>
                                    <asp:TextBox ID="txtDescp" CssClass="form-control" TabIndex="13" runat="server" Rows="4" TextMode="MultiLine" onkeyup="myFunction(this.id)"></asp:TextBox>
                                </div>
                                </div>
                                 <div class="box">
                                <div class="row">
                                    <div class="col-md-2 form-group">
                                        <label>Upload Item Pic.</label>
                                        <asp:FileUpload runat="server" ID="fuItemPic" onchange="UploadFile(this);" TabIndex="14" />
                                    </div>
                                    <div class="col-md-6 form-group" style="margin-top: 17px">
                                        <asp:Button ID="btnitemimg" OnClick="btnitemimg_Click" CssClass="btn btn-bitbucket btn-flat" Text="Add Item Image" runat="server" CausesValidation="false" />
                                    </div>
                                    <asp:HiddenField ID="hfItemPic" runat="server" />
                                    <asp:Image ID="ImgPrv" runat="server" CssClass="imgStud" Style="margin-top: 5px;" />


                                </div>

                                <div class="row">

                                    <div class="box-body">
                                        <asp:GridView ID="grditem" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                            AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grditem_RowCommand" ShowHeaderWhenEmpty="true"
                                            CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                            CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                            <AlternatingRowStyle BackColor="White" />
                                            <PagerStyle CssClass="csspager" />
                                            <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Document Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("Filename") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                    <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                            runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                            CommandName="Download" CausesValidation="False" />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                    <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" ImageUrl="images/delete.png" ToolTip="Click here to delete"
                                                            runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Id") %>'
                                                            CommandName="deletedata" CausesValidation="False" />
                                                        <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" ConfirmText="Do You Want to Delete?" runat="server" TargetControlID="btnDelete"></asp:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                    <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                </asp:TemplateField>


                                            </Columns>
                                            <EditRowStyle HorizontalAlign="Center"></EditRowStyle>
                                        </asp:GridView>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-2 form-group">
                                        <label>Upload Item Broucher</label>
                                        <asp:FileUpload runat="server" ID="fuBroucher" onchange="UploadFile(this);" TabIndex="14" />
                                    </div>
                                    <div class="col-md-6 form-group" style="margin-top: 17px">
                                        <asp:Button ID="btnadditembro" OnClick="btnadditembro_Click" CssClass="btn btn-bitbucket btn-flat" Text="Add Item Broucher" runat="server" CausesValidation="false" />
                                    </div>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:Image ID="Image1" runat="server" CssClass="imgStud" Style="margin-top: 5px;" />


                                </div>

                                <div class="row">

                                    <div class="box-body">
                                        <asp:GridView ID="grditembro" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                            AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grditembro_RowCommand" ShowHeaderWhenEmpty="true"
                                            CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                            CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                            <AlternatingRowStyle BackColor="White" />
                                            <PagerStyle CssClass="csspager" />
                                            <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                            <Columns>
                                                <asp:TemplateField HeaderText="Document Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("fileName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                    <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                            runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                            CommandName="Download" CausesValidation="False" />
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                    <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" ImageUrl="images/delete.png" ToolTip="Click here to delete"
                                                            runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Id") %>'
                                                            CommandName="deletedata" CausesValidation="False" />
                                                        <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" ConfirmText="Do You Want to Delete?" runat="server" TargetControlID="btnDelete"></asp:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                    <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                </asp:TemplateField>


                                            </Columns>
                                            <EditRowStyle HorizontalAlign="Center"></EditRowStyle>
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div class="col-md-3 form-group pull-right" style="text-align: right; margin-top: 5%">
                                    <asp:LinkButton ID="btnSave" OnClick="btnSave_Click" runat="server" TabIndex="16" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                      <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" TabIndex="28" ValidationGroup="comgroup" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Delete</asp:LinkButton>
                                    <asp:LinkButton ID="btnreset" runat="server" TabIndex="17" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <asp:ModalPopupExtender ID="mpdesign" runat="server" PopupControlID="pnldesign" TargetControlID="lbtncreategroupname"
            CancelControlID="btnclosedesign" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnldesign" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div style="height: 60px">
                <div class="example-modal">
                    <div class="modal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btnclosedesign" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create Group</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Name<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtgroupname" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtgroupname"
                                                            Display="Dynamic" ErrorMessage="Please Group Name" ValidationGroup="cgroup" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <asp:Label  class="control-label" ID="lblmsg1" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncreategroup" OnClick="lbtncreategroup_Click" ValidationGroup="cgroup" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="lbtnresetgroup" OnClick="lbtnresetgroup_Click" runat="server"  TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
            <asp:Button ID="Button3" runat="server" Text="Close" />
        </asp:Panel>




        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlsubgroup" TargetControlID="lbtncreatesubgroupname"
            CancelControlID="btnclosesubgroup" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlsubgroup" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div style="height: 60px">
                <div class="example-modal">
                    <div class="modal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btnclosesubgroup" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create SubGroup</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Name<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtsubgroupnamemp" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsubgroupnamemp"
                                                            Display="Dynamic" ErrorMessage="Please SubGroup Name" ValidationGroup="csgroup" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Under Item Group
                                                        </label>
                                                        <asp:DropDownList ID="dlgroupnamemp" class="form-control" runat="server"></asp:DropDownList>
                                                    </div>
                                                    <asp:Label  class="control-label" ID="lblmsg2" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtcreatesubgroup" OnClick="lbtcreatesubgroup_Click" ValidationGroup="csgroup" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2"  runat="server" OnClick="lbtnresetgroup_Click" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
                </div>
            </div>

            <asp:Button ID="Button1" runat="server" Text="Close" />
        </asp:Panel>



        <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="pnluom" TargetControlID="lbtncreatuom"
            CancelControlID="btncloseunit" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnluom" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div style="height: 60px">
                <div class="example-modal">
                    <div class="modal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btncloseunit" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create UOM</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Name<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtuom" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtuom"
                                                            Display="Dynamic" ErrorMessage="Please Group Name" ValidationGroup="uomgroup" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <asp:Label  class="control-label" ID="lblmsg3" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncreateuom" OnClick="lbtncreateuom_Click" ValidationGroup="uomgroup" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton3"  OnClick="lbtnresetgroup_Click" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
            <asp:Button ID="Button2" runat="server" Text="Close" />
        </asp:Panel>


    </div>
</asp:Content>

