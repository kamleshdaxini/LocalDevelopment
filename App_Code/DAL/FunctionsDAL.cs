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
/// Summary description for FunctionsDAL
/// </summary>
public class FunctionsDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public FunctionsDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'Functions' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadFunctions(int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormFunctions' stored procedure is used to get both 'Active','Inactive' type records from Functions table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormFunctions", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeFormFunctions");
            return DSet.Tables["IntakeFormFunctions"];
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