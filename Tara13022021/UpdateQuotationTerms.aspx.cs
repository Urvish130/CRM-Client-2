
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class UpdateQuotationTerms : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    BusinessLogicLayer bll = new BusinessLogicLayer();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {   
                lblid.Text = Request.QueryString["no"].ToString();
                Label1.Text = Request.QueryString["UpdQTC"].ToString(); 
                BindTerms(Label1.Text,lblid.Text);
                BindDetail(Label1.Text);
            }


        }

        catch (Exception ex)
        {
            ex.ToString();
        }
    }



    public void BindTerms(string noseries ,string id)
    {
        try
        {
            string result;


            DataTable dtdata = bll.getQuotationtermsandconditionsdatabyidBAL(noseries,id);
            if (dtdata.Rows.Count > 0)
            {
                txtName.Text = dtdata.Rows[0]["Termstitle"].ToString();
                Txttandc.Text = dtdata.Rows[0]["TermsDescription"].ToString();
                txtSequence.Text = dtdata.Rows[0]["Extra1"].ToString();
                txtName.Focus();
                BtnSave.Visible = false;
                BtnUpdate.Visible = true;
            }
        }



        catch (Exception ex)
        {
            ex.ToString();
        }
    }



    public void BindDetail(String id)
    {

        try
        {
            dt = bll.getallQuotationtermsandconditionsbyidBAL(id);


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

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bll.checktermsandconditionsdata(txtName.Text, txtSequence.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bll.Savetermsandconditionsbll(txtName.Text, Txttandc.Text, "", localTime, txtSequence.Text, "", "", "", "");

                txtSequence.Text = "";
                txtName.Text = "";
                Txttandc.Text = "";
                txtName.Focus();
                //Response.Redirect("TermsandConditions.aspx", false);
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Grddata_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string result;
            lblid.Text = e.CommandArgument.ToString();
            if (e.CommandName == "editdata")
            {
                DataTable dtdata = bll.gettermsandconditionsdatabyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    txtName.Text = dtdata.Rows[0]["Title"].ToString();
                    Txttandc.Text = dtdata.Rows[0]["TermsandConditions"].ToString();
                    txtSequence.Text = dtdata.Rows[0]["Extra1"].ToString();
                    txtName.Focus();
                    BtnSave.Visible = false;
                    BtnUpdate.Visible = true;

                }
            }
            else if (e.CommandName == "deletedata")
            {

                result = bll.deletetermsandconditionsdata(lblid.Text);

                ShowMessage("Record Deleted!!!", MessageType.Success);



                BtnSave.Visible = true;
                BtnUpdate.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            bll.tbl_Quotationtermsandconditionsupdate(lblid.Text, txtName.Text, Txttandc.Text, Label1.Text, txtSequence.Text);
            txtSequence.Text = "";
            txtName.Text = "";
            Txttandc.Text = "";
            txtName.Focus();
            BtnSave.Visible = true;
            BtnUpdate.Visible = false;
            
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

}