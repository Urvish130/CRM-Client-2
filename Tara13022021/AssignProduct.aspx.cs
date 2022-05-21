using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class AssignProduct : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    BusinessLogicLayer bal = new BusinessLogicLayer();
    public enum MessageType { Success, Error, Info, Warning };
    Getconnection c = new Getconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["no"] == null)
            {
                Response.Redirect("Default.aspx", false);
            }
            else {

               
                lblloginid.Text = Session["no"].ToString();
            lblrole.Text = Session["role"].ToString();
            bind();
            divpri.Visible = true;
            divdistri.Visible = false;
            bindprincipal();
            bindsuppliers();
            getmaxcomno();
            bindDetail();
            GridView1.Visible = true;
            GridView2.Visible = false;
                }
        }
    }
      public void bindDetail()
    {

        try
        {
            //DataTable dtdata = new DataTable();
            // dtdata = bal.getallAllAssignProductforadminBAL();

            string OpnStock = "SELECT        No, Type,Name FROM            dbo.tbl_AssignProduct_Details GROUP BY No, Type,Name";
            SqlDataAdapter sda = new SqlDataAdapter(OpnStock, c.getconnection());
            DataTable strdt = new DataTable();
            sda.Fill(strdt);
              List<StockSummary> SOListitems = new List<StockSummary>();
            for (int i = 0; i < strdt.Rows.Count; i++)
            {
                StockSummary SOLOb = new StockSummary();
                SOLOb.No = strdt.Rows[i]["No"].ToString();
                SOLOb.Type = strdt.Rows[i]["Type"].ToString();
                string name =strdt.Rows[i]["name"].ToString();
                if (SOLOb.Type.Equals("Principal"))
                {
                    string getpname = "select Pname from tbl_Principal_Master where Id='" + name + "'";
                    SqlCommand cmd = new SqlCommand(getpname, c.getconnection());
                    SOLOb.name = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    string getpname = "select Name from tbl_Supplier_Master where Id='" + name + "'";
                    SqlCommand cmd = new SqlCommand(getpname, c.getconnection());
                    SOLOb.name = cmd.ExecuteScalar().ToString();
                }

                SOListitems.Add(SOLOb);
            }
            grddata.DataSource = SOListitems;
            grddata.DataBind();

         
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }

    public void bindprincipal()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getallPrincipalforadminBAL();
            if (dtbtype.Rows.Count > 0)
            {
                dpprincipal.DataSource = dtbtype;
                dpprincipal.DataTextField = "Pname";
                dpprincipal.DataValueField = "Id";
                dpprincipal.DataBind();
            }
            dpprincipal.Items.Insert(0, new ListItem("----Select Principal----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }

    public string getmaxcomno()
    {
        string s = string.Empty, id = string.Empty;
        Getconnection c = new Getconnection();
        try
        {
            string s1 = "select Top (1) No from tbl_AssignProduct_NoSeries    order By  Id DESC";
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
            lblno.Text = s.ToString();
            //hfMaxEntryNo.Value = fid.ToString();
            bal.tbl_AssignProduct_NoSeries_InsertBAL(s, "", "");
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

    public void bindsuppliers()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getallSuppliersforadminBAL();
            if (dtbtype.Rows.Count > 0)
            {
                dlsupplier.DataSource = dtbtype;
                dlsupplier.DataTextField = "name";
                dlsupplier.DataValueField = "Id";
                dlsupplier.DataBind();
            }
            dlsupplier.Items.Insert(0, new ListItem("----Select Supplier----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    public void bind()
    {
        try
        {

            string s = "select * from tbl_Item_Master";
            SqlDataAdapter da = new SqlDataAdapter(s, c.getconnection());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void grddata_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string result;
        lblno.Text = e.CommandArgument.ToString();
        if (e.CommandName == "editdata")
        {
            

            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

            Label lbltype = row.FindControl("lbltype") as Label;
           // Label lbltype = (Label)grddata.Rows[index].FindControl("lbltype");
           // Label lblsuname = (Label)grddata.Rows[index].FindControl("lblsuname");
            Label lblsuname = row.FindControl("lblsuname") as Label;
            //rbtntype.SelectedItem.Text = lbltype.Text;
            if (lbltype.Text.Equals("Principal"))
            {
                dpprincipal.SelectedItem.Text = lblsuname.Text;

                rbtntype.Items.FindByValue("1").Selected = true;
                rbtntype.Items.FindByValue("2").Selected = false;


                divpri.Visible = true;
                divdistri.Visible = false;


            }
            else
            {
                rbtntype.Items.FindByValue("1").Selected = false;
                rbtntype.Items.FindByValue("2").Selected = true;
                dlsupplier.SelectedItem.Text = lblsuname.Text;
                divpri.Visible = false;
                divdistri.Visible = true;
            }



            dt = bal.getallassignproductitemforadminBAL(lblno.Text);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
                GridView2.UseAccessibleHeader = true;
                GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
                GridView2.Visible = true;
                GridView1.Visible = false;
            }
            else
            {
                GridView2.Visible = true;
                GridView1.Visible = false;
                GridView2.DataSource = dt;
                GridView2.DataBind();
                GridView2.UseAccessibleHeader = true;
                GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        else if (e.CommandName == "deletedata")
        {

            result = bal.deleteAssignproductdetailsdatabyidBAL(lblno.Text);
            ShowMessage("Record Deleted!!!", MessageType.Success);


            bindDetail();
            btnSave.Visible = true;
            btnUpdate.Visible = false;

        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
            int name=0;
            if (rbtntype.SelectedItem.Text.Equals("Principal"))
            {
                name = Convert.ToInt32(dpprincipal.SelectedValue.ToString());
            }
            else
            {
                name =Convert.ToInt32(dlsupplier.SelectedValue.ToString());
            }

           // bal.tbl_AssignProduct_Master_InsertDAL(lblno.Text, rbtntype.SelectedItem.Text, name, lblloginid.Text, localTime, "", "", "", "", "");

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string checkvalue;

                    string lblItemname = ((Label)row.FindControl("lblItemname")).Text;
                    string itemid = bal.getitemidbynameBAL(lblItemname.ToString());
                    CheckBox chkRow = (row.Cells[0].FindControl("checkvalue") as CheckBox);

                    if (chkRow.Checked)
                    {
                        checkvalue = "True";
                    }
                    else
                    {
                        checkvalue = "False";
                    }

                    bal.tbl_AssignProduct_Details_InsertBAL(lblno.Text, rbtntype.SelectedItem.Text,name, Convert.ToInt32(itemid), checkvalue, lblloginid.Text, localTime, "", "", "", "", "");
                    bindDetail();
                   
                }
            }
            ShowMessage("Record Save!!!", MessageType.Success);
        }
        catch(Exception ex)
        {

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
             bal.deleteAssignproductdetailsdatabyidBAL(lblno.Text);

             DateTime utcTime = DateTime.UtcNow;
             TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
             DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
             int name = 0;
             if (rbtntype.SelectedItem.Text.Equals("Principal"))
             {
                 name = Convert.ToInt32(dpprincipal.SelectedValue.ToString());
             }
             else
             {
                 name = Convert.ToInt32(dlsupplier.SelectedValue.ToString());
             }

             // bal.tbl_AssignProduct_Master_InsertDAL(lblno.Text, rbtntype.SelectedItem.Text, name, lblloginid.Text, localTime, "", "", "", "", "");

             foreach (GridViewRow row in GridView2.Rows)
             {
                 if (row.RowType == DataControlRowType.DataRow)
                 {
                     string checkvalue;

                     string lblItemname = ((Label)row.FindControl("lblItemname")).Text;
                     string itemid = bal.getitemidbynameBAL(lblItemname.ToString());
                     CheckBox chkRow = (row.Cells[0].FindControl("checkvalue") as CheckBox);

                     if (chkRow.Checked)
                     {
                         checkvalue = "True";
                     }
                     else
                     {
                         checkvalue = "False";
                     }

                     bal.tbl_AssignProduct_Details_InsertBAL(lblno.Text, rbtntype.SelectedItem.Text, name, Convert.ToInt32(itemid), checkvalue, lblloginid.Text, localTime, "", "", "", "", "");
                   
                }
             }
             bindDetail();
             GridView1.Visible = true;
             GridView2.Visible = false;
             btnSave.Visible = true;
             btnUpdate.Visible = false;
             dlsupplier.ClearSelection();
             dpprincipal.ClearSelection();
            ShowMessage("Record Save!!!", MessageType.Success);

        }
        catch(Exception ex)
        {

        }

    }

    protected void rbtntype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbtntype.SelectedItem.Text.Equals("Principal"))
            {
                divpri.Visible = true;
                divdistri.Visible = false;
            }
            else
            {
                divpri.Visible = false;
                divdistri.Visible = true;
            }
        
        }
        catch(Exception ex)
        {

        }
    }


   
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            CheckBox chk = (CheckBox)e.Row.FindControl("checkvalue");
            if (chk.Text.Equals("True"))
            {
                chk.Checked = true;
                chk.Text = "";
            }
            else
            {
                chk.Checked = false;
                chk.Text = "";
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssignProduct.aspx");

    }
}