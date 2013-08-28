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
/// Summary description for GroupDAL
/// </summary>
public class GroupDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();

    public GroupDAL()
	{
        //
        // TODO: Add constructor logic here
        //
	}

    //  To insert 'Group' record in database by stored procedure
    public int InsertGroup(string GroupName, string GroupDescription,bool IsActive, int  LoginUser,string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            //  'uspInsertGroup' stored procedure is used to insert record in Group table
            SqlCommand DCmd = new SqlCommand("uspInsertGroup", Conn);
            DCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                DCmd.Parameters.AddWithValue("@GroupName", GroupName);
                DCmd.Parameters.AddWithValue("@GroupDescription", GroupDescription);
                DCmd.Parameters.AddWithValue("@LoggedInUser", LoginUser);
                DCmd.Parameters.AddWithValue("@IsActive", IsActive);
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



    //  To update 'Group' record of Specific Group in database by stored procedure
    public int UpdateGroup(int GroupId,string GroupDescription,bool IsActive, string GroupName, int LoginUser, string Ret)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            //  'uspInsertGroup' stored procedure is used to update record in Group table
            SqlCommand DCmd = new SqlCommand("uspUpdateGroup", Conn);
            DCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                DCmd.Parameters.AddWithValue("@GroupId", GroupId);
                DCmd.Parameters.AddWithValue("@GroupName", GroupName);
                DCmd.Parameters.AddWithValue("@GroupDescription", GroupDescription);
                DCmd.Parameters.AddWithValue("@LoggedInUser", LoginUser);
                DCmd.Parameters.AddWithValue("@IsActive", IsActive);
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

    //  To get 'Group' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadAllGroup(int LoggedInUser, string returnmsg)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            //  'uspInsertGroup' stored procedure is used to selct Active and InActive type records From group table
            SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupDetails", Conn);          
            DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;           
            DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
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

    //  To get 'Group' record of 'Active' type from database by stored procedure
    public DataTable LoadActiveGroup(bool IsActive, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupDetails' stored procedure is used to select Active type Group records from Group table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
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

    //  To select 'Group' records specific GroupId from database by stored procedure
    public DataTable SelectGroupID(int GroupId,int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupDetails' stored procedure is used to select record from Group table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetGroupDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@GroupId", GroupId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
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

    //  To Change status of 'Group' record of specific GroupId from database by stored procedure
    public int ChangeGroupStatus(int GroupId, int LoggedInUser, string returnmsg, bool IsActive)
        {
            SqlConnection Conn = new SqlConnection(ConnStr);
            Conn.Open();
            //  'uspUpdateGroupStatus' stored procedure is used to Chnage Status of record in Group table
            SqlCommand DCmd = new SqlCommand("uspUpdateGroupStatus", Conn);
            DCmd.CommandType = CommandType.StoredProcedure;
            DCmd.Parameters.AddWithValue("@GroupId", GroupId);
            DCmd.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DCmd.Parameters.AddWithValue("@IsActive", IsActive);
            DCmd.Parameters.AddWithValue("@RetMsg", returnmsg);
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