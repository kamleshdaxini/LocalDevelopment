using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GroupRolePermissionBAL
/// </summary>
public class GroupRolePermissionBAL
{
    public GroupRolePermissionBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Group Role Permission' data in GroupRolePermissionDAL Data Access Layer for insertion
    public int InsertGroupRolePermission(int GroupRoleId, int SubMenuId, int PermissionId, bool IsActive, int LoginUser, string Ret)
    {

        GroupRolePermissionDAL GroupRolePermissionDAL = new GroupRolePermissionDAL();
        try
        {
            return GroupRolePermissionDAL.InsertGroupRolePermission(GroupRoleId, SubMenuId, PermissionId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRolePermissionDAL = null;
        }
    }

    //  To pass 'Group Role Permission' data in GroupRolePermissionDAL Data Access Layer for updation
    public int UpdateGroupRolePermission(int GroupRolePermissionId, int PermissionId, bool IsActive, int LoginUser, string Ret)
    {
        GroupRolePermissionDAL GroupRolePermissionDAL = new GroupRolePermissionDAL();
        try
        {
            return GroupRolePermissionDAL.UpdateGroupRolePermission(GroupRolePermissionId, PermissionId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRolePermissionDAL = null;
        }
    }

    //  To pass 'Group Role Permission' data in GroupRolePermissionDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadAllGroupRolePermission(int LoggedInUser, string returnmsg)
    {
        GroupRolePermissionDAL GroupRolePermissionDAL = new GroupRolePermissionDAL();
        try
        {
            return GroupRolePermissionDAL.LoadAllGroupRolePermission(LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRolePermissionDAL = null;
        }
    }

    //  To pass 'Group Role Permission' data in GroupRolePermissionDAL Data Access Layer to show Active or Inactive type records
    public DataTable LoadActiveGroupRolePermission(bool IsActive, int LoggedInUser, string Ret)
    {
        GroupRolePermissionDAL GroupRolePermissionDAL = new GroupRolePermissionDAL();
        try
        {
            return GroupRolePermissionDAL.LoadActiveGroupRolePermission(IsActive, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRolePermissionDAL = null;
        }
    }

    // To pass 'Group Role Permission' data in GroupRolePermissionDAL Data Access Layer to show selected GroupRoleID records
    public DataTable SelectGroupRolePermissionID(int GroupRoleId, int LoggedInUser, string Ret)
    {
        GroupRolePermissionDAL GroupRolePermissionDAL = new GroupRolePermissionDAL();
        try
        {
            return GroupRolePermissionDAL.SelectGroupRolePermissionID(GroupRoleId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRolePermissionDAL = null;
        }
    }

    // To pass 'Group Role Permission' data in GroupRolePermissionDAL Data Access Layer to show selected GroupID records
    public DataTable SelectGroupID(int GroupId, int LoggedInUser, string Ret)
    {
        GroupRolePermissionDAL GroupRolePermissionDAL = new GroupRolePermissionDAL();
        try
        {
            return GroupRolePermissionDAL.SelectGroupID(GroupId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRolePermissionDAL = null;
        }
    }
  
}