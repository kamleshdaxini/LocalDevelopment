using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for StakeHolderBAL
/// </summary>
public class StakeHolderBAL
{
	public StakeHolderBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Stakeholder' data in StakeholderDAL Data Access Layer for insertion
    public int InsertStakeholder(int UserID, bool Isactive, int LoginUser, string Ret)
    {
        StakeholderDAL StakeholderDAL = new StakeholderDAL();
        try
        {
            return StakeholderDAL.InsertStakeholder(UserID, Isactive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderDAL = null;
        }
    }

    //  To pass 'Stakeholder' data in StakeholderDAL Data Access Layer for updation
    public int UpdateStakeholder(int StakeholderId, bool IsActive, int LoginUser, string Ret)
    {
        StakeholderDAL StakeholderDAL = new StakeholderDAL();
        try
        {
            return StakeholderDAL.UpdateStakeholder(StakeholderId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderDAL = null;
        }
    }

    // To pass 'Stakeholder' data in StakeholderDAL Data Access Layer to show Active type records
    public DataTable LoadActiveStakeholder(int LoggedInUser, string Ret, bool IsActive)
    {
        StakeholderDAL StakeholderDAL = new StakeholderDAL();
        try
        {
            return StakeholderDAL.LoadActiveStakeholder(LoggedInUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderDAL = null;
        }
    }

    // To pass 'Stakeholder' data in StakeholderDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadAllStakeholder(int LoggedInUser, string Ret)
    {
        StakeholderDAL StakeholderDAL = new StakeholderDAL();
        try
        {
            return StakeholderDAL.LoadAllStakeholder(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderDAL = null;
        }
    }

    // To pass 'Stakeholder' data in StakeholderDAL Data Access Layer to show selected StakeholderID records
    public DataTable SelectStakeholderID(int StakeholderId, int LoggedInUser, string Ret)
    {
        StakeholderDAL StakeholderDAL = new StakeholderDAL();
        try
        {
            return StakeholderDAL.SelectStakeholderID(StakeholderId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderDAL = null;
        }
    }
}