using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for StakeholderRelationshipManagerDAL
/// </summary>
public class StakeholderRelationshipManagerDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public StakeholderRelationshipManagerDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To insert 'Stakeholder Relationship Manager' record in database by stored procedure
    public int InsertStakeholderRelationshipManager(int UserID, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertStakeholderRelationshipManager' stored procedure is used to insert record in Stakeholder Relationship Manager table
        SqlCommand DCmd = new SqlCommand("uspInsertStakeholderRelationshipManager", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@UserID", UserID);
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

    //  To update 'Stakeholder Relationship Manager' record of Specific UpdateStakeholderRelationshipManager in database by stored procedure
    public int UpdateStakeholderRelationshipManager(int StakeholderRelationshipManagerId, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspUpdateStakeholderRelationshipManager' stored procedure is used to update record in Stakeholder Relationship Manager table
        SqlCommand DCmd = new SqlCommand("uspUpdateStakeholderRelationshipManager", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@StakeholderRelationshipManagerId", StakeholderRelationshipManagerId);
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

    //  To get 'Stakeholder Relationship Manager' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActiveStakeholderRelationshipManager(int LoggedInUser, string returnmsg, bool IsActive)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetStakeholderRelationshipManagerDetails' stored procedure is used to get specific records from Stakeholder Relationship Manager table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetStakeholderRelationshipManagerDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "StakeholderRelationshipManager");
            return DSet.Tables["StakeholderRelationshipManager"];
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

    //  To get 'Stakeholder Relationship Manager' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAllStakeholderRelationshipManager(int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetStakeholderRelationshipManagerDetails' stored procedure is used to get both 'Active','Inactive' type records from Stakeholder Relationship Manager table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetStakeholderRelationshipManagerDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "StakeholderRelationshipManager");
            return DSet.Tables["StakeholderRelationshipManager"];
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

    //  To select 'Stakeholder Relationship Manager' records specific StakeholderRelationshipManagerID from database by stored procedure
    public DataTable SelectStakeholderRelationshipManagerID(int StakeholderRelationshipManagerID, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetStakeholderRelationshipManagerDetails' stored procedure is used to get Specific StakeholderRelationshipManagerID records from Vendor table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetStakeholderRelationshipManagerDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@StakeholderRelationshipManagerID", StakeholderRelationshipManagerID);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "StakeholderRelationshipManager");
            return DSet.Tables["StakeholderRelationshipManager"];
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