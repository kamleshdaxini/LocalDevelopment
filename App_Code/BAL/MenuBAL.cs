using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for MenuBAL
/// </summary>
public class MenuBAL
{
	public MenuBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Menu' data in MenuDAL Data Access Layer for insertion
    public int InsertMenu(string MenuName,string MenuDesc,int IsActive,int LoggedInUser, string RetMsg)
    {
        MenuDAL MenuDAL = new MenuDAL();
        try
        {
            return MenuDAL.InsertMenu(MenuName, MenuDesc, IsActive, LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            MenuDAL = null;
        }
    }

    // To pass 'Menu' data in MenuDAL Data Access Layer for updation
    public int UpdateMenu(int MenuId, string MenuName,string MenuDesc,int IsActive, int LoggedInUser, string RetMsg)
    {
        MenuDAL MenuDAL = new MenuDAL();
        try
        {
            return MenuDAL.UpdateMenu(MenuId, MenuName, MenuDesc, IsActive, LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            MenuDAL = null;
        }
    }

    // To pass 'Menu' data in MenuDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadAllMenu(int LoggedInUser, string RetMsg)
    {
        MenuDAL MenuDAL = new MenuDAL();
        try
        {
            return MenuDAL.LoadAllMenu(LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            MenuDAL = null;
        }
    }

    // To pass 'Menu' data in MenuDAL Data Access Layer to show selected MenuId records
    public DataTable SelectMenuID(int MenuId, int LoggedInUser, string RetMsg)
    {
        MenuDAL MenuDAL = new MenuDAL();
        try
        {
            return MenuDAL.SelectMenuID(MenuId, LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            MenuDAL = null;
        }
    }

    // To pass 'Menu' data in MenuDAL Data Access Layer to show selected MenuName records
    public DataTable SelectMenuName(string MenuName, int LoggedInUser, string RetMsg)
    {
        MenuDAL MenuDAL = new MenuDAL();
        try
        {
            return MenuDAL.SelectMenuName(MenuName, LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            MenuDAL = null;
        }
    }

    // To pass 'Menu' data in MenuDAL Data Access Layer to show Active type records
    public DataTable LoadActiveMenu(bool IsActive, int LoggedInUser, string RetMsg)
    {
        MenuDAL MenuDAL = new MenuDAL();
        try
        {
            return MenuDAL.LoadActiveMenu(IsActive, LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            MenuDAL = null;
        }
    }
}