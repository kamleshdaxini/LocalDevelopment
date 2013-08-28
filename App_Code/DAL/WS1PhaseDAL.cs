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
/// Summary description for WS1PhaseDAL
/// </summary>
public class WS1PhaseDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public WS1PhaseDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To get 'WS1 Phase' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadWS1Phase(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetWS1PhaseDetails' stored procedure is used to get both 'Active','Inactive' type records from WS1 Phase table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Masters.uspGetWS1PhaseDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "WS1Phase");
            return DSet.Tables["WS1Phase"];
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