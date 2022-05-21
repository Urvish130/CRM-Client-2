using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateQuotation : System.Web.UI.Page
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
                    Session["UpdTandC"] = lblcomno.Text;
                    string zoneId = "India Standard Time";
                    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
                    DateTime now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi);
                    txtfdate.Text = now.ToString("dd/MM/yyyy");
                    txtdate.Text = now.ToString("dd/MM/yyyy");
                    lblloginid.Text = Session["no"].ToString();
                    lblrole.Text = Session["role"].ToString();
                    lblcompanyno.Text = Session["Companyno"].ToString();
                    lblcomno.Text = Request.QueryString["no"].ToString();
                    bindcustgroup();
                    bindQuotationitemdata();
                    bindfollowupdata();
                    // bindTaxationdata();
                    txtcurrency.Enabled = false;
                    txtrate.Enabled = false;
                    bindCountry();
                    bindstatus();
                    bindsource();
                    bindfollowup();
                    bindassignto();
                    binditem();
                    binduom();
                    binddepartment();
                    binddesignation();
               
                    
                    BindTermsandConditions();


                    filldata();
                    
                }
            }
            catch (Exception ex)
            {

            }




        }
    }
    public void filldata()
    {
        try
        {
            DataTable dtdata = bal.getallQuotationdatabynoBAL(lblcomno.Text);
            if (dtdata.Rows.Count > 0)
            {
                txtno.Text = dtdata.Rows[0]["QuotationNo"].ToString();
                txtdate.Text = dtdata.Rows[0]["QuotationDate"].ToString();
                txtemail.Text = dtdata.Rows[0]["ContactEmail"].ToString();
                txtcontactno.Text = dtdata.Rows[0]["Custcontactno"].ToString();
                txtmobileno.Text = dtdata.Rows[0]["ContactMno1"].ToString();
                txtmobileno2.Text = dtdata.Rows[0]["ContactMno2"].ToString();
                
                

              
                dpcustgroup.SelectedValue = dtdata.Rows[0]["Groupno"].ToString();
                bincustnanme();
                dpcust.SelectedValue = dtdata.Rows[0]["No"].ToString();
                bincustcontact();
                Session["CustID"] = dpcust.SelectedValue.ToString();

                dpcontactper.SelectedValue = dtdata.Rows[0]["Id"].ToString();
                dpstatus.SelectedValue = dtdata.Rows[0]["InqiuryStatus"].ToString();
                dpsource.SelectedValue = dtdata.Rows[0]["InqiurySource"].ToString();
                dpfollowstatus.SelectedValue = dtdata.Rows[0]["InqiuryStatus"].ToString();

                txtremarks.Text = dtdata.Rows[0]["Remarks"].ToString();
                ddlDept.SelectedValue = dtdata.Rows[0]["Dept"].ToString();
                ddldesign.SelectedValue = dtdata.Rows[0]["Design"].ToString();
                //txturl.Text = dtdata.Rows[0]["URL"].ToString();
                //rbtnstatus.SelectedItem.Text = dtdata.Rows[0]["Status"].ToString();
                //txtgstno.Text = dtdata.Rows[0]["GSTno"].ToString();
                //txtbankname.Text = dtdata.Rows[0]["Bankname"].ToString();
                //txtaccno.Text = dtdata.Rows[0]["Accountno"].ToString();
                //txtifsccode.Text = dtdata.Rows[0]["IFSCcode"].ToString();
                //txtcountry.Text = dtdata.Rows[0]["Country"].ToString();
                // bindcustomer();
                //  bincustcontact();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void lbtncStatus2_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkstatusnameBAL(TextBox1.Text);
            if (dt1.Rows.Count > 0)
            {
                 ShowMessage("Name Already Exist!!!", MessageType.Error);
                //Label5.Text = "Name Already Exists!!!";
                Status2.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Status_Master_InsertBAL(TextBox1.Text, lblloginid.Text, localTime, "", "", "", "", "");
                bindstatus();
                 ShowMessage("Record Save!!!", MessageType.Success);
                TextBox1.Text = "";
                //Label5.Text = "Record Save!!!";
                TextBox1.Focus();
                Status2.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
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
                  ShowMessage("Name Already Exist!!!", MessageType.Error);
               // Label1.Text = "Name Already Exists!!!";
                mpstatus.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Status_Master_InsertBAL(TextBox1.Text, lblloginid.Text, localTime, "", "", "", "", "");
                bindstatus();
                 ShowMessage("Record Save!!!", MessageType.Success);
                txtstatus.Text = "";
               // Label1.Text = "Record Save!!!";
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


    public void bincustcontact()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getCustomerConatctPersonBAL(dpcust.SelectedValue.ToString());
            if (dtbtype.Rows.Count > 0)
            {
                dpcontactper.DataSource = dtbtype;
                dpcontactper.DataTextField = "ContactName";
                dpcontactper.DataValueField = "Id";
                dpcontactper.DataBind();
            }
            dpcontactper.Items.Insert(0, new ListItem("----Select Conatctperson----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }

    protected void RefreshCurrency(object sender, EventArgs e)
    {

        try
        {
            bindCountry();
        }
        catch (Exception ex)
        {

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
            string s1 = "select Top (1) QuotationNo from Quotation_Master    order By  Id DESC";
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


                dpfollowstatus.DataSource = dtbtype;
                dpfollowstatus.DataTextField = "StatusName";
                dpfollowstatus.DataValueField = "Id";
                dpfollowstatus.DataBind();
            }
            dpstatus.Items.Insert(0, new ListItem("----Select Status----", "0"));
            dpfollowstatus.Items.Insert(0, new ListItem("----Select Status----", "0"));

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

    public void BindTermsandConditions()
    {

        try
        {
            DataTable dt = bal.getTermsfroQuotationUpdateBAL(Convert.ToInt32(lblcomno.Text));


            if (dt.Rows.Count > 0)
            {
                grddata1.DataSource = dt;
                grddata1.DataBind();
                grddata1.UseAccessibleHeader = true;
                grddata1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grddata1.DataSource = dt;
                grddata1.DataBind();
                grddata1.UseAccessibleHeader = true;
                grddata1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }


    public void bindfollowup()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getallFollowuptypeforadminBAL();
            if (dtbtype.Rows.Count > 0)
            {
                dpfollowuptype.DataSource = dtbtype;
                dpfollowuptype.DataTextField = "FollowupName";
                dpfollowuptype.DataValueField = "Id";
                dpfollowuptype.DataBind();
            }
            dpfollowuptype.Items.Insert(0, new ListItem("----Select Followup Type----", "0"));

        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
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

    public void bindCountry()
    {
        try
        {
            DataTable dtbtype = new DataTable();


            dtbtype = bal.getallCountryforadminBAL();
            if (dtbtype.Rows.Count > 0)
            {
                ddlCurrency.DataSource = dtbtype;
                ddlCurrency.DataTextField = "Extra1";
                ddlCurrency.DataValueField = "Extra3";
                ddlCurrency.DataBind();
            }
            ddlCurrency.Items.Insert(0, new ListItem("----Select Currency----", "0"));

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
            bincustnanme();
        }
        catch (Exception ex)
        {

        }
    }


    protected void bincustnanme()
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
                decimal rate = Convert.ToDecimal(txtrate.Text);
                dpuom.SelectedValue = dtdata.Rows[0]["Expr1"].ToString();
                int uomvaluye = Convert.ToInt32(dpuom.SelectedValue.ToString());
                txtqty.Focus();
                decimal txt1 = Convert.ToDecimal(dtdata.Rows[0]["Extra1"].ToString());
                    
                if (DropDownListID.SelectedValue == "1")
                {
                    decimal charges = Convert.ToDecimal(txt1 + rate);
                    decimal rate1 = Convert.ToDecimal(charges);
                    decimal currency = Convert.ToDecimal(txtcurrency.Text);
                    decimal count = Convert.ToDecimal(rate1 / currency);

                    txtrate.Text = count.ToString("0.00");
                }
                else
                {
                    decimal charges = Convert.ToDecimal(rate);
                    decimal rate1 = Convert.ToDecimal(charges);
                    decimal currency = Convert.ToDecimal(txtcurrency.Text);
                    decimal count = Convert.ToDecimal(rate1 / currency);

                    txtrate.Text = count.ToString("0.00");
                }
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
                decimal rate = Convert.ToDecimal(txtrate.Text);
                dpuom.SelectedValue = dtdata.Rows[0]["Expr1"].ToString();
                int uomvaluye = Convert.ToInt32(dpuom.SelectedValue.ToString());
                txtqty.Focus();
                decimal txt1 = Convert.ToDecimal(dtdata.Rows[0]["Extra1"].ToString());
               
                if (DropDownListID.SelectedValue == "1")
                {
                    decimal charges = Convert.ToDecimal(txt1 + rate);
                    decimal rate1 = Convert.ToDecimal(charges);
                    decimal currency = Convert.ToDecimal(txtcurrency.Text);
                    decimal count = Convert.ToDecimal(rate1 / currency);
                    txtrate.Text = count.ToString("0.00");
                }
                else
                {
                    decimal charges = Convert.ToDecimal(rate);
                    decimal rate1 = Convert.ToDecimal(charges);
                    decimal currency = Convert.ToDecimal(txtcurrency.Text);
                    decimal count = Convert.ToDecimal(rate1 / currency);
                    txtrate.Text = count.ToString("0.00");
                }
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


    public void bindQuotationitemdata()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getQuotationDetailsdataBAL(Convert.ToInt32(lblcomno.Text));
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
                DataTable dtdata = bal.getQuotationDetailsdatabyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    dpitem.SelectedValue = dtdata.Rows[0]["Item"].ToString();
                    bindprinciple();



                    dpprincipal.SelectedValue = dtdata.Rows[0]["Principal"].ToString();
                    bindsupplier();
                    dpsuppliers.SelectedValue = dtdata.Rows[0]["Suppiler"].ToString();
                    dpuom.SelectedValue = dtdata.Rows[0]["UOM"].ToString();
                    txtqty.Text = dtdata.Rows[0]["Qty"].ToString();
                    txtrate.Text = dtdata.Rows[0]["Rate"].ToString();
                    txtamount.Text = dtdata.Rows[0]["Amount"].ToString();
                    ddlCurrency.SelectedValue = dtdata.Rows[0]["Extra1"].ToString();
                    txtcurrency.Text = dtdata.Rows[0]["Extra1"].ToString();
                    dpitem.Focus();
                    btnaddproduct.Visible = false;
                    lbtnupdatecontact.Visible = true;
                    //  bindDetail();
                }
            }
            else if (e.CommandName == "deletedata")
            {

                result = bal.deleteQuotationdetailsdatabyidBAL(lblid.Text);

                ShowMessage("Record Deleted!!!", MessageType.Success);

                bindQuotationitemdata();


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

            string result = bal.tbl_Quotation_Details_updateBAL(Convert.ToInt32(lblid.Text), Convert.ToInt32(dpitem.SelectedValue.ToString()), Convert.ToInt32(dpsuppliers.SelectedValue.ToString()), Convert.ToInt32(dpprincipal.SelectedValue.ToString()), Convert.ToInt32(dpuom.SelectedValue.ToString()), Convert.ToDecimal(txtqty.Text), Convert.ToDecimal(txtrate.Text), Convert.ToDecimal(txtamount.Text), lblloginid.Text, localTime, ddlCurrency.SelectedValue.ToString(), lblcomno.Text, "", "", "");

            if (result == "-1")
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {
                resetcontact();
                bindQuotationitemdata();
                ShowMessage("Record Save!!!", MessageType.Success);

                ddlCurrency.ClearSelection();
                btnaddproduct.Visible = true;
                lbtnupdatecontact.Visible = false;
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void lbtnresetcontact_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnaddfollowup_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dt1 = new DataTable();
            dt1 = bal.checkQuotationFollowupBAL(lblcomno.Text, txtfdate.Text, Convert.ToInt32(dpfollowuptype.SelectedValue.ToString()));
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
                //lblmsg.Text = "Name aslready Exist!!!";
            }
            else
            {

                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Quotation_Followup_InsertBAL(Convert.ToInt32(lblcomno.Text), txtfdate.Text, Convert.ToInt32(dpfollowuptype.SelectedValue.ToString()), Convert.ToInt32(dpassignto.SelectedValue.ToString()), Convert.ToInt32(dpfollowstatus.SelectedValue.ToString()), txtfremarks.Text, "", "", lblloginid.Text, localTime, "", "", "", "", "");
                txtfremarks.Text = "";
                dpassignto.ClearSelection();
                dpfollowuptype.ClearSelection();
                bindfollowupdata();
                //txtcontactname.Focus();
                ShowMessage("Record Save!!!", MessageType.Success);
            }
        }
        catch (Exception ex)
        {

        }

    }




    public void bindfollowupdata()
    {

        try
        {

            DataTable dtcontact = new DataTable();
            dtcontact = bal.getQuotationFollowupdataBAL(Convert.ToInt32(lblcomno.Text));
            if (dtcontact.Rows.Count > 0)
            {
                grdfollowup.DataSource = dtcontact;
                grdfollowup.DataBind();
                grdfollowup.UseAccessibleHeader = true;
                grdfollowup.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grdfollowup.DataSource = dtcontact;
                grdfollowup.DataBind();
                grdfollowup.UseAccessibleHeader = true;
                grdfollowup.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }




    public void resetfollowup()
    {
        try
        {
            string zoneId = "India Standard Time";
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
            DateTime now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi);
            txtfdate.Text = now.ToString("dd/MM/yyyy");


            dpfollowuptype.ClearSelection();


            dpfollowstatus.ClearSelection();

            txtfremarks.Text = "";

        }
        catch (Exception ex)
        {

        }
    }
    protected void lbtnupdatefollowup_Click(object sender, EventArgs e)
    {
        try
        {


            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

            string result = bal.tbl_Quotation_Followup_updateBAL(Convert.ToInt32(lblid.Text), Convert.ToInt32(lblcomno.Text), txtfdate.Text, Convert.ToInt32(dpfollowuptype.SelectedValue.ToString()), Convert.ToInt32(dpassignto.SelectedValue.ToString()), Convert.ToInt32(dpfollowstatus.SelectedValue.ToString()), txtfremarks.Text, lblloginid.Text, localTime, "", "", "", "", "");

            if (result == "-1")
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {
                bindfollowupdata();
                ShowMessage("Record Save!!!", MessageType.Success);
                dpfollowuptype.ClearSelection();
                dpassignto.ClearSelection();


                lbtnaddfollowup.Visible = true;
                lbtnupdatefollowup.Visible = false;
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void lbtnresetfollowup_Click(object sender, EventArgs e)
    {

    }
    protected void grdfollowup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string result;
            lblid.Text = e.CommandArgument.ToString();
            if (e.CommandName == "editdata")
            {
                DataTable dtdata = bal.getQuotationFollowupDetailsdatabyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    dpfollowuptype.SelectedValue = dtdata.Rows[0]["Follotype"].ToString();
                    dpfollowstatus.SelectedValue = dtdata.Rows[0]["FolloStatus"].ToString();
                    dpassignto.SelectedValue = dtdata.Rows[0]["Assignto"].ToString();

                    txtfremarks.Text = dtdata.Rows[0]["Remarks"].ToString();
                    txtfdate.Text = dtdata.Rows[0]["NextFolldate"].ToString();



                    lbtnaddfollowup.Visible = false;
                    lbtnupdatefollowup.Visible = true;
                    //  bindDetail();
                }
            }
            else if (e.CommandName == "deletedata")
            {

                result = bal.deleteQuotationfollowupdatabyidBAL(lblid.Text);

                ShowMessage("Record Deleted!!!", MessageType.Success);

                bindfollowupdata();


            }

        }
        catch (Exception ex)
        {

        }
    }

    
        protected void RefreshTermsdata(object sender, EventArgs e)
    {
        BindTermsandConditions();
    }

    protected void grdTerms_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "editterms")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                //GridViewRow gvRow = grddata1.Rows[index];
                //int gr = index;
                Response.Write("<script>window.open ('UpdateQuotationTerms.aspx?no=" + index + "&UpdQTC="+ lblcomno.Text + "','_blank');</script>");
                // Response.Redirect(String.Format("TermsandConditions.aspx?no={0}", gvRow), false);
            }
            else if (e.CommandName == "RefreshTermsdata")
            {
                BindTermsandConditions();
            }

        }
        catch (Exception ex)
        {



        }
    }





    //protected void grdTerms_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //    try
    //    {
    //        mpterms.Show();

    //        string result;
    //        lblid.Text = e.CommandArgument.ToString();
    //        if (e.CommandName == "editdata")
    //        {


    //            mpterms.Show();
    //            DataTable dtdata = bal.gettermsandconditionsdatabyidBAL(lblid.Text);
    //            if (dtdata.Rows.Count > 0)
    //            {
    //                txttitle.Text = dtdata.Rows[0]["Title"].ToString();
    //                Txttandc.Text = dtdata.Rows[0]["TermsandConditions"].ToString();



    //                //    //  bindDetail();
    //                }
    //            }
    //        else if (e.CommandName == "deletedata")
    //        {

    //            result = bal.deleteinquiryfollowupdatabyidBAL(lblid.Text);

    //            ShowMessage("Record Deleted!!!", MessageType.Success);

    //            bindfollowupdata();


    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}








    public void lbtndesignreset_Click(object sender, EventArgs e)
    {
        try
        {
            // txtstatus.Text = "";
            // Label1.Text = "";
          //  Label16.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            txtsource.Text = "";
            txtuom.Text = "";
            // Label5.Text = "";
            //TextBox1.Text = "";
            Label6.Text = "";
          //  txtCountry.Text = "";
            mpTxtFollowup.Text = "";

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

    protected void lbtncSource_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checksourcenameBAL(txtsource.Text);
            if (dt1.Rows.Count > 0)
            {
                 ShowMessage("Name Already Exist!!!", MessageType.Error);
               // Label2.Text = "Name Already Exists!!!";
                mpsource.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Source_Master_InsertBAL(txtsource.Text, lblloginid.Text, localTime, "", "", "", "", "");
                bindsource();
                 ShowMessage("Record Save!!!", MessageType.Success);
                txtsource.Text = "";
                txtsource.Focus();
               // Label2.Text = "Record Save!!!";
                mpsource.Show();
                bindsource();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }



    //protected void lbtncCountry_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable dt1 = new DataTable();
    //        dt1 = bal.checkCountrynameBAL(txtCountry.Text);
    //        if (dt1.Rows.Count > 0)
    //        {
    //            // ShowMessage("Name Already Exist!!!", MessageType.Error);
    //            Label16.Text = "Name Already Exists!!!";
    //            mpCountry.Show();
    //        }
    //        else
    //        {
    //            DateTime utcTime = DateTime.UtcNow;
    //            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    //            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

    //            bal.SaveCountryMasterBAL(txtCountry.Text, lblloginid.Text, localTime, "", "", "", "", "");
    //            bindsource();
    //             ShowMessage("Record Save!!!", MessageType.Success);
    //            txtCountry.Text = "";
    //            txtCountry.Focus();
    //            //Label16.Text = "Record Save!!!";
    //            mpCountry.Show();
    //            bindCountry();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //  Getconnection.SiteErrorInsert(ex);
    //        ShowMessage(ex.ToString(), MessageType.Error);
    //    }
    //}




    protected void lbtncUOM_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkUOMnameBAL(txtuom.Text);
            if (dt1.Rows.Count > 0)
            {
                 ShowMessage("UOM Already Exist!!!", MessageType.Error);
               // Label3.Text = "UOM Already Exists!!!";
                mpuom.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tblItemunit_Master_InsertBAL(txtuom.Text, lblloginid.Text, localTime, "", "", "", "", "");
                binduom();
                 ShowMessage("Record Save!!!", MessageType.Success);
                txtuom.Text = "";
                //Label3.Text = "Record Save!!!";
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




    protected void lbtncFollowup_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = bal.checkFollowupnameBAL(mpTxtFollowup.Text);
            if (dt1.Rows.Count > 0)
            {
                  ShowMessage("Name Already Exist!!!", MessageType.Error);
               // Label6.Text = "Name Already Exists!!!";
                mpfollowup.Show();
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_followuptype_Master_InsertBAL(mpTxtFollowup.Text, lblloginid.Text, localTime, "", "", "", "", "");
                bindfollowup();
                 ShowMessage("Record Save!!!", MessageType.Success);
                mpTxtFollowup.Text = "";
                //Label6.Text = "Record Save!!!";
                mpTxtFollowup.Focus();
                mpfollowup.Show();
            }
        }
        catch (Exception ex)
        {
            //  Getconnection.SiteErrorInsert(ex);
            ShowMessage(ex.ToString(), MessageType.Error);
        }
    }



    protected void btnaddproduct_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dt1 = new DataTable();
            dt1 = bal.checkQuotationProductNameBAL(lblcomno.Text, dpitem.SelectedItem.Value);
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                DataTable dtdata2 = new DataTable();
                dtdata2 = bal.checkQuotationProductBroucherBAL(dpitem.SelectedItem.Value);

                if (dtdata2.Rows.Count > 0)
                {
                    for (int j = 0; j < dtdata2.Rows.Count; j++)
                    {
                        string DocuName = dtdata2.Rows[j]["DocuName"].ToString();
                        string Filename = dtdata2.Rows[j]["Filename"].ToString();
                        string DocumentPath = dtdata2.Rows[j]["DocumentPath"].ToString();

                        bal.tbl_Quotation_Details_Broucher_InsertBAL(Convert.ToInt32(lblcomno.Text), DocuName, Filename, DocumentPath, lblloginid.Text, localTime, dpitem.SelectedItem.Value, "", "", "", "");



                    }
                }
                bal.tbl_Quotation_Details_InsertBAL(Convert.ToInt32(lblcomno.Text), Convert.ToInt32(dpitem.SelectedValue.ToString()), Convert.ToInt32(dpsuppliers.SelectedValue.ToString()), Convert.ToInt32(dpprincipal.SelectedValue.ToString()), Convert.ToInt32(dpuom.SelectedValue.ToString()), Convert.ToDecimal(txtqty.Text), Convert.ToDecimal(txtrate.Text), Convert.ToDecimal(txtamount.Text), lblloginid.Text, localTime, ddlCurrency.SelectedValue.ToString(), "", "", "", "");
                resetcontact();
                bindQuotationitemdata();
                //txtcontactname.Focus();
                ShowMessage("Record Save!!!", MessageType.Success);
                ddlCurrency.ClearSelection();
                txtcurrency.Text = "";
            
            }
        }
        catch (Exception ex)
        {

        }

    }
    //protected void btnaddTaxation_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        DataTable dt1 = new DataTable();


    //        DateTime utcTime = DateTime.UtcNow;
    //        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    //        DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

    //        string result = bal.tbl_Quotation_Taxation_InsertBAL(Convert.ToInt32(lblcomno.Text), Convert.ToInt32(dpCountry.SelectedValue.ToString()), TextBox2.Text, TextBox3.Text, lblloginid.Text, localTime, "", "", "", "", "");
    //        bindTaxationdata();
    //        //txtcontactname.Focus();
    //        if (result == "-1")
    //        {
    //            lblmsg.Text = "Already exist";
    //            dpCountry.ClearSelection();
    //            TextBox2.Text = "";
    //            TextBox3.Text = "";
    //        }
    //        else
    //        {
    //            lblmsg.Text = "Record saved";
    //            dpCountry.ClearSelection();
    //            TextBox2.Text = "";
    //            TextBox3.Text = "";
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //}
    //protected void lbtnupdateTaxation_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        DataTable dt1 = new DataTable();
    //        dt1 = bal.checkTaxationBAL(lblcomno.Text, TextBox2.Text, Convert.ToInt32(dpCountry.SelectedValue.ToString()));
    //        if (dt1.Rows.Count > 0)
    //        {
    //            ShowMessage("Name Already Exist!!!", MessageType.Error);
    //        }
    //        else
    //        {

    //            DateTime utcTime = DateTime.UtcNow;
    //            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    //            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

    //            bal.tbl_Quotation_Taxation_UpdateBAL(Convert.ToInt32(lblid.Text), Convert.ToInt32(lblcomno.Text), Convert.ToInt32(dpCountry.SelectedValue.ToString()), TextBox2.Text, TextBox3.Text, lblloginid.Text, localTime, "", "", "", "", "");
    //            dpCountry.ClearSelection();
    //            TextBox2.Text = "";
    //            TextBox3.Text = "";
    //            bindTaxationdata();
    //            //txtcontactname.Focus();
    //            lblmsg.Text = "Record Updated";
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //}
    //public void bindTaxationdata()
    //{

    //    try
    //    {

    //        DataTable dtcontact = new DataTable();
    //        dtcontact = bal.getTaxationDataBAL(Convert.ToInt32(lblcomno.Text));
    //        if (dtcontact.Rows.Count > 0)
    //        {
    //            grdviewTaxation.DataSource = dtcontact;
    //            grdviewTaxation.DataBind();
    //            grdviewTaxation.UseAccessibleHeader = true;
    //            grdviewTaxation.HeaderRow.TableSection = TableRowSection.TableHeader;
    //        }
    //        else
    //        {
    //            grdviewTaxation.DataSource = dtcontact;
    //            grdviewTaxation.DataBind();
    //            grdviewTaxation.UseAccessibleHeader = true;
    //            grdviewTaxation.HeaderRow.TableSection = TableRowSection.TableHeader;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Getconnection.SiteErrorInsert(ex);
    //    }
    //}
    //protected void grdTaxation_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        string result;
    //        lblid.Text = e.CommandArgument.ToString();
    //        if (e.CommandName == "editdata")
    //        {
    //            DataTable dtdata = bal.getTaxationDetailsdatabyidBAL(lblid.Text);
    //            if (dtdata.Rows.Count > 0)
    //            {
    //                dpCountry.SelectedValue = dtdata.Rows[0]["Country"].ToString();
    //                TextBox2.Text = dtdata.Rows[0]["TAXName"].ToString();


    //                TextBox3.Text = dtdata.Rows[0]["TAXPercentage"].ToString();




    //                LinkButton16.Visible = false;
    //                LinkButton9.Visible = true;
    //                //  bindDetail();
    //            }
    //        }
    //        else if (e.CommandName == "deletedata")
    //        {

    //            result = bal.deleteQuotationTaxationdatabyidBAL(lblid.Text);

    //            ShowMessage("Record Deleted!!!", MessageType.Success);

    //            bindTaxationdata();


    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}








    protected void Inquiry_Save(object sender, EventArgs e)
    {
        try
        {


            string Groupid = bal.getCustomerGroupIdbynameDAL(dpcustgroup.SelectedItem.Text);
            string custid = bal.getCustomerIdbynameBAL(dpcust.SelectedItem.Text);


            DataTable dt1 = new DataTable();
            dt1 = bal.checkInqiuryalreadyBAL(txtno.Text, txtdate.Text, Convert.ToInt32(Groupid), Convert.ToInt32(custid));
            if (dt1.Rows.Count > 0)
            {
                 ShowMessage("Name Already Exist!!!", MessageType.Error);
                //lblmsg.Text = "Name Already Exist!!!";
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





    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string Groupid = bal.getCustomerGroupIdbynameDAL(dpcustgroup.SelectedItem.Text);
            string custid = bal.getCustomerIdbynameBAL(dpcust.SelectedItem.Text);
            DataTable dt1 = new DataTable();
            dt1 = bal.checkQuotationalreadyBAL(txtno.Text, txtdate.Text, Convert.ToInt32(custid), Convert.ToInt32(Groupid));
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                try
                {
                    string inqno = lblcomno.Text;
                    if (inqno.Equals(""))
                    {
                        bal.tbl_Quotation_Master_UpdateBAL(Convert.ToInt32(txtno.Text), Convert.ToInt32(lblcomno.Text), txtdate.Text, Convert.ToInt32(Groupid), Convert.ToInt32(custid), Convert.ToInt32(dpcontactper.SelectedValue.ToString()), txtcontactno.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesign.SelectedValue.ToString()), txtemail.Text, txtmobileno.Text, txtmobileno2.Text, Convert.ToInt32(dpstatus.SelectedValue.ToString()), Convert.ToInt32(dpsource.SelectedValue.ToString()), txtremarks.Text, lblloginid.Text, localTime, "DirectQuotation", "", "", "", lblcompanyno.Text);

                    }
                    else
                    {
                        bal.tbl_Quotation_Master_UpdateBAL(Convert.ToInt32(txtno.Text), Convert.ToInt32(lblcomno.Text), txtdate.Text, Convert.ToInt32(Groupid), Convert.ToInt32(custid), Convert.ToInt32(dpcontactper.SelectedValue.ToString()), txtcontactno.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesign.SelectedValue.ToString()), txtemail.Text, txtmobileno.Text, txtmobileno2.Text, Convert.ToInt32(dpstatus.SelectedValue.ToString()), Convert.ToInt32(dpsource.SelectedValue.ToString()), txtremarks.Text, lblloginid.Text, localTime, "InqtoQuotation", lblcomno.Text, "", "", lblcompanyno.Text);
                    }
                }
                catch (Exception ex)
                {

                }
                try
                {
                    foreach (GridViewRow row in grddata1.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {

                            CheckBox chkrow = (row.Cells[0].FindControl("btnchkbox") as CheckBox);

                            int id = Convert.ToInt32(((Label)row.FindControl("lblid")).Text);
                            string title = ((Label)row.FindControl("lblname")).Text;
                            string descp = ((Label)row.FindControl("lbltandc")).Text;
                            if (chkrow.Checked)
                            {
                                bal.tbl_Quotation_tandc_UpdateBAL(Convert.ToInt32(lblcomno.Text), id, title, descp, "True", lblloginid.Text, localTime);
                            }
                            else
                            {
                                bal.tbl_Quotation_tandc_UpdateBAL(Convert.ToInt32(lblcomno.Text), id, title, descp, "False", lblloginid.Text, localTime);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                Response.Redirect("QuotationRegistry.aspx", false);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void grddata1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chk = (CheckBox)e.Row.FindControl("btnchkbox");
            Label lblSatatus = (Label)e.Row.FindControl("lblstatus");

            if (lblSatatus.Text.ToString() == "True")
            {
                chk.Checked = true;
            }
            else
            {
                chk.Checked = false;
            }

        }
    }

    protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlCurrency.SelectedValue) < 1)
        {

            txtcurrency.Text = "1";
            var currency = Convert.ToDecimal(txtcurrency.Text);
            dpprincipal.ClearSelection();
            dpsuppliers.ClearSelection();
            dpuom.ClearSelection();

            txtqty.Text = "";
            txtamount.Text = "";
            txtrate.Text = "";



        }
        else if (txtqty.Text == "" || txtrate.Text == "")
        {
            txtcurrency.Text = ddlCurrency.SelectedValue;

            var currency = Convert.ToDecimal(txtcurrency.Text);
            dpprincipal.ClearSelection();
            dpsuppliers.ClearSelection();
            dpuom.ClearSelection();
            txtqty.Text = "";
            txtamount.Text = "";
            txtrate.Text = "";
        }
        else
        {

            txtcurrency.Text = ddlCurrency.SelectedValue;
            txtcurrency.Text = "1";
            var currency = Convert.ToDecimal(txtcurrency.Text);
            dpprincipal.ClearSelection();
            dpsuppliers.ClearSelection();
            dpuom.ClearSelection();

            txtqty.Text = "";
            txtamount.Text = "";
            txtrate.Text = "";
        }



    }
    protected void txtqty_TextChanged(object sender, EventArgs e)
    {
        if (txtcurrency.Text == "" || txtcurrency.Text == "1")
        {
            txtcurrency.Text = "1";
            var currency = Convert.ToDecimal(txtcurrency.Text);
            var qty = Convert.ToDecimal(txtqty.Text);
            var rate = Convert.ToDecimal(txtrate.Text);
            var amount = qty * (rate / currency);
            decimal txt1 = amount;
            txtamount.Text = txt1.ToString("0.00");
            var rate_changed = (rate / currency);
            decimal txt2 = rate_changed;
            txtrate.Text = txt2.ToString("0.00");
        }
        else
        {
            txtcurrency.Text = ddlCurrency.SelectedValue;
            var currency = Convert.ToDecimal(txtcurrency.Text);
            var qty = Convert.ToDecimal(txtqty.Text);
            var rate = Convert.ToDecimal(txtrate.Text);
            var amount = qty * (rate / currency);
            decimal txt1 = amount;
            txtamount.Text = txt1.ToString("0.00");
            var rate_changed = (rate / currency);
            decimal txt2 = rate_changed;
            txtrate.Text = txt2.ToString("0.00");
        }
    }
    protected void grdproduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string customerId = grdproduct.DataKeys[e.Row.RowIndex].Value.ToString();
            //string custorId = e.Row.DataItem.ToString();
            DataTable dt = new DataTable();
            dt = bal.getitemBrouchersforquotation(Convert.ToInt32(customerId));
            GridView BOMGrid = e.Row.FindControl("BOMGrid") as GridView;
            BOMGrid.DataSource = dt;
            BOMGrid.DataBind();
        }

    }
    protected void BOMGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string result;
            string deleteItem = e.CommandArgument.ToString();
            if (e.CommandName == "deleteBroucher")
            {

                result = bal.deleteQuotationdetailsBrocherbyidBAL(deleteItem);

                ShowMessage("Record Deleted!!!", MessageType.Success);

                bindQuotationitemdata();


            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void DropDownListID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCurrency.ClearSelection();
        txtcurrency.Text = "1";
        dpprincipal.ClearSelection();
        dpsuppliers.ClearSelection();
        dpuom.ClearSelection();

        txtqty.Text = "";
        txtamount.Text = "";
        txtrate.Text = "";
    }
}
























