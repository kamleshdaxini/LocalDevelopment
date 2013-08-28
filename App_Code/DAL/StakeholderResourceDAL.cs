using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for StakeholderResourceDAL
/// </summary>
public class StakeholderResourceDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public StakeholderResourceDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'Stakeholder Resource' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadStakeholderResource(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormStakeholderResources' stored procedure is used to get both 'Active','Inactive' type records from StakeholderResource table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormStakeholderResources", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeFormStakeholderResources");
            return DSet.Tables["IntakeFormStakeholderResources"];
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