using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for SpecialitiesDAL
/// </summary>
public class SpecialitiesDAL
{

    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public SpecialitiesDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'Specialities' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadSpecialities(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormSpecialties' stored procedure is used to get both 'Active','Inactive' type records from Specialities table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormSpecialties", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeFormSpecialties");
            return DSet.Tables["IntakeFormSpecialties"];
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