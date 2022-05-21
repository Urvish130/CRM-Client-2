<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Complaint.aspx.cs" Inherits="Complaint" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
            <h1>Complaint Entry
                     <asp:Label  class="control-label" ID="lblmsg" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Complaint</a></li>
                <li class="active">Complaint Entry</li>
                <asp:Label ID="lblcomno" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblrole" runat="server" Visible="false" Text=""></asp:Label>
            </ol>
        </section>

        <section class="content">
            <!-- SELECT2 EXAMPLE -->
            <div class="box box-primary">

                <!-- /.box-header -->
                <div class="box-body">

                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                No:<span class="required">* </span>
                            </label>
                            <asp:TextBox ID="txtno" class="form-control"  TabIndex="1" ReadOnly="true" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtno"
                                Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" ValidationGroup="Emst" SetFocusOnError="true" ForeColor="Red"
                                CssClass="validate"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Date:
                            </label>
                            <asp:TextBox ID="txtdate" class="form-control" placeholder="dd/mm/yyyy" TabIndex="2" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender3" TargetControlID="txtdate" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label>Customer Group <span class="required">* </span></label>


                            <div class="input-group">
                                <asp:DropDownList ID="dpcustgroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpcustgroup_SelectedIndexChanged" data-placeholder="Select Customer Group" CssClass="form-control select2" TabIndex="3"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:HyperLink ID="Custgroupbtn" href="CustomerGroup.aspx" Target="_blank" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                            <asp:LinkButton ID="lbtncustgroup" runat="server" OnClick="RefreshCustGroup" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                                </div>


                        </div>
                        

                    </div>
                   <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Name of Customer <span class="required">* </span></label>


                            <div class="input-group">
                                <asp:DropDownList ID="dpcust" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpcust_SelectedIndexChanged" data-placeholder="Select Customer" CssClass="form-control select2" TabIndex="3"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:HyperLink ID="Custbtn" runat="server" href="CustomerMaster.aspx" Target="_blank" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                          <asp:LinkButton ID="lbtncust" runat="server"  OnClick="RefreshCustGroup" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                                </div>


                        </div>
                        <div class="col-md-6 form-group">
                            <label>Contact Person<span class="required">* </span></label>


                            <div class="input-group">
                                <asp:DropDownList ID="dpcontactper" runat="server" AutoPostBack="true"  data-placeholder="Select Contact Person" CssClass="form-control select2" TabIndex="5"></asp:DropDownList>
                                <span class="input-group-btn">
                                     <asp:HyperLink ID="CustContactbtn" runat="server" href="AddCustomerContactMaster.aspx" Target="_blank" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                                    <asp:LinkButton ID="lbtncustcontact" runat="server" OnClick="RefreshCustCOntactGroup" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                            </div>


                        </div>
                   </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Department 
                            </label>
                            <div class="input-group">
                                <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="false" data-placeholder="Select Department" CssClass="form-control select2" TabIndex="23"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lnbDept" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                            </div>

                        </div>
                         <div class="col-md-6 form-group">
                            <label class="control-label">
                                Designation 
                            </label>
                            <div class="input-group">
                                <asp:DropDownList ID="ddldesign" runat="server" AutoPostBack="false" data-placeholder="Select Designation" CssClass="form-control select2" TabIndex="24"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lbtncreatedesign" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        
                       <div class="col-md-4 form-group">
                                <label>Assign To<span class="required">* </span></label>


                                <div class="input-group">
                                    <asp:DropDownList ID="dpassignto" runat="server" AutoPostBack="false" data-placeholder="Select Employee Name" CssClass="form-control select2" TabIndex="5"></asp:DropDownList>
                                    <span class="input-group-btn">
                                         <asp:HyperLink ID="AddEmployee" runat="server" href="Distributor.aspx" Target="_blank" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                                       <asp:LinkButton ID="RefreshEmployee" runat="server" OnClick="RefreshAssignTo" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                                        
                                </div>


                            </div>
                        <div class="col-md-4 form-group">
                                <label>Status<span class="required">* </span></label>


                                <div class="input-group">
                                    <asp:DropDownList ID="dpfollowstatus" runat="server" AutoPostBack="false" data-placeholder="Select Conatct Person" CssClass="form-control select2" TabIndex="5"></asp:DropDownList>
                                    <span class="input-group-btn">

                                        <asp:LinkButton ID="LinkButton8" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                                </div>


                            </div>
                        <div class="col-md-4 form-group">
                               <label>Image Upload<span class="required">* </span></label>
                              <div class="input-group">
                              <asp:FileUpload ID="FileUpload1" TabIndex="27" runat="server" />
                                <div style="padding:10px">
                                 <asp:Label ID="lblimgpathname" runat="server" Visible="false" Text=""><b>Image Path :</b></asp:Label>
                                 <asp:Label ID="lblimgpath" runat="server" Visible="false" Text=""></asp:Label>
                                    </div>
                                  </div>
                        </div>
                    </div>
                  

                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label class="control-label">
                                 Issue/ Problem
                            </label>
                            <asp:TextBox ID="txtremarks" placeholder="Enter Issue/Problem" class="form-control" TabIndex="10" TextMode="MultiLine" runat="server"></asp:TextBox>

                        </div>
                        </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label class="control-label">
                                Solution Provided & Progress Of same
                            </label>
                            <asp:TextBox ID="TextBox1" placeholder="Enter Solution Provided" class="form-control" TabIndex="10" TextMode="MultiLine" runat="server"></asp:TextBox>

                        </div>
                        </div>
                </div>
                


                


                <div class="box-body">
                    <div class="box box-primary">


                        <div class="row">
                            <div class="col-md-12 form-group" style="padding-top: 5px; text-align: right">
                                <asp:LinkButton ID="btnSave" runat="server"  ValidationGroup="Emst" TabIndex="36" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                <asp:LinkButton ID="btnUpdate" Visible="false" runat="server" TabIndex="37" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" TabIndex="38" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>
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
                                                     <div class="col-md-6">
                     <asp:Label ID="lblmsg3" runat="server" Text="" ForeColor="Red"></asp:Label>
                 </div>
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncreatedept" ValidationGroup="deptgrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton4"  runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
                                                      <div class="col-md-6">
                     <asp:Label ID="lblmsg4" runat="server" Text="" ForeColor="Red"></asp:Label>
                 </div>
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtndesigncreate" ValidationGroup="designgrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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

