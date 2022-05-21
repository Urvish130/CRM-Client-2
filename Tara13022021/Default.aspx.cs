using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class _Default : System.Web.UI.Page
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
                
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checklogindetailsBAL(txtuname.Text,txtpwd.Text);
            if (dt1.Rows.Count > 0)
            {
                Session["no"] = dt1.Rows[0]["no"].ToString();
                Session["Ename"] = dt1.Rows[0]["Ename"].ToString();
                Session["role"] = dt1.Rows[0]["Erole"].ToString();
                Session["rolename"] = dt1.Rows[0]["RoleName"].ToString();
                Session["Companyno"] = dt1.Rows[0]["Extra5"].ToString();
                Response.Redirect("Dashboard.aspx", false);

            }
            else
            {
                ShowMessage("Invalid username and password!!", MessageType.Error);
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
}