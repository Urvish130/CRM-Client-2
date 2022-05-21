<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateQuotationTerms.aspx.cs" Inherits="UpdateQuotationTerms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <div class="content-wrapper"> 
             <section class="content-header">
                    <h1>Terms and Conditions</h1>
                        <ol class="breadcrumb">
                            <li><a href="Default.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                            <li><a href="Quotation.master">Quotation</a></li>
                            <li class="active">Terms and Conditons</li>
                            <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                            <asp:Label ID="Label1" runat="server" Visible="false" Text=""></asp:Label>
                               <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
                        </ol>
                </section>
            <asp:UpdatePanel ID="updtPnlContactForm" runat="server">
            <ContentTemplate>
           <div class="row margin">
              
                <div class="col-md-7">
                      <div class="box box-primary">
                        <div class="box-body margin">
                            <div class="form-group" >
                                <label class="control-label">
                                    Title:<span class="required">* </span>
                                </label>
                               
                                <asp:TextBox ID="txtName" CssClass ="form-control" TabIndex="1" runat="server" placeholder="Enter Title"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                    CssClass="validate"></asp:RequiredFieldValidator>
                              
                                     <label class="control-label" style="padding-top:15px">
                                      Sequence Number<span class="required">* </span>
                                </label>
                              <asp:TextBox ID="txtSequence" CssClass ="form-control" TabIndex="1" runat="server" placeholder="Enter Sequence Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSequence"
                                    Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                    CssClass="validate"></asp:RequiredFieldValidator>

                      
                                     <label class="control-label"  style="padding-top:15px">
                                    Description:<span class="required">* </span>
                                </label>
                          <asp:TextBox ID="Txttandc" runat="server" Height="500px" Width="90%" BorderStyle="Double" ></asp:TextBox>
                         <asp:HtmlEditorExtender ID="HtmlEditorExtender1" TargetControlID="Txttandc" EnableSanitization="false" runat="server"  ></asp:HtmlEditorExtender>
                            </div> </div> 
                         <asp:LinkButton ID="BtnSave"  runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat pull-right"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                          <asp:LinkButton ID="BtnUpdate" Visible="false" runat="server" OnClick="BtnUpdate_Click" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>                

                           
                    
                          </div>
                    
                    </div>
               
                               <div class="col-md-5">

                 <asp:GridView ID="grddata" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="Grddata_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5"  HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Title">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("Termstitle") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Title">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsequence" runat="server" Text='<%# Eval("Extra1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnedit" ImageUrl="images/viewIcon.png" ToolTip="Click here to update"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("id") %>'
                                                CommandName="editdata" CausesValidation="False" />
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" ImageUrl="images/delete.png" ToolTip="Click here to delete"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("id") %>'
                                                CommandName="deletedata" CausesValidation="False" />
                                         
                                        </ItemTemplate></asp:TemplateField>
                                </Columns>
                       <EditRowStyle HorizontalAlign="Center"></EditRowStyle>
                            </asp:GridView>
</div>
             </div>
                                     
                </ContentTemplate></asp:UpdatePanel>
                              
            </div>
          
   

</asp:Content>




