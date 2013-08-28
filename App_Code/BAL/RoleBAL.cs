using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RoleBAL
/// </summary>
public class RoleBAL
{
    public RoleBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Role' data in RoleDAL Data Access Layer for insertion
    public int InsertRole(string RoleName, string RoleDescription, bool IsActive, int LoginUser, string Ret)
    {
        RoleDAL rDAL = new RoleDAL();
        try
        {
            return rDAL.InsertRole(RoleName, RoleDescription, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            rDAL = null;
        }
    }

    // To pass 'Role' data in RoleDAL Data Access Layer for updation
    public int UpdateRole(int RoleId, string RoleName, string RoleDescription, bool IsActive, int LoginUser, string Ret)
    {
        RoleDAL rDAL = new RoleDAL();
        try
        {
            return rDAL.UpdateRole(RoleId, RoleName, RoleDescription, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            rDAL = null;
        }
    }

    // To pass 'Role' data in RoleDAL Data Access Layer to show Active type records
    public DataTable LoadAllRole(int LoggedInUser, string returnmsg)
    {
        RoleDAL rDAL = new RoleDAL();
        try
        {
            return rDAL.LoadAllRole(LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            rDAL = null;
        }
    }

    // To pass 'Role' data in RoleDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadActiveRole(bool IsActive, int LoggedInUser, string Ret)
    {
        RoleDAL rDAL = new RoleDAL();
        try
        {
            return rDAL.LoadActiveRole(IsActive, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            rDAL = null;
        }
    }

    // To pass 'Role' data in RoleDAL Data Access Layer to show selected RoleId record
    public DataTable SelectRoleID(int RoleId, int LoggedInUser, string Ret)
    {
        RoleDAL rDAL = new RoleDAL();
        try
        {
            return rDAL.SelectRoleID(RoleId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            rDAL = null;
        }
    }

    // To pass 'Role' data in RoleDAL Data Access Layer to show Change Status of selected RoleId record
    public int ChangeRoleStatus(int RoleId, int LoggedInUser, string Ret, bool IsActive)
    {
        RoleDAL rDAL = new RoleDAL();
        try
        {
            return rDAL.ChangeRoleStatus(RoleId, LoggedInUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            rDAL = null;
        }
    }
}