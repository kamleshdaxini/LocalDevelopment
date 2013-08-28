using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for WS1PhaseBAL
/// </summary>
public class WS1PhaseBAL
{
	public WS1PhaseBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'WS1 Phase' data in WS1PhaseDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadWS1Phase(int LoggedInUser, string Ret)
    {
        WS1PhaseDAL WS1PhaseDAL = new WS1PhaseDAL();
        try
        {
            return WS1PhaseDAL.LoadWS1Phase(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            WS1PhaseDAL = null;
        }
    }
}