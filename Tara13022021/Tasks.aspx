<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tasks.aspx.cs" Inherits="Tasks" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>
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
            width: 60%;
            height: auto;
            z-index: 100 !important;
        }

            .modalPopup2 .heading {
                background-color: white;
                /*height: 30px;*/
                /*color: red;*/
                /*line-height: 30px;*/
                text-align: center;
                font-weight: bold;
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
    </style>
    <link href="https://code.jquery.com/ui/1.12.0/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-3.1.0.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script>
        var eventsFired = 0;
        $(document).ready(function () {
            $("#txtDate").val($.datepicker.formatDate("dd/mm/yy", new Date()));
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
            <h1>Task Entry</h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="userregister.aspx">Tasks</a></li>
                <li class="active">Task Entry</li>
                <asp:Label ID="lblcomno" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblrole" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lbleror" runat="server" Visible="false" Text=""></asp:Label>
            </ol>
        </section>
        <asp:HiddenField ID="hfID" runat="server" />
        <asp:HiddenField ID="hfUserName" runat="server" />
        <asp:HiddenField ID="hfUserType" runat="server" />
        <asp:HiddenField ID="Create" runat="server" />
        <asp:HiddenField ID="View" runat="server" />
        <asp:HiddenField ID="Edit" runat="server" />
        <asp:HiddenField ID="Delete" runat="server" />
        <asp:HiddenField ID="hfamc" runat="server" />
        <asp:HiddenField ID="hfwarranty" runat="server" />
        <section class="content">
            <div class="box box-primary">
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <u>
                                    <h3 style="text-align: center; margin-bottom: 10px; width: 100%">Task Details</h3>
                                </u>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-md-2">
                                        <label class="control-label">Entry No:<span class="required">* </span></label>
                                        <br />
                                        <asp:TextBox ID="txtNo" runat="server" CssClass="form-control" Enabled="false" TabIndex="1" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-md-7">
                                    </div>
                                    <div class="col-md-3">
                                        <label class="control-label">Date:<span class="required">* </span></label>
                                        <asp:TextBox ID="txtDate" ClientIDMode="Static" runat="server" Enabled="false" CssClass="form-control" placeholder="Enter Date" TabIndex="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="(*) Required" ControlToValidate="txtDate" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div style="margin-top: 10px;"></div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">Task Detail</h3>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-md-12">
                                                        <asp:TextBox ID="txtWkDetails" runat="server" CssClass="form-control" TextMode="MultiLine" ValidationGroup="vgMain" Height="200px" TabIndex="3"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvwork" runat="server" ErrorMessage="(*) Required" ControlToValidate="txtWkDetails" ValidationGroup="vgMain" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="panel panel-primary">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">Attachment</h3>
                                        </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="form-group">
                                                    <div class="col-md-12">
                                                        <label class="control-label">Description</label>
                                                        <asp:TextBox ID="txtDescrip" runat="server" CssClass="form-control" onkeyup="myFunction(this.id)" TextMode="MultiLine" TabIndex="4"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-7" style="margin-top: 10px;">
                                                        <asp:FileUpload ID="fileAttach" runat="server" TabIndex="5" />
                                                    </div>
                                                    <div class="col-md-5" style="margin-top: 10px;">
                               <%-- OnClick="btnAdd_Click"   --%>                      <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary icon-btn" TabIndex="6" CausesValidation="false" OnClientClick="showProgress()" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="margin-top: 10px;"></div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:HiddenField ID="hfFileId" runat="server" />
                                                    <asp:HiddenField ID="hfFileName" runat="server" />
                                                    <asp:HiddenField ID="hfFilePath" runat="server" />
                        <%--        OnRowCommand="grdDoc_RowCommand"   --%>                 <asp:GridView ID="grdDoc" runat="server" AllowPaging="True" AllowSorting="false" AutoGenerateColumns="False"
                                                        CssClass="table table-bordered dataTable no-footer" CellPadding="3" EditRowStyle-HorizontalAlign="Center" PageSize="7"
                                                        GridLines="None" BackColor="White" BorderColor="White" BorderStyle="Ridge" ShowHeaderWhenEmpty="true" 
                                                        BorderWidth="2px" CellSpacing="1" DataKeyNames="FilePath">
                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                        <HeaderStyle BackColor="#009688" Font-Bold="True" ForeColor="#FFFFFF" />
                                                        <PagerStyle CssClass="csspager" BackColor="#009688" ForeColor="White" HorizontalAlign="Left" Font-Size="large" />
                                                        <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Description">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDescrip" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Download">
                                                                <ItemTemplate>
                                                  <%-- OnClick="lnkDownload_Click" --%>                <asp:LinkButton ID="lnkDownload" runat="server" Text='<%# Eval("FileName") %>'  ForeColor="#673ab7" CausesValidation="false"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="lblenid" HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnedit" ImageUrl="~/images/viewIcon.png" ToolTip="Click here to Edit File Attachment"
                                                                        runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("ID") %>'
                                                                        CommandName="editdata" CausesValidation="False" />
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="lblenid" HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnDelete" ImageUrl="~/images/delete.png" ToolTip="Click here to delete File Attachment"
                                                                        runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("ID") %>'
                                                                        CommandName="deletedata" CausesValidation="False" />
                                                                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" ConfirmText="Do you Want to Delete?" runat="server" TargetControlID="btnDelete"></asp:ConfirmButtonExtender>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                                <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 5px;">
                                <div class="col-md-4">
                                    <label class="control-label">Task Date:<span class="required">* </span></label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txttaskdate" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Task Date" TabIndex="7" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask></asp:TextBox>
                                        <span class="input-group-addon"><i id="txttaskdate" class="fa fa-calendar"></i></span>
                                        <asp:CalendarExtender ID="CalendarExtender5" PopupButtonID="txtdudt" runat="server" TargetControlID="txttaskdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="txttaskdate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="Invalid date format." ForeColor="Red" SetFocusOnError="true" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="rftxttask" runat="server" ErrorMessage="(*) Required" ControlToValidate="txttaskdate" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label class="control-label">Due Date:<span class="required">* </span></label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtduedate" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Due Date" TabIndex="7" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask></asp:TextBox>
                                        <span class="input-group-addon"><i id="txtdudt" class="fa fa-calendar"></i></span>
                                        <asp:CalendarExtender ID="CalendarExtender4" PopupButtonID="txtdudt" runat="server" TargetControlID="txtduedate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                        <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="txtduedate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                            ErrorMessage="Invalid date format." ForeColor="Red" SetFocusOnError="true" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="rftxtdue" runat="server" ErrorMessage="(*) Required" ControlToValidate="txtduedate" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label class="control-label">Assign To:<span class="required">* </span></label>
                                    <asp:DropDownList ID="ddlassignto" runat="server" CssClass="form-control select2" ValidationGroup="vgMain" TabIndex="9"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvassign" runat="server" ErrorMessage="(*) Required" ValidationGroup="vgMain" InitialValue="NA" SetFocusOnError="true" ControlToValidate="ddlassignto" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row" style="margin-top: 5px;">
                                <div class="col-md-4">
                                    <label class="control-label">Assign By Status:<span class="required">* </span></label>
                                    <asp:DropDownList ID="abstatus" runat="server" CssClass="form-control select2" TabIndex="10"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfabstatus" runat="server" ErrorMessage="(*) Required" InitialValue="NA" SetFocusOnError="true" ControlToValidate="abstatus" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label class="control-label">Assign To Status:</label>
                                    <asp:DropDownList ID="atstatus" runat="server" CssClass="form-control select2" TabIndex="11"></asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="rfatstatus" runat="server" ErrorMessage="(*) Required" ControlToValidate="atstatus" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-md-4" runat="server" visible="false">
                                    <label class="control-label">Assign by:<span class="required">* </span></label>
                                    <asp:TextBox ID="txtloginname" runat="server" Enabled="false" CssClass="form-control" onkeyup="myFunction(this.id)" TabIndex="12"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="box-footer">
                <div class="row">
                    <div class="col-md-12" style="text-align: right;">
              <%--OnClick="btnsave_Click"--%>           <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn btn-primary icon-btn" TabIndex="13" OnClientClick="showProgress()" />
          <%--OnClick="btncancel_Click"--%>              <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-default icon-btn"  CausesValidation="false" TabIndex="14" />
                    </div>
                </div>
            </div>
            <div class="box box-primary" style="margin-top: 2%">
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="row">
                                    <u>
                                        <h3 style="text-align: center; margin-bottom: 2%; width: 100%">Task Register</h3>
                                    </u>
                                </div>
                                <div class="row" style="margin-top: 5px;" runat="server" visible="false">
                                    <div class="col-md-3">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtfromdate" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="from date" TabIndex="22" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask></asp:TextBox>
                                            <span class="input-group-addon"><i id="fdate" class="fa fa-calendar"></i></span>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="fdate" TargetControlID="txtfromdate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="txtfromdate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                                ErrorMessage="Invalid date format." ForeColor="Red" SetFocusOnError="true" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="input-group">
                                            <asp:TextBox ID="txttodate" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="from date" TabIndex="23" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask></asp:TextBox>
                                            <span class="input-group-addon"><i id="tdate" class="fa fa-calendar"></i></span>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="tdate" TargetControlID="txttodate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="txttodate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$"
                                                ErrorMessage="Invalid date format." ForeColor="Red" SetFocusOnError="true" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddFltWkType" runat="server" CssClass="form-control select2" ValidationGroup="vgMain" TabIndex="24"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlAssign" runat="server" CssClass="form-control select2" ValidationGroup="vgFlp" data-placeholder="Select Assign By" TabIndex="25"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 10px;" runat="server" visible="false">
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlFltassignto" runat="server" CssClass="form-control select2" ValidationGroup="vgMain" TabIndex="26"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="dpassbystatus" runat="server" CssClass="form-control select2" ValidationGroup="vgMain" TabIndex="27"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="dpasstostatus" runat="server" CssClass="form-control select2" ValidationGroup="vgMain" TabIndex="28"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlparty" runat="server" CssClass="form-control select2" ValidationGroup="vgMain" TabIndex="29"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row" runat="server" style="margin-top: 10px" visible="false">
                                    <div class="col-md-12" style="text-align: right;">
   <%--     OnClick="btnFilter_Click"   --%>                             <asp:LinkButton ID="btnFilter" runat="server" TabIndex="30" CssClass="btn btn-primary icon-btn" CausesValidation="false"  OnClientClick="showProgress()"><i class="fa fa-filter"></i>Filter</asp:LinkButton>
<%--  OnClick="btnAllData_Click"  --%>                                    <asp:LinkButton ID="btnAllData" runat="server" TabIndex="31" CssClass="btn btn-primary icon-btn"  CausesValidation="false" OnClientClick="showProgress()"><i class="fa fa-refresh"></i>All</asp:LinkButton>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 1%">
                                    <div class="col-md-12">
                                        <div class="table-responsive" style="border: 0px">
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <asp:HiddenField ID="hfAttachment" runat="server" />
                                            <asp:HiddenField ID="hfFinished" runat="server" />
                                            <asp:HiddenField ID="hfToday" runat="server" />
                                            <asp:GridView ID="grdData" runat="server"
                                                AllowPaging="false" AllowSorting="false"
                                                AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" ShowHeaderWhenEmpty="true"
                                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White"
                                               > <%--OnRowCommand="grdData_RowCommand"--%>
                                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID" runat="server" Text='<%#  Eval("Noseries") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="checkAll" runat="server" Onclick="javascript:SelectAllCheckboxes1(this);" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Entry No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEntNo" runat="server" Text='<%#  Eval("EntryNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Entry Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblentrydate" runat="server" Text='<%#  Eval("EntryDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Task Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltaskdate" runat="server" Text='<%#  Eval("TaskDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Due Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblduedate" runat="server" Text='<%#  Eval("DueDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Work Detail" SortExpression="WorkType">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblWt" runat="server" Text='<%#  Eval("WorkDetail") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assign By">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssignBy" runat="server" Text='<%#  Eval("AssignBy") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assign To">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssignTo" runat="server" Text='<%#  Eval("AssignTo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assign By Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%#  Eval("AdminStatus") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assign To Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssignStatus" runat="server" Text='<%#  Eval("AssignStatus") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="lblenid" HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnedit" ImageUrl="~/images/viewIcon.png" ToolTip="Click here to Edit Work Entry"
                                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Noseries") %>'
                                                                CommandName="editdata" CausesValidation="False" />
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="center" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="lblenid" HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" ImageUrl="~/images/delete.png" ToolTip="Click here to delete Work Entry"
                                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Noseries") %>'
                                                                CommandName="deletedata" CausesValidation="False" />
                                                            <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" ConfirmText="Do you Want to Delete?" runat="server" TargetControlID="btnDelete"></asp:ConfirmButtonExtender>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="true" HorizontalAlign="center" />
                                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <script>
        //On UpdatePanel Refresh
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    $(".select2").select2();
                    setTimeout(function () {
                        $("#alert_container").fadeTo(2000, 0).slideUp(500, function () {
                            $("#alert_container").remove();
                        });
                    }, 3000);//5000=5 seconds
                    //Datemask dd/mm/yyyy
                    $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
                    //Money Euro
                    $("[data-mask]").inputmask();
                }
            });
        };
    </script>
    <script>
        setTimeout(function () {
            $("#alert_container").fadeTo(2000, 0).slideUp(500, function () {
                $("#alert_container").remove();
            });
        }, 3000);//5000=5 seconds
    </script>
    <script type="text/javascript">
        function showProgress() {
           <%-- var updateProgress = $get("<%=UpdateProgress1.ClientID %>");--%>
            //updateProgress.style.display = "block";
        }
    </script>
    <%--Capitalize Format--%>
    <script type="text/javascript">
        function myFunction(id) {
            var txt = document.getElementById(id);
            txt.value = txt.value.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
        }
    </script>
    <script>
        function SelectAllCheckboxes1(chk) {
            $('#<%=grdData.ClientID%>').find("input:checkbox").each(function () {
                if (this != chk) { this.checked = chk.checked; }
            });
        }
    </script>
</asp:Content>

