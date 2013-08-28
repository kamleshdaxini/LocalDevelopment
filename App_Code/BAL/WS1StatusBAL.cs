using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for WS1StatusBAL
/// </summary>
public class WS1StatusBAL
{
	public WS1StatusBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'WS1 Status' data in WS1StatusDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadWS1Status(int LoggedInUser, string Ret)
    {
        WS1StatusDAL WS1StatusDAL = new WS1StatusDAL();
        try
        {
            return WS1StatusDAL.LoadWS1Status(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            WS1StatusDAL = null;
        }
    }
}