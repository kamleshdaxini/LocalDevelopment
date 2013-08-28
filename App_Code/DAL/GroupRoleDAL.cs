using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.Data;

/// <summary>
/// Summary description for GroupRoleDAL
/// </summary>
public class GroupRoleDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public GroupRoleDAL()
	{
        //
        // TODO: Add constructor logic here
        //
	}
    

    //  To insert 'Group Role' record in database by stored procedure
    public int InsertGroupRole(int GroupId, int RoleId, bool IsActive, int LoginUser, string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            //  'uspInsertGroupRole' stored procedure is used to insert record in Group Role table
            SqlCommand DCmd = new SqlCommand("uspInsertGroupRole", Conn);
            DCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                DCmd.Parameters.AddWithValue("@GroupId", GroupId);
                DCmd.Parameters.AddWithValue("@RoleID", RoleId);
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

    //  To update 'Group Role' record of Specific UpdateGroupRole in database by stored procedure
    public int UpdateGroupRole(int GroupRoleId, bool IsActive, int LoginUser, string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            //  'uspUpdateGroupRole' stored procedure is used to update record in Group Role table
            SqlCommand DCmd = new SqlCommand("uspUpdateGroupRole", Conn);
            DCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                DCmd.Parameters.AddWithValue("@GroupRoleID", GroupRoleId);
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

    //  To get 'Group Role' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadGroupRoleAll(int LoggedInUser, string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            //  'uspGetGroupRoleDetails' stored procedure is used to get specific records from Group Role table
            SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupRoleDetails", Conn);
            DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
            DataSet DSet = new DataSet();
            try
            {
                DAdapter.Fill(DSet, "GroupRole");
                return DSet.Tables["GroupRole"];
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
    //  To get 'Group Role' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable GroupRoleLoad(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(ConnStr);
        SqlDataAdapter dAd = new SqlDataAdapter("uspGetGroupRoleDetails", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);        
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);

        DataTable dt = new DataTable();
        try
        {
            dAd.Fill(dt);
            DataTable dtNew = dt.Copy();
            DataColumn dc = new DataColumn("GroupRole");
            DataRow dr;
            dtNew.Columns.Add(dc);
            if (dtNew.Rows.Count > 0)
            {
                for (int i = 0; i < dtNew.Rows.Count; i++)
                {
                    string Group = dtNew.Rows[i][2].ToString();
                    string Role = dtNew.Rows[i][4].ToString();
                    dtNew.Rows[i][12] = Group + "-" + Role;

                }
            }
            return dtNew;
        }
        catch
        {
            throw;
        }
        finally
        {

            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
    //  To get 'Group Role' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadActiveGroupRole(bool IsActive, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupRoleDetails' stored procedure is used to get both 'Active','Inactive' type records from Group Role table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupRoleDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "GroupRole");
            return DSet.Tables["GroupRole"];
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

    //  To select 'Group Role' records specific GroupRoleID from database by stored procedure
    public DataTable SelectGroupRoleID(int GroupRoleID, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupRoleDetails' stored procedure is used to get Specific GroupRoleID records from Group Role table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupRoleDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@GroupRoleID", GroupRoleID);
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

    //  To select 'Group Role' records specific GroupID from database by stored procedure
    public DataTable SelectGroupID(bool IsActive,int GroupID, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupRoleDetails' stored procedure is used to get Specific GroupID records from Group Role table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupRoleDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DAdapter.SelectCommand.Parameters.AddWithValue("@GroupID", GroupID);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "GroupRole");
            return DSet.Tables["GroupRole"];
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

    //  To select 'Group Role' records specific GroupID and RoleID from database by stored procedure
    public DataTable SelectGroupIDRoleID(int GroupID, int RoleId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupRoleDetails' stored procedure is used to get Specific GroupID & RoleID records from Group Role table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupRoleDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@GroupId", GroupID);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RoleID", GroupID);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "GroupRole");
            return DSet.Tables["GroupRole"];
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