using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SpecialitiesBAL
/// </summary>
public class SpecialitiesBAL
{
	public SpecialitiesBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Specialities' data in SpecialitiesDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadSpecialities(int LoggedInUser, string Ret)
    {
        SpecialitiesDAL SpecialitiesDAL = new SpecialitiesDAL();
        try
        {
            return SpecialitiesDAL.LoadSpecialities(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            SpecialitiesDAL = null;
        }
    }
}