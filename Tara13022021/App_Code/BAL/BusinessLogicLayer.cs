using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BusinessLogicLayer
/// </summary>
public class BusinessLogicLayer
{
    DataAccessLayer dal = new DataAccessLayer();

    #region IndustrygroupMaster


    public DataTable checklogindetailsBAL(string Eemailid, string Epwd)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checklogindetailsDAL(Eemailid,Epwd);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string SaveIndustrygroupMasterBAL(string GroupName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.SaveIndustrygroupMasterDAL(GroupName, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deleteIndustrygroupbyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteIndustrygroupbyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Industrygroup_UpdateBAL(string id, string GroupName)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Industrygroup_UpdateDAL(id, GroupName);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public DataTable getallIndustrygroupBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallIndustrygroupDAL(Createby);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallIndustrygroupfroadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallIndustrygroupfroadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkIndustrygroupnamebal(string groupname)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkIndustrygroupnamedal(groupname);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getIndustrygroupdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getIndustrygroupdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    #endregion
    #region BussinessTypeMaster

    public string SaveBussinessTypeMasterBAL(string BussType, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.SaveBussinessTypeMasterDAL(BussType, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public DataTable getallBussinessTypeBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallBussinessTypeDAL(Createby);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallBussinessTypeforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallBussinessTypeforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallPrincipalforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallPrincipalforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallSuppliersforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallSuppliersforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkBussinessTypenameBAL(string BussType)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkBussinessTypenameDAL(BussType);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getBussinessTypedatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getBussinessTypedatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteBussinessTypedatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteBussinessTypedatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string deleteAssignproductdetailsdatabyidBAL(string no)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteAssignproductdetailsdatabyidDAL(no);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_BussinessType_UpdateBAL(string id, string BussType)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_BussinessType_UpdateDAL(id, BussType);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    #endregion

    #region Noseries
    public string tbl_Company_NoSeries_InsertBAL(string CompanyNo, string Extra1, string Extra2)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Company_NoSeries_InsertDAL(CompanyNo, Extra1, Extra2);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_AssignProduct_NoSeries_InsertBAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_AssignProduct_NoSeries_InsertDAL(No, Extra1, Extra2);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_CustomerGroup_NoSeries_InsertBAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_CustomerGroup_NoSeries_InsertDAL(No, Extra1, Extra2);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Customer_Noseries_InsertBAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Customer_Noseries_InsertDAL(No, Extra1, Extra2);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_Supplier_Noseries_InsertBAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Supplier_Noseries_InsertDAL(No, Extra1, Extra2);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }




    public string tbl_Employee_NoSeries_InsertBAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Employee_NoSeries_InsertDAL(No, Extra1, Extra2);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_Item_NoSeries_InsertBAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Item_NoSeries_InsertDAL(No, Extra1, Extra2);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_Principal_NoSeries_InsertBAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Principal_NoSeries_InsertDAL(No, Extra1, Extra2);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    #endregion


    #region DepartmentMaster

    public string tbl_Department_Master_InsertBAL(string DeptName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Department_Master_InsertDAL(DeptName, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;

    }


    public DataTable checkDepartmentnameBAL(string DeptName)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkDepartmentnameDAL(DeptName);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getDepartment_MasterBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getDepartment_MasterDAL(Createby);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable getDepartment_MasterforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getDepartment_MasterforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getDepartmentdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getDepartmentdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deleteDepartmentdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteDepartmentdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }



    public string tbl_DepartmentMaster_UpdateBAL(string id, string DeptName)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_DepartmentMaster_UpdateDAL(id, DeptName);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    #endregion



    #region DesignationMaster

    public DataTable getDesignation_MasterBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getDesignation_MasterDAL(Createby);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getDesignation_MasterforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getDesignation_MasterforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkDesignationnameBAL(string DesigName)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkDesignationnameDAL(DesigName);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Designation_Master_InsertBAL(string DesigName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Designation_Master_InsertDAL(DesigName, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;

    }

    public DataTable getDesignationdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getDesignationdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteDesignationdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteDesignationdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Designation_UpdateBAL(string id, string DesigName)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Designation_UpdateDAL(id, DesigName);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    #endregion

    #region CompanyMaster


    public string tbl_Company_Contact_Master_InsertBAL(string Companyno, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Company_Contact_Master_InsertDAL(Companyno, ContactName, ContactEmail, ContactPhone, ContactMobileno1, ContactMobileno2, Dept, Design, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable checkcompanynamemasterBAL(string Name)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkcompanynamemasterDAL(Name);
        }
        catch (Exception ex)
        {
            
        }
        return dt;
    }

    public string tbl_Company_Master_InsertBAL(string Companyno, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string ComCountry,string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Company_Master_InsertDAL(Companyno, Comname, Comarea, Comaddress, Comcity, Comstate, ComDistrict, ComCountry, ComPincode, ComPhoneNo, ComEmail, BussinessType, Industrygroup, URL, Status, GSTno, Bankname, Accountno, IFSCcode, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);

        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable getcompanycontactdataBAL( int companyno)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getcompanycontactdataDAL( companyno);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getcompanycontactdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getcompanycontactdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deletecompanycontactdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletecompanycontactdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_Company_Contact_Master_updateBAL(int id, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {

        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Company_Contact_Master_updateDAL(id, ContactName, ContactEmail, ContactPhone, ContactMobileno1, ContactMobileno2, Dept, Design, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public DataTable checkcompanycontactnameBAL(string companyno, string ContactName, string ContactEmail)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkcompanycontactnameDAL(companyno, ContactName, ContactEmail);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkPrincipalcontactnameBAL(string no, string ContactName, string ContactEmail)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkPrincipalcontactnameDAL(no, ContactName, ContactEmail);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallcompanydataBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallcompanydataDAL(Createby);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getallcompanydataforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallcompanydataforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public DataTable getallCustomercontactdataBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallCustomercontactdataDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getallcompanydatabycomnoBAL(string comno)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallcompanydatabycomnoDAL(comno);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }



    public string tbl_Company_Master_updateBAL(string Companyno, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string ComCountry, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Company_Master_updateDAL(Companyno, Comname, Comarea, Comaddress, Comcity, Comstate, ComDistrict, ComCountry, ComPincode, ComPhoneNo, ComEmail, BussinessType, Industrygroup, URL, Status, GSTno, Bankname, Accountno, IFSCcode, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);

        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }




    public string deletecompanydatabyCompanynoBAL(string companyno)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletecompanydatabyCompanynoDAL(companyno);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    #endregion




    #region CompanyMaster


    public string tbl_CustomerGroup_Contact_Master_InsertBAL(string Groupno, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_CustomerGroup_Contact_Master_InsertDAL(Groupno, ContactName, ContactEmail, ContactPhone, ContactMobileno1, ContactMobileno2, Dept, Design, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable checkcustomergroupcontactnameBAL(string Groupno, string ContactName, string ContactEmail)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkcustomergroupcontactnameDAL(Groupno, ContactName, ContactEmail);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable checkCustomerGroup_Master_nameBAL(string name)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkCustomerGroup_Master_nameDAL(name);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkCustomer_Master_nameBAL(string name)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkCustomer_Master_nameDAL(name);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable getCustomerGroupcontactdataBAL(int Groupno)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCustomerGroupcontactdataDAL( Groupno);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }




    public DataTable getCustomerGroupcontactdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCustomerGroupcontactdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string deleteCustomerGroupcontactdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteCustomerGroupcontactdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_CustomerGroup_Contact_Master_updateBAL(int id, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {

        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_CustomerGroup_Contact_Master_updateDAL(id, ContactName, ContactEmail, ContactPhone, ContactMobileno1, ContactMobileno2, Dept, Design, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string tbl_CustomerGroup_Master_InsertBAL(string Groupno, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_CustomerGroup_Master_InsertDAL(Groupno, Comname, Comarea, Comaddress, Comcity, Comstate, ComDistrict, Country, ComPincode, ComPhoneNo, ComEmail, BussinessType, Industrygroup, URL, Status, GSTno, Bankname, Accountno, IFSCcode, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);

        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable getallCustomerGroupdataBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallCustomerGroupdataDAL(Createby);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getallCustomerGroupdataforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallCustomerGroupdataforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }





    public DataTable getallCustomerGroupdatabyGroupnoBAL(string Groupno)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallCustomerGroupdatabyGroupnoDAL(Groupno);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public string tbl_CustomerGroup_Master_updateBAL(string Groupno, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_CustomerGroup_Master_updateDAL(Groupno, Comname, Comarea, Comaddress, Comcity, Comstate, ComDistrict, Country, ComPincode, ComPhoneNo, ComEmail, BussinessType, Industrygroup, URL, Status, GSTno, Bankname, Accountno, IFSCcode, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);

        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string deleteCustomerGroupdatabyCompanynoBAL(string Groupno)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteCustomerGroupdatabyCompanynoDAL(Groupno);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    #endregion

    #region CustomerMaster
    public DataTable getCustomerGroupNameBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCustomerGroupNameDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkcustomercontactnameBAL(string Custno, string ContactName, string ContactEmail)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkcustomercontactnameDAL(Custno, ContactName, ContactEmail);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Customer_Contact_Master_InsertBAL(string Custno, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Customer_Contact_Master_InsertDAL(Custno, ContactName, ContactEmail, ContactPhone, ContactMobileno1, ContactMobileno2, Dept, Design, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getCustomercontactdataBAL( int Custno)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCustomercontactdataDAL( Custno);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getCustomercontactdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCustomercontactdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteCustomercontactdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteCustomercontactdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_Customer_Contact_Master_updateBAL(int id, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {

        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Customer_Contact_Master_updateDAL(id, ContactName, ContactEmail, ContactPhone, ContactMobileno1, ContactMobileno2, Dept, Design, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Customer_Master_InsertBAL(string No, string Groupno, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Customer_Master_InsertDAL(No, Groupno, Comname, Comarea, Comaddress, Comcity, Comstate, ComDistrict, Country, ComPincode, ComPhoneNo, ComEmail, BussinessType, Industrygroup, URL, Status, GSTno, Bankname, Accountno, IFSCcode, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);

        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getallCustomerMasterataBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallCustomerMasterataDAL(Createby);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getallCustomerMasterataforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallCustomerMasterataforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getallCustomerdatabynoBAL(string No)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallCustomerdatabynoDAL(No);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public string tbl_Customer_Master_updateBAL(string No, string GroupNo, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Customer_Master_updateDAL(No, GroupNo, Comname, Comarea, Comaddress, Comcity, Comstate, ComDistrict, Country, ComPincode, ComPhoneNo, ComEmail, BussinessType, Industrygroup, URL, Status, GSTno, Bankname, Accountno, IFSCcode, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);

        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deleteCustomerdatabynoBAL(string No)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteCustomerdatabynoDAL(No);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    #endregion

    #region EmployeeMaster
    public string tbl_Employee_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Employee_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getdocumentadataBAL( )
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getdocumentadataDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public string deleteemployeedocumentdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteemployeedocumentdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable checkEmployee_master_detailsBAL(string txtName, string txtfhname, string txtsurname, string txtphno)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkEmployee_master_detailsDAL(txtName, txtfhname, txtsurname, txtphno);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Employee_master_InsertBAL(string no, string Ename, string Efname, string Esurname, string Egender,
        string Epaddress, string Eperaddress, string ECity, string EState, string EDistrict, string ECountry, string EPincode, string EPhoneNo, string Emobilenop, string Emobileoffice, string Emobilewhatsup,
        string Erole, string Epfno, string Edoa, string Edoj, string Edol, int Edept, int Edesign,
        string Eemailid, string Epwd, string Eurgentcontactname, string Eurgentcontactno, string Eurgentcontactrelation, string Estatus, string Ebankname, string Eaccno, string Eifsccode,

        string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string txtbulkemail, string txtbulkpassword, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Employee_master_InsertDAL( no,  Ename,  Efname,  Esurname,  Egender,
        Epaddress,  Eperaddress, ECity,EState,EDistrict,ECountry,EPincode,EPhoneNo, Emobilenop,  Emobileoffice,  Emobilewhatsup,
        Erole,  Epfno,  Edoa,  Edoj,  Edol,  Edept,  Edesign,
        Eemailid,  Epwd,  Eurgentcontactname,  Eurgentcontactno,  Eurgentcontactrelation,  Estatus,  Ebankname,  Eaccno,  Eifsccode,

        CreateBy,  CreateDatetime,  Extra1,  Extra2, txtbulkemail, txtbulkpassword,  Extra5);

        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable getallemployeedataBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallemployeedataDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    
         public DataTable getallemployenameforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallemployenameforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getallemployeedataforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallemployeedataforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getemployeedatanoBAL(string comno)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getemployeedatanoDAL(comno);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public string deleteemployeedatabynoBAL(string no)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteemployeedatabynoDAL(no);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Employee_master_UpdateBAL(string no, string Ename, string Efname, string Esurname, string Egender,
     string Epaddress, string Eperaddress, string ECity, string EState, string EDistrict, string ECountry, string EPincode, string EPhoneNo, string Emobilenop, string Emobileoffice, string Emobilewhatsup,
     string Erole, string Epfno, string Edoa, string Edoj, string Edol, int Edept, int Edesign,
     string Eemailid, string Epwd, string Eurgentcontactname, string Eurgentcontactno, string Eurgentcontactrelation, string Estatus, string Ebankname, string Eaccno, string Eifsccode,
        string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string txtbulkemail, string txtbulkpassword, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Employee_master_UpdateDAL(no, Ename, Efname, Esurname, Egender,
        Epaddress, Eperaddress, ECity, EState, EDistrict, ECountry, EPincode, EPhoneNo, Emobilenop, Emobileoffice, Emobilewhatsup,
        Erole, Epfno, Edoa, Edoj, Edol, Edept, Edesign,
        Eemailid, Epwd, Eurgentcontactname, Eurgentcontactno, Eurgentcontactrelation, Estatus, Ebankname, Eaccno, Eifsccode, CreateBy, CreateDatetime, Extra1, Extra2, txtbulkemail, txtbulkpassword, Extra5);

        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    #endregion

    #region Itemgroupmaster
    public DataTable getallItemgroupBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallItemgroupDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallItemgroupforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallItemgroupforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkItemgroupnameBAL(string groupname)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkItemgroupnameDAL(groupname);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tblItemgroup_Master_InsertBAL(string ItemGroupName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tblItemgroup_Master_InsertDAL(ItemGroupName, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getItemgroupdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getItemgroupdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteItemgroupdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteItemgroupdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Itemgroup_UpdateBAL(string id, string ItemGroupName)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Itemgroup_UpdateDAL(id, ItemGroupName);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    #endregion


     
    #region Itemsubgroupmaster
    public DataTable getallItemsubgroupBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallItemsubgroup(Createby);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallItemsubgroupforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallItemsubgroupforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkItemsubgroupnameBAL(string groupname)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkItemsubgroupnameDAL(groupname);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkItemsubgroupdataBAL(int id,string groupname)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkItemsubgroupdataDAL(id, groupname);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Itemsubgroup_Master_InsertBAL(string ItemSubGroupName, int ItemGroupId, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Itemsubgroup_Master_InsertDAL(ItemSubGroupName, ItemGroupId, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getItemsubgroupdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getItemsubgroupdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteItemsubgroupdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteItemsubgroupdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string tbl_Itemsubgroup_Master_UpdateBAL(string Id, int ItemGroupId, string ItemSubGroupName)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Itemsubgroup_Master_UpdateDAL(Id, ItemGroupId, ItemSubGroupName);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    #endregion

    #region Itemgroupmaster
    public DataTable getallunitBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallunitDAL(Createby);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallunitforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallunitforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkUOMnameBAL(string Uom)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkUOMnameDAL(Uom);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tblItemunit_Master_InsertBAL(string Uom, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tblItemunit_Master_InsertDAL(Uom, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getUOMdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getUOMdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteUOMdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteUOMdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string tblItemunit_Master_UpdateBAL(string id, string Uom)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tblItemunit_Master_UpdateDAL(id, Uom);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    #endregion
    public string tbl_Company_Image_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Company_Image_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    #region IteMaster
    public string tbl_ItemDocument_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_ItemDocument_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getItemdocumentadataBAL(string lblcomno)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getItemdocumentadataDAL(lblcomno);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public string deletitemimgdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletitemimgdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deletitemdocumentdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletitemdocumentdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_ItemImage_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_ItemImage_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable getItemimageadataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getItemimageadataDAL(no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable checkItemnameBAL(string Itemname)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkItemnameDAL(Itemname);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Item_Master_InsertBAL(int no, int itemgroup, int itemsubgroup, string Modelno, string Itemname, string ItemFinalname, string Itemalis, string Itemcategoryno, int ItemUOM, decimal Itemrate, int Itemgst, string ItemHsn, string ItemDesc, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Item_Master_InsertDAL( no,  itemgroup,  itemsubgroup,  Modelno,    Itemname,ItemFinalname,  Itemalis,  Itemcategoryno,  ItemUOM,  Itemrate,  Itemgst,  ItemHsn,  ItemDesc,  CreateBy,  CreateDatetime,  Extra1,  Extra2,  Extra3,  Extra4,  Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public DataTable getallItemdataBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallItemdataDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getallItemdataforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallItemdataforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public DataTable getallitemdatabynoBAL(string no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallitemdatabynoDAL(no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public string tbl_Item_Master_updateBAL(int no, int itemgroup, int itemsubgroup, string Modelno, string Itemname, string ItemFinalname, string Itemalis, string Itemcategoryno, int ItemUOM, decimal Itemrate, int Itemgst, string ItemHsn, string ItemDesc, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Item_Master_updateDAL(no, itemgroup, itemsubgroup, Modelno, Itemname, ItemFinalname, Itemalis, Itemcategoryno, ItemUOM, Itemrate, Itemgst, ItemHsn, ItemDesc, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deleteitematanoBAL(string no)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteitematanoDAL(no);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    #endregion


    #region Sourcemaster
    public DataTable getallsourceBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallsourceDAL(Createby);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }




    public DataTable getallsourceforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallsourceforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }




    public DataTable getsourcedatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getsourcedatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deletesourcedatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletesourcedatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable checksourcenameBAL(string SourceName)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checksourcenameDAL(SourceName);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Source_Master_InsertBAL(string BussType, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Source_Master_InsertDAL(BussType, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Source_Master_UpdateBAL(string id, string SourceName)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Source_Master_UpdateDAL(id, SourceName);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
       #endregion


    #region StatusMaster
    public DataTable getallstatusBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallstatusDAL(Createby);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallstatusforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallstatusforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getstatusdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getstatusdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deletestatusdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletestatusdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable checkstatusnameBAL(string StatusName)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkstatusnameDAL(StatusName);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Status_Master_InsertBAL(string StatusName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Status_Master_InsertDAL(StatusName, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string tbl_Status_Master_UpdateBAL(string id, string StatusName)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Status_Master_UpdateDAL(id, StatusName);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    #endregion


    #region Followup Type Master
    public DataTable getallFollowuptypeBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallFollowuptypeDAL(Createby);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallFollowuptypeforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallFollowuptypeforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getfolowupdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getfolowupdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public string deletefollowupdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletefollowupdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable checkFollowupnameBAL(string FollowupName)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkFollowupnameDAL(FollowupName);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_followuptype_Master_InsertBAL(string FollowupName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_followuptype_Master_InsertDAL(FollowupName, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_followuptype_Master_UpdateBAL(string id, string FollowupName)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_followuptype_Master_UpdateDAL(id, FollowupName);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    #endregion

    #region Supplier Master
    public DataTable checkSuppliercontactnameBAL(string no, string ContactName, string ContactEmail)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkSuppliercontactnameDAL(no, ContactName, ContactEmail);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkSupplier_Master_nameBAL( string Name)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkSupplier_Master_nameDAL(Name);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Supplier_Contact_Master_InsertBAL(string no, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Supplier_Contact_Master_InsertDAL(no, ContactName, ContactEmail, ContactPhone, ContactMobileno1, ContactMobileno2, Dept, Design, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getSuppliercontactdataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getSuppliercontactdataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public DataTable getSuppliercontactdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getSuppliercontactdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteSuppliercontactdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteSuppliercontactdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Supplier_Contact_Master_updateBAL(int id, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {

        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Supplier_Contact_Master_updateDAL(id, ContactName, ContactEmail, ContactPhone, ContactMobileno1, ContactMobileno2, Dept, Design, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }



    public string tbl_Supplier_Master_InsertBAL(string No, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Supplier_Master_InsertDAL(No, Comname, Comarea, Comaddress, Comcity, Comstate, ComDistrict, Country, ComPincode, ComPhoneNo, ComEmail, BussinessType, Industrygroup, URL, Status, GSTno, Bankname, Accountno, IFSCcode, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);

        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public DataTable getallSupplierMasterataBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallSupplierMasterataDAL(Createby);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getallSupplierMasterataforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallSupplierMasterataforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getallSupplierdatabynoBAL(string No)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallSupplierdatabynoDAL(No);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public string tbl_Supplier_Master_updateBAL(string No, string Comname, string Comarea, string Comaddress, string Comcity, string Comstate, string ComDistrict, string Country, string ComPincode, string ComPhoneNo, string ComEmail, int BussinessType, int Industrygroup, string URL, string Status, string GSTno, string Bankname, string Accountno, string IFSCcode, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Supplier_Master_updateDAL(No, Comname, Comarea, Comaddress, Comcity, Comstate, ComDistrict, Country, ComPincode, ComPhoneNo, ComEmail, BussinessType, Industrygroup, URL, Status, GSTno, Bankname, Accountno, IFSCcode, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);

        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deleteSupplierdatabynoBAL(string No)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteSupplierdatabynoDAL(No);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    #endregion

    #region PrincipalMaster
    public string tbl_PrincipalProfile_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalProfile_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_PrincipalCatlogue_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalCatlogue_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_PrincipalApp_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalApp_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_PrincipalNews_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalNews_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_PrincipalCertificate_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalCertificate_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_PrincipalPPT_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalPPT_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_PrincipalIntroLetter_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalIntroLetter_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_PrincipalClient_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalClient_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_PrincipalProgress_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalProgress_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_PrincipalPrice_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalPrice_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_PrincipalComInfo_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalComInfo_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_PrincipalViedo_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalViedo_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_PrincipalPaper_Document_Master_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_PrincipalPaper_Document_Master_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getProfiledocumentadataBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getProfiledocumentadataDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getCatloguedocumentadataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCatloguedocumentadataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getApplicationdocumentadataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getApplicationdocumentadataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getPaperdocumentadataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getPaperdocumentadataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getNewsdocumentadataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getNewsdocumentadataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getCertifcatedocumentadataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCertifcatedocumentadataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getPPTdocumentadataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getPPTdocumentadataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getIntroLetterdocumentadataBAL(int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getIntroLetterdocumentadataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getClientdocumentadatBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getClientdocumentadatDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getProgressdocumentadataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getProgressdocumentadataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getPricedocumentadataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getPricedocumentadataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getCominfodocumentadataBAL(  int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCominfodocumentadataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getPrincipalViedodataBAL(  int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getPrincipalViedodataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public string deleteprincipalProfiledatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteprincipalProfiledatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deleteprincipalCatloguedatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteprincipalCatloguedatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deleteprincipalApplicationdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteprincipalApplicationdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string deleteprincipalPaperdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteprincipalPaperdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deleteprincipalNewsdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteprincipalNewsdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deleteprincipalCertificatedatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteprincipalCertificatedatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deleteprincipalPPTdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteprincipalPPTdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deleteprincipalIntroLetterdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteprincipalIntroLetterdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deletePrincipalClientdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletePrincipalClientdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deletePrincipalProgressdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletePrincipalProgressdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deletePrincipalPricedatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletePrincipalPricedatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deletePrincipalCominfodatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletePrincipalCominfodatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deletePrincipalViedodatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletePrincipalViedodatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public DataTable checkPrincipalViedeoBAL(string DocuName)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkPrincipalViedeoDAL(DocuName);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Principal_Contact_Master_InsertBAL(string no, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Principal_Contact_Master_InsertDAL(no, ContactName, ContactEmail, ContactPhone, ContactMobileno1, ContactMobileno2, Dept, Design, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public DataTable getPrincipalcontactdataBAL( int no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getPrincipalcontactdataDAL( no);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getPrincipalcontactdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getPrincipalcontactdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deletePrincipalcontactdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletePrincipalcontactdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Principal_Contact_Master_updateBAL(int id, string ContactName, string ContactEmail, string ContactPhone, string ContactMobileno1, string ContactMobileno2, int Dept, int Design, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {

        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Principal_Contact_Master_updateDAL(id, ContactName, ContactEmail, ContactPhone, ContactMobileno1, ContactMobileno2, Dept, Design, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable checkPrincipalnameBAL(string Pname)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkPrincipalnameDAL(Pname);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Principal_Master_InsertBAL(int no, string Pname, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Principal_Master_InsertDAL(no, Pname, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getallPrincipalMasterataBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallPrincipalMasterataDAL(Createby);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getallPrincipalMasterataforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallPrincipalMasterataforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public string tbl_Principal_Master_UpdateBAL(string no, string Pname)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Principal_Master_UpdateDAL(no, Pname);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string deletePrincipaldatabynoBAL(string No)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletePrincipaldatabynoDAL(No);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    #endregion

    #region Role Master
    public DataTable getallRoleBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallRoleDAL(Createby);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallRoleforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallRoleforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkRolenameBAL(string RoleName)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkRolenameDAL(RoleName);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Role_Master_InsertBAL(string RoleName, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Role_Master_InsertDAL(RoleName, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getRoledatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getRoledatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteRoledatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteRoledatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_Role_Master_UpdateBAL(string id, string RoleName)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Role_Master_UpdateDAL(id, RoleName);
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
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_AssignProduct_Master_InsertDAL(No,Type,Name, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_AssignProduct_Details_InsertBAL(string No,string Type,int Name, int ProductId, string checkvalue, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_AssignProduct_Details_InsertDAL(No, Type,Name,ProductId,checkvalue, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string getitemidbynameBAL(string Itemname)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.getitemidbynameDAL(Itemname);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getallAllAssignProductforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallAllAssignProductforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getallassignproductitemforadminBAL(string no)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallassignproductitemforadminDAL(no);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    #endregion



    #region Inqiury


    public string tbl_Inquiry_No_Series_InsertBAL(string No, string Extra1, string Extra2)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Inquiry_No_Series_InsertDAL(No, Extra1, Extra2);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }



 
    public DataTable getCustomerNameBAL( string GroupNo)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCustomerNameDAL(GroupNo);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getCustomerConatctPersonBAL( string Custno)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCustomerConatctPersonDAL(Custno);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable getsupplierbyasssignBAL(string Productid)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getsupplierbyasssignDAL(Productid);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getprincipalbyasssignBAL(string Productid)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getprincipalbyasssignDAL(Productid);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getitemdetailsbyidBAL(string itemid)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getitemdetailsbyidDAL(itemid);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getallItemadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallItemadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkProductNameBAL(string Noseries, string Item)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkProductNameDAL(Noseries, Item);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkinquiryitemsBAL(string date, int CustGroup, int Cust, string item)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkinquiryitemsDAL(date, CustGroup, Cust, item);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkinquiryitemsupdateBAL(string date, int CustGroup, int Cust, string item, string id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkinquiryitemsupdateDAL(date, CustGroup, Cust, item, id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkFollowupBAL(string Noseries, string NextFolldate, int Follotype)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkFollowupDAL(Noseries, NextFolldate, Follotype);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable checkInqiuryalreadyBAL(string InqiuryNo, string Inquirydate, int Custgroup, int Custname)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkInqiuryalreadyDAL(InqiuryNo, Inquirydate, Custgroup, Custname);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Inqiury_Details_InsertBAL(int Noseries, int Item, int Supplier, int Principal,int UOM, decimal Qty, decimal Rate, decimal Amount, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Inqiury_Details_InsertDAL(Noseries, Item, Supplier, Principal,UOM, Qty, Rate, Amount, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_Inqiury_Followup_InsertBAL(int Noseries, string NextFolldate, int Follotype, int Assignto, int FolloStatus, string Remarks, string Comdate, string Comremarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Inqiury_Followup_InsertDAL(Noseries, NextFolldate, Follotype, Assignto, FolloStatus, Remarks, Comdate, Comremarks, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }




    public string tbl_Inqiury_Master_InsertBAL(int InqiuryNo, int Noseries, string Inquirydate, int Custgroup, int Custname, int Custcontact, string Custcontactno, int Dept, int Design, string ContactEmail, string ContactMno1, string ContactMno2, int InqiuryStatus, int InquirySource, string Remarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Inqiury_Master_InsertDAL(InqiuryNo, Noseries, Inquirydate, Custgroup, Custname, Custcontact, Custcontactno, Dept, Design, ContactEmail, ContactMno1, ContactMno2, InqiuryStatus, InquirySource, Remarks, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Inqiury_Master_UpdateBAL(int InqiuryNo, int Noseries, string Inquirydate, int Custgroup, int Custname, int Custcontact, string Custcontactno, int Dept, int Design, string ContactEmail, string ContactMno1, string ContactMno2, int InqiuryStatus, int InquirySource, string Remarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Inqiury_Master_UpdateDAL(InqiuryNo, Noseries, Inquirydate, Custgroup, Custname, Custcontact, Custcontactno, Dept, Design, ContactEmail, ContactMno1, ContactMno2, InqiuryStatus, InquirySource, Remarks, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string tbl_Inqiury_Followup_updateBAL(int Id,int Noseries, string NextFolldate, int Follotype, int Assignto, int FolloStatus, string Remarks, string Comdate, string Comremarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Inqiury_Followup_updateDAL(Id,Noseries, NextFolldate, Follotype, Assignto, FolloStatus, Remarks, Comdate, Comremarks, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public DataTable getInqiuryDetailsdataBAL( int Noseries)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getInqiuryDetailsdataDAL( Noseries);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getFollowupdataBAL( int Noseries)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getFollowupdataDAL( Noseries);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getFollowupdataforeditBal(int id,int Noseries)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getFollowupdataforeditDal(id, Noseries);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public DataTable getFollowupdataFordashBAL(int id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getFollowupdataFordashDAL(id);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public DataTable getQuotationdataFordashBAL(int id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getQuotationdataFordashDAL(id);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getInqiuryDetailsdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getInqiuryDetailsdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable getFollowupDetailsdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getFollowupDetailsdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string deleteinquirydetailsdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteinquirydetailsdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public string deleteinquiryfollowupdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteinquiryfollowupdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string tbl_Inqiury_Details_updateBAL(int Id, int Item, int Supplier, int Principal, int UOM, decimal Qty, decimal Rate, decimal Amount, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {

        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Inqiury_Details_updateDAL(Id, Item, Supplier, Principal, UOM, Qty, Rate, Amount, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
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
        dal = new DataAccessLayer();
        try
        {
            res = dal.getCustomerGroupIdbynameDAL(Name);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string getCustomerIdbynameBAL(string Name)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.getCustomerIdbynameDAL(Name);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


    public DataTable getallInqiurydataBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallInqiurydataDAL(Createby);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getallInqiurydatabynoBAL(string Noseries)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallInqiurydatabynoDAL(Noseries);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getallInqiurydataforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallInqiurydataforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }



    #endregion
    //Bulk Email Start getBulkEmailDataBAL

    public DataTable getBulkEmailDataBAL(string Createby)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getBulkEmailDataDAL(Createby);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    //Bulk EMail ENd

    //Image Upload Start

    public DataTable getallUploadedImagesforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallUploadedImagesforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }


    public DataTable getUploadedImagesbyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getUploadedImagesbyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteImagesbyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteImagesbyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable checkImagenameBAL(string groupname)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkImagenameDAL(groupname);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tblImage_Upload_InsertBAL(string Name, string path, string CreateBy, DateTime @CreateDatetime, string Extra1, string Extra2, string @Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tblImage_Upload_InsertDAL(Name,path, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public string tbl_Image_UpdateBAL(string id, string Name, string path)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Image_UpdateDAL(id, Name, path);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    //Image Upload End

    //Terms & COnditions Start

    public DataTable checktermsandconditionsdata(string name , string seq)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checktermsandconditionsdata(name, seq);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string Savetermsandconditionsbll(string name, string termsandconditions, string Createby, DateTime Createddatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.Savetermsandconditionsbll(name, termsandconditions, Createby, Createddatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    } //done

    public DataTable getalltermsandconditionsfroadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getalltermsandconditionsDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable gettermsandconditionsdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.gettermsandconditionsdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    } //done

    public string deletetermsandconditionsdata(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletetermsandconditionsdata(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    } //done

    public string tbl_termsandconditionsupdate(string id, string name, string tandc, string Sequence)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_termsandconditionsupdate(id, name, tandc,  Sequence);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    } //done

    //Terms & Conditions End

    //Country Start





    public DataTable getallCountryforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallcountryDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkCountrynameBAL(string name)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkcountrydata(name);
        }
        catch (Exception ex)
        {

        }
        return dt;
    } //done
    public string SaveCountryMasterBAL(string name, string Createby, DateTime Createddatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.Savecountrybll(name, Createby, Createddatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    } //done

    public DataTable getCountrybyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getcountrydatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    } //done

    public string deleteCountrybyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deletecountrydata(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    } //done

    public string tbl_Country_UpdateBAL(string id, string name)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_countryupdate(id, name);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    } //done




    //Quotation
    public DataTable getallQuotationdataforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallQuotationdataforadminDAL();

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public DataTable getallQuotationdataforemployeeBAL(string Company)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallQuotationdataemployeDAL(Company);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable checkQuotationProductNameBAL(string Noseries, string Item)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkQuotationProductNameDAL(Noseries, Item);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable checkQuotationProductBroucherBAL(string Item)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkQuotationProductBroucherDAL(Item);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkInquiryProductBroucherBAL(string Item)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkInquiryProductBroucherDAL(Item);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public string tbl_Quotation_Details_InsertBAL(int Noseries, int Item, int Supplier, int Principal, int UOM, decimal Qty, decimal Rate, decimal Amount, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_Details_InsertDAL(Noseries, Item, Supplier, Principal, UOM, Qty, Rate, Amount, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string tbl_Quotation_Details_Broucher_InsertBAL(int Noseries, string Item, string Supplier, string Principal, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_Details_Broucher_InsertDAL(Noseries, Item, Supplier, Principal,CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string tbl_Inquiry_Details_Broucher_InsertBAL(int Noseries, string Item, string Supplier, string Principal, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Inquiry_Details_Broucher_InsertDAL(Noseries, Item, Supplier, Principal, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getQuotationDetailsdataBAL(int Noseries)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getQuotationDetailsdataDAL(Noseries);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public DataTable checkQuotationFollowupBAL(string Noseries, string NextFolldate, int Follotype)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkQuotationFollowupDAL(Noseries, NextFolldate, Follotype);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Quotation_Followup_InsertBAL(int Noseries, string NextFolldate, int Follotype, int Assignto, int FolloStatus, string Remarks, string Comdate, string Comremarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_Followup_InsertDAL(Noseries, NextFolldate, Follotype, Assignto, FolloStatus, Remarks, Comdate, Comremarks, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable getQuotationFollowupdataBAL(int Noseries)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getQuotationFollowupdataDAL(Noseries);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public string tbl_Quotation_Followup_updateBAL(int Id, int Noseries, string NextFolldate, int Follotype, int Assignto, int FolloStatus, string Remarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_Followup_updateDAL(Id, Noseries, NextFolldate, Follotype, Assignto, FolloStatus, Remarks,  CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable getQuotationFollowupDetailsdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getQuotationFollowupDetailsdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteQuotationfollowupdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteQuotationfollowupdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable checkQuotationalreadyBAL(string Quotno, string Inquirydate, int custid, int Groupid)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkQuotationalreadyDAL(Quotno, Inquirydate, custid, Groupid);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Quotation_Master_InsertBAL(int InqiuryNo, int Noseries, string Inquirydate,int custGroup, int Custname, int Custcontact, string Custcontactno, int Dept, int Design, string ContactEmail, string ContactMno1, string ContactMno2, int InqiuryStatus, int InquirySource, string Remarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_Master_InsertDAL(InqiuryNo, Noseries, Inquirydate, custGroup, Custname, Custcontact, Custcontactno, Dept, Design, ContactEmail, ContactMno1, ContactMno2, InqiuryStatus, InquirySource, Remarks, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string tbl_Quotation_tandc_InsertBAL(int termsid, int noseries, string termstitle, string termsdescrip, string status, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_tandc_InsertDAL(termsid, noseries, termstitle, termsdescrip, status, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }


        public DataTable getallQuotationdatabynoBAL(string Noseries)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallQuoationdatabynoDAL(Noseries);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getTaxationDatabyidBAL(int Noseries)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getTaxationDatabyidDAL(Noseries);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public DataTable getTermsfroQuotationUpdateBAL(int id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getalltermsandconditionsDAL(id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Quotation_Master_UpdateBAL(int InqiuryNo, int Noseries, string Inquirydate, int custGroup, int Custname, int Custcontact, string Custcontactno, int Dept, int Design, string ContactEmail, string ContactMno1, string ContactMno2, int InqiuryStatus, int InquirySource, string Remarks, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_Master_UpdateDAL(InqiuryNo, Noseries, Inquirydate, custGroup, Custname, Custcontact, Custcontactno, Dept, Design, ContactEmail, ContactMno1, ContactMno2, InqiuryStatus, InquirySource, Remarks, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    //ENd
    //Taxation
    public DataTable checkTaxationBAL(string id, string name, int country)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkTaxationDAL(id, name, country);
        }
        catch (Exception ex)
        {

        }
        return dt;
    } //done
    public string tbl_Quotation_Taxation_InsertBAL(int Noseries, int country, string name, string percent, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_Taxation_InsertDAL(Noseries, country, name, percent, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string tbl_Quotation_Taxation_UpdateBAL(int id,int Noseries, int country, string name, string percent, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_Taxation_UpdateDAL(id,Noseries, country, name, percent, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getTaxationDataBAL(int Noseries)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getTaxationDataDAL(Noseries);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }

    public DataTable getTaxationDetailsdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getTaxationDetailsdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteQuotationTaxationdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteQuotationTaxationdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    //End

    public DataTable getQuotationtermsandconditionsdatabyidBAL(string noseries ,string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getQuotationtermsandconditionsdatabyidDAL(noseries,Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    } //done
    public DataTable getallQuotationtermsandconditionsbyidBAL(string id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallQuotationtermsandconditionsbyidDAL(id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string tbl_Quotation_tandc_UpdateBAL(int termsid, int noseries, string termstitle, string termsdescrip, string status, string CreateBy, DateTime CreateDatetime)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_tandc_UpdateDAL(termsid, noseries, termstitle, termsdescrip, status, CreateBy, CreateDatetime);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string tbl_Quotationtermsandconditionsupdate(string id, string name, string tandc, string termsid,string seq)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_QuotationtermsandconditionsupdateDAL(id, name, tandc, termsid, seq);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable getQuotationDetailsdatabyidBAL(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getQuotationDetailsdatabyidDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Quotation_Details_updateBAL(int Id, int Item, int Supplier, int Principal, int UOM, decimal Qty, decimal Rate, decimal Amount, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {

        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Quotation_Details_updateDAL(Id, Item, Supplier, Principal, UOM, Qty, Rate, Amount, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable getonlyCustomerNameBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getonlyCustomerNameDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string deleteQuotationdetailsdatabyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteQuotationdetailsdatabyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string deleteQuotationdetailsBrocherbyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteQuotationdetailsBrocherbyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public string deleteInquirydetailsBrocherbyidBAL(string id)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.deleteInquirydetailsBrocherbyidDAL(id);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }

    public DataTable getcompanyimagebyno(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getcompanyimagebynoDAL(Id);
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
            dal = new DataAccessLayer();
            dt = dal.getitemBrouchersforquotation(Noseries);

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
            dal = new DataAccessLayer();
            dt = dal.getitemBrouchersforInquiry(Noseries);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    public DataTable getCompanyforadminBAL()
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getCompanyforadminDAL();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable checkEmployee_master_detailsBAL(string txtName, string txtfhname, string txtsurname)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkEmployee_master_detailsDAL(txtName, txtfhname, txtsurname);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable getcompanybannerbyno(string Id)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getcompanybannerbynoDAL(Id);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public string tbl_Company_Banner_InsertBAL(string no, string DocuName, string Filename, string DocumentPath, string CreateBy, DateTime CreateDatetime, string Extra1, string Extra2, string Extra3, string Extra4, string Extra5)
    {
        string res = "";
        dal = new DataAccessLayer();
        try
        {
            res = dal.tbl_Company_Banner_InsertDAL(no, DocuName, Filename, DocumentPath, CreateBy, CreateDatetime, Extra1, Extra2, Extra3, Extra4, Extra5);
        }
        catch (Exception ex)
        {
            res = ex.ToString();
        }

        return res;
    }
    public DataTable checkEmployee_master_EmailBAL(string txtName, string txtfhname, string txtsurname)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.checkEmployee_master_EnailDAL(txtName, txtfhname, txtsurname);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    #region 12/02/21

    public DataTable getallInqiurydataByEmployeeBAL(string CompanyNo)
    {
        DataTable dt = null;
        try
        {
            dal = new DataAccessLayer();
            dt = dal.getallInqiurydataByEmployeeDAL(CompanyNo);

        }
        catch (Exception ex)
        {


        }
        return dt;
    }
    #endregion
}
