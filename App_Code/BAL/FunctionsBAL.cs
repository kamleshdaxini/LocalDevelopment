using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for FunctionsBAL
/// </summary>
public class FunctionsBAL
{
	public FunctionsBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Functions' data in FunctionsDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadFunctions(int LoggedInUser, string Ret)
    {
        FunctionsDAL FunctionsDAL = new FunctionsDAL();
        try
        {
            return FunctionsDAL.LoadFunctions(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            FunctionsDAL = null;
        }
    }
}