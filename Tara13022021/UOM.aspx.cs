using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UOM : System.Web.UI.Page
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

            //dt = bal.getallunitBAL(lblloginid.Text);
            dt = bal.getallunitforadminBAL();
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
                DataTable dtdata = bal.getUOMdatabyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    txtName.Text = dtdata.Rows[0]["Uom"].ToString();
                    txtName.Focus();
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;

                }
            }
            else if (e.CommandName == "deletedata")
            {

                result = bal.deleteUOMdatabyidBAL(lblid.Text);

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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkUOMnameBAL(txtName.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
                //lblmsg.Text = "Name Already Exist!!!";
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tblItemunit_Master_InsertBAL(txtName.Text, lblloginid.Text, localTime, "", "", "", "", "");
                bindDetail();
                ShowMessage("Record Save!!!", MessageType.Success);
                txtName.Text = "";
                txtName.Focus();
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
            string result = bal.tblItemunit_Master_UpdateBAL(lblid.Text, txtName.Text); 
            if (result == "-1")
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {

                bindDetail();
                ShowMessage("Record Updated!!!", MessageType.Success);
                txtName.Text = "";
                txtName.Focus();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
       
    }


}