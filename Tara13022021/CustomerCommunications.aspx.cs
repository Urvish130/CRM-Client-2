using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net.Mime;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using CKEditor;
using System.util;

public partial class CustomerCommunications : System.Web.UI.Page
{

    BusinessLogicLayer bal = new BusinessLogicLayer();
    DataTable dt = new DataTable();
    string FilePath;
    SqlCommand cmd = new SqlCommand();
   
    string conStr = "";
    //   XmlElement XElemRoot;
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["no"] == null)
            {
                Response.Redirect("Default.aspx", false);
            }
            else
            {

                lblloginid.Text = Session["no"].ToString();
                bindEmaildata();

            }

        }
    }

    public void bindEmaildata()
    {

        try
        {
           
            

                dt = bal.getallCustomercontactdataBAL();
            
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = CKEditor1.Text;
        string str1 = Server.HtmlEncode(str);
        lblpre.Text = str1;


    }

    protected void btnsend_Click(object sender, EventArgs e)
    {
        try
        {
            int i;
            for (i = 0; i <= GridView1.Rows.Count; i++)
            {
                int c = GridView1.Rows.Count;
                if (i < c)
                {
                    //string name = Convert.ToString( GridView1.Rows[i].Cells[3].Text);
                    Label name1 = (Label)GridView1.Rows[i].Cells[1].FindControl("lblEmail");
                    Label name3 = (Label)GridView1.Rows[i].Cells[1].FindControl("lblcustname");
                    Label name4 = (Label)GridView1.Rows[i].Cells[1].FindControl("lblcontactname");
                    CheckBox name2 = (CheckBox)GridView1.Rows[i].Cells[1].FindControl("btnchkbox");
                    if (name1.Text.Equals(null) || name1.Text.Equals("") || name1.Text == "&nbsp;")
                    {

                        lblERROR.Text = " No E-Mail ID found for " + name3.Text +" " + name4.Text;
                        break;

                    }
                    else
                    {
                        if (name1.Text == "&nbsp;")
                        {
                            name1.Text = "";
                        }
                        else if( name2.Checked == true)
                        {
                            sendemail(name1.Text);
                        }
                    }

                }

            }
        }
        catch (Exception ex)
        {

        }
    }


    public void sendemail(string toemail)
    {


        DataTable dt = new DataTable();
        dt = bal.getBulkEmailDataBAL(lblloginid.Text);


        //Attachment data = new Attachment(
        //                   Attach1,
        //                   MediaTypeNames.Application.Pdf);

        string to = toemail; //To address    
        string from = dt.Rows[0]["Extra3"].ToString(); //From address     
        MailMessage message = new MailMessage(from, to);
        string str = CKEditor1.Text;

        if (FileUpload2.HasFiles)
        {
            foreach (HttpPostedFile file in FileUpload2.PostedFiles)
            {
                string filename1;
                string fileName1 = Path.GetFileName(file.FileName);
                string Extension1 = Path.GetExtension(file.FileName);
                string FolderPath1 = ConfigurationManager.AppSettings[""];
                filename1 = Path.GetFileName(file.FileName);
                FilePath = (Server.MapPath("~/Documents/") + fileName1);
                FileUpload2.SaveAs(FilePath);
                string Attach1 = Server.MapPath(FolderPath1 + fileName1);
                message.Attachments.Add(new Attachment(file.InputStream, fileName1));
                Extension1 = "";
            }

        }

        //for (int i=0; i< FileUpload2.PostedFiles.Count;i++)
        //{
        //    string filename1;
        //    string fileName1 = Path.GetFileName(FileUpload2.PostedFiles[i].FileName);
        //    string Extension1 = Path.GetExtension(FileUpload2.PostedFiles[i].FileName);
        //    string FolderPath1 = ConfigurationManager.AppSettings[""];
        //    filename1 = Path.GetFileName(FileUpload2.PostedFiles[i].FileName);
        //    FilePath = Server.MapPath(FolderPath1 + fileName1);
        //    FileUpload2.SaveAs(FilePath);
        //    string Attach1 = Server.MapPath(FolderPath1 + fileName1);
        //    message.Attachments.Add(new Attachment(file.InputStream, fileName1));
        //}


        //filename2 = Path.GetFileName(FUATTACH.PostedFile.FileName);
        ////Attachment imgAtt = new Attachment(FUATTACH.PostedFile.InputStream, filename);



        //    if (FUATTACH.HasFile)
        //    {
        //        FUATTACH.SaveAs(Server.MapPath("/Upload/") + FUATTACH.FileName);
        //        //  fuSIGN.SaveAs(Server.MapPath("/Upload/") + fuSIGN.FileName);
        //    }
        //string image = Server.MapPath("/Upload/") + FUATTACH.FileName;
        //LinkedResource img = new LinkedResource(image, MediaTypeNames.Image.Jpeg);
        //img.ContentId = "MyImage";




        //string str2 = @"  

        //              <img src=cid:MyImage  id='img' alt='' width='100px' height='100px'/>   

        //    ";

        //AlternateView avl = AlternateView.CreateAlternateViewFromString(
        //       str2, null, MediaTypeNames.Text.Html);


        //  avl.LinkedResources.Add(img);
        //   message.AlternateViews.Add(avl);

        string str1 = Server.HtmlEncode(str);
        lblpre.Text = str1;
        //string mailbody = CKEditor1.Text;
        message.Subject = txtsubject.Text;
        message.Body = str;
        Properties props = new Properties();
        message.IsBodyHtml = true;

        props.Add("webmail.tarainstruments.starttls.enable", "true");


        message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;
        SmtpClient client = new SmtpClient("webmail.tarainstruments.com", 587); //Gmail smtp    
        client.UseDefaultCredentials = false;
        System.Net.NetworkCredential basicCredential1 = new
        //("webmail.tarainstruments.com", 587)("smtp.gmail.com", 587)

        System.Net.NetworkCredential(dt.Rows[0]["Extra3"].ToString(), dt.Rows[0]["Extra4"].ToString());
        client.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

        client.Credentials = basicCredential1;
        try
        {
            client.Send(message);
            lblERROR.Text = "Mail Successfully Send.";
            lblERROR.ForeColor = System.Drawing.Color.Green;
            lblERROR.Font.Bold = true;
            txtsubject.Text = "";
            CKEditor1.Text = "";
        }

        catch (Exception ex)
        {
            lblERROR.Text = ex.ToString();
            lblERROR.ForeColor = System.Drawing.Color.Red;
            lblERROR.Font.Bold = true; ;
        }
    }



    protected void btnchkbox_CheckedChanged(object sender, EventArgs e)
    {

    }
}