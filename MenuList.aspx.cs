using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class MenuList : System.Web.UI.Page
{
    public  string Useraname;// For loged in username
    public  int LoginUser;// For Loged in user id
    public  string Ret;// For return message
    public  bool IsActive;// For user status
    int MenuID;// For menu id
    string Sort;//For sorting
    DataTable DtSort;// For sorting in table
    DataView DvMenu;// For sorting menu view

    /// <summary>
    /// On Page Load 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int MenuInd = MasterAcc.SelectedIndex;
        int MenuIndex = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = MenuIndex - 1;
        // To select loginuser id and login username
        Login objMenu = new Login();
        objMenu.Start();
        Useraname = objMenu.LogedInUser;
        LoginUser = objMenu.LoginUser;
        Ret = objMenu.Ret;
        if (!Page.IsPostBack)
        {         
            IsActive = true;
            // To sort defaulty by Ascending order
            ViewState["Sort"] = "ASC";
            // To fetch Menu details having active status
            DataTable DtMenu = getMenuDetails(IsActive);
            ViewState["DtMenu"] = DtMenu;
            BindGrid(DtMenu);
            if (Session["MenuId"] != null)
            {
                MenuID = Convert.ToInt32(Session["MenuId"].ToString());
            }
        }
    }

    /// <summary>
    /// Bind Menu details in grid
    /// </summary>
    /// <param name="DtMenu"></param>
    private void BindGrid(DataTable DtMenu)
    {
        grdMenuList.Columns[0].Visible = false;        
        if (DtMenu.Rows.Count > 0 || DtMenu != null)
        {
            grdMenuList.DataSource = DtMenu;
            grdMenuList.DataBind();
            for (int i = 0; i < grdMenuList.Rows.Count; i++)
            {
                Label lnkStatus = (grdMenuList.Rows[i].FindControl("lnkStatus") as Label);
                string Status = lnkStatus.CssClass.ToString();
                if (Status == "True")
                {
                    lnkStatus.Text = "Active";
                }
                else
                {
                    lnkStatus.Text = "InActive";
                }
            }
        }
        else
        {
            grdMenuList.DataSource = null;
            grdMenuList.DataBind();
        }

    }

    // Get Menu Details
    private DataTable getMenuDetails(bool IsActive)
    {
        MenuBAL MenuBAL = new MenuBAL();
        DataTable DtMenuDe = new DataTable();
        try
        {
            DtMenuDe = MenuBAL.LoadActiveMenu(IsActive, LoginUser, Ret);
        }
        catch (Exception ee)
        {

        }
        finally
        {
            MenuBAL = null;
        }
        return DtMenuDe;
    }
    /// <summary>
    /// To load Menu details from Menu Business Access Layer
    /// </summary>
    /// <returns></returns>
    private DataTable loadMenu()
    {
        MenuBAL MenuBAL = new MenuBAL();
        DataTable DtMenuLoad = new DataTable();
        try
        {
            DtMenuLoad = MenuBAL.LoadAllMenu(LoginUser, Ret);
        }
        catch (Exception ee)
        {

        }
        finally
        {
            MenuBAL = null;
        }
        return DtMenuLoad;
    }
    
  
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
      
    }

    /// <summary>
    /// To Sor Menu ID by Ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkIDClick(object sender, EventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        Session["SortMenuID"] = null;
        int MenuIdNew = Convert.ToInt32(lnk.CommandArgument.ToString());
        Session["SortMenuID"] = MenuIdNew.ToString();
        string MenuName = lnk.CssClass.ToString();
        SubMenuBindGrid(MenuIdNew);
        if (grdSubmenu.Rows.Count > 0)
        {
            mpopMenu.Show();
            lblMenu.Text = MenuName;
        }
        else
        {
            MsgMenu.Msg = "Submenu not exist for " + MenuName;
            MsgMenu.showmsg();
        }            
    }

    /// <summary>
    /// To bind SubMenu Details of specific Menu to grid
    /// </summary>
    /// <param name="MenuId"></param>
    private void SubMenuBindGrid(int MenuId)
    {
        grdSubmenu.DataSource = SubMGridDataSource(MenuId);
        grdSubmenu.DataBind();      
    }

    /// <summary>
    /// To sort Submenu by ascending and descending way
    /// </summary>
    /// <param name="DtSort"></param>
    private void FilterSubMenuBindGrid(DataTable DtSort)
    {
        grdSubmenu.DataSource = DtSort;
        grdSubmenu.DataBind();
    }

    /// <summary>
    /// To get Submenu details of selected menu id
    /// </summary>
    /// <param name="MenuId"></param>
    /// <returns></returns>
    private DataTable SubMGridDataSource(int MenuId)
    {
        SubMenuBAL mBAL = new SubMenuBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = mBAL.SelectMenuID(MenuId, LoginUser, Ret);
        }
        catch (Exception ee)
        {

        }
        finally
        {
            mBAL = null;
        }
        return dTable;
    }

    /// <summary>
    /// To get menu details of selected menu id
    /// </summary>
    /// <param name="MenuID"></param>
    /// <returns></returns>
    private DataTable GetMenuID(int MenuID)
    {
        MenuBAL mBAL = new MenuBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = mBAL.SelectMenuID(MenuID, LoginUser, Ret);
        }
        catch (Exception ee)
        {

        }
        finally
        {
            mBAL = null;
        }

        return dTable;
    }
    /// To clear data
    public void Clear()
    {         
         ddlOperator.SelectedIndex = 0;
         ddlVal.SelectedIndex = 0;
        txtValue.Text = "";      
    }
    /// <summary>
    /// To search menu details on selected condition
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbApplyFilter_Click(object sender, ImageClickEventArgs e)
    {
        string OpeMenuName="";
        string ColMenu = ddlMenuColumn.SelectedValue;
        string Val = txtValue.Text;
        DataView DvMenu= new DataView();
       
            if (ColMenu == "MenuName")
            {
                OpeMenuName = ddlOperator.Text;
                DataTable dt = loadMenu();
                DvMenu = dt.DefaultView;
            }
            else if(ColMenu =="IsActive")
            {
                OpeMenuName = ddlStatusOpe.Text;
                Val = ddlVal.Text;
            }
            if (Val == "Active")
            {
                Val = "true";
                if (OpeMenuName == "=")
                {
                    DataTable dt = getMenuDetails(true);
                    DvMenu = dt.DefaultView;
                }
                else if (OpeMenuName == "<>")
                {
                    DataTable dt = getMenuDetails(false);
                    DvMenu = dt.DefaultView;
                }
            }
            else if(Val == "InActive")
            {
                Val = "false";
                if (OpeMenuName == "=")
                {
                    DataTable dt = getMenuDetails(false);
                    DvMenu = dt.DefaultView;
                }
                else if (OpeMenuName == "<>")
                {
                    DataTable dt = getMenuDetails(true);
                    DvMenu = dt.DefaultView;
                }
            }
            if (OpeMenuName == "Like")
            {
                Val = "%" + Val + "%";
                filterDataview(DvMenu, ColMenu, OpeMenuName, Val);
            }
            else if (OpeMenuName == "Not like")
            {
                filterDataview(DvMenu, ColMenu, OpeMenuName, Val);
            }
            else if (OpeMenuName == "=")
            {
                filterDataview(DvMenu, ColMenu, OpeMenuName, Val);
            }
            else if (OpeMenuName == "<>")
            {
                filterDataview(DvMenu, ColMenu, OpeMenuName, Val);
            }
        
    }

    /// <summary>
    /// To search menu details by different conditions
    /// </summary>
    /// <param name="DvMenu"></param>
    /// <param name="Column"></param>
    /// <param name="Operator"></param>
    /// <param name="Value"></param>
    public void filterDataview(DataView DvMenu, string Column, string Operator, string Value)
    {
        DvMenu.RowFilter = Column + " " + Operator + "'" + Value + "'";
        if (DvMenu.ToTable().Rows.Count == 0)
        {
            MsgMenu.Msg = "Record(s) not found";
            MsgMenu.showmsg();
            ViewState["DtMenu"] = DvMenu.ToTable();
            BindGrid(DvMenu.ToTable());          
        }
        else
        {
            ViewState["DtMenu"] = DvMenu.ToTable();
            BindGrid(DvMenu.ToTable());
        }
    }

    /// <summary>
    /// To change dropdown value for different conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlMenuColumn_SelectedIndexChanged(object sender, EventArgs e)
    {
        string col = ddlMenuColumn.Text;      
        if (col == "MenuName")
        {
            tdMenuName.Visible = true;
            tdStatus.Visible = false;
            cvMenuOpe.Enabled = true;
            tdVal.Visible = false;
            tdValText.Visible = true;
            cvMenuOpeSta.Enabled = false;
           
        }
        else if (col == "IsActive")
        {
            tdMenuName.Visible = false;
            tdStatus.Visible = true;
            tdValText.Visible = false;
            cvMenuOpe.Enabled = false;
            cvMenuOpeSta.Enabled = true;
            tdVal.Visible = true;
           
        }
        Clear();
    }

    /// <summary>
    /// To show active menu details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRef_Click(object sender, ImageClickEventArgs e)
    {
        bool IsActive = true;
        DataTable DtMenu = getMenuDetails(IsActive);
        ViewState["DtMenu"] = DtMenu;
        BindGrid(DtMenu);
        ddlMenuColumn.SelectedIndex = 0;
        ddlOperator.SelectedIndex = 0;
        ddlVal.SelectedIndex = 0;
        txtValue.Text = null;
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdMenuList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdMenuList.PageIndex = e.NewPageIndex;
        DataTable DtMenu = (DataTable)ViewState["DtMenu"];
        BindGrid(DtMenu);     
    }


    /// <summary>
    /// To sort Menu name in grid by ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkMname_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtMenu"];
            DtSort.DefaultView.Sort = "MenuName" + " ASC";
            DvMenu = new DataView(DtSort);
            DvMenu.Sort = ("MenuName" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtMenu"] = DvMenu.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtMenu"];
            DtSort.DefaultView.Sort = "MenuName" + " DESC";
            DvMenu = new DataView(DtSort);
            DvMenu.Sort = ("MenuName" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtMenu"] = DvMenu.ToTable();
        }
        BindGrid(DvMenu.ToTable());
    }


    /// <summary>
    /// To sort Menu Description in grid by ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkMDescription_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtMenu"];
            DtSort.DefaultView.Sort = "MenuDescription" + " ASC";
            DvMenu = new DataView(DtSort);
            DvMenu.Sort = ("MenuDescription" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtMenu"] = DvMenu.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtMenu"];
            DtSort.DefaultView.Sort = "MenuDescription" + " DESC";
            DvMenu = new DataView(DtSort);
            DvMenu.Sort = ("MenuDescription" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtMenu"] = DvMenu.ToTable();
        }
        BindGrid(DvMenu.ToTable());
    }

    /// <summary>
    /// To sort Menu status in grid by ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkMStatus_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtMenu"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            DvMenu = new DataView(DtSort);
            DvMenu.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtMenu"] = DvMenu.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtMenu"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            DvMenu = new DataView(DtSort);
            DvMenu.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtMenu"] = DvMenu.ToTable();
        }
        BindGrid(DvMenu.ToTable());
    }
    
    /// <summary>
    /// To sort SubMenu name in grid by ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSMName_Click(object sender, EventArgs e)
    {
        int SortMenuId = Convert.ToInt16(Session["SortMenuID"]);
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = SubMGridDataSource(SortMenuId);
            DtSort.DefaultView.Sort = "SubMenuName" + " ASC";
            DvMenu = new DataView(DtSort);
            DvMenu.Sort = ("SubMenuName" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtMenu"] = DvMenu.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = SubMGridDataSource(SortMenuId);
            DtSort.DefaultView.Sort = "SubMenuName" + " DESC";
            DvMenu = new DataView(DtSort);
            DvMenu.Sort = ("SubMenuName" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtMenu"] = DvMenu.ToTable();
        }
        FilterSubMenuBindGrid(DvMenu.ToTable());
        mpopMenu.Show();
        
    }

    /// <summary>
    /// To add new menu details 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Session["MenuId"] = null;
        Response.Redirect("MenuDetails.aspx", false);
    }

    /// <summary>
    /// To edit Menu Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imbMenu = sender as ImageButton;
        int MenuId = Convert.ToInt32(imbMenu.CommandArgument.ToString());
        lblSelectID.Text = MenuId.ToString();
        Session["MenuId"] = lblSelectID.Text;
        Response.Redirect("MenuDetails.aspx", false);      
    }

    /// <summary>
    /// Help for Menu List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbMenuhelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/MenuListHelp.pdf");
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