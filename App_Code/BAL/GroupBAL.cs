using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GroupBAL
/// </summary>
public class GroupBAL
{
	public GroupBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Group' data in GroupDAL Data Access Layer for insertion
    public int InsertGroup(string GroupName ,string GroupDescription,bool Isactive,int LoginUser, string Ret)
    {
     
        GroupDAL GroupDAL = new GroupDAL();
        try
        {
            return GroupDAL.InsertGroup(GroupName,GroupDescription, Isactive, LoginUser,Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupDAL = null;
        }
    }

    // To pass 'Group' data in GroupDAL Data Access Layer for updation
    public int UpdateGroup(int GroupId,string GroupDescription, bool IsActive, string GroupName, int LoginUser, string Ret)
    {
        GroupDAL GroupDAL = new GroupDAL();
        try
        {
            return GroupDAL.UpdateGroup(GroupId, GroupDescription,IsActive, GroupName, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        { 
            GroupDAL = null;
        }
    }

    // To pass 'Group' data in GroupDAL Data Access Layer to show Active type records
    public DataTable LoadAllGroup(int LoggedInUser,string returnmsg)
    {
        GroupDAL GroupDAL = new GroupDAL();
        try
        {
            return GroupDAL.LoadAllGroup(LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupDAL = null;
        }
    }

    // To pass 'Group' data in GroupDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadActiveGroup(bool IsActive,int LoggedInUser, string returnmsg)
    {
        GroupDAL GroupDAL = new GroupDAL();
        try
        {
            return GroupDAL.LoadActiveGroup(IsActive, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupDAL = null;
        }
    }

    // To pass 'Group' data in GroupDAL Data Access Layer to show selected GroupId record
    public DataTable SelectGroupID(int GroupId,int LoggedInUser, string returnmsg)
    {
        GroupDAL GroupDAL = new GroupDAL();
        try
        {
            return GroupDAL.SelectGroupID(GroupId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupDAL = null;
        }
    }

    // To pass 'Group' data in GroupDAL Data Access Layer to show Change Status of selected GroupId record
    public int ChangeGroupStatus(int GroupId, int LoggedInUser, string returnmsg, bool IsActive)
    {
        GroupDAL GroupDAL = new GroupDAL();
        try
        {
            return GroupDAL.ChangeGroupStatus(GroupId, LoggedInUser, returnmsg, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupDAL = null;
        }
    }
}