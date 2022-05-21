using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class DistributorRegister : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    BusinessLogicLayer bal = new BusinessLogicLayer();
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
                lblrole.Text = Session["role"].ToString();
                bindDetail();
            }
        }
    }

    public void bindDetail()
    {

        try
        {
            if (lblrole.Text.Equals("admin"))
            {
                dt = bal.getallemployeedataforadminBAL();
            }
            else
            {

                dt = bal.getallemployeedataforadminBAL();
            }
           
            
          
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
            lblid.Text = e.CommandArgument.ToString();
            if (e.CommandName == "editdata")
            {
                Response.Redirect(String.Format("UpdateDistributor.aspx?no={0}", lblid.Text), false);
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void btncreate_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Distributor.aspx", false);
        }
        catch (Exception ex)
        {

        }
    }
}