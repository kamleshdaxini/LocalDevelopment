using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserGroupRoleBAL
/// </summary>
public class UserGroupRoleBAL
{
	public UserGroupRoleBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'User Group Role' data in UserGroupRoleDAL Data Access Layer for insertion
    public int InsertUserGroupRole(int UserID, int GroupRoleID, int IsActive, int LoginUser, string Ret)
    {
        UserGroupRoleDAL UserGroupRoleDAL = new UserGroupRoleDAL();
        try
        {
            return UserGroupRoleDAL.InsertUserGroupRole(UserID, GroupRoleID, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserGroupRoleDAL = null;
        }
    }

    //  To pass 'User Group Role' data in UserGroupRoleDAL Data Access Layer for updation
    public int UpdateUserGroupRole(int UserGroupRoleID, int IsActive, int LoginUser, string Ret)
    {
        UserGroupRoleDAL UserGroupRoleDAL = new UserGroupRoleDAL();
        try
        {
            return UserGroupRoleDAL.UpdateUserGroupRole(UserGroupRoleID, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserGroupRoleDAL = null;
        }
    }

    // To pass 'User Group Role' data in UserGroupRoleDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadAllUserGroupRole(int LoggedInUser, string Ret)
    {
        UserGroupRoleDAL UserGroupRoleDAL = new UserGroupRoleDAL();
        try
        {
            return UserGroupRoleDAL.LoadAllUserGroupRole(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserGroupRoleDAL = null;
        }
    }

    // To pass 'User Group Role' data in UserGroupRoleDAL Data Access Layer to show selected UserID records
    public DataTable SelectUserID(int UserID, int LoggedInUser, string Ret)
    {
        UserGroupRoleDAL UserGroupRoleDAL = new UserGroupRoleDAL();
        try
        {
            return UserGroupRoleDAL.SelectUserID(UserID, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserGroupRoleDAL = null;
        }
    }

    // To pass 'User Group Role' data in UserGroupRoleDAL Data Access Layer to show selected GroupRoleID records
    public DataTable SelectGroupRoleID(int GroupRoleID, int LoggedInUser, string Ret)
    {
        UserGroupRoleDAL UserGroupRoleDAL = new UserGroupRoleDAL();
        try
        {
            return UserGroupRoleDAL.SelectGroupRoleID(GroupRoleID, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserGroupRoleDAL = null;
        }
    }

    //  To pass 'User Group Role' data in UserGroupRoleDAL Data Access Layer for new insertion 
    public int InsertNewUserGroupRole(int UserID, int GroupRoleID, int IsActive, int LoginUser)
    {


        UserGroupRoleDAL UserGroupRoleDAL = new UserGroupRoleDAL();
        try
        {
            return UserGroupRoleDAL.InsertNewUserGroupRole(UserID, GroupRoleID, IsActive, LoginUser);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserGroupRoleDAL = null;
        }
    }

    // To pass 'User Group Role' data in UserGroupRoleDAL Data Access Layer to show selected UserID & GroupRoleID records
    public DataTable SelectUserGroupID(int UserID, int GroupRoleID, int LoggedInUser, string Ret)
    {
        UserGroupRoleDAL UserGroupRoleDAL = new UserGroupRoleDAL();
        try
        {
            return UserGroupRoleDAL.SelectUserGroupID(UserID, GroupRoleID, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserGroupRoleDAL = null;
        }
    }
}