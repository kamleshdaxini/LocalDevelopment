using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
 
/// <summary>
/// Summary description for PortfolioManagerBAL
/// </summary>
public class PortfolioManagerBAL
{
    public PortfolioManagerBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Portfolio Manager' data in PortfolioManagerDAL Data Access Layer for insertion
    public int InsertPortfolioManager(int UserID, bool Isactive, int LoginUser, string Ret)
    {
        PortfolioManagerDAL PortfolioManagerDAL = new PortfolioManagerDAL();
        try
        {
            return PortfolioManagerDAL.InsertPortfolioManager(UserID, Isactive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            PortfolioManagerDAL = null;
        }
    }

    // To pass 'Portfolio Manager' data in PortfolioManagerDAL Data Access Layer for updation
    public int UpdatePortfolioManager(int PortfolioManagerId, bool IsActive, int LoginUser, string Ret)
    {
        PortfolioManagerDAL PortfolioManagerDAL = new PortfolioManagerDAL();
        try
        {
            return PortfolioManagerDAL.UpdatePortfolioManager(PortfolioManagerId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            PortfolioManagerDAL = null;
        }
    }

    // To pass 'Portfolio Manager' data in PortfolioManagerDAL Data Access Layer to show Active type records
    public DataTable LoadActivePortfolioManager(int LoggedInUser, string Ret, bool IsActive)
    {
        PortfolioManagerDAL PortfolioManagerDAL = new PortfolioManagerDAL();
        try
        {
            return PortfolioManagerDAL.LoadActivePortfolioManager(LoggedInUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            PortfolioManagerDAL = null;
        }
    }

    // To pass 'Portfolio Manager' data in PortfolioManagerDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadAllPortfolioManager(int LoggedInUser, string Ret)
    {
        PortfolioManagerDAL PortfolioManagerDAL = new PortfolioManagerDAL();
        try
        {
            return PortfolioManagerDAL.LoadAllPortfolioManager(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            PortfolioManagerDAL = null;
        }
    }

    // To pass 'Portfolio Manager' data in PortfolioManagerDAL Data Access Layer to show selected PortfolioManagerID records
    public DataTable SelectPortfolioManagerID(int PortfolioManagerId, int LoggedInUser, string Ret)
    {
        PortfolioManagerDAL PortfolioManagerDAL = new PortfolioManagerDAL();
        try
        {
            return PortfolioManagerDAL.SelectPortfolioManagerID(PortfolioManagerId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            PortfolioManagerDAL = null;
        }
    }
}