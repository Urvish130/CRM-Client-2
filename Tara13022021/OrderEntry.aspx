<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderEntry.aspx.cs" Inherits="OrderEntry" %>

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
            var amount = qty * rate;
            txtamount.value = amount;



        }
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

        .unselectable ajax__html_editor_extender_container {
            height: 288px;
            width: auto !important;
        }

        .modal-dialog {
            width: 1000px;
            margin: 30px auto;
        }

        .unselectable ajax__html_editor_extender_container {
            height: auto;
            width: auto !important;
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
        .reveal-modal {
            background: #e1e1e1;
            visibility: hidden;
            display: none;
            top: 100px;
            left: 50%;
            width: 820px;
            position: absolute;
            z-index: 41;
            padding: 30px;
            -webkit-box-shadow: 0 0 10px rgba(0,0,0,0.4);
            -moz-box-shadow: 0 0 10px rgba(0,0,0,0.4);
            box-shadow: 0 0 10px rgba(0,0,0,0.4)
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
            <h1>Order Entry
                     <asp:Label class="control-label" ID="lblmsg" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Inquiry</a></li>
                <li class="active">Inquiry Entry</li>
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
                                    <asp:LinkButton ID="lbtncust" runat="server" OnClick="RefreshCustGroup" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                            </div>


                        </div>
                        <div class="col-md-6 form-group">
                            <label>Status <span class="required">* </span></label>


                            <div class="input-group">
                                <asp:DropDownList ID="dpstatus" runat="server" AutoPostBack="false" data-placeholder="Select Customer" CssClass="form-control select2" TabIndex="4"></asp:DropDownList>
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
                            <asp:TextBox ID="txtmobileno" class="form-control" TabIndex="9" runat="server"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtaddress"
                                Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" ValidationGroup="Emst" SetFocusOnError="true" ForeColor="Red"
                                CssClass="validate"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-md-6 form-group">
                            <label class="control-label">
                                MobileNo(2)
                            </label>
                            <asp:TextBox ID="txtmobileno2" class="form-control" TabIndex="10" runat="server"></asp:TextBox>

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
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label class="control-label">Extra Discount (%)</label>
                            <asp:TextBox ID="txtextradisc" class="form-control" TabIndex="28" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-4 form-group">
                            <label class="control-label">Freight Amount</label>
                            <asp:TextBox ID="txtfreight" class="form-control" TabIndex="32" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4 form-group">
                            <label class="control-label">Load Charge</label>
                            <asp:TextBox ID="txtload" class="form-control" TabIndex="33" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="box-body">
                    <div class="box box-primary">
                        <div class="row" style="margin-top: 10px">

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
                        <div class="row">
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

                            </div>
                            <div class="col-md-2 form-group">
                                <label class="control-label">
                                    Rate:
                                </label>
                                <asp:TextBox ID="txtrate" ReadOnly="true" ClientIDMode="Static" class="form-control" TabIndex="2" runat="server"></asp:TextBox>

                            </div>

                            <div class="col-md-2 form-group">
                                <label class="control-label">
                                    Amount:
                                </label>
                                <asp:TextBox ID="txtamount" ClientIDMode="Static" class="form-control" TabIndex="2" runat="server"></asp:TextBox>

                            </div>


                            <div class="col-md-3 form-group" style="margin-top: 25px; text-align: left">

                                <asp:LinkButton ID="btnaddproduct" runat="server" TabIndex="35" OnClick="btnaddproduct_Click" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Add Product</asp:LinkButton>
                                <asp:LinkButton ID="lbtnupdatecontact" Visible="false" runat="server" OnClick="lbtnupdatecontact_Click" TabIndex="28" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                <asp:LinkButton ID="lbtnresetcontact" runat="server" TabIndex="29" OnClick="lbtnresetcontact_Click" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>

                            </div>
                        </div>

                        <div class="row">

                            <div class="box-body">
                                <asp:GridView ID="grdproduct" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                    AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdproduct_RowCommand" ShowHeaderWhenEmpty="true"
                                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                    CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                    <AlternatingRowStyle BackColor="White" />
                                    <PagerStyle CssClass="csspager" />
                                    <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="ItemName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Supplier">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSupplier" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Principal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrincipal" runat="server" Text='<%# Eval("Principal") %>'></asp:Label>
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
                </div>



                <%--<div class="box-body">
                    <div class="box box-primary">
                        <div class="row" style="margin-top: 10px">


                            <div class="col-md-3 form-group">
                                <label>Advance<span class="required">* </span></label>

                                <asp:TextBox ID="TextBox2" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <label>Balance 1<span class="required">* </span></label>

                                <asp:TextBox ID="TextBox3" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <label>Balance 2<span class="required">* </span></label>

                                <asp:TextBox ID="TextBox4" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <label>Balance 3<span class="required">* </span></label>

                                <asp:TextBox ID="TextBox5" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 form-group">
                                <label class="control-label">
                                    Remarks:<span class="required">* </span>
                                </label>
                                <asp:TextBox ID="TextBox6" class="form-control" TabIndex="9" TextMode="MultiLine" runat="server"></asp:TextBox>


                            </div>
                        </div>

                    </div>
                </div>--%>



                <div class="box-body">
                    <div class="box box-primary">
                        <div class="row" style="margin-top: 10px">
                            <div class="col-md-3 form-group">
                                <label class="control-label">Terms Name</label>
                                <asp:TextBox ID="txtTermsName" placeholder="Terms Name" class="form-control" TabIndex="28" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-3 form-group">
                                <label class="control-label">Date</label>
                                <asp:TextBox ID="txtdat1" class="form-control" placeholder="dd/MM/yyyy" TabIndex="32" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtdat1" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                            </div>
                            <div class="col-md-3 form-group">
                                <label class="control-label">
                                    Remarks:<span class="required">* </span>
                                </label>
                                <asp:TextBox ID="txtfremarks" placeholder="Remarks" class="form-control" TabIndex="9" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfremarks"
                                    Display="Dynamic" ErrorMessage="Please Enter remarks" Text="(*) Required" ValidationGroup="Emst" SetFocusOnError="true" ForeColor="Red"
                                    CssClass="validate"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-md-3 form-group" style="margin-top: 25px; text-align: left">

                                <asp:LinkButton ID="lbtnaddfollowup" runat="server" TabIndex="36" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Add Payment</asp:LinkButton>
                                <asp:LinkButton ID="lbtnupdatefollowup" Visible="false" runat="server" TabIndex="37" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update Followup</asp:LinkButton>
                                <asp:LinkButton ID="lbtnresetfollowup" runat="server" TabIndex="38" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>



                            </div>
                        </div>







                    </div>



















                </div>
                <div class="box-body">
                    <div class="box box-primary">

                        <div class="row" style="margin-top: 10px">
                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    Expected Date for Delivery:
                                </label>
                                <asp:TextBox ID="TextBox1" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="TextBox1" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                            </div>
                            <div class="col-md-4 form-group">
                                <label class="control-label">Work Progress</label>
                                <asp:TextBox ID="TextBox10" placeholder="Work Progress" class="form-control" TabIndex="28" runat="server"></asp:TextBox>
                            </div>
                          <div class="col-md-4 form-group" style="margin-top:25px; text-align: left">

                                <asp:LinkButton ID="LinkButton2" runat="server" TabIndex="36" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Add</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" Visible="false" runat="server" TabIndex="37" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update Followup</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton5" runat="server" TabIndex="38" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>



                            </div>

                        </div>
                    </div>
                </div>
                <div class="box-body">
                    <div class="box box-primary">


                        <div class="row" style="margin-top: 10px; margin-right: 10px">
                            <div class="col-md-12 form-group" style="padding-top: 5px; text-align: right">
                                <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" ValidationGroup="Emst" TabIndex="36" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                <asp:LinkButton ID="btnUpdate" Visible="false" runat="server" TabIndex="37" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" TabIndex="38" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>






        <asp:ModalPopupExtender ID="mpstatus" runat="server" PopupControlID="pnlstatus" TargetControlID="LinkButton1"
            CancelControlID="btnclosestatus" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlstatus" runat="server" CssClass="modalPopup" align="center" Style="display: none">
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
                                                    <asp:Label class="control-label" ID="Label1" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label>

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
                                                    <asp:Label class="control-label" ID="Label2" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label>
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
                                                    <asp:Label class="control-label" ID="Label3" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label>
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



