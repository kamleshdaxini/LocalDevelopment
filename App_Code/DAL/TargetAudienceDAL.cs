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
/// Summary description for TargetAudienceDAL
/// </summary>
public class TargetAudienceDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public TargetAudienceDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'Target Audience' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadTargetAudience(int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormTargetAudienceDetails' stored procedure is used to get both 'Active','Inactive' type records from Target Audience table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormTargetAudienceDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeFormTargetAudience");
            return DSet.Tables["IntakeFormTargetAudience"];
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