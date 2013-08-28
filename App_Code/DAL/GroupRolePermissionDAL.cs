using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


/// <summary>
/// Summary description for GroupRolePermissionDAL
/// </summary>
public class GroupRolePermissionDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public GroupRolePermissionDAL()
	{
        //
        // TODO: Add constructor logic here
        //
	}

    //  To insert 'Group Role Permission' record in database by stored procedure
    public int InsertGroupRolePermission(int GroupRoleId, int SubMenuId, int PermissionId, bool IsActive, int LoginUser, string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            //  'uspInsertGroupRolePermission' stored procedure is used to insert record in Group Role Permission table
            SqlCommand DCmd = new SqlCommand("uspInsertGroupRolePermission", Conn);
            DCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                DCmd.Parameters.AddWithValue("@PermissionID", PermissionId);
                DCmd.Parameters.AddWithValue("@GroupRoleId", GroupRoleId);
                DCmd.Parameters.AddWithValue("@SubMenuID", SubMenuId);
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

    //  To update 'Group Role Permission' record of Specific UpdateGroupRolePermission in database by stored procedure
    public int UpdateGroupRolePermission(int GroupRolePermissionId, int PermissionId, bool IsActive, int LoginUser, string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            //  'uspUpdateGroupRolePermission' stored procedure is used to update record in Group Role Permission table
            SqlCommand DCmd = new SqlCommand("uspUpdateGroupRolePermission", Conn);
            DCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                DCmd.Parameters.AddWithValue("@GroupRolePermissionID", GroupRolePermissionId);
                DCmd.Parameters.AddWithValue("@PermissionID", PermissionId);                
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

    //  To get 'Group Role Permission' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAllGroupRolePermission(int LoggedInUser, string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            //  'uspGetGroupRolePermissionDetails' stored procedure is used to get both 'Active','Inactive' type records from Group Role Permission table
            SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupRolePermissionDetails", Conn);          
            DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;           
            DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
            DataSet DSet = new DataSet();
            try
            {
                DAdapter.Fill(DSet, "GroupRolePermission");
                return DSet.Tables["GroupRolePermission"];
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

    //  To get 'Group Role Permission' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActiveGroupRolePermission(bool IsActive, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupRolePermissionDetails' stored procedure is used to get specific records from Group Role Permission table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupRolePermissionDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "GroupRolePermission");
            return DSet.Tables["GroupRolePermission"];
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

    //  To select 'Group Role Permission' records specific GroupRoleID from database by stored procedure
    public DataTable SelectGroupRolePermissionID(int GroupRoleId, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupRolePermissionDetails' stored procedure is used to get Specific GroupRoleID records from Group Role Permission table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupRolePermissionDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@GroupRoleID", GroupRoleId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Group");
            return DSet.Tables["Group"];
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

    //  To select 'Group Role Permission' records specific GroupID from database by stored procedure
    public DataTable SelectGroupID(int GroupId, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupRolePermissionDetails' stored procedure is used to get Specific GroupID records from Group Role Permission table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupRolePermissionDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@GroupID", GroupId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Group");
            return DSet.Tables["Group"];
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