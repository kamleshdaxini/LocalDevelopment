using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for PermissionDAL
/// </summary>
public class PermissionDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
	public PermissionDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'Permission' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadPermission(int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetPermissionDetails' stored procedure is used to get both 'Active','Inactive' type records from Permission table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetPermissionDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Permission");
            return DSet.Tables["Permission"];
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