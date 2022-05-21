using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class UpdateCompany : System.Web.UI.Page
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
                bindbusstype();
                bindIndustry();
                binddepartment();
                binddesignation();
                txtName.Focus();
                bindcontactdata();
                bindCompanyImage();
                bindCompanyBanner();
                filldata();
                lblmsg.Text = "";
                lblmsg1.Text = "";
                lblmsg2.Text = "";
                lblmsg3.Text = "";
                lblmsg4.Text = "";
                lblmsg5.Text = "";

            }
        }

    }
    protected void bindCompanyBanner()
    {
        DataTable dtdata = bal.getcompanybannerbyno(lblcomno.Text);
        grdbanner.DataSource = dtdata;
        grdbanner.DataBind();

    }
    public void filldata()
    {
        try
        {
            DataTable dtdata = bal.getallcompanydatabycomnoBAL(lblcomno.Text);
            if (dtdata.Rows.Count > 0)
            {
                txtName.Text = dtdata.Rows[0]["Name"].ToString();
                txtaddress.Text = dtdata.Rows[0]["Address"].ToString();
                txtcity.Text = dtdata.Rows[0]["City"].ToString();
                txtstate.Text = dtdata.Rows[0]["State"].ToString();
                txtdistrict.Text = dtdata.Rows[0]["District"].ToString();
                txtcountry.Text = dtdata.Rows[0]["Country"].ToString();
                txtpincode.Text = dtdata.Rows[0]["Pincode"].ToString();
                txtphno.Text = dtdata.Rows[0]["PhoneNo"].ToString();
                txtemail.Text = dtdata.Rows[0]["Email"].ToString();
                dpbusstype.SelectedValue=dtdata.Rows[0]["BussinessType"].ToString();
                dpindustry.SelectedValue = dtdata.Rows[0]["Industrygroup"].ToString();
                txturl.Text = dtdata.Rows[0]["URL"].ToString();
                rbtnstatus.SelectedItem.Text = dtdata.Rows[0]["Status"].ToString();
                txtgstno.Text = dtdata.Rows[0]["GSTno"].ToString();
                txtbankname.Text = dtdata.Rows[0]["Bankname"].ToString();
                txtaccno.Text = dtdata.Rows[0]["Accountno"].ToString();
                txtifsccode.Text = dtdata.Rows[0]["IFSCcode"].ToString();
                txtcountry.Text = dtdata.Rows[0]["Country"].ToString();

            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void bindCompanyImage()
    {
        DataTable dtdata = bal.getcompanyimagebyno(lblcomno.Text);
        gvImages.DataSource = dtdata;
        gvImages.DataBind();

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
            dt1 = bal.checkcompanycontactnameBAL(lblcomno.Text, txtcontactname.Text, txtcontactemail.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
                //lblmsg1.Text = "Name Already Exist!!!";
            }
            else
            {
              
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                bal.tbl_Company_Contact_Master_InsertBAL(lblcomno.Text, txtcontactname.Text, txtcontactemail.Text, txtcontactphno.Text, txtcontactmno1.Text, txtcontactmno2.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesign.SelectedValue.ToString()), lblloginid.Text, localTime, txtdob.Text, txtdoani.Text, "", "", "");
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
    public void lbtnreset_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            lblmsg1.Text = "";
            lblmsg2.Text = "";
            lblmsg3.Text = "";
            lblmsg4.Text = "";
            lblmsg5.Text = "";
            txtbtypename.Text = "";
            txtgroupname.Text = "";
            txtdeptname.Text = "";
            txtdesign.Text = "";



        }
        catch (Exception ex)
        {

        }
    }
    public void lbtndeletecomp_Click(object sender, EventArgs e)
    {
        try
        {
            bal.deletecompanydatabyCompanynoBAL(Convert.ToString(lblcomno.Text));
            Response.Redirect("CompanyRegister.aspx", false);



        }
        catch (Exception ex)
        {

        }
    }

    protected void lbtnresetcontact1_Click(object sender, EventArgs e)
    {
        try
        {
            resetcontact();
            txtName.Text = "";
            txtaddress.Text = "";
            txtcity.Text = "";
            txtdistrict.Text = "";
            txtstate.Text = "";
            txtcountry.Text = "";
            txtpincode.Text = "";
            txtphno.Text = "";
            txtemail.Text = "";
            dpbusstype.ClearSelection();
            dpindustry.ClearSelection();
            txturl.Text = "";
            txtgstno.Text = "";
            txtbankname.Text = "";
            txtaccno.Text = "";
            txtifsccode.Text = "";
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
            txtdob.Text = "";
            txtdoani.Text = "";

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
                DataTable dtdata = bal.getcompanycontactdatabyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    txtcontactname.Text = dtdata.Rows[0]["ContactName"].ToString();
                    txtcontactemail.Text = dtdata.Rows[0]["ContactEmail"].ToString();
                    txtcontactphno.Text = dtdata.Rows[0]["ContactPhone"].ToString();
                    txtcontactmno1.Text = dtdata.Rows[0]["ContactMobileno1"].ToString();
                    txtcontactmno2.Text = dtdata.Rows[0]["ContactMobileno2"].ToString();
                    txtdob.Text = dtdata.Rows[0]["Extra1"].ToString();
                    txtdoani.Text = dtdata.Rows[0]["Extra2"].ToString();
                    string deptvalule = dtdata.Rows[0]["Dept"].ToString();
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

                result = bal.deletecompanycontactdatabyidBAL(lblid.Text);

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
    protected void lbtnupdatecontact_Click(object sender, EventArgs e)
    {
        try
        {

            
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

            string result = bal.tbl_Company_Contact_Master_updateBAL(Convert.ToInt32(lblid.Text), txtcontactname.Text, txtcontactemail.Text, txtcontactphno.Text, txtcontactmno1.Text, txtcontactmno2.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesign.SelectedValue.ToString()), lblloginid.Text, localTime, txtdob.Text, txtdoani.Text, "", "", "");
            if (result == "-1")
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {
                resetcontact();
                bindcontactdata();
                ShowMessage("Record Updated!!!", MessageType.Success);

                txtcontactname.Focus();
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
            dtcontact = bal.getcompanycontactdataBAL( Convert.ToInt32(lblcomno.Text));
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

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
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
           
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);


            bal.tbl_Company_Master_updateBAL(lblcomno.Text, txtName.Text, "", txtaddress.Text, txtcity.Text, txtstate.Text, txtdistrict.Text,txtcountry.Text, txtpincode.Text, txtphno.Text, txtemail.Text, Convert.ToInt32(dpbusstype.SelectedValue.ToString()), Convert.ToInt32(dpindustry.SelectedValue.ToString()), txturl.Text, rbtnstatus.SelectedItem.Text, txtgstno.Text, txtbankname.Text, txtaccno.Text, txtifsccode.Text, lblloginid.Text, localTime, "", "", "", "", "");

            Response.Redirect("CompanyRegister.aspx", false);
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            bal.deletecompanydatabyCompanynoBAL(lblcomno.Text);
            Response.Redirect("CompanyRegister.aspx", false);
        }
        catch(Exception ex)
        {

        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CompanyRegister.aspx", false);
        }
        catch(Exception ex)
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
               // lblmsg.Text = "Name Already Exist!!!";
                mpbtype.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.SaveBussinessTypeMasterBAL(txtbtypename.Text, lblloginid.Text, localTime, "", "", "", "", "");
                ShowMessage("Record Save!!!", MessageType.Success);
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
              //  lblmsg2.Text = "Name Already Exist!!!";
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
               // lblmsg2.Text = "Record Save!!!";
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
               // lblmsg3.Text = "Name Already Exist!!!";
                pnldept.Focus();
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
               // lblmsg3.Text = "Record Save!!!";
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
               // lblmsg4.Text = "Name Already Exist!!!";
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
               // lblmsg4.Text = "Record Save!!!";
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
    public static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }


    protected void btnaddCompanyImage_Click(object sender, EventArgs e)
    {

        try
        {


            if (fuCompanyImage.HasFile)
            {
                string randomfilename = RandomString(10);

                string fileName = Path.GetFileName(fuCompanyImage.FileName);
                string extention = Path.GetExtension(fuCompanyImage.FileName);
                fuCompanyImage.SaveAs(Server.MapPath("~/Documents/") + randomfilename + extention);
                string filepath = "~/Documents/" + randomfilename + extention;

                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Company_Image_InsertBAL(lblcomno.Text, "", randomfilename, filepath, lblloginid.Text, localTime, "", "", "", "", "");
                bindCompanyImage();
            }

        }
        catch (Exception ex)
        {

        }

    }

    protected void btnaddbanner_Click(object sender, EventArgs e)
    {
        try
        {

            if (FileUpload1.HasFile)
            {
                string randomfilename = RandomString(10);

                string fileName = Path.GetFileName(FileUpload1.FileName);
                string extention = Path.GetExtension(FileUpload1.FileName);
                //FileUpload1.SaveAs(Server.MapPath("~/CompanyBanner/") + randomfilename + extention);



                BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream);
                byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);

                //Convert the Byte Array to Base64 Encoded string.
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                //***Save Base64 Encoded string as Image File***//

                //Convert Base64 Encoded string to Byte Array.
                byte[] imageBytes = Convert.FromBase64String(base64String);

                //Save the Byte Array as Image File.
                string filepath = "~/CompanyBanner/" + randomfilename + extention;
                //File.WriteAllBytes(filepath, imageBytes);
                FileUpload1.SaveAs(Server.MapPath("~/CompanyBanner/") + randomfilename + extention);

                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Company_Banner_InsertBAL(lblcomno.Text, "", randomfilename, filepath, lblloginid.Text, localTime, base64String, "", "", "", "");
                bindCompanyBanner();
            }
            else
            {
                ShowMessage("Please Select Image!!!", MessageType.Error);
            }
        }
        catch (Exception ex)
        {

        }
    }
}