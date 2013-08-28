using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for PortfolioManagerDAL
/// </summary>
public class PortfolioManagerDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public PortfolioManagerDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To insert 'Portfolio Manager' record in database by stored procedure
    public int InsertPortfolioManager(int UserID, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertPortfolioManager' stored procedure is used to insert record in Portfolio Manager table
        SqlCommand DCmd = new SqlCommand("uspInsertPortfolioManager", Conn);
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

    //  To update 'Portfolio Manager' record of Specific UpdatePortfolioManager in database by stored procedure
    public int UpdatePortfolioManager(int PortfolioManagerId, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspUpdatePortfolioManager' stored procedure is used to update record in Portfolio Manager table
        SqlCommand DCmd = new SqlCommand("uspUpdatePortfolioManager", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@PortfolioManagerId", PortfolioManagerId);
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

    //  To get 'Portfolio Manager' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActivePortfolioManager(int LoggedInUser, string Ret, bool IsActive)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetPortfolioManagerDetails' stored procedure is used to get specific records from Portfolio Manager table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetPortfolioManagerDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "PortfolioManager");
            return DSet.Tables["PortfolioManager"];
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

    //  To get 'Portfolio Manager' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAllPortfolioManager(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetPortfolioManagerDetails' stored procedure is used to get both 'Active','Inactive' type records from Portfolio Manager table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetPortfolioManagerDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "PortfolioManager");
            return DSet.Tables["PortfolioManager"];
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

    //  To select 'Portfolio Manager' records specific PortfolioManagerId from database by stored procedure
    public DataTable SelectPortfolioManagerID(int PortfolioManagerId, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetPortfolioManagerDetails' stored procedure is used to get Specific PortfolioManagerId records from Portfolio Manager table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetPortfolioManagerDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@PortfolioManagerId", PortfolioManagerId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "PortfolioManager");
            return DSet.Tables["PortfolioManager"];
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