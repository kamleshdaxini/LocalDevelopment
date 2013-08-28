using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ContentDeveloperBALcs
/// </summary>
public class ContentDeveloperBAL
{
    public ContentDeveloperBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Content Developer' data in ContentDeveloperDAL Data Access Layer for insertion
    public int InsertContentDeveloper(int UserID, bool Isactive, int LoginUser, string Ret)
    {

        ContentDeveloperDAL ContentDeveloperDAL = new ContentDeveloperDAL();
        try
        {
            return ContentDeveloperDAL.InsertContentDeveloper(UserID, Isactive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentDeveloperDAL = null;
        }
    }

    // To pass 'Content Developer' data in ContentDeveloperDAL Data Access Layer for updation
    public int UpdateContentDeveloper(int ContentDeveloperId, bool IsActive, int LoginUser, string Ret)
    {
        ContentDeveloperDAL ContentDeveloperDAL = new ContentDeveloperDAL();
        try
        {
            return ContentDeveloperDAL.UpdateContentDeveloper(ContentDeveloperId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentDeveloperDAL = null;
        }
    }

    // To pass 'Content Developer' data in ContentDeveloperDAL Data Access Layer to show Active type records
    public DataTable LoadActiveContentDeveloper(int LoggedInUser, string Ret, bool IsActive)
    {
        ContentDeveloperDAL ContentDeveloperDAL = new ContentDeveloperDAL();
        try
        {
            return ContentDeveloperDAL.LoadActiveContentDeveloper(LoggedInUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentDeveloperDAL = null;
        }
    }

    // To pass 'Content Developer' data in ContentDeveloperDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadAllContentDeveloper(int LoggedInUser, string Ret)
    {
        ContentDeveloperDAL ContentDeveloperDAL = new ContentDeveloperDAL();
        try
        {
            return ContentDeveloperDAL.LoadContentDeveloperAll(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentDeveloperDAL = null;
        }
    }

    // To pass 'Content Developer' data in ContentDeveloperDAL Data Access Layer to show selected ContentDeveloperID records
    public DataTable SelectContentDeveloperID(int ContentDeveloperId, int LoggedInUser, string Ret)
    {
        ContentDeveloperDAL ContentDeveloperDAL = new ContentDeveloperDAL();
        try
        {
            return ContentDeveloperDAL.SelectContentDeveloperID(ContentDeveloperId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentDeveloperDAL = null;
        }
    }
}