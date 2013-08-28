using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for StakeholderRelationshipManagerBAL
/// </summary>
public class StakeholderRelationshipManagerBAL
{
	public StakeholderRelationshipManagerBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Stakeholder Relationship Manager' data in StakeholderRelationshipManagerDAL Data Access Layer for insertion
    public int InsertStakeholderRelationshipManager(int UserID, bool IsActive, int LoginUser, string Ret)
    {

        StakeholderRelationshipManagerDAL StakeholderRelationshipManagerDAL = new StakeholderRelationshipManagerDAL();
        try
        {
            return StakeholderRelationshipManagerDAL.InsertStakeholderRelationshipManager(UserID, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderRelationshipManagerDAL = null;
        }
    }

    //  To pass 'Stakeholder Relationship Manager' data in StakeholderRelationshipManagerDAL Data Access Layer for updation
    public int UpdateStakeholderRelationshipManager(int StakeholderRelationshipManagerId, bool IsActive, int LoginUser, string Ret)
    {
        StakeholderRelationshipManagerDAL StakeholderRelationshipManagerDAL = new StakeholderRelationshipManagerDAL();
        try
        {
            return StakeholderRelationshipManagerDAL.UpdateStakeholderRelationshipManager(StakeholderRelationshipManagerId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderRelationshipManagerDAL = null;
        }
    }

    // To pass 'Stakeholder Relationship Manager' data in StakeholderRelationshipManagerDAL Data Access Layer to show Active type records
    public DataTable LoadActiveStakeholderRelationshipManager(int LoggedInUser, string returnmsg, bool IsActive)
    {
        StakeholderRelationshipManagerDAL StakeholderRelationshipManagerDAL = new StakeholderRelationshipManagerDAL();
        try
        {
            return StakeholderRelationshipManagerDAL.LoadActiveStakeholderRelationshipManager(LoggedInUser, returnmsg, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderRelationshipManagerDAL = null;
        }
    }

    // To pass 'Stakeholder Relationship Manager' data in StakeholderRelationshipManagerDAL Data Access Layer to show Active and Inactive type records
    public DataTable SelectStakeholderRelationshipManagerID(int StakeholderRelationshipManagerID, int LoggedInUser, string Ret)
    {
        StakeholderRelationshipManagerDAL StakeholderRelationshipManagerDAL = new StakeholderRelationshipManagerDAL();
        try
        {
            return StakeholderRelationshipManagerDAL.SelectStakeholderRelationshipManagerID(StakeholderRelationshipManagerID, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderRelationshipManagerDAL = null;
        }
    }

    // To pass 'Stakeholder Relationship Manager' data in StakeholderRelationshipManagerDAL Data Access Layer to show selected StakeholderRelationshipManagerID records
    public DataTable LoadAllStakeholderRelationshipManager(int LoggedInUser, string Ret)
    {
        StakeholderRelationshipManagerDAL StakeholderRelationshipManagerDAL = new StakeholderRelationshipManagerDAL();
        try
        {
            return StakeholderRelationshipManagerDAL.LoadAllStakeholderRelationshipManager(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderRelationshipManagerDAL = null;
        }
    }
}