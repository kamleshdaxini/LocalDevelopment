using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for WSStatusDAL
/// </summary>
public class WS1StatusDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public WS1StatusDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'WS1 Status' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadWS1Status(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetWS1StatusDetails' stored procedure is used to get both 'Active','Inactive' type records from WS1 Status table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Masters.uspGetWS1StatusDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "WS1Status");
            return DSet.Tables["WS1Status"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }
}