using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TrainingImpactOnBAL
/// </summary>
public class TrainingImpactOnBAL
{
	public TrainingImpactOnBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Training Impact On' data in TrainingImpactOnDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadTrainingImpactOn(int LoggedInUser, string Ret)
    {
        TrainingImpactOnDAL TrainingImpactOnDAL = new TrainingImpactOnDAL();
        try
        {
            return TrainingImpactOnDAL.LoadTrainingImpactOn(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            TrainingImpactOnDAL = null;
        }
    }

}