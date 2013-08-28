using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


/// <summary>
/// Summary description for UserDAL
/// </summary>
public class UserDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public UserDAL()
	{
        //
        // TODO: Add constructor logic here
        //
	}

    //  To insert 'User' record in database by stored procedure
    public int InsertUser(string FirstName, string LastName, string EMail, string Remarks, bool IsAdmin,bool IsActive,string UserName, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertUser' stored procedure is used to insert record in User table
        SqlCommand DCmd = new SqlCommand("uspInsertUser", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@FirstName", FirstName);
            DCmd.Parameters.AddWithValue("@LastName", LastName);
            DCmd.Parameters.AddWithValue("@eMail", EMail);
            DCmd.Parameters.AddWithValue("@Remarks", Remarks);
            DCmd.Parameters.AddWithValue("@IsAdmin", IsAdmin);
            DCmd.Parameters.AddWithValue("@UserName", UserName);
            DCmd.Parameters.AddWithValue("@LoggedInUser", LoginUser);
            DCmd.Parameters.AddWithValue("@IsActive", IsActive);
            DCmd.Parameters.AddWithValue("@RetMsg", Ret);
            SqlParameter code = new SqlParameter("@RetMsg", SqlDbType.VarChar);
            code.Direction = ParameterDirection.Output;
            string remsg = DCmd.Parameters["@RetMsg"].Value.ToString();                         
            return DCmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            DCmd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To update 'User' record of Specific UpdateUser in database by stored procedure
    public int UpdateUser(int UserId, string FirstName, string LastName, string eMail, string Remarks, bool IsAdmin,bool IsActive, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspUpdateUser' stored procedure is used to update record in User table
        SqlCommand DCmd = new SqlCommand("uspUpdateUser", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@UserId", UserId);
            DCmd.Parameters.AddWithValue("@FirstName", FirstName);
            DCmd.Parameters.AddWithValue("@LastName", LastName);
            DCmd.Parameters.AddWithValue("@eMail", eMail);
            DCmd.Parameters.AddWithValue("@Remarks", Remarks);
            DCmd.Parameters.AddWithValue("@IsAdmin", IsAdmin); 
            DCmd.Parameters.AddWithValue("@IsActive", IsActive);      
            DCmd.Parameters.AddWithValue("@LoggedInUser", LoginUser);           
            DCmd.Parameters.AddWithValue("@RetMsg", Ret);

            return DCmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            DCmd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To get 'User' record of 'Active' or 'Inactive' from database by stored procedure
    public DataTable LoadActiveUser(bool IsActive,int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserDetails' stored procedure is used to get specific records from User table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "User");
            return DSet.Tables["User"];
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

    //  To get 'User' record of both 'Active','Inactive' type from database by stored procedure
    public DataTable LoadAllUser(int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserDetails' stored procedure is used to get both 'Active','Inactive' type records from User table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "User");
            return DSet.Tables["User"];
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

    //  To select 'User' records specific UserName from database by stored procedure
    public DataTable SelectUserName(string UserName, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserDetails' stored procedure is used to get Specific UserName records from User table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@UserName", UserName);
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "User");
            return DSet.Tables["User"];
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

    //  To select 'User' records specific UserID from database by stored procedure
    public DataTable SelectUserID(int UserId, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserDetails' stored procedure is used to get Specific UserID records from User table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@UserId", UserId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "User");
            return DSet.Tables["User"];
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

    //  To select 'User' records specific First Name & Last Name from database by stored procedure
    public DataTable SelectUserdetails(string FName , string  LName,bool IsActive,int LoggedInUser ,string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserDetails' stored procedure is used to get Specific First Name & Last Name records from User table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@FirstName", FName);
        DAdapter.SelectCommand.Parameters.AddWithValue("@LastName", LName);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "User");
            return DSet.Tables["User"];
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

    //  To get 'User' record for Email from database by stored procedure
    public DataTable LoadNameEmail(int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserDetails' stored procedure is used to get Email field from User table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataTable DtUser = new DataTable();
        try
        {
            DAdapter.Fill(DtUser);
            DataTable DtUserNew = DtUser.Copy();
            DataColumn dc = new DataColumn("UserNameEmail");
            DtUserNew.Columns.Add(dc);
            if (DtUserNew.Rows.Count > 0)
            {
                for (int i = 0; i < DtUserNew.Rows.Count; i++)
                {
                    string UserName = DtUserNew.Rows[i][5].ToString();
                    string EMail = DtUserNew.Rows[i][4].ToString();
                    DtUserNew.Rows[i][15] = UserName + "  (" + EMail + ")";
                }
            }
            return DtUserNew;
        }
        catch
        {
            throw;
        }
        finally
        {
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To get 'User' record by Permission wise from database by stored procedure
    public DataTable LoadUserPermission(int UserId, bool IsActive, int LoggedInUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetUserWiseMenuPermissions' stored procedure is used to get User details Permission wise from User table
        SqlDataAdapter DAdapter = new SqlDataAdapter("uspGetUserWiseMenuPermissions", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@UserID", UserId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", Ret);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "User");
            return DSet.Tables["User"];
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