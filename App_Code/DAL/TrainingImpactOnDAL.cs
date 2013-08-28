using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for TrainingImpactOnDAL
/// </summary>
public class TrainingImpactOnDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public TrainingImpactOnDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'Training Impact On' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadTrainingImpactOn(int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormTrainingImpactOn' stored procedure is used to get both 'Active','Inactive' type records from Training Impact On table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormTrainingImpactOn", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeFormTrainingImpactOn");
            return DSet.Tables["IntakeFormTrainingImpactOn"];
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