using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for InstructionalDesignerDAL
/// </summary>
public class InstructionalDesignerDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public InstructionalDesignerDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To insert 'Instructional Designer' record in database by stored procedure
    public int InsertInstructionalDesigner(int UserID, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertInstructionalDesigner' stored procedure is used to insert record in Instructional Designer table
        SqlCommand DCmd = new SqlCommand("uspInsertInstructionalDesigner", Conn);
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

    //  To update 'Instructional Designer' record of Specific UpdateInstructionalDesigner in database by stored procedure
    public int UpdateInstructionalDesigner(int InstructionalDesignerId, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspUpdateInstructionalDesigner' stored procedure is used to update record in Instructional Designer table
        SqlCommand DCmd = new SqlCommand("uspUpdateInstructionalDesigner", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@InstructionalDesignerId", InstructionalDesignerId);
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

    //  To get 'Instructional Designer' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActiveInstructionalDesigner(int LoggedInUser, string Ret, bool IsActive)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetInstructionalDesignerDetails' stored procedure is used to get specific records from Instructional Designer table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetInstructionalDesignerDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "InstructionalDesigner");
            return DSet.Tables["InstructionalDesigner"];
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

    //  To get 'Instructional Designer' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAllInstructionalDesigner(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetInstructionalDesignerDetails' stored procedure is used to get both 'Active','Inactive' type records from Instructional Designer table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetInstructionalDesignerDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "InstructionalDesigner");
            return DSet.Tables["InstructionalDesigner"];
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

    //  To select 'Instructional Designer' records specific InstructionalDesignerId from database by stored procedure
    public DataTable SelectInstructionalDesignerID(int InstructionalDesignerId, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetInstructionalDesignerDetails' stored procedure is used to get Specific InstructionalDesignerId records from Instructional Designer table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetInstructionalDesignerDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@InstructionalDesignerId", InstructionalDesignerId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "InstructionalDesigner");
            return DSet.Tables["InstructionalDesigner"];
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