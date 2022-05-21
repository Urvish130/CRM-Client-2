using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
public partial class UpdateItem : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    BusinessLogicLayer bal = new BusinessLogicLayer();

    public enum MessageType { Success, Error, Info, Warning };


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            lblcomno.Text = Request.QueryString["no"].ToString();
            lblrole.Text = Session["role"].ToString();
            lblloginid.Text = Session["no"].ToString();
            binditemgroup();
             binddocument();
            bindimg();
            binditemsubgroup();
            lblmsg.Text = "";
            binduom();

            filldata();
        }
    }
    public void filldata()
    {
        try
        {
            DataTable dtdata = bal.getallitemdatabynoBAL(lblcomno.Text);
            if (dtdata.Rows.Count > 0)
            {
                ddlgroup.SelectedValue = dtdata.Rows[0]["itemgroup"].ToString();
                ddlsubgroup.SelectedValue = dtdata.Rows[0]["itemsubgroup"].ToString();
                txtModalNo.Text = dtdata.Rows[0]["Modelno"].ToString();
                txtItemName.Text = dtdata.Rows[0]["Itemname"].ToString();
                txtFinalName.Text = dtdata.Rows[0]["ItemFinalname"].ToString();
                txtAlias.Text = dtdata.Rows[0]["Itemalis"].ToString();
                txtitemcategoryno.Text = dtdata.Rows[0]["Itemcategoryno"].ToString();
                ddluom.SelectedValue = dtdata.Rows[0]["ItemUOM"].ToString();
                txtRate.Text = dtdata.Rows[0]["Itemrate"].ToString();
                txtImportDuty.Text = dtdata.Rows[0]["Extra1"].ToString();
                txtExportDuty.Text = dtdata.Rows[0]["Extra2"].ToString();
                txtGST.Text = dtdata.Rows[0]["Itemgst"].ToString();
               txtHSN.Text = dtdata.Rows[0]["ItemHsn"].ToString();
               txtDescp.Text = dtdata.Rows[0]["ItemDesc"].ToString();
                

            }
        }
        catch (Exception ex)
        {

        }
    }
    public void binditemgroup()
    {
        try
        {
            DataTable dtdept = new DataTable();


            dtdept = bal.getallItemgroupforadminBAL();
            if (dtdept.Rows.Count > 0)
            {
                ddlgroup.DataSource = dtdept;
                ddlgroup.DataTextField = "ItemGroupName";
                ddlgroup.DataValueField = "Id";
                ddlgroup.DataBind();


                dlgroupnamemp.DataSource = dtdept;
                dlgroupnamemp.DataTextField = "ItemGroupName";
                dlgroupnamemp.DataValueField = "Id";
                dlgroupnamemp.DataBind();

            }
            ddlgroup.Items.Insert(0, new ListItem("----Select ItemGroup----", "0"));
            dlgroupnamemp.Items.Insert(0, new ListItem("----Select ItemGroup----", "0"));
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }

    public void binditemsubgroup()
    {
        try
        {
            DataTable dtdept = new DataTable();


            dtdept = bal.getallItemsubgroupforadminBAL();
            if (dtdept.Rows.Count > 0)
            {
                ddlsubgroup.DataSource = dtdept;
                ddlsubgroup.DataTextField = "ItemSubGroupName";
                ddlsubgroup.DataValueField = "Id";
                ddlsubgroup.DataBind();
            }
            ddlsubgroup.Items.Insert(0, new ListItem("----Select Item SubGroup----", "0"));
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }

    public void binduom()
    {
        try
        {
            DataTable dtdept = new DataTable();


            dtdept = bal.getallunitforadminBAL();
            if (dtdept.Rows.Count > 0)
            {
                ddluom.DataSource = dtdept;
                ddluom.DataTextField = "Uom";
                ddluom.DataValueField = "Id";
                ddluom.DataBind();
            }
            ddluom.Items.Insert(0, new ListItem("----Select UOM----", "0"));
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void lbtncreategroup_Click(object sender, EventArgs e)
    {


        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkItemgroupnameBAL(txtgroupname.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
               // lblmsg1.Text = "Name Already Exist!!!";
                mpdesign.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tblItemgroup_Master_InsertBAL(txtgroupname.Text, lblloginid.Text, localTime, "", "", "", "", "");
                binditemgroup();
               ShowMessage("Record Save!!!", MessageType.Success);
                //lblmsg1.Text = "Record Save!!!";
                txtgroupname.Text = "";
                txtgroupname.Focus();
                mpdesign.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }
    protected void lbtnresetgroup_Click(object sender, EventArgs e)
    {

    }
    protected void lbtcreatesubgroup_Click(object sender, EventArgs e)
    {


        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkItemsubgroupnameBAL(txtsubgroupnamemp.Text);
            if (dt1.Rows.Count > 0)
            {
                  ShowMessage("Name Already Exist!!!", MessageType.Error);
               // lblmsg2.Text = "Name Already Exist!!!";
                ModalPopupExtender1.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Itemsubgroup_Master_InsertBAL(txtsubgroupnamemp.Text, Convert.ToInt32(dlgroupnamemp.SelectedValue.ToString()), lblloginid.Text, localTime, "", "", "", "", "");
                binditemsubgroup();
                 ShowMessage("Record Save!!!", MessageType.Success);
              // lblmsg2.Text = "Record Save!!!";
                txtsubgroupnamemp.Text = "";
                dlgroupnamemp.ClearSelection();
                ModalPopupExtender1.Show();
                txtsubgroupnamemp.Focus();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }
    protected void lbtresetesubgroup_Click(object sender, EventArgs e)
    {

    }
    protected void lbtncreateuom_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkUOMnameBAL(txtuom.Text);
            if (dt1.Rows.Count > 0)
            {
                 ShowMessage("Name Already Exist!!!", MessageType.Error);
               // lblmsg3.Text = "Name Already Exist!!!";
                ModalPopupExtender2.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tblItemunit_Master_InsertBAL(txtuom.Text, lblloginid.Text, localTime, "", "", "", "", "");
                binduom();
                  ShowMessage("Record Save!!!", MessageType.Success);
                lblmsg3.Text = "Record Save!!!";
                txtuom.Text = "";
                txtuom.Focus();
                ModalPopupExtender2.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }
    public void lbtndesignreset_Click(object sender, EventArgs e)
    {
        try
        {
            txtuom.Text = "";
            lblmsg.Text = "";
            lblmsg1.Text = "";
            lblmsg2.Text = "";
            lblmsg3.Text = "";
            txtsubgroupnamemp.Text = "";

            txtgroupname.Text = "";


        }
        catch (Exception ex)
        {

        }
    }

    protected void grditem_RowCommand(object sender, GridViewCommandEventArgs e)
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

            string result = bal.deletitemimgdatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            bindimg();


        }
    }
    protected void grditembro_RowCommand(object sender, GridViewCommandEventArgs e)
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

            string result = bal.deletitemdocumentdatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            binddocument();


        }

    }
    protected void btnitemimg_Click(object sender, EventArgs e)
    {
        try
        {


            if (fuItemPic.HasFile)
            {
                string fileName = Path.GetFileName(fuItemPic.FileName);
                fuItemPic.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;
                string filepath1 = "http://localhost:64802/Documents" + fileName;



                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_ItemImage_Master_InsertBAL(lblcomno.Text, "", fileName, filepath1, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                bindimg();
                // txtdocument.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }

    public void binddocument()
    {

        try
        {
          
            DataTable dtcontact = new DataTable();
            dtcontact = bal.getItemdocumentadataBAL(lblcomno.Text);
            if (dtcontact.Rows.Count > 0)
            {
                grditembro.DataSource = dtcontact;
                grditembro.DataBind();
                grditembro.UseAccessibleHeader = true;
                grditembro.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grditembro.DataSource = dtcontact;
                grditembro.DataBind();
                grditembro.UseAccessibleHeader = true;
                grditembro.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }


    public void bindimg()
    {

        try
        {
           
            DataTable dtcontact = new DataTable();
            dtcontact = bal.getItemimageadataBAL( Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grditem.DataSource = dtcontact;
                grditem.DataBind();
                grditem.UseAccessibleHeader = true;
                grditem.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grditem.DataSource = dtcontact;
                grditem.DataBind();
                grditem.UseAccessibleHeader = true;
                grditem.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void btnadditembro_Click(object sender, EventArgs e)
    {
        try
        {


            if (fuBroucher.HasFile)
            {
                string fileName = Path.GetFileName(fuBroucher.FileName);
                fuItemPic.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;


             
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_ItemDocument_Master_InsertBAL(lblcomno.Text, "", fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                binddocument();
                ShowMessage("Record Save!!!", MessageType.Success);
                // txtdocument.Focus();
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Item_Master_updateBAL(Convert.ToInt32(lblcomno.Text), Convert.ToInt32(ddlgroup.SelectedValue.ToString()), Convert.ToInt32(ddlsubgroup.SelectedValue.ToString()), txtModalNo.Text, txtItemName.Text, txtFinalName.Text, txtAlias.Text, txtitemcategoryno.Text, Convert.ToInt32(ddluom.SelectedValue.ToString()), Convert.ToDecimal(txtRate.Text), Convert.ToInt32(txtGST.Text), txtHSN.Text, txtDescp.Text, lblloginid.Text, localTime, txtImportDuty.Text, txtExportDuty.Text, "", "", "");

                ShowMessage("Record Save!!!", MessageType.Success);
                Response.Redirect("ItemRegsiter.aspx", false);
            
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }
    
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            bal.deleteitematanoBAL(lblcomno.Text);
            Response.Redirect("ItemRegsiter.aspx", false);
        }
        catch (Exception ex)
        {

        }


    }
}