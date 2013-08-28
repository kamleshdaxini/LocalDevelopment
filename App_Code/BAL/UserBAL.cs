using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserBAL
/// </summary>
public class UserBAL
{
	public UserBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'User' data in UserDAL Data Access Layer for insertion
    public int InsertUser(string FirstName, string LastName, string EMail, string Remarks, bool IsAdmin, bool IsActive, string UserName, int LoginUser, string Ret)
    {
        UserDAL UserDAL = new UserDAL();
        try
        {
            return UserDAL.InsertUser(FirstName, LastName, EMail, Remarks, IsAdmin, IsActive, UserName, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserDAL = null;
        }
    }

    //  To pass 'User' data in UserDAL Data Access Layer for updation
    public int UpdateUser(int UserId, string FirstName, string LastName, string EMail, string Remarks, bool IsAdmin, bool IsActive, int LoginUser, string Ret)
    {
        UserDAL UserDAL = new UserDAL();
        try
        {
            return UserDAL.UpdateUser(UserId, FirstName, LastName, EMail, Remarks, IsAdmin, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserDAL = null;
        }
    }

    // To pass 'User' data in UserDAL Data Access Layer to show Active type records
    public DataTable LoadAllUser(int LoggedInUser, string Ret)
    {
        UserDAL UserDAL = new UserDAL();
        try
        {
            return UserDAL.LoadAllUser(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserDAL = null;
        }
    }

    // To pass 'User' data in UserDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadActiveUser(bool IsActive, int LoggedInUser, string Ret)
    {
        UserDAL UserDAL = new UserDAL();
        try
        {
            return UserDAL.LoadActiveUser(IsActive, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserDAL = null;
        }
    }

    // To pass 'User' data in UserDAL Data Access Layer to show selected UserId records
    public DataTable SelectUserID(int UserId, int LoggedInUser, string Ret)
    {
        UserDAL UserDAL = new UserDAL();
        try
        {
            return UserDAL.SelectUserID(UserId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserDAL = null;
        }
    }

    // To pass 'User' data in UserDAL Data Access Layer to show  all Users details
    public DataTable SelectUserdetails(string FName, string LName, bool IsActive, int LoggedInUser, string Ret)
    {
        UserDAL UserDAL = new UserDAL();
        try
        {
            return UserDAL.SelectUserdetails(FName, LName, IsActive, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserDAL = null;
        }
    }

    // To pass 'User' data in UserDAL Data Access Layer to show selected UserName records
    public DataTable SelectUserName(string UserName, int LoggedInUser, string Ret)
    {
        UserDAL UserDAL = new UserDAL();
        try
        {
            return UserDAL.SelectUserName(UserName, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserDAL = null;
        }
    }

    // To pass 'User' data in UserDAL Data Access Layer to show Email of all User
    public DataTable LoadNameEmail(int LoggedInUser, string Ret)
    {
        UserDAL UserDAL = new UserDAL();
        try
        {
            return UserDAL.LoadNameEmail(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserDAL = null;
        }
    }

    // To pass 'User' data in UserDAL Data Access Layer to show Users permission wise
    public DataTable LoadUserPermission(int UserId,bool IsActive,int LoggedInUser, string Ret)
    {
        UserDAL UserDAL = new UserDAL();
        try
        {
            return UserDAL.LoadUserPermission(UserId, IsActive, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserDAL = null;
        }
    }

}