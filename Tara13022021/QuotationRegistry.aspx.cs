using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Data.Odbc;
using System.Net.Mail;
using System.Net;

public partial class QuotationRegistry : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    Getconnection c = new Getconnection();
    BusinessLogicLayer bal = new BusinessLogicLayer();
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
                lblcompanyno.Text = Session["Companyno"].ToString();
                bindDetail();
            }
            
            

        }
    }
    protected void btncreate_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Quotation.aspx", false);
        }
        catch (Exception ex)
        {

        }

    }

    public void bindDetail()
    {

        try
        {
            string RoleName = Session["rolename"].ToString();
            if (RoleName.Equals("Admin"))
            {
                dt = bal.getallQuotationdataforadminBAL();


            }
            else
            {
                dt = bal.getallQuotationdataforemployeeBAL(lblcompanyno.Text);
            }
           



            if (dt.Rows.Count > 0)
            {
                grddata.DataSource = dt;
                grddata.DataBind();
                grddata.UseAccessibleHeader = true;
                grddata.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                grddata.DataSource = dt;
                grddata.DataBind();
                grddata.UseAccessibleHeader = true;
                grddata.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Getconnection.SiteErrorInsert(ex);
        }
    }
    protected void grddata_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string result;
            lblid.Text = e.CommandArgument.ToString();
            if (e.CommandName == "editdata")
            {
                Response.Redirect(String.Format("UpdateQuotation.aspx?no={0}", lblid.Text), false);
            }
            else if (e.CommandName == "revisedata")
            {
                Response.Redirect(String.Format("ReviseQuotation.aspx?no={0}", lblid.Text), false);
            }
            else if (e.CommandName == "Copydata")
            {
                Response.Redirect(String.Format("CopyQuotation.aspx?no={0}", lblid.Text), false);
            }
            else if (e.CommandName == "wondata")
            {
                Response.Redirect(String.Format("OrderEntry.aspx?quoteno={0}", lblid.Text), false);
            }
            else if (e.CommandName == "lossdata")
            {
                Response.Redirect(String.Format("OrderRegistry.aspx?no={0}", lblid.Text), false);
            }
            else if (e.CommandName == "printdata")
            {
                Response.Redirect(String.Format("QuotationReport.aspx?Id={0}", lblid.Text), false);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnExportExcel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            bindDetail();
            grddata.Columns[0].Visible = false;
            grddata.Columns[1].Visible = false;
            grddata.Columns[2].Visible = false;
            grddata.Columns[3].Visible = false;
            grddata.Columns[12].Visible = false;
            grddata.Columns[13].Visible = false;
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition",
             "attachment;filename=QuotationRegister.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            grddata.AllowPaging = false;
            grddata.DataBind();

            //Change the Header Row back to white color
            grddata.HeaderRow.Style.Add("background-color", "#FFFFFF");

            //Apply style to Individual Cells
            grddata.HeaderRow.Cells[3].Style.Add("background-color", "green");
            grddata.HeaderRow.Cells[4].Style.Add("background-color", "green");
            grddata.HeaderRow.Cells[5].Style.Add("background-color", "green");
            grddata.HeaderRow.Cells[6].Style.Add("background-color", "green");
            grddata.HeaderRow.Cells[7].Style.Add("background-color", "green");
            grddata.HeaderRow.Cells[8].Style.Add("background-color", "green");
            grddata.HeaderRow.Cells[9].Style.Add("background-color", "green");
            grddata.HeaderRow.Cells[10].Style.Add("background-color", "green");
            grddata.HeaderRow.Cells[11].Style.Add("background-color", "green");
            //grdVisit.HeaderRow.Cells[17].Style.Add("background-color", "green");
            for (int i = 0; i < grddata.Rows.Count; i++)
            {
                GridViewRow row = grddata.Rows[i];
                //Change Color back to white
                row.BackColor = System.Drawing.Color.White;
                //Apply text style to each Row
                row.Attributes.Add("class", "textmode");
                //Apply style to Individual Cells of Alternating Row
                if (i % 2 != 0)
                {
                    row.Cells[3].Style.Add("background-color", "#C2D69B");
                    row.Cells[4].Style.Add("background-color", "#C2D69B");
                    row.Cells[5].Style.Add("background-color", "#C2D69B");
                    row.Cells[6].Style.Add("background-color", "#C2D69B");
                    row.Cells[7].Style.Add("background-color", "#C2D69B");
                    row.Cells[8].Style.Add("background-color", "#C2D69B");
                    row.Cells[9].Style.Add("background-color", "#C2D69B");
                    row.Cells[10].Style.Add("background-color", "#C2D69B");
                    row.Cells[11].Style.Add("background-color", "#C2D69B");
                }
            }
            grddata.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            bindDetail();
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnExportPDF_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            bindDetail();
            grddata.Columns[0].Visible = false;
            grddata.Columns[1].Visible = false;
            grddata.Columns[2].Visible = false;
            grddata.Columns[3].Visible = false;
            grddata.Columns[12].Visible = false;
            grddata.Columns[13].Visible = false;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=QuotationRegister.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grddata.AllowPaging = false;
            grddata.DataBind();
             grddata.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        catch (Exception ex)
        { }
    }

    protected void btnExportWord_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            bindDetail();
            grddata.Columns[0].Visible = false;
            grddata.Columns[1].Visible = false;
            grddata.Columns[2].Visible = false;
            grddata.Columns[3].Visible = false;
            grddata.Columns[12].Visible = false;
            grddata.Columns[13].Visible = false;
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=QuotationRegister.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grddata.AllowPaging = false;
            grddata.DataBind();
            grddata.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}