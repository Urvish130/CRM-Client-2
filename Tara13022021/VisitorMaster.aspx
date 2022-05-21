<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VisitorMaster.aspx.cs" Inherits="VisitorMaster" %>

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
            <h1>Visit Entry
                     <asp:Label class="control-label" ID="lblmsg" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Visit </a></li>
                <li class="active">Visit Entry</li>
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
                                <asp:DropDownList ID="dpcustgroup" runat="server" AutoPostBack="true" data-placeholder="Select Customer Group" CssClass="form-control select2" TabIndex="3"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:HyperLink ID="Custgroupbtn" Target="_blank" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                                    <asp:LinkButton ID="lbtncustgroup" runat="server" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                            </div>


                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label>Name of Customer <span class="required">* </span></label>


                            <div class="input-group">
                                <asp:DropDownList ID="dpcust" runat="server" AutoPostBack="true" data-placeholder="Select Customer" CssClass="form-control select2" TabIndex="3"></asp:DropDownList>
                                <span class="input-group-btn">
                                    <asp:HyperLink ID="Custbtn" runat="server" href="CustomerMaster.aspx" Target="_blank" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:HyperLink>
                                    <asp:LinkButton ID="lbtncust" runat="server" CssClass="btn btn-success btn-flat" CausesValidation="false"><i class="fa fa-refresh"></i></asp:LinkButton></span>
                            </div>


                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-4 form-group">
                            <label class="control-label">
                                Contact Person<span class="required">*</span>
                            </label>
                            <asp:TextBox ID="txtcontactname" CssClass="form-control" TabIndex="18" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcontactname"
                                Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" SetFocusOnError="true" ValidationGroup="comgcontactroup" ForeColor="Red"
                                CssClass="validate"></asp:RequiredFieldValidator>


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
                    </div>



                    <div class="row">
                        <div class="col-md-4">
                            <asp:CheckBox ID="CheckBox" onclick="ShowHideDiv(this)" Text="Tour Advance" class="checkbox-inline" TabIndex="2" runat="server"></asp:CheckBox>

                        </div>
                    </div>
                    <div id="Tourdata" style="display: none;margin-top:10px" >
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    From Date:
                                </label>
                                <asp:TextBox ID="TextBox1" placeholder="dd/mm/yyyy" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="TextBox1" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                            </div>
                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    To Date:
                                </label>
                                <asp:TextBox ID="TextBox2" placeholder="dd/mm/yyyy" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="TextBox2" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-md-12 form-group">
                                <label class="control-label">
                                    Purpose<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="Remarks" placeholder="Enter Purpose" class="form-control" TextMode="MultiLine" TabIndex="6" runat="server"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                </div>



                <div class="box-body">
                    <div class="box box-primary">


                        <div class="row" style="margin-top: 10px; margin-right: 10px">
                            <div class="col-md-12 form-group" style="padding-top: 5px; text-align: right">
                                <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="Emst" TabIndex="36" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                <asp:LinkButton ID="btnUpdate" Visible="false" runat="server" TabIndex="37" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" TabIndex="38" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>


        <script type="text/javascript">

            function ShowHideDiv(CheckBox) {
                debugger;
                var dvPassport = document.getElementById("Tourdata");
                dvPassport.style.display = CheckBox.checked ? "block" : "none";
            }
        </script>














































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



