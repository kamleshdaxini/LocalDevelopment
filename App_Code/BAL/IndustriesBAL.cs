using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for IndustriesBAL
/// </summary>
public class IndustriesBAL
{
    public IndustriesBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Industries' data in IndustriesDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadIndustries(int LoggedInUser, string returnmsg)
    {
        IndustriesDAL IndustriesDAL = new IndustriesDAL();
        try
        {
            return IndustriesDAL.LoadIndustries(LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IndustriesDAL = null;
        }
    }
}