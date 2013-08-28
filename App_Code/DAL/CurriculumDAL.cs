using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.Data;

/// <summary>
/// Summary description for CurriculumDAL
/// </summary>
public class CurriculumDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public CurriculumDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'Curriculum' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadCurriculum(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormCurriculum' stored procedure is used to get both 'Active','Inactive' type records from Curriculum table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormCurriculum", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "Curriculum");
            return DSet.Tables["Curriculum"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }
}