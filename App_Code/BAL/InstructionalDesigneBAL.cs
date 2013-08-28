using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for InstructionalDesignerBAL
/// </summary>
public class InstructionalDesignerBAL
{
    public InstructionalDesignerBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Instructional Designer' data in InstructionalDesignerDAL Data Access Layer for insertion
    public int InsertInstructionalDesigner(int UserID, bool Isactive, int LoginUser, string Ret)
    {

        InstructionalDesignerDAL InstructionalDesignerDAL = new InstructionalDesignerDAL();
        try
        {
            return InstructionalDesignerDAL.InsertInstructionalDesigner(UserID, Isactive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            InstructionalDesignerDAL = null;
        }
    }

    //  To pass 'Instructional Designer' data in InstructionalDesignerDAL Data Access Layer for updation
    public int UpdateInstructionalDesigner(int InstructionalDesignerId, bool IsActive, int LoginUser, string Ret)
    {
        InstructionalDesignerDAL InstructionalDesignerDAL = new InstructionalDesignerDAL();
        try
        {
            return InstructionalDesignerDAL.UpdateInstructionalDesigner(InstructionalDesignerId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            InstructionalDesignerDAL = null;
        }
    }

    //  To pass 'Instructional Designer' data in InstructionalDesignerDAL Data Access Layer to show Active or Inactive type records
    public DataTable LoadActiveInstructionalDesigner(int LoggedInUser, string returnmsg, bool IsActive)
    {
        InstructionalDesignerDAL InstructionalDesignerDAL = new InstructionalDesignerDAL();
        try
        {
            return InstructionalDesignerDAL.LoadActiveInstructionalDesigner(LoggedInUser, returnmsg, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            InstructionalDesignerDAL = null;
        }
    }

    //  To pass 'Instructional Designer' data in InstructionalDesignerDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadAllInstructionalDesigner(int LoggedInUser, string returnmsg)
    {
        InstructionalDesignerDAL InstructionalDesignerDAL = new InstructionalDesignerDAL();
        try
        {
            return InstructionalDesignerDAL.LoadAllInstructionalDesigner(LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            InstructionalDesignerDAL = null;
        }
    }

    // To pass 'Instructional Designer' data in InstructionalDesignerDAL Data Access Layer to show selected InstructionalDesignerId records
    public DataTable SelectInstructionalDesignerID(int InstructionalDesignerId, int LoggedInUser, string returnmsg)
    {
        InstructionalDesignerDAL InstructionalDesignerDAL = new InstructionalDesignerDAL();
        try
        {
            return InstructionalDesignerDAL.SelectInstructionalDesignerID(InstructionalDesignerId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            InstructionalDesignerDAL = null;
        }
    }
}