using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for UserGroupRoleDAL
/// </summary>
public class UserGroupRoleDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public UserGroupRoleDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To insert 'User Group Role' record in database by stored procedure
    public int InsertUserGroupRole(int UserID, int GroupRoleID, int IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertUserGroupRole' stored procedure is used to insert record in User Group Role table
        SqlCommand DCmd = new SqlCommand("uspInsertUserGroupRole", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@UserID", UserID);
            DCmd.Parameters.AddWithValue("@GroupRoleID", GroupRoleID);
            DCmd.Parameters.AddWithValue("@IsActive", IsActive);
            DCmd.Parameters.AddWithValue("@LoggedInUser", LoginUser);
            DCmd.Parameters.AddWithValue("@RetMsg", Ret);
            return DCmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            DCmd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To update 'User Group Role' record of Specific UpdateUserGroupRole in database by stored procedure
    public int UpdateUserGroupRole(int UserGroupRoleID, int IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspUpdateUserGroupRole' stored procedure is used to update record in User Group Role table
        SqlCommand DCmd = new SqlCommand("uspUpdateUserGroupRole", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@UserGroupRoleId", UserGroupRoleID);
            DCmd.Parameters.AddWithValue("@IsActive", IsActive);
            DCmd.Parameters.AddWithValue("@LoggedInUser", LoginUser);
            DCmd.Parameters.AddWithValue("@RetMsg", Ret);
            return DCmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            DCmd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To get 'User Group Role' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAllUserGroupRole(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserGroupRoleDetails' stored procedure is used to get both 'Active','Inactive' type records from User Group Role table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserGroupRoleDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "UserGroupRole");
            return DSet.Tables["UserGroupRole"];
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

    //  To select 'User Group Role' records specific UserID from database by stored procedure
    public DataTable SelectUserID(int UserID, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserGroupRoleDetails' stored procedure is used to get Specific UserID records from User Group Role table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserGroupRoleDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@UserID", UserID);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "UserGroupRole");
            return DSet.Tables["UserGroupRole"];
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

    //  To select 'User Group Role' records specific GroupRoleID from database by stored procedure
    public DataTable SelectGroupRoleID(int GroupRoleID, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserGroupRoleDetails' stored procedure is used to get Specific GroupRoleID records from User Group Role table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserGroupRoleDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@GroupRoleID", GroupRoleID);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "UserGroupRole");
            return DSet.Tables["UserGroupRole"];
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

    //  To insert 'User Group Role' record in database by stored procedure
    public int InsertNewUserGroupRole(int UserID, int GroupRoleID, int IsActive, int LoginUser)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertUserGroupRole' stored procedure is used to insert record in User Group Role table
        SqlCommand DCmd = new SqlCommand("uspInsertUserGroupRole", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@UserID", UserID);
            DCmd.Parameters.AddWithValue("@GroupRoleID", GroupRoleID);
            DCmd.Parameters.AddWithValue("@IsActive", IsActive);
            DCmd.Parameters.AddWithValue("@LoggedInUser", LoginUser);
            return DCmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            DCmd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To select 'User Group Role' records specific UserID & GroupRoleID from database by stored procedure
    public DataTable SelectUserGroupID(int UserID, int GroupRoleID, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserGroupRoleDetails' stored procedure is used to get Specific VendorId records from User Group Role table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserGroupRoleDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@GroupRoleID", GroupRoleID);
        DAdapter.SelectCommand.Parameters.AddWithValue("@UserID", UserID);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "UserGroupRole");
            return DSet.Tables["UserGroupRole"];
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

