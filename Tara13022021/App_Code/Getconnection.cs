using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Getconnection
/// </summary>
public class Getconnection
{
    public SqlConnection sqlMasterConnection = new SqlConnection();
    private int result;
    private SqlDataAdapter myAdapter = new SqlDataAdapter();
    public Getconnection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void CheckLoginStatus()
    {
        if (HttpContext.Current.Session["name"] == null || HttpContext.Current.Session["role"] == null ||
            HttpContext.Current.Session["Id"] == null)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Redirect("~/Default.aspx?action=fail");
        }
    }
    public SqlConnection getconnection()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["demo"].ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                sqlMasterConnection = sqlCon;
            }
        }
        catch (Exception e)
        {


        }
        return sqlMasterConnection;
    }

    public SqlConnection getconnectiontally()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["demotally"].ConnectionString);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                sqlMasterConnection = sqlCon;
            }
        }
        catch (Exception e)
        {


        }
        return sqlMasterConnection;
    }
    private SqlConnection connection;
    public void CloseConnection()
    {
        try
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }
        catch (Exception e)
        {
            connection.Close();
            connection.Dispose();
            //SiteErrorInsert(e);
        }
    }

    public static bool SiteErrorInsert(Exception ex)
    {
        bool status = false;
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["demo"].ConnectionString);
        try
        {

            SqlCommand sqlCommand = new SqlCommand("SiteErrorInsert", sqlCon);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter spErrorCode = new SqlParameter("@ErrorCode", SqlDbType.VarChar, 50);
            spErrorCode.Value = "";
            sqlCommand.Parameters.Add(spErrorCode);

            SqlParameter spExceptionMessage = new SqlParameter("@ExceptionMessage", SqlDbType.VarChar, ex.Message.Length);
            spExceptionMessage.Value = ex.Message;
            sqlCommand.Parameters.Add(spExceptionMessage);

            SqlParameter spExceptionStackTrace = new SqlParameter("@ExceptionStackTrace", SqlDbType.VarChar, ex.StackTrace.Length);
            spExceptionStackTrace.Value = ex.StackTrace;
            sqlCommand.Parameters.Add(spExceptionStackTrace);

            SqlParameter spSource = new SqlParameter("@Source", SqlDbType.VarChar, ex.Source.Length);
            spSource.Value = ex.Source;
            sqlCommand.Parameters.Add(spSource);

            string fileName = "";
            string lineNo = "";
            string description = "";

            if (ex.InnerException != null)
            {
                Exception inex = ex.InnerException;
                StackTrace trace = new StackTrace(inex, true);
                if (trace != null && trace.FrameCount > 0)
                {
                    fileName = trace.GetFrame(0).GetFileName();
                    lineNo = Convert.ToString(trace.GetFrame(0).GetFileLineNumber());
                }
            }

            description = "Type : " + ex.GetType().ToString() + " Method Name : " + ex.TargetSite + " FileName : " + fileName + " Line No : " + lineNo;

            SqlParameter spDescription = new SqlParameter("@Description", SqlDbType.VarChar, description.Length);
            spDescription.Value = description;
            sqlCommand.Parameters.Add(spDescription);

            SqlParameter spModifyBY = new SqlParameter("@SalesPersonCode", SqlDbType.VarChar, 100);
            spModifyBY.Value = GetLoginCode();
            sqlCommand.Parameters.Add(spModifyBY);

            SqlParameter spIPAddress = new SqlParameter("@IPAddress", SqlDbType.VarChar, 50);
            spIPAddress.Value = GetIPAddress();
            sqlCommand.Parameters.Add(spIPAddress);

            SqlParameter spBrowser = new SqlParameter("@Browser", SqlDbType.VarChar, 50);
            spBrowser.Value = GetWebBrowser();
            sqlCommand.Parameters.Add(spBrowser);

            SqlParameter spWebURL = new SqlParameter("@WebURL", SqlDbType.VarChar, 1024);
            spWebURL.Value = GetWebURL();
            sqlCommand.Parameters.Add(spWebURL);

            sqlCon.Open();
            sqlCommand.ExecuteNonQuery();
            status = true;

        }
        catch (Exception e)
        {
            HttpContext.Current.Response.Write(e.Message);
            HttpContext.Current.Response.Write(e.StackTrace);
        }
        finally
        {
            sqlCon.Close();
        }
        return status;
    }
    public static string GetWebURL()
    {
        return HttpContext.Current.Request.Url.AbsoluteUri;
    }
    public static string GetIPAddress()
    {
        return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
    }
    public static string GetWebBrowser()
    {
        string returnval = "";
        //return HttpContext.Current.Request.Browser.Browser;
        try
        {
            string navigatorAgent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            string browserName = "";
            string fullVersionName = "";
            int nameOffset, verOffset, ix;

            // In Firefox, the true version is after "Firefox" 
            if ((verOffset = navigatorAgent.IndexOf("Firefox")) != -1)
            {
                browserName = "Firefox";
                fullVersionName = navigatorAgent.Substring(verOffset + 8);
            }

            // In MSIE, the true version is after "MSIE" in userAgent
            else if ((verOffset = navigatorAgent.IndexOf("rv:")) != -1)
            {
                browserName = "IE";
                fullVersionName = navigatorAgent.Substring(verOffset + 3);
            }
            // In MSIE, the true version is after "MSIE" in userAgent
            else if ((verOffset = navigatorAgent.IndexOf("MSIE")) != -1)
            {
                browserName = "IE";
                fullVersionName = navigatorAgent.Substring(verOffset + 5);
            }
            // In Chrome, the true version is after "Chrome" 
            else if ((verOffset = navigatorAgent.IndexOf("Chrome")) != -1)
            {
                browserName = "Chrome";
                fullVersionName = navigatorAgent.Substring(verOffset + 7);
            }

            // In Opera, the true version is after "Opera" or after "Version"
            else if ((verOffset = navigatorAgent.IndexOf("Opera")) != -1)
            {
                browserName = "Opera";
                fullVersionName = navigatorAgent.Substring(verOffset + 6);
                if ((verOffset = navigatorAgent.IndexOf("Version")) != -1)
                    fullVersionName = navigatorAgent.Substring(verOffset + 8);
            }

            // In Safari, the true version is after "Safari" or after "Version" 
            else if ((verOffset = navigatorAgent.IndexOf("Safari")) != -1)
            {
                browserName = "Safari";
                fullVersionName = navigatorAgent.Substring(verOffset + 7);
                if ((verOffset = navigatorAgent.IndexOf("Version")) != -1)
                    fullVersionName = navigatorAgent.Substring(verOffset + 8);
            }

            // In most other browsers, "name/version" is at the end of userAgent 
            else if ((nameOffset = navigatorAgent.LastIndexOf(' ') + 1) <
                      (verOffset = navigatorAgent.LastIndexOf('/')))
            {
                browserName = navigatorAgent.Substring(nameOffset, verOffset);
                fullVersionName = navigatorAgent.Substring(verOffset + 1);

            }
            // trim the fullVersionName string at semicolon/space if present
            if ((ix = fullVersionName.ToString().IndexOf(";")) != -1)
                fullVersionName = fullVersionName.ToString().Substring(0, ix);
            if ((ix = fullVersionName.ToString().IndexOf(" ")) != -1)
                fullVersionName = fullVersionName.ToString().Substring(0, ix);

            if (fullVersionName.ToString().IndexOf(".") != -1)
            {
                fullVersionName = fullVersionName.Substring(0, fullVersionName.ToString().IndexOf("."));
            }

            returnval = browserName + " " + fullVersionName;
        }
        catch (Exception e)
        {
            SiteErrorInsert(e);
        }
        return returnval;

    }
    public static string GetLoginRole()
    {
        string RoleName = "";
        try
        {
            if (HttpContext.Current.Session["role"] != null)
            {
                RoleName = Convert.ToString(HttpContext.Current.Session["role"]);
            }
        }
        catch (Exception e)
        {
            SiteErrorInsert(e);
        }
        return RoleName;
    }
    public static string GetLoginCode()
    {
        string UserCode = "";
        try
        {
            if (HttpContext.Current.Session["Id"] != null)
            {
                UserCode = Convert.ToString(HttpContext.Current.Session["Id"]);
            }
        }
        catch (Exception e)
        {
            SiteErrorInsert(e);
        }
        return UserCode;
    }

    public static string GetLoginName()
    {
        string UserName = "";
        try
        {
            if (HttpContext.Current.Session["name"] != null)
            {
                UserName = Convert.ToString(HttpContext.Current.Session["name"]);
            }
        }
        catch (Exception e)
        {
            SiteErrorInsert(e);
        }
        return UserName;
    }

    #region executeSelectQuery
    public DataTable executeSelectQuery(String _query)
    {
        SqlCommand myCommand = new SqlCommand();
        DataTable dataTable = new DataTable();
        dataTable = null;
        DataSet ds = new DataSet();
        try
        {
            myCommand.Connection = getconnection();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = _query;
            myCommand.ExecuteNonQuery();
            myAdapter.SelectCommand = myCommand;
            myAdapter.Fill(ds);
            dataTable = ds.Tables[0];
        }
        catch (SqlException e)
        {
            Console.Write("Error - Connection.executeSelectQuery - Query:" + _query + " \nException: " + e.StackTrace.ToString());
            return null;
        }
        finally
        {
            CloseConnection();
        }
        return dataTable;
    }
    #endregion

    #region executeSelectQueryByID
    public DataTable executeSelectQueryByID(String _query, SqlParameter[] sqlParameter)
    {
        SqlCommand myCommand = new SqlCommand();
        DataTable dataTable = new DataTable();
        dataTable = null;
        DataSet ds = new DataSet();
        try
        {
            myCommand.Connection = getconnection();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = _query;
            myCommand.Parameters.AddRange(sqlParameter);
            myCommand.ExecuteNonQuery();
            myAdapter.SelectCommand = myCommand;
            myAdapter.Fill(ds);
            dataTable = ds.Tables[0];
        }
        catch (SqlException e)
        {
            Console.Write("Error - Connection.executeSelectQuery - Query:" + _query + " \nException: " + e.StackTrace.ToString());
            return null;
        }
        finally
        {
            CloseConnection();
        }
        return dataTable;
    }
    #endregion

    #region executeInsertQuery

    public int executeInsertQuerywithvalue(String _query, SqlParameter[] sqlParameter)
    {
        SqlCommand myCommand = new SqlCommand();
        try
        {
            myCommand.Connection = getconnection();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = _query;
            myCommand.Parameters.AddRange(sqlParameter);
            myAdapter.InsertCommand = myCommand;
           // result = myCommand.ExecuteNonQuery();

            SqlParameter returnParameter = myCommand.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            myCommand.ExecuteNonQuery();

            result = (int)returnParameter.Value;

            if (_query == "Visit_Entry_Insert")
            {
                result = Convert.ToInt32(myCommand.Parameters["@ID"].Value.ToString());
            }
            if (_query == "AdminMaster_Insert")
            {
                result = Convert.ToInt32(myCommand.Parameters["@flag"].Value.ToString());
            }


        }
        catch (SqlException e)
        {
            Console.Write("Error - Connection.executeInsertQuery - Query:" + _query + " \nException: \n" + e.StackTrace.ToString());
            result = 0;
        }
        finally
        {
            CloseConnection();
        }
        return result;
    }
    public int executeInsertQuery(String _query, SqlParameter[] sqlParameter)
    {
        SqlCommand myCommand = new SqlCommand();
        try
        {
            myCommand.Connection = getconnection();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = _query;
            myCommand.Parameters.AddRange(sqlParameter);
            myAdapter.InsertCommand = myCommand;
            result = myCommand.ExecuteNonQuery();

          

            if (_query == "Visit_Entry_Insert")
            {
                result = Convert.ToInt32(myCommand.Parameters["@ID"].Value.ToString());
            }
            if (_query == "AdminMaster_Insert")
            {
                result = Convert.ToInt32(myCommand.Parameters["@flag"].Value.ToString());
            }
            

        }
        catch (SqlException e)
        {
            Console.Write("Error - Connection.executeInsertQuery - Query:" + _query + " \nException: \n" + e.StackTrace.ToString());
            result = 0;
        }
        finally
        {
            CloseConnection();
        }
        return result;
    }
    #endregion

    #region executeUpdateQuery
    public int executeUpdateQuery(String _query, SqlParameter[] sqlParameter)
    {
        SqlCommand myCommand = new SqlCommand();
        try
        {
            myCommand.Connection = getconnection();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = _query;
            myCommand.Parameters.AddRange(sqlParameter);
            myAdapter.UpdateCommand = myCommand;
            result = myCommand.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            Console.Write("Error - Connection.executeUpdateQuery - Query:" + _query + " \nException: " + e.StackTrace.ToString());
            result = 0;
        }
        finally
        {
            CloseConnection();
        }
        return result;
    }
    #endregion

    #region executeDeleteQuery
    public int executeDeleteQuery(String _query, SqlParameter[] sqlParameter)
    {
        SqlCommand myCommand = new SqlCommand();
        try
        {
            myCommand.Connection = getconnection();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = _query;
            myCommand.Parameters.AddRange(sqlParameter);
            myAdapter.DeleteCommand = myCommand;
            result = myCommand.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            Console.Write("Error - Connection.executeUpdateQuery - Query:" + _query + " \nException: " + e.StackTrace.ToString());
            result = 0;
        }
        finally
        {
            CloseConnection();
        }
        return result;
    }
    #endregion
}