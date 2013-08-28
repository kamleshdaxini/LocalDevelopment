using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for SubMenuDAL
/// </summary>
public class SubMenuDAL
{
    string ConnString = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public SubMenuDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To insert 'SubMenu' record in database by stored procedure
    public int InsertSubMenu(int MenuId, string SubMenuName, string SubMenuDesc, string SubMenuURL,int IsActive,int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnString);
        Conn.Open();
        //  'uspInsertSubMenu' stored procedure is used to insert record in SubMenu table
        SqlCommand Cmd = new SqlCommand("uspInsertSubMenu", Conn);
        Cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            Cmd.Parameters.AddWithValue("@MenuID", MenuId);
            Cmd.Parameters.AddWithValue("@SubMenuName", SubMenuName);
            Cmd.Parameters.AddWithValue("@SubMenuDescription", SubMenuDesc);
            Cmd.Parameters.AddWithValue("@SubMenuURL", SubMenuURL);
            Cmd.Parameters.AddWithValue("@IsActive", IsActive);
            Cmd.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            Cmd.Parameters.AddWithValue("@RetMsg", RetMsg);
            return Cmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            Cmd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To update 'SubMenu' record of Specific UpdateSubMenu in database by stored procedure
    public int UpdateSubMenu(int SubMenuId, string SubMenuName, string SubMenuDesc,string SubMenuURL, int IsActive, int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnString);
        Conn.Open();
        //  'uspUpdateSubMenu' stored procedure is used to update record in SubMenu table
        SqlCommand Cmd = new SqlCommand("uspUpdateSubMenu", Conn);
        Cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            Cmd.Parameters.AddWithValue("@SubMenuId", SubMenuId);
            Cmd.Parameters.AddWithValue("@SubMenuName", SubMenuName);
            Cmd.Parameters.AddWithValue("@SubMenuDescription", SubMenuDesc);
            Cmd.Parameters.AddWithValue("@SubMenuURL", SubMenuURL);
            Cmd.Parameters.AddWithValue("@IsActive", IsActive);
            Cmd.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            Cmd.Parameters.AddWithValue("@RetMsg", RetMsg);
            return Cmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            Cmd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To get 'SubMenu' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAllSubMenu(int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnString);
        //  'uspGetSubMenuDetails' stored procedure is used to get both 'Active','Inactive' type records from SubMenu table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetSubMenuDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", RetMsg);
            DAdapter.Fill(DSet, "Masters.SubMenu");
            return DSet.Tables["Masters.SubMenu"];
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

    //  To select 'SubMenu' records specific SubMenuId from database by stored procedure
    public DataTable SelectSubMenuID(int SubMenuId, int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnString);
        //  'uspGetSubMenuDetails' stored procedure is used to get Specific SubMenuId records from SubMenu table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetSubMenuDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@SubMenuId", SubMenuId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", RetMsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "SubMenu");
            return DSet.Tables["SubMenu"];
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

    //  To select 'SubMenu' records specific MenuId from database by stored procedure
    public DataTable SelectMenuID(int MenuId, int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnString);
        //  'uspGetSubMenuDetails' stored procedure is used to get Specific MenuId records from SubMenu table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetSubMenuDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@MenuId", MenuId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", RetMsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "SubMenu");
            return DSet.Tables["SubMenu"];
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

    //  To get 'SubMenu' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActiveSubMenu(bool IsActive,int LoggedInUser, string RetMsg)
    {
        SqlConnection Conn = new SqlConnection(ConnString);
        //  'uspGetSubMenuDetails' stored procedure is used to get specific records from SubMenu table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetSubMenuDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
            DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", RetMsg);
            DAdapter.Fill(DSet, "Masters.SubMenu");
            return DSet.Tables["Masters.SubMenu"];
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