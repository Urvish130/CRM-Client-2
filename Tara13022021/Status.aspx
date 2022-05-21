<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Status.aspx.cs" Inherits="Status" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
         $(function () {
           
                 $('[id*=grddata]').DataTable({
                "responsive": true,



            });
            
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Status Master
                    
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Master</a></li>
                <li class="active">Status Master</li>
                     <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                 <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
                    <asp:Label ID="lblrole" runat="server" Visible="false" Text=""></asp:Label>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-6">
                    <div class="box box-primary">
                         <div id="alert_container"></div>
                        <div class="box-body">
                            <div class="form-group">
                                <label class="control-label">
                                   Status Name<span class="required">* </span>
                                </label>
                                <asp:TextBox ID="txtName" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="Please Enter Name" ValidationGroup="gstatus" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                    CssClass="validate"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-6">
                     <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                 </div>
                            <div class="form-group pull-right">
                                <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" TabIndex="2" ValidationGroup="gstatus" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                            <asp:LinkButton ID="btnUpdate" Visible="false" OnClick="btnUpdate_Click" runat="server" TabIndex="3" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" runat="server" TabIndex="4"  OnClick="btnReset_Click" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-header">
                            <h4>Status Details</h4>

                        </div>
                        <div class="box-body">
                            <asp:GridView ID="grddata" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grddata_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("StatusName") %>'></asp:Label>
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
        </section>
    </div>
</asp:Content>

