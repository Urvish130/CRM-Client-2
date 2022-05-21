<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdatePrincipal.aspx.cs" Inherits="UpdatePrincipal" %>

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



    <style>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Principal Master
                     <asp:Label  class="control-label" ID="lblmsg" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Master</a></li>
                <li class="active">Principal Master</li>
                <asp:Label ID="lblcomno" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblid" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
                  <asp:Label ID="lblrole" runat="server" Visible="false" Text=""></asp:Label>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <!-- SELECT2 EXAMPLE -->
            <div class="box box-primary">
                 <div id="alert_container"></div>
                <!-- /.box-header -->
                <div class="box-body">

                    <div class="row">
                        <div class="col-md-12 form-group">
                            <label class="control-label">
                                Name<span class="required">* </span>
                            </label>
                            <asp:TextBox ID="txtName" ValidationGroup="prigrp" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" SetFocusOnError="true" ForeColor="Red"
                                CssClass="validate"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label class="control-label">
                                Profile
                            </label>
                            <asp:TextBox ID="txtprofilename" ValidationGroup="profilegrp" class="form-control" TabIndex="2" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtnuploadprofile" ValidationGroup="profilegrp" OnClick="lbtnuploadprofile_Click" Style="margin-top: 22px" runat="server" TabIndex="3" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>

                    </div>
                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdprofile" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdprofile_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Profile Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label class="control-label">
                                Catalouge
                            </label>
                            <asp:TextBox ID="txtcatloguename" class="form-control" ValidationGroup="Catalouge" TabIndex="4" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="filecatelogue" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtnuploadcatlogue" Style="margin-top: 22px" OnClick="lbtnuploadcatlogue_Click" ValidationGroup="Catalouge" runat="server" TabIndex="4" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>
                    </div>

                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdcatlogue" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdcatlogue_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Catalouge Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label>Application</label>
                            <asp:TextBox ID="txtapp" class="form-control" ValidationGroup="appgrp" TabIndex="5" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="fileapp" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtncreateapp" OnClick="lbtncreateapp_Click" ValidationGroup="appgrp" Style="margin-top: 22px" runat="server" TabIndex="6" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>
                    </div>


                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdapplication" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdapplication_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Application Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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

                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label class="control-label">
                                Paper
                            </label>
                            <asp:TextBox ID="txtpaper" class="form-control" ValidationGroup="papergrp" TabIndex="7" runat="server"></asp:TextBox>

                        </div>
                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="filepaper" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtnaddpaper" OnClick="lbtnaddpaper_Click" ValidationGroup="papergrp" Style="margin-top: 22px" runat="server" TabIndex="8" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>

                    </div>
                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdpaper" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdpaper_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Paper Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label class="control-label">
                                News
                            </label>
                            <asp:TextBox ID="txtnews" class="form-control" ValidationGroup="newsgrp" TabIndex="9" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="Filenews" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtnaddnews" Style="margin-top: 22px" ValidationGroup="newsgrp" OnClick="lbtnaddnews_Click" runat="server" TabIndex="10" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>


                    </div>


                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdnews" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdnews_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="News Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label class="control-label">
                                Certification
                            </label>
                            <asp:TextBox ID="txtcertificate" ValidationGroup="certigrp" class="form-control" TabIndex="11" runat="server"></asp:TextBox>

                        </div>


                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="Filecerti" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtnaddcerti" ValidationGroup="certigrp" OnClick="lbtnaddcerti_Click" Style="margin-top: 22px" runat="server" TabIndex="12" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>


                    </div>
                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdcerti" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdcerti_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Certificate Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label>PPT</label>
                            <asp:TextBox ID="txtppt" class="form-control" ValidationGroup="pptgrp" TabIndex="13" runat="server"></asp:TextBox>

                        </div>

                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="Fileppt" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtnaddppt" OnClick="lbtnaddppt_Click" ValidationGroup="pptgrp" Style="margin-top: 22px" runat="server" TabIndex="14" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>



                    </div>
                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdppt" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdppt_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="PPT Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label class="control-label">
                                Intro Letter
                            </label>
                            <asp:TextBox ID="txtintroletter" ValidationGroup="introlettergrp" CssClass="form-control" TabIndex="15" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="Fileintro" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtnaddintroletter" ValidationGroup="introlettergrp" OnClick="lbtnaddintroletter_Click" Style="margin-top: 22px" runat="server" TabIndex="16" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>

                    </div>

                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdintroletter" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdintroletter_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Intro Letter">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label class="control-label">
                                Client List
                            </label>
                            <asp:TextBox ID="txtclientlist" ValidationGroup="clientlistgrp" CssClass="form-control" ClientIDMode="Static" TabIndex="17" runat="server"></asp:TextBox>

                        </div>
                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="Fileclient" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtnaddclientlist" ValidationGroup="clientlistgrp" OnClick="lbtnaddclientlist_Click" Style="margin-top: 22px" runat="server" TabIndex="18" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>

                    </div>

                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdclientlist" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdclientlist_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Client List">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label class="control-label">
                                Progress
                            </label>
                            <asp:TextBox ID="txtprogress" ValidationGroup="progressgrp" CssClass="form-control" TabIndex="18" runat="server"></asp:TextBox>

                        </div>
                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="FileProgress" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtncreateprogress" ValidationGroup="progressgrp" OnClick="lbtncreateprogress_Click" Style="margin-top: 22px" runat="server" TabIndex="20" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>

                    </div>
                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdprogress" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdprogress_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Progress">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <div class="row">

                        <div class="col-md-7 form-group">
                            <label class="control-label">
                                Prices
                            </label>
                            <asp:TextBox ID="txtprice" ValidationGroup="pricegrp" CssClass="form-control" TabIndex="21" runat="server"></asp:TextBox>

                        </div>
                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="Fileprice" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtnaddprice" OnClick="lbtnaddprice_Click" ValidationGroup="pricegrp" Style="margin-top: 22px" runat="server" TabIndex="22" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>


                    </div>
                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdprice" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdprice_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Prise">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <div class="row">
                        <div class="col-md-7 form-group">
                            <label>Competitor's Information</label>
                            <asp:TextBox ID="txtcominfo" ValidationGroup="cominfogrp" class="form-control" TabIndex="23" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3 form-group">
                            <label class="control-label">
                                Upload Mutiple File
                            </label>
                            <asp:FileUpload ID="Filecominfo" class="form-control" runat="server" />
                        </div>

                        <div class="col-md-2 form-group">
                            <asp:LinkButton ID="lbtncreatecompatator" OnClick="lbtncreatecompatator_Click" ValidationGroup="cominfogrp" Style="margin-top: 22px" runat="server" TabIndex="24" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                        </div>

                    </div>
                    <div class="row">

                        <div class="box-body">
                            <asp:GridView ID="grdcominfo" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdcominfo_RowCommand" ShowHeaderWhenEmpty="true"
                                CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                <AlternatingRowStyle BackColor="White" />
                                <PagerStyle CssClass="csspager" />
                                <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Infomation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfname" runat="server" Text='<%# Eval("FileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                        <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="lblfamt" HeaderText="Download">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btndownload" ImageUrl="~/images/icons8-download-24.png" ToolTip="Click here to Download"
                                                runat="server" CssClass="imgbtnalign1" CommandArgument='<%# Eval("fileName") %>'
                                                CommandName="Download" CausesValidation="False" />
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
                    <section class="content-header">
                        <h3>Upload Video 
                    
                        </h3>
                        <div class="row">
                            <div class="col-md-5 form-group">
                                <label class="control-label">
                                    Title<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="txtviedotitle" ValidationGroup="pviedogrp" CssClass="form-control" TabIndex="25" runat="server"></asp:TextBox>


                            </div>
                            <div class="col-md-5 form-group">
                                <label class="control-label">
                                    Link 
                                </label>
                                <asp:TextBox ID="txtviedolink" ValidationGroup="pviedogrp" CssClass="form-control" TabIndex="26" runat="server"></asp:TextBox>

                            </div>
                            <div class="col-md-1 form-group">
                                <asp:LinkButton ID="lbtnaddviedo" ValidationGroup="pviedogrp" OnClick="lbtnaddviedo_Click" runat="server" Style="margin-top: 25px" TabIndex="27" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Add Another Video</asp:LinkButton>

                            </div>
                        </div>

                        <div class="row">

                            <div class="box-body">
                                <asp:GridView ID="grdviedodata" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                    AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdviedodata_RowCommand" ShowHeaderWhenEmpty="true"
                                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2" DataKeyNames="DocumentPath"
                                    CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                    <AlternatingRowStyle BackColor="White" />
                                    <PagerStyle CssClass="csspager" />
                                    <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Title">
                                            <ItemTemplate>
                                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("DocuName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Link">
                                            <ItemTemplate>
                                                <asp:Label ID="lbllink" runat="server" Text='<%# Eval("Filename") %>'></asp:Label>
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


                    </section>
                    <section class="content-header">
                        <h3>Contact Person
                    
                        </h3>
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    Name<span class="required">*</span>
                                </label>
                                <asp:TextBox ID="txtcontactname" CssClass="form-control" TabIndex="28" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcontactname"
                                    Display="Dynamic" ErrorMessage="Please Enter Name" Text="(*) Required" SetFocusOnError="true" ValidationGroup="comgcontactroup" ForeColor="Red"
                                    CssClass="validate"></asp:RequiredFieldValidator>


                            </div>
                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    Email 
                                </label>
                                <asp:TextBox ID="txtcontactemail" CssClass="form-control" TabIndex="29" runat="server"></asp:TextBox>

                            </div>
                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    Phone No
                                </label>
                                <asp:TextBox ID="txtcontactphno" CssClass="form-control" TabIndex="30" runat="server"></asp:TextBox>


                            </div>
                        </div>
                        <div class="row">

                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    Mobile No(1)
                                </label>
                                <asp:TextBox ID="txtcontactmno1" CssClass="form-control" TabIndex="31" runat="server"></asp:TextBox>


                            </div>
                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    Mobile No(2)
                                </label>
                                <asp:TextBox ID="txtcontactmno2" CssClass="form-control" TabIndex="32" runat="server"></asp:TextBox>


                            </div>
                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    Department 
                                </label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="false" data-placeholder="Select Department" CssClass="form-control select2" TabIndex="33"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="lnbDept" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                                </div>

                            </div>


                        </div>

                        <div class="row">

                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    Designation 
                                </label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddldesign" runat="server" AutoPostBack="false" data-placeholder="Select Designation" CssClass="form-control select2" TabIndex="34"></asp:DropDownList>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="lbtncreatedesign" runat="server" CssClass="btn btn-dropbox btn-flat" CausesValidation="false"><i class="fa fa-plus"></i></asp:LinkButton></span>
                                </div>
                            </div>
                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    Date of Birth
                                </label>
                                <asp:TextBox ID="txtdob" CssClass="form-control" TabIndex="35" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtdob" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>


                            </div>
                            <div class="col-md-4 form-group">
                                <label class="control-label">
                                    Date of Anniversary
                                </label>
                                <asp:TextBox ID="txtdoani" CssClass="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" TabIndex="36" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" TargetControlID="txtdoani" Format="dd/MM/yyyy" runat="server"></asp:CalendarExtender>

                            </div>

                        </div>
                        <div class="row" style="text-align: right">
                            <div class="col-md-12 form-group" style="text-align: right">
                                <asp:LinkButton ID="lbtnaddcontact" Style="margin-top: 25px" OnClick="lbtnaddcontact_Click" ValidationGroup="comgcontactroup" runat="server" TabIndex="37" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Add contact </asp:LinkButton>
                                <asp:LinkButton ID="lbtnupdatecontact" Visible="false" runat="server" OnClick="lbtnupdatecontact_Click" ValidationGroup="comgcontactroup" TabIndex="38" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                                <asp:LinkButton ID="lbtnresetcontact" runat="server" TabIndex="39" OnClick="lbtnresetcontact_Click" Style="margin-top: 25px" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>

                            </div>
                        </div>

                        <div class="row">

                            <div class="box-body">
                                <asp:GridView ID="grdcontact" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="false"
                                    AutoGenerateColumns="False" BorderWidth="1px" OnRowCommand="grdcontact_RowCommand" ShowHeaderWhenEmpty="true"
                                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                    CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5" HeaderStyle-BackColor="#3c8dbc" HeaderStyle-ForeColor="White">
                                    <AlternatingRowStyle BackColor="White" />
                                    <PagerStyle CssClass="csspager" />
                                    <EmptyDataTemplate>No Records Available</EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblname" runat="server" Text='<%# Eval("ContactName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label ID="lblemail" runat="server" Text='<%# Eval("ContactEmail") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PhoneNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContactPhone" runat="server" Text='<%# Eval("ContactPhone") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobileno1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContactMobileno1" runat="server" Text='<%# Eval("ContactMobileno1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobileno2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContactMobileno2" runat="server" Text='<%# Eval("ContactMobileno2") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Department">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeptName" runat="server" Text='<%# Eval("DeptName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Designation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesigName" runat="server" Text='<%# Eval("DesigName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date of Birth">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldob" runat="server" Text='<%# Eval("Extra1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="true" HorizontalAlign="Left" />
                                            <HeaderStyle Wrap="true" HorizontalAlign="Left" CssClass="grdhead" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date of Anniversary">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldoani" runat="server" Text='<%# Eval("Extra2") %>'></asp:Label>
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

                    </section>
                    <div class="row">
                        <div class="col-md-12 form-group pull-right" style="padding-top: 5px; text-align: right">
                            <asp:LinkButton ID="btnSave" runat="server" ValidationGroup="prigrp" CausesValidation="true" OnClick="btnSave_Click" TabIndex="40" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Update</asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" OnClick="btnDelete_Click"  runat="server"  OnClientClick="return confirm('Do You Want to Delete?')"  TabIndex="41" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Delete</asp:LinkButton>
                            <asp:LinkButton ID="btncancel" OnClick="btncancel_Click" runat="server" TabIndex="42" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;cancel</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>

            <!-- /.row -->
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
                                                                                                        <asp:Label ID="lblmsg1" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label>

                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtncreatedept" OnClick="lbtncreatedept_Click" ValidationGroup="deptgrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lbtndesignreset_Click" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
                                                     <asp:Label ID="lblmsg2" runat="server" Text="     " Width="500px" ForeColor="Red"></asp:Label>
                                                    <div class="form-group pull-right">
                                                        <asp:LinkButton ID="lbtndesigncreate" OnClick="lbtndesigncreate_Click" ValidationGroup="designgrp" runat="server" TabIndex="19" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>

                                                        <asp:LinkButton ID="LinkButton2" OnClick="lbtndesignreset_Click" runat="server" TabIndex="20" CssClass="btn btn-bitbucket bg-gray btn-flat" CausesValidation="false"><i class="fa fa-times"></i>&nbsp;Reset</asp:LinkButton>
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
