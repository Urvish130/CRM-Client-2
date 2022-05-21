<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddCustContactWhileUpdate.aspx.cs" Inherits="AddCustContactWhileUpdate" %>
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
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Customer  Master
                    
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Master</a></li>
                <li class="active">Customer  Master</li>
                <asp:Label ID="lblcomno" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                  <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
                  <asp:Label ID="lblrole" runat="server" Visible="false" Text=""></asp:Label>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <!-- SELECT2 EXAMPLE -->
            <div class="box box-primary">

                <!-- /.box-header -->
                <div class="box-body">

                    <div class="row">
                        
                        <div class="col-md-12 form-group">
                            <label class="control-label">
                                Customer Group 
                            </label>
                            <div class="input-group">
                                <asp:DropDownList ID="dpcustgroup" runat="server" AutoPostBack="false" data-placeholder="Parul University" CssClass="form-control select2" TabIndex="14"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label class="control-label">
                                Name<span class="required">* </span>
                            </label>
                            <asp:TextBox ID="txtName" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" ValidationGroup="cust" SetFocusOnError="true" ForeColor="Red"
                                CssClass="validate"></asp:RequiredFieldValidator>
                        </div>
                       
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Address
                            </label>
                            <asp:TextBox ID="txtaddress" TextMode="MultiLine" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                        </div>
                         <div class="col-md-6 form-group">
                            <label class="control-label">
                                City/Taluka
                            </label>
                            <asp:TextBox ID="txtcity" class="form-control" TabIndex="3" runat="server"></asp:TextBox>
                          
                        </div>

                    </div>

                    <div class="row">
                       <div class="col-md-6 form-group">
                            <label class="control-label">
                                District 
                            </label>
                            <asp:TextBox ID="txtdistrict" class="form-control" TabIndex="4" runat="server"></asp:TextBox>
                            
                        </div>

                        <div class="col-md-6 form-group">
                            <label>State</label>
                            <asp:TextBox ID="txtstate" class="form-control" TabIndex="5" runat="server"></asp:TextBox>
                            
                        </div>
                    </div>
                    <div class="row">
                        
                        <div class="col-md-6 form-group">
                            <label>Country </label>
                            <asp:TextBox ID="txtcountry" class="form-control" TabIndex="6" runat="server"></asp:TextBox>
                           
                        </div>

                        <div class="col-md-6 form-group">
                            <label>Pincode </label>
                            <asp:TextBox ID="txtpincode" class="form-control" TabIndex="7" runat="server"></asp:TextBox>
                           
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Phone No 
                            </label>
                            <asp:TextBox ID="txtphno" CssClass="form-control" TabIndex="8" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Email<span class="required">*</span>
                            </label>
                            <asp:TextBox ID="txtemail" CssClass="form-control" ClientIDMode="Static" TabIndex="9" runat="server"></asp:TextBox>

                        </div>
                    </div>

                     <div class="row">
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Business type
                            </label>
                            <div class="input-group">
                                <asp:DropDownList ID="dpbusstype" runat="server" AutoPostBack="false" data-placeholder="Select Business type" CssClass="form-control select2" TabIndex="10"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lbtncreatebtype" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                            </div>


                        </div>
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Industry Group
                            </label>
                            <div class="input-group">
                                <asp:DropDownList ID="dpindustry" runat="server" AutoPostBack="false" data-placeholder="Select Industry Group" CssClass="form-control select2" TabIndex="11"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lbtncindugrp" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>URL</label>
                            <asp:TextBox ID="txturl" CssClass="form-control" TabIndex="12" runat="server"></asp:TextBox>

                        </div>
                        <div class="col-md-6 form-group">

                            <label class="control-label">Status</label>
                            <asp:RadioButtonList ID="rbtnstatus" runat="server" CssClass="radioboxlist form-control" RepeatDirection="Horizontal" TabIndex="13">
                                <asp:ListItem Selected="True">Active</asp:ListItem>
                                <asp:ListItem>Inactive</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                GST No
                            </label>
                            <asp:TextBox ID="txtgstno" CssClass="form-control" TabIndex="14" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Bank Name
                            </label>
                            <asp:TextBox ID="txtbankname" CssClass="form-control" ClientIDMode="Static" TabIndex="15" runat="server"></asp:TextBox>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Account No
                            </label>
                            <asp:TextBox ID="txtaccno" CssClass="form-control" TabIndex="16" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                IFSC code
                            </label>
                            <asp:TextBox ID="txtifsccode" CssClass="form-control" ClientIDMode="Static" TabIndex="17" runat="server"></asp:TextBox>

                        </div>
                    </div>

                </div>
                <section class="content-header">
                    <h3>Contact Person
                    
                    </h3>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label class="control-label">
                                Name<span class="required">*</span>
                            </label>
                            <asp:TextBox ID="txtcontactname" CssClass="form-control" TabIndex="18" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcontactname"
                                Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" SetFocusOnError="true" ValidationGroup="custcontact" ForeColor="Red"
                                CssClass="validate"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4 form-group">
                            <label class="control-label">
                                Email 
                            </label>
                            <asp:TextBox ID="txtcontactemail" CssClass="form-control" TabIndex="19" runat="server"></asp:TextBox>

                        </div>
                        <div class="col-md-4 form-group">
                            <label class="control-label">
                                Phone No
                            </label>
                            <asp:TextBox ID="txtcontactphno" CssClass="form-control" TabIndex="20" runat="server"></asp:TextBox>


                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-4 form-group">
                            <label class="control-label">
                                Mobile No(1)
                            </label>
                            <asp:TextBox ID="txtcontactmno1" CssClass="form-control" TabIndex="21" runat="server"></asp:TextBox>


                        </div>
                        <div class="col-md-4 form-group">
                            <label class="control-label">
                                Mobile No(2)
                            </label>
                            <asp:TextBox ID="txtcontactmno2" CssClass="form-control" TabIndex="22" runat="server"></asp:TextBox>


                        </div>
                        <div class="col-md-4 form-group">
                            <label class="control-label">
                                Department 
                            </label>
                            <div class="input-group">
                                <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="false" data-placeholder="Select Department" CssClass="form-control select2" TabIndex="23"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lnbDept" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                            </div>

                        </div>


                    </div>

                       <div class="row">

                        <div class="col-md-4 form-group">
                            <label class="control-label">
                                Designation 
                            </label>
                            <div class="input-group">
                                <asp:DropDownList ID="ddldesign" runat="server" AutoPostBack="false" data-placeholder="Select Designation" CssClass="form-control select2" TabIndex="24"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lbtncreatedesign" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                            </div>
                        </div>
                        <div class="col-md-4 form-group">
                            <label class="control-label">
                                Date of Birth
                            </label>
                            <asp:TextBox ID="txtdob" CssClass="form-control" TabIndex="25" runat="server"></asp:TextBox>
                               <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtdob" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>


                        </div>
                        <div class="col-md-4 form-group">
                            <label class="control-label">
                                Date of Anniversary
                            </label>
                            <asp:TextBox ID="txtdoani" CssClass="form-control" data-inputmask="'alias': 'dd/mm/yyyy'"  TabIndex="26" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" TargetControlID="txtdoani" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>

                        </div>

                    </div>
                    <div class="row" style="text-align:right">
                        <div class="col-md-12 form-group" style="text-align: right">
                            <asp:LinkButton ID="lbtnaddcontact" Style="margin-top: 25px" OnClick="lbtnaddcontact_Click" ValidationGroup="comgcontactroup" runat="server" TabIndex="27" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Add contact </asp:LinkButton>
                            <asp:LinkButton ID="lbtnupdatecontact" Visible="false" runat="server" OnClick="lbtnupdatecontact_Click" ValidationGroup="comgcontactroup" TabIndex="28" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                            <asp:LinkButton ID="lbtnresetcontact" runat="server" TabIndex="29" OnClick="lbtnresetcontact_Click" Style="margin-top: 25px" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>

                        </div>
                    </div>

                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdcontact" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdcontact_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("ContactName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" Text='<%# Eval("ContactEmail") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PhoneNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactPhone" runat="server" Text='<%# Eval("ContactPhone") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobileno1">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactMobileno1" runat="server" Text='<%# Eval("ContactMobileno1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobileno2">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactMobileno2" runat="server" Text='<%# Eval("ContactMobileno2") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeptName" runat="server" Text='<%# Eval("DeptName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Designation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesigName" runat="server" Text='<%# Eval("DesigName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Date of Birth">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldob" runat="server" Text='<%# Eval("Extra1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Date of Anniversary">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldoani" runat="server" Text='<%# Eval("Extra2") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnedit" ImageUrl="images/viewIcon.png" ToolTip="Click here to update"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Id") %>'
                                                CommandName="editdata" CausesValidation="False" />
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

                </section>


                <div class="row" style="text-align: right">

                    <div class="col-md-12 form-group" style="padding-top: 5px">
                        <asp:LinkButton ID="btnupdate" runat="server" TabIndex="30" ValidationGroup="cust" OnClick="btnupdate_Click" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                        <asp:LinkButton ID="btndelete" Visible="false" OnClick="btndelete_Click" runat="server" TabIndex="31" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                        <asp:LinkButton ID="btncancel" runat="server" OnClick="btncancel_Click" TabIndex="32" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
                    </div>
                </div>
                <!-- /.row -->
        </section>




         <asp:ModalPopupExtender ID="mpbtype" runat="server" PopupControlID="pnlnbussinesstype" TargetControlID="lbtncreatebtype"
            CancelControlID="btnclosebtype" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlnbussinesstype" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div style="height: 60px">
                <div class="example-modal">
                    <div class="modal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btnclosebtype" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create Bussiness Type</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Business type Name<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtbtypename" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbtypename"
                                                            Display="Dynamic" ErrorMessage="Please Enter Name" ValidationGroup="btype" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncbytype" OnClick="lbtncbytype_Click" ValidationGroup="btype" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                                      
                                                        <asp:LinkButton ID="LinkButton5" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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



        <asp:ModalPopupExtender ID="mpindutype" runat="server" PopupControlID="pnlindugrp" TargetControlID="lbtncindugrp"
            CancelControlID="btncloseindugrp" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlindugrp" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div style="height: 60px">
                <div class="example-modal">
                    <div class="modal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btncloseindugrp" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create Industry Group</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                           Industry Group<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtgroupname" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtgroupname"
                                                            Display="Dynamic" ErrorMessage="Please Group Name" ValidationGroup="indugrp" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncreateindugroup" OnClick="lbtncreateindugroup_Click" ValidationGroup="indugrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                                      
                                                        <asp:LinkButton ID="LinkButton3" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
            <asp:Button ID="Button1" runat="server" Text="Close" />
        </asp:Panel>


        <asp:ModalPopupExtender ID="mpdept" runat="server" PopupControlID="pnldept" TargetControlID="lnbDept"
            CancelControlID="btnclosedept" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnldept" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div style="height: 60px">
                <div class="example-modal">
                    <div class="modal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btnclosedept" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create Department</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                           Department Name<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtdeptname" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdeptname"
                                                            Display="Dynamic" ErrorMessage="Please Department Name" ValidationGroup="deptgrp" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncreatedept" OnClick="lbtncreatedept_Click" ValidationGroup="deptgrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                                      
                                                        <asp:LinkButton ID="LinkButton4" runat="server"  TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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



         <asp:ModalPopupExtender ID="mpdesign" runat="server" PopupControlID="pnldesign" TargetControlID="lbtncreatedesign"
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
                                    <h4 class="modal-title" style="text-align: center">Create Designation</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                           Designation Name<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtdesign" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdesign"
                                                            Display="Dynamic" ErrorMessage="Please Department Name" ValidationGroup="designgrp" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtndesigncreate" OnClick="lbtndesigncreate_Click" ValidationGroup="designgrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                                      
                                                        <asp:LinkButton ID="LinkButton2" runat="server"  TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
    </div>
</asp:Content>

