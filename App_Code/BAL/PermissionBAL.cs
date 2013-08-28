using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PermissionBAL
/// </summary>
public class PermissionBAL
{
	public PermissionBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Permission' data in PermissionDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadPermission(int LoggedInUser, string RetMsg)
    {
        PermissionDAL PermissionDAL = new PermissionDAL();
        try
        {
            return PermissionDAL.LoadPermission(LoggedInUser, RetMsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            PermissionDAL = null;
        }
    }

}