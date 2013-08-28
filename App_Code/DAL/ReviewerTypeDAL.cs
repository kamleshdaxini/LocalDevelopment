using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for ReviewerTypeDAL
/// </summary>
public class ReviewerTypeDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public ReviewerTypeDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'Reviewer Type' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadReviewerType(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormReviewerType' stored procedure is used to get both 'Active','Inactive' type records from Reviewer Type table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormReviewerType", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeFormReviewerType");
            return DSet.Tables["IntakeFormReviewerType"];
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