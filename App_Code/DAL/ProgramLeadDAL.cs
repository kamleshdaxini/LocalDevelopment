using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for PLDAL
/// </summary>
public class ProgramLeadDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public ProgramLeadDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To insert 'Program Lead' record in database by stored procedure
    public int InsertProgramLead(int UserID, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertProgramLead' stored procedure is used to insert record in Program Lead table
        SqlCommand DCmd = new SqlCommand("uspInsertProgramLead", Conn);
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

    //  To update 'Program Lead' record of Specific UpdateProgramLead in database by stored procedure
    public int UpdateProgramLead(int ProgramLeadId, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspUpdateProgramLead' stored procedure is used to update record in Program Lead table
        SqlCommand DCmd = new SqlCommand("uspUpdateProgramLead", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@ProgramLeadId", ProgramLeadId);
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

    //  To get 'Program Lead(' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActiveProgramLead(int LoggedInUser, string returnmsg, bool IsActive)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetProgramLeadDetails' stored procedure is used to get specific records from Program Lead table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetProgramLeadDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "ProgramLead");
            return DSet.Tables["ProgramLead"];
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

    //  To get 'Program Lead' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAllProgramLead(int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetContentDeveloperDetails' stored procedure is used to get both 'Active','Inactive' type records from Program Lead table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetProgramLeadDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "ProgramLead");
            return DSet.Tables["ProgramLead"];
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

    //  To select 'Program Lead' records specific ProgramLeadId from database by stored procedure
    public DataTable SelectProgramLeadID(int ProgramLeadId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetProgramLeadDetails' stored procedure is used to get Specific ProgramLeadId records from Program Lead table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetProgramLeadDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@ProgramLeadId", ProgramLeadId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "ProgramLead");
            return DSet.Tables["ProgramLead"];
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