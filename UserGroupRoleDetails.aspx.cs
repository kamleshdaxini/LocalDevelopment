using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class UserPermissionDetails : System.Web.UI.Page
{
    // Initialization of public variables
    public string UserName;// For logged in username
    public int LoginUser;// For loged in User ID
    public string Ret;// For Return message
    DataTable DtAddNew = new DataTable();//

    /// <summary>
    /// Page Load Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int Ind = MasterAcc.SelectedIndex;
        int Index = Convert.ToInt16(Session["SrNo"]);
        int NewUserID;
        MasterAcc.SelectedIndex = Index - 1;
        // To select loginuser id and login username
        Login objUserGroupRole = new Login();
        objUserGroupRole.Start();
        UserName = objUserGroupRole.LogedInUser;
        LoginUser = objUserGroupRole.LoginUser;
        Ret = objUserGroupRole.Ret;
        NewUserID = set();     
        if (!Page.IsPostBack)
        {         
            BindUserddl();
            DataTable DtNewUser = GridUserDataSource(NewUserID);
            if (DtNewUser.Rows.Count == 0)
            {
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
                btnCancel.Visible = true;
            }
            if (ddlUserName.SelectedIndex == 0)
            {
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
        }
    }

    /// <summary>
    /// To set particular user name in user dropdownlist
    /// </summary>
    /// <returns></returns>
    private int set()
    {
        if (Session["UserId"] != null)
        {
            DataTable DtUserDe = UserIDDetails(Convert.ToInt16(Session["UserId"]));
            if (DtUserDe.Rows.Count > 0)
            {
                Session["Userset"] = DtUserDe.Rows[0][0].ToString();
            }
            else
            {
                Session["Userset"] = null;
            }
        }
        else if (Session["Username"] != null)
        {
            string UName = Session["Username"].ToString();
            string[] Name = UName.Split('_');
            string FName=Name[0].ToString();
            string LName=Name[1].ToString();
            DataTable DtUserDe = SelectUserdetails(FName, LName, true);
            if (DtUserDe.Rows.Count > 0)
            {
                Session["Userset"] = DtUserDe.Rows[0][0].ToString();
            }
            else
            {
                Session["Userset"] = null;
            }
        }
        if (Session["Userset"] != null)
        {
            return Convert.ToInt32(Session["Userset"].ToString());
        }
        return 0;
    }

    /// <summary>
    /// To bind User Group Role Grid
    /// </summary>
    /// <param name="UserID"></param>
    private void BindUserPerGrid(int UserID)
    {
        DataTable DtUserPer = GridUserDataSource(UserID);
        if (DtUserPer.Rows.Count > 0)
        {
            grdUserPerDetails.DataSource = DtUserPer;
            grdUserPerDetails.DataBind();
            BindddlGroupRole(DtUserPer);
            btnSave.Visible = true;
            btnCancel.Visible = true;
            for (int i = 0; i < grdUserPerDetails.Rows.Count; i++)
            {
                LinkButton lblIsActive = (grdUserPerDetails.Rows[i].FindControl("lblisactive") as LinkButton);
                Label lblStatus = (grdUserPerDetails.Rows[i].FindControl("lblstatus") as Label);
                string Status = lblIsActive.CommandArgument.ToString();

                if (Status == "True")
                {
                    lblIsActive.Text = "DeActive";
                    lblStatus.Text = "Active";
                    lblIsActive.Font.Underline = true;
                }
                else
                {
                    lblIsActive.Text = "Active";
                    lblStatus.Text = "InActive";
                    lblIsActive.Font.Underline = true;
                }               
            }
        }
        else
        {
            grdUserPerDetails.DataSource = null;
            grdUserPerDetails.DataBind();
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }
    }

    /// <summary>
    /// To select particular user from database
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    private DataTable GridUserDataSource(int UserID)
    {
        UserGroupRoleBAL UserGroupRoleBAL = new UserGroupRoleBAL();
        DataTable DtUserGridSo = new DataTable();
        try
        {
            DtUserGridSo = UserGroupRoleBAL.SelectUserID(UserID, LoginUser, Ret);
            //DataView dv1 = dTable.DefaultView;
            //dv1.RowFilter = "IsActive=true";
            //dTable = dv1.ToTable();
        }
        catch
        {
            throw;
        }
        finally
        {
            UserGroupRoleBAL = null;
        }
        return DtUserGridSo;
    }

    /// <summary>
    /// To bind Group Role dropdown list
    /// </summary>
    /// <param name="DtUserGroupRole"></param>
    protected void BindddlGroupRole(DataTable DtUserGroupRole)
    {
        foreach (GridViewRow grdRow in grdUserPerDetails.Rows)
        {
            DropDownList ddlGroupRole;
            int NewGroupRoleID;
            NewGroupRoleID = Convert.ToInt32(DtUserGroupRole.Rows[grdRow.RowIndex][9].ToString());
            DataTable DtCGR = CheckGroupRoleStatus(NewGroupRoleID);
            ddlGroupRole = (DropDownList)(grdUserPerDetails.Rows[grdRow.RowIndex].Cells[1].FindControl("ddlGroupRoleDetails"));
            DataTable DtGroupRole = ddlGroupRoleDe();
            if (DtGroupRole.Rows.Count > 0 || DtGroupRole != null)
            {
                ddlGroupRole.DataSource = DtGroupRole;
                ddlGroupRole.DataTextField = "GroupRole";
                ddlGroupRole.DataValueField = "GroupRoleID";
                ddlGroupRole.DataBind();
                ddlGroupRole.Items.Insert(0, new ListItem("Select Group Role", "Select Group Role"));
                if (DtUserGroupRole.Rows[grdRow.RowIndex][9].ToString() != "")
                {
                    ddlGroupRole.SelectedValue = DtUserGroupRole.Rows[grdRow.RowIndex][9].ToString();
                    ddlGroupRole.Enabled = false;
                }
                else
                {
                    ddlGroupRole.SelectedIndex = 0;
                }
            }
            else
            {
                ddlGroupRole.DataSource = null;
                ddlGroupRole.DataTextField = "GroupRole";
                ddlGroupRole.DataValueField = "GroupRoleID";
                ddlGroupRole.DataBind();
                ddlGroupRole.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                ddlGroupRole.SelectedIndex = 0;
            }
        }
    }

    /// <summary>
    /// To take Group Role list from database
    /// </summary>
    /// <returns></returns>
    private DataTable ddlGroupRoleDe()
    {
        GroupRoleBAL GroupRoleBAL = new GroupRoleBAL();
        DataTable DtGrpRolDe = new DataTable();
        try
        {
            DtGrpRolDe = GroupRoleBAL.GroupRoleLoad(LoginUser, Ret );
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleBAL = null;
        }
        return DtGrpRolDe;
    }

    /// <summary>
    /// To check status of group role
    /// </summary>
    /// <param name="NGRID"></param>
    /// <returns></returns>
    private DataTable CheckGroupRoleStatus(int NGRID)
    {
        GroupRoleBAL GroupRoleBAL = new GroupRoleBAL();
        DataTable DtGrpRolSta = new DataTable();
        try
        {
            DtGrpRolSta = GroupRoleBAL.SelectGroupRoleID(NGRID, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleBAL = null;
        }
        return DtGrpRolSta;
    }

    /// <summary>
    /// To bind User dropdown list
    /// </summary>
    protected void BindUserddl()
    {
        DataTable DtUser = UserPerDetails();
        if (DtUser.Rows.Count > 0 || DtUser != null)
        {
            ddlUserName.DataSource = DtUser;
            ddlUserName.DataTextField = "UserNameEmail";
            ddlUserName.DataValueField = "UserID";
            ddlUserName.DataBind();
            ddlUserName.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            if (Session["Userset"] != null)
            {
                int UId=Convert.ToInt16(Session["Userset"]);
                ddlUserName.SelectedValue = UId.ToString();
                ddlUserName_SelectedIndexChanged1(this, EventArgs.Empty);
            }
            else
            {
                //cmbUserName.SelectedIndex =0;
                MsgGroup.Msg = "Selected user not in active Status";
                MsgGroup.showmsg();
            }
        }
        else
        {
            ddlUserName.DataSource = null;
            ddlUserName.DataTextField = "UserNameEmail";
            ddlUserName.DataValueField = "UserID";
            ddlUserName.DataBind();
            ddlUserName.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlUserName.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// To load selected user details from database
    /// </summary>
    /// <param name="FName"></param>
    /// <param name="LName"></param>
    /// <param name="ISActive"></param>
    /// <returns></returns>
    protected DataTable SelectUserdetails(string FName,string LName,bool ISActive)
    {
        ISActive=true;
        UserBAL UserBAL = new UserBAL();
        DataTable DtSelUser = new DataTable();
        try
        {
            DtSelUser = UserBAL.SelectUserdetails(FName, LName, ISActive, LoginUser, Ret);
        }
        catch (Exception ee)
        {
            throw;
        }
        finally
        {
            UserBAL = null;
        }
        return DtSelUser;
    }

    /// <summary>
    /// To get selected user
    /// </summary>
    /// <param name="UserIdNew"></param>
    /// <returns></returns>
    protected DataTable UserIDDetails(int UserIdNew)
    {
        UserBAL UserBAL = new UserBAL();
        DataTable DtUserIdDet = new DataTable();
        try
        {
            DtUserIdDet = UserBAL.SelectUserID(UserIdNew, LoginUser, Ret);
            DataView DvUserDet = DtUserIdDet.DefaultView;
            DvUserDet.RowFilter = "IsActive=true";
            DtUserIdDet = DvUserDet.ToTable();
        }
        catch (Exception ee)
        {
            throw;
        }
        finally
        {
            UserBAL = null;
        }
        return DtUserIdDet;
    }

    /// <summary>
    /// To take user list from database
    /// </summary>
    /// <returns></returns>
    protected DataTable UserPerDetails()
    {
        UserBAL UserBAL = new UserBAL();
        DataTable DtUserPerDe = new DataTable();
        try
        {
            DtUserPerDe = UserBAL.LoadNameEmail(LoginUser, Ret);
        }
        catch (Exception ee)
        {
            throw;
        }
        finally
        {
            UserBAL = null;
        }
        return DtUserPerDe;
    }

    /// <summary>
    /// To Save New Group Role assign to User
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow grdRow in grdUserPerDetails.Rows)
        {
            int IntResult = 0;
            int IsActive = 1;
            UserGroupRoleBAL UserGroupRoleBAL = new UserGroupRoleBAL();
            LinkButton lblIsActive = (grdUserPerDetails.Rows[grdRow.RowIndex].FindControl("lblisactive") as LinkButton);
            Label lblStatus = (grdUserPerDetails.Rows[grdRow.RowIndex].FindControl("lblstatus") as Label);
            string Status = lblIsActive.CommandArgument.ToString();
            DropDownList ddlGroupRole1 = (DropDownList)(grdUserPerDetails.Rows[grdRow.RowIndex].Cells[1].FindControl("ddlGroupRoleDetails"));
            int UserIDNew = Convert.ToInt16(ddlUserName.SelectedValue);
            Session["NewUserID"] = UserIDNew.ToString();
            int GroupRoleID = Convert.ToInt32(ddlGroupRole1.SelectedValue);
            string UserGPID = lblIsActive.CssClass.ToString();
            if (UserGPID != "")
            {
                int UserGroupRoleID = Convert.ToInt32(lblIsActive.CssClass.ToString());
                if (Status == "True")
                {
                    IsActive = 1;
                }
                else if (Status == "False")
                {
                    IsActive = 0;
                }
                IntResult = UserGroupRoleBAL.UpdateUserGroupRole(UserGroupRoleID, IsActive, LoginUser, Ret);
            }
            else
            {
                DataTable DtGroupRole = DuplicateGroupRoleCheck(UserIDNew, GroupRoleID);
                int Cnt = DtGroupRole.Rows.Count;
                if (Cnt == 0)
                {
                    IntResult = UserGroupRoleBAL.InsertUserGroupRole(UserIDNew, GroupRoleID, IsActive, LoginUser, Ret);
                    MsgGroup.Msg = "Record added Successfully.";
                    MsgGroup.showmsg();
                }
                else
                {
                    MsgGroup.Msg = "Duplicate Entry!";
                    MsgGroup.showmsg();
                    ddlGroupRole1.SelectedIndex = 0;
                }
            }
        }   
    }

    /// <summary>
    /// To Check duplication in Group Role for user
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="GroupRoleID"></param>
    /// <returns></returns>
    protected DataTable DuplicateGroupRoleCheck(int UserID, int GroupRoleID)
    {
        UserGroupRoleBAL UserGroupRoleBAL = new UserGroupRoleBAL();
        DataTable DtDupUser = new DataTable();
        try
        {
            DtDupUser = UserGroupRoleBAL.SelectUserGroupID(UserID, GroupRoleID, LoginUser, Ret);
        }
        catch (Exception ee)
        {
            throw;
        }
        finally
        {
            UserGroupRoleBAL = null;
        }
        return DtDupUser;
    }

    /// <summary>
    ///  To cancel action & reset to choose user page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        grdUserPerDetails.DataSource = null;
        grdUserPerDetails.DataBind();
        btnSave.Visible = false;
        btnCancel.Visible = false;
        ddlUserName.SelectedIndex = 0;
        Response.Redirect("UserList.aspx", false);
    }

    /// <summary>
    /// On dropdown User Change event for bind gridview with group role for Particular user
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlUserName_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlUserName.SelectedValue.ToString() != "<< Select >>")
        {
            ViewState["DtAddNew"] = null;
            int UserID = Convert.ToInt16(ddlUserName.SelectedValue.ToString());
            Session["UserID"] = UserID.ToString();
            BindUserPerGrid(UserID);
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }
        else
        {
            //CVUser.ValidationGroup = "gr";
            Session["UserID"] = null;
            ViewState["DtAddNew"] = null;
            grdUserPerDetails.DataSource = null;
            grdUserPerDetails.DataBind();
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }
    }

    /// <summary>
    /// To add new group role to particular user
    /// </summary>
    /// <param name="dtUserGroupRole"></param>
    private void gridAddNewBind(DataTable dtUserGroupRole)
    {
        foreach (GridViewRow grdRow in grdUserPerDetails.Rows)
        {
            DropDownList ddlGroupRole;
            ddlGroupRole = (DropDownList)(grdUserPerDetails.Rows[grdRow.RowIndex].Cells[1].FindControl("ddlGroupRoleDetails"));
            DataTable DtGroupRole = ddlGroupRoleDe();
            LinkButton lblIsActive = (grdUserPerDetails.Rows[grdRow.RowIndex].FindControl("lblisactive") as LinkButton);
            Label lblStatus = (grdUserPerDetails.Rows[grdRow.RowIndex].FindControl("lblstatus") as Label);
            string Status = lblIsActive.CommandArgument.ToString();
            if (Status == "True")
            {

                lblIsActive.Text = "DeActive";
                lblStatus.Text = "Active";
            }
            else if (Status == "False")
            {
                lblIsActive.Text = "Active";
                lblStatus.Text = "InActive";
            }
            else
            {
                lblIsActive.Text = "DeActive";
                lblStatus.Text = "Active";
            }

            if (DtGroupRole.Rows.Count > 0 || DtGroupRole != null)
            {
                ddlGroupRole.DataSource = DtGroupRole;
                ddlGroupRole.DataTextField = "GroupRole";
                ddlGroupRole.DataValueField = "GroupRoleID";
                ddlGroupRole.DataBind();
                ddlGroupRole.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                if (dtUserGroupRole.Rows[grdRow.RowIndex][9].ToString() != "")
                {
                    ddlGroupRole.SelectedValue = dtUserGroupRole.Rows[grdRow.RowIndex][9].ToString();
                    ddlGroupRole.Enabled = false;
                }
                else
                {
                    ddlGroupRole.SelectedIndex = 0;
                }
            }
            else
            {
                ddlGroupRole.DataSource = null;
                ddlGroupRole.DataTextField = "GroupRole";
                ddlGroupRole.DataValueField = "GroupRoleID";
                ddlGroupRole.DataBind();
                ddlGroupRole.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                ddlGroupRole.SelectedIndex = 0;
            }

        }
    }

    /// <summary>
    /// To Change status of User 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblisactive_Click1(object sender, EventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        GridViewRow row = (GridViewRow)lnk.Parent.Parent;
        int Idx = row.RowIndex;
        int IntResult = 0;
        int Status;
        int UserGroupRoleID;
        UserGroupRoleBAL user = new UserGroupRoleBAL();
        int UserID = Convert.ToInt16(ddlUserName.SelectedValue);
        LinkButton lblIsActive = (grdUserPerDetails.Rows[Idx].FindControl("lblisactive") as LinkButton);
        Label lblStatus = (grdUserPerDetails.Rows[Idx].FindControl("lblstatus") as Label);
        if (lblIsActive.CssClass.ToString() == "")
        {
            MsgGroup.Msg = "Please Save Record";
            MsgGroup.showmsg();
        }
        else
        {
            if (lblStatus.Text == "Active" || lblStatus.Text == "True")
            {
                Status = 0;
                lblStatus.Text = "InActive";
                lblIsActive.Text = "Active";
            }
            else
            {
                Status = 1;
                lblStatus.Text = "Active";
                lblIsActive.Text = "DeActive";
            }
            UserGroupRoleID = Convert.ToInt32(lblIsActive.CssClass.ToString());
            IntResult = user.UpdateUserGroupRole(UserGroupRoleID, Status, LoginUser, Ret);
        }
        BindUserPerGrid(UserID);
    }

   /// <summary>
    /// To check duplicate group role entry for particular user 
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void ddlGroupRoleDetails_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList ddlcheck = sender as DropDownList;
        GridViewRow grdrow = (GridViewRow)ddlcheck.Parent.Parent;
        int RowIndex = Convert.ToInt16(ddlcheck.CssClass.ToString());
        int UserID = Convert.ToInt16(ddlUserName.SelectedValue);
        int GroupRoleID = Convert.ToInt32(ddlcheck.SelectedValue);
        DataTable DtGRole = (DataTable)ViewState["DtAddNew"];
        DataView DataView = DtGRole.DefaultView;
        DataView.RowFilter = "UserID = " + UserID + " And GroupRoleID =" + GroupRoleID;
        DataTable DtGroupRole = DataView.ToTable();
        int Cnt = DtGroupRole.Rows.Count;
        if (Cnt > 0)
        {
            MsgGroup.Msg = "Duplicate Entry!";
            MsgGroup.showmsg();
            ddlcheck.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// To add new user group role permission details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        int VarUserID = Convert.ToInt32(Session["UserID"]);
        int Cnt = grdUserPerDetails.Rows.Count;
        if (ViewState["DtAddNew"] != null)
        {
            if (Cnt > 0)
            {
                DropDownList ddlGroupRole = (DropDownList)(grdUserPerDetails.Rows[Cnt - 1].Cells[0].FindControl("ddlGroupRoleDetails")); ;
                string GroupRole = ddlGroupRole.SelectedValue.ToString();
                DtAddNew = (DataTable)ViewState["DtAddNew"];
                if (GroupRole != "")
                {
                    DtAddNew.Rows[Cnt - 1][9] = GroupRole;
                    DtAddNew.Rows[Cnt - 1][2] = true;
                    DtAddNew.Rows[Cnt - 1][0] = VarUserID;
                }
            }
            DtAddNew.Rows.Add(DtAddNew.NewRow());
            grdUserPerDetails.DataSource = DtAddNew;
            grdUserPerDetails.DataBind();
            gridAddNewBind(DtAddNew);
            DtAddNew = DtAddNew.Copy();
        }
        else
        {
            DataTable grdata = GridUserDataSource(VarUserID);
            grdata.Rows.Add(grdata.NewRow());
            grdUserPerDetails.DataSource = grdata;
            grdUserPerDetails.DataBind();
            gridAddNewBind(grdata);
            DtAddNew = grdata.Copy();
            ViewState["DtAddNew"] = DtAddNew;
        }
        btnSave.Visible = true;
        btnCancel.Visible = true;
    }

    protected void imguserhelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/UserGroupRoleListHelp.docx");
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