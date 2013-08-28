using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CurriculumBAL
/// </summary>
public class CurriculumBAL
{
	public CurriculumBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To pass 'Curriculum' data in CurriculumDAL Data Access Layer to show Active,Inactive type records
    public DataTable LoadCurriculum(int LoggedInUser, string Ret)
    {
        CurriculumDAL CurriculumDAL = new CurriculumDAL();
        try
        {
            return CurriculumDAL.LoadCurriculum(LoggedInUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            CurriculumDAL = null;
        }
    }
}