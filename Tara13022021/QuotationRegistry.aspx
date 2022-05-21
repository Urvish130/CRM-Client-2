<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QuotationRegistry.aspx.cs" Inherits="QuotationRegistry"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
      <script type="text/javascript">
         $(function () {
           
                 $('[id*=grddata]').DataTable({
                "responsive": true,



            });
            
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
           
            <ol class="breadcrumb">
                <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblrole" runat="server" Visible="false" Text=""></asp:Label>
                 <asp:Label ID="lblcompanyno" runat="server" Visible="false" Text=""></asp:Label>
            </ol>            
            
               <div class="row" style="margin-top:-22px">
                <div class="col-md-4">
                    <div class="form-group pull-left">
                         <h1>Quotation Registry</h1>
                        </div>
                    </div>
                   <div class="col-md-6">
                       <div class="form-group pull-right" style="margin-top:15px; margin-left:25px">
                          <asp:ImageButton ID="ImageButton1" Width="47px" Height="47px" OnClick="btnExportExcel_Click" ImageUrl="~/images/Excel.png" runat="server" />
                            <asp:ImageButton ID="ImageButton2" Width="47px" Height="47px" OnClick="btnExportPDF_Click" ImageUrl="~/images/pdf.jpg" runat="server" />
                            <asp:ImageButton ID="ImageButton3" Width="47px" Height="47px" OnClick="btnExportWord_Click" ImageUrl="~/images/Word.png" runat="server" />
                            <%--<asp:ImageButton ID="btnmail" Width="47px" Height="47px" ImageUrl="~/images/email.png" runat="server" />--%>
                        
                       </div>

                   </div>
                    <div class="col-md-2">
                          <div class="form-group pull-right" style="margin-top:20px">
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="20px" OnClick="btncreate_Click" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Create Quotation</asp:LinkButton>    
                   </div>
                              </div>
                   </div>
                   
                
            
        </section>
        <section class="content">
            <%--<div class="row">
                <div class="col-md-6">
                    <div class="form-group pull-right">
                        <asp:LinkButton ID="btncreate" runat="server" OnClick="btncreate_Click" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Create Quotation</asp:LinkButton>
                        </div>
                        <div class="col-md-6" style="text-align: right">
                            <asp:ImageButton ID="btnExportExcel" Width="47px" Height="47px" OnClick="btnExportExcel_Click" ImageUrl="~/images/Excel.png" runat="server" />
                            <asp:ImageButton ID="btnExportPDF" Width="47px" Height="47px" OnClick="btnExportPDF_Click" ImageUrl="~/images/pdf.jpg" runat="server" />
                            <asp:ImageButton ID="btnExportWord" Width="47px" Height="47px" OnClick="btnExportWord_Click" ImageUrl="~/images/Word.png" runat="server" />--%>
                            <%--<asp:ImageButton ID="btnmail" Width="47px" Height="47px" ImageUrl="~/images/email.png" runat="server" />--%>
                       <%-- </div>
                   
                </div>
            </div>--%>
            <div class="row">
                <div class="box-body">
                    <div class="row" style="margin-top: 0px;">
                        <%--<div class="col-md-9" style="text-align: right">
                            <asp:LinkButton ID="btnFilter" runat="server" TabIndex="11" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-filter"></i>&nbsp;Filter</asp:LinkButton>
                            <asp:LinkButton ID="btnReset" runat="server" TabIndex="12" CssClass="btn btn-bitbucket bg-gray btn-flat"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
                        </div>--%>
                        
                    </div>
                    <div class="row" style="margin-top:-25px">
                        <div class="col-md-12">
                            
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
                                                    runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Noseries") %>'
                                                    CommandName="editdata" CausesValidation="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="" HeaderText="Revise" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnrevise" ImageUrl="~/images/download 2.png" Height="40px" Width="40px" ToolTip="Click here to Revise"
                                                    runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Noseries") %>'
                                                    CommandName="revisedata" CausesValidation="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderStyle-CssClass="" HeaderText="Copy" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnCopy" ImageUrl="images/download.png" ToolTip="Click here to Revise" Height="25px" Width="25px"
                                                    runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Noseries") %>'
                                                    CommandName="Copydata" CausesValidation="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="" HeaderText="Print" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnprint" ImageUrl="images/download1.png" Height="40px" Width="40px" ToolTip="Click here to Print"
                                                    runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Noseries") %>'
                                                    CommandName="printdata" CausesValidation="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblno" runat="server" Text='<%# Eval("QuotationNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("QuotationDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer Group">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcustgroup" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcust" runat="server" Text='<%# Eval("CustName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Contact Person">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcontact" runat="server" Text='<%# Eval("Custname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContactEmail" runat="server" Text='<%# Eval("ContactEmail") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobileno">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmno" runat="server" Text='<%# Eval("ContactMno1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Source">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsource" runat="server" Text='<%# Eval("SourceName") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderStyle-CssClass="" HeaderText="Won" >
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnwon" ImageUrl="images/download3.png" Height="35px" Width="35px" ToolTip="Click here to Won"
                                                    runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Noseries") %>'
                                                    CommandName="wondata" CausesValidation="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="" HeaderText="Loss">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnloss" ImageUrl="images/download4.png" Height="35px" Width="60px" ToolTip="Click here to Loss"
                                                    runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("Noseries") %>'
                                                    CommandName="lossdata" CausesValidation="False" />
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                    </Columns>
                                </asp:GridView>
                            </div>
                        
                    </div>
                </div>
            </div>
        </section>

    </div>
</asp:Content>

