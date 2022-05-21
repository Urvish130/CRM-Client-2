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

public partial class sendemail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        //{

        //    string from = "info@tarainstruments.com"; //Replace this with your own correct Gmail Address
        //    string to = "mikir@uniqtechsolutions.com";
        //    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //    mail.To.Add(to);

        //    string value = "test email contect";



        //    AlternateView avl = AlternateView.CreateAlternateViewFromString("<html><body><br/><img src=cid:MyImage></body></html>" + value + "<html><body><br/><img src=cid:MySign></body></html>", null, MediaTypeNames.Text.Html);


        //    mail.From = new MailAddress(from, "test email", System.Text.Encoding.UTF8);
        //    mail.Subject = "test email";
        //    mail.SubjectEncoding = System.Text.Encoding.UTF8;
        //    //mail.Body = body;
        //    mail.AlternateViews.Add(avl);
        //    mail.BodyEncoding = System.Text.Encoding.UTF8;
        //    mail.IsBodyHtml = true;
        //    mail.Priority = MailPriority.High;


        //    SmtpClient client = new SmtpClient("mail.tarainstruments.com");

        //    NetworkCredential Credentials = new NetworkCredential("info@tarainstruments.com", "info@tara");
        //    //client.Credentials = Credentials;

        //    client.EnableSsl = true;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = basicCredential1;
        //    //ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //    //{ return true; };

        //    //client.Host = "jobbit.in";


        //    client.Send(mail);

        //}
        //catch (Exception ex)
        //{
        //    //lblERROR.Text = "Mail Not Send Successfully.";
        //    //lblERROR.ForeColor = System.Drawing.Color.Red;
        //    //lblERROR.Font.Bold = true;
        //}


    }

    //public void sendemail()
    //{
    //    string to = "mikir@uniqtechsolutions.com"; //To address    
    //    string from = "info@tarainstruments.com"; //From address    
    //    MailMessage message = new MailMessage(from, to);

    //    string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
    //    message.Subject = "Sending Email Using Asp.Net & C#";
    //    message.Body = mailbody;
    //    message.BodyEncoding = Encoding.UTF8;
    //    message.IsBodyHtml = true;
    //    SmtpClient client = new SmtpClient("mail.tarainstruments.com", 587); //Gmail smtp    
    //    System.Net.NetworkCredential basicCredential1 = new
    //    System.Net.NetworkCredential("info@tarainstruments.com", "info@tara");
    //    client.EnableSsl = true;
    //    client.UseDefaultCredentials = false;
    //    client.Credentials = basicCredential1;
    //    try
    //    {
    //        client.Send(message);
    //    }

    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

 
   
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
}