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
/// Summary description for AnalyzeSolutionDAL
/// </summary>
public class AnalyzeSolutionDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public AnalyzeSolutionDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'Analyze Solution' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAnalyzeSolution(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormAnalyzeSolution' stored procedure is used to get both 'Active','Inactive' type records from Analyze Solution table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormAnalyzeSolution", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "AnalyzeSolution");
            return DSet.Tables["AnalyzeSolution"];
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