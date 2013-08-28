using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

public partial class GroupRolePerdetails : System.Web.UI.Page
{
    public  string Useraname;
    public  int LoginUser;
    public  string Ret;
    int vargroupID;
    int varMenuID;
    DataTable dtAddNew = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Accordion masteracc = (Accordion)Master.FindControl("acdnMaster");
        int ind = masteracc.SelectedIndex;
        int inx = Convert.ToInt16(Session["SrNo"]);
        masteracc.SelectedIndex = inx - 1;
        Login obj = new Login();
        obj.Start();
        Useraname = obj.LogedInUser;
        LoginUser = obj.LoginUser;
        Ret = obj.Ret;
        if (!Page.IsPostBack)
        {
            bindGroupcmb();
        }
       
    }


    private void ChnageGroupRoleStatus(int grId, int roleid, bool IsActive)
    {
       
        GroupRoleBAL gr = new GroupRoleBAL();
        DataTable dTable = new DataTable();
        try
        {
            int res = gr.UpdateGroupRole(grId, IsActive, LoginUser, Ret);

        }
        catch
        {

        }
        finally
        {
            gr = null;
        }


    }
    private DataTable getGroupRolePermissiondetails(int grpId)
    {
        GroupRolePermissionBAL grp = new GroupRolePermissionBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = grp.SelectGroupRolePermissionID(grpId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            grp = null;
        }

        return dTable;
    }

    private DataTable getGrpdetails(int groupId)
    {
        GroupRoleBAL grp = new GroupRoleBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = grp.SelectGroupID(true, groupId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            grp = null;
        }

        return dTable;
    }


    private DataTable getRoledetails(int Groupid)
    {
        GroupRoleBAL gr = new GroupRoleBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = gr.SelectGroupID(true, Groupid, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            gr = null;
        }

        return dTable;
    }
    private DataTable getGroupdetails()
    {
        GroupBAL g = new GroupBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = g.LoadActiveGroup(true, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            g = null;
        }

        return dTable;
    }
    private DataTable getSubMenudetails(int menuId)
    {

        SubMenuBAL s = new SubMenuBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = s.SelectMenuID(menuId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            s = null;
        }

        return dTable;
    }
    private DataTable getPermissiondetails()
    {

        PermissionBAL p = new PermissionBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = p.LoadPermission(LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            p = null;
        }

        return dTable;
    }
    private DataTable getGrpPermissiondetails(int grpid)
    {

        GroupRolePermissionBAL p = new GroupRolePermissionBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = p.SelectGroupRolePermissionID(grpid, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            p = null;
        }

        return dTable;
    }
    private DataTable getMenudetails()
    {

        MenuBAL m = new MenuBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = m.LoadAllMenu(LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            m = null;
        }

        return dTable;
    }
    private int Updategrpdetails(int grpId, int perid, bool IsActive, int LoginUserid, string Ret)
    {

        GroupRolePermissionBAL grp = new GroupRolePermissionBAL();
        int inres = 0;
        try
        {
            inres = grp.UpdateGroupRolePermission(grpId, perid, IsActive, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            grp = null;
        }

        return inres;
    }
    private int Insertgrpdetails(int grId, int SubMenuID, int perid, bool IsActive, int LoginUserid, string Ret)
    {

        GroupRolePermissionBAL grp = new GroupRolePermissionBAL();
        int inres = 0;
        try
        {
            inres = grp.InsertGroupRolePermission(grId, SubMenuID, perid, IsActive, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            grp = null;
        }

        return inres;
    }
    private void bindGroupcmb()
    {

        DataTable groupdt = getGroupdetails();
        if (groupdt.Rows.Count > 0 || groupdt != null)
        {
            cmbGroupName.DataSource = getGroupdetails();
            cmbGroupName.DataTextField = "GroupName";
            cmbGroupName.DataValueField = "GroupId";
            cmbGroupName.DataBind();
            cmbGroupName.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            cmbGroupName.SelectedIndex = 0;
        }
        else
        {
            cmbGroupName.DataSource = null;
            cmbGroupName.DataTextField = "GroupName";
            cmbGroupName.DataValueField = "GroupId";
            cmbGroupName.DataBind();
            cmbGroupName.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            cmbGroupName.SelectedIndex = 0;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (grdGrpView.Rows.Count > 0)
        {
            for (int i = 0; i < grdGrpView.Rows.Count; i++)
            {
                LinkButton lnkstatus = (LinkButton)this.grdGrpView.Rows[i].FindControl("lnkisActive1");
                string status = lnkstatus.CommandArgument.ToString();
                bool grpstatus1 = false;
                if (status == "True")
                {
                    grpstatus1 = true;
                }
                else if (status == "False")
                {
                    grpstatus1 = false;
                }

                LinkButton lnkgrpid = (LinkButton)this.grdGrpView.Rows[i].FindControl("lnkAddNew1");
                string check = lnkgrpid.CommandArgument.ToString();
                DropDownList cmbSubmenu = (DropDownList)this.grdGrpView.Rows[i].FindControl("cmbSubMenu");
                int submenuid = Convert.ToInt16(cmbSubmenu.SelectedValue);
                DropDownList cmbSPer = (DropDownList)this.grdGrpView.Rows[i].FindControl("cmbPermission");
                int Permenuid = Convert.ToInt16(cmbSPer.SelectedValue);
                int grid = Convert.ToInt16(Session["GRPID"].ToString());
                if (check != "")
                {
                    int grpid = Convert.ToInt16(lnkgrpid.CommandArgument.ToString());
                    int res = Updategrpdetails(grpid, Permenuid, grpstatus1, LoginUser, Ret);
                }
                else
                {
                    int res = Insertgrpdetails(grid, submenuid, Permenuid, grpstatus1, LoginUser, Ret);
                }

            }
        }
        msg1.Msg = "Group Role Information Submited Successfully";
        msg1.showmsg();
        ViewState["dtaddnew"] = null;
        Session["GRPID"] = null;
      
    }
    protected void cmbGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbGroupName.SelectedIndex == 0)
        {
            grdgrpdetails.DataSource = null;
            grdgrpdetails.DataBind();
        }
        else
        {
            vargroupID = Convert.ToInt16(cmbGroupName.SelectedValue);
            gridRoleBind(vargroupID);
        }

    }
    private void gridRoleBind(int GroupId)
    {

        DataTable grpdt = getGrpdetails(GroupId);
        if (grpdt.Rows.Count>0)
        {
            grdgrpdetails.DataSource = grpdt;
            grdgrpdetails.DataBind();
            for (int j = 0; j < grdgrpdetails.Rows.Count; j++)
            {
                LinkButton lnkisactive = (LinkButton)this.grdgrpdetails.Rows[j].FindControl("lnkIsActive");
                string status = lnkisactive.CommandArgument.ToString();
                Label lblisactive = (Label)this.grdgrpdetails.Rows[j].FindControl("lblgrstatus");
                lnkisactive.Font.Underline = true;
                if (status == "True")
                {
                    lnkisactive.Text = "Deactivate";
                    lblisactive.Text = "Active";
                }
                else if (status == "False")
                {
                    lnkisactive.Text = "Activate";
                    lblisactive.Text = "InActive";
                }
                DropDownList cmbRole;
                cmbRole = (DropDownList)(grdgrpdetails.Rows[j].Cells[0].FindControl("cmbRoleName"));
                // here i am binding the DropDownList with the dataset ds
                DataTable groupdt = getRoledetails(GroupId);
                if (groupdt.Rows.Count > 0 || groupdt != null)
                {
                    cmbRole.DataSource = getRoledetails(GroupId);
                    cmbRole.DataTextField = "RoleName";
                    cmbRole.DataValueField = "RoleId";
                    cmbRole.DataBind();
                    cmbRole.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    cmbRole.SelectedValue = grpdt.Rows[j][3].ToString();
                    cmbRole.Enabled = false;
                }
                else
                {
                    cmbRole.DataSource = null;
                    cmbRole.DataTextField = "RoleName";
                    cmbRole.DataValueField = "RoleId";
                    cmbRole.DataBind();
                    cmbRole.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    cmbRole.SelectedIndex = 0;
                }
            }

        }
        else
        {
            grdgrpdetails.DataSource = null;
            grdgrpdetails.DataBind();
            msg1.Msg = "Record(s) not Found";
            msg1.showmsg();
        }


    }
    private int gridMenuBind(int grpId)
    {

        DataTable grpdt = getGroupRolePermissiondetails(grpId);
        if (grpdt!=null)
        {               
            grdGrpView.DataSource = grpdt;
            grdGrpView.DataBind();
            for (int i = 0; i < grpdt.Rows.Count; i++)
            {
                LinkButton lnkisactive2 = (LinkButton)this.grdGrpView.Rows[i].FindControl("lnkIsActive1");
                Label lblisactive1 = (Label)this.grdGrpView.Rows[i].FindControl("lblStatus");
                string status = lnkisactive2.CommandArgument.ToString();
                lnkisactive2.Font.Underline = true;
                if (status == "True")
                {
                    lnkisactive2.Text = "Deactivate";
                    lblisactive1.Text = "Active";
                }
                else if (status == "False")
                {
                    lnkisactive2.Text = "Activate";
                    lblisactive1.Text = "InActive";
                }
                DropDownList cmbMenu;
                cmbMenu = (DropDownList)(grdGrpView.Rows[i].Cells[0].FindControl("cmbMenu"));
                // here i am binding the DropDownList with the dataset ds
                DataTable Menudt = getMenudetails();
                if (Menudt.Rows.Count > 0 || Menudt != null)
                {
                    cmbMenu.DataSource = Menudt;
                    cmbMenu.DataTextField = "MenuName";
                    cmbMenu.DataValueField = "MenuId";
                    cmbMenu.DataBind();
                    cmbMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    cmbMenu.SelectedValue = grpdt.Rows[i][3].ToString();
                    cmbMenu.Enabled = false;
                    gridSubMenuBind(Convert.ToInt16(cmbMenu.SelectedValue), i, grpdt.Rows[i][4].ToString());
                    gridPermissionBind(i, grpdt.Rows[i][10].ToString());
                    mpop1.Show();

                }
                else
                {
                    cmbMenu.DataSource = null;
                    cmbMenu.DataTextField = "MenuName";
                    cmbMenu.DataValueField = "MenuId";
                    cmbMenu.DataBind();
                    cmbMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    cmbMenu.SelectedIndex = 0;
                }

            }
           
            //grdGrpView.DataSource = grpdt;
            //grdGrpView.DataBind();
            return 1;
        }
        else
        {
            grdgrpdetails.DataSource = null;
            grdgrpdetails.DataBind();
        
            return 0;
        }
       

    }
    private void gridAddNewBind(DataTable grpdt)
    {


        if (grpdt.Rows.Count > 0)
        {
            for (int i2 = 0; i2 < grpdt.Rows.Count; i2++)
            {

                DropDownList cmbMenu;
                cmbMenu = (DropDownList)(grdGrpView.Rows[i2].Cells[0].FindControl("cmbMenu"));
                // here i am binding the DropDownList with the dataset ds
                LinkButton lnkisactive3 = (LinkButton)this.grdGrpView.Rows[i2].FindControl("lnkIsActive1");
                Label lblisactive1 = (Label)this.grdGrpView.Rows[i2].FindControl("lblStatus");
                string status = lnkisactive3.CommandArgument.ToString();
                lnkisactive3.Font.Underline = true;
                if (status == "True")
                {
                    lnkisactive3.Text = "Deactivate";
                    lblisactive1.Text = "Active";
                }
                else if (status == "False")
                {
                    lnkisactive3.Text = "Activate";
                    lblisactive1.Text = "InActive";
                }
                DataTable Menudt = getMenudetails();
                if (Menudt.Rows.Count > 0 || Menudt != null)
                {
                    cmbMenu.DataSource = Menudt;
                    cmbMenu.DataTextField = "MenuName";
                    cmbMenu.DataValueField = "MenuId";
                    cmbMenu.DataBind();
                    cmbMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    string varmenuidnew = grpdt.Rows[i2][3].ToString();
                    if (varmenuidnew != "")
                    {
                        cmbMenu.SelectedValue = grpdt.Rows[i2][3].ToString();
                        cmbMenu.Enabled = false;
                        gridSubMenuBind(Convert.ToInt16(cmbMenu.SelectedValue), i2, grpdt.Rows[i2][4].ToString());
                        gridPermissionBind(i2, grpdt.Rows[i2][10].ToString());
                    }
                    else
                    {
                        cmbMenu.SelectedIndex = 0;
                    }
                }
                else
                {
                    cmbMenu.DataSource = null;
                    cmbMenu.DataTextField = "MenuName";
                    cmbMenu.DataValueField = "MenuId";
                    cmbMenu.DataBind();
                    cmbMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    cmbMenu.SelectedIndex = 0;
                }
            }
        }

    }
    private void gridPermissionBind(int grdndex, string Selectedvalue)
    {

        foreach (GridViewRow grdRow in grdGrpView.Rows)
        {
            // here i am definning the property of the DropDownList as bind_dropdownlist
            // DropDownList bind_dropdownlist = new DropDownList();
            // here i am finding the  DropDownList from the gridiew for        binding
            if (grdRow.RowIndex == grdndex)
            {
                DropDownList cmbper;
                cmbper = (DropDownList)(grdGrpView.Rows[grdRow.RowIndex].Cells[0].FindControl("cmbPermission"));
                // here i am binding the DropDownList with the dataset ds
                DataTable groupdt = getPermissiondetails();
                if (groupdt.Rows.Count > 0 || groupdt != null)
                {
                    cmbper.DataSource = groupdt;
                    cmbper.DataTextField = "PermissionName";
                    cmbper.DataValueField = "PermissionID";
                    cmbper.DataBind();
                    cmbper.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    cmbper.SelectedIndex = 0;
                    if (Selectedvalue != null)
                    {
                        cmbper.SelectedValue = Selectedvalue;
                    }
                }
                else
                {
                    cmbper.DataSource = null;
                    cmbper.DataTextField = "PermissionName";
                    cmbper.DataValueField = "PermissionID";
                    cmbper.DataBind();
                    cmbper.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    cmbper.SelectedIndex = 0;
                }
            }

        }
    }
    private void gridSubMenuBind(int MenuId, int grdndex, string Selectedvalue)
    {

        foreach (GridViewRow grdRow in grdGrpView.Rows)
        {
            // here i am definning the property of the DropDownList as bind_dropdownlist
            // DropDownList bind_dropdownlist = new DropDownList();
            // here i am finding the  DropDownList from the gridiew for        binding
            if (grdRow.RowIndex == grdndex)
            {
                DropDownList cmbSubMenu;
                cmbSubMenu = (DropDownList)(grdGrpView.Rows[grdRow.RowIndex].Cells[0].FindControl("cmbSubMenu"));
                // here i am binding the DropDownList with the dataset ds
                DataTable groupdt = getSubMenudetails(MenuId);
                if (groupdt.Rows.Count > 0 || groupdt != null)
                {
                    cmbSubMenu.DataSource = groupdt;
                    cmbSubMenu.DataTextField = "SubMenuName";
                    cmbSubMenu.DataValueField = "SubMenuID";
                    cmbSubMenu.DataBind();
                    cmbSubMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    cmbSubMenu.SelectedIndex = 0;
                    if (Selectedvalue != null)
                    {
                        cmbSubMenu.SelectedValue = Selectedvalue;
                        cmbSubMenu.Enabled = false;
                    }
                }
                else
                {
                    cmbSubMenu.DataSource = groupdt;
                    cmbSubMenu.DataTextField = "SubMenuName";
                    cmbSubMenu.DataValueField = "SubMenuID";
                    cmbSubMenu.DataBind();
                    cmbSubMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
                    cmbSubMenu.SelectedIndex = 0;
                }
            }

        }
    }
    protected void lnkPermission_Click(object sender, EventArgs e)
    {

        LinkButton lnkper = sender as LinkButton;
        string chk2 = lnkper.CommandArgument.ToString();
        int grpID;
        if (chk2 == "True" || chk2 == "False")
        {
            LinkAddnNewp.Visible = false;
            grpID = Convert.ToInt16(Session["GRPID"]);
            gridMenuBind(grpID);
            mpop1.Show();
        }
        else
        {
            GridViewRow rw = (GridViewRow)lnkper.Parent.Parent;
            int rwindx = rw.RowIndex;
            DropDownList cmbRole = (DropDownList)(grdgrpdetails.Rows[rwindx].Cells[0].FindControl("cmbRoleName"));
            string Rolename = cmbRole.SelectedItem.Text;
            string GroupName = cmbGroupName.SelectedItem.Text;
            lblGroup.Text = GroupName;
            lblRole.Text = Rolename;
            grpID = Convert.ToInt16(lnkper.CommandArgument.ToString());
            int res = gridMenuBind(grpID);
            if (res == 0)
            {
                LinkAddnNewp.Visible = true;
                //msg1.Msg = "No record Exist";
                Session["GRPID"] = grpID.ToString();
                //msg1.showmsg();
                mpop1.Show();
            }
            else
            {
                LinkAddnNewp.Visible = false;
                Session["GRPID"] = grpID.ToString();
                mpop1.Show();
            }

        }


    }

    protected void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList cmbSubMenu = (DropDownList)sender;
        GridViewRow row = (GridViewRow)cmbSubMenu.Parent.Parent;
        int idx = row.RowIndex;
        if (cmbSubMenu.SelectedIndex != 0)
        {
            varMenuID = Convert.ToInt16(cmbSubMenu.SelectedValue);
            gridSubMenuBind(varMenuID, idx, null);
        }
        mpop1.Show();
    }
    protected void cmbSubMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList cmbSubMenu = (DropDownList)sender;
        GridViewRow row = (GridViewRow)cmbSubMenu.Parent.Parent;
        int idx = row.RowIndex;
        int cntcheck = 0;
        int SelectedSubMenu = Convert.ToInt16(cmbSubMenu.SelectedValue);
        for (int i = 0; i < idx; i++)
        {
            DropDownList cmbSubMenunew = (DropDownList)(grdGrpView.Rows[i].Cells[0].FindControl("cmbSubMenu"));
            int submenu = Convert.ToInt16(cmbSubMenunew.SelectedValue);
            if (SelectedSubMenu == submenu)
            {
                cntcheck = 1;
            }

        }
        gridPermissionBind(idx, null);
        mpop1.Show();

        if (cntcheck == 1)
        {
            cmbSubMenu.SelectedIndex = 0;
            msg1.Msg = "SubMenu already selected please select another Submenu";
            msg1.showmsg();

        }

    }

    protected void lnkAddNew1_Click(object sender, EventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        lnk.ValidationGroup = "grp";
        int vargrpidnew = Convert.ToInt16(Session["GRPID"]);
        if (ViewState["dtaddnew"] != null)
        {
            int cnt = grdGrpView.Rows.Count;
            if (cnt > 0)
            {
                DropDownList cmbper;
                cmbper = (DropDownList)(grdGrpView.Rows[cnt - 1].Cells[0].FindControl("cmbPermission"));
                DropDownList cmbMenu;
                cmbMenu = (DropDownList)(grdGrpView.Rows[cnt - 1].Cells[0].FindControl("cmbMenu"));
                DropDownList cmbSubMenu;
                cmbSubMenu = (DropDownList)(grdGrpView.Rows[cnt - 1].Cells[0].FindControl("cmbSubMenu"));
                string menu = cmbMenu.SelectedValue.ToString();
                string smenu = cmbSubMenu.SelectedValue.ToString();
                string per = cmbper.SelectedValue.ToString();
                dtAddNew = (DataTable)ViewState["dtaddnew"];
                dtAddNew.Rows[cnt - 1][3] = menu;
                dtAddNew.Rows[cnt - 1][4] = smenu;
                dtAddNew.Rows[cnt - 1][10] = per;

            }
            dtAddNew.Rows.Add(dtAddNew.NewRow());
            int grdcnt = dtAddNew.Rows.Count;
            dtAddNew.Rows[grdcnt - 1][12] = "True";
            grdGrpView.DataSource = dtAddNew;
            grdGrpView.DataBind();
            gridAddNewBind(dtAddNew);
            dtAddNew = dtAddNew.Copy();
        }
        else
        {
            DataTable grdata = getGroupRolePermissiondetails(vargrpidnew);
            grdata.Rows.Add(grdata.NewRow());
            int grdcnt = grdata.Rows.Count;
            grdata.Rows[grdcnt - 1][12] = "True";
            grdGrpView.DataSource = grdata;
            grdGrpView.DataBind();
            gridAddNewBind(grdata);
            dtAddNew = grdata.Copy();
            ViewState["dtaddnew"] = dtAddNew;
        }

        mpop1.Show();
    }
    protected void lnkIsActive_Click(object sender, EventArgs e)
    {
        LinkButton lnkActive = sender as LinkButton;
        int grid = Convert.ToInt16(lnkActive.CssClass.ToString());
        GridViewRow row = (GridViewRow)lnkActive.Parent.Parent;
        int idx = row.RowIndex;
        DropDownList cmbrole = (DropDownList)grdgrpdetails.Rows[idx].FindControl("cmbRoleName");
        int roleid = Convert.ToInt16(cmbrole.SelectedValue);
        string status = lnkActive.Text;
        bool varStatus = false;
        if (status == "Deactivate")
        {
            varStatus = false;
        }
        else
        {
            varStatus = true;
        }
        ChnageGroupRoleStatus(grid, roleid, varStatus);

        cmbGroupName_SelectedIndexChanged(sender, e);

    }
    protected void lnkisActive1_Click(object sender, EventArgs e)
    {
        LinkButton lnkActive = sender as LinkButton;
        string chk = lnkActive.CssClass.ToString();
        if (chk != "")
        {
            int vargrpid = Convert.ToInt16(lnkActive.CssClass.ToString());
            GridViewRow row = (GridViewRow)lnkActive.Parent.Parent;
            int idx1 = row.RowIndex;
            DropDownList cmbper = (DropDownList)grdGrpView.Rows[idx1].FindControl("cmbPermission");
            int varpermissionid = Convert.ToInt16(cmbper.SelectedValue);
            string status = lnkActive.Text;
            bool varStatus = false;
            if (status == "Activate")
            {
                varStatus = true;
            }
            else if (status == "Deactivate")
            {

                varStatus = false;
            }
            Updategrpdetails(vargrpid, varpermissionid, varStatus, LoginUser, Ret);
            lnkPermission_Click(sender, e);
            mpop1.Show();
        }
        else
        {
            msg1.Msg = "Please First Save the Record";
            msg1.showmsg();
            mpop1.Show();
        }
    }
    protected void btnCancel0_Click(object sender, EventArgs e)
    {
        ViewState["dtaddnew"] = null;
        Session["GRPID"] = null;
    }
    protected void LinkAddnNewp_Click(object sender, EventArgs e)
    {   
        LinkAddnNewp.Attributes.Add("onclick","moveVerticalScroll()");
        int vargrpidnew = Convert.ToInt16(Session["GRPID"]);
        if (ViewState["dtaddnew"] != null)
        {
            int cnt = grdGrpView.Rows.Count;
            if (cnt > 0)
            {
                DropDownList cmbper;
                cmbper = (DropDownList)(grdGrpView.Rows[cnt - 1].Cells[0].FindControl("cmbPermission"));
                DropDownList cmbMenu;
                cmbMenu = (DropDownList)(grdGrpView.Rows[cnt - 1].Cells[0].FindControl("cmbMenu"));
                DropDownList cmbSubMenu;
                cmbSubMenu = (DropDownList)(grdGrpView.Rows[cnt - 1].Cells[0].FindControl("cmbSubMenu"));
                string menu = cmbMenu.SelectedValue.ToString();
                string smenu = cmbSubMenu.SelectedValue.ToString();
                string per = cmbper.SelectedValue.ToString();
                dtAddNew = (DataTable)ViewState["dtaddnew"];
                dtAddNew.Rows[cnt - 1][3] = menu;
                dtAddNew.Rows[cnt - 1][4] = smenu;
                dtAddNew.Rows[cnt - 1][10] = per;

            }
            dtAddNew.Rows.Add(dtAddNew.NewRow());
            int grdcnt = dtAddNew.Rows.Count;
            dtAddNew.Rows[grdcnt - 1][12] = "True";
            BindGrdpermission(dtAddNew);
            gridAddNewBind(dtAddNew);
            dtAddNew = dtAddNew.Copy();
        }
        else
        {
            DataTable grdata = getGroupRolePermissiondetails(vargrpidnew);
            grdata.Rows.Add(grdata.NewRow());
            int grdcnt = grdata.Rows.Count;
            grdata.Rows[grdcnt - 1][12] = "True";
            BindGrdpermission(grdata);
            gridAddNewBind(grdata);
            dtAddNew = grdata.Copy();
            ViewState["dtaddnew"] = dtAddNew;
        }

        mpop1.Show();
    }

    private void BindGrdpermission(DataTable dtgrdperm)
    {
        grdGrpView.DataSource = dtgrdperm;
        grdGrpView.DataBind();
        for (int i = 0; i < dtgrdperm.Rows.Count; i++)
        {
            LinkButton lnkisactive = (LinkButton)this.grdGrpView.Rows[i].FindControl("lnkIsActive1");
            Label lblisactive1 = (Label)this.grdGrpView.Rows[i].FindControl("lblStatus");
            string status = lnkisactive.CommandArgument.ToString();
            if (status == "True")
            {
                lnkisactive.Text = "Deactivate";
                lblisactive1.Text = "Active";
            }
            else if (status == "False")
            {
                lnkisactive.Text = "Activate";
                lblisactive1.Text = "InActive";
            }
        }
    }
    protected void grdgrpdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdgrpdetails.PageIndex = e.NewPageIndex;
        grdgrpdetails.DataBind();
        int vargrpId = Convert.ToInt16(cmbGroupName.SelectedValue);
        gridRoleBind(vargrpId);

    }




   
}