using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TargetAudienceBAL
/// </summary>
public class TargetAudienceBAL
{
    public TargetAudienceBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Target Audience' data in TargetAudienceDAL Data Access Layer to show Active,Inactive type records 
    public DataTable LoadTargetAudience(int LoggedInUser, string returnmsg)
    {
        TargetAudienceDAL TargetAudienceDAL = new TargetAudienceDAL();
        try
        {
            return TargetAudienceDAL.LoadTargetAudience(LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            TargetAudienceDAL = null;
        }
    }

}