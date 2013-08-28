using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ProgramLeadBAL
/// </summary>
public class ProgramLeadBAL
{
    public ProgramLeadBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Program Lead' data in ProgramLeadDAL Data Access Layer for insertion
    public int InsertProgramLead(int UserID, bool IsActive, int LoginUser, string Ret)
    {
        ProgramLeadDAL ProgramLeadDAL = new ProgramLeadDAL();
        try
        {
            return ProgramLeadDAL.InsertProgramLead(UserID, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ProgramLeadDAL = null;
        }
    }

    // To pass 'Program Lead' data in ProgramLeadDAL Data Access Layer for updation
    public int UpdateProgramLead(int ProgramLeadId, bool IsActive, int LoginUser, string Ret)
    {
        ProgramLeadDAL ProgramLeadDAL = new ProgramLeadDAL();
        try
        {
            return ProgramLeadDAL.UpdateProgramLead(ProgramLeadId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ProgramLeadDAL = null;
        }
    }

    // To pass 'Program Lead' data in ProgramLeadDAL Data Access Layer to show Active type records
    public DataTable LoadActiveProgramLead(int LoggedInUser, string Ret, bool IsActive)
    {
        ProgramLeadDAL ProgramLeadDAL = new ProgramLeadDAL();
        try
        {
            return ProgramLeadDAL.LoadActiveProgramLead(LoggedInUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            ProgramLeadDAL = null;
        }
    }

    // To pass 'Program Lead' data in ProgramLeadDAL Data Access Layer to show Active and Inactive type records
    public DataTable LoadAllProgramLead(int LoggedInUser, string Ret)
    {
        ProgramLeadDAL ProgramLeadDAL = new ProgramLeadDAL();
        try
        {
            return ProgramLeadDAL.LoadAllProgramLead(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ProgramLeadDAL = null;
        }
    }

    // To pass 'Program Lead' data in ProgramLeadDAL Data Access Layer to show selected ProgramLeadId records
    public DataTable SelectProgramLeadID(int ProgramLeadId, int LoggedInUser, string Ret)
    {
        ProgramLeadDAL ProgramLeadDAL = new ProgramLeadDAL();
        try
        {
            return ProgramLeadDAL.SelectProgramLeadID(ProgramLeadId, LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ProgramLeadDAL = null;
        }
    }

}