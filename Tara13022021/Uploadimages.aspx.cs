using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Uploadimages : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    BusinessLogicLayer bal = new BusinessLogicLayer();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
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
                    bindDetail();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }


    public void bindDetail()
    {

        try
        {

            //if (lblrole.Text.Equals("admin"))
            //{

            //}
            //else
            //{
            //    dt = bal.getallRoleBAL(lblloginid.Text);
            //}

            //dt = bal.getallItemgroupBAL(lblloginid.Text);

            dt = bal.getallUploadedImagesforadminBAL();
            if (dt.Rows.Count > 0)
            {
                grddata.DataSource = dt;
                grddata.DataBind();
                grddata.UseAccessibleHeader = true;
                grddata.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grddata.DataSource = dt;
                grddata.DataBind();
                grddata.UseAccessibleHeader = true;
                grddata.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grddata_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string result;
            lblid.Text = e.CommandArgument.ToString();
            if (e.CommandName == "editdata")
            {
                DataTable dtdata = bal.getUploadedImagesbyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    txtName.Text = dtdata.Rows[0]["Name"].ToString();
                    lblimgpath.Text = dtdata.Rows[0]["Path"].ToString();
                    lblimgpath.Visible = true;
                    txtName.Focus();
                    lblimgpathname.Visible = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;

                }
            }
            else if (e.CommandName == "deletedata")
            {

                result = bal.deleteImagesbyidBAL(lblid.Text);

                ShowMessage("Record Deleted!!!", MessageType.Success);

                bindDetail();
                btnSave.Visible = true;
                btnUpdate.Visible = false;

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
           
            lblmsg.Text = "";
            lblimgpath.Visible = false;
            lblimgpathname.Visible = false;
            txtName.Text = "";

                

        }
        catch (Exception ex)
        {

        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkImagenameBAL(txtName.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
               // lblmsg.Text = "Name Already Exist!!!";
            }
            else
            {
                if (FileUpload1.HasFile)
                {
                    string fileName = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/Documents/") + fileName);
                    string filepath = "http://oxonpaints-001-site7.atempurl.com/Documents/" + fileName;



                    DateTime utcTime = DateTime.UtcNow;
                    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                    DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                    bal.tblImage_Upload_InsertBAL(txtName.Text, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                    bindDetail();
                    ShowMessage("Record Save!!!", MessageType.Success);
                    txtName.Text = "";
                    txtName.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "http://oxonpaints-001-site7.atempurl.com/Documents/" + fileName;
                string result = bal.tbl_Image_UpdateBAL(lblid.Text, txtName.Text, filepath);


                if (result == "-1")
                {
                    ShowMessage("Name Already Exist!!!", MessageType.Error);
                }


                else
                {


                    bindDetail();
                    ShowMessage("Record Updated!!!", MessageType.Success);
                    txtName.Text = "";
                     lblimgpath.Visible = false;
            lblimgpathname.Visible = false;
                    txtName.Focus();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                }
            }
        
        }
        catch (Exception ex)
        {
        }
    }
}