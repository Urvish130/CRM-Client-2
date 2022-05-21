<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateQuotation.aspx.cs" Inherits="UpdateQuotation" %>

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

    <script type="text/javascript">
        function tSpeedValue(txt) {



            var qty = txtqty.value;
            var rate = txtrate.value;
            var currency = txtcurrency.value;
            var amount = qty * (rate);
            amount.toFixed(2);
            txtamount.value = amount;
          


        }
    </script>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
      <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
       <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            debugger;
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            debugger;
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <style>
        .example-modal1 .modal {
    position: absolute;
    width: 500px;
    height: 800px;
    /* bottom: 25%; */
    /* right: -47%; */
    left: -350%;
    text-align: left;
    display: block;
    z-index: 1;
    /*margin: auto;
    justify-content: center;*/
    /* overflow: scroll; */
}
     .modal-dialog1 {
    width: 500px;
    margin: 30px auto;
}
     .modal {
    background: none;
}

     .unselectable ajax__html_editor_extender_container{
             height: 288px;
             width:auto !important;
     }
.modal-dialog {
    width: 1000px;
    margin: 30px auto;
}
        .unselectable ajax__html_editor_extender_container
        {
            height:auto;
            width: auto!important;
        }
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


     <style>
                .example-modal .modal {
    position: absolute;
    width: 500px;
    height: 800px;
    /* bottom: 25%; */
    /* right: 25%; */
    /* left: -2%; */
    text-align: left;
    display: block;
    z-index: 1;
    margin: auto;
    justify-content: center;
    /*overflow:scroll;*/
}
         .example2-modal .modal {
    position: absolute;
    width: 1300px;
    height: 800px;
    /* bottom: 25%; */
    /* right: 25%; */
    /* left: -2%; */
    text-align: left;
    display: block;
    z-index: 1;
    margin: auto;
    justify-content: center;
    /*overflow:scroll;*/
}
        /*.example2-modal .modal {
            position: absolute;
             
         width: 1000px;
  height: 500px;
            bottom: 25%;
            right: 25%;
           left:auto;
            text-align: left;
            display: block;
            z-index: 1;
        }*/

        .example2-modal .modal {
            background: transparent !important;
        }
    </style>
     <style>
        .reveal-modal     
  {
        background:#e1e1e1; 
        visibility:hidden;
        display:none;
        top:100px; 
        left:50%; 
        width:820px; 
        position:absolute; 
        z-index:41;
        padding:30px; 
        -webkit-box-shadow:0 0 10px rgba(0,0,0,0.4);
        -moz-box-shadow:0 0 10px rgba(0,0,0,0.4); 
        box-shadow:0 0 10px rgba(0,0,0,0.4)
  }
        }

        .example-modal .modal {
            background: transparent !important;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
   
    <div class="content-wrapper">
        <section class="content-header">
            <h1>Quotation Entry
                     <asp:Label  class="control-label" ID="lblmsg" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Inqiury</a></li>
                <li class="active">Inquiry Entry</li>
                <asp:Label ID="lblcomno" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblrole" runat="server" Visible="false" Text=""></asp:Label>
                  <asp:Label ID="lblcompanyno" runat="server" Visible="false" Text=""></asp:Label>
            </ol>
        </section>

        <section class="content">
            <!-- SELECT2 EXAMPLE -->
            <div class="box box-primary">
                 <div id="alert_container"></div>
                <!-- /.box-header -->
                <div class="box-body">

                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                No:<span class="required">* </span>
                            </label>
                            <asp:TextBox ID="txtno" class="form-control" TabIndex="1" ReadOnly="true" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtno"
                                Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" ValidationGroup="Emst" SetFocusOnError="true" ForeColor="Red"
                                CssClass="validate"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Date:
                            </label>
                            <asp:TextBox ID="txtdate" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
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
                            <label>Status <span class="required">* </span></label>


                            <div class="input-group">
                            
                                <asp:DropDownList ID="dpstatus" runat="server"  AutoPostBack="false" data-placeholder="Select Customer" CssClass="form-control select2" TabIndex="4"></asp:DropDownList>
                                <span class="input-group-btn">
                                   <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                            </div>


                        </div>
                    </div>



                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Contact Person<span class="required">* </span></label>


                            <div class="input-group">
                                <asp:DropDownList ID="dpcontactper" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpcontactper_SelectedIndexChanged" data-placeholder="Select Contact Person" CssClass="form-control select2" TabIndex="5"></asp:DropDownList>
                                <span class="input-group-btn">
                                     <asp:HyperLink ID="CustContactbtn" runat="server" href="AddCustomerContactMaster.aspx" Target="_blank" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                                    <asp:LinkButton ID="lbtncustcontact" runat="server" OnClick="RefreshCustCOntactGroup" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                            </div>


                        </div>
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Contact no
                            </label>
                            <asp:TextBox ID="txtcontactno" class="form-control" TabIndex="6" runat="server"></asp:TextBox>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label>Department<span class="required"> </span></label>


                            <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="false" Enabled="false" data-placeholder="Select Department" CssClass="form-control select2" TabIndex="23"></asp:DropDownList>


                        </div>
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Designation
                            </label>
                            <asp:DropDownList ID="ddldesign" runat="server" AutoPostBack="false" Enabled="false" data-placeholder="Select Designation" CssClass="form-control select2" TabIndex="24"></asp:DropDownList>

                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                Email Id
                            </label>
                            <asp:TextBox ID="txtemail" class="form-control" TabIndex="7" runat="server"></asp:TextBox>

                        </div>
                        <div class="col-md-6 form-group">
                            <label>Source<span class="required">* </span></label>


                            <div class="input-group">
                                <asp:DropDownList ID="dpsource" runat="server" AutoPostBack="false" data-placeholder="Select Source" CssClass="form-control select2" TabIndex="8"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                            </div>


                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                MobileNo:<span class="required">* </span>
                            </label>
                            <asp:TextBox ID="txtmobileno" class="form-control" TabIndex="9"  runat="server"></asp:TextBox>
                          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtaddress"
                                Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" ValidationGroup="Emst" SetFocusOnError="true" ForeColor="Red"
                                CssClass="validate"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                               MobileNo(2)
                            </label>
                            <asp:TextBox ID="txtmobileno2" class="form-control" TabIndex="10"  runat="server"></asp:TextBox>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label class="control-label">
                                 Remarks
                            </label>
                            <asp:TextBox ID="txtremarks" class="form-control" TabIndex="10" TextMode="MultiLine" runat="server"></asp:TextBox>

                        </div>
                        </div>
              <hr style="height:3px"/>
                <div class="row">
                     <div class="col-md-4 form-group">
                            <label class="control-label">Select Customer Type <span class="required">* </span></label>
                            
                                 <asp:DropDownList ID="DropDownListID" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="DropDownListID_SelectedIndexChanged">
                                     <asp:ListItem Text= "Indian Client" Value="1" />
                                     <asp:ListItem Text= "Foreign Client" Value="2" />
                                </asp:DropDownList> 
                            
                        </div>
                            <div class="col-md-4 "  >
                                <label style="align-content: center">
                                    Select Currency <span class="required">* </span>
                                </label>
                         
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged" data-placeholder="Select Currency" CssClass="form-control select2" TabIndex="4"></asp:DropDownList>
                                  <span class="input-group-btn">
                                  <asp:HyperLink ID="HyperLink1" runat="server" href="Country.aspx" Target="_blank" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                                        <asp:LinkButton ID="LinkButton10" runat="server" OnClick="RefreshCurrency" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                                      
                                </div>

                            </div>
                            <div class="col-md-4 " >
                                  <label style="align-content: center">
                                    Currency Rate <span class="required">* </span>
                                </label>
                             
                                <asp:TextBox ID="txtcurrency" runat="server"   ClientIDMode="Static" class="form-control"></asp:TextBox>
                                  
                            </div> 
                              
                            

                        </div>
                    </div>
                <div class="box-body">
                    <div class="box box-primary" >
                        <div class="row"  style="margin-top:10px">

                            <div class="col-md-4 form-group">
                                <label>Select Product <span class="required">* </span></label>


                                <div class="input-group">
                                    <asp:DropDownList ID="dpitem" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpitem_SelectedIndexChanged" data-placeholder="Select Product" CssClass="form-control select2" TabIndex="4"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:HyperLink ID="AddItmBtn" runat="server" href="Item.aspx" Target="_blank" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                                       <asp:LinkButton ID="AddItmBtnRefresh" runat="server" OnClick="RefreshItmdataGroup" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                               </div>

                            </div>
                            <div class="col-md-4 form-group">
                                <label>Select Principal <span class="required">* </span></label>


                                <div class="input-group">
                                    <asp:DropDownList ID="dpprincipal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpprincipal_SelectedIndexChanged" data-placeholder="Select Product" CssClass="form-control select2" TabIndex="4"></asp:DropDownList>
                                    <span class="input-group-btn">
                                         <asp:HyperLink ID="AssignPrincipleBtn" runat="server" href="AssignProduct.aspx" Target="_blank" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                                       <asp:LinkButton ID="PrincipleRefresh" runat="server" OnClick="RefreshPrincipaldata" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                                       
                                </div>
                            </div>
                            <div class="col-md-4 form-group">
                                <label>Select Supplier <span class="required">* </span></label>


                                <div class="input-group">
                                    <asp:DropDownList ID="dpsuppliers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dpsuppliers_SelectedIndexChanged" data-placeholder="Select Product" CssClass="form-control select2" TabIndex="4"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:HyperLink ID="AssignSupplierBtn" runat="server" href="AssignProduct.aspx" Target="_blank" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                                       <asp:LinkButton ID="SupplierRefresh" runat="server" OnClick="RefreshPrincipaldata" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                                      
                                </div>
                            </div>

                        </div>
                        <div class="row" >
                            <div class="col-md-3 form-group">
                                <label>UOM <span class="required">* </span></label>


                                <div class="input-group">
                                    <asp:DropDownList ID="dpuom" runat="server" AutoPostBack="true" data-placeholder="Select UOM" CssClass="form-control select2" TabIndex="4"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="LinkButton12" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                                </div>
                            </div>
                            <div class="col-md-2 form-group">
                                <label class="control-label">
                                    Qty:
                                </label>
                                <asp:TextBox ID="txtqty" ClientIDMode="Static" onkeyup="tSpeedValue(this)" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                                <%--OnTextChanged="txtqty_TextChanged" --%>
                            </div>
                            <div class="col-md-2 form-group">
                                <label class="control-label">
                                    Rate:
                                </label>
                                <asp:TextBox ID="txtrate"  ClientIDMode="Static" class="form-control" TabIndex="2" runat="server"></asp:TextBox>

                            </div>

                            <div class="col-md-2 form-group">
                                <label class="control-label">
                                    Amount:
                                </label>
                                <asp:TextBox ID="txtamount" ClientIDMode="Static" class="form-control" TabIndex="2" runat="server"></asp:TextBox>

                            </div>


                            <div class="col-md-3 form-group" style="margin-top: 25px; text-align: left">

                                <asp:LinkButton ID="btnaddproduct" runat="server" TabIndex="35" OnClick="btnaddproduct_Click" Enabled="true" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Add Product</asp:LinkButton>
                                <asp:LinkButton ID="lbtnupdatecontact" Visible="false" runat="server" OnClick="lbtnupdatecontact_Click" TabIndex="28" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                <asp:LinkButton ID="lbtnresetcontact" runat="server" TabIndex="29" OnClick="lbtnresetcontact_Click"  CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>

                            </div>
                        </div>

                        <div class="row">

                            <div class="box-body">
                                <asp:GridView ID="grdproduct" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                    AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdproduct_RowCommand" ShowHeaderWhenEmpty="true"
                                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                    CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" OnRowDataBound="grdproduct_RowDataBound"   DataKeyNames="Noseries" HeaderStyle-ForeColor="White">
                                    <AlternatingRowStyle BackColor="White" />
                                    <PagerStyle CssClass="csspager" />
                                    <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                    <Columns>
                                           <asp:TemplateField>
                                            <ItemTemplate>
                                                <img alt="" style="cursor: pointer" src="images/plus.png" />
                                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                                                                        <asp:GridView ID="BOMGrid" runat="server" AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" ShowHeaderWhenEmpty="true"
                                                        CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" OnRowCommand="BOMGrid_RowCommand"

                                                        CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                                        <Columns>
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="DocuName" HeaderText="Document Name" />
                                                            <asp:BoundField ItemStyle-Width="150px" DataField="Filename" HeaderText="File Name" />
                                                             <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Delete Broucher">
                                                                <ItemTemplate>

                                                                   
                                                                        <asp:ImageButton ID="btnedit" ImageUrl="images/delete.png" ToolTip="Click here to Delete"
                                                                            runat="server" CssClass="imgbtnalign1"  CommandArgument='<%# Eval("Id") %>'
                                                                        CommandName="deleteBroucher" CausesValidation="False" OnClientClick="return confirm('Do You Want to Delete?')"/>
                                                                  


                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                            </asp:TemplateField>

                                                        </Columns>

                                                    </asp:GridView>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ItemName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Principal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSupplier" runat="server" Text='<%# Eval("Principal") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Supplier">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrincipal" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UOM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUOM" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" Text='<%# Eval("Rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Edit" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ImageUrl="images/viewIcon.png" ToolTip="Click here to update"
                                                    runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Noseries") %>'
                                                    CommandName="editdata" CausesValidation="False" />
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
                                                    CommandName="deletedata" CausesValidation="False" OnClientClick="return confirm('Do You Want to Delete?')" />

                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle HorizontalAlign="Center"></EditRowStyle>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>









<%--<div class="box-body">
                    <div class="box box-primary">
                        <div class="row" style="margin-top:10px">

                            <div class="col-md-3 form-group">
                                <label>Select Country<span class="required">* </span></label>


                                <div class="input-group">
                                    <asp:DropDownList ID = "dpCountry" runat="server" AutoPostBack="false" data-placeholder="Select Country" CssClass="form-control select2" TabIndex="5"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID = "lbtnCountry" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                                </div>


                            </div>
                             <div class="col-md-3 form-group">
                                <label>TAX Name<span class="required">* </span></label>

                                <asp:TextBox ID = "TextBox2" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
              </div>
                             <div class="col-md-2 form-group">
                                <label>TAX Percentage<span class="required">* </span></label>

                                <asp:TextBox ID = "TextBox3"  class="form-control" TabIndex="2" runat="server"></asp:TextBox>
              </div>
                            <div class="col-md-1     form-group">
                                
              </div>

                            
                            <div class="col-md-3 form-group" style="margin-top: 25px">

                     <asp:LinkButton ID = "LinkButton16" runat="server" TabIndex="35" OnClick="btnaddTaxation_Click"  CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp; Add Taxation</asp:LinkButton>
                         

                                <asp:LinkButton ID = "LinkButton9" Visible= "false" runat= "server"  TabIndex= "28" OnClick= "lbtnupdateTaxation_Click" CssClass= "btn btn-bitbucket btn-flat" ><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                <asp:LinkButton ID = "LinkButton10" runat="server" TabIndex="29" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
                            </div>
                            
                            </div>
</div>
                <div class="row">

                            <div class="box-body">
                                <asp:GridView ID="grdviewTaxation" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                    AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdTaxation_RowCommand" ShowHeaderWhenEmpty="true"
                                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                    CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                    <AlternatingRowStyle BackColor="White" />
                                    <PagerStyle CssClass="csspager" />
                                    <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Country">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Expr1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tax Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTaxName" runat="server" Text='<%# Eval("TaxName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="TAX Percentage">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTAXXPercentage" runat="server" Text='<%# Eval("TAXPercentage") %>'></asp:Label>
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
                        </div>--%>















                <div class="box-body">
                    <div class="box box-primary">
                        <div class="row"  style="margin-top:10px">

                            <div class="col-md-3 form-group">
                                <label class="control-label">
                                    Next Followup Date
                                </label>
                                <asp:TextBox ID="txtfdate" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfdate" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                            </div>
                            <div class="col-md-2 form-group">
                                <label>Followup Type<span class="required">* </span></label>


                                <div class="input-group">
                                    <asp:DropDownList ID="dpfollowuptype" runat="server" AutoPostBack="false" data-placeholder="Select Conatct Person" CssClass="form-control select2" TabIndex="5"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="LinkButton5" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                                </div>


                            </div>

                            <div class="col-md-3 form-group">
                                <label>Assign To<span class="required">* </span></label>


                                <div class="input-group">
                                    <asp:DropDownList ID="dpassignto" runat="server" AutoPostBack="false" data-placeholder="Select Employee Name" CssClass="form-control select2" TabIndex="5"></asp:DropDownList>
                                    <span class="input-group-btn">
                                         <asp:HyperLink ID="AddEmployee" runat="server" href="Distributor.aspx" Target="_blank" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                                       <asp:LinkButton ID="RefreshEmployee" runat="server" OnClick="RefreshAssignTo" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                                        
                                </div>


                            </div>

                            <div class="col-md-3 form-group">
                                <label>Status<span class="required">* </span></label>


                                   <div class="input-group">
                                    <asp:DropDownList ID="dpfollowstatus"   runat="server" AutoPostBack="false" data-placeholder="Select Conatct Person" CssClass="form-control select2" TabIndex="5"></asp:DropDownList>
                                    <span class="input-group-btn">

                                        <asp:LinkButton ID="LinkButton8" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                                </div>
                                </div>

                          

                        </div>


                        <div class="row">
                            <div class="col-md-9 form-group">
                                <label class="control-label">
                                    Remarks:<span class="required">* </span>
                                </label>
                                <asp:TextBox ID="txtfremarks" class="form-control" TabIndex="9" TextMode="MultiLine" runat="server"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfremarks"
                                    Display="Dynamic" ErrorMessage="Please Enter remarks" Text="(*) Required" ValidationGroup="Emst" SetFocusOnError="true" ForeColor="Red"
                                    CssClass="validate"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-md-3 form-group" style="margin-top: 25px; text-align: left">

                              <asp:LinkButton ID="lbtnaddfollowup" runat="server" OnClick="lbtnaddfollowup_Click" TabIndex="36" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Add Followup</asp:LinkButton>
                                <asp:LinkButton ID="lbtnupdatefollowup" Visible="false" OnClick="lbtnupdatefollowup_Click" runat="server" TabIndex="37" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update Followup</asp:LinkButton>
                                <asp:LinkButton ID="lbtnresetfollowup" OnClick="lbtnresetfollowup_Click" runat="server" TabIndex="38" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>



                            </div>
                        </div>

                        <div class="row">

                            <div class="box-body">
                                <asp:GridView ID="grdfollowup" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                    AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdfollowup_RowCommand" ShowHeaderWhenEmpty="true"
                                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                    CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                    <AlternatingRowStyle BackColor="White" />
                                    <PagerStyle CssClass="csspager" />
                                    <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="NextFolldate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNextFolldate" runat="server" Text='<%# Eval("NextFolldate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Followup Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFollowupName" runat="server" Text='<%# Eval("FollowupName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Assign To">
                                            <ItemTemplate>
                                                <asp:Label ID="lblassignto" runat="server" Text='<%# Eval("Ename") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusName" runat="server" Text='<%# Eval("StatusName") %>'></asp:Label>
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
                    </div>










                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
<ContentTemplate>
 <asp:Button ID="FakeTarget2" runat="server" Text="FakeTarget2" style="display:none"/>

    
<asp:ModalPopupExtender ID="mpterms" runat="server" PopupControlID="pnlterms" TargetControlID="FakeTarget2"
            CancelControlID="btncloseTerms" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
              <asp:Panel ID="pnlterms" runat="server" Style="display:none" CssClass="example2-modal">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">

<ContentTemplate>
    


            <div style="height: 20px">
                <div class="example2-modal">
                    <div class="modal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btncloseTerms" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Edit Terms and Conditions</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Title<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txttitle" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txttitle"
                                                            Display="Dynamic" ErrorMessage="Please Enter Status" ValidationGroup="statusgrp" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <asp:Label  class="control-label" ID="Label4" runat="server" Text=" " Width="500px" ForeColor="Red"></asp:Label> 
                                                    <asp:TextBox ID="Txttandc" runat="server" Height="500px" Width="90%" BorderStyle="Double" ></asp:TextBox>
                         <asp:HtmlEditorExtender ID="HtmlEditorExtender1" TargetControlID="Txttandc" EnableSanitization="false" runat="server"  ></asp:HtmlEditorExtender>
                                                    <div class="form-group pull-right" style="padding-top:15px">
                                                        <asp:LinkButton ID="LinkButton11"  ValidationGroup="statusgrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton17" OnClick="lbtndesignreset_Click" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
    </ContentTemplate>

</asp:UpdatePanel>
           
        </asp:Panel>


    </ContentTemplate>

</asp:UpdatePanel>--%>


 <div class="box box-primary" style="display:inline">
                            <div class="box-body margin">
                                 <div class="row" >
                            <div class="col-md-6 " style="align-content:center;font-size:20px">
                                <label  style="align-content:center">
                                    Select Terms & Conditions <span class="required">* </span>
                                </label>
                                </div>
                                      <div class="col-md-3 "></div>
                                    <div class="col-md-3 " style="align-content:center;font-size:20px; padding-left:60px" >
                                    <label> Refresh Terms</label>
                                <label  style="align-content:center">
                                     <asp:LinkButton ID="LinkButton11" runat="server"  OnClick="RefreshTermsdata" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton>
                                    </label>
                                    </div>

                                     </div>
                                <div class="col-md-12">

                                    <asp:GridView ID="grddata1" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                        AutoGenerateColumns="False" BorderWidth="1px" ShowHeaderWhenEmpty="true" OnRowDataBound="grddata1_RowDataBound" OnRowCommand="grdTerms_RowCommand" 
                                        CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" 
                                        CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                        <AlternatingRowStyle BackColor="White" />
                                        <PagerStyle CssClass="csspager" />
                                        <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                        <Columns>
                                             <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnedit" ImageUrl="images/viewIcon.png" ToolTip="Click here to Edit"
                                                    runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Id") %>'
                                                    CommandName="editterms" CausesValidation="False" />
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                             



                                            <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="btnchkbox"
                                                        runat="server" CommandArgument='<%# Eval("TermsId") %>'
                                                        CausesValidation="False" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             
                                            <asp:TemplateField Visible="false" HeaderText="id">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Eval("TermsId") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Title">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("Termstitle") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Description">

                                                <ItemTemplate>
                                                    <asp:Label ID="lbltandc" runat="server" Text='<%# Eval("TermsDescription") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" Visible="false" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Edit">
                                            <ItemTemplate>
                                              <asp:LinkButton ID="btneditterms" runat="server" ToolTip="Click here to Edit"
                                                    CssClass="imgbtnalign1" CommandArgument='<%# Eval("Id") %>'
                                                    CommandName="editdata" CausesValidation="False" ><img src="images/viewIcon.png" />
                                                  </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>--%>

                                        </Columns>
                                        <EditRowStyle HorizontalAlign="Center"></EditRowStyle>
                                    </asp:GridView>
                                  
                                </div>

                            </div>
                        </div>







              
               
                  </div>
                <div class="box-body">
                    <div class="box box-primary">


                        <div class="row">
                            <div class="col-md-12 form-group" style="padding-top: 5px; text-align: right">
                                <asp:LinkButton ID="btnUpdate" OnClick="btnSave_Click"  runat="server" TabIndex="37" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" TabIndex="38" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
                                <asp:LinkButton ID="btnSave"  runat="server"  ValidationGroup="Emst" TabIndex="36" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Delete</asp:LinkButton>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>
        





         <asp:ModalPopupExtender ID="mpstatus" runat="server" PopupControlID="pnlstatus" TargetControlID="LinkButton1"
            CancelControlID="btnclosestatus" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlstatus" runat="server" CssClass="modalPopup" align="center" Style="display:none">
            <div style="height: 60px">
                <div class="example-modal1">
                    <div class="modal">
                        <div class="modal-dialog1">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btnclosestatus" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create Status</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Status<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtstatus" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtstatus"
                                                            Display="Dynamic" ErrorMessage="Please Enter Status" ValidationGroup="statusgrp" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <asp:Label  class="control-label" ID="Label1" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
                                                   
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncStatus" OnClick="lbtncStatus_Click" ValidationGroup="statusgrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton13" OnClick="lbtndesignreset_Click" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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



         <asp:ModalPopupExtender ID="mpsource" runat="server" PopupControlID="pnlsource" TargetControlID="LinkButton3"
            CancelControlID="btnclosesource" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlsource" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div style="height: 60px">
                <div class="example-modal1">
                    <div class="modal">
                        <div class="modal-dialog1">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btnclosesource" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create Source</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Source<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtsource" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsource"
                                                            Display="Dynamic" ErrorMessage="Please Enter Source" ValidationGroup="sourcegrp" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <asp:Label  class="control-label" ID="Label2" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncSource" OnClick="lbtncSource_Click" ValidationGroup="sourcegrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton7" OnClick="lbtndesignreset_Click" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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


                 <asp:ModalPopupExtender ID="mpuom" runat="server" PopupControlID="pnluom" TargetControlID="LinkButton12"
            CancelControlID="btncloseuom" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnluom" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div style="height: 60px">
                <div class="example-modal1">
                    <div class="modal">
                        <div class="modal-dialog1">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btncloseuom" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create UOM</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            UOM<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtuom" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtuom"
                                                            Display="Dynamic" ErrorMessage="Please Enter Source" ValidationGroup="uomgrp" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <asp:Label  class="control-label" ID="Label3" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncUOM" OnClick="lbtncUOM_Click" ValidationGroup="txtuom" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton14" OnClick="lbtndesignreset_Click" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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






        











                         <asp:ModalPopupExtender ID="mpfollowup" runat="server" PopupControlID="pnlfollowup" TargetControlID="LinkButton5"
            CancelControlID="btnclosefollowup" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlfollowup" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div style="height: 60px">
                <div class="example-modal1">
                    <div class="modal">
                        <div class="modal-dialog1">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btnclosefollowup" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create Followup Type</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Type<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="mpTxtFollowup" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="mpTxtFollowup"
                                                            Display="Dynamic" ErrorMessage="Please Enter Status" ValidationGroup="mpTxtFollowup" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <asp:Label  class="control-label" ID="Label6" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
                                                   
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="LinkButton6" OnClick="lbtncFollowup_Click" ValidationGroup="stf" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton19" OnClick="lbtndesignreset_Click" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
            <asp:Button ID="Button5" runat="server" Text="Close" />
        </asp:Panel>












                 <asp:ModalPopupExtender ID="Status2" runat="server" PopupControlID="pnlstatus2" TargetControlID="LinkButton8"
            CancelControlID="btnclosestatus2" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlstatus2" runat="server" CssClass="modalPopup" align="center" style="left: 50% !important; top: 10% !important; display: none">
            <div style="height: 60px">
                <div class="example-modal1">
                    <div class="modal">
                        <div class="modal-dialog1">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btnclosestatus2" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create Status</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Status<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="TextBox1" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox1"
                                                            Display="Dynamic" ErrorMessage="Please Enter Status" ValidationGroup="statusgrp" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <asp:Label  class="control-label" ID="Label5" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
                                                   
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="LinkButton2" OnClick="lbtncStatus2_Click" ValidationGroup="st" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton4" OnClick="lbtndesignreset_Click" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
            <asp:Button ID="Button4" runat="server" Text="Close" />
        </asp:Panel>


           <%--             <asp:ModalPopupExtender ID="mpCountry" runat="server" PopupControlID="pnlCountry" TargetControlID="lbtnCountry"
            CancelControlID="btncloseCountry" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlCountry" runat="server" CssClass="modalPopup" align="center" Style="display:none">
            <div style="height: 60px">
                <div class="example-modal1">
                    <div class="modal">
                        <div class="modal-dialog1">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" id="btncloseCountry" aria-label="Close">
                                        <span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" style="text-align: center">Create Country</h4>

                                    <div class="modal-body">
                                        <div class="col-md-12">
                                            <div class="box box-primary">

                                                <div class="box-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            Country<span class="required">* </span>
                                                        </label>
                                                        <asp:TextBox ID="txtCountry" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCountry"
                                                            Display="Dynamic" ErrorMessage="Please Enter Status" ValidationGroup="statusgrp" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                                            CssClass="validate"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <asp:Label  class="control-label" ID="Label16" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label> 
                                                   
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncCountry" OnClick="lbtncCountry_Click" ValidationGroup="Countrygrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton15" OnClick="lbtndesignreset_Click" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
            <asp:Button ID="Button6" runat="server" Text="Close" />
        </asp:Panel>--%>
            






    </div>
<%--    <script type="text/javascript">

        Load();
        function Load() {
 $("#pnlterms").modal("hide");
        }
        function ShowPopup() {
            debugger;
        $("#pnlterms").modal("show");
    }
</script>--%>
     
</asp:Content>




