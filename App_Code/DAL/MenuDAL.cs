using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MenuDAL
/// </summary>
public class MenuDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public MenuDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    //  To insert 'Menu' record in database by stored procedure
    public int InsertMenu(string MenuName, string MenuDesc, int IsActive,int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertMenu' stored procedure is used to insert record in Menu table
        SqlCommand DCmd = new SqlCommand("uspInsertMenu", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@MenuName", MenuName);
            DCmd.Parameters.AddWithValue("@MenuDescription", MenuDesc);
            DCmd.Parameters.AddWithValue("@IsActive", IsActive);
            DCmd.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DCmd.Parameters.AddWithValue("@RetMsg", RetMsg);
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

    //  To update 'Menu' record of Specific UpdateMenu in database by stored procedure
    public int UpdateMenu(int MenuId, string MenuName,string MenuDesc,int IsActive,int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspUpdateMenu' stored procedure is used to update record in Menu table
        SqlCommand DCmd = new SqlCommand("uspUpdateMenu", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@MenuID", MenuId);
            DCmd.Parameters.AddWithValue("@MenuName", MenuName);
            DCmd.Parameters.AddWithValue("@MenuDescription", MenuDesc);
            DCmd.Parameters.AddWithValue("@IsActive", IsActive);
            DCmd.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DCmd.Parameters.AddWithValue("@RetMsg", RetMsg);
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

    //  To get 'Menu' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAllMenu(int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetMenuDetails' stored procedure is used to get both 'Active','Inactive' type records from Menu table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetMenuDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", RetMsg);
            DAdapter.Fill(DSet, "Masters.Menu");
            return DSet.Tables["Masters.Menu"];
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

    //  To select 'Menu' records specific MenuId from database by stored procedure
    public DataTable SelectMenuID(int MenuId, int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetMenuDetails' stored procedure is used to get Specific MenuId records from Menu table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetMenuDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@MenuId", MenuId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", RetMsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Menu");
            return DSet.Tables["Menu"];
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

    //  To select 'Menu' records specific MenuName from database by stored procedure
    public DataTable SelectMenuName(string MenuName, int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetMenuDetails' stored procedure is used to get Specific MenuName records from Menu table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetMenuDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@MenuName", MenuName);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", RetMsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Menu");
            return DSet.Tables["Menu"];
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

    //  To get 'Menu' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActiveMenu(bool IsActive,int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetMenuDetails' stored procedure is used to get specific records from Menu table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetMenuDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive); 
            DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", RetMsg);
            DAdapter.Fill(DSet, "Masters.Menu");
            return DSet.Tables["Masters.Menu"];
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