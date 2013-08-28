using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ReviewerTypeBAL
/// </summary>
public class ReviewerTypeBAL
{
	public ReviewerTypeBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'ReviewerType' data in ReviewerTypeDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadReviewerType(int LoggedInUser, string Ret)
    {
        ReviewerTypeDAL ReviewerTypeDAL = new ReviewerTypeDAL();
        try
        {
            return ReviewerTypeDAL.LoadReviewerType(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ReviewerTypeDAL = null;
        }
    }

}