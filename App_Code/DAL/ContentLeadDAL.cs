using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ContentLeadBAL
/// </summary>
public class ContentLeadDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public ContentLeadDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To insert 'Content Lead' record in database by stored procedure
    public int InsertContentLead(int UserID, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertContentLead' stored procedure is used to insert record in Content Lead table
        SqlCommand DCmd = new SqlCommand("uspInsertContentLead", Conn);
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


    //  To update 'Content Lead' record of Specific UpdateContent Lead in database by stored procedure
    public int UpdateContentLead(int ContentLeadId, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspUpdateContentLead' stored procedure is used to update record in Content Lead table
        SqlCommand DCmd = new SqlCommand("uspUpdateContentLead", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@ContentLeadId", ContentLeadId);
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

    //  To get 'Content Lead' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActiveContentLead(int LoggedInUser, string returnmsg, bool IsActive)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetContentLeadDetails' stored procedure is used to get specific records from Content Lead table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetContentLeadDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "ContentLead");
            return DSet.Tables["ContentLead"];
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

    //  To get 'Content Lead' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadContentLeadAll(int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetContentLeadDetails' stored procedure is used to get both 'Active','Inactive' type records from Content Lead table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetContentLeadDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "ContentLead");
            return DSet.Tables["ContentLead"];
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


    //  To select 'Content Lead' records specific ContentLeadId from database by stored procedure
    public DataTable SelectContentLeadId(int ContentLeadId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetContentLeadDetails' stored procedure is used to get Specific ContentLeadId records from Content Lead table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetContentLeadDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@ContentLeadId", ContentLeadId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "ContentLead");
            return DSet.Tables["ContentLead"];
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