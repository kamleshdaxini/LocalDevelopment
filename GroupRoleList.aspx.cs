using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using AjaxControlToolkit;
using System.IO;


public partial class GroupRoleList : System.Web.UI.Page
{
    // Initialization of public variables
    public string UserName;// For logged in username
    public int LoginUser;// For Logged in user Id
    public string Ret;// For return message
    string Ope, Col, Val;// For operator, Column, value 
    string Sort;// For Sorting
    DataTable DtSort;// For Sorting table
    DataView DvS;// For Sorting view
    int MenuID;// For Menu id
    DataTable DtAddNew = new DataTable();// for New grouprole table


    /// <summary>
    ///  Page load method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int Ind = MasterAcc.SelectedIndex;
        int Index = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = Index - 1;
        // To select loginuser id and login username
        Login objGroupRole = new Login();
        objGroupRole.Start();
        UserName = objGroupRole.LogedInUser;
        LoginUser = objGroupRole.LoginUser;
        Ret = objGroupRole.Ret;
        if (!IsPostBack)
        {
            // To sort defaulty by Ascending order
            ViewState["DtSortUser"] = "ASC";
            // To fetch GroupRole details having active status
            DataTable DtGrpRole = ActiveGridDataSource();
            ViewState["DtGrpRolUser"] = DtGrpRole;
            BindGrid(DtGrpRole);
        }
    }

    /// <summary>
    /// To bind Gridview by group details
    /// </summary>
    /// <param name="DtRole"></param>
    private void BindGrid(DataTable DtRole)
    {
        if (DtRole.Rows.Count > 0 || DtRole != null)
          {
              grdRoleDetails.DataSource = DtRole;
              grdRoleDetails.DataBind();
              for (int i = 0; i < grdRoleDetails.Rows.Count; i++)
              {
                  Label lblIsActive = (grdRoleDetails.Rows[i].FindControl("lblIsActive") as Label);
                  string Status = lblIsActive.CssClass.ToString();
                  if (Status == "True")
                  {                      
                      lblIsActive.Text = "Active";
                  }
                  else
                  {                     
                      lblIsActive.Text = "InActive";
                  }
              }     
          }
          else
          {
              grdRoleDetails.DataSource = null;
              grdRoleDetails.DataBind();
          }      
    }

    /// <summary>
    /// To get group Role details from Business logic layer
    /// </summary>
    /// <returns></returns>
    private DataTable GridDataSource()
    {
        GroupRoleBAL GroupRoleBAL = new GroupRoleBAL();        
        DataTable DtGridDet = new DataTable();
        try
        {
            DtGridDet = GroupRoleBAL.LoadAllGroupRole(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleBAL = null;
        }
        return DtGridDet;
    }

    /// <summary>
    /// To get Active Status group role details
    /// </summary>
    /// <returns></returns>
    private DataTable ActiveGridDataSource()
    {
        GroupRoleBAL GroupRoleBAL = new GroupRoleBAL();
        DataTable DtActSou = new DataTable();
        try
        {
            DtActSou = GroupRoleBAL.LoadActiveGroupRole(true, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleBAL = null;
        }
        return DtActSou;
    }

    /// <summary>
    /// To filter group role details by specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbFilter_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Col = ddlGroupRoleCol.Text; // For selected column in dropdownlist for search
        Val = txtGroupRoleVal.Text; // For selected value in dropdownlist for search
        DataTable DtFilter = GridDataSource(); // To filter table
        DataView DvSta = DtFilter.DefaultView; // to filter view
        if (Col == "IsActive")
        {
            Ope = ddlGroupRoleOpeSta.Text; // For Selected operator in dropdownlist
            Val = ddlGroupRoleSta.SelectedValue; // For Selected grouprole status in dropdownlist
            if ( Val == "Active")
            {
                Val = "true";
            }
            else if (Val == "InActive")
            {
                Val = "false";
            }
        }
        else
        {
            Ope = ddlGroupRoleOpe.Text;
        }
        if (Ope == "LIKE")
        {
            string GrpRolFilter = Col + " " + Ope + "'%" + Val + "%' ";
            DvSta.RowFilter = GrpRolFilter;

            if (DvSta.ToTable().Rows.Count == 0)
            {
                msgGrpRole.Msg = "Record(s) not found";
                msgGrpRole.showmsg();
                BindGrid(DvSta.ToTable());
            }
            else
            {
                ViewState["DtGrpRolUser"] = DvSta.ToTable();
                BindGrid(DvSta.ToTable());
            }
        }
        else if (Ope == "=")
        {
            DvSta.RowFilter = Col + Ope + "'" + Val + "'";
            if (DvSta.ToTable().Rows.Count == 0)
            {
                msgGrpRole.Msg = "Record(s) not found";
                msgGrpRole.showmsg();
                BindGrid(DvSta.ToTable());
            }
            else
            {
                ViewState["DtGrpRolUser"] = DvSta.ToTable();
                BindGrid(DvSta.ToTable());
            }
        }
        else if (Ope == "<>")
        {
            DvSta.RowFilter = Col + Ope + "'" + Val + "'";
            if (DvSta.ToTable().Rows.Count == 0)
            {
                msgGrpRole.Msg = "Record(s) not found";
                msgGrpRole.showmsg();
                BindGrid(DvSta.ToTable());
            }
            else
            {
                ViewState["DtGrpRolUser"] = DvSta.ToTable();
                BindGrid(DvSta.ToTable());
            }
        }
        else if (Ope == "NOT LIKE")
        {
            string GrpRolFilter = Col + " " + Ope + "'%" + Val + "%' ";
            DvSta.RowFilter = GrpRolFilter;
            if (DvSta.ToTable().Rows.Count == 0)
            {
                msgGrpRole.Msg = "Record(s) not found";
                msgGrpRole.showmsg();
                BindGrid(DvSta.ToTable());
            }
            else
            {
                ViewState["DtGrpRolUser"] = DvSta.ToTable();
                BindGrid(DvSta.ToTable());
            }
        }     
    }

    /// <summary>
    /// To change dropdown value for specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlGroupRoleCol_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroupRoleCol.Text == "RoleName" || ddlGroupRoleCol.Text == "GroupName")
        {
            td1.Visible = true;
            td2.Visible = false;
            td3.Visible = true;
            td4.Visible = false;
            cvGrpRoleOpeSta.Enabled = false;
            cvGroupRoleOpe.Enabled = true;
            cvGrpRoleStatus.Enabled = false;
            ddlGroupRoleSta.Visible = false;
            txtGroupRoleVal.Text = "";
        }
        else if (ddlGroupRoleCol.Text == "IsActive")
        {
            td2.Visible = true;
            td1.Visible = false;
            td3.Visible = false;
            td4.Visible = true;
            cvGroupRoleOpe.Enabled = false;
            cvGrpRoleOpeSta.Enabled = true;
            cvGrpRoleStatus.Enabled = true;
            ddlGroupRoleSta.Visible = true;
            txtGroupRoleVal.Text = "";
        }        
    }

    /// <summary>
    ///  To load active group role details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRefresh_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        DataTable DtRoleNew = ActiveGridDataSource();
        ViewState["DtAddNew"] = DtRoleNew;
        BindGrid(DtRoleNew);
    }

    /// <summary>
    /// To sort grid role name status wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkRoleName_Click(object sender, EventArgs e)
    {
        if (ViewState["DtSortUser"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtGrpRolUser"];
            DtSort.DefaultView.Sort = "RoleName" + " ASC";
            DvS = new DataView(DtSort);
            DvS.Sort = ("RoleName" + " ASC");
            Sort = "DESC";
            ViewState["DtGrpRolUser"] = DvS.ToTable();
            ViewState["DtSortUser"] = Sort;
        }
        else if (ViewState["DtSortUser"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtGrpRolUser"];
            DtSort.DefaultView.Sort = "RoleName" + " DESC";
            DvS = new DataView(DtSort);
            DvS.Sort = ("RoleName" + " DESC");
            Sort = "ASC";
            ViewState["DtGrpRolUser"] = DvS.ToTable();
            ViewState["DtSortUser"] = Sort;
        }
        BindGrid(DvS.ToTable());
    }

    /// <summary>
    /// To Sort grid group name status wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkGrpName_Click(object sender, EventArgs e)
    {
        if (ViewState["DtSortUser"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtGrpRolUser"];
            DtSort.DefaultView.Sort = "GroupName" + " ASC";
            DvS = new DataView(DtSort);
            DvS.Sort = ("GroupName" + " ASC");
            Sort = "DESC";
            ViewState["DtGrpRolUser"] = DvS.ToTable();
            ViewState["DtSortUser"] = Sort;
        }
        else if (ViewState["DtSortUser"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtGrpRolUser"];
            DtSort.DefaultView.Sort = "GroupName" + " DESC";
            DvS = new DataView(DtSort);
            DvS.Sort = ("GroupName" + " DESC");
            Sort = "ASC";
            ViewState["DtGrpRolUser"] = DvS.ToTable();
            ViewState["DtSortUser"] = Sort;
        }
        BindGrid(DvS.ToTable());
    }

    /// <summary>
    /// To Sort grid group role status wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkGrpRolestStatus_Click(object sender, EventArgs e)
    {
        if (ViewState["DtSortUser"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtGrpRolUser"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            DvS = new DataView(DtSort);
            DvS.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["DtGrpRolUser"] = DvS.ToTable();
            ViewState["DtSortUser"] = Sort;
        }
        else if (ViewState["DtSortUser"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtGrpRolUser"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            DvS = new DataView(DtSort);
            DvS.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["DtGrpRolUser"] = DvS.ToTable();
            ViewState["DtSortUser"] = Sort;
        }
        BindGrid(DvS.ToTable());
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdRoleDetails_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        grdRoleDetails.PageIndex = e.NewPageIndex;
        DataTable DtGroupRoleDet= (DataTable)ViewState["DtGrpRolUser"];
        BindGrid(DtGroupRoleDet);     
    }

    /// <summary>
    /// To change status of Group Role details
    /// </summary>
    /// <param name="GrId"></param>
    /// <param name="RoleId"></param>
    /// <param name="IsActive"></param>
    private void ChangeGroupRoleStatus(int GrId, int RoleId, bool IsActive)
    {
        GroupRoleBAL GroupRoleBAL = new GroupRoleBAL();
        try
        {
            int IntResult = GroupRoleBAL.UpdateGroupRole(GrId, IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRoleBAL = null;
        }
    }

    /// <summary>
    /// To load group Role permission details
    /// </summary>
    /// <param name="GrpId"></param>
    /// <returns></returns>
    private DataTable GetGroupRolePermissionDetails(int GrpId)
    {
        GroupRolePermissionBAL GroupRolePermissionBAL = new GroupRolePermissionBAL();
        DataTable DtGrpRolePer = new DataTable();
        try
        {
            DtGrpRolePer = GroupRolePermissionBAL.SelectGroupRolePermissionID(GrpId, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRolePermissionBAL = null;
        }
        return DtGrpRolePer;
    }

    /// <summary>
    /// To load submenu details from database
    /// </summary>
    /// <param name="MenuId"></param>
    /// <returns></returns>
    private DataTable GetSubMenudetails(int MenuId)
    {
        SubMenuBAL SubMenuBAL = new SubMenuBAL();
        DataTable DtSubMenuDet = new DataTable();
        try
        {
            DtSubMenuDet = SubMenuBAL.SelectMenuID(MenuId, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            SubMenuBAL = null;
        }
        return DtSubMenuDet;
    }

    /// <summary>
    /// To load permission details from database
    /// </summary>
    /// <returns></returns>
    private DataTable GetPermissionDetails()
    {
        PermissionBAL PermissionBAL = new PermissionBAL();
        DataTable DtPerDet = new DataTable();
        try
        {
            DtPerDet = PermissionBAL.LoadPermission(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            PermissionBAL = null;
        }
        return DtPerDet;
    }

    /// <summary>
    /// To load menu details from database
    /// </summary>
    /// <returns></returns>
    private DataTable GetMenuDetails()
    {
        MenuBAL MenuBAL = new MenuBAL();
        DataTable DtMenuDet = new DataTable();
        try
        {
            DtMenuDet = MenuBAL.LoadAllMenu(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            MenuBAL = null;
        }
        return DtMenuDet;
    }

    /// <summary>
    /// To update group role permission details
    /// </summary>
    /// <param name="GrpId"></param>
    /// <param name="PerId"></param>
    /// <param name="IsActive"></param>
    /// <param name="LoginUserId"></param>
    /// <param name="Ret"></param>
    /// <returns></returns>
    private int UpdateGrpDetails(int GrpId, int PerId, bool IsActive, int LoginUserId, string Ret)
    {
        GroupRolePermissionBAL GroupRolePermissionBAL = new GroupRolePermissionBAL();
        int InRes = 0;
        try
        {
            InRes = GroupRolePermissionBAL.UpdateGroupRolePermission(GrpId, PerId, IsActive, LoginUserId, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRolePermissionBAL = null;
        }
        return InRes;
    }

    /// <summary>
    /// To insert group role permission details
    /// </summary>
    /// <param name="GrId"></param>
    /// <param name="SubMenuID"></param>
    /// <param name="PerId"></param>
    /// <param name="IsActive"></param>
    /// <param name="LoginUserId"></param>
    /// <param name="Ret"></param>
    /// <returns></returns>
    private int InsertGrpDetails(int GrId, int SubMenuID, int PerId, bool IsActive, int LoginUserId, string Ret)
    {
        GroupRolePermissionBAL GroupRolePermissionBAL = new GroupRolePermissionBAL();
        int InRes = 0;
        try
        {
            InRes = GroupRolePermissionBAL.InsertGroupRolePermission(GrId, SubMenuID, PerId, IsActive, LoginUserId, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            GroupRolePermissionBAL = null;
        }
        return InRes;
    }

    /// <summary>
    /// To save permission details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (grdGrpView.Rows.Count > 0)
        {
            for (int i = 0; i < grdGrpView.Rows.Count; i++)
            {
                LinkButton lnkStatus = (LinkButton)this.grdGrpView.Rows[i].FindControl("lnkIsActSta");
                string Status = lnkStatus.CommandArgument.ToString();
                string Check = lnkStatus.CssClass.ToString();
                bool GrpSta = false;
                if (Status == "True")
                {
                    GrpSta = true;
                }
                else if (Status == "False")
                {
                    GrpSta = false;
                }
                DropDownList ddlSubMenu = (DropDownList)this.grdGrpView.Rows[i].FindControl("ddlSubMenu");
                int SubMenuId = Convert.ToInt16(ddlSubMenu.SelectedValue);
                DropDownList ddlSubMenuPer = (DropDownList)this.grdGrpView.Rows[i].FindControl("ddlPermission");
                int PerMenuId = Convert.ToInt16(ddlSubMenuPer.SelectedValue);
                int GrId = Convert.ToInt16(Session["GRPID"].ToString());
                if (Check != "")
                {
                    int GrpId = Convert.ToInt16(Check);
                    int IntResult = UpdateGrpDetails(GrpId, PerMenuId, GrpSta, LoginUser, Ret);
                }
                else
                {
                    int IntResult = InsertGrpDetails(GrId, SubMenuId, PerMenuId, GrpSta, LoginUser, Ret);
                }
            }
        }
        msgGrpRole.Msg = "Group Role Information Submited Successfully";
        msgGrpRole.showmsg();
        ViewState["DtAddNew"] = null;
        Session["GRPID"] = null;
        mpopGrpRole.Hide();
    }

    /// <summary>
    /// To bind Menu dropdown with existing menu
    /// </summary>
    /// <param name="grpId"></param>
    /// <returns></returns>
    private int gridMenuBind(int grpId)
    {
        DataTable DtGrpRolePer = GetGroupRolePermissionDetails(grpId);
        if (DtGrpRolePer.Rows.Count > 0)
        {
            grdGrpView.DataSource = DtGrpRolePer;
            grdGrpView.DataBind();
            for (int i = 0; i < DtGrpRolePer.Rows.Count; i++)
            {
                LinkButton lnkIsActSta = (LinkButton)this.grdGrpView.Rows[i].FindControl("lnkIsActSta");
                Label lblIsActS = (Label)this.grdGrpView.Rows[i].FindControl("lblStatus");
                string Status = lnkIsActSta.CommandArgument.ToString();
                lnkIsActSta.Font.Underline = true;
                if (Status == "True")
                {
                    lnkIsActSta.Text = "Deactivate";
                    lblIsActS.Text = "Active";
                }
                else if (Status == "False")
                {
                    lnkIsActSta.Text = "Activate";
                    lblIsActS.Text = "InActive";
                }
                DropDownList ddlMenu;
                ddlMenu = (DropDownList)(grdGrpView.Rows[i].Cells[0].FindControl("ddlMenu"));
                DataTable DtMenu = GetMenuDetails();
                if (DtMenu.Rows.Count > 0 || DtMenu != null)
                {
                    ddlMenu.DataSource = DtMenu;
                    ddlMenu.DataTextField = "MenuName";
                    ddlMenu.DataValueField = "MenuId";
                    ddlMenu.DataBind();
                    ddlMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    ddlMenu.SelectedValue = DtGrpRolePer.Rows[i][3].ToString();
                    ddlMenu.Enabled = false;
                    gridSubMenuBind(Convert.ToInt16(ddlMenu.SelectedValue), i, DtGrpRolePer.Rows[i][4].ToString());
                    gridPermissionBind(i, DtGrpRolePer.Rows[i][10].ToString());
                    mpopGrpRole.Show();
                }
                else
                {
                    ddlMenu.DataSource = null;
                    ddlMenu.DataTextField = "MenuName";
                    ddlMenu.DataValueField = "MenuId";
                    ddlMenu.DataBind();
                    ddlMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    ddlMenu.SelectedIndex = 0;
                }
            }
            return 1;
        }
        else
        {
            grdGrpView.DataSource = DtGrpRolePer;
            grdGrpView.DataBind();
            return 0;
        }
    }

    /// <summary>
    /// To bind grid when add new group role permission
    /// </summary>
    /// <param name="DtGrpRolePer"></param>
    private void gridAddNewBind(DataTable DtGrpRolePer)
    {
        if (DtGrpRolePer.Rows.Count > 0)
        {
            for (int i2 = 0; i2 < DtGrpRolePer.Rows.Count; i2++)
            {
                DropDownList ddlMenu;
                ddlMenu = (DropDownList)(grdGrpView.Rows[i2].Cells[0].FindControl("ddlMenu"));
                LinkButton lnkIsAct = (LinkButton)this.grdGrpView.Rows[i2].FindControl("lnkIsActSta");
                Label lblIsActSta = (Label)this.grdGrpView.Rows[i2].FindControl("lblStatus");
                string Status = lnkIsAct.CommandArgument.ToString();
                lnkIsAct.Font.Underline = true;
                if (Status == "True")
                {
                    lnkIsAct.Text = "Deactivate";
                    lblIsActSta.Text = "Active";
                }
                else if (Status == "False")
                {
                    lnkIsAct.Text = "Activate";
                    lblIsActSta.Text = "InActive";
                }
                DataTable DtMenu = GetMenuDetails();
                if (DtMenu.Rows.Count > 0 || DtMenu != null)
                {
                    ddlMenu.DataSource = DtMenu;
                    ddlMenu.DataTextField = "MenuName";
                    ddlMenu.DataValueField = "MenuId";
                    ddlMenu.DataBind();
                    ddlMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    string VarMenuIDnew = DtGrpRolePer.Rows[i2][3].ToString();
                    if (VarMenuIDnew != "")
                    {
                        ddlMenu.SelectedValue = DtGrpRolePer.Rows[i2][3].ToString();
                        ddlMenu.Enabled = false;
                        gridSubMenuBind(Convert.ToInt16(ddlMenu.SelectedValue), i2, DtGrpRolePer.Rows[i2][4].ToString());
                        gridPermissionBind(i2, DtGrpRolePer.Rows[i2][10].ToString());
                    }
                    else
                    {
                        ddlMenu.SelectedIndex = 0;
                    }
                }
                else
                {
                    ddlMenu.DataSource = null;
                    ddlMenu.DataTextField = "MenuName";
                    ddlMenu.DataValueField = "MenuId";
                    ddlMenu.DataBind();
                    ddlMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    ddlMenu.SelectedIndex = 0;
                }
            }
        }
    }

    /// <summary>
    /// To bind permission dropdownlist in grid
    /// </summary>
    /// <param name="grdndex"></param>
    /// <param name="Selectedvalue"></param>
    private void gridPermissionBind(int grdndex, string Selectedvalue)
    {
        foreach (GridViewRow grdRow in grdGrpView.Rows)
        {
            if (grdRow.RowIndex == grdndex)
            {
                DropDownList ddlper;
                ddlper = (DropDownList)(grdGrpView.Rows[grdRow.RowIndex].Cells[0].FindControl("ddlPermission"));
                DataTable DtGroupPer = GetPermissionDetails();
                if (DtGroupPer.Rows.Count > 0 || DtGroupPer != null)
                {
                    ddlper.DataSource = DtGroupPer;
                    ddlper.DataTextField = "PermissionName";
                    ddlper.DataValueField = "PermissionID";
                    ddlper.DataBind();
                    ddlper.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    ddlper.SelectedIndex = 0;
                    if (Selectedvalue != null)
                    {
                        ddlper.SelectedValue = Selectedvalue;
                    }
                }
                else
                {
                    ddlper.DataSource = null;
                    ddlper.DataTextField = "PermissionName";
                    ddlper.DataValueField = "PermissionID";
                    ddlper.DataBind();
                    ddlper.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    ddlper.SelectedIndex = 0;
                }
            }
        }
    }

    /// <summary>
    /// To bind Submenu by menu wise in dropdown in gridview
    /// </summary>
    /// <param name="MenuId"></param>
    /// <param name="grdndex"></param>
    /// <param name="Selectedvalue"></param>
    private void gridSubMenuBind(int MenuId, int grdndex, string Selectedvalue)
    {
        foreach (GridViewRow grdRow in grdGrpView.Rows)
        {
            if (grdRow.RowIndex == grdndex)
            {
                DropDownList ddlSubMenu;
                ddlSubMenu = (DropDownList)(grdGrpView.Rows[grdRow.RowIndex].Cells[0].FindControl("ddlSubMenu"));
                DataTable DtGroup = GetSubMenudetails(MenuId);
                if (DtGroup.Rows.Count > 0 || DtGroup != null)
                {
                    ddlSubMenu.DataSource = DtGroup;
                    ddlSubMenu.DataTextField = "SubMenuName";
                    ddlSubMenu.DataValueField = "SubMenuID";
                    ddlSubMenu.DataBind();
                    ddlSubMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    ddlSubMenu.SelectedIndex = 0;
                    if (Selectedvalue != null)
                    {
                        ddlSubMenu.SelectedValue = Selectedvalue;
                        ddlSubMenu.Enabled = false;
                    }
                }
                else
                {
                    ddlSubMenu.DataSource = DtGroup;
                    ddlSubMenu.DataTextField = "SubMenuName";
                    ddlSubMenu.DataValueField = "SubMenuID";
                    ddlSubMenu.DataBind();
                    ddlSubMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    ddlSubMenu.SelectedIndex = 0;
                }
            }
        }
    }

    /// <summary>
    /// To bind submenu on menu dropdownlist selected change event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlSubMenu = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlSubMenu.Parent.Parent;
        int idx = row.RowIndex;
        if (ddlSubMenu.SelectedIndex != 0)
        {
            MenuID = Convert.ToInt16(ddlSubMenu.SelectedValue);
            gridSubMenuBind(MenuID, idx, null);
        }
        mpopGrpRole.Show();
    }

    /// <summary>
    /// To check wheather duplicate submenu is not link to menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlSubMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlSubMenu = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlSubMenu.Parent.Parent;
        int Idx = row.RowIndex;
        int cntCheck = 0;
        int SelectedSubMenu = Convert.ToInt16(ddlSubMenu.SelectedValue);
        for (int i = 0; i < Idx; i++)
        {
            DropDownList ddlSubMenunew = (DropDownList)(grdGrpView.Rows[i].Cells[0].FindControl("ddlSubMenu"));
            int submenu = Convert.ToInt16(ddlSubMenunew.SelectedValue);
            if (SelectedSubMenu == submenu)
            {
                cntCheck = 1;
            }
        }
        gridPermissionBind(Idx, null);
        mpopGrpRole.Show();
        if (cntCheck == 1)
        {
            ddlSubMenu.SelectedIndex = 0;
            msgGrpRole.Msg = "Duplicate Entry";
            msgGrpRole.showmsg();
        }
    }

    /// <summary>
    /// To activate group role details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkIsActive_Click(object sender, EventArgs e)
    {
        LinkButton lnkActive = sender as LinkButton;
        int GrId = Convert.ToInt16(lnkActive.CssClass.ToString());
        GridViewRow row = (GridViewRow)lnkActive.Parent.Parent;
        int Idx = row.RowIndex;
        DropDownList ddlrole = (DropDownList)grdRoleDetails.Rows[Idx].FindControl("cmbRoleName");
        int RoleId = Convert.ToInt16(ddlrole.SelectedValue);
        string Status = lnkActive.Text;
        bool VarStatus = false;
        if (Status == "Deactivate")
        {
            VarStatus = false;
        }
        else
        {
            VarStatus = true;
        }
        ChangeGroupRoleStatus(GrId, RoleId, VarStatus);
    }

    /// <summary>
    /// To activate or deactive menu for particular group role
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkIsActSta_Click(object sender, EventArgs e)
    {
        LinkButton lnkActive = sender as LinkButton;
        string chk = lnkActive.CssClass.ToString();
        if (chk != "")
        {
            int varGrpId = Convert.ToInt16(lnkActive.CssClass.ToString());
            GridViewRow row = (GridViewRow)lnkActive.Parent.Parent;
            int idx1 = row.RowIndex;
            DropDownList ddlper = (DropDownList)grdGrpView.Rows[idx1].FindControl("ddlPermission");
            int varPermissionId = Convert.ToInt16(ddlper.SelectedValue);
            string status = lnkActive.Text;
            bool VarStatus = false;
            if (status == "Activate")
            {
                VarStatus = true;
            }
            else if (status == "Deactivate")
            {

                VarStatus = false;
            }
            UpdateGrpDetails(varGrpId, varPermissionId, VarStatus, LoginUser, Ret);       
            imbpermission_Click(sender, null);
            mpopGrpRole.Show();
        }
        else
        {
            msgGrpRole.Msg = "Please First Save the Record";
            msgGrpRole.showmsg();
            mpopGrpRole.Show();
        }
    }

    /// <summary>
    /// To cancel current operation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelPer_Click(object sender, EventArgs e)
    {
        ViewState["DtAddNew"] = null;
        Session["GRPID"] = null;
        mpopGrpRole.Hide();
    }

    /// <summary>
    /// To bind permission grid
    /// </summary>
    /// <param name="dtgrdperm"></param>
    private void BindGrdpermission(DataTable dtgrdperm)
    {
        grdGrpView.DataSource = dtgrdperm;
        grdGrpView.DataBind();
        for (int i = 0; i < dtgrdperm.Rows.Count; i++)
        {
            LinkButton lnkIsActive = (LinkButton)this.grdGrpView.Rows[i].FindControl("lnkIsActSta");
            Label lblStatus = (Label)this.grdGrpView.Rows[i].FindControl("lblStatus");
            string status = lnkIsActive.CommandArgument.ToString();
            if (status == "True")
            {
                lnkIsActive.Text = "Deactivate";
                lblStatus.Text = "Active";
            }
            else if (status == "False")
            {
                lnkIsActive.Text = "Activate";
                lblStatus.Text = "InActive";
            }
        }
    }

    /// <summary>
    /// To add new Group Role Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Session["GroupRoleId"] = null;
        Response.Redirect("GroupRoleDetails.aspx", false);
    }

    // To add new permission to Group Role
    protected void lnkAddNewPer_Click(object sender, EventArgs e)
    {
        int VarGrpIdNew = Convert.ToInt16(Session["GRPID"]);
        if (ViewState["DtAddNew"] != null)
        {
            int Cnt = grdGrpView.Rows.Count;
            if (Cnt > 0)
            {
                DropDownList ddlper;
                ddlper = (DropDownList)(grdGrpView.Rows[Cnt - 1].Cells[0].FindControl("ddlPermission"));
                DropDownList ddlMenu;
                ddlMenu = (DropDownList)(grdGrpView.Rows[Cnt - 1].Cells[0].FindControl("ddlMenu"));
                DropDownList ddlSubMenu;
                ddlSubMenu = (DropDownList)(grdGrpView.Rows[Cnt - 1].Cells[0].FindControl("ddlSubMenu"));
                string Menu = ddlMenu.SelectedValue.ToString();
                string SMenu = ddlSubMenu.SelectedValue.ToString();
                string Per = ddlper.SelectedValue.ToString();
                DtAddNew = (DataTable)ViewState["DtAddNew"];
                DtAddNew.Rows[Cnt - 1][3] = Menu;
                DtAddNew.Rows[Cnt - 1][4] = SMenu;
                DtAddNew.Rows[Cnt - 1][10] = Per;
            }
            DtAddNew.Rows.Add(DtAddNew.NewRow());
            int grdcnt = DtAddNew.Rows.Count;
            DtAddNew.Rows[grdcnt - 1][12] = "True";
            BindGrdpermission(DtAddNew);
            gridAddNewBind(DtAddNew);
            DtAddNew = DtAddNew.Copy();
        }
        else
        {
            DataTable DtGrData = GetGroupRolePermissionDetails(VarGrpIdNew);
            DtGrData.Rows.Add(DtGrData.NewRow());
            int grdcnt = DtGrData.Rows.Count;
            DtGrData.Rows[grdcnt - 1][12] = "True";
            BindGrdpermission(DtGrData);
            gridAddNewBind(DtGrData);
            DtAddNew = DtGrData.Copy();
            ViewState["DtAddNew"] = DtAddNew;
        }
        mpopGrpRole.Show();
    }

    /// <summary>
    /// To edit group role details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imb = sender as ImageButton;
        int GroupRoleId = Convert.ToInt32(imb.CommandArgument.ToString());
        lblSelectID.Text = GroupRoleId.ToString();
        Session["GroupRoleId"] = lblSelectID.Text;
        Response.Redirect("GroupRoleDetails.aspx", false);       
    }

    /// <summary>
    /// To show permission popup for particular group role
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbpermission_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imbpermission = sender as ImageButton;
        int GrpID;
        if(imbpermission==null)
        {      
            GrpID = Convert.ToInt16(Session["GRPID"]);
            gridMenuBind(GrpID);
            mpopGrpRole.Show();
        }
        else
        {
            GridViewRow Rw = (GridViewRow)imbpermission.Parent.Parent;
            int RwIndx = Rw.RowIndex;
            Label lblRoleName = (Label)this.grdRoleDetails.Rows[RwIndx].Cells[0].FindControl("lblRlName");
            Label lblGroupName = (Label)this.grdRoleDetails.Rows[RwIndx].Cells[0].FindControl("lblGropName");
            string RoleName = lblRoleName.Text;
            string GroupName = lblGroupName.Text;
            lblGroup.Text = GroupName;
            lblRole.Text = RoleName;
            GrpID = Convert.ToInt16(imbpermission.CommandArgument.ToString());
            int ReCnt = gridMenuBind(GrpID);
            if (ReCnt == 0)
            {
                Session["GRPID"] = GrpID.ToString();
                msgGrpRole.Msg = "Record(s) not found";
                msgGrpRole.showmsg();
                mpopGrpRole.Show();
            }
            else
            {
                Session["GRPID"] = GrpID.ToString();
                mpopGrpRole.Show();
            }
        }
    }
    protected void imguserhelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/GroupRoleListHelp.pdf");
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