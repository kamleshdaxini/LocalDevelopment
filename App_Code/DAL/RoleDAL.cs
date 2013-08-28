using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


/// <summary>
/// Summary description for RoleDAL
/// </summary>
public class RoleDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public RoleDAL()
	{
        //
        // TODO: Add constructor logic here
        //
	}

    //  To insert 'Role' record in database by stored procedure
    public int InsertRole(string RoleName, string RoleDescription, bool IsActive, int LoginUser, string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            //  'uspInsertRole' stored procedure is used to insert record in Role table
            SqlCommand DCmd = new SqlCommand("uspInsertRole", Conn);
            DCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                DCmd.Parameters.AddWithValue("@RoleName", RoleName);
                DCmd.Parameters.AddWithValue("@RoleDescription", RoleDescription);
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

    //  To update 'Role' record of Specific Role in database by stored procedure
    public int UpdateRole(int RoleId, string RoleName, string RoleDescription, bool IsActive, int LoginUser, string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            //  'uspUpdateRole' stored procedure is used to update record in Role table
            SqlCommand DCmd = new SqlCommand("uspUpdateRole", Conn);
            DCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                DCmd.Parameters.AddWithValue("@RoleId", RoleId);
                DCmd.Parameters.AddWithValue("@RoleDescription", RoleDescription);
                DCmd.Parameters.AddWithValue("@IsActive", IsActive);
                DCmd.Parameters.AddWithValue("@RoleName", RoleName);
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

    //  To get 'Role' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadAllRole(int LoggedInUser, string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            //  'uspGetRoleDetails' stored procedure is used to selct Active and InActive type records From Role table
            SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetRoleDetails", Conn);          
            DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;           
            DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
            DataSet DSet = new DataSet();
            try
            {
                DAdapter.Fill(DSet, "Role");
                return DSet.Tables["Role"];
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

    //  To get 'Role' record of 'Active' type from database by stored procedure
    public DataTable LoadActiveRole(bool IsActive, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetRoleDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Role");
            return DSet.Tables["Role"];
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

    //  To select 'Role' records specific RoleId from database by stored procedure
    public DataTable SelectRoleID(int RoleId, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetRoleDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RoleId", RoleId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Role");
            return DSet.Tables["Role"];
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

    //  To Change status of 'Role' record of specific RoleId from database by stored procedure
    public int ChangeRoleStatus(int RoleId, int LoggedInUser, string Ret, bool IsActive)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            SqlCommand DCmd = new SqlCommand("uspUpdateRoleStatus", Conn);
            DCmd.CommandType = CommandType.StoredProcedure;
            DCmd.Parameters.AddWithValue("@RoleId", RoleId);
            DCmd.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DCmd.Parameters.AddWithValue("@IsActive", IsActive);
            DCmd.Parameters.AddWithValue("@RetMsg", Ret);
            try
            {               
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

}