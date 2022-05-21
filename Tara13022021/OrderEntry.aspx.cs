using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderEntry : System.Web.UI.Page
{
    BusinessLogicLayer bll = new BusinessLogicLayer();
    BusinessLogicLayer bal = new BusinessLogicLayer();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["no"] == null)
                {
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    string zoneId = "India Standard Time";
                    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
                    DateTime now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi);
                   // txtfdate.Text = now.ToString("dd/MM/yyyy");
                    txtdate.Text = now.ToString("dd/MM/yyyy");
                    TextBox1.Text= now.ToString("dd/MM/yyyy");
                    lblloginid.Text = Session["no"].ToString();
                    lblrole.Text = Session["role"].ToString();
                    bindcustgroup();
                    bindstatus();
                    bindsource();
                   // bindfollowup();
                   // bindassignto();
                    binditem();
                    binduom();
                    binddepartment();
                    binddesignation();
                    getInquiryNo();
                    getmaxcomno();
                  
                }
            }
            catch (Exception ex)
            {

            }




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
                dpstatus.DataSource = dtbtype;
                dpstatus.DataTextField = "StatusName";
                dpstatus.DataValueField = "Id";
                dpstatus.DataBind();


              //  dpfollowstatus.DataSource = dtbtype;
              //  dpfollowstatus.DataTextField = "StatusName";
              //  dpfollowstatus.DataValueField = "Id";
            //    dpfollowstatus.DataBind();
            }
            dpstatus.Items.Insert(0, new ListItem("----Select Status----", "0"));
          //  dpfollowstatus.Items.Insert(0, new ListItem("----Select Status----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }


    public void bindsource()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getallsourceforadminBAL();
            if (dtbtype.Rows.Count > 0)
            {
                dpsource.DataSource = dtbtype;
                dpsource.DataTextField = "SourceName";
                dpsource.DataValueField = "Id";
                dpsource.DataBind();
            }
            dpsource.Items.Insert(0, new ListItem("----Select Source----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }


    public void binduom()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getallunitforadminBAL();
            if (dtbtype.Rows.Count > 0)
            {
                dpuom.DataSource = dtbtype;
                dpuom.DataTextField = "Uom";
                dpuom.DataValueField = "Id";
                dpuom.DataBind();
            }
            dpuom.Items.Insert(0, new ListItem("----Select UOM----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }




    public void binditem()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getallItemadminBAL();
            if (dtbtype.Rows.Count > 0)
            {
                dpitem.DataSource = dtbtype;
                dpitem.DataTextField = "Itemname";
                dpitem.DataValueField = "Id";
                dpitem.DataBind();
            }
            dpitem.Items.Insert(0, new ListItem("----Select Item----", "0"));

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
    protected void dpitem_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // getsupplierbyasssignBAL

            DataTable dtbtype = new DataTable();
            DataTable dtbtype1 = new DataTable();




            dtbtype = bal.getsupplierbyasssignBAL(dpitem.SelectedValue.ToString());
            if (dtbtype.Rows.Count > 0)
            {
                dpsuppliers.DataSource = dtbtype;
                dpsuppliers.DataTextField = "Name";
                dpsuppliers.DataValueField = "Id";
                dpsuppliers.DataBind();
            }
            else
            {

                dtbtype.Clear();
                dtbtype.Rows.Clear();
                dpsuppliers.DataSource = dtbtype;
                dpsuppliers.DataTextField = "Name";
                dpsuppliers.DataValueField = "Id";
                dpsuppliers.DataBind();
            }
            dpsuppliers.Items.Insert(0, new ListItem("----Select Supplier----", "0"));






            dtbtype1 = bal.getprincipalbyasssignBAL(dpitem.SelectedValue.ToString());
            if (dtbtype1.Rows.Count > 0)
            {
                dpprincipal.DataSource = dtbtype1;
                dpprincipal.DataTextField = "Pname";
                dpprincipal.DataValueField = "Id";
                dpprincipal.DataBind();
            }
            else
            {
                dtbtype1.Clear();
                dtbtype1.Rows.Clear();
                dpprincipal.DataSource = dtbtype1;
                dpprincipal.DataTextField = "Pname";
                dpprincipal.DataValueField = "Id";
                dpprincipal.DataBind();
            }
            dpprincipal.Items.Insert(0, new ListItem("----Select Pricipal----", "0"));


        }
        catch (Exception ex)
        {

        }
    }
    protected void dpprincipal_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            DataTable dtdata = bal.getitemdetailsbyidBAL(dpitem.SelectedValue.ToString());
            if (dtdata.Rows.Count > 0)
            {
                txtrate.Text = dtdata.Rows[0]["Itemrate"].ToString();
                dpuom.SelectedValue = dtdata.Rows[0]["Expr1"].ToString();
                int uomvaluye = Convert.ToInt32(dpuom.SelectedValue.ToString());
                txtqty.Focus();

            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void dpsuppliers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dtdata = bal.getitemdetailsbyidBAL(dpitem.SelectedValue.ToString());
            if (dtdata.Rows.Count > 0)
            {
                txtrate.Text = dtdata.Rows[0]["Itemrate"].ToString();

                dpuom.SelectedValue = dtdata.Rows[0]["Expr1"].ToString();
                int uomvaluye = Convert.ToInt32(dpuom.SelectedValue.ToString());
                txtqty.Focus();
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

            //dp.ClearSelection();
            //ddldesign.ClearSelection();
            //txtdob.Text = "";
            //txtdoani.Text = "";
            dpprincipal.ClearSelection();
            dpitem.ClearSelection();
            dpuom.ClearSelection();
            dpsuppliers.ClearSelection();
            txtqty.Text = "";
            txtrate.Text = "";
            txtamount.Text = "";
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnaddproduct_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dt1 = new DataTable();
            //dt1 = bal.checkProductNameBAL(lblcomno.Text, dpitem.SelectedItem.Text);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {

                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Inqiury_Details_InsertBAL(Convert.ToInt32(lblcomno.Text), Convert.ToInt32(dpitem.SelectedValue.ToString()), Convert.ToInt32(dpsuppliers.SelectedValue.ToString()), Convert.ToInt32(dpprincipal.SelectedValue.ToString()), Convert.ToInt32(dpuom.SelectedValue.ToString()), Convert.ToDecimal(txtqty.Text), Convert.ToDecimal(txtrate.Text), Convert.ToDecimal(txtamount.Text), lblloginid.Text, localTime, "", "", "", "", "");
                resetcontact();
                binditemdata();
                //txtcontactname.Focus();
            }
        }
        catch (Exception ex)
        {

        }

    }

    public void binditemdata()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getInqiuryDetailsdataBAL(Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdproduct.DataSource = dtcontact;
                grdproduct.DataBind();
                grdproduct.UseAccessibleHeader = true;
                grdproduct.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdproduct.DataSource = dtcontact;
                grdproduct.DataBind();
                grdproduct.UseAccessibleHeader = true;
                grdproduct.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    public void bindprinciple()
    {
        try
        {
            DataTable dtbtype = new DataTable();
            DataTable dtbtype1 = new DataTable();




            dtbtype1 = bal.getprincipalbyasssignBAL(dpitem.SelectedValue.ToString());
            if (dtbtype1.Rows.Count > 0)
            {
                dpprincipal.DataSource = dtbtype1;
                dpprincipal.DataTextField = "Pname";
                dpprincipal.DataValueField = "Id";
                dpprincipal.DataBind();
            }
            else
            {
                dtbtype1.Clear();
                dtbtype1.Rows.Clear();
                dpprincipal.DataSource = dtbtype1;
                dpprincipal.DataTextField = "Pname";
                dpprincipal.DataValueField = "Id";
                dpprincipal.DataBind();
            }
            dpprincipal.Items.Insert(0, new ListItem("----Select Pricipal----", "0"));
        }

        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }

    public void bindsupplier()
    {
        try
        {
            DataTable dtbtype = new DataTable();
            DataTable dtbtype1 = new DataTable();




            dtbtype = bal.getsupplierbyasssignBAL(dpitem.SelectedValue.ToString());
            if (dtbtype.Rows.Count > 0)
            {
                dpsuppliers.DataSource = dtbtype;
                dpsuppliers.DataTextField = "Name";
                dpsuppliers.DataValueField = "Id";
                dpsuppliers.DataBind();
            }
            else
            {

                dtbtype.Clear();
                dtbtype.Rows.Clear();
                dpsuppliers.DataSource = dtbtype;
                dpsuppliers.DataTextField = "Name";
                dpsuppliers.DataValueField = "Id";
                dpsuppliers.DataBind();
            }
            dpsuppliers.Items.Insert(0, new ListItem("----Select Supplier----", "0"));
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
    protected void grdproduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string result;
            lblid.Text = e.CommandArgument.ToString();
            if (e.CommandName == "editdata")
            {
                DataTable dtdata = bal.getInqiuryDetailsdatabyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    dpitem.SelectedValue = dtdata.Rows[0]["Item"].ToString();
                    bindprinciple();



                    dpprincipal.SelectedValue = dtdata.Rows[0]["Principal"].ToString();
                    bindsupplier();
                    dpsuppliers.SelectedValue = dtdata.Rows[0]["Supplier"].ToString();
                    dpuom.SelectedValue = dtdata.Rows[0]["UOM"].ToString();
                    txtqty.Text = dtdata.Rows[0]["Qty"].ToString();
                    txtrate.Text = dtdata.Rows[0]["Rate"].ToString();
                    txtamount.Text = dtdata.Rows[0]["Amount"].ToString();


                    dpitem.Focus();
                    btnaddproduct.Visible = false;
                    lbtnupdatecontact.Visible = true;
                    //  bindDetail();
                }
            }
            else if (e.CommandName == "deletedata")
            {

                result = bal.deleteinquirydetailsdatabyidBAL(lblid.Text);

                ShowMessage("Record Deleted!!!", MessageType.Success);

                binditemdata();


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

            bal.tbl_Inqiury_Details_updateBAL(Convert.ToInt32(lblid.Text), Convert.ToInt32(dpitem.SelectedValue.ToString()), Convert.ToInt32(dpsuppliers.SelectedValue.ToString()), Convert.ToInt32(dpprincipal.SelectedValue.ToString()), Convert.ToInt32(dpuom.SelectedValue.ToString()), Convert.ToDecimal(txtqty.Text), Convert.ToDecimal(txtrate.Text), Convert.ToDecimal(txtamount.Text), lblloginid.Text, localTime, "", "", "", "", "");
            resetcontact();
            binditemdata();
            ShowMessage("Record Save!!!", MessageType.Success);


            btnaddproduct.Visible = true;
            lbtnupdatecontact.Visible = false;

        }
        catch (Exception ex)
        {

        }
    }
    protected void lbtnresetcontact_Click(object sender, EventArgs e)
    {

    }
   


    


    
    protected void lbtnresetfollowup_Click(object sender, EventArgs e)
    {

    }
   





















    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {


            string Groupid = bal.getCustomerGroupIdbynameDAL(dpcustgroup.SelectedItem.Text);
            string custid = bal.getCustomerIdbynameBAL(dpcust.SelectedItem.Text);


            DataTable dt1 = new DataTable();
            dt1 = bal.checkInqiuryalreadyBAL(txtno.Text, txtdate.Text, Convert.ToInt32(Groupid), Convert.ToInt32(custid));
            if (dt1.Rows.Count > 0)
            {
                // ShowMessage("Name Already Exist!!!", MessageType.Error);
                lblmsg.Text = "Name Already Exist!!!";
            }
            else
            {

                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);


                bal.tbl_Inqiury_Master_InsertBAL(Convert.ToInt32(txtno.Text), Convert.ToInt32(lblcomno.Text), txtdate.Text, Convert.ToInt32(Groupid), Convert.ToInt32(custid), Convert.ToInt32(dpcontactper.SelectedValue.ToString()), txtcontactno.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesign.SelectedValue.ToString()), txtemail.Text, txtmobileno.Text, txtmobileno2.Text, Convert.ToInt32(dpstatus.SelectedValue.ToString()), Convert.ToInt32(dpsource.SelectedValue.ToString()), txtremarks.Text, lblloginid.Text, localTime, "", "", "", "", "");
                Response.Redirect("InquiryRegister.aspx", false);
            }
        }
        catch (Exception ex)
        {

        }

    }

    public void lbtndesignreset_Click(object sender, EventArgs e)
    {
        try
        {
            txtstatus.Text = "";
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            txtsource.Text = "";
            txtuom.Text = "";
          
           
        }
        catch (Exception ex)
        {

        }
    }


    public void RefreshItmdataGroup(object sender, EventArgs e)
    {
        binditem();
    }

    public void RefreshPrincipaldata(object sender, EventArgs e)
    {
        dpprincipal.ClearSelection();
        binditem();
        bindprinciple();
    }

    public void RefreshCustGroup(object sender, EventArgs e)
    {
        bindcustgroup();
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

    protected void dpcontactper_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dtdata = bal.getCustomercontactdatabyidBAL(dpcontactper.SelectedValue.ToString());
            if (dtdata.Rows.Count > 0)
            {

                txtemail.Text = dtdata.Rows[0]["ContactEmail"].ToString();
                txtcontactno.Text = dtdata.Rows[0]["ContactPhone"].ToString();

                ddlDept.SelectedValue = dtdata.Rows[0]["Dept"].ToString();
                ddldesign.SelectedValue = dtdata.Rows[0]["Design"].ToString();
                txtmobileno.Text = dtdata.Rows[0]["ContactMobileno1"].ToString();
                txtmobileno2.Text = dtdata.Rows[0]["ContactMobileno2"].ToString();
                //  bindDetail();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void lbtncStatus_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkstatusnameBAL(txtstatus.Text);
            if (dt1.Rows.Count > 0)
            {
                //  ShowMessage("Name Already Exist!!!", MessageType.Error);
                Label1.Text = "Name Already Exists!!!";
                mpstatus.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Status_Master_InsertBAL(txtstatus.Text, lblloginid.Text, localTime, "", "", "", "", "");
                bindstatus();
                // ShowMessage("Record Save!!!", MessageType.Success);
                txtstatus.Text = "";
                Label1.Text = "Record Save!!!";
                txtstatus.Focus();
                mpstatus.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }

    protected void lbtncSource_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checksourcenameBAL(txtsource.Text);
            if (dt1.Rows.Count > 0)
            {
                // ShowMessage("Name Already Exist!!!", MessageType.Error);
                Label2.Text = "Name Already Exists!!!";
                mpsource.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Source_Master_InsertBAL(txtsource.Text, lblloginid.Text, localTime, "", "", "", "", "");
                bindsource();
                // ShowMessage("Record Save!!!", MessageType.Success);
                txtsource.Text = "";
                txtsource.Focus();
                Label2.Text = "Record Save!!!";
                mpsource.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }

    protected void lbtncUOM_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkUOMnameBAL(txtuom.Text);
            if (dt1.Rows.Count > 0)
            {
                // ShowMessage("UOM Already Exist!!!", MessageType.Error);
                Label3.Text = "UOM Already Exists!!!";
                mpuom.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tblItemunit_Master_InsertBAL(txtuom.Text, lblloginid.Text, localTime, "", "", "", "", "");
                binduom();
                // ShowMessage("Record Save!!!", MessageType.Success);
                txtuom.Text = "";
                Label3.Text = "Record Save!!!";
                txtuom.Focus();
                mpuom.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }








    //protected void lbtnUpdateTandC_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable dt1 = new DataTable();
    //        dt1 = bll.checktermsandconditionsdata(txttitle.Text);
    //        if (dt1.Rows.Count > 0)
    //        {
    //            ShowMessage("Name Already Exist!!!", MessageType.Error);
    //        }
    //        else
    //        {
    //            DateTime utcTime = DateTime.UtcNow;
    //            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    //            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

    //            bll.Savetermsandconditionsbll(txttitle.Text, Txttandc.Text, "", localTime, "", "", "", "", "");

    //            BindTermsandConditions();
    //            txttitle.Text = "";
    //            Txttandc.Text = "";
    //            txttitle.Focus();
    //            Label4.Text = "Update Successfull";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ex.ToString();
    //    }
    //}

}