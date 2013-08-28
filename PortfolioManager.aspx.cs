using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class Portfolio_Manager : System.Web.UI.Page
{
    public  string UserName;// For loged in user
    public  int LoginUser;// For loged in user id
    public  string Ret;// For return message
    public static bool IsActive;// For return message
    DataTable DtPortMana = new DataTable();// For Portfolio Manger table
    int PortManaID;// For Portfolio Manager Id
    string Sort;// For sorting
    DataTable DtSort;// For Sorting table
    DataView DvPortFolio;// For Menu Details View

    /// <summary>
    /// Page load Method
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
        UserName = objMenu.LogedInUser;
        LoginUser = objMenu.LoginUser;
        Ret = objMenu.Ret;
        if (!Page.IsPostBack)
        {       
            IsActive = true;
            // To sort defaulty by Ascending order
            ViewState["Sort"] = "ASC";
            // To fetch Portfolio Manager details having active status
            DataTable DtPortMana = PortManaActiveDetails(IsActive);
            ViewState["DtPortMana"] = DtPortMana;
            if (DtPortMana.Rows.Count > 0)
            {
                BindPortMana(DtPortMana);
            }
            else
            {
                GrdPortfolioManager.DataSource = null;
                GrdPortfolioManager.DataBind();
            }
        }
    }

    /// <summary>
    /// To get Portfolio Manger having active status
    /// </summary>
    /// <param name="IsActive"></param>
    /// <returns></returns>
    protected DataTable PortManaActiveDetails(bool IsActive)
    {

        PortfolioManagerBAL PortfolioManagerBAL = new PortfolioManagerBAL();
        DataTable DtPortManaADe = new DataTable();
        try
        {
            DtPortManaADe = PortfolioManagerBAL.LoadActivePortfolioManager(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            PortfolioManagerBAL = null;
        }

        return DtPortManaADe;
    }

    /// <summary>
    /// To bind Portfolio manager details in grid
    /// </summary>
    /// <param name="DtPortMana"></param>
    private void BindPortMana(DataTable DtPortMana)
    {
        if (DtPortMana.Rows.Count > 0 )
        {
            GrdPortfolioManager.DataSource = DtPortMana;
            GrdPortfolioManager.DataBind();
            for (int i = 0; i < GrdPortfolioManager.Rows.Count; i++)
            {
                Label lblPLUser = (GrdPortfolioManager.Rows[i].FindControl("lblUser") as Label);
                Label lblStatus = (GrdPortfolioManager.Rows[i].FindControl("lnkStatus") as Label);
                LinkButton lnkStatus = (GrdPortfolioManager.Rows[i].FindControl("lnkEdit") as LinkButton);
                string Status = lblStatus.CssClass.ToString();
                if (Status == "True")
                {
                    lblStatus.Text = "Active";
                    lnkStatus.Text = "Deactivate";
                    lnkStatus.Font.Underline = true;
                }
                else
                {
                    lblStatus.Text = "InActive";
                    lnkStatus.Text = "Activate";
                    lnkStatus.Font.Underline = true;
                }
            }
        }
        else
        {
            GrdPortfolioManager.DataSource = null;
            GrdPortfolioManager.DataBind();
        }
    }

    /// <summary>
    /// To get User details
    /// </summary>
    /// <returns></returns>
    protected DataTable UserPerDetails()
    {
        UserBAL UserBAL = new UserBAL();
        DataTable DtUser = new DataTable();
        try
        {
            DtUser = UserBAL.LoadActiveUser(IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserBAL = null;
        }
        return DtUser;
    }
   
    /// <summary>
    /// To edit Portfolio Manger details in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        GridViewRow row = (GridViewRow)lnk.Parent.Parent;
        int Idx = row.RowIndex;
        int IntResult = 0;
        bool Status;
        int PortManaID;
        PortfolioManagerBAL PortManaBAL = new PortfolioManagerBAL();
        LinkButton lblIsActive = (GrdPortfolioManager.Rows[Idx].FindControl("lnkEdit") as LinkButton);
        Label lblStatus = (GrdPortfolioManager.Rows[Idx].FindControl("lnkStatus") as Label);
        {
            if (lblStatus.Text == "Active" || lblStatus.Text == "True")
            {
                Status = false;
                lblStatus.Text = "InActive";
                lblIsActive.Text = "Activate";
            }
            else
            {
                Status = true;
                lblStatus.Text = "Active";
                lblIsActive.Text = "Deactivate";
            }
            PortManaID = Convert.ToInt32(lnk.CommandArgument.ToString());
            lblSelectID.Text = PortManaID.ToString();
            Session["PortManaID"] = lblSelectID.Text;
            IntResult = PortManaBAL.UpdatePortfolioManager(PortManaID, Status, LoginUser, Ret);
        }
    }

    /// <summary>
    /// To bind Portfolio Manager in dropdownlist
    /// </summary>
    public void BindPortManaUser()
    {
        DataTable DtUser = UserPerDetails();
        if (DtUser.Rows.Count > 0 || DtUser != null)
        {
            ddlPortManaUser.DataSource = DtUser;
            ddlPortManaUser.DataTextField = "UserName";
            ddlPortManaUser.DataValueField = "UserID";
            ddlPortManaUser.DataBind();
            ddlPortManaUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlPortManaUser.SelectedIndex = 0;
        }
        else
        {
            ddlPortManaUser.DataSource = null;
            ddlPortManaUser.DataTextField = "UserName";
            ddlPortManaUser.DataValueField = "UserID";
            ddlPortManaUser.DataBind();
            ddlPortManaUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlPortManaUser.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// To save and update Portfolio Manager details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        PortfolioManagerBAL PortManaBAL = new PortfolioManagerBAL();
        int UserID = Convert.ToInt32(ddlPortManaUser.SelectedValue.ToString());
        string Status = ddlPortManaStatus.SelectedValue.ToString();
        bool IsActive = true;
        if (Status == "Active")
        {
            IsActive = true;
        }
        else if (Status == "InActive")
        {
            IsActive = false;
        }
        if (btnSave.Text == "Save")
        {
            try
            {
                int Result = PortManaBAL.InsertPortfolioManager(UserID, IsActive, LoginUser, Ret);
                DtPortMana = PortManaDetails();
                ViewState["DtPortMana"] = DtPortMana;
                BindPortMana(DtPortMana);
                MsgPortMana.Msg = "Record added successfully";
                MsgPortMana.showmsg();
            }
            catch (Exception ee)
            {
                if (ee.Message == "Duplicate Entry")
                {
                    MsgPortMana.Msg = "Duplicate Entry!";
                    MsgPortMana.showmsg();
                    ClearPortMana();
                }
            }
            finally
            {
                PortManaBAL = null;
            }
        }
    }

    /// <summary>
    /// To get Portfolio manager details from Portfolio manager Business access layer
    /// </summary>
    /// <returns></returns>
    protected DataTable PortManaDetails()
    {
        PortfolioManagerBAL PortfolioManagerBAL = new PortfolioManagerBAL();
        DataTable DtPortManaDe = new DataTable();
        try
        {
            DtPortManaDe = PortfolioManagerBAL.LoadAllPortfolioManager(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            PortfolioManagerBAL = null;
        }

        return DtPortManaDe;
    }

    /// <summary>
    /// To Cancel current operation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearPortMana();
        MPopUpPortMana.Hide();
        DtPortMana = PortManaDetails();
        ViewState["DtPortMana"] = DtPortMana;
        BindPortMana(DtPortMana);       
    }

    /// <summary>
    /// To get specific Portfolio Manager details  
    /// </summary>
    /// <param name="PortManaID"></param>
    /// <returns></returns>
    protected DataTable GetUserDetails(int PortManaID)
    {
        PortfolioManagerBAL PortfolioManagerBAL = new PortfolioManagerBAL();
        DataTable DtGetUser = new DataTable();
        try
        {
            DtGetUser = PortfolioManagerBAL.SelectPortfolioManagerID(PortManaID, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            PortfolioManagerBAL = null;
        }

        return DtGetUser;
    }

    /// <summary>
    /// To Clear dropdonlist 
    /// </summary>
    public void ClearPortMana()
    {
        ddlPortManaUser.SelectedIndex = 0;
        ddlPortManaStatus.SelectedIndex = 0;
        ddlPortManaUser.Enabled = true;
    }

    /// <summary>
    /// To search Portfolio Manager on different conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        string Col = ddlCol.SelectedValue;// For selected column in dropdownlist for search
        string Ope = ddlOpe.Text;// For selected operator in dropdownlist for search
        string Val = ddlVal.Text; // For selected value in dropdownlist for search
        DataView DvPortFolio = new DataView();
        if (Col == "IsActive")
        {
            if (Val == "Active" || Val == "active")
            {
                Val = "true";
                if (Ope == "=")
                {
                    DataTable DtPortManaActDet = PortManaActiveDetails(true);
                    DvPortFolio = DtPortManaActDet.DefaultView;
                    filterDataview(DvPortFolio, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable DtPortManaActDet = PortManaActiveDetails(false);
                    DvPortFolio = DtPortManaActDet.DefaultView;
                    filterDataview(DvPortFolio, Col, Ope, Val);
                }
            }
            else if (Val == "InActive" || Val == "Inactive" || Val == "inactive")
            {
                Val = "false";
                if (Ope == "=")
                {
                    DataTable DtPortManaActDet = PortManaActiveDetails(false);
                    DvPortFolio = DtPortManaActDet.DefaultView;
                    filterDataview(DvPortFolio, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable DtPortManaActDet = PortManaActiveDetails(true);
                    DvPortFolio = DtPortManaActDet.DefaultView;
                    filterDataview(DvPortFolio, Col, Ope, Val);
                }
            }

        }
    }

    /// <summary>
    /// To show active status portfolio manager details in gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRef_Click(object sender, ImageClickEventArgs e)
    {
        bool IsActive = true;
        DataTable DtPortMana = PortManaActiveDetails(IsActive);
        ViewState["DtPortMana"] = DtPortMana;  
        BindPortMana(DtPortMana);
        ddlCol.SelectedIndex = 0;
        ddlOpe.SelectedIndex = 0;
        ddlVal.SelectedIndex = 0;
    }

    /// <summary>
    /// To search Portfolio Manager details by different conditions
    /// </summary>
    /// <param name="DvPortFolio"></param>
    /// <param name="Column"></param>
    /// <param name="Operator"></param>
    /// <param name="Value"></param>
    public void filterDataview(DataView DvPortFolio, string Column, string Operator, string Value)
    {
        DvPortFolio.RowFilter = Column + " " + Operator + "'" + Value + "'";
        if (DvPortFolio.ToTable().Rows.Count == 0)
        {
            MsgPortMana.Msg = "Record(s) not found";         
            MsgPortMana.showmsg();
            ViewState["DtPortMana"] = DvPortFolio.ToTable();
            BindPortMana(DvPortFolio.ToTable());
            ddlCol.SelectedIndex = 0;
            ddlOpe.SelectedIndex = 0;
            ddlVal.SelectedIndex = 0;
        }
        else
        {
            ViewState["DtPortMana"] = DvPortFolio.ToTable();
            BindPortMana(DvPortFolio.ToTable());
        }
    }

    /// <summary>
    /// To Sort Portfolio Manager details by username ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkUserName_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtPortMana"];
            DtSort.DefaultView.Sort = "UserID" + " ASC";
            DvPortFolio = new DataView(DtSort);
            DvPortFolio.Sort = ("UserID" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtPortMana"] = DvPortFolio.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtPortMana"];
            DtSort.DefaultView.Sort = "UserID" + " DESC";
            DvPortFolio = new DataView(DtSort);
            DvPortFolio.Sort = ("UserID" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtPortMana"] = DvPortFolio.ToTable();
        }
        BindPortMana(DvPortFolio.ToTable());
    }

    /// <summary>
    /// To Sort Portfolio Manager details by Status ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtPortMana"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            DvPortFolio = new DataView(DtSort);
            DvPortFolio.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtPortMana"] = DvPortFolio.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtPortMana"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            DvPortFolio = new DataView(DtSort);
            DvPortFolio.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtPortMana"] = DvPortFolio.ToTable();
        }
        BindPortMana(DvPortFolio.ToTable());
    }

    /// <summary>
    /// To add new Portfolio Manager details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        MPopUpPortMana.Show();
        BindPortManaUser();
        ClearPortMana();
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GrdPortfolioManager_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPortfolioManager.PageIndex = e.NewPageIndex;
        DataTable DtPortMana = (DataTable)ViewState["DtPortMana"];
        BindPortMana(DtPortMana);
    }


    /// <summary>
    /// Help for Portfolio Manager KAS Audit Master
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbPortManaHelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/PortfolioManagerHelp.pdf");
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