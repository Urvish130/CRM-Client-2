using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DataAccessLayer
/// </summary>
public class DataAccessLayer
{
    Getconnection con = new Getconnection();
    SqlConnection c;
    SqlCommand cmd;
    public DataAccessLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataTable checklogindetailsDAL(string Eemailid, string Epwd)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checklogindetails", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Eemailid", SqlDbType.VarChar).Value = Eemailid;
            cmd.Parameters.Add("@Epwd", SqlDbType.VarChar).Value = Epwd;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    #region IndustrygroupMaster
    public string SaveIndustrygroupMasterDAL(string GroupName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Industrygroup_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GroupName", SqlDbType.VarChar).Value = GroupName;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable getallIndustrygroupDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallIndustrygroup", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallIndustrygroupfroadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallIndustrygroupfroadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkIndustrygroupnamedal(string GroupName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkIndustrygroupname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@GroupName", SqlDbType.VarChar).Value = GroupName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getIndustrygroupdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getIndustrygroupdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteIndustrygroupbyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteIndustrygroupdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string tbl_Industrygroup_UpdateDAL(string Id, string GroupName)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Industrygroup_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@GroupName", SqlDbType.VarChar).Value = GroupName;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    #endregion
    #region BussinessTypeMaster
    public string SaveBussinessTypeMasterDAL(string BussType, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_BussinessType_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BussType", SqlDbType.VarChar).Value = BussType;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable getallBussinessTypeDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallBussinessType", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallBussinessTypeforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallBussinessTypeforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallPrincipalforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallPrincipalforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallSuppliersforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallSuppliersforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkBussinessTypenameDAL(string BussType)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkBussinessTypename", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@BussType", SqlDbType.VarChar).Value = BussType;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getBussinessTypedatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getBussinessTypedatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteBussinessTypedatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteBussinessTypedatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string tbl_BussinessType_UpdateDAL(string Id, string BussType)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_BussinessType_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@BussType", SqlDbType.VarChar).Value = BussType;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    #endregion
    #region Noseries
    public string tbl_Company_NoSeries_InsertDAL(string CompanyNo, string Extra1, string Extra2)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Company_NoSeries_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CompanyNo", SqlDbType.BigInt).Value = CompanyNo;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_AssignProduct_NoSeries_InsertDAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_AssignProduct_NoSeries_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.BigInt).Value = No;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_CustomerGroup_NoSeries_InsertDAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_CustomerGroup_NoSeries_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.BigInt).Value = No;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Customer_Noseries_InsertDAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Customer_Noseries_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.BigInt).Value = No;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Supplier_Noseries_InsertDAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Supplier_Noseries_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.BigInt).Value = No;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Employee_NoSeries_InsertDAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Employee_NoSeries_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.BigInt).Value = No;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Item_NoSeries_InsertDAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Item_NoSeries_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.BigInt).Value = No;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_Principal_NoSeries_InsertDAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Principal_NoSeries_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.BigInt).Value = No;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    #endregion
    #region DepartmentMaster

    public string tbl_Department_Master_InsertDAL(string DeptName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Department_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DeptName", SqlDbType.VarChar).Value = DeptName;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable checkDepartmentnameDAL(string DeptName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkDepartmentname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@DeptName", SqlDbType.VarChar).Value = DeptName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getDepartment_MasterDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getDepartment_Master", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable getDepartment_MasterforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getDepartment_Masterforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getDepartmentdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getDepartmentdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteDepartmentdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteDepartmentdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_DepartmentMaster_UpdateDAL(string Id, string DeptName)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_DepartmentMaster_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@DeptName", SqlDbType.VarChar).Value = DeptName;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    #endregion
    #region DesignationMaster

    public DataTable getDesignation_MasterDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getDesignation_Master", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getDesignation_MasterforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getDesignation_Masterforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkDesignationnameDAL(string DesigName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkDesignationname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@DesigName", SqlDbType.VarChar).Value = DesigName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Designation_Master_InsertDAL(string DesigName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Designation_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DesigName", SqlDbType.VarChar).Value = DesigName;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable getDesignationdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getDesignationdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteDesignationdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteDesignationdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_Designation_UpdateDAL(string Id, string DesigName)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Designation_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@DesigName", SqlDbType.VarChar).Value = DesigName;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    #endregion
    #region CompanyMaster
    public DataTable checkcompanynamemasterDAL(string Name)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkcompanynamemaster", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public string tbl_Company_Contact_Master_InsertDAL(string Companyno, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Company_Contact_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Companyno", SqlDbType.VarChar).Value = Companyno;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = ContactPhone;
            cmd.Parameters.Add("@ContactMobileno1", SqlDbType.VarChar).Value = ContactMobileno1;
            cmd.Parameters.Add("@ContactMobileno2", SqlDbType.VarChar).Value = ContactMobileno2;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable getcompanycontactdataDAL( int companyno)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getcompanycontactdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@companyno", SqlDbType.BigInt).Value = companyno;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getcompanycontactdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getcompanycontactdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public string deletecompanycontactdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletecompanycontactdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }





    public string tbl_Company_Contact_Master_updateDAL(int Id, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Company_Contact_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = ContactPhone;
            cmd.Parameters.Add("@ContactMobileno1", SqlDbType.VarChar).Value = ContactMobileno1;
            cmd.Parameters.Add("@ContactMobileno2", SqlDbType.VarChar).Value = ContactMobileno2;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;

            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }




    public DataTable checkcompanycontactnameDAL(string companyno, string ContactName, string ContactEmail)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkcompanycontactname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@companyno", SqlDbType.VarChar).Value = companyno;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public string tbl_Company_Master_InsertDAL(string Companyno, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string ComCountry, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Company_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Companyno", SqlDbType.VarChar).Value = Companyno;
            cmd.Parameters.Add("@Comname", SqlDbType.VarChar).Value = Comname;
            cmd.Parameters.Add("@Comarea", SqlDbType.VarChar).Value = Comarea;
            cmd.Parameters.Add("@Comaddress", SqlDbType.VarChar).Value = Comaddress;
            cmd.Parameters.Add("@Comcity", SqlDbType.VarChar).Value = Comcity;
            cmd.Parameters.Add("@Comstate", SqlDbType.VarChar).Value = Comstate;
            cmd.Parameters.Add("@ComDistrict", SqlDbType.VarChar).Value = ComDistrict;
            cmd.Parameters.Add("@ComCountry", SqlDbType.VarChar).Value = ComCountry;
            cmd.Parameters.Add("@ComPincode", SqlDbType.VarChar).Value = ComPincode;
            cmd.Parameters.Add("@ComPhoneNo", SqlDbType.VarChar).Value = ComPhoneNo;
            cmd.Parameters.Add("@ComEmail", SqlDbType.VarChar).Value = ComEmail;
            cmd.Parameters.Add("@BussinessType", SqlDbType.Int).Value = BussinessType;
            cmd.Parameters.Add("@Industrygroup", SqlDbType.Int).Value = Industrygroup;
            cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = URL;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
            cmd.Parameters.Add("@GSTno", SqlDbType.VarChar).Value = GSTno;
            cmd.Parameters.Add("@Bankname", SqlDbType.VarChar).Value = Bankname;
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar).Value = Accountno;
            cmd.Parameters.Add("@IFSCcode", SqlDbType.VarChar).Value = IFSCcode;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getallcompanydataDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallcompanydata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable getallcompanydataforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallcompanydataforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallCustomercontactdataDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallCustomercontactdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallcompanydatabycomnoDAL(string comno)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallcompanydatabycomno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@comno", SqlDbType.VarChar).Value = comno;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public string tbl_Company_Master_updateDAL(string Companyno, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string ComCountry, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Company_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Companyno", SqlDbType.VarChar).Value = Companyno;
            cmd.Parameters.Add("@Comname", SqlDbType.VarChar).Value = Comname;
            cmd.Parameters.Add("@Comarea", SqlDbType.VarChar).Value = Comarea;
            cmd.Parameters.Add("@Comaddress", SqlDbType.VarChar).Value = Comaddress;
            cmd.Parameters.Add("@Comcity", SqlDbType.VarChar).Value = Comcity;
            cmd.Parameters.Add("@Comstate", SqlDbType.VarChar).Value = Comstate;
            cmd.Parameters.Add("@ComDistrict", SqlDbType.VarChar).Value = ComDistrict;
            cmd.Parameters.Add("@ComCountry", SqlDbType.VarChar).Value = ComCountry;
            cmd.Parameters.Add("@ComPincode", SqlDbType.VarChar).Value = ComPincode;
            cmd.Parameters.Add("@ComPhoneNo", SqlDbType.VarChar).Value = ComPhoneNo;
            cmd.Parameters.Add("@ComEmail", SqlDbType.VarChar).Value = ComEmail;
            cmd.Parameters.Add("@BussinessType", SqlDbType.Int).Value = BussinessType;
            cmd.Parameters.Add("@Industrygroup", SqlDbType.Int).Value = Industrygroup;
            cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = URL;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
            cmd.Parameters.Add("@GSTno", SqlDbType.VarChar).Value = GSTno;
            cmd.Parameters.Add("@Bankname", SqlDbType.VarChar).Value = Bankname;
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar).Value = Accountno;
            cmd.Parameters.Add("@IFSCcode", SqlDbType.VarChar).Value = IFSCcode;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string deletecompanydatabyCompanynoDAL(string companyno)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletecompanydatabyCompanyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@companyno", SqlDbType.VarChar).Value = companyno;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    #endregion
    #region CustomerGroup

    public string tbl_CustomerGroup_Contact_Master_InsertDAL(string Groupno, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_CustomerGroup_Contact_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Groupno", SqlDbType.VarChar).Value = Groupno;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = ContactPhone;
            cmd.Parameters.Add("@ContactMobileno1", SqlDbType.VarChar).Value = ContactMobileno1;
            cmd.Parameters.Add("@ContactMobileno2", SqlDbType.VarChar).Value = ContactMobileno2;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable checkcustomergroupcontactnameDAL(string Groupno, string ContactName, string ContactEmail)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkcustomergroupcontactname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Groupno", SqlDbType.VarChar).Value = Groupno;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkCustomerGroup_Master_nameDAL(string name)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkCustomerGroup_Master_name", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
           
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkCustomer_Master_nameDAL(string name)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkCustomer_Master_name", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getCustomerGroupcontactdataDAL( int Groupno)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getCustomerGroupcontactdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
         //   cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Groupno", SqlDbType.BigInt).Value = Groupno;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getCustomerGroupcontactdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getCustomerGroupcontactdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteCustomerGroupcontactdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteCustomerGroupcontactdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_CustomerGroup_Contact_Master_updateDAL(int Id, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_CustomerGroup_Contact_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = ContactPhone;
            cmd.Parameters.Add("@ContactMobileno1", SqlDbType.VarChar).Value = ContactMobileno1;
            cmd.Parameters.Add("@ContactMobileno2", SqlDbType.VarChar).Value = ContactMobileno2;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;


            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_CustomerGroup_Master_InsertDAL(string Groupno, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_CustomerGroup_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Groupno", SqlDbType.VarChar).Value = Groupno;
            cmd.Parameters.Add("@Comname", SqlDbType.VarChar).Value = Comname;
            cmd.Parameters.Add("@Comarea", SqlDbType.VarChar).Value = Comarea;
            cmd.Parameters.Add("@Comaddress", SqlDbType.VarChar).Value = Comaddress;
            cmd.Parameters.Add("@Comcity", SqlDbType.VarChar).Value = Comcity;
            cmd.Parameters.Add("@Comstate", SqlDbType.VarChar).Value = Comstate;
            cmd.Parameters.Add("@ComDistrict", SqlDbType.VarChar).Value = ComDistrict;
            cmd.Parameters.Add("Country", SqlDbType.VarChar).Value = Country;
            cmd.Parameters.Add("@ComPincode", SqlDbType.VarChar).Value = ComPincode;
            cmd.Parameters.Add("@ComPhoneNo", SqlDbType.VarChar).Value = ComPhoneNo;
            cmd.Parameters.Add("@ComEmail", SqlDbType.VarChar).Value = ComEmail;
            cmd.Parameters.Add("@BussinessType", SqlDbType.Int).Value = BussinessType;
            cmd.Parameters.Add("@Industrygroup", SqlDbType.Int).Value = Industrygroup;
            cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = URL;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
            cmd.Parameters.Add("@GSTno", SqlDbType.VarChar).Value = GSTno;
            cmd.Parameters.Add("@Bankname", SqlDbType.VarChar).Value = Bankname;
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar).Value = Accountno;
            cmd.Parameters.Add("@IFSCcode", SqlDbType.VarChar).Value = IFSCcode;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable getallCustomerGroupdataDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallCustomerGroupdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable getallCustomerGroupdataforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallCustomerGroupdataforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable getallCustomerGroupdatabyGroupnoDAL(string Groupno)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallCustomerGroupdatabyGroupno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Groupno", SqlDbType.VarChar).Value = Groupno;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_CustomerGroup_Master_updateDAL(string Groupno, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_CustomerGroup_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Groupno", SqlDbType.VarChar).Value = Groupno;
            cmd.Parameters.Add("@Comname", SqlDbType.VarChar).Value = Comname;
            cmd.Parameters.Add("@Comarea", SqlDbType.VarChar).Value = Comarea;
            cmd.Parameters.Add("@Comaddress", SqlDbType.VarChar).Value = Comaddress;
            cmd.Parameters.Add("@Comcity", SqlDbType.VarChar).Value = Comcity;
            cmd.Parameters.Add("@Comstate", SqlDbType.VarChar).Value = Comstate;
            cmd.Parameters.Add("@ComDistrict", SqlDbType.VarChar).Value = ComDistrict;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = Country;
            cmd.Parameters.Add("@ComPincode", SqlDbType.VarChar).Value = ComPincode;
            cmd.Parameters.Add("@ComPhoneNo", SqlDbType.VarChar).Value = ComPhoneNo;
            cmd.Parameters.Add("@ComEmail", SqlDbType.VarChar).Value = ComEmail;
            cmd.Parameters.Add("@BussinessType", SqlDbType.Int).Value = BussinessType;
            cmd.Parameters.Add("@Industrygroup", SqlDbType.Int).Value = Industrygroup;
            cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = URL;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
            cmd.Parameters.Add("@GSTno", SqlDbType.VarChar).Value = GSTno;
            cmd.Parameters.Add("@Bankname", SqlDbType.VarChar).Value = Bankname;
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar).Value = Accountno;
            cmd.Parameters.Add("@IFSCcode", SqlDbType.VarChar).Value = IFSCcode;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string deleteCustomerGroupdatabyCompanynoDAL(string Groupno)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteCustomerGroupdatabyCompanyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Groupno", SqlDbType.VarChar).Value = Groupno;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    #endregion


    #region CustomerMaster
    public DataTable getCustomerGroupNameDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getCustomerGroupName", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkcustomercontactnameDAL(string Custno, string ContactName, string ContactEmail)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkcustomercontactname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Custno", SqlDbType.VarChar).Value = Custno;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Customer_Contact_Master_InsertDAL(string Custno, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Customer_Contact_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Custno", SqlDbType.VarChar).Value = Custno;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = ContactPhone;
            cmd.Parameters.Add("@ContactMobileno1", SqlDbType.VarChar).Value = ContactMobileno1;
            cmd.Parameters.Add("@ContactMobileno2", SqlDbType.VarChar).Value = ContactMobileno2;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getCustomercontactdataDAL(  int Custno)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getCustomercontactdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
         //   cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Custno", SqlDbType.BigInt).Value = Custno;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;

    }

    public DataTable getCustomercontactdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getCustomercontactdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deleteCustomercontactdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteCustomercontactdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_Customer_Contact_Master_updateDAL(int Id, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Customer_Contact_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = ContactPhone;
            cmd.Parameters.Add("@ContactMobileno1", SqlDbType.VarChar).Value = ContactMobileno1;
            cmd.Parameters.Add("@ContactMobileno2", SqlDbType.VarChar).Value = ContactMobileno2;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Customer_Master_InsertDAL(string No, string GroupNo, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Customer_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;
            cmd.Parameters.Add("@GroupNo", SqlDbType.VarChar).Value = GroupNo;
            cmd.Parameters.Add("@Comname", SqlDbType.VarChar).Value = Comname;
            cmd.Parameters.Add("@Comarea", SqlDbType.VarChar).Value = Comarea;
            cmd.Parameters.Add("@Comaddress", SqlDbType.VarChar).Value = Comaddress;
            cmd.Parameters.Add("@Comcity", SqlDbType.VarChar).Value = Comcity;
            cmd.Parameters.Add("@Comstate", SqlDbType.VarChar).Value = Comstate;
            cmd.Parameters.Add("@ComDistrict", SqlDbType.VarChar).Value = ComDistrict;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = Country;
            cmd.Parameters.Add("@ComPincode", SqlDbType.VarChar).Value = ComPincode;
            cmd.Parameters.Add("@ComPhoneNo", SqlDbType.VarChar).Value = ComPhoneNo;
            cmd.Parameters.Add("@ComEmail", SqlDbType.VarChar).Value = ComEmail;
            cmd.Parameters.Add("@BussinessType", SqlDbType.Int).Value = BussinessType;
            cmd.Parameters.Add("@Industrygroup", SqlDbType.Int).Value = Industrygroup;
            cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = URL;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
            cmd.Parameters.Add("@GSTno", SqlDbType.VarChar).Value = GSTno;
            cmd.Parameters.Add("@Bankname", SqlDbType.VarChar).Value = Bankname;
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar).Value = Accountno;
            cmd.Parameters.Add("@IFSCcode", SqlDbType.VarChar).Value = IFSCcode;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getallCustomerMasterataDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallCustomerMasterata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallCustomerMasterataforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallCustomerMasterataforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallCustomerdatabynoDAL(string No)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallCustomerdatabyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Customer_Master_updateDAL(string No, string GroupNo, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Customer_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;
            cmd.Parameters.Add("@GroupNo", SqlDbType.VarChar).Value = GroupNo;
            cmd.Parameters.Add("@Comname", SqlDbType.VarChar).Value = Comname;
            cmd.Parameters.Add("@Comarea", SqlDbType.VarChar).Value = Comarea;
            cmd.Parameters.Add("@Comaddress", SqlDbType.VarChar).Value = Comaddress;
            cmd.Parameters.Add("@Comcity", SqlDbType.VarChar).Value = Comcity;
            cmd.Parameters.Add("@Comstate", SqlDbType.VarChar).Value = Comstate;
            cmd.Parameters.Add("@ComDistrict", SqlDbType.VarChar).Value = ComDistrict;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = Country;
            cmd.Parameters.Add("@ComPincode", SqlDbType.VarChar).Value = ComPincode;
            cmd.Parameters.Add("@ComPhoneNo", SqlDbType.VarChar).Value = ComPhoneNo;
            cmd.Parameters.Add("@ComEmail", SqlDbType.VarChar).Value = ComEmail;
            cmd.Parameters.Add("@BussinessType", SqlDbType.Int).Value = BussinessType;
            cmd.Parameters.Add("@Industrygroup", SqlDbType.Int).Value = Industrygroup;
            cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = URL;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
            cmd.Parameters.Add("@GSTno", SqlDbType.VarChar).Value = GSTno;
            cmd.Parameters.Add("@Bankname", SqlDbType.VarChar).Value = Bankname;
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar).Value = Accountno;
            cmd.Parameters.Add("@IFSCcode", SqlDbType.VarChar).Value = IFSCcode;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string deleteCustomerdatabynoDAL(string No)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteCustomerdatabyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    #endregion



    #region EmployeeMaster


    public string tbl_Employee_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Employee_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getallemployenameforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallemployenameforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getdocumentadataDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getdocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
          //  cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteemployeedocumentdatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteemployeedocumentdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable checkEmployee_master_detailsDAL(string txtName, string txtfhname, string txtsurname, string txtphno)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkEmployee_master_details", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@txtName", SqlDbType.VarChar).Value = txtName;
            cmd.Parameters.Add("@txtfhname", SqlDbType.VarChar).Value = txtfhname;
            cmd.Parameters.Add("@txtsurname", SqlDbType.VarChar).Value = txtsurname;
            cmd.Parameters.Add("@txtphno", SqlDbType.VarChar).Value = txtphno;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Employee_master_InsertDAL(string no, string Ename, string Efname, string Esurname, string Egender,
        string Epaddress, string Eperaddress, string ECity, string EState, string EDistrict, string ECountry, string EPincode, string EPhoneNo, string Emobilenop, string Emobileoffice, string Emobilewhatsup,
        string Erole, string Epfno, string Edoa, string Edoj, string Edol, int Edept, int Edesign,
        string Eemailid, string Epwd, string Eurgentcontactname, string Eurgentcontactno, string Eurgentcontactrelation, string Estatus, string Ebankname, string Eaccno, string Eifsccode,

        string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string txtbulkemail, string txtbulkpassword, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Employee_master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@Ename", SqlDbType.VarChar).Value = Ename;
            cmd.Parameters.Add("@Efname", SqlDbType.VarChar).Value = Efname;
            cmd.Parameters.Add("@Esurname", SqlDbType.VarChar).Value = Esurname;
            cmd.Parameters.Add("@Egender", SqlDbType.VarChar).Value = Egender;
            cmd.Parameters.Add("@Epaddress", SqlDbType.VarChar).Value = Epaddress;
            cmd.Parameters.Add("@Eperaddress", SqlDbType.VarChar).Value = Eperaddress;


            cmd.Parameters.Add("@ECity", SqlDbType.VarChar).Value = ECity;
            cmd.Parameters.Add("@EState", SqlDbType.VarChar).Value = EState;
            cmd.Parameters.Add("@EDistrict", SqlDbType.VarChar).Value = EDistrict;
            cmd.Parameters.Add("@ECountry", SqlDbType.VarChar).Value = ECountry;
            cmd.Parameters.Add("@EPincode", SqlDbType.VarChar).Value = EPincode;
            cmd.Parameters.Add("@EPhoneNo", SqlDbType.VarChar).Value = EPhoneNo;

            cmd.Parameters.Add("@Emobilenop", SqlDbType.VarChar).Value = Emobilenop;
            cmd.Parameters.Add("@Emobileoffice", SqlDbType.VarChar).Value = Emobileoffice;
            cmd.Parameters.Add("@Emobilewhatsup", SqlDbType.VarChar).Value = Emobilewhatsup;
            cmd.Parameters.Add("@Erole", SqlDbType.VarChar).Value = Erole;
            cmd.Parameters.Add("@Epfno", SqlDbType.VarChar).Value = Epfno;
            cmd.Parameters.Add("@Edoa", SqlDbType.VarChar).Value = Edoa;
            cmd.Parameters.Add("@Edoj", SqlDbType.VarChar).Value = Edoj;
            cmd.Parameters.Add("@Edol", SqlDbType.VarChar).Value = Edol;
            cmd.Parameters.Add("@Edept", SqlDbType.Int).Value = Edept;
            cmd.Parameters.Add("@Edesign", SqlDbType.Int).Value = Edesign;
            cmd.Parameters.Add("@Eemailid", SqlDbType.VarChar).Value = Eemailid;
            cmd.Parameters.Add("@Epwd", SqlDbType.VarChar).Value = Epwd;
            cmd.Parameters.Add("@Eurgentcontactname", SqlDbType.VarChar).Value = Eurgentcontactname;
            cmd.Parameters.Add("@Eurgentcontactno", SqlDbType.VarChar).Value = Eurgentcontactno;
            cmd.Parameters.Add("@Eurgentcontactrelation", SqlDbType.VarChar).Value = Eurgentcontactrelation;

            cmd.Parameters.Add("@Estatus", SqlDbType.VarChar).Value = Estatus;
            cmd.Parameters.Add("@Ebankname", SqlDbType.VarChar).Value = Ebankname;
            cmd.Parameters.Add("@Eaccno", SqlDbType.VarChar).Value = Eaccno;
            cmd.Parameters.Add("@Eifsccode", SqlDbType.VarChar).Value = Eifsccode;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = txtbulkemail;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = txtbulkpassword;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }



    public DataTable getallemployeedataDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallemployeedata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallemployeedataforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallemployeedataforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getemployeedatanoDAL(string no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getemployeedatano", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deleteemployeedatabynoDAL(string no)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteemployeedatabyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }



    public string tbl_Employee_master_UpdateDAL(string no, string Ename, string Efname, string Esurname, string Egender,
      string Epaddress, string Eperaddress, string ECity, string EState, string EDistrict, string ECountry, string EPincode, string EPhoneNo, string Emobilenop, string Emobileoffice, string Emobilewhatsup,
      string Erole, string Epfno, string Edoa, string Edoj, string Edol, int Edept, int Edesign,
      string Eemailid, string Epwd, string Eurgentcontactname, string Eurgentcontactno, string Eurgentcontactrelation, string Estatus, string Ebankname, string Eaccno, string Eifsccode,
        string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string txtbulkemail, string txtbulkpassword, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Employee_master_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@Ename", SqlDbType.VarChar).Value = Ename;
            cmd.Parameters.Add("@Efname", SqlDbType.VarChar).Value = Efname;
            cmd.Parameters.Add("@Esurname", SqlDbType.VarChar).Value = Esurname;
            cmd.Parameters.Add("@Egender", SqlDbType.VarChar).Value = Egender;
            cmd.Parameters.Add("@Epaddress", SqlDbType.VarChar).Value = Epaddress;
            cmd.Parameters.Add("@Eperaddress", SqlDbType.VarChar).Value = Eperaddress;

            cmd.Parameters.Add("@ECity", SqlDbType.VarChar).Value = ECity;
            cmd.Parameters.Add("@EState", SqlDbType.VarChar).Value = EState;
            cmd.Parameters.Add("@EDistrict", SqlDbType.VarChar).Value = EDistrict;
            cmd.Parameters.Add("@ECountry", SqlDbType.VarChar).Value = ECountry;
            cmd.Parameters.Add("@EPincode", SqlDbType.VarChar).Value = EPincode;
            cmd.Parameters.Add("@EPhoneNo", SqlDbType.VarChar).Value = EPhoneNo;

            cmd.Parameters.Add("@Emobilenop", SqlDbType.VarChar).Value = Emobilenop;
            cmd.Parameters.Add("@Emobileoffice", SqlDbType.VarChar).Value = Emobileoffice;
            cmd.Parameters.Add("@Emobilewhatsup", SqlDbType.VarChar).Value = Emobilewhatsup;
            cmd.Parameters.Add("@Erole", SqlDbType.VarChar).Value = Erole;
            cmd.Parameters.Add("@Epfno", SqlDbType.VarChar).Value = Epfno;
            cmd.Parameters.Add("@Edoa", SqlDbType.VarChar).Value = Edoa;
            cmd.Parameters.Add("@Edoj", SqlDbType.VarChar).Value = Edoj;
            cmd.Parameters.Add("@Edol", SqlDbType.VarChar).Value = Edol;
            cmd.Parameters.Add("@Edept", SqlDbType.Int).Value = Edept;
            cmd.Parameters.Add("@Edesign", SqlDbType.Int).Value = Edesign;
            cmd.Parameters.Add("@Eemailid", SqlDbType.VarChar).Value = Eemailid;
            cmd.Parameters.Add("@Epwd", SqlDbType.VarChar).Value = Epwd;
            cmd.Parameters.Add("@Eurgentcontactname", SqlDbType.VarChar).Value = Eurgentcontactname;
            cmd.Parameters.Add("@Eurgentcontactno", SqlDbType.VarChar).Value = Eurgentcontactno;
            cmd.Parameters.Add("@Eurgentcontactrelation", SqlDbType.VarChar).Value = Eurgentcontactrelation;

            cmd.Parameters.Add("@Estatus", SqlDbType.VarChar).Value = Estatus;
            cmd.Parameters.Add("@Ebankname", SqlDbType.VarChar).Value = Ebankname;
            cmd.Parameters.Add("@Eaccno", SqlDbType.VarChar).Value = Eaccno;
            cmd.Parameters.Add("@Eifsccode", SqlDbType.VarChar).Value = Eifsccode;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = txtbulkemail;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = txtbulkpassword;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    #endregion


    #region Itemgroupmaster
    public DataTable getallItemgroupDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallItemgroupforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
       //     cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallItemgroupforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallItemgroupforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkItemgroupnameDAL(string GroupName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkItemgroupname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@GroupName", SqlDbType.VarChar).Value = GroupName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tblItemgroup_Master_InsertDAL(string ItemGroupName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tblItemgroup_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemGroupName", SqlDbType.VarChar).Value = ItemGroupName;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }



    public DataTable getItemgroupdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getItemgroupdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteItemgroupdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteItemgroupdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Itemgroup_UpdateDAL(string Id, string ItemGroupName)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Itemgroup_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@ItemGroupName", SqlDbType.VarChar).Value = ItemGroupName;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    #endregion
    #region Itemsubgroupmaster
    public DataTable getallItemsubgroup(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallItemsubgroup", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallItemsubgroupforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallItemsubgroupforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkItemsubgroupnameDAL(string GroupName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkItemsubgroupname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@GroupName", SqlDbType.VarChar).Value = GroupName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkItemsubgroupdataDAL(int id,string GroupName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkItemsubgroupdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@GroupName", SqlDbType.VarChar).Value = GroupName;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Itemsubgroup_Master_InsertDAL(string ItemSubGroupName, int ItemGroupId, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Itemsubgroup_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ItemSubGroupName", SqlDbType.VarChar).Value = ItemSubGroupName;
            cmd.Parameters.Add("@ItemGroupId", SqlDbType.Int).Value = ItemGroupId;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getItemsubgroupdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getItemsubgroupdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteItemsubgroupdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteItemsubgroupdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Itemsubgroup_Master_UpdateDAL(string Id, int ItemGroupId, string ItemSubGroupName)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Itemsubgroup_Master_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@ItemGroupId", SqlDbType.Int).Value = ItemGroupId;
            cmd.Parameters.Add("@ItemSubGroupName", SqlDbType.VarChar).Value = ItemSubGroupName;


            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    #endregion


    #region Unitmaster
    public DataTable getallunitDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallunit", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallunitforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallunitforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkUOMnameDAL(string Uom)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkUOMname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("Uom", SqlDbType.VarChar).Value = Uom;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tblItemunit_Master_InsertDAL(string Uom, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tblItemunit_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Uom", SqlDbType.VarChar).Value = Uom;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable getUOMdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getUOMdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deleteUOMdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteUOMdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tblItemunit_Master_UpdateDAL(string Id, string Uom)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tblItemunit_Master_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@Uom", SqlDbType.VarChar).Value = Uom;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    #endregion

    #region IteMaster


    public string tbl_ItemDocument_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_ItemDocument_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string tbl_Company_Image_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Company_Image_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getItemdocumentadataDAL(string lblcomno)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getItemdocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
          cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = lblcomno;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deletitemimgdatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletitemimgdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_ItemImage_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_ItemImage_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getItemimageadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getItemimageadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deletitemdocumentdatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletitemdocumentdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable checkItemnameDAL(string Itemname)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkItemname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Itemname", SqlDbType.VarChar).Value = Itemname;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public string tbl_Item_Master_InsertDAL(int no, int itemgroup, int itemsubgroup, string Modelno, string Itemname, string ItemFinalname, string Itemalis, string Itemcategoryno, int ItemUOM, decimal Itemrate, int Itemgst, string ItemHsn, string ItemDesc, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Item_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.Int).Value = no;
            cmd.Parameters.Add("@itemgroup", SqlDbType.Int).Value = itemgroup;
            cmd.Parameters.Add("@itemsubgroup", SqlDbType.Int).Value = itemsubgroup;
            cmd.Parameters.Add("@Modelno", SqlDbType.VarChar).Value = Modelno;
            cmd.Parameters.Add("@Itemname", SqlDbType.VarChar).Value = Itemname;
            cmd.Parameters.Add("ItemFinalname", SqlDbType.VarChar).Value = ItemFinalname;
            cmd.Parameters.Add("@Itemalis", SqlDbType.VarChar).Value = Itemalis;
            cmd.Parameters.Add("@Itemcategoryno", SqlDbType.VarChar).Value = Itemcategoryno;
            cmd.Parameters.Add("@ItemUOM", SqlDbType.Int).Value = ItemUOM;
            cmd.Parameters.Add("@Itemrate", SqlDbType.Decimal).Value = Itemrate;
            cmd.Parameters.Add("@Itemgst", SqlDbType.Int).Value = Itemgst;
            cmd.Parameters.Add("@ItemHsn", SqlDbType.VarChar).Value = ItemHsn;
            cmd.Parameters.Add("@ItemDesc", SqlDbType.VarChar).Value = @ItemDesc;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }




    public DataTable getallItemdataDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallItemdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          //  cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable getallItemdataforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallItemdataforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallitemdatabynoDAL(string no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallitemdatabyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Item_Master_updateDAL(int no, int itemgroup, int itemsubgroup, string Modelno, string Itemname, string ItemFinalname, string Itemalis, string Itemcategoryno, int ItemUOM, decimal Itemrate, int Itemgst, string ItemHsn, string ItemDesc, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Item_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.Int).Value = no;
            cmd.Parameters.Add("@itemgroup", SqlDbType.Int).Value = itemgroup;
            cmd.Parameters.Add("@itemsubgroup", SqlDbType.Int).Value = itemsubgroup;
            cmd.Parameters.Add("@Modelno", SqlDbType.VarChar).Value = Modelno;
            cmd.Parameters.Add("@Itemname", SqlDbType.VarChar).Value = Itemname;
            cmd.Parameters.Add("ItemFinalname", SqlDbType.VarChar).Value = ItemFinalname;
            cmd.Parameters.Add("@Itemalis", SqlDbType.VarChar).Value = Itemalis;
            cmd.Parameters.Add("@Itemcategoryno", SqlDbType.VarChar).Value = Itemcategoryno;
            cmd.Parameters.Add("@ItemUOM", SqlDbType.Int).Value = ItemUOM;
            cmd.Parameters.Add("@Itemrate", SqlDbType.Decimal).Value = Itemrate;
            cmd.Parameters.Add("@Itemgst", SqlDbType.Int).Value = Itemgst;
            cmd.Parameters.Add("@ItemHsn", SqlDbType.VarChar).Value = ItemHsn;
            cmd.Parameters.Add("@ItemDesc", SqlDbType.VarChar).Value = @ItemDesc;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string deleteitematanoDAL(string no)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteitematano", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }



    #endregion

    #region Sourcemaster
    public DataTable getallsourceDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallsource", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable getallsourceforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallsourceforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getsourcedatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getsourcedatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deletesourcedatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletesourcedatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable checksourcenameDAL(string SourceName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checksourcename", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@SourceName", SqlDbType.VarChar).Value = SourceName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Source_Master_InsertDAL(string SourceName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Source_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SourceName", SqlDbType.VarChar).Value = SourceName;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_Source_Master_UpdateDAL(string Id, string SourceName)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Source_Master_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@SourceName", SqlDbType.VarChar).Value = SourceName;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    #endregion


    #region StatusMaster
    public DataTable getallstatusDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallstatus", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallstatusforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallstatusforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getstatusdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getstatusdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deletestatusdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletestatusdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable checkstatusnameDAL(string StatusName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkstatusname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@StatusName", SqlDbType.VarChar).Value = StatusName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public string tbl_Status_Master_InsertDAL(string StatusName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Status_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StatusName", SqlDbType.VarChar).Value = StatusName;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_Status_Master_UpdateDAL(string Id, string StatusName)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Status_Master_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@StatusName", SqlDbType.VarChar).Value = StatusName;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    #endregion


    #region Followup Type Master
    public DataTable getallFollowuptypeDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallFollowuptype", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallFollowuptypeforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallFollowuptypeforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getfolowupdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getfolowupdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deletefollowupdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletefollowupdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable checkFollowupnameDAL(string FollowupName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkFollowupname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@FollowupName", SqlDbType.VarChar).Value = FollowupName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_followuptype_Master_InsertDAL(string FollowupName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_followuptype_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FollowupName", SqlDbType.VarChar).Value = FollowupName;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string tbl_followuptype_Master_UpdateDAL(string Id, string FollowupName)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_followuptype_Master_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@FollowupName", SqlDbType.VarChar).Value = FollowupName;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    #endregion


    #region Supplier Master
    public DataTable checkSuppliercontactnameDAL(string no, string ContactName, string ContactEmail)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkSuppliercontactname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkSupplier_Master_nameDAL(string Name)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkSupplier_Master_name", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
           
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Supplier_Contact_Master_InsertDAL(string no, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Supplier_Contact_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = ContactPhone;
            cmd.Parameters.Add("@ContactMobileno1", SqlDbType.VarChar).Value = ContactMobileno1;
            cmd.Parameters.Add("@ContactMobileno2", SqlDbType.VarChar).Value = ContactMobileno2;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getSuppliercontactdataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getSuppliercontactdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;

    }


    public DataTable getSuppliercontactdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getSuppliercontactdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteSuppliercontactdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteSuppliercontactdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_Supplier_Contact_Master_updateDAL(int Id, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Supplier_Contact_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = ContactPhone;
            cmd.Parameters.Add("@ContactMobileno1", SqlDbType.VarChar).Value = ContactMobileno1;
            cmd.Parameters.Add("@ContactMobileno2", SqlDbType.VarChar).Value = ContactMobileno2;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }



    public string tbl_Supplier_Master_InsertDAL(string No, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Supplier_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;

            cmd.Parameters.Add("@Comname", SqlDbType.VarChar).Value = Comname;
            cmd.Parameters.Add("@Comarea", SqlDbType.VarChar).Value = Comarea;
            cmd.Parameters.Add("@Comaddress", SqlDbType.VarChar).Value = Comaddress;
            cmd.Parameters.Add("@Comcity", SqlDbType.VarChar).Value = Comcity;
            cmd.Parameters.Add("@Comstate", SqlDbType.VarChar).Value = Comstate;
            cmd.Parameters.Add("@ComDistrict", SqlDbType.VarChar).Value = ComDistrict;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = Country;
            cmd.Parameters.Add("@ComPincode", SqlDbType.VarChar).Value = ComPincode;
            cmd.Parameters.Add("@ComPhoneNo", SqlDbType.VarChar).Value = ComPhoneNo;
            cmd.Parameters.Add("@ComEmail", SqlDbType.VarChar).Value = ComEmail;
            cmd.Parameters.Add("@BussinessType", SqlDbType.Int).Value = BussinessType;
            cmd.Parameters.Add("@Industrygroup", SqlDbType.Int).Value = Industrygroup;
            cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = URL;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
            cmd.Parameters.Add("@GSTno", SqlDbType.VarChar).Value = GSTno;
            cmd.Parameters.Add("@Bankname", SqlDbType.VarChar).Value = Bankname;
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar).Value = Accountno;
            cmd.Parameters.Add("@IFSCcode", SqlDbType.VarChar).Value = IFSCcode;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable getallSupplierMasterataDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallSupplierMasterata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallSupplierMasterataforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallSupplierMasterataforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallSupplierdatabynoDAL(string No)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallSupplierdatabyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Supplier_Master_updateDAL(string No, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Supplier_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;

            cmd.Parameters.Add("@Comname", SqlDbType.VarChar).Value = Comname;
            cmd.Parameters.Add("@Comarea", SqlDbType.VarChar).Value = Comarea;
            cmd.Parameters.Add("@Comaddress", SqlDbType.VarChar).Value = Comaddress;
            cmd.Parameters.Add("@Comcity", SqlDbType.VarChar).Value = Comcity;
            cmd.Parameters.Add("@Comstate", SqlDbType.VarChar).Value = Comstate;
            cmd.Parameters.Add("@ComDistrict", SqlDbType.VarChar).Value = ComDistrict;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = Country;
            cmd.Parameters.Add("@ComPincode", SqlDbType.VarChar).Value = ComPincode;
            cmd.Parameters.Add("@ComPhoneNo", SqlDbType.VarChar).Value = ComPhoneNo;
            cmd.Parameters.Add("@ComEmail", SqlDbType.VarChar).Value = ComEmail;
            cmd.Parameters.Add("@BussinessType", SqlDbType.Int).Value = BussinessType;
            cmd.Parameters.Add("@Industrygroup", SqlDbType.Int).Value = Industrygroup;
            cmd.Parameters.Add("@URL", SqlDbType.VarChar).Value = URL;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
            cmd.Parameters.Add("@GSTno", SqlDbType.VarChar).Value = GSTno;
            cmd.Parameters.Add("@Bankname", SqlDbType.VarChar).Value = Bankname;
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar).Value = Accountno;
            cmd.Parameters.Add("@IFSCcode", SqlDbType.VarChar).Value = IFSCcode;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string deleteSupplierdatabynoDAL(string No)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteSupplierdatabyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    #endregion


    #region PrincipalMaster


    public string tbl_PrincipalProfile_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalProfile_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_PrincipalCatlogue_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalCatlogue_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_PrincipalApp_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalApp_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_PrincipalNews_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalNews_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_PrincipalCertificate_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalCertificate_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_PrincipalPaper_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalPaper_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getProfiledocumentadataDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getProfiledocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            //cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deleteprincipalProfiledatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteprincipalProfiledatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable getCatloguedocumentadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getCatloguedocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getApplicationdocumentadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getApplicationdocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          //  cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getPaperdocumentadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getPaperdocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getNewsdocumentadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getNewsdocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          //  cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getCertifcatedocumentadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getCertifcatedocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getPPTdocumentadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getPPTdocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getIntroLetterdocumentadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getIntroLetterdocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          //  cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getClientdocumentadatDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getClientdocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteprincipalCatloguedatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteprincipalCatloguedatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string deleteprincipalApplicationdatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteprincipalApplicationdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string deleteprincipalPaperdatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteprincipalPaperdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string deleteprincipalNewsdatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteprincipalNewsdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }



    public string deleteprincipalCertificatedatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteprincipalCertificatedatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string deleteprincipalPPTdatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteprincipalPPTdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string deleteprincipalIntroLetterdatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteprincipalIntroLetterdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string deletePrincipalClientdatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletePrincipalClientdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string deletePrincipalProgressdatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletePrincipalProgressdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string deletePrincipalPricedatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletePrincipalPricedatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string deletePrincipalCominfodatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletePrincipalCominfodatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string deletePrincipalViedodatabyidDAL(string id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletePrincipalViedodatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_PrincipalPPT_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalPPT_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_PrincipalIntroLetter_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalIntroLetter_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_PrincipalClient_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalClient_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }



    public string tbl_PrincipalProgress_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalProgress_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }



    public string tbl_PrincipalPrice_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalPrice_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }




    public string tbl_PrincipalComInfo_Document_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalComInfo_Document_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_PrincipalViedo_Master_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_PrincipalViedo_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getProgressdocumentadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getProgressdocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
         //   cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getPricedocumentadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getPricedocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable getCominfodocumentadataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getCominfodocumentadata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getPrincipalViedodataDAL(  int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getPrincipalViedodata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          //  cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkPrincipalViedeoDAL(string DocuName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkPrincipalViedeo", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Principal_Contact_Master_InsertDAL(string no, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Principal_Contact_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = ContactPhone;
            cmd.Parameters.Add("@ContactMobileno1", SqlDbType.VarChar).Value = ContactMobileno1;
            cmd.Parameters.Add("@ContactMobileno2", SqlDbType.VarChar).Value = ContactMobileno2;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable checkPrincipalcontactnameDAL(string no, string ContactName, string ContactEmail)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkPrincipalcontactname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getPrincipalcontactdataDAL( int no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getPrincipalcontactdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          //  cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@no", SqlDbType.BigInt).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getPrincipalcontactdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getPrincipalcontactdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deletePrincipalcontactdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletePrincipalcontactdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Principal_Contact_Master_updateDAL(int Id, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Principal_Contact_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactPhone", SqlDbType.VarChar).Value = ContactPhone;
            cmd.Parameters.Add("@ContactMobileno1", SqlDbType.VarChar).Value = ContactMobileno1;
            cmd.Parameters.Add("@ContactMobileno2", SqlDbType.VarChar).Value = ContactMobileno2;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;

            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable checkPrincipalnameDAL(string @Pname)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkPrincipalname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Pname", SqlDbType.VarChar).Value = Pname;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Principal_Master_InsertDAL(int no, string Pname, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Principal_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@Pname", SqlDbType.VarChar).Value = Pname;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable getallPrincipalMasterataDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallPrincipalMasterata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallPrincipalMasterataforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallPrincipalMasterataforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Principal_Master_UpdateDAL(string no, string Pname)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Principal_Master_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@Pname", SqlDbType.VarChar).Value = Pname;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string deletePrincipaldatabynoDAL(string No)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletePrincipaldatabyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    #endregion


    #region Role Master
    public DataTable getallRoleDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallRole", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallRoleforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallRoleforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkRolenameDAL(string RoleName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkRolename", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = RoleName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Role_Master_InsertDAL(string RoleName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Role_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = RoleName;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getRoledatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getRoledatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteRoledatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteRoledatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Role_Master_UpdateDAL(string Id, string RoleName)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Role_Master_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = RoleName;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    #endregion


    #region Assignproduct
    public string tbl_AssignProduct_Master_InsertDAL(string No, string Type, string Name, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_AssignProduct_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_AssignProduct_Details_InsertDAL(string No, string Type,int Name, int ProductId, string checkvalue, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_AssignProduct_Details_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.VarChar).Value = No;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;
            cmd.Parameters.Add("@Name", SqlDbType.Int).Value = Name;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = ProductId;
            cmd.Parameters.Add("@checkvalue", SqlDbType.VarChar).Value = checkvalue;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string getitemidbynameDAL(string Itemname)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("getitemidbyname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Itemname", SqlDbType.VarChar).Value = Itemname;


            res = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable getallAllAssignProductforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallAllAssignProductforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallassignproductitemforadminDAL(string no)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallassignproductitemforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deleteAssignproductdetailsdatabyidDAL(string no)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteAssignproductdetailsdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = @no;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    #endregion


    #region Inqiury

    public string tbl_Inquiry_No_Series_InsertDAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Inquiry_No_Series_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@No", SqlDbType.BigInt).Value = No;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }



    public DataTable getCustomerNameDAL( string GroupNo)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getCustomerName", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@GroupNo", SqlDbType.VarChar).Value = GroupNo;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getCustomerConatctPersonDAL( string Custno)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getCustomerConatctPerson", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Custno", SqlDbType.VarChar).Value = Custno;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable getsupplierbyasssignDAL(string Productid)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getsupplierbyasssign", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Productid", SqlDbType.VarChar).Value = Productid;
          
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getprincipalbyasssignDAL(string Productid)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getprincipalbyasssign", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Productid", SqlDbType.VarChar).Value = Productid;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getitemdetailsbyidDAL(string itemid)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getitemdetailsbyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@itemid", SqlDbType.VarChar).Value = itemid;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallItemadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallItemadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkProductNameDAL(string Noseries, string Item)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkProductName", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Noseries", SqlDbType.VarChar).Value = Noseries;
            cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;
            
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkinquiryitemsDAL(string date, int CustGroup, int Cust, string item)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkinquiryitems", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@CustGroup", SqlDbType.Int).Value = CustGroup;
            cmd.Parameters.Add("@Cust", SqlDbType.Int).Value = Cust;
            cmd.Parameters.Add("@item", SqlDbType.VarChar).Value = item;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkinquiryitemsupdateDAL(string date, int CustGroup, int Cust, string item, string id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkinquiryitemsupdate", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@CustGroup", SqlDbType.Int).Value = CustGroup;
            cmd.Parameters.Add("@Cust", SqlDbType.Int).Value = Cust;
            cmd.Parameters.Add("@item", SqlDbType.VarChar).Value = item;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkFollowupDAL(string Noseries, string NextFolldate, int Follotype)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkFollowup", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Noseries", SqlDbType.VarChar).Value = Noseries;
            cmd.Parameters.Add("@NextFolldate", SqlDbType.VarChar).Value = NextFolldate;
            cmd.Parameters.Add("@Follotype", SqlDbType.Int).Value = Follotype;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkInqiuryalreadyDAL(string InqiuryNo, string Inquirydate, int Custgroup, int Custname)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkInqiuryalready", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@InqiuryNo", SqlDbType.VarChar).Value = InqiuryNo;
            cmd.Parameters.Add("@Inquirydate", SqlDbType.VarChar).Value = Inquirydate;
            cmd.Parameters.Add("@Custgroup", SqlDbType.Int).Value = Custgroup;
            cmd.Parameters.Add("@Custname", SqlDbType.Int).Value = Custname;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Inqiury_Details_InsertDAL(int Noseries, int Item, int Supplier, int Principal, int UOM, decimal Qty, decimal Rate, decimal Amount, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Inqiury_Details_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@Item", SqlDbType.Int).Value = Item;
            cmd.Parameters.Add("@Supplier", SqlDbType.Int).Value = Supplier;
            cmd.Parameters.Add("@Principal", SqlDbType.Int).Value = Principal;
            cmd.Parameters.Add("@UOM", SqlDbType.Int).Value = UOM;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Qty;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = Rate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = Amount;
            
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Inqiury_Followup_InsertDAL(int Noseries, string NextFolldate, int Follotype, int Assignto, int FolloStatus, string Remarks, string Comdate, string Comremarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Inqiury_Followup_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@NextFolldate", SqlDbType.VarChar).Value = NextFolldate;
            cmd.Parameters.Add("@Follotype", SqlDbType.Int).Value = Follotype;
            cmd.Parameters.Add("@Assignto", SqlDbType.Int).Value = Assignto;
            cmd.Parameters.Add("@FolloStatus", SqlDbType.Int).Value = FolloStatus;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
            cmd.Parameters.Add("@Comdate", SqlDbType.VarChar).Value = Comdate;
            cmd.Parameters.Add("@Comremarks", SqlDbType.VarChar).Value = Comremarks;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Inqiury_Master_InsertDAL(int InqiuryNo, int Noseries, string Inquirydate, int Custgroup, int Custname, int Custcontact, string Custcontactno, int Dept, int Design, string ContactEmail, string ContactMno1, string ContactMno2, int InqiuryStatus, int InquirySource, string Remarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Inqiury_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InqiuryNo", SqlDbType.Int).Value = InqiuryNo;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@Inquirydate", SqlDbType.VarChar).Value = Inquirydate;
            cmd.Parameters.Add("@Custgroup", SqlDbType.Int).Value = Custgroup;
            cmd.Parameters.Add("@Custname", SqlDbType.Int).Value = Custname;
            cmd.Parameters.Add("@Custcontact", SqlDbType.Int).Value = Custcontact;
            cmd.Parameters.Add("@Custcontactno", SqlDbType.VarChar).Value = Custcontactno;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;


            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactMno1", SqlDbType.VarChar).Value = ContactMno1;
            cmd.Parameters.Add("@ContactMno2", SqlDbType.VarChar).Value = ContactMno2;
            cmd.Parameters.Add("@InqiuryStatus", SqlDbType.Int).Value = InqiuryStatus;
            cmd.Parameters.Add("@InquirySource", SqlDbType.Int).Value = InquirySource;
             cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Inqiury_Master_UpdateDAL(int InqiuryNo, int Noseries, string Inquirydate, int Custgroup, int Custname, int Custcontact, string Custcontactno, int Dept, int Design, string ContactEmail, string ContactMno1, string ContactMno2, int InqiuryStatus, int InquirySource, string Remarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Inqiury_Master_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InqiuryNo", SqlDbType.Int).Value = InqiuryNo;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@Inquirydate", SqlDbType.VarChar).Value = Inquirydate;
            cmd.Parameters.Add("@Custgroup", SqlDbType.Int).Value = Custgroup;
            cmd.Parameters.Add("@Custname", SqlDbType.Int).Value = Custname;
            cmd.Parameters.Add("@Custcontact", SqlDbType.Int).Value = Custcontact;
            cmd.Parameters.Add("@Custcontactno", SqlDbType.VarChar).Value = Custcontactno;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;


            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactMno1", SqlDbType.VarChar).Value = ContactMno1;
            cmd.Parameters.Add("@ContactMno2", SqlDbType.VarChar).Value = ContactMno2;
            cmd.Parameters.Add("@InqiuryStatus", SqlDbType.Int).Value = InqiuryStatus;
            cmd.Parameters.Add("@InquirySource", SqlDbType.Int).Value = InquirySource;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_Inqiury_Followup_updateDAL(int Id, int Noseries, string NextFolldate, int Follotype, int Assignto, int FolloStatus, string Remarks, string Comdate, string Comremarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Inqiury_Followup_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@NextFolldate", SqlDbType.VarChar).Value = NextFolldate;
            cmd.Parameters.Add("@Follotype", SqlDbType.Int).Value = Follotype;
            cmd.Parameters.Add("@Assignto", SqlDbType.Int).Value = Assignto;
            cmd.Parameters.Add("@FolloStatus", SqlDbType.Int).Value = FolloStatus;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
            cmd.Parameters.Add("@Comdate", SqlDbType.VarChar).Value = Comdate;
            cmd.Parameters.Add("@Comremarks", SqlDbType.VarChar).Value = Comremarks;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable getInqiuryDetailsdataDAL( int Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getInqiuryDetailsdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getFollowupdataDAL( int Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getFollowupdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
          //  cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getFollowupdataforeditDal(int id,int Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getFollowupdataforedit", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getFollowupdataFordashDAL(int id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getFollowupdataFordash", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
             cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
           // cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getQuotationdataFordashDAL(int id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getQuotationdataFordash", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            // cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getInqiuryDetailsdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getInqiuryDetailsdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getFollowupDetailsdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getFollowupDetailsdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deleteinquirydetailsdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteinquirydetailsdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string deleteinquiryfollowupdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteinquiryfollowupdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Inqiury_Details_updateDAL(int Id, int Item, int Supplier, int Principal, int UOM, decimal Qty, decimal Rate, decimal Amount, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Inqiury_Details_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Item", SqlDbType.Int).Value = Item;
            cmd.Parameters.Add("@Supplier", SqlDbType.Int).Value = Supplier;
            cmd.Parameters.Add("@Principal", SqlDbType.Int).Value = Principal;
            cmd.Parameters.Add("@UOM", SqlDbType.Int).Value = UOM;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Qty;
            cmd.Parameters.Add("@Rate", SqlDbType.Int).Value = Rate;
            cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = Amount;

            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string getCustomerGroupIdbynameDAL(string Name)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("getCustomerGroupIdbyname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = @Name;


            res = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string getCustomerIdbynameDAL(string Name)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("getCustomerIdbyname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = @Name;


            res = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable getallInqiurydataDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallInqiurydata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallInqiurydatabynoDAL(string Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallInqiurydatabyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Noseries", SqlDbType.VarChar).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallInqiurydataforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallInqiurydataforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }




    #endregion
    //Bulk EMailStart getBulkEmailDataDAL

    public DataTable getBulkEmailDataDAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getBulkEmailData", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@createby", SqlDbType.VarChar).Value = Createby;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    //Bulk Email ENd 


    //Upload Image Start
    public DataTable getallUploadedImagesforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallUploadedImagesforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getUploadedImagesbyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getUploadedImagesbyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteImagesbyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteImagesbyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public DataTable checkImagenameDAL(string GroupName)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkImagenameDAL", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = GroupName;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tblImage_Upload_InsertDAL(string Name, string path, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tblImage_Upload_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = path;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public string tbl_Image_UpdateDAL(string Id, string Name, string path)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Image_UpdateDAL", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@Path", SqlDbType.VarChar).Value = path;


            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    //Upload Image ENd


    //Terms and Conditions Start

    public DataTable checktermsandconditionsdata(string name , string seq)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checktermsandconditions", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@Sequence", SqlDbType.VarChar).Value = seq;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string Savetermsandconditionsbll(string name, string termsandconditions, string Createby, DateTime Createddatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("inserttermsandconditions", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@Termsandconditions", SqlDbType.VarChar).Value = termsandconditions;

            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@CreateDateTime", SqlDbType.DateTime).Value = Createddatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = "";


            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    } //done

    public DataTable getalltermsandconditionsDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("termsandconditionsdisp", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable gettermsandconditionsdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("showtermsandconditions", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    } //done

    public string deletetermsandconditionsdata(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletetermsandconditions", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    } //done

    public string tbl_termsandconditionsupdate(string Id, string name, string tandc , string Sequence)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("updatetermsandconditions", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@TandC", SqlDbType.VarChar).Value = tandc;
            cmd.Parameters.Add("@Sequence", SqlDbType.VarChar).Value = Sequence;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    } //done




    //Terms and Conditions END


    //Country master
    public DataTable getallcountryDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("countrydisp", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkcountrydata(string name)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkcountryname", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = name;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    } //done

    public string Savecountrybll(string name, string Createby, DateTime Createddatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("insertcountry", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@CreateDateTime", SqlDbType.DateTime).Value = Createddatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = "";


            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    } //done

    public DataTable getcountrydatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("showcountry", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    } //done

    public string deletecountrydata(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletecountry", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    } //done

    public string tbl_countryupdate(string Id, string name)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("updatecountry", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = name;


            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    } //done


    //End



    //Quotation Start
    public DataTable getallQuotationdataforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallQuotationdataforadmin", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getallQuotationdataemployeDAL(string com)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallQuotationdataEployee", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@CompanyNo", SqlDbType.VarChar).Value = com;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkQuotationProductNameDAL(string Noseries, string Item)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkProductName", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Noseries", SqlDbType.VarChar).Value = Noseries;
            cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkQuotationProductBroucherDAL( string Item)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkQuotationProductBroucher", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@Noseries", SqlDbType.VarChar).Value = Noseries;
            cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkInquiryProductBroucherDAL(string Item)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkQuotationProductBroucher", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@Noseries", SqlDbType.VarChar).Value = Noseries;
            cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Quotation_Details_InsertDAL(int Noseries, int Item, int Supplier, int Principal, int UOM, decimal Qty, decimal Rate, decimal Amount, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Quotation_Details_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@Item", SqlDbType.Int).Value = Item;
            cmd.Parameters.Add("@Supplier", SqlDbType.Int).Value = Supplier;
            cmd.Parameters.Add("@Principal", SqlDbType.Int).Value = Principal;
            cmd.Parameters.Add("@UOM", SqlDbType.Int).Value = UOM;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Qty;
            cmd.Parameters.Add("@Rate", SqlDbType.Decimal).Value = Rate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = Amount;

            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string tbl_Quotation_Details_Broucher_InsertDAL(int Noseries, string Item, string Supplier, string Principal, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Quotation_Details_Broucher_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;
            cmd.Parameters.Add("@Supplier", SqlDbType.VarChar).Value = Supplier;
            cmd.Parameters.Add("@Principal", SqlDbType.VarChar).Value = Principal;
            

            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string tbl_Inquiry_Details_Broucher_InsertDAL(int Noseries, string Item, string Supplier, string Principal, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Inquiry_Details_Broucher_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@Item", SqlDbType.VarChar).Value = Item;
            cmd.Parameters.Add("@Supplier", SqlDbType.VarChar).Value = Supplier;
            cmd.Parameters.Add("@Principal", SqlDbType.VarChar).Value = Principal;


            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable getQuotationDetailsdataDAL(int Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getQuotationDetailsdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkQuotationFollowupDAL(string Noseries, string NextFolldate, int Follotype)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkQuotationFollowup", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Noseries", SqlDbType.VarChar).Value = Noseries;
            cmd.Parameters.Add("@NextFolldate", SqlDbType.VarChar).Value = NextFolldate;
            cmd.Parameters.Add("@Follotype", SqlDbType.Int).Value = Follotype;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Quotation_Followup_InsertDAL(int Noseries, string NextFolldate, int Follotype, int Assignto, int FolloStatus, string Remarks, string Comdate, string Comremarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("[tbl_Quotation_Followup_Insert]", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@NextFolldate", SqlDbType.VarChar).Value = NextFolldate;
            cmd.Parameters.Add("@Follotype", SqlDbType.Int).Value = Follotype;
            cmd.Parameters.Add("@Assignto", SqlDbType.Int).Value = Assignto;
            cmd.Parameters.Add("@FolloStatus", SqlDbType.Int).Value = FolloStatus;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
           
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }

    public DataTable getQuotationFollowupdataDAL(int Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getQuotationFollowupdata", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //  cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Quotation_Followup_updateDAL(int Id, int Noseries, string NextFolldate, int Follotype, int Assignto, int FolloStatus, string Remarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Quotation_Followup_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@NextFolldate", SqlDbType.VarChar).Value = NextFolldate;
            cmd.Parameters.Add("@Follotype", SqlDbType.Int).Value = Follotype;
            cmd.Parameters.Add("@Assignto", SqlDbType.Int).Value = Assignto;
            cmd.Parameters.Add("@FolloStatus", SqlDbType.Int).Value = FolloStatus;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
            
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable getQuotationFollowupDetailsdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getQuotationFollowupDetailsdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteQuotationfollowupdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletequotationfollowupdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable checkQuotationalreadyDAL(string Quotno, string Inquirydate, int custid, int Groupid)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkQuotationalready", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@InqiuryNo", SqlDbType.VarChar).Value = Quotno;
            cmd.Parameters.Add("@Inquirydate", SqlDbType.VarChar).Value = Inquirydate;
            cmd.Parameters.Add("@Custid", SqlDbType.Int).Value = custid;
            cmd.Parameters.Add("@Custgroup", SqlDbType.Int).Value = Groupid;

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Quotation_Master_InsertDAL(int InqiuryNo, int Noseries, string Inquirydate, int custGroup ,int Custname, int Custcontact, string Custcontactno, int Dept, int Design, string ContactEmail, string ContactMno1, string ContactMno2, int InqiuryStatus, int InquirySource, string Remarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Quotation_Master_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InqiuryNo", SqlDbType.Int).Value = InqiuryNo;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@Inquirydate", SqlDbType.VarChar).Value = Inquirydate;
            cmd.Parameters.Add("@Custgroup", SqlDbType.Int).Value = custGroup;
            cmd.Parameters.Add("@Custname", SqlDbType.Int).Value = Custname;
            cmd.Parameters.Add("@Custcontact", SqlDbType.Int).Value = Custcontact;
            cmd.Parameters.Add("@Custcontactno", SqlDbType.VarChar).Value = Custcontactno;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;


            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactMno1", SqlDbType.VarChar).Value = ContactMno1;
            cmd.Parameters.Add("@ContactMno2", SqlDbType.VarChar).Value = ContactMno2;
            cmd.Parameters.Add("@InqiuryStatus", SqlDbType.Int).Value = InqiuryStatus;
            cmd.Parameters.Add("@InquirySource", SqlDbType.Int).Value = InquirySource;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string tbl_Quotation_tandc_InsertDAL(int termsid, int noseries, string termstitle, string termsdescrip, string status, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("insert_quotations_tandc", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@termsid", SqlDbType.Int).Value = termsid;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = noseries;
            cmd.Parameters.Add("@termstitle", SqlDbType.VarChar).Value = termstitle;
            cmd.Parameters.Add("@termsdescription", SqlDbType.VarChar).Value = termsdescrip;

            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;

            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable getallQuoationdatabynoDAL(string Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallQuotationdatabyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Noseries", SqlDbType.VarChar).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getTaxationDatabyidDAL(int Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getTaxationDataDAL", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //  cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getalltermsandconditionsDAL(int id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("termsandconditionsFromQuotation", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Quotation_Master_UpdateDAL(int InqiuryNo, int Noseries, string Inquirydate, int custGroup, int Custname, int Custcontact, string Custcontactno, int Dept, int Design, string ContactEmail, string ContactMno1, string ContactMno2, int InqiuryStatus, int InquirySource, string Remarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Quotation_Master_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InqiuryNo", SqlDbType.Int).Value = InqiuryNo;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@Inquirydate", SqlDbType.VarChar).Value = Inquirydate;
            cmd.Parameters.Add("@Custgroup", SqlDbType.Int).Value = custGroup;
            cmd.Parameters.Add("@Custname", SqlDbType.Int).Value = Custname;
            cmd.Parameters.Add("@Custcontact", SqlDbType.Int).Value = Custcontact;
            cmd.Parameters.Add("@Custcontactno", SqlDbType.VarChar).Value = Custcontactno;
            cmd.Parameters.Add("@Dept", SqlDbType.Int).Value = Dept;
            cmd.Parameters.Add("@Design", SqlDbType.Int).Value = Design;


            cmd.Parameters.Add("@ContactEmail", SqlDbType.VarChar).Value = ContactEmail;
            cmd.Parameters.Add("@ContactMno1", SqlDbType.VarChar).Value = ContactMno1;
            cmd.Parameters.Add("@ContactMno2", SqlDbType.VarChar).Value = ContactMno2;
            cmd.Parameters.Add("@InqiuryStatus", SqlDbType.Int).Value = InqiuryStatus;
            cmd.Parameters.Add("@InquirySource", SqlDbType.Int).Value = InquirySource;
            cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    //End


    //Taxation Start
    public DataTable checkTaxationDAL(string id, string name, int country)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkTaxation", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@Country", SqlDbType.Int).Value = country;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    } //done


    public string tbl_Quotation_Taxation_InsertDAL(int Noseries, int country, string name, string percent, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Quotation_Taxation_Details_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@country", SqlDbType.Int).Value = country;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@percent", SqlDbType.VarChar).Value = percent;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }


    public string tbl_Quotation_Taxation_UpdateDAL(int id,int Noseries, int country, string name, string percent, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Quotation_Taxation_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@Noseries", SqlDbType.Int).Value = Noseries;
            cmd.Parameters.Add("@country", SqlDbType.Int).Value = country;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@percent", SqlDbType.VarChar).Value = percent;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable getTaxationDataDAL(int Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getTaxationDataDAL", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //  cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getTaxationDetailsdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getTaxationDetailsdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteQuotationTaxationdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteQuotationTaxationdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    //End
    public DataTable getQuotationtermsandconditionsdatabyidDAL(string noseries,string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getQuotationtermsandconditionsdatabyid", c);
    cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@Noseries", SqlDbType.VarChar).Value = noseries;
            dt = new DataTable();
    da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    } //done
    public DataTable getallQuotationtermsandconditionsbyidDAL(string id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallQuotationtermsandconditionsbyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Quotation_tandc_UpdateDAL(int termsid, int noseries, string termstitle, string termsdescrip, string status, string CreateBy, DateTime CreateDatetime)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Quotation_tandc_Update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@termsid", SqlDbType.Int).Value = noseries;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = termsid ;
            cmd.Parameters.Add("@termstitle", SqlDbType.VarChar).Value = termstitle;
            cmd.Parameters.Add("@termsdescription", SqlDbType.VarChar).Value = termsdescrip;

            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;

            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
          
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string tbl_QuotationtermsandconditionsupdateDAL(string Id, string name, string tandc, string termsid, string seq)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("updatetermsandconditionsforQuatation", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@TandC", SqlDbType.VarChar).Value = tandc;
            cmd.Parameters.Add("@Termsid", SqlDbType.VarChar).Value = termsid;
            cmd.Parameters.Add("@seq", SqlDbType.VarChar).Value = seq;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable getQuotationDetailsdatabyidDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getQuotationDetailsdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Quotation_Details_updateDAL(int Id, int Item, int Supplier, int Principal, int UOM, decimal Qty, decimal Rate, decimal Amount, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Quotation_Details_update", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@Item", SqlDbType.Int).Value = Item;
            cmd.Parameters.Add("@Supplier", SqlDbType.Int).Value = Supplier;
            cmd.Parameters.Add("@Principal", SqlDbType.Int).Value = Principal;
            cmd.Parameters.Add("@UOM", SqlDbType.Int).Value = UOM;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = Qty;
            cmd.Parameters.Add("@Rate", SqlDbType.Int).Value = Rate;
            cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = Amount;

            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;

            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable getonlyCustomerNameDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getonlyCustomerName", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
           
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteQuotationdetailsdatabyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deletequotationdetailsdatabyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string deleteQuotationdetailsBrocherbyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteQuotationdetailsBrocherbyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public string deleteInquirydetailsBrocherbyidDAL(string Id)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("deleteInquirydetailsBrocherbyid", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable getcompanyimagebynoDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getcompanyimagebyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getitemBrouchersforquotation(int Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getitemBrouchersforquotation", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getitemBrouchersforInquiry(int Noseries)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getitemBrouchersforInquiry", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@Createby", SqlDbType.VarChar).Value = Createby;
            cmd.Parameters.Add("@Noseries", SqlDbType.BigInt).Value = Noseries;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getCompanyforadminDAL()
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("GetCompanyddl", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkEmployee_master_detailsDAL(string txtName, string txtfhname, string txtsurname)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkEmployee_master_details", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@txtName", SqlDbType.VarChar).Value = txtName;
            cmd.Parameters.Add("@txtfhname", SqlDbType.VarChar).Value = txtfhname;
            cmd.Parameters.Add("@txtsurname", SqlDbType.VarChar).Value = txtsurname;
            cmd.Parameters.Add("@txtphno", SqlDbType.VarChar).Value = "0";
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getcompanybannerbynoDAL(string Id)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getcompanyBannerbyno", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Company_Banner_InsertDAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        try
        {
            c = con.getconnection();
            cmd = new SqlCommand("tbl_Company_Banner_Insert", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@no", SqlDbType.VarChar).Value = no;
            cmd.Parameters.Add("@DocuName", SqlDbType.VarChar).Value = DocuName;
            cmd.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename;
            cmd.Parameters.Add("@DocumentPath", SqlDbType.VarChar).Value = DocumentPath;
            cmd.Parameters.Add("@CreateBy", SqlDbType.VarChar).Value = CreateBy;
            cmd.Parameters.Add("@CreateDatetime", SqlDbType.DateTime).Value = CreateDatetime;
            cmd.Parameters.Add("@Extra1", SqlDbType.VarChar).Value = Extra1;
            cmd.Parameters.Add("@Extra2", SqlDbType.VarChar).Value = Extra2;
            cmd.Parameters.Add("@Extra3", SqlDbType.VarChar).Value = Extra3;
            cmd.Parameters.Add("@Extra4", SqlDbType.VarChar).Value = Extra4;
            cmd.Parameters.Add("@Extra5", SqlDbType.VarChar).Value = Extra5;
            res = cmd.ExecuteNonQuery().ToString();
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }
        return res;
    }
    public DataTable checkEmployee_master_EnailDAL(string txtName, string txtfhname, string txtsurname)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("checkEmployee_Email_details", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@txtName", SqlDbType.VarChar).Value = txtName;
            cmd.Parameters.Add("@txtfhname", SqlDbType.VarChar).Value = txtfhname;
            cmd.Parameters.Add("@txtsurname", SqlDbType.VarChar).Value = txtsurname;
            cmd.Parameters.Add("@txtphno", SqlDbType.VarChar).Value = "0";
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    #region 12/02/21
    public DataTable getallInqiurydataByEmployeeDAL(string CompanyNo)
    {
        DataTable dt = null;
        try
        {
            c = con.getconnection();
            SqlCommand cmd = new SqlCommand("getallInqiurydataByEmployee", c);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@CompanyNo", SqlDbType.BigInt).Value = CompanyNo;
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    #endregion
}