using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GroupRoleBAL
/// </summary>
public class GroupRoleBAL
{
    public GroupRoleBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Group Role' data in GroupRoleDAL Data Access Layer for insertion
    public int InsertGroupRole(int GroupId, int RoleId, bool IsActive, int LoginUser, string Ret)
    {

        GroupRoleDAL GroupRoleDAL = new GroupRoleDAL();
        try
        {
            return GroupRoleDAL.InsertGroupRole(GroupId, RoleId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleDAL = null;
        }
    }

    //  To pass 'Group Role' data in GroupRoleDAL Data Access Layer for updation
    public int UpdateGroupRole(int GroupRoleId, bool IsActive, int LoginUser, string Ret)
    {
        GroupRoleDAL GroupRoleDAL = new GroupRoleDAL();
        try
        {
            return GroupRoleDAL.UpdateGroupRole(GroupRoleId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleDAL = null;
        }
    }

    // To pass 'Group Role' data in GroupRoleDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadAllGroupRole(int LoggedInUser, string Ret)
    {
        GroupRoleDAL GroupRoleDAL = new GroupRoleDAL();
        try
        {
            return GroupRoleDAL.LoadGroupRoleAll(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleDAL = null;
        }
    }

    public DataTable GroupRoleLoad(int LoggedInUser, string returnmsg)
    {
        GroupRoleDAL grDAL = new GroupRoleDAL();
        try
        {
            return grDAL.GroupRoleLoad(LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            grDAL = null;
        }
    }
    // To pass 'Group Role' data in GroupRoleDAL Data Access Layer to show Active type records 
    public DataTable LoadActiveGroupRole(bool IsActive, int LoggedInUser, string Ret)
    {
        GroupRoleDAL GroupRoleDAL = new GroupRoleDAL();
        try
        {
            return GroupRoleDAL.LoadActiveGroupRole(IsActive, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleDAL = null;
        }
    }

    // To pass 'Group Role' data in GroupRoleDAL Data Access Layer to show selected GroupRoleID records
    public DataTable SelectGroupRoleID(int GroupRoleId, int LoggedInUser, string Ret)
    {
        GroupRoleDAL GroupRoleDAL = new GroupRoleDAL();
        try
        {
            return GroupRoleDAL.SelectGroupRoleID(GroupRoleId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleDAL = null;
        }
    }

    // To pass 'Group Role' data in GroupRoleDAL Data Access Layer to show selected GroupRoleID records with status
    public DataTable SelectGroupID(bool IsActive, int GroupId, int LoggedInUser, string Ret)
    {
        GroupRoleDAL GroupRoleDAL = new GroupRoleDAL();
        try
        {
            return GroupRoleDAL.SelectGroupID(IsActive, GroupId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleDAL = null;
        }
    }

    // To pass 'Group Role' data in GroupRoleDAL Data Access Layer to show selected GroupID and RoleID records
    public DataTable SelectGroupIDRoleID(int GroupId, int RoleId, int LoggedInUser, string Ret)
    {
        GroupRoleDAL GroupRoleDAL = new GroupRoleDAL();
        try
        {
            return GroupRoleDAL.SelectGroupIDRoleID(GroupId, RoleId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleDAL = null;
        }
    }

  
}