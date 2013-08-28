using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ContentDeveloperDAL
/// </summary>
public class ContentDeveloperDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public ContentDeveloperDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To insert 'Content Developer' record in database by stored procedure
    public int InsertContentDeveloper(int UserID, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertContentDeveloper' stored procedure is used to insert record in Content Developer table
        SqlCommand DCmd = new SqlCommand("uspInsertContentDeveloper", Conn);
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


    //  To update 'Content Developer' record of Specific UpdateContentDeveloper in database by stored procedure
    public int UpdateContentDeveloper(int ContentDeveloperId, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspUpdateContentDeveloper' stored procedure is used to update record in Content Developer table
        SqlCommand DCmd = new SqlCommand("uspUpdateContentDeveloper", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@ContentDeveloperId", ContentDeveloperId);
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

    //  To get 'Content Developer' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActiveContentDeveloper(int LoggedInUser, string returnmsg, bool IsActive)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetContentDeveloperDetails' stored procedure is used to get specific records from Content Developer table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetContentDeveloperDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "ContentDeveloper");
            return DSet.Tables["ContentDeveloper"];
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

    //  To get 'Content Developer' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadContentDeveloperAll(int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetContentDeveloperDetails' stored procedure is used to get both 'Active','Inactive' type records from Content Developer table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetContentDeveloperDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "ContentDeveloper");
            return DSet.Tables["ContentDeveloper"];
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


    //  To select 'Content Developer' records specific ContentDeveloperId from database by stored procedure
    public DataTable SelectContentDeveloperID(int ContentDeveloperId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetContentDeveloperDetails' stored procedure is used to get Specific ContentDeveloperId records from Content Developer table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetContentDeveloperDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@ContentDeveloperId", ContentDeveloperId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "ContentDeveloper");
            return DSet.Tables["ContentDeveloper"];
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