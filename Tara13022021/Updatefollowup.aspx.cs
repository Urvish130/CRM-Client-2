using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Updatefollowup : System.Web.UI.Page
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
                string zoneId = "India Standard Time";
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
                DateTime now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi);
                txtfdate.Text = now.ToString("dd/MM/yyyy");
                txtdate.Text = now.ToString("dd/MM/yyyy");
                lblloginid.Text = Session["no"].ToString();
                lblrole.Text = Session["role"].ToString();
                bindcustgroup();
                bindstatus();

                bindsource();
                bindfollowup();
                bindassignto();
                binditem();
                binduom();
                binddepartment();
                binddesignation();
                filldata();
                binditemdata();
                bindfollowupdata();
               // btnUpdate.Visible = true;

            }




        }
    }


    public void filldata()
    {
        try
        {
            DataTable dtdata = bal.getallInqiurydatabynoBAL(lblcomno.Text);
            if (dtdata.Rows.Count > 0)
            {
                txtno.Text = dtdata.Rows[0]["InqiuryNo"].ToString();
                txtdate.Text = dtdata.Rows[0]["Inquirydate"].ToString();
                txtemail.Text = dtdata.Rows[0]["ContactEmail"].ToString();
                txtcontactno.Text = dtdata.Rows[0]["Custcontactno"].ToString();
                txtmobileno.Text = dtdata.Rows[0]["ContactMno1"].ToString();
                txtmobileno2.Text = dtdata.Rows[0]["ContactMno2"].ToString();
                dpcustgroup.SelectedValue = dtdata.Rows[0]["Groupno"].ToString();


                bincustnanme();
                dpcust.SelectedValue = dtdata.Rows[0]["Cno"].ToString();

                bincustcontact();


                dpcontactper.SelectedValue = dtdata.Rows[0]["Custcontact"].ToString();
                dpsource.SelectedValue = dtdata.Rows[0]["InquirySource"].ToString();
                dpstatus.SelectedValue = dtdata.Rows[0]["InqiuryStatus"].ToString();

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

            }
        }
        catch (Exception ex)
        {

        }
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



    public void bincustnanme()
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
    protected void dpcust_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            bincustcontact();
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
            dt1 = bal.checkProductNameBAL(lblcomno.Text, dpitem.SelectedItem.Text);
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

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
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
                   // btnaddproduct.Visible = false;
                    //lbtnupdatecontact.Visible = true;
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


           // btnaddproduct.Visible = true;
            //lbtnupdatecontact.Visible = false;

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
            dt1 = bal.checkFollowupBAL(lblcomno.Text, txtfdate.Text, Convert.ToInt32(dpfollowuptype.SelectedValue.ToString()));
            if (dt1.Rows.Count > 0)
            {
                ShowMessage("Name Already Exist!!!", MessageType.Error);
            }
            else
            {

                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);

                bal.tbl_Inqiury_Followup_InsertBAL(Convert.ToInt32(lblcomno.Text), txtfdate.Text, Convert.ToInt32(dpfollowuptype.SelectedValue.ToString()), Convert.ToInt32(dpassignto.SelectedValue.ToString()), Convert.ToInt32(dpfollowstatus.SelectedValue.ToString()), txtfremarks.Text, "", "", lblloginid.Text, localTime, "", "", "", "", "");
                resetfollowup();
                bindfollowupdata();
                //txtcontactname.Focus();
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
            dtcontact = bal.getFollowupdataforeditBal(Convert.ToInt32(lblloginid.Text),Convert.ToInt32(lblcomno.Text));
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
            dpassignto.ClearSelection();

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

            bal.tbl_Inqiury_Followup_updateBAL(Convert.ToInt32(lblid.Text), Convert.ToInt32(lblcomno.Text), txtfdate.Text, Convert.ToInt32(dpfollowuptype.SelectedValue.ToString()), Convert.ToInt32(dpassignto.SelectedValue.ToString()), Convert.ToInt32(dpfollowstatus.SelectedValue.ToString()), txtfremarks.Text, "", "", lblloginid.Text, localTime, "", "", "", "", "");
            resetfollowup();
            bindfollowupdata();
            ShowMessage("Record Save!!!", MessageType.Success);


            lbtnaddfollowup.Visible = true;
            lbtnupdatefollowup.Visible = false;

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
                DataTable dtdata = bal.getFollowupDetailsdatabyidBAL(lblid.Text);
                if (dtdata.Rows.Count > 0)
                {
                    dpfollowuptype.SelectedValue = dtdata.Rows[0]["Follotype"].ToString();

                    dpfollowstatus.SelectedValue = dtdata.Rows[0]["FolloStatus"].ToString();


                    txtfremarks.Text = dtdata.Rows[0]["Remarks"].ToString();
                    txtfdate.Text = dtdata.Rows[0]["NextFolldate"].ToString();
                    dpassignto.SelectedValue = dtdata.Rows[0]["Assignto"].ToString();


                    lbtnaddfollowup.Visible = false;
                    lbtnupdatefollowup.Visible = true;
                    //  bindDetail();
                }
            }
            else if (e.CommandName == "deletedata")
            {

                result = bal.deleteinquiryfollowupdatabyidBAL(lblid.Text);

                ShowMessage("Record Deleted!!!", MessageType.Success);

                bindfollowupdata();


            }

        }
        catch (Exception ex)
        {

        }
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {


            string Groupid = bal.getCustomerGroupIdbynameDAL(dpcustgroup.SelectedItem.Text);
            string custid = bal.getCustomerIdbynameBAL(dpcust.SelectedItem.Text);



            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);


            bal.tbl_Inqiury_Master_UpdateBAL(Convert.ToInt32(txtno.Text), Convert.ToInt32(lblcomno.Text), txtdate.Text, Convert.ToInt32(Groupid), Convert.ToInt32(custid), Convert.ToInt32(dpcontactper.SelectedValue.ToString()), txtcontactno.Text, Convert.ToInt32(ddlDept.SelectedValue.ToString()), Convert.ToInt32(ddldesign.SelectedValue.ToString()), txtemail.Text, txtmobileno.Text, txtmobileno2.Text, Convert.ToInt32(dpstatus.SelectedValue.ToString()), Convert.ToInt32(dpsource.SelectedValue.ToString()), txtremarks.Text, lblloginid.Text, localTime, "", "", "", "", "");
            Response.Redirect("InquiryRegister.aspx", false);

        }
        catch (Exception ex)
        {

        }

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
}