using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ContentLeadBAL
/// </summary>
public class ContentLeadBAL
{
    public ContentLeadBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Content Lead' data in ContentDeveloperDAL Data Access Layer for insertion
    public int InsertContentLead(int UserID, bool IsActive, int LoginUser, string Ret)
    {
        ContentLeadDAL ContentLeadDAL = new ContentLeadDAL();
        try
        {
            return ContentLeadDAL.InsertContentLead(UserID, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentLeadDAL = null;
        }
    }

    // To pass 'Content Lead' data in ContentLeadDAL Data Access Layer for updation
    public int UpdateContentLead(int ContentLeadId, bool IsActive, int LoginUser, string Ret)
    {
        ContentLeadDAL ContentLeadDAL = new ContentLeadDAL();
        try
        {
            return ContentLeadDAL.UpdateContentLead(ContentLeadId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentLeadDAL = null;
        }
    }

    // To pass 'Content Lead' data in ContentLeadDAL Data Access Layer to show Active type records
    public DataTable LoadActiveContentLead(int LoggedInUser, string returnmsg, bool IsActive)
    {
        ContentLeadDAL ContentLeadDAL = new ContentLeadDAL();
        try
        {
            return ContentLeadDAL.LoadActiveContentLead(LoggedInUser, returnmsg,IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentLeadDAL = null;
        }
    }

    // To pass 'Content Lead' data in ContentLeadDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadContentLeadAll(int LoggedInUser, string returnmsg)
    {
        ContentLeadDAL ContentLeadDAL = new ContentLeadDAL();
        try
        {
            return ContentLeadDAL.LoadContentLeadAll(LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentLeadDAL = null;
        }
    }

    // To pass 'Content Lead' data in ContentLeadDAL Data Access Layer to show selected ContentDeveloperID records
    public DataTable SelectContentLeadId(int ContentLeadId, int LoggedInUser, string returnmsg)
    {
        ContentLeadDAL ContentLeadDAL = new ContentLeadDAL();
        try
        {
            return ContentLeadDAL.SelectContentLeadId(ContentLeadId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentLeadDAL = null;
        }
    }
}