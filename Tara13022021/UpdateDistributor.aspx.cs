using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
public partial class UpdateDistributor : System.Web.UI.Page
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
                lblcomno.Text = Request.QueryString["no"].ToString();
                lblrole.Text = Session["role"].ToString();
                binddepartment();
                bindCompnay();
                binddesignation();
                bindrole();
                binddocument();
                filldata();
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
            

           
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

            if(txtbulkpassword.Text =="")
            {
                txtbulkpassword.Text = lblbulkpassword.Text;
            }
            if (txtPwd.Text == "")
            {
                txtPwd.Text = lblpassword.Text;
            }
           DataTable dt1 = bal.checkEmployee_master_EmailBAL(lblcomno.Text, txtEmail.Text, ddlcompany.SelectedValue);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Email ID Already Exist!!!", MessageType.Error);
                //lblmsg3.Text = "Name Already Exist!!!";
            }
            string result = bal.tbl_Employee_master_UpdateBAL(lblcomno.Text, txtName.Text, txtfhname.Text, txtsurname.Text, ddlgen.SelectedValue.ToString(), txtpaddress.Text, txtperaddress.Text,txtcity.Text,txtstate.Text,txtdistrict.Text,txtcountry.Text,txtpincode.Text,txtphno.Text , txtpmobileno.Text, txtmobileoffice.Text, txtmobilenowhatsup.Text, ddlRole.SelectedValue.ToString(), txtpfno.Text, txtdoa.Text, txtdoj.Text, txtdol.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesignation.SelectedValue.ToString()), txtEmail.Text, txtPwd.Text, txtecontatname.Text, txtecontactno.Text, txtcontactrelation.Text, rdbStatus.SelectedItem.Text, txtbankname.Text, txtaccno.Text, txtifsccode.Text, lblloginid.Text, localTime, txtdob.Text, txtdoani.Text, txtbulkemail.Text, txtbulkpassword.Text,ddlcompany.SelectedValue);
            if(result == "-1")
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {
                Response.Redirect("DistributorRegister.aspx", false);

            }
           
        }
        catch (Exception ex)
        {

        }
    }


    public void filldata()
    {
        try
        {
            DataTable dtdata = bal.getemployeedatanoBAL(lblcomno.Text);
            if (dtdata.Rows.Count > 0)
            {
                txtName.Text = dtdata.Rows[0]["Ename"].ToString();
                txtfhname.Text = dtdata.Rows[0]["Efname"].ToString();
                txtsurname.Text = dtdata.Rows[0]["Esurname"].ToString();
                ddlgen.SelectedValue = dtdata.Rows[0]["Egender"].ToString();
                txtpaddress.Text = dtdata.Rows[0]["Epaddress"].ToString();
                txtperaddress.Text = dtdata.Rows[0]["Eperaddress"].ToString();

                txtcity.Text = dtdata.Rows[0]["ECity"].ToString();
                txtdistrict.Text = dtdata.Rows[0]["EDistrict"].ToString();
                txtstate.Text = dtdata.Rows[0]["EState"].ToString();
                txtcountry.Text = dtdata.Rows[0]["ECountry"].ToString();
                txtpincode.Text = dtdata.Rows[0]["EPincode"].ToString();
                txtphno.Text = dtdata.Rows[0]["EPhoneNo"].ToString();

                txtpmobileno.Text = dtdata.Rows[0]["Emobilenop"].ToString();

                txtmobileoffice.Text = dtdata.Rows[0]["Emobileoffice"].ToString();
                txtmobilenowhatsup.Text = dtdata.Rows[0]["Emobilewhatsup"].ToString();
                ddlRole.SelectedValue = dtdata.Rows[0]["Erole"].ToString();
                txtpfno.Text = dtdata.Rows[0]["Epfno"].ToString();
                txtdoa.Text = dtdata.Rows[0]["Edoa"].ToString();
                txtdoj.Text = dtdata.Rows[0]["Edoj"].ToString();
                txtdol.Text = dtdata.Rows[0]["Edol"].ToString();
                ddlDept.SelectedValue = dtdata.Rows[0]["Edept"].ToString();
                ddldesignation.SelectedValue = dtdata.Rows[0]["Edesign"].ToString();


                txtEmail.Text = dtdata.Rows[0]["Eemailid"].ToString();
                lblpassword.Text = dtdata.Rows[0]["Epwd"].ToString();
                txtecontatname.Text = dtdata.Rows[0]["Eurgentcontactname"].ToString();
                txtecontactno.Text = dtdata.Rows[0]["Eurgentcontactno"].ToString();
                txtcontactrelation.Text = dtdata.Rows[0]["Eurgentcontactrelation"].ToString();
                txtcontactrelation.Text = dtdata.Rows[0]["Eurgentcontactrelation"].ToString();
                rdbStatus.SelectedItem.Text = dtdata.Rows[0]["Estatus"].ToString();

                txtbankname.Text = dtdata.Rows[0]["Ebankname"].ToString();
                txtaccno.Text = dtdata.Rows[0]["Eaccno"].ToString();

                txtifsccode.Text = dtdata.Rows[0]["Eifsccode"].ToString();
                txtdob.Text = dtdata.Rows[0]["Extra1"].ToString();
                txtdoani.Text = dtdata.Rows[0]["Extra2"].ToString();
                txtbulkemail.Text = dtdata.Rows[0]["Extra3"].ToString();
                lblbulkpassword.Text = dtdata.Rows[0]["Extra4"].ToString();
                ddlcompany.SelectedValue= dtdata.Rows[0]["Extra5"].ToString();

            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            bal.deleteemployeedatabynoBAL(lblcomno.Text);
            Response.Redirect("DistributorRegister.aspx", false);
        }
        catch (Exception ex)
        {

        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("DistributorRegister.aspx", false);
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
               // lblmsg1.Text = "Name Already Exist!!!";
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
               // lblmsg2.Text = "Name Already Exist!!!";
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
               // lblmsg2.Text = "Record Save!!!";
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
        Response.Redirect("DistributorRegister.aspx", false);
    }
    protected void btndeleteee(object sender, EventArgs e)
    {
        bal.deleteemployeedatabynoBAL(lblcomno.Text);
        Response.Redirect("DistributorRegister.aspx", false);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string URL = "Company.aspx";
        Response.Write("<script type='text/javascript'>window.open('" + URL + "');</script>");
        //Response.Redirect("Default.aspx", false);
    }
}