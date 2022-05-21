<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssignProduct.aspx.cs" Inherits="AssignProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
     <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
   <script type="text/javascript">
         $(function () {
           
                 $('[id*=grddata]').DataTable({
                "responsive": true,



            });
            
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <div  id="progress" style="display:none">
       <img src="images/rotate-pulsating-loading-animation.gif" />
    </div>--%>
    <div id="formdata">
        <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">

            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Master</a></li>
                <li class="active">Assign product</li>

                  
                <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblrole" runat="server" Visible="false" Text=""></asp:Label>
                    <asp:Label ID="lblno" runat="server" Text=""></asp:Label>
            </ol>
        </section>
        <br />
        <section class="content">
            <div class="row">
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div id="alert_container"></div>
                        <div class="box-header">
                            <h4>Assign Product Entry</h4>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label class="control-label">Select </label>
                                <asp:RadioButtonList ID="rbtntype" runat="server" CssClass="radioboxlist form-control" AutoPostBack="true" OnSelectedIndexChanged="rbtntype_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="28">
                                    <asp:ListItem Value="1" Selected="True">Principal</asp:ListItem>
                                    <asp:ListItem Value="2">Suppliers</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div id="divpri" runat="server" class="form-group">
                                <label>Select principal<span class="required">* </span></label>
                                <asp:DropDownList ID="dpprincipal" runat="server" data-placeholder="Select principal" class="form-control select2" TabIndex="2">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="isubgroup" runat="server" ControlToValidate="dpprincipal"
                                    Display="Dynamic" ErrorMessage="Please Select Group" SetFocusOnError="true" ForeColor="Red"
                                    CssClass="validate" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>

                            <div id="divdistri" runat="server" class="form-group">
                                <label>Select Suppliers<span class="required">* </span></label>
                                <asp:DropDownList ID="dlsupplier" runat="server" data-placeholder="Select Suppliers" class="form-control select2" TabIndex="2">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="isubgroup" runat="server" ControlToValidate="dlsupplier"
                                    Display="Dynamic" ErrorMessage="Please Select Group" SetFocusOnError="true" ForeColor="Red"
                                    CssClass="validate" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:GridView ID="GridView1" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                    AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grddata_RowCommand"  ShowHeaderWhenEmpty="true"
                                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                    CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                    <AlternatingRowStyle BackColor="White" />
                                    <PagerStyle CssClass="csspager" />
                                    <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="checkvalue" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Itemname">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemname" runat="server" Text='<%# Eval("Itemname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>


                                    </Columns>

                                    <EditRowStyle HorizontalAlign="Center"></EditRowStyle>
                                </asp:GridView>

                                        <asp:GridView ID="GridView2" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                    AutoGenerateColumns="False" BorderWidth="1px"  OnRowDataBound="GridView2_RowDataBound" ShowHeaderWhenEmpty="true"
                                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                    CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                    <AlternatingRowStyle BackColor="White" />
                                    <PagerStyle CssClass="csspager" />
                                    <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="checkvalue" Text='<%# Eval("checkvalue") %>' runat="server"></asp:CheckBox>
                                                <%-- <asp:CheckBox ID="CheckBox1" Visible="false" Text='<%# Eval("checkvalue") %>' runat="server"></asp:CheckBox>--%>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Itemname">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemname" runat="server" Text='<%# Eval("Itemname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>


                                    </Columns>

                                    <EditRowStyle HorizontalAlign="Center"></EditRowStyle>
                                </asp:GridView>
                            </div>


                            <div class="form-group pull-right">
                                <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" TabIndex="3" ValidationGroup="isubgroup" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                                <asp:LinkButton ID="btnUpdate" Visible="false" OnClick="btnUpdate_Click" runat="server" TabIndex="4" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" TabIndex="5" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-header">
                            <h4>Assign Product Details</h4>
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
                                    <asp:TemplateField HeaderText="SupplerName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsuname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                                            <asp:Label ID="lbltype" Visible="false" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>

                                    
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnedit" ImageUrl="images/viewIcon.png" ToolTip="Click here to update"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("No") %>'
                                                CommandName="editdata" CausesValidation="False" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" ImageUrl="images/delete.png" ToolTip="Click here to delete"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("No") %>'
                                                CommandName="deletedata" CausesValidation="False" OnClientClick="return confirm('Do You Want to Delete?')"  />
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
    </div>
    
</asp:Content>

