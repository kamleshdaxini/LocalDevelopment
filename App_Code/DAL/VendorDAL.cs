using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for VendorDAL
/// </summary>
public class VendorDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
	public VendorDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To insert 'Vendor' record in database by stored procedure
    public int InsertVendor(int UserID, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertVendor' stored procedure is used to insert record in Vendor table
        SqlCommand DCmd = new SqlCommand("uspInsertVendor", Conn);
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

    //  To update 'Vendor' record of Specific UpdateVendor in database by stored procedure
    public int UpdateVendor(int VendorId, bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspUpdateVendor' stored procedure is used to update record in Vendor table
        SqlCommand DCmd = new SqlCommand("uspUpdateVendor", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@VendorID", VendorId);
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

    //  To get 'Vendor' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActiveVendor(int LoggedInUser, string returnmsg, bool IsActive)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetVendorDetails' stored procedure is used to get specific records from Vendor table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetVendorDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Vendor");
            return DSet.Tables["Vendor"];
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

    //  To get 'Vendor' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAllVendor(int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetVendorDetails' stored procedure is used to get both 'Active','Inactive' type records from Vendor table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetVendorDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Vendor");
            return DSet.Tables["Vendor"];
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

    //  To select 'Vendor' records specific VendorId from database by stored procedure
    public DataTable SelectVendorID(int VendorId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetVendorDetails' stored procedure is used to get Specific VendorId records from Vendor table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetVendorDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@ContentDeveloperId", VendorId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Vendor");
            return DSet.Tables["Vendor"];
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