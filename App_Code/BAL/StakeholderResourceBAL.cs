using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for StakeholderResourceBAL
/// </summary>
public class StakeholderResourceBAL
{
	public StakeholderResourceBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Stakeholder Resource' data in StakeholderResourceDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadStakeholderResource(int LoggedInUser, string Ret)
    {
        StakeholderResourceDAL StakeholderResourceDAL = new StakeholderResourceDAL();
        try
        {
            return StakeholderResourceDAL.LoadStakeholderResource(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderResourceDAL = null;
        }
    }
}