using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SubMenuBAL
/// </summary>
public class SubMenuBAL
{
	public SubMenuBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'SubMenu' data in VendorDAL Data Access Layer for insertion
    public int InsertSubMenu(int MenuId,string SubMenuName,string SubMenuDesc,string SubMenuURl,int IsActive,int LoggedInUser, string RetMsg)
    {
        SubMenuDAL SubMenuDAL = new SubMenuDAL();
        try
        {
            return SubMenuDAL.InsertSubMenu(MenuId, SubMenuName, SubMenuDesc, SubMenuURl, IsActive, LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            SubMenuDAL = null;
        }
    }

    //  To pass 'SubMenu' data in VendorDAL Data Access Layer for updation
    public int UpdateSubMenu(int SubMenuId, string SubMenuName, string SubMenuDesc,string SubMenuURl,int IsActive, int LoggedInUser, string RetMsg)
    {
        SubMenuDAL SubMenuDAL = new SubMenuDAL();
        try
        {
            return SubMenuDAL.UpdateSubMenu(SubMenuId, SubMenuName, SubMenuDesc, SubMenuURl, IsActive, LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            SubMenuDAL = null;
        }
    }

    // To pass 'SubMenu' data in SubMenuDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadAllSubMenu(int LoggedInUser, string RetMsg)
    {
        SubMenuDAL SubMenuDAL = new SubMenuDAL();
        try
        {
            return SubMenuDAL.LoadAllSubMenu(LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            SubMenuDAL = null;
        }
    }

    // To pass 'SubMenu' data in SubMenuDAL Data Access Layer to show selected SubMenuID records
    public DataTable SelectSubMenuID(int SubMenuId, int LoggedInUser, string RetMsg)
    {
        SubMenuDAL SubMenuDAL = new SubMenuDAL();
        try
        {
            return SubMenuDAL.SelectSubMenuID(SubMenuId, LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            SubMenuDAL = null;
        }
    }

    // To pass 'SubMenu' data in SubMenuDAL Data Access Layer to show selected MenuId records
    public DataTable SelectMenuID(int MenuId, int LoggedInUser, string RetMsg)
    {
        SubMenuDAL SubMenuDAL = new SubMenuDAL();
        try
        {
            return SubMenuDAL.SelectMenuID(MenuId, LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            SubMenuDAL = null;
        }
    }

    // To pass 'SubMenu' data in SubMenuDAL Data Access Layer to show Active type records
    public DataTable LoadActiveSubMenu(bool IsActive,int LoggedInUser, string RetMsg)
    {
        SubMenuDAL SubMenuDAL = new SubMenuDAL();
        try
        {
            return SubMenuDAL.LoadActiveSubMenu(IsActive, LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            SubMenuDAL = null;
        }
    }
}