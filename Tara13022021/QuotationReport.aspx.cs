
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Net.Mail;
using System.Net;
public partial class QuotationReport : System.Web.UI.Page
{
    BusinessLogicLayer bal = new BusinessLogicLayer();
    Getconnection c = new Getconnection();
    string headervalue = null;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        try
        {
            if (Session["role"].ToString() == null)
            {
                Response.Redirect("Default.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"].ToString() != null)
            {
                bindreport();
            }
        }
    }
    public void bindreport()
    {
        try
        {
            DataTable dt1 = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("getallQuotationdataForReport1", c.getconnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QuotationNumber", SqlDbType.VarChar).Value = Request.QueryString["Id"].ToString();
            dt1.Load(cmd.ExecuteReader());

            DataTable dt2 = new DataTable();
            SqlCommand cmd1 = new SqlCommand();
            cmd1 = new SqlCommand("getQuotationdataReport2", c.getconnection());
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@QuotationNumber", SqlDbType.VarChar).Value = Request.QueryString["Id"].ToString();
            dt2.Load(cmd1.ExecuteReader());
           
           
            

            DataTable dt3 = new DataTable();
            SqlCommand cmd3 = new SqlCommand();
            cmd3 = new SqlCommand("termsandconditionsFromQuotationforReport", c.getconnection());
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.Add("@id", SqlDbType.VarChar).Value = Request.QueryString["Id"].ToString();
            dt3.Load(cmd3.ExecuteReader());

            DataTable dt4 = new DataTable();
            SqlCommand cmd4 = new SqlCommand();
            cmd4 = new SqlCommand("getQuotationdataReportCurrency", c.getconnection());
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.Add("@QuotationNumber", SqlDbType.VarChar).Value = Request.QueryString["Id"].ToString();
            dt4.Load(cmd4.ExecuteReader());

            if (dt1.Rows.Count > 0)
            {
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.EnableHyperlinks = true;
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt1));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet4", dt2));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt3));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", dt4));
                ReportViewer1.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/Reports/Quotation.rdlc");
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.Visible = true;
            }
            else
            {
                ReportViewer1.Visible = false;
            }
            
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        mpmail.Show();
    }
    protected void lbtncancel_Click(object sender, EventArgs e)
    {
        mpmail.Hide();
    }
    //protected void btnsendmail_Click(object sender, EventArgs e)
    //{
    //    string FileName = "File_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";
    //    string extension;
    //    string encoding;
    //    string mimeType;
    //    string[] streams;
    //    Warning[] warnings;
    //    string contentType = "application/pdf";
    //    Byte[] mybytes = ReportViewer1.LocalReport.Render("PDF", null,
    //                    out extension, out encoding,
    //                    out mimeType, out streams, out warnings); //for exporting to PDF  
    //    using (FileStream fs = File.Create(Server.MapPath("~/Reports/") + FileName))
    //    {
    //        fs.Write(mybytes, 0, mybytes.Length);
    //    }
    //    try
    //    {
    //        MailMessage mail = new MailMessage();
    //        SmtpClient smtp = new SmtpClient();
    //        mail.From = new MailAddress("Email ID", "Visible Name");
    //        string cust = txtmail.Text;
    //        //mail.To.Add(new MailAddress("aaku898shah@gmail.com"));
    //        string[] Custm = cust.Split(',');
    //        foreach (string custmr in Custm)
    //        {
    //            mail.To.Add(new MailAddress(custmr));
    //        }
    //        //mail.Bcc.Add("mikir281989@gmail.com");
    //        mail.Subject = "Quotation";
    //        mail.Body = "This is Computer Generated Quotation";
    //        MemoryStream memoryStream = new MemoryStream(mybytes);
    //        memoryStream.Seek(0, SeekOrigin.Begin);
    //        Attachment attachment = new Attachment(memoryStream, "~/Reports/" + FileName);
    //        mail.Attachments.Add(attachment);
    //        mail.IsBodyHtml = true;
    //        smtp.Port = 587;
    //        smtp.Host = "smtp.gmail.com"; //for gmail host  
    //        smtp.EnableSsl = true;
    //        smtp.UseDefaultCredentials = false;
    //        smtp.Credentials = new NetworkCredential("Email ID", "Password");
    //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    //        //smtp.Send(mail);
    //        //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Mail Sent on  " + "" + cust + "');", true);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}

    protected void btnsendmail_Click(object sender, EventArgs e)
    {

    }
}