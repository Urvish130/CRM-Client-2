using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Complaint : System.Web.UI.Page
{
    BusinessLogicLayer bal = new BusinessLogicLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindassignto();
            bindcustgroup();
            getmaxcomno();
            getInquiryNo();
            bindstatus();
            binddepartment();
            binddesignation();
        }
    }

    public void bindassignto()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getallemployenameforadminBAL();
            if (dtbtype.Rows.Count > 0)
            {
                dpassignto.DataSource = dtbtype;
                dpassignto.DataTextField = "Ename";
                dpassignto.DataValueField = "Id";
                dpassignto.DataBind();
            }
            dpassignto.Items.Insert(0, new ListItem("----Select Employe Name----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }


    public void bindcustgroup()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getCustomerGroupNameBAL();
            if (dtbtype.Rows.Count > 0)
            {
                dpcustgroup.DataSource = dtbtype;
                dpcustgroup.DataTextField = "Name";
                dpcustgroup.DataValueField = "Groupno";
                dpcustgroup.DataBind();
            }
            dpcustgroup.Items.Insert(0, new ListItem("----Select Group----", "0"));

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
            string s1 = "select Top (1) No from tbl_Inquiry_No_Series    order By  Id DESC";
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
            bal.tbl_Inquiry_No_Series_InsertBAL(s, "", "");
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
    public string getInquiryNo()
    {
        string s = string.Empty, id = string.Empty;
        Getconnection c = new Getconnection();
        try
        {
            string s1 = "select Top (1) InqiuryNo from tbl_Inqiury_Master    order By  Id DESC";
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
            txtno.Text = s.ToString();
            //hfMaxEntryNo.Value = fid.ToString();

        }
        catch (Exception ex)
        {

            txtno.Text = "1";
        }
        finally
        {
            c.CloseConnection();
        }
        return s;
    }
    public void bindstatus()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getallstatusforadminBAL();
            if (dtbtype.Rows.Count > 0)
            {
                dpfollowstatus.DataSource = dtbtype;
                dpfollowstatus.DataTextField = "StatusName";
                dpfollowstatus.DataValueField = "Id";
                dpfollowstatus.DataBind();


                dpfollowstatus.DataSource = dtbtype;
                dpfollowstatus.DataTextField = "StatusName";
                dpfollowstatus.DataValueField = "Id";
                dpfollowstatus.DataBind();
            }
            dpfollowstatus.Items.Insert(0, new ListItem("----Select Status----", "0"));
           

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }

    protected void dpcustgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            try
            {
                DataTable dtbtype = new DataTable();


                dtbtype = bal.getCustomerNameBAL(dpcustgroup.SelectedValue.ToString());
                if (dtbtype.Rows.Count > 0)
                {
                    dpcust.DataSource = dtbtype;
                    dpcust.DataTextField = "Name";
                    dpcust.DataValueField = "No";
                    dpcust.DataBind();
                }
                dpcust.Items.Insert(0, new ListItem("----Select Customer----", "0"));

            }
            catch (Exception ex)
            {
                Getconnection.SiteErrorInsert(ex);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void dpcust_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dtbtype = new DataTable();

            Session["CustID"] = dpcust.SelectedValue.ToString();
            dtbtype = bal.getCustomerConatctPersonBAL(dpcust.SelectedValue.ToString());
            if (dtbtype.Rows.Count > 0)
            {
                dpcontactper.DataSource = dtbtype;
                dpcontactper.DataTextField = "ContactName";
                dpcontactper.DataValueField = "Id";
                dpcontactper.DataBind();
            }
            dpcontactper.Items.Insert(0, new ListItem("----Select Contact Person----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }

    }

    public void RefreshCustGroup(object sender, EventArgs e)
    {
        bindcustgroup();
    }

    public void RefreshAssignTo(object sender, EventArgs e)
    {
        bindassignto();
    }
    public void RefreshCustName(object sender, EventArgs e)
    {
        bindcustgroup();
    }
    public void RefreshCustCOntactGroup(object sender, EventArgs e)
    {
        dpcust.ClearSelection();
        bindcustgroup();
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
}