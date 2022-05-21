<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendBulkEmail.aspx.cs" Inherits="SendBulkEmail" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %> 



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!DOCTYPE html>

    <script type="text/javascript">

        $(document).ready(function () {

            $('#txtemailcontent').bind('copy paste cut', function (e) {

                e.preventDefault(); //disable cut,copy,paste

            });

        });

    </script>
       <script type="text/javascript">
         $(function () {
           
                 $('[id*=GridView1]').DataTable({
                "responsive": true,



            });
            
        });
    </script>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upd1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnsend" />
            <asp:PostBackTrigger ControlID="lbtnupload" />
            <%-- <asp:PostBackTrigger ControlID="FileUpload2" />
            <asp:PostBackTrigger ControlID="FileUpload1" />--%>
        </Triggers>
        <ContentTemplate>
            <div class="messagealert" id="alert_container"></div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upd1" ClientIDMode="Predictable" ViewStateMode="Inherit">
                <ProgressTemplate>
                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #ffffff; opacity: 0.7;">
                        <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" Width="80px" Height="80px"
                            AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 55%; left: 47%;" />
                        <span style="border-width: 0px; position: fixed; padding: 30px; background-color: #FFFFFF; color: #0472C4; font-size: 25px; left: 44%; top: 42%;">Please Wait ...</span>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
              <asp:Label ID="lblloginid" runat="server" Visible="false" Text=""></asp:Label>
            <div class="wrapper">


                <!-- Content Wrapper. Contains page content -->
                <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">

                        <ol class="breadcrumb">
                            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                            <li class="active">Mailbox</li>
                        </ol>
                    </section>

                    <!-- Main content -->
                    <section class="content" style="margin-top:20px">
                        <div class="row">
                            <div class="col-md-5">
                                <a href="mailbox.html" class="btn btn-primary btn-block margin-bottom">Upload Excel File(only .xls and .xlsx extansion allow)</a>
                                <div class="col-md-2 form-group">
                                    <label class="control-label">
                                        Select  
                                    </label>
                                    <asp:FileUpload ID="FileUpload1" TabIndex="27" runat="server" />

                                </div>
                                <div class="col-md-1 form-group" style="margin-top: 15px; margin-left: 180px; text-align: right">

                                    <asp:LinkButton ID="lbtnupload" OnClick="lbtnupload_Click" runat="server" TabIndex="35" CssClass="btn btn-bitbucket btn-flat"><i class="fa fa-save"></i>&nbsp;Upload</asp:LinkButton>
                                     

                                </div>
                                <div class="row">
                                     <div class="col-md-5">
                                         <div class="form-group">
                                                <div class="input-group">
                                                    <asp:Label ID="lblERROR" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                         </div>
                                    </div>

                                <asp:GridView ID="GridView1" runat="server" AlternatingRowStyle-BackColor="#C2D69B" AllowPaging="false" AllowSorting="true"
                                                        AutoGenerateColumns="true" BorderWidth="1px"
                                                        CssClass="table table-striped table-bordered table-hover dataTable no-footer" CellPadding="2"
                                                        CellSpacing="2" EditRowStyle-HorizontalAlign="Center" PageSize="5"></asp:GridView>

                            </div>




                            <!-- /.col -->
                            <div class="col-md-7">
                                <div class="box box-primary">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">Compose New Message</h3>
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body">

                                        <div class="form-group">

                                            <asp:TextBox ID="txtsubject" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">

                                           <%-- <asp:HtmlEditorExtender ID="HtmlEditorExtender1" TargetControlID="txtemailcontent" EnableSanitization="false" runat="server">
                                                <Toolbar>
                                                    <asp:InsertImage />
                                                </Toolbar>
                                            </asp:HtmlEditorExtender>--%>
                                            
                                       <%-- <div class="form-group">

                                            <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/"   runat="server">
                                           
                                            </CKEditor:CKEditorControl>
                                      
                                            </div>--%>
                                                
    <div>
   <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server">
   </CKEditor:CKEditorControl>
</div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
        <asp:Label ID="lblpre" runat="server" Text="" ></asp:Label>
        </asp:Panel>
        <br />
        

 


                                        <div class="form-group">
                                          <div style="margin-left:20px">
                                                <i style="font-size:20px">Add Attachments</i></div>
                 
                                  <div style="margin:10px">
                                        <asp:FileUpload ID="FileUpload2" TabIndex="45" runat="server" AllowMultiple="true" />
                                      <p class="help-block">Max(Based on your Emaild Provider)</p>
                                  </div>

                                            
                                        </div>
                                               

                                            
                                        <%--<div class="form-group">
                                            <div class="btn btn-default btn-file">
                                                <i class="fa fa-paperclip"></i> Image in Body End
                 
                                  
                                        <asp:FileUpload ID="FUATTACH" TabIndex="45" runat="server" AllowMultiple="true" />

                                            </div>
                                            <p class="help-block">Max(Based on your Emaild Provider)</p>
                                        </div>--%>
                                    </div>
                                    <!-- /.box-body -->
                                    <div class="box-footer">
                                        <div class="pull-right">


                                            <asp:LinkButton ID="btnsend" class="btn btn-primary" OnClick="btnsend_Click" runat="server"><i class="fa fa-envelope-o"></i> Send</asp:LinkButton>
                                        </div>
                                        <button type="reset" class="btn btn-default"><i class="fa fa-times"></i>Clear</button>
                                    </div>
                                    <!-- /.box-footer -->
                                </div>
                                <!-- /. box -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </section>
                    <!-- /.content -->
                </div>
                <!-- /.content-wrapper -->
                <footer class="main-footer">
                    <div class="pull-right hidden-xs">
                        <b>Version</b> 2.3.8
   
                    </div>
                    <strong>Copyright &copy; 2014-2016 <a href="http://almsaeedstudio.com">Almsaeed Studio</a>.</strong> All rights
    reserved.
 
                </footer>

                <!-- Control Sidebar -->
                <aside class="control-sidebar control-sidebar-dark">
                    <!-- Create the tabs -->
                    <ul class="nav nav-tabs nav-justified control-sidebar-tabs">
                        <li><a href="#control-sidebar-home-tab" data-toggle="tab"><i class="fa fa-home"></i></a></li>
                        <li><a href="#control-sidebar-settings-tab" data-toggle="tab"><i class="fa fa-gears"></i></a></li>
                    </ul>
                    <!-- Tab panes -->
                    <div class="tab-content">
                        <!-- Home tab content -->
                        <div class="tab-pane" id="control-sidebar-home-tab">
                            <h3 class="control-sidebar-heading">Recent Activity</h3>
                            <ul class="control-sidebar-menu">
                                <li>
                                    <a href="javascript:void(0)">
                                        <i class="menu-icon fa fa-birthday-cake bg-red"></i>

                                        <div class="menu-info">
                                            <h4 class="control-sidebar-subheading">Langdon's Birthday</h4>

                                            <p>Will be 23 on April 24th</p>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)">
                                        <i class="menu-icon fa fa-user bg-yellow"></i>

                                        <div class="menu-info">
                                            <h4 class="control-sidebar-subheading">Frodo Updated His Profile</h4>

                                            <p>New phone +1(800)555-1234</p>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)">
                                        <i class="menu-icon fa fa-envelope-o bg-light-blue"></i>

                                        <div class="menu-info">
                                            <h4 class="control-sidebar-subheading">Nora Joined Mailing List</h4>

                                            <p>nora@example.com</p>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)">
                                        <i class="menu-icon fa fa-file-code-o bg-green"></i>

                                        <div class="menu-info">
                                            <h4 class="control-sidebar-subheading">Cron Job 254 Executed</h4>

                                            <p>Execution time 5 seconds</p>
                                        </div>
                                    </a>
                                </li>
                            </ul>
                            <!-- /.control-sidebar-menu -->

                            <h3 class="control-sidebar-heading">Tasks Progress</h3>
                            <ul class="control-sidebar-menu">
                                <li>
                                    <a href="javascript:void(0)">
                                        <h4 class="control-sidebar-subheading">Custom Template Design
               
                                    <span class="label label-danger pull-right">70%</span>
                                        </h4>

                                        <div class="progress progress-xxs">
                                            <div class="progress-bar progress-bar-danger" style="width: 70%"></div>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)">
                                        <h4 class="control-sidebar-subheading">Update Resume
               
                                    <span class="label label-success pull-right">95%</span>
                                        </h4>

                                        <div class="progress progress-xxs">
                                            <div class="progress-bar progress-bar-success" style="width: 95%"></div>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)">
                                        <h4 class="control-sidebar-subheading">Laravel Integration
               
                                    <span class="label label-warning pull-right">50%</span>
                                        </h4>

                                        <div class="progress progress-xxs">
                                            <div class="progress-bar progress-bar-warning" style="width: 50%"></div>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)">
                                        <h4 class="control-sidebar-subheading">Back End Framework
               
                                    <span class="label label-primary pull-right">68%</span>
                                        </h4>

                                        <div class="progress progress-xxs">
                                            <div class="progress-bar progress-bar-primary" style="width: 68%"></div>
                                        </div>
                                    </a>
                                </li>
                            </ul>
                            <!-- /.control-sidebar-menu -->

                        </div>
                        <!-- /.tab-pane -->
                        <!-- Stats tab content -->
                        <div class="tab-pane" id="control-sidebar-stats-tab">Stats Tab Content</div>
                        <!-- /.tab-pane -->
                        <!-- Settings tab content -->
                        <div class="tab-pane" id="control-sidebar-settings-tab">
                            <form method="post">
                                <h3 class="control-sidebar-heading">General Settings</h3>

                                <div class="form-group">
                                    <label class="control-sidebar-subheading">
                                        Report panel usage
             
                                <input type="checkbox" class="pull-right" checked>
                                    </label>

                                    <p>
                                        Some information about this general settings option
           
                                    </p>
                                </div>
                                <!-- /.form-group -->

                                <div class="form-group">
                                    <label class="control-sidebar-subheading">
                                        Allow mail redirect
             
                                <input type="checkbox" class="pull-right" checked>
                                    </label>

                                    <p>
                                        Other sets of options are available
           
                                    </p>
                                </div>
                                <!-- /.form-group -->

                                <div class="form-group">
                                    <label class="control-sidebar-subheading">
                                        Expose author name in posts
             
                                <input type="checkbox" class="pull-right" checked>
                                    </label>

                                    <p>
                                        Allow the user to show his name in blog posts
           
                                    </p>
                                </div>
                                <!-- /.form-group -->

                                <h3 class="control-sidebar-heading">Chat Settings</h3>

                                <div class="form-group">
                                    <label class="control-sidebar-subheading">
                                        Show me as online
             
                                <input type="checkbox" class="pull-right" checked>
                                    </label>
                                </div>
                                <!-- /.form-group -->

                                <div class="form-group">
                                    <label class="control-sidebar-subheading">
                                        Turn off notifications
             
                                <input type="checkbox" class="pull-right">
                                    </label>
                                </div>
                                <!-- /.form-group -->

                                <div class="form-group">
                                    <label class="control-sidebar-subheading">
                                        Delete chat history
             
                                <a href="javascript:void(0)" class="text-red pull-right"><i class="fa fa-trash-o"></i></a>
                                    </label>
                                </div>
                                <!-- /.form-group -->
                            </form>
                        </div>
                        <!-- /.tab-pane -->
                    </div>
                </aside>
                <!-- /.control-sidebar -->
                <!-- Add the sidebar's background. This div must be placed
       immediately after the control sidebar -->
                <div class="control-sidebar-bg"></div>
            </div>
            <!-- ./wrapper -->

            <%--<!-- jQuery 2.2.3 -->
            <script src="../../plugins/jQuery/jquery-2.2.3.min.js"></script>
            <!-- Bootstrap 3.3.6 -->
            <script src="../../bootstrap/js/bootstrap.min.js"></script>
            <!-- Slimscroll -->
            <script src="../../plugins/slimScroll/jquery.slimscroll.min.js"></script>
            <!-- FastClick -->
            <script src="../../plugins/fastclick/fastclick.js"></script>
            <!-- AdminLTE App -->
            <script src="../../dist/js/app.min.js"></script>
            <!-- AdminLTE for demo purposes -->
            <script src="../../dist/js/demo.js"></script>
            <!-- iCheck -->
            <script src="../../plugins/iCheck/icheck.min.js"></script>
            <!-- Bootstrap WYSIHTML5 -->
            <script src="../../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
            <!-- Page Script -->
            <script>
                $(function () {
                    //Add text editor
                    $("#compose-textarea").wysihtml5();
                });
</script>--%>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

