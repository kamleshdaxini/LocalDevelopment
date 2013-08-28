using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AnalyzeSolutionBAL
/// </summary>
public class AnalyzeSolutionBAL
{
    public AnalyzeSolutionBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Analyze Solution' data in AnalyzeSolutionDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadAnalyzeSolution(int LoggedInUser, string Ret)
    {
        AnalyzeSolutionDAL AnalyzeSolutionDAL = new AnalyzeSolutionDAL();
        try
        {
            return AnalyzeSolutionDAL.LoadAnalyzeSolution(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            AnalyzeSolutionDAL = null;
        }
    }

   
}