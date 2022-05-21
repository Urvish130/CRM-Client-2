<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemRegsiter.aspx.cs" Inherits="ItemRegsiter" %>

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
            <h1>Item Register
                    
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Master</a></li>
                <li class="active">Item Register</li>
                <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                   <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
                 <asp:Label ID="lblrole" runat="server" Visible="false" Text=""></asp:Label>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group pull-right">
                        <asp:LinkButton ID="btncreate" runat="server" OnClick="btncreate_Click"  TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Create Item</asp:LinkButton>
                       
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <asp:GridView ID="grddata" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                    AutoGenerateColumns="False" BorderWidth="1px" ShowHeaderWhenEmpty="true" OnRowCommand="grddata_RowCommand"
                                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                    CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                    <AlternatingRowStyle BackColor="White" />
                                    <PagerStyle CssClass="csspager" />
                                    <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-CssClass="" HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnedit" ImageUrl="images/viewIcon.png" ToolTip="Click here to update"
                                                    runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("no") %>'
                                                    CommandName="editdata" CausesValidation="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("Itemname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Group Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCity" runat="server" Text='<%# Eval("ItemGroupName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sub Group Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblState" runat="server" Text='<%# Eval("ItemSubGroupName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UOM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDistrict" runat="server" Text='<%# Eval("Uom") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Eval("Itemrate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GST">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Itemgst") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="HSN code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBussType" runat="server" Text='<%# Eval("ItemHsn") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Import Duty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblImportDuty" runat="server" Text='<%# Eval("Extra1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Export Duty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExportDuty" runat="server" Text='<%# Eval("Extra2") %>'></asp:Label>
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
        </section>
    </div>
</asp:Content>

