using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
public partial class Distributor : System.Web.UI.Page
{
    BusinessLogicLayer bal = new BusinessLogicLayer();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
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
                bindrole();
                binddepartment();
                bindCompnay();
                binddesignation();
                txtName.Focus();
                lblmsg.Text = "";
                lblmsg1.Text = "";
                lblmsg2.Text = "";
                lblmsg3.Text = "";
            }
        }

    }

    public void bindrole()
    {
        try
        {
            DataTable dtdept = new DataTable();


            dtdept = bal.getallRoleforadminBAL();
            if (dtdept.Rows.Count > 0)
            {
                ddlRole.DataSource = dtdept;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "Id";
                ddlRole.DataBind();
            }
            ddlRole.Items.Insert(0, new ListItem("----Select Role----", "0"));
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
    public void bindCompnay()
    {
        try
        {
            DataTable dtdept = new DataTable();


            dtdept = bal.getCompanyforadminBAL();
            if (dtdept.Rows.Count > 0)
            {
                ddlcompany.DataSource = dtdept;
                ddlcompany.DataTextField = "Name";
                ddlcompany.DataValueField = "Companyno";
                ddlcompany.DataBind();
            }
            ddlcompany.Items.Insert(0, new ListItem("----Select Company----", "0"));
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
                ddldesignation.DataSource = dtdesign;
                ddldesignation.DataTextField = "DesigName";
                ddldesignation.DataValueField = "Id";
                ddldesignation.DataBind();
            }
            ddldesignation.Items.Insert(0, new ListItem("----Select Designation----", "0"));
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
            string s1 = "select Top (1) No from tbl_Employee_NoSeries    order By  Id DESC";
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
            bal.tbl_Employee_NoSeries_InsertBAL(s, "", "");
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
    protected void grddocument_RowCommand(object sender, GridViewCommandEventArgs e)
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

            string result = bal.deleteemployeedocumentdatabyidBAL(e.CommandArgument.ToString());

            ShowMessage("Record Deleted!!!", MessageType.Success);

            binddocument();
         

        }
    }
    protected void lbtnadddocument_Click(object sender, EventArgs e)
    {
        try
        {


            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Documents/") + fileName);
                string filepath = "~/Documents/" + fileName;
                

                
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_Employee_Document_Master_InsertBAL(lblcomno.Text, txtdocument.Text, fileName, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
                txtdocument.Text = "";                
                binddocument();
                txtdocument.Focus();
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

    public void binddocument()
    {

        try
        {
            
            DataTable dtcontact = new DataTable();
            dtcontact = bal.getdocumentadataBAL();
            if (dtcontact.Rows.Count > 0)
            {
                grddocument.DataSource = dtcontact;
                grddocument.DataBind();
                grddocument.UseAccessibleHeader = true;
                grddocument.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grddocument.DataSource = dtcontact;
                grddocument.DataBind();
                grddocument.UseAccessibleHeader = true;
                grddocument.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    public void lbtnreset_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            lblmsg1.Text = "";
            lblmsg2.Text = "";
            lblmsg3.Text = "";
            txtdesign.Text = "";
            txtdeptname.Text = "";
            txtrolename.Text = "";




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
            dt1 = bal.checkEmployee_master_detailsBAL(txtName.Text, txtEmail.Text, ddlcompany.SelectedValue);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
                //lblmsg3.Text = "Name Already Exist!!!";
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);


              string result=  bal.tbl_Employee_master_InsertBAL(lblcomno.Text, txtName.Text, txtfhname.Text, txtsurname.Text, ddlgen.SelectedValue.ToString(), txtpaddress.Text, txtperaddress.Text, txtcity.Text, txtstate.Text, txtdistrict.Text, txtcountry.Text, txtpincode.Text, txtphno.Text, txtpmobileno.Text, txtmobileoffice.Text, txtmobilenowhatsup.Text, ddlRole.SelectedValue.ToString(), txtpfno.Text, txtdoa.Text, txtdoj.Text, txtdol.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesignation.SelectedValue.ToString()), txtEmail.Text, txtPwd.Text, txtecontatname.Text, txtecontactno.Text, txtcontactrelation.Text, rdbStatus.SelectedItem.Text, txtbankname.Text, txtaccno.Text, txtifsccode.Text, lblloginid.Text, localTime, txtdob.Text, txtdoani.Text, txtbulkemail.Text, txtbulkpassword.Text, ddlcompany.SelectedValue);
                if (result == "-1")
                {
                    ShowMessage("Email ID Already Exist!!!", MessageType.Error);
                }
                else
                {
                    Response.Redirect("DistributorRegister.aspx", false);
                }
               
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void lbtncrole_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkRolenameBAL(txtrolename.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
                //lblmsg.Text = "Name Already Exist!!!";
                mpindutype.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Role_Master_InsertBAL(txtrolename.Text, lblloginid.Text, localTime, "", "", "", "", "");
                bindrole();
                  ShowMessage("Record Save!!!", MessageType.Success);
                //lblmsg.Text = "Record Save!!!";
                mpindutype.Show();
                txtrolename.Text = "";
                txtrolename.Focus();
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
                //lblmsg1.Text = "Name Already Exist!!!";
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
                //lblmsg1.Text = "Record Save!!!";
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
                //lblmsg2.Text = "Name Already Exist!!!";
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
                //lblmsg2.Text = "Record Save!!!";
                txtdesign.Text = "";
                txtdesign.Focus();
                mpdesign.Show();
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
        txtfhname.Text = "";
        txtsurname.Text = "";
        txtpaddress.Text = "";
        txtperaddress.Text = "";
        txtcity.Text = "";
        txtdistrict.Text = "";
        txtstate.Text = "";
        txtcountry.Text = "";
        txtpincode.Text = "";
        txtphno.Text = "";
        txtmobilenowhatsup.Text = "";
        txtmobileoffice.Text = "";
        txtpfno.Text = "";
        txtEmail.Text = "";
        txtPwd.Text = "";
        txtecontatname.Text = "";
        txtcontactrelation.Text = "";
        txtbulkemail.Text = "";
        txtbulkpassword.Text = "";
        txtecontactno.Text = "";
        txtdob.Text = "";
        txtdocument.Text = "";
        txtdoj.Text = "";
        txtdol.Text = "";
        ddlDept.ClearSelection();
        ddldesignation.ClearSelection();
        ddlgen.ClearSelection();
        ddlRole.ClearSelection();
        FileUpload1.Dispose();
        txtdoa.Text = "";
        txtaccno.Text = "";
        txtbankname.Text = "";
        txtifsccode.Text = "";
        txtpmobileno.Text = "";
        txtdoani.Text ="";


    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string URL = "Company.aspx";
        Response.Write("<script type='text/javascript'>window.open('" + URL + "');</script>");
        //Response.Redirect("Default.aspx", false);
    }
}