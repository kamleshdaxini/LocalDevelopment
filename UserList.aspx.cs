using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class UserList : System.Web.UI.Page
{
    // Initialization of public variables
    public string UserName;// For logged in username
    public int LoginUser;// For loged in User ID
    public string Ret;// For Return message
    string Ope, Col, Val, Sort;// For operator, Column, value, Sorting perpose
    DataTable DtSort;// For Sorting in Table
    DataView Dv;// For User table view

    /// <summary>
    ///  Page Load Method 
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
            // To sort defaulty by Ascending order
            ViewState["SortUser"] = "ASC";
            // To fetch Group details having active status
            DataTable DtUser = ActivegetUserDetails();
            ViewState["DtUserDet"] = DtUser;
            BindGrid(DtUser);
        }
    }
 
   /// <summary>
    /// To bind User details to Grid 
   /// </summary>
   /// <param name="DtUser"></param>
    private void BindGrid(DataTable DtUser)
    {
        if (DtUser.Rows.Count > 0 || DtUser != null)
        {
            grdUserDetails.DataSource = DtUser;
            grdUserDetails.DataBind();
            for (int i = 0; i < grdUserDetails.Rows.Count; i++)
            {
                Label lblIsActive = (grdUserDetails.Rows[i].FindControl("lblIsActive") as Label);
                string Status = lblIsActive.CssClass.ToString();
                if (Status == "1")
                {

                    lblIsActive.Text = "Active";
                }
                else if (Status == "0")
                {
                    lblIsActive.Text = "InActive";
                }

            }
        }
        else
        {
            grdUserDetails.DataSource = null;
            grdUserDetails.DataBind();
        }
    }

    /// <summary>
    /// To get active User details
    /// </summary>
    /// <returns></returns>
    private DataTable ActivegetUserDetails()
    {
        UserBAL UserBAL = new UserBAL();
        DataTable DtUserDe = new DataTable();
        try
        {
            DtUserDe = UserBAL.LoadActiveUser(true, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            UserBAL = null;
        }
        return DtUserDe;
    }
    
    /// <summary>
    /// To get User details from 'user Business access layer'
    /// </summary>
    /// <returns></returns>
    private DataTable getUserDetails()
    {
        UserBAL UserBAL = new UserBAL();
        DataTable DtUDetails = new DataTable();
        try
        {
            DtUDetails = UserBAL.LoadAllUser(LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            UserBAL = null;
        }
        return DtUDetails;
    }

   
    /// <summary>
    ///  To filter user details by specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbFilter_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
        Col = ddlUserColumn.Text;    // For selected column in dropdownlist for search         
        Val = txtUserValue.Text; // For selected value in textbox for search
        DataTable Dt = getUserDetails();// For get all user details in grid
        DataView Dv = Dt.DefaultView;// For View of user details
        if (Col  == "IsAdmin")
        {
            Ope = ddlUserOpeSta.Text;// For operator in search condition
            Val = ddlUserIsAdmin.SelectedValue;// For value in search condition
            if (Val == "true")
            {
                Val = "true";
            }
            else if (Val == "false")
            {
                Val = "false";
            }
        }
        else if (Col == "IsActive")
        {
            Ope = ddlUserOpeSta.Text;
            Val  = ddlUserStatus.SelectedValue;
            if (Val == "true")
            {
                Val = "1";
            }
            else if (Val == "false")
            {
                Val = "0";
            }
        }
        else
        {
            Ope = ddlUserOperator.Text;
        }
        if (Ope == "LIKE")
        {
            string Filter = Col + " " + Ope + "'%" + Val + "%' ";
            Dv.RowFilter = Filter;
            if (Dv.ToTable().Rows.Count == 0)
            {
                msgUser.Msg = "Record(s) not found";
                msgUser.showmsg();
                BindGrid(Dv.ToTable());
            }
            else
            {
                ViewState["DtUserDet"] = Dv.ToTable();
                BindGrid(Dv.ToTable());
            }
        }
        else if (Ope == "=")
        {
            Dv.RowFilter = Col + Ope + "'" + Val + "'";
            if (Dv.ToTable().Rows.Count == 0)
            {
                msgUser.Msg = "Record(s) not found";
                msgUser.showmsg();
                BindGrid(Dv.ToTable());
            }
            else
            {
                BindGrid(Dv.ToTable());
                ViewState["DtUserDet"] = Dv.ToTable();
            }
        }
        else if (Ope == "<>")
        {
            Dv.RowFilter = Col + Ope + "'" + Val + "'";
            if (Dv.ToTable().Rows.Count == 0)
            {
                msgUser.Msg = "Record(s) not found";
                msgUser.showmsg();
                BindGrid(Dv.ToTable());
            }
            else
            {
                BindGrid(Dv.ToTable());
                ViewState["DtUserDet"] = Dv.ToTable();
            }
        }
        else if (Ope == "NOT LIKE")
        {
            string Filter = Col + " " + Ope + "'%" + Val + "%' ";
            Dv.RowFilter = Filter;
            if (Dv.ToTable().Rows.Count == 0)
            {
                msgUser.Msg = "Record(s) not found";
                msgUser.showmsg();
                BindGrid(Dv.ToTable());
            }
            else
            {
                BindGrid(Dv.ToTable());
                ViewState["DtUserDet"] = Dv.ToTable();
            }
        }
      
        }
        catch (Exception ex)
        {
             Response.Write(ex.Message);
        }
    }

    /// <summary>
    /// To clear
    /// </summary>
    private void ClearUser()
    {
        txtUserValue.Text = "";
        ddlUserStatus.SelectedIndex = 0;
        ddlUserIsAdmin.SelectedIndex = 0;
    }

    /// <summary>
    /// To change dropdown value for specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlUserColumn_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearUser();
        if (ddlUserColumn.Text == "FirstName" || ddlUserColumn.Text == "LastName" || ddlUserColumn.Text == "eMail")
        {
            td1.Visible = true;
            td2.Visible = false;
            td3.Visible = true;
            td5.Visible = false;
            td4.Visible = false;
            cvUserOperator.Enabled = true;
            rfvUserVal.Enabled = true;
            cvUserOpeSta.Enabled = false;
            cvUserStatus.Enabled = false;
            cvUserIsAdmin.Enabled = false;
        }
        else if (ddlUserColumn.Text == "IsActive")
        {
            td2.Visible = true;
            td1.Visible = false;
            td3.Visible = false;
            td5.Visible = false;
            td4.Visible = true;
            cvUserOperator.Enabled = false;
            cvUserOpeSta.Enabled = true;
            rfvUserVal.Enabled = false;
            cvUserStatus.Enabled = true;
            cvUserIsAdmin.Enabled = false;
        }
        else if (ddlUserColumn.Text == "IsAdmin")
        {
            td2.Visible = true;
            td1.Visible = false;
            td3.Visible = false;
            td5.Visible = true;
            td4.Visible = false;
            cvUserOperator.Enabled = false;
            cvUserOpeSta.Enabled = true;
            rfvUserVal.Enabled = false;
            cvUserStatus.Enabled = false;
            cvUserIsAdmin.Enabled = true;
        }
       
    }
   
    /// <summary>
    /// To sort user details by First name wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkFirstName_Click(object sender, EventArgs e)
    {
        if (ViewState["SortUser"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtUserDet"];
            DtSort.DefaultView.Sort = "FirstName" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("FirstName" + " ASC");
            Sort = "DESC";
            ViewState["DtUserDet"] = Dv.ToTable();
            ViewState["SortUser"] = Sort;
        }
        else if (ViewState["SortUser"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtUserDet"];
            DtSort.DefaultView.Sort = "FirstName" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("FirstName" + " DESC");
            Sort = "ASC";
            ViewState["DtUserDet"] = Dv.ToTable();
            ViewState["SortUser"] = Sort;
        }
        BindGrid(Dv.ToTable());
    }

    /// <summary>
    /// To sort user details last name wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkLName_Click(object sender, EventArgs e)
    {
        if (ViewState["SortUser"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtUserDet"];
            DtSort.DefaultView.Sort = "LastName" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("LastName" + " ASC");
            Sort = "DESC";
            ViewState["DtUserDet"] = Dv.ToTable();
            ViewState["SortUser"] = Sort;
        }
        else if (ViewState["SortUser"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtUserDet"];
            DtSort.DefaultView.Sort = "LastName" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("LastName" + " DESC");
            Sort = "ASC";
            ViewState["DtUserDet"] = Dv.ToTable();
            ViewState["SortUser"] = Sort;
        }
        BindGrid(Dv.ToTable());
    }

    /// <summary>
    /// To sort user details email wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkEmailId_Click(object sender, EventArgs e)
    {
        if (ViewState["SortUser"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtUserDet"];
            DtSort.DefaultView.Sort = "eMail" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("eMail" + " ASC");
            Sort = "DESC";
            ViewState["DtUserDet"] = Dv.ToTable();
            ViewState["SortUser"] = Sort;
        }
        else if (ViewState["SortUser"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtUserDet"];
            DtSort.DefaultView.Sort = "eMail" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("eMail" + " DESC");
            Sort = "ASC";
            ViewState["DtUserDet"] = Dv.ToTable();
            ViewState["SortUser"] = Sort;
        }
        BindGrid(Dv.ToTable());
    }

    /// <summary>
    /// To sort user details Status wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStatusUser_Click(object sender, EventArgs e)
    {
        if (ViewState["SortUser"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtUserDet"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["DtUserDet"] = Dv.ToTable();
            ViewState["SortUser"] = Sort;
        }
        else if(ViewState["SortUser"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtUserDet"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["DtUserDet"] = Dv.ToTable();
            ViewState["SortUser"] = Sort;
        }
        BindGrid(Dv.ToTable());
    }

    /// <summary>
    /// To load active user details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRefresh_Click(object sender, ImageClickEventArgs e)
    {
        DataTable DtUserDet = ActivegetUserDetails();
        ViewState["DtUserDet"] = DtUserDet;
        BindGrid(DtUserDet);
        ClearUser();
    }

    /// <summary>
    /// To sort user details IsAdmin wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkIsAdmin_Click(object sender, EventArgs e)
    {
        if (ViewState["SortUser"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtUserDet"];
            DtSort.DefaultView.Sort = "IsAdmin" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("IsAdmin" + " ASC");
            Sort = "DESC";
            ViewState["DtUserDet"] = Dv.ToTable();
            ViewState["SortUser"] = Sort;
        }
        else if (ViewState["SortUser"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtUserDet"];
            DtSort.DefaultView.Sort = "IsAdmin" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("IsAdmin" + " DESC");
            Sort = "ASC";
            ViewState["DtUserDet"] = Dv.ToTable();
            ViewState["SortUser"] = Sort;
        }
        BindGrid(Dv.ToTable());
    }

    /// <summary>
    /// For paging of grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdUserDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdUserDetails.PageIndex = e.NewPageIndex;
        DataTable DtUser = (DataTable)ViewState["DtUserDet"];
        BindGrid(DtUser);
    }

    /// <summary>
    /// To add new user details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("UserDetails.aspx", false);
    }

    /// <summary>
    /// To edit user details   
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imb = sender as ImageButton;   
        int UserId = Convert.ToInt32(imb.CommandArgument.ToString());
        lblSelectID.Text = UserId.ToString();
        Session["UserId"] = lblSelectID.Text;
        Response.Redirect("UserDetails.aspx", false);
    }

    /// <summary>
    /// To show user group role permission details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbUserGRPer_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imbGRper = sender as ImageButton;
        int UserId = Convert.ToInt32(imbGRper.CommandArgument.ToString());
        lblSelectID.Text = UserId.ToString();
        Session["UserId"] = lblSelectID.Text;
        Response.Redirect("UserGroupRoleDetails.aspx", false);
    }
    protected void imguserhelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/UserListHelp.pdf");
        FileInfo myDoc = new FileInfo(fPath);
        if (myDoc.Exists)
        {
            Response.Clear();
            Response.ContentType = "Application/msword";
            Response.AddHeader("content-disposition", "attachment;filename=" + myDoc.Name);
            Response.AddHeader("Content-Length", myDoc.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(myDoc.FullName);
            Response.End();
        }
    }
}