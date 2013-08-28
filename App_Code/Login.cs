using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for Login
/// Used To Check Login User Details
/// </summary>
public class Login
{
	public Login()
	{
        
	}
    public string LoginUserName="Administrator";// For Login User name
    public int LoginUser;// For logged in user id
    public string LogedInUser;// For logged in user id
    public int LoginUserID = 0; // Bydefaulty logged in user id set to zero
    public string Ret = "temp"; // For return message
    public string ValidUser; // To chack logged in user is valid or not

    /// <summary>
    /// To start valid user checking
    /// </summary>
    /// <returns></returns>
    public String Start()
    {              
/*       
 // To find current machine username
        string UserName = HttpContext.Current.User.Identity.Name.ToString();
        // To slite username by two back slashes
        UserName = Regex.Replace(UserName, @"\\", @"\\");
        // for seperarion
        string[] Separator = new string[] { "\\" };
        // To split username
        string[] StrSplitArr = UserName.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
        //To save Loginusername       
        LoginUserName = StrSplitArr[1].ToString();
        // To get details of logged in user
*/
        GetUserDetails();     
        //To check logged in user is valid or not
        if (ValidUser == "Yes")
        {
            return ValidUser;
        }
        else
        {
            return ValidUser;
        }
    }

    /// <summary>
    /// To check user is authorised or not from database
    /// </summary>
    /// <returns></returns>
    public DataTable GetUserDetails()
    {
        UserBAL UserBAL = new UserBAL();
        DataTable UserTable = new DataTable();
        try
        {
            UserTable = UserBAL.SelectUserName(LoginUserName, LoginUserID, Ret);
            if (UserTable.Rows.Count > 0)
            {
                LoginUser = Convert.ToInt16(UserTable.Rows[0][0]);
                LogedInUser = UserTable.Rows[0][5].ToString();
                ValidUser = "Yes";
            }
            else
            {
                ValidUser = "No";
            }
        }
        catch
        {

        }
        finally
        {
            UserBAL = null;
        }

        return UserTable;
    }      

}