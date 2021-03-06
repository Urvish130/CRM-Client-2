using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Country : System.Web.UI.Page
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
            dt = bal.getallCountryforadminBAL();
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
                DataTable dtdata = bal.getCountrybyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    txtName.Text = dtdata.Rows[0]["Country"].ToString();
                    txtcurrency.Text = dtdata.Rows[0]["Extra1"].ToString();
                    txtCurrencyValue.Text = dtdata.Rows[0]["Extra2"].ToString();
                    txtINRvalue.Text = dtdata.Rows[0]["Extra3"].ToString();
                    txtName.Focus();
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    //  bindDetail();
                }
            }
            else if (e.CommandName == "deletedata")
            {

                result = bal.deleteCountrybyidBAL(lblid.Text);

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
            dt1 = bal.checkCountrynameBAL(txtName.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
               // lblmsg.Text = "Name Already Exist!!!";
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.SaveCountryMasterBAL(txtName.Text, lblloginid.Text, localTime, txtcurrency.Text, txtCurrencyValue.Text, txtINRvalue.Text, "", "");
                bindDetail();
                ShowMessage("Record Save!!!", MessageType.Success);
                txtName.Text = "";
                txtcurrency.Text = "";
                txtCurrencyValue.Text = "";
                txtINRvalue.Text = "";
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
            string result = bal.tbl_Country_UpdateBAL(lblid.Text, txtName.Text);
            if (result == "-1")
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {
                bindDetail();
                ShowMessage("Record Updated!!!", MessageType.Success);
                txtName.Text = "";
                txtcurrency.Text = "";
                txtCurrencyValue.Text = "";
                txtINRvalue.Text = "";
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
        txtcurrency.Text = "";
        txtCurrencyValue.Text = "";
        txtINRvalue.Text = "";
    }
}