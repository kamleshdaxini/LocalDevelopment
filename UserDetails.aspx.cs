using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Data;
using System.Data.Common;
using System.DirectoryServices.AccountManagement;
using AjaxControlToolkit;

public partial class User : System.Web.UI.Page
{
    // Initialization of public variables
    int UserId;// For User Id 
    public string UserName;// For Loged in username 
    public int LoginUser;// For Loged in userId
    public string Ret;// For return message
           
    /// <summary>
    /// Page Load method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param> 
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int Ind = MasterAcc.SelectedIndex;
        int Index = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = Index - 1;
        // To select loginuser id and login username
        Login objUser = new Login();
        objUser.Start();
        UserName = objUser.LogedInUser;
        LoginUser = objUser.LoginUser;
        Ret = objUser.Ret;
        if (!Page.IsPostBack)
        {         
            if (Session["UserId"] != null)
            {
                imbSearch.Visible = false;
                UserId = Convert.ToInt32(Session["UserId"].ToString());
                DataTable DtUser = GetUserDetails();
                if (DtUser.Rows.Count > 0)
                {
                    txtEmail.ReadOnly = true;
                    txtFName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    txtUserName.ReadOnly = true;
                    txtFName.Text = DtUser.Rows[0][2].ToString();
                    txtLastName.Text = DtUser.Rows[0][1].ToString();
                    txtEmail.Text = DtUser.Rows[0][4].ToString();
                    txtUserName.Text = DtUser.Rows[0][3].ToString();
                    string Status = DtUser.Rows[0][8].ToString();
                    txtRemarks.Text = DtUser.Rows[0][6].ToString();
                    string UserStatus = DtUser.Rows[0][4].ToString();
                    if (Status == "0")
                    {
                        ddlUserStatus.SelectedIndex = 1;
                    }
                    else if (Status == "1")
                    {
                        ddlUserStatus.SelectedIndex = 2;
                    }
                    string UserAdmin = DtUser.Rows[0][7].ToString();
                    if (UserAdmin == "True")
                    {
                        ddlIsAdmin.SelectedIndex = 1;
                    }
                    else if (UserAdmin == "False")
                    {
                        ddlIsAdmin.SelectedIndex = 2;
                    }
                    btnSave.Text = "Update";
                    ViewState["dtgrusereaddnew"] = DtUser;
                }
                btnUserGroRol.Visible = true;
            }
            else
            {
                btnUserGroRol.Visible = true;
                btnUserGroRol.Enabled = false;
                imbSearch.Visible = true;
            }          
        }
        else
        {
            if (Session["UserId"] != null)
            {
                UserId = Convert.ToInt32(Session["UserId"].ToString());
                imbSearch.Visible = false;
            }
        }
    }

    /// <summary>
    /// To load user details from database
    /// </summary>
    /// <returns></returns>
    protected DataTable GetUserDetails()
    {
        UserBAL UserBAL = new UserBAL();
        DataTable DtUserDet = new DataTable();
        try
        {
            DtUserDet = UserBAL.SelectUserID(UserId, LoginUser, Ret);
        
        }
        catch
        {
            throw;
        }
        finally
        {
            UserBAL = null;
        }
        return DtUserDet;
    }

    /// <summary>
    /// To search active directory record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        BindUser();
        mpopUser.Show();
    }

    /// <summary>
    /// To bind active directory records in user details grid
    /// </summary>
    public void BindUser()
    {
        DataTable DtBindUser = new DataTable();       
        DataColumn Dtmail = new DataColumn("mail");
        DataColumn Dtfname = new DataColumn("fname");
        DataColumn Dtlname = new DataColumn("lname");
        DataColumn DtdisplayName = new DataColumn("displayName");
        DtBindUser.Columns.Add(Dtmail);
        DtBindUser.Columns.Add(Dtfname);
        DtBindUser.Columns.Add(Dtlname);
        DtBindUser.Columns.Add(DtdisplayName);
        DataRow Druser;

        // Added connection string for active directory user
        string connection = ConfigurationManager.ConnectionStrings["ADConnection"].ToString();
        DirectorySearcher DsSearch = new DirectorySearcher(connection);

        // declaired domain from which you want to fetch active directory users
        DirectoryEntry UserDomain = new DirectoryEntry("LDAP://DC=kpmg,DC=aptaracorp,DC=com");
        DirectorySearcher Usersearch = new DirectorySearcher(connection);
        DsSearch.SearchRoot = UserDomain;
        DsSearch.SearchScope = SearchScope.Subtree;
        SearchResultCollection UserResult;

        //Applied Filter On User For Specific Fname and Lname
        Usersearch.Filter = "(&(objectClass=user)(sn=" + txtLastName.Text + "*)(givenName=" + txtFName.Text + "*))";
        UserResult = Usersearch.FindAll();
        for (int i = 0; i < UserResult.Count; i++)
        {
            string AccounName = UserResult[i].Properties["samaccountname"][0].ToString();
            DirectorySearcher DrSearcher = new System.DirectoryServices.DirectorySearcher("(samaccountname=" + AccounName + ")");
            SearchResult SrchRes = DrSearcher.FindOne();
            DirectoryEntry DrEntry = SrchRes.GetDirectoryEntry();
            try
            {
                if (DrEntry.Properties["givenName"][0].ToString() != "")
                {
                    string FirstName = DrEntry.Properties["givenName"][0].ToString();
                    string LastName = DrEntry.Properties["sn"][0].ToString();
                    string UserEmail = DrEntry.Properties["mail"][0].ToString();
                    string UserDisName = DrEntry.Properties["displayName"][0].ToString();
                    Druser = DtBindUser.NewRow();
                    Druser["mail"] = UserEmail.ToString();
                    Druser["fname"] = FirstName.ToString();
                    Druser["lname"] = LastName.ToString();
                    Druser["displayName"] = UserDisName.ToString();
                    DtBindUser.Rows.Add(Druser);
                }
            }
            catch
            {
                ////throw;
            }
        }
        if (DtBindUser.Rows.Count > 0)
        {
            grdUserDetails.DataSource = DtBindUser;
            grdUserDetails.DataBind();
        }
    }

    /// <summary>
    /// To see searched user details in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSelect_Click(object sender, EventArgs e)
     {
         LinkButton lnkUser = sender as LinkButton;
         GridViewRow rw = (GridViewRow)lnkUser.Parent.Parent;
         int Idx = rw.RowIndex;
         txtEmail.ReadOnly = true;
         txtFName.ReadOnly = true;
         txtLastName.ReadOnly = true;
         txtUserName.ReadOnly = true;
         Label lblUserName = (Label)grdUserDetails.Rows[Idx].FindControl("lblUserName");
         Label lblFName = (Label)grdUserDetails.Rows[Idx].FindControl("lblFName");
         Label lblLName = (Label)grdUserDetails.Rows[Idx].FindControl("lblLName");
         Label lblEmail = (Label)grdUserDetails.Rows[Idx].FindControl("lblEmail");
         mpopUser.Hide();
         txtEmail.Text = lblEmail.Text;
         txtFName.Text = lblFName.Text;
         txtLastName.Text = lblLName.Text;
         txtUserName.Text = lblUserName.Text;
     }
     
     //To cancel action
    protected void btnCancel_Click(object sender, EventArgs e)
     {
         Response.Redirect("UserList.aspx", false);
     }

     /// <summary>
    /// To save and update user details
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     protected void btnSave_Click(object sender, EventArgs e)
     {
         string Status = ddlUserStatus.SelectedItem.Text;
         string FName = txtFName.Text;
         string Lname = txtLastName.Text;
         string Email = txtEmail.Text;
         string Remarks = txtRemarks.Text;
         string UserName = txtUserName.Text;
         string UIsAdmin = ddlIsAdmin.SelectedItem.Text;
         bool IsAdmin = true;
         if (UIsAdmin == "True")
         {
             IsAdmin = true;
         }
         else if (UIsAdmin == "False")
         {
             IsAdmin = false;
         }      
         bool UserStatus;
         if (ddlUserStatus.SelectedItem.Text != "Select")
         {
             if (Status == "Active")
             {
                 UserStatus = true;
             }
             else
             {
                 UserStatus = false;
             }
             if (btnSave.Text == "Save")
             {
                 int IntResult = 0;
                 UserBAL UserBAL = new UserBAL();                                           
                 try
                 {
                     // 'InsertUser' is User business Access Layer function called
                     // to insert User details
                     IntResult = UserBAL.InsertUser(FName, Lname, Email, Remarks, IsAdmin, UserStatus, UserName, LoginUser, Ret);
                     //msgUser.Msg = "User details submited successfully";
                     //msgUser.showmsg();
                     btnUserGroRol.Enabled = true;
                     Clear();
                     Response.Redirect("UserList.aspx", false);                            
                 }
                 catch (Exception ee)
                 {
                     if (ee.Message == "Duplicate Entry")
                     {
                         // Duplicate Entry is catched when inserting Group
                         msgUser.Msg = "Duplicate Entry!";
                         msgUser.showmsg();
                         Clear();
                     }
                 }
                 finally
                 {
                     UserBAL = null;
                 }
             }
             else if (btnSave.Text == "Update")
             {
                 int IntResult = 0;
                 UserBAL UserBAL = new UserBAL();
                 try
                 {
                     // 'UpdateUser' is User business Access Layer function called
                     // to update User details
                     IntResult = UserBAL.UpdateUser(UserId, FName, Lname, Email, Remarks, IsAdmin, UserStatus, LoginUser, Ret);
                     msgUser.Msg = "User details updated successfully";
                     msgUser.showmsg();
                     btnSave.Text = "Save";
                     Clear();
                     Response.Redirect("UserList.aspx", false);                     
                 }
                 catch (Exception ee)
                 {
                     // Duplicate Entry is catched when updating Group
                     if (ee.Message == "Duplicate Entry")
                     {
                         msgUser.Msg = "Duplicate Entry!";
                         msgUser.showmsg();
                         Clear();
                     }
                 }
                 finally
                 {
                     UserBAL = null;
                 }
             }
         }
     }

     /// <summary>
     /// To clear all fields
     /// </summary>
     private void Clear()
     {
         txtLastName.Text = "";
         txtFName.Text = "";
         txtEmail.Text = "";
         txtUserName.Text = "";
         ddlUserStatus.SelectedIndex = 0;
         txtRemarks.Text = "";
     }

     /// <summary>
     /// for paging in user grid
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>

     protected void grdUserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         grdUserDetails.PageIndex = e.NewPageIndex;
         BindUser();
         mpopUser.Show();
     }

     /// <summary>
     /// To show group role permission of selected user
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     protected void btnUserGroRol_Click(object sender, EventArgs e)
     {
         if (btnSave.Text == "Save")
         {
             Session["UserId"] = null;
             Session["Username"] = txtFName.Text + "_" + txtLastName.Text;
             Response.Redirect("UserGroupRoleDetails.aspx", false);
         }
         else if (btnSave.Text == "Update")
         {
             Session["Username"] = null;
             Session["UserId"] = UserId.ToString();
             Response.Redirect("UserGroupRoleDetails.aspx", false);
         }
     }
}