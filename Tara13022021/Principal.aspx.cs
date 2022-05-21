using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.IO;
public partial class Principal : System.Web.UI.Page

{

       BusinessLogicLayer bal = new BusinessLogicLayer();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            if (Session["no"] == null)
            {
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                lblloginid.Text = Session["no"].ToString();
                lblrole.Text = Session["role"].ToString();
                lblmsg.Text = "";
                lblmsg1.Text = "";
                lblmsg2.Text = "";
                getmaxcomno();
                binddepartment();
                binddesignation();
            } 
        }
    }
    public string getmaxcomno()
    {
        string s = string.Empty, id = string.Empty;
        Getconnection c = new Getconnection();
        try
        {
            string s1 = "select Top (1) No from tbl_Principal_NoSeries    order By  Id DESC";
            SqlCommand cmd11 = new SqlCommand(s1, c.getconnection());
            if (cmd11.ExecuteScalar() != null)
                id = cmd11.ExecuteScalar().ToString();
            c.CloseConnection();
            int fid = 0;
            if (id.Equals(""))
            {
                id = "1";
                fid = Convert.ToInt32(id);
            }
            else
            {
                fid = Convert.ToInt32(id);
                fid = fid + 1;
            }
            s = fid.ToString();
            lblcomno.Text = s.ToString();
            //hfMaxEntryNo.Value = fid.ToString();
            bal.tbl_Principal_NoSeries_InsertBAL(s, "", "");
        }
        catch (Exception ex)
        {

            //txtinqno.Text = "1";
        }
        finally
        {
            c.CloseConnection();
        }
        return s;
    }
  
  
    protected void lbtnuploadprofile_Click(object sender, EventArgs e)
    {
        try
        {


            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalProfile_Document_Master_InsertBAL(lblcomno.Text, txtprofilename.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtprofilename.Text = "";
                bindprofile();
                txtprofilename.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }
    public void bindprofile()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getProfiledocumentadataBAL( );
            if (dtcontact.Rows.Count > 0)
            {
                grdprofile.DataSource = dtcontact;
                grdprofile.DataBind();
                grdprofile.UseAccessibleHeader = true;
                grdprofile.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdprofile.DataSource = dtcontact;
                grdprofile.DataBind();
                grdprofile.UseAccessibleHeader = true;
                grdprofile.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdprofile_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deleteprincipalProfiledatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

           bindprofile();


        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void grdcatlogue_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deleteprincipalCatloguedatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindcatlogue();


        }
    }
    protected void lbtnuploadcatlogue_Click(object sender, EventArgs e)
    {
        try
        {


            if (filecatelogue.HasFile)
            {
                string fileName = Path.GetFileName(filecatelogue.FileName);
                filecatelogue.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalCatlogue_Document_Master_InsertBAL(lblcomno.Text, txtcatloguename.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtcatloguename.Text = "";
                bindcatlogue();
                txtcatloguename.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }


    public void bindcatlogue()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getCatloguedocumentadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdcatlogue.DataSource = dtcontact;
                grdcatlogue.DataBind();
                grdcatlogue.UseAccessibleHeader = true;
                grdcatlogue.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdcatlogue.DataSource = dtcontact;
                grdcatlogue.DataBind();
                grdcatlogue.UseAccessibleHeader = true;
                grdcatlogue.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdapplication_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deleteprincipalApplicationdatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindapp();


        }
    }
    protected void lbtncreateapp_Click(object sender, EventArgs e)
    {
        try
        {


            if (fileapp.HasFile)
            {
                string fileName = Path.GetFileName(fileapp.FileName);
                fileapp.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalApp_Document_Master_InsertBAL(lblcomno.Text, txtapp.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtapp.Text = "";
                bindapp();
                txtapp.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }

    public void bindapp()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getApplicationdocumentadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdapplication.DataSource = dtcontact;
                grdapplication.DataBind();
                grdapplication.UseAccessibleHeader = true;
                grdapplication.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdapplication.DataSource = dtcontact;
                grdapplication.DataBind();
                grdapplication.UseAccessibleHeader = true;
                grdapplication.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void lbtnaddpaper_Click(object sender, EventArgs e)
    {
        try
        {


            if (filepaper.HasFile)
            {
                string fileName = Path.GetFileName(filepaper.FileName);
                filepaper.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalPaper_Document_Master_InsertBAL(lblcomno.Text, txtpaper.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtpaper.Text = "";
                bindpaper();
                txtpaper.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }


    public void bindpaper()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getPaperdocumentadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdpaper.DataSource = dtcontact;
                grdpaper.DataBind();
                grdpaper.UseAccessibleHeader = true;
                grdpaper.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdpaper.DataSource = dtcontact;
                grdpaper.DataBind();
                grdpaper.UseAccessibleHeader = true;
                grdpaper.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdpaper_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deleteprincipalPaperdatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindpaper();


        }
    }
    protected void lbtnaddnews_Click(object sender, EventArgs e)
    {
        try
        {


            if (Filenews.HasFile)
            {
                string fileName = Path.GetFileName(Filenews.FileName);
                Filenews.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalNews_Document_Master_InsertBAL(lblcomno.Text, txtnews.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtnews.Text = "";
                bindnews();
                txtnews.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }


    public void bindnews()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getNewsdocumentadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdnews.DataSource = dtcontact;
                grdnews.DataBind();
                grdnews.UseAccessibleHeader = true;
                grdnews.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdnews.DataSource = dtcontact;
                grdnews.DataBind();
                grdnews.UseAccessibleHeader = true;
                grdnews.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdnews_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deleteprincipalNewsdatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindnews();


        }
    }
    protected void lbtnaddcerti_Click(object sender, EventArgs e)
    {
        try
        {


            if (Filecerti.HasFile)
            {
                string fileName = Path.GetFileName(Filecerti.FileName);
                Filecerti.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalCertificate_Document_Master_InsertBAL(lblcomno.Text, txtcertificate.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtcertificate.Text = "";
                bindcertificate();
                txtcertificate.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }


    public void bindcertificate()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getCertifcatedocumentadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdcerti.DataSource = dtcontact;
                grdcerti.DataBind();
                grdcerti.UseAccessibleHeader = true;
                grdcerti.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdcerti.DataSource = dtcontact;
                grdcerti.DataBind();
                grdcerti.UseAccessibleHeader = true;
                grdcerti.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdcerti_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deleteprincipalCertificatedatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindcertificate();


        }
    }
    protected void lbtnaddppt_Click(object sender, EventArgs e)
    {
        try
        {


            if (Fileppt.HasFile)
            {
                string fileName = Path.GetFileName(Fileppt.FileName);
                Fileppt.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalPPT_Document_Master_InsertBAL(lblcomno.Text, txtppt.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtppt.Text = "";
                bindppt();
                txtppt.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }

    public void bindppt()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getPPTdocumentadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdppt.DataSource = dtcontact;
                grdppt.DataBind();
                grdppt.UseAccessibleHeader = true;
                grdppt.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdppt.DataSource = dtcontact;
                grdppt.DataBind();
                grdppt.UseAccessibleHeader = true;
                grdppt.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdppt_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deleteprincipalPPTdatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindppt();


        }
    }
    protected void lbtnaddintroletter_Click(object sender, EventArgs e)
    {
        try
        {


            if (Fileintro.HasFile)
            {
                string fileName = Path.GetFileName(Fileintro.FileName);
                Fileintro.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalIntroLetter_Document_Master_InsertBAL(lblcomno.Text, txtintroletter.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                lbtnaddintroletter.Text = "";
                bindintroletter();
                lbtnaddintroletter.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }


    public void bindintroletter()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getIntroLetterdocumentadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdintroletter.DataSource = dtcontact;
                grdintroletter.DataBind();
                grdintroletter.UseAccessibleHeader = true;
                grdintroletter.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdintroletter.DataSource = dtcontact;
                grdintroletter.DataBind();
                grdintroletter.UseAccessibleHeader = true;
                grdintroletter.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdintroletter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deleteprincipalIntroLetterdatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindintroletter();


        }
    }
    protected void lbtnaddclientlist_Click(object sender, EventArgs e)
    {
        try
        {


            if (Fileclient.HasFile)
            {
                string fileName = Path.GetFileName(Fileclient.FileName);
                Fileclient.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalClient_Document_Master_InsertBAL(lblcomno.Text, txtclientlist.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtclientlist.Text = "";
                bindcient();
                txtclientlist.Focus();
            }

        }
        catch (Exception ex)
        {

        }

    }

    public void bindcient()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getClientdocumentadatBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdclientlist.DataSource = dtcontact;
                grdclientlist.DataBind();
                grdclientlist.UseAccessibleHeader = true;
                grdclientlist.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdclientlist.DataSource = dtcontact;
                grdclientlist.DataBind();
                grdclientlist.UseAccessibleHeader = true;
                grdclientlist.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdclientlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deletePrincipalClientdatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindcient();


        }
    }
    protected void lbtncreateprogress_Click(object sender, EventArgs e)
    {
        try
        {


            if (FileProgress.HasFile)
            {
                string fileName = Path.GetFileName(FileProgress.FileName);
                FileProgress.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalProgress_Document_Master_InsertBAL(lblcomno.Text, txtprogress.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtprogress.Text = "";
                bindprogress();
                txtprogress.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }
    public void bindprogress()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getProgressdocumentadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdprogress.DataSource = dtcontact;
                grdprogress.DataBind();
                grdprogress.UseAccessibleHeader = true;
                grdprogress.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdprogress.DataSource = dtcontact;
                grdprogress.DataBind();
                grdprogress.UseAccessibleHeader = true;
                grdprogress.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdprogress_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deletePrincipalProgressdatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindprogress();


        }
    }
    protected void lbtnaddprice_Click(object sender, EventArgs e)
    {
        try
        {


            if (Fileprice.HasFile)
            {
                string fileName = Path.GetFileName(Fileprice.FileName);
                Fileprice.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalPrice_Document_Master_InsertBAL(lblcomno.Text, txtprice.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtprice.Text = "";
                bindprice();
                txtprice.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }

    public void bindprice()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getPricedocumentadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdprice.DataSource = dtcontact;
                grdprice.DataBind();
                grdprice.UseAccessibleHeader = true;
                grdprice.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdprice.DataSource = dtcontact;
                grdprice.DataBind();
                grdprice.UseAccessibleHeader = true;
                grdprice.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdprice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deletePrincipalPricedatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindprice();


        }
    }
    public static Random random = new Random();
    public static string RandomString(int length)
    { 
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    protected void lbtncreatecompatator_Click(object sender, EventArgs e)
    {
        try
        {


            if (Filecominfo.HasFile)
            {
                string fileName = Path.GetFileName(Filecominfo.FileName);
                string randomfilename = RandomString(10);
                Filecominfo.SaveAs(Server.MapPath("~/Documents/") + randomfilename);
                string filepath = "~/Documents/" + randomfilename;
                


                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalComInfo_Document_Master_InsertBAL(lblcomno.Text, txtcominfo.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtcominfo.Text = "";
                bindcominfor();
                txtcominfo.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }
    public void bindcominfor()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getCominfodocumentadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdcominfo.DataSource = dtcontact;
                grdcominfo.DataBind();
                grdcominfo.UseAccessibleHeader = true;
                grdcominfo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdcominfo.DataSource = dtcontact;
                grdcominfo.DataBind();
                grdcominfo.UseAccessibleHeader = true;
                grdcominfo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdcominfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Documents/") + e.CommandArgument);
            ShowMessage("Attachment Sucessfully Downloaded !!!", MessageType.Success);
            Response.End();

        }
        else if (e.CommandName == "deletedata")
        {

            string result = bal.deletePrincipalCominfodatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindcominfor();


        }

    }
    protected void lbtnaddviedo_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkPrincipalViedeoBAL(txtName.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {

                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_PrincipalViedo_Master_InsertBAL(lblcomno.Text, txtviedotitle.Text, txtviedolink.Text, "", lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtviedotitle.Text = "";
                txtviedolink.Text = "";
                bindviedo();
                txtviedotitle.Focus();
            }
           

        }
        catch (Exception ex)
        {

        }
    }

    public void bindviedo()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getPrincipalViedodataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdviedodata.DataSource = dtcontact;
                grdviedodata.DataBind();
                grdviedodata.UseAccessibleHeader = true;
                grdviedodata.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdviedodata.DataSource = dtcontact;
                grdviedodata.DataBind();
                grdviedodata.UseAccessibleHeader = true;
                grdviedodata.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grdviedodata_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deletedata")
        {

            string result = bal.deletePrincipalViedodatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindviedo();


        }
    }

    protected void lbtncreatedept_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkDepartmentnameBAL(txtdeptname.Text);
            if (dt1.Rows.Count > 0)
            {
               ShowMessage("Name Already Exist!!!", MessageType.Error);
               // lblmsg1.Text = "Name Already Exist!!!";
                mpdept.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                lblmsg1.Text = "";
                bal.tbl_Department_Master_InsertBAL(txtdeptname.Text, lblloginid.Text, localTime, "", "", "", "", "");
                binddepartment();
               ShowMessage("Record Save!!!", MessageType.Success);
                //txtdeptname.Text = "";
                lblmsg1.Text = "Record Save!!!";
               txtdeptname.Focus();
                mpdept.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }

    protected void lbtndesigncreate_Click(object sender, EventArgs e)
    {
        try
        {
            
            DataTable dt1 = new DataTable();
            dt1 = bal.checkDesignationnameBAL(txtdesign.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
               // lblmsg2.Text = "Name Already Exist!!!";
                mpdesign.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Designation_Master_InsertBAL(txtdesign.Text, lblloginid.Text, localTime, "", "", "", "", "");
                binddesignation();
                ShowMessage("Record Save!!!", MessageType.Success);
                txtdesign.Text = "";
               // lblmsg2.Text = "Record Save!!!";
                txtdesign.Focus();
                mpdesign.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }

    public void binddepartment()
    {
        try
        {
            DataTable dtdept = new DataTable();


            dtdept = bal.getDepartment_MasterforadminBAL();
            if (dtdept.Rows.Count > 0)
            {
                ddlDept.DataSource = dtdept;
                ddlDept.DataTextField = "DeptName";
                ddlDept.DataValueField = "Id";
                ddlDept.DataBind();
            }
            ddlDept.Items.Insert(0, new ListItem("----Select Department----", "0"));
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    public void binddesignation()
    {
        try
        {
            DataTable dtdesign = new DataTable();


            dtdesign = bal.getDesignation_MasterforadminBAL();
            if (dtdesign.Rows.Count > 0)
            {
                ddldesign.DataSource = dtdesign;
                ddldesign.DataTextField = "DesigName";
                ddldesign.DataValueField = "Id";
                ddldesign.DataBind();
            }
            ddldesign.Items.Insert(0, new ListItem("----Select Designation----", "0"));
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }

    protected void lbtnaddcontact_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dt1 = new DataTable();
            dt1 = bal.checkPrincipalcontactnameBAL(lblcomno.Text, txtcontactname.Text, txtcontactemail.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {

                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_Principal_Contact_Master_InsertBAL(lblcomno.Text, txtcontactname.Text, txtcontactemail.Text, txtcontactphno.Text, txtcontactmno1.Text, txtcontactmno2.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesign.SelectedValue.ToString()), lblloginid.Text, localTime, txtdob.Text, txtdoani.Text, "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                resetcontact();
                bindcontactdata();
                txtcontactname.Focus();
            }
        }
        catch (Exception ex)
        {

        }

    }

    public void lbtndesignreset_Click(object sender, EventArgs e)
    {
        try
        {
            txtdesign.Text = "";
            lblmsg.Text = "";
            lblmsg1.Text = "";
            lblmsg2.Text = "";
            txtdeptname.Text = "";


        }
        catch (Exception ex)
        {

        }
    }


    public void resetcontact()
    {
        try
        {
            txtcontactname.Text = "";
            txtcontactemail.Text = "";
            txtcontactphno.Text = "";
            txtcontactmno1.Text = "";
            txtcontactmno2.Text = "";
            ddlDept.ClearSelection();
            ddldesign.ClearSelection();
            txtdob.Text = "";
            txtdoani.Text = "";

        }
        catch (Exception ex)
        {

        }
    }
    protected void grdcontact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string result;
            lblid.Text = e.CommandArgument.ToString();
            if (e.CommandName == "editdata")
            {
                DataTable dtdata = bal.getPrincipalcontactdatabyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    txtcontactname.Text = dtdata.Rows[0]["ContactName"].ToString();
                    txtcontactemail.Text = dtdata.Rows[0]["ContactEmail"].ToString();
                    txtcontactphno.Text = dtdata.Rows[0]["ContactPhone"].ToString();
                    txtcontactmno1.Text = dtdata.Rows[0]["ContactMobileno1"].ToString();
                    txtcontactmno2.Text = dtdata.Rows[0]["ContactMobileno2"].ToString();
                    txtdob.Text = dtdata.Rows[0]["Extra1"].ToString();
                    txtdoani.Text = dtdata.Rows[0]["Extra2"].ToString();
                    string deptvalule = dtdata.Rows[0]["Dept"].ToString();
                    ddlDept.SelectedValue = dtdata.Rows[0]["Dept"].ToString();
                    ddldesign.SelectedValue = dtdata.Rows[0]["Design"].ToString();

                    txtcontactname.Focus();
                    lbtnaddcontact.Visible = false;
                    lbtnupdatecontact.Visible = true;
                    //  bindDetail();
                }
            }
            else if (e.CommandName == "deletedata")
            {

                result = bal.deletePrincipalcontactdatabyidBAL(lblid.Text);

                ShowMessage("Record Deleted!!!", MessageType.Success);

                bindcontactdata();
                lbtnaddcontact.Visible = true;
                lbtnupdatecontact.Visible = false;

            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void lbtnupdatecontact_Click(object sender, EventArgs e)
    {
        try
        {


            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

            string result = bal.tbl_Principal_Contact_Master_updateBAL(Convert.ToInt32(lblid.Text), txtcontactname.Text, txtcontactemail.Text, txtcontactphno.Text, txtcontactmno1.Text, txtcontactmno2.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesign.SelectedValue.ToString()), lblloginid.Text, localTime, txtdob.Text, txtdoani.Text, "", "", "");
            if (result == "-1")
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {

                resetcontact();
                bindcontactdata();
                ShowMessage("Record Save!!!", MessageType.Success);

                txtcontactname.Focus();
                lbtnaddcontact.Visible = true;
                lbtnupdatecontact.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void lbtnresetcontact_Click(object sender, EventArgs e)
    {
        try
        {
            resetcontact();
        }
        catch (Exception ex)
        {

        }

    }
    public void bindcontactdata()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getPrincipalcontactdataBAL(Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdcontact.DataSource = dtcontact;
                grdcontact.DataBind();
                grdcontact.UseAccessibleHeader = true;
                grdcontact.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdcontact.DataSource = dtcontact;
                grdcontact.DataBind();
                grdcontact.UseAccessibleHeader = true;
                grdcontact.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkPrincipalnameBAL(txtName.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("      Name Already Exist!!!", MessageType.Error);
               // lblmsg.Text = "      Name Already Exist!!!";
              


            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Principal_Master_InsertBAL(Convert.ToInt32(lblcomno.Text),txtName.Text, lblloginid.Text, localTime,"", "", "", "", "");

                Response.Redirect("PrincipalRegsiter.aspx", false);
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }

    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        resetcontact();
        txtName.Text = "";
        txtprofilename.Text = "";
        txtcatloguename.Text = "";
        txtapp.Text = "";
        txtpaper.Text = "";
        txtnews.Text = "";
        txtcertificate.Text = "";
        txtppt.Text = "";
        txtintroletter.Text = "";
        txtclientlist.Text = "";
        txtprogress.Text = "";
        txtprice.Text = "";
        txtcominfo.Text = "";
        FileUpload1.Dispose();
        fileapp.Dispose();
        filepaper.Dispose();
        Filenews.Dispose();
        Filecerti.Dispose();
        Fileppt.Dispose();
        Fileintro.Dispose();
        Fileclient.Dispose();
        Fileprice.Dispose();
        Filecominfo.Dispose();
        FileProgress.Dispose();

    }
}