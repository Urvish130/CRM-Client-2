using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class CustomerGroup : System.Web.UI.Page
{
    BusinessLogicLayer bal = new BusinessLogicLayer();
    public enum MessageType { Success, Error, Info, Warning };

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
                getmaxcomno();
                bindbusstype();
                bindIndustry();
                binddepartment();
                binddesignation();
                txtName.Focus();
                lblmsg.Text = "";
                lblmsg1.Text = "";
                lblmsg2.Text = "";
                lblmsg3.Text = "";
                lblmsg4.Text = "";
                
            }
        }
    }

    public string getmaxcomno()
    {
        string s = string.Empty, id = string.Empty;
        Getconnection c = new Getconnection();
        try
        {
            string s1 = "select Top (1) No from tbl_CustomerGroup_NoSeries    order By  Id DESC";
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
            bal.tbl_CustomerGroup_NoSeries_InsertBAL(s, "", "");
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
    public void bindbusstype()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getallBussinessTypeforadminBAL();
            if (dtbtype.Rows.Count > 0)
            {
                dpbusstype.DataSource = dtbtype;
                dpbusstype.DataTextField = "BussType";
                dpbusstype.DataValueField = "Id";
                dpbusstype.DataBind();
            }
            dpbusstype.Items.Insert(0, new ListItem("----Select BussinessType----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    public void bindIndustry()
    {
        try
        {
            DataTable dtindustry = new DataTable();


            dtindustry = bal.getallIndustrygroupfroadminBAL();
            if (dtindustry.Rows.Count > 0)
            {
                dpindustry.DataSource = dtindustry;
                dpindustry.DataTextField = "GroupName";
                dpindustry.DataValueField = "Id";
                dpindustry.DataBind();
            }
            dpindustry.Items.Insert(0, new ListItem("----Select Industrytype----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
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
            dt1 = bal.checkcustomergroupcontactnameBAL(lblcomno.Text, txtcontactname.Text, txtcontactemail.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {
               
                
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_CustomerGroup_Contact_Master_InsertBAL(lblcomno.Text, txtcontactname.Text, txtcontactemail.Text, txtcontactphno.Text, txtcontactmno1.Text, txtcontactmno2.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesign.SelectedValue.ToString()), lblloginid.Text, localTime, txtdob.Text, txtdoani.Text, "", "", "");
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
            txtdoani.Text = "";
            txtdob.Text = "";
        }
        catch (Exception ex)
        {

        }
    }
    public void lbtnresetindugroup_Click(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            lblmsg1.Text = "";
            lblmsg2.Text = "";
            lblmsg3.Text = "";

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
                DataTable dtdata = bal.getCustomerGroupcontactdatabyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    txtcontactname.Text = dtdata.Rows[0]["ContactName"].ToString();
                    txtcontactemail.Text = dtdata.Rows[0]["ContactEmail"].ToString();
                    txtcontactphno.Text = dtdata.Rows[0]["ContactPhone"].ToString();
                    txtcontactmno1.Text = dtdata.Rows[0]["ContactMobileno1"].ToString();
                    txtcontactmno2.Text = dtdata.Rows[0]["ContactMobileno2"].ToString();
                    txtdob.Text = dtdata.Rows[0]["Extra1"].ToString();
                    txtdoani.Text = dtdata.Rows[0]["Extra2"].ToString();
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

                result = bal.deleteCustomerGroupcontactdatabyidBAL(lblid.Text);

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


    public void bindcontactdata()
    {

        try
        {
          
            DataTable dtcontact = new DataTable();
            dtcontact = bal.getCustomerGroupcontactdataBAL(Convert.ToInt32(lblcomno.Text));
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
    protected void lbtnupdatecontact_Click(object sender, EventArgs e)
    {
        try
        {

          
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

           string result = bal.tbl_CustomerGroup_Contact_Master_updateBAL(Convert.ToInt32(lblid.Text), txtcontactname.Text, txtcontactemail.Text, txtcontactphno.Text, txtcontactmno1.Text, txtcontactmno2.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesign.SelectedValue.ToString()), lblloginid.Text, localTime, txtdob.Text, txtdoani.Text, "", "", "");
            if(result == "-1")
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
               // ShowMessage("Record Save!!!", MessageType.Success);
            }

            

        }
        catch (Exception ex)
        {

        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    public void lbtndesignreset_Click(object sender, EventArgs e)
    {
        try
        {
            txtdesign.Text = "";
            lblmsg.Text = "";
            lblmsg1.Text = "";
            lblmsg2.Text = "";
            txtdeptname.Text="";
            txtbtypename.Text = "";
            txtgroupname.Text = "";


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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkCustomerGroup_Master_nameBAL(txtbtypename.Text);
            if (dt1.Rows.Count > 0)
            {
               

                ShowMessage("Name Already Exist!!!", MessageType.Error);
               // lblmsg4.Text = "Name Already Exist!!!";
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);


                bal.tbl_CustomerGroup_Master_InsertBAL(lblcomno.Text, txtName.Text, "", txtaddress.Text, txtcity.Text, txtstate.Text, txtdistrict.Text, txtcountry.Text, txtpincode.Text, txtphno.Text, txtemail.Text, Convert.ToInt32(dpbusstype.SelectedValue.ToString()), Convert.ToInt32(dpindustry.SelectedValue.ToString()), txturl.Text, rbtnstatus.SelectedItem.Text, txtgstno.Text, txtbankname.Text, txtaccno.Text, txtifsccode.Text, lblloginid.Text, localTime, "", "", "", "", "");

                Response.Redirect("CustomerGroupRegister.aspx", false);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void lbtncbytype_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkBussinessTypenameBAL(txtbtypename.Text);
            if (dt1.Rows.Count > 0)
            {
                
            
                ShowMessage("Name Already Exist!!!", MessageType.Error);
                //lblmsg.Text = "Name Already Exist!!!";
                mpbtype.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.SaveBussinessTypeMasterBAL(txtbtypename.Text, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                //lblmsg.Text = "Record Save!!!";
                bindbusstype();
                txtbtypename.Text = "";
                txtbtypename.Focus();
                mpbtype.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }

    protected void lbtncreateindugroup_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkIndustrygroupnamebal(txtgroupname.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
                //lblmsg1.Text = "Name Already Exist!!!";
                mpindutype.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.SaveIndustrygroupMasterBAL(txtgroupname.Text, lblloginid.Text, localTime, "", "", "", "", "");
                bindIndustry();
                ShowMessage("Record Save!!!", MessageType.Success);
               // lblmsg1.Text = "Record Save!!!";
                txtgroupname.Text = "";
                txtgroupname.Focus();
                mpindutype.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
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
               // lblmsg2.Text = "Name Already Exist!!!";
                mpdept.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Department_Master_InsertBAL(txtdeptname.Text, lblloginid.Text, localTime, "", "", "", "", "");
                binddepartment();
                ShowMessage("Record Save!!!", MessageType.Success);
                //lblmsg2.Text = "Record Save!!!";
               txtdeptname.Text = "";
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
              //  lblmsg3.Text = "Name Already Exist!!!";
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
               // lblmsg3.Text = "Record Save!!!";
               txtdesign.Text = "";
                txtdesign.Focus();
                mpdesign.Show();
                //mpdesign.Hide();
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
        txtName.Text = "";
        txtaddress.Text = "";
        txtcity.Text = "";
        txtdistrict.Text = "";
        txtstate.Text = "";
        txtcountry.Text = "";
        txtpincode.Text = "";
        txtphno.Text = "";
        txtemail.Text = "";
        txturl.Text = "";
        txtgstno.Text = "";
        txtbankname.Text = "";
        txtaccno.Text = "";
        txtifsccode.Text = "";
       
        dpindustry.ClearSelection();
        dpbusstype.ClearSelection();
        resetcontact();

    }
}