using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using AjaxControlToolkit;
using System.IO;

public partial class SubMenuList : System.Web.UI.Page
{
    // Initialization of public variables
    public string UserName;// For logged in username
    public int LoginUser;// For Logged in user Id
    public string Ret;// For return message
    public  bool IsActive;// For Status
    int SubMenuID; // For SubMenu ID
    string ColSMName; // For Column
    string Sort; // For Sorting
    DataTable DtSort; // For Sorting table
    DataView DvSubMenu; // For Sorting view

    /// <summary>
    /// On Page Load 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int ind = MasterAcc.SelectedIndex;
        int indx = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = indx - 1;
        grdSubMenuDetails.Columns[0].Visible = false;
        // To select loginuser id and login username
        Login objSubMenu = new Login();
        objSubMenu.Start();
        UserName = objSubMenu.LogedInUser;
        LoginUser = objSubMenu.LoginUser;
        Ret = objSubMenu.Ret;
        if (!Page.IsPostBack)
        {
            IsActive = true;
            // To sort defaulty by Ascending order
            ViewState["Sort"] = "ASC";
            // To fetch SubMenu details having active status
            DataTable DtSubMenu = GetSubMenuDetails(IsActive);
            ViewState["DtSubMenu"] = DtSubMenu;
            BindGrid(DtSubMenu);
            if (Session["SubMenuID"] != null)
            {
                SubMenuID = Convert.ToInt32(Session["SubMenuId"].ToString());
            }
        }       
   }

    /// <summary>
    ///  To bind Gridview by Submenu details
    /// </summary>
    /// <param name="DtGetSubMenu"></param>
    private void BindGrid(DataTable DtGetSubMenu)
    {
        if (DtGetSubMenu.Rows.Count > 0 || DtGetSubMenu != null)
        {
            grdSubMenuDetails.DataSource = DtGetSubMenu;
            grdSubMenuDetails.DataBind();
            for (int i = 0; i < grdSubMenuDetails.Rows.Count; i++)
            {
                Label lblIsActive = (grdSubMenuDetails.Rows[i].FindControl("lblIsActive") as Label);
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
            grdSubMenuDetails.DataSource = null;
            grdSubMenuDetails.DataBind();
        }
    }

    /// <summary>
    /// To get Active Status SubMenu details
    /// </summary>
    /// <param name="IsActive"></param>
    /// <returns></returns>
    private DataTable GetSubMenuDetails(bool IsActive)
    {
        SubMenuBAL SubMenuBAL = new SubMenuBAL();
        DataTable DtGetSubMenu = new DataTable();
        try
        {
            DtGetSubMenu = SubMenuBAL.LoadActiveSubMenu(IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            SubMenuBAL = null;
        }
        return DtGetSubMenu;
    }

    /// <summary>
    /// To get SubMenu details from Business logic layer
    /// </summary>
    /// <returns></returns>
    private DataTable LoadSubMenu()
    {
        SubMenuBAL SubMenuBAL = new SubMenuBAL();
        DataTable DtLoadSubMenu = new DataTable();
        try
        {
            DtLoadSubMenu = SubMenuBAL.LoadAllSubMenu(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            SubMenuBAL = null;
        }
        return DtLoadSubMenu;
    }

   
  
    /// <summary>
    ///  To Search SubMenu details by specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        string OpeSubMName ="";
        ColSMName = ddlCol.Text;
        string Val = ddlVal.Text;
        DataTable DtFilter = new DataTable();
        DvSubMenu = DtFilter.DefaultView;
        if (ColSMName != "Select Column")
        {
            if (ColSMName == "SubMenuName")
            {
                OpeSubMName = ddlOpeName.Text;
                DtFilter = LoadSubMenu();
                DvSubMenu = DtFilter.DefaultView;
                Val = txtValMenuN.Text;
            }
            else if (ColSMName == "IsActive")
            {
                OpeSubMName = ddlOpeStatus.Text;
            }
            else if (ColSMName == "MenuID")
            {
                Val = txtValMenuN.Text;
                int ValMID = GetMenuID(Val);
                OpeSubMName = ddlOpeStatus.Text;
                DtFilter = LoadSubMenu();
                DvSubMenu = DtFilter.DefaultView;
                if (OpeSubMName == "=")
                {                   
                    DvSubMenu.RowFilter = ColSMName + " " + OpeSubMName + ValMID;
                    if (DvSubMenu.ToTable().Rows.Count == 0)
                    {
                        MsgSubMenu.Msg = "No Records Found";
                        MsgSubMenu.showmsg();
                    }
                    else
                    {
                        ViewState["DtSubMenu"] = DvSubMenu.ToTable();
                        BindGrid(DvSubMenu.ToTable());
                    }
                }
                else if (OpeSubMName == "<>")
                {
                    DtFilter = LoadSubMenu();
                    DvSubMenu = DtFilter.DefaultView;
                    DvSubMenu.RowFilter = ColSMName + " " + OpeSubMName + ValMID;
                    if (DvSubMenu.ToTable().Rows.Count == 0)
                    {
                        MsgSubMenu.Msg = "No Records Found";
                        MsgSubMenu.showmsg();
                    }
                    else
                    {
                        ViewState["DtSubMenu"] = DvSubMenu.ToTable();
                        BindGrid(DvSubMenu.ToTable());
                    }
                }
            }
            if (Val == "Active")
            {
                Val = "true";
                if (OpeSubMName == "=")
                {
                    DtFilter = GetSubMenuDetails(true);
                    DvSubMenu = DtFilter.DefaultView;
                }
                else if (OpeSubMName == "<>")
                {
                    DtFilter = GetSubMenuDetails(false);
                    DvSubMenu = DtFilter.DefaultView;
                }
            }
            else if (Val == "InActive")
            {
                Val = "false";
                if (OpeSubMName == "=")
                {
                    DtFilter = GetSubMenuDetails(false);
                    DvSubMenu = DtFilter.DefaultView;
                }
                else if (OpeSubMName == "<>")
                {
                    DtFilter = GetSubMenuDetails(true);
                    DvSubMenu = DtFilter.DefaultView;
                }
            }
            if (ColSMName == "SubMenuName" || ColSMName == "IsActive")
            {
                if (OpeSubMName == "Like")
                {
                    Val = "%" + Val + "%";
                    FilterDataView(DvSubMenu, ColSMName, OpeSubMName, Val);
                }
                else if (OpeSubMName == "Not Like")
                {
                    FilterDataView(DvSubMenu, ColSMName, OpeSubMName, Val);
                }
                else if (OpeSubMName == "=")
                {
                    FilterDataView(DvSubMenu, ColSMName, OpeSubMName, Val);
                }
                else if (OpeSubMName == "<>")
                {
                    FilterDataView(DvSubMenu, ColSMName, OpeSubMName, Val);
                }
            }
        }
    }

    /// <summary>
    /// To search SubMenu details by different conditions 
    /// </summary>
    /// <param name="DvSubMenu"></param>
    /// <param name="Column"></param>
    /// <param name="Operator"></param>
    /// <param name="Value"></param>
    public void FilterDataView(DataView DvSubMenu, string Column, string Operator, string Value)
    {
        DvSubMenu.RowFilter = Column + " " + Operator + "'" + Value + "'";
        if (DvSubMenu.ToTable().Rows.Count == 0)
        {
            MsgSubMenu.Msg = "No Records Found";
            MsgSubMenu.showmsg();
            ViewState["DtSubMenu"] = DvSubMenu.ToTable();
            BindGrid(DvSubMenu.ToTable());
            ddlCol.SelectedIndex = 0;
            ddlOpeStatus.SelectedIndex = 0;
            ddlVal.SelectedIndex = 0;
            ddlOpeName.SelectedIndex = 0;
            txtValMenuN.Text = null;
        }
        else
        {
            BindGrid(DvSubMenu.ToTable());
            ViewState["DtSubMenu"] = DvSubMenu.ToTable();
        }
    }

    /// <summary>
    /// To change dropdown value for specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCol_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string ColName = ddlCol.Text;
        if (ColName == "SubMenuName")
        {
            tdOpeName.Visible = true;
            tdOpeStatus.Visible = false;
            tdUserValue.Visible = true;
            cvSMOpeartor.Enabled = true;
            tdVal.Visible = false;
            cvSMOpeStatus.Enabled = false;
            AutoComplete2.Enabled = false;
        }
        else if (ColName == "IsActive")
        {
            tdOpeName.Visible = false;
            tdOpeStatus.Visible = true;
            tdUserValue.Visible = false;
            tdVal.Visible = true;
            cvSMOpeartor.Enabled = false;
            cvSMOpeStatus.Enabled = true;
            AutoComplete2.Enabled = false;    
        }
        else if (ColName == "MenuID")
        {
            tdOpeName.Visible = false;
            tdOpeStatus.Visible = true;
            tdUserValue.Visible = true;
            tdVal.Visible = false;
            cvSMOpeartor.Enabled = false;
            cvSMOpeStatus.Enabled = true;
            AutoComplete2.Enabled = true;
        }
    }

    /// <summary>
    /// For filter get MenuID
    /// </summary>
    /// <param name="MenuName"></param>
    /// <returns></returns>
    public int GetMenuID(string MenuName)
    {
        int VMenuID =0;
        DataTable GetMenu = GetMenuIDsource(MenuName);
        if (GetMenu.Rows.Count > 0)
        {
            VMenuID = Convert.ToInt32(GetMenu.Rows[0][0].ToString());
        }
        return VMenuID;
    }

    /// <summary>
    /// For filter MenuName by Using MenuID
    /// </summary>
    /// <param name="MenuName"></param>
    /// <returns></returns>
    private DataTable GetMenuIDsource(string MenuName)
    {
        MenuBAL MenuBAL = new MenuBAL();
        DataTable DtGetMenu = new DataTable();
        try
        {
            DtGetMenu = MenuBAL.SelectMenuName(MenuName, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            DtGetMenu = null;
        }
        return DtGetMenu;
    }

    /// <summary>
    /// To bind Menu name to search textbox
    /// </summary>
    /// <param name="prefixText"></param>
    /// <param name="count"></param>
    /// <param name="contextKey"></param>
    /// <returns></returns>
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList1(string prefixText, int count, string contextKey)
    {
        string ConStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
        SqlConnection Con = new SqlConnection(ConStr);
        Con.Open();
        SqlCommand Cmd = new SqlCommand("Select MenuName from Masters.[Menu] where [IsActive] = 1", Con);
        SqlDataAdapter DAdapter = new SqlDataAdapter(Cmd);
        DataTable DtSearch = new DataTable();
        DAdapter.Fill(DtSearch);
        DataTable DtSearchNew = DtSearch.Copy();
        List<string> txtItems = new List<string>();
        String DbValues;
        if (DtSearchNew.Rows.Count > 0)
        {
            foreach (DataRow row in DtSearchNew.Rows)
            {
                DbValues = row["MenuName"].ToString();
                txtItems.Add(DbValues);
            }
        }
        return txtItems.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="MenuID"></param>
    /// <returns></returns>
    private DataTable GetMenuDetails(int MenuID)
    {
        MenuBAL MenuBAL = new MenuBAL();
        DataTable DtGetMenu = new DataTable();
        try
        {
            DtGetMenu = MenuBAL.SelectMenuID(MenuID, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            MenuBAL = null;
        }
        return DtGetMenu;
    }

    /// <summary>
    /// To show active SubMenu details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRef_Click(object sender, ImageClickEventArgs e)
    {
        bool IsActive = true;
        DataTable DtSubM = GetSubMenuDetails(IsActive);
        ViewState["DtSubMenu"] = DtSubM;
        BindGrid(DtSubM);
        ddlCol.SelectedIndex = 0;
        ddlOpeName.SelectedIndex = 0;
        ddlOpeStatus.SelectedIndex = 0;
        ddlVal.SelectedIndex = 0;
        txtValMenuN.Text = null;
    }

    /// <summary>
    /// To sort grid Menu name wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkMeName_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtSubMenu"];
            DtSort.DefaultView.Sort = "MenuID" + " ASC";
            DvSubMenu = new DataView(DtSort);
            DvSubMenu.Sort = ("MenuID" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtSubMenu"] = DvSubMenu.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtSubMenu"];
            DtSort.DefaultView.Sort = "MenuID" + " DESC";
            DvSubMenu = new DataView(DtSort);
            DvSubMenu.Sort = ("MenuID" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtSubMenu"] = DvSubMenu.ToTable();
        }
        BindGrid(DvSubMenu.ToTable());
    }

    /// <summary>
    /// To Sort grid SubMenu wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSMName_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtSubMenu"];
            DtSort.DefaultView.Sort = "SubMenuName" + " ASC";
            DvSubMenu = new DataView(DtSort);
            DvSubMenu.Sort = ("SubMenuName" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtSubMenu"] = DvSubMenu.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtSubMenu"];
            DtSort.DefaultView.Sort = "SubMenuName" + " DESC";
            DvSubMenu = new DataView(DtSort);
            DvSubMenu.Sort = ("SubMenuName" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtSubMenu"] = DvSubMenu.ToTable();
        }
        BindGrid(DvSubMenu.ToTable());
    }

    /// <summary>
    /// To Sort grid SubMenu Description wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSubDes_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtSubMenu"];
            DtSort.DefaultView.Sort = "SubMenuDescription" + " ASC";
            DvSubMenu = new DataView(DtSort);
            DvSubMenu.Sort = ("SubMenuDescription" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtSubMenu"] = DvSubMenu.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtSubMenu"];
            DtSort.DefaultView.Sort = "SubMenuDescription" + " DESC";
            DvSubMenu = new DataView(DtSort);
            DvSubMenu.Sort = ("SubMenuDescription" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtSubMenu"] = DvSubMenu.ToTable();
        }
        BindGrid(DvSubMenu.ToTable());
    }

    /// <summary>
    /// To Sort grid SubMenu Status wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSMStatus_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtSubMenu"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            DvSubMenu = new DataView(DtSort);
            DvSubMenu.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtSubMenu"] = DvSubMenu.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtSubMenu"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            DvSubMenu = new DataView(DtSort);
            DvSubMenu.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtSubMenu"] = DvSubMenu.ToTable();
        }
        BindGrid(DvSubMenu.ToTable());
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdSubMenuDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdSubMenuDetails.PageIndex = e.NewPageIndex;
        DataTable DtSubMenu = (DataTable)ViewState["DtSubMenu"];      
        BindGrid(DtSubMenu);
    }

    /// <summary>
    /// To add new SubMenu details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Session["SubMenuId"] = null;
        Response.Redirect("SubMenuDetails.aspx", false); 
    }

    /// <summary>
    ///  To Edit SubMenu details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imbSubMenu = sender as ImageButton;
        GridViewRow row = (GridViewRow)imbSubMenu.Parent.Parent;
        int Idx = row.RowIndex;
        int SubMenuId = Convert.ToInt32(imbSubMenu.CommandArgument.ToString());
        lblSelectID.Text = SubMenuId.ToString();
        Label lblMeID = (grdSubMenuDetails.Rows[Idx].FindControl("lblMeNa") as Label);
        int NewMenuID = Convert.ToInt32(lblMeID.CssClass.ToString());
        DataTable dtMenu = GetMenuDetails(NewMenuID);
        string MStatus = dtMenu.Rows[0][3].ToString();
        if (MStatus == "False")
        {
            MsgSubMenu.Msg = "Menu is not in Active status, Please activate Menu";
            MsgSubMenu.showmsg();
        }
        else if (MStatus == "True")
        {
            Session["SubMenuId"] = lblSelectID.Text;
            Response.Redirect("SubMenuDetails.aspx", false);
        }
    }

    /// <summary>
    /// Help for SubMenu List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSubMenuHelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/SubMenuListHelp.pdf");
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
