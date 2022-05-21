using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    if (Session["no"] == null)
        //    {
        //        Response.Redirect("Default.aspx", false);
        //    }
        //    else
        //    {
        //        lbllname.Text = Session["Ename"].ToString();
        //    }
        //}
    }
}
