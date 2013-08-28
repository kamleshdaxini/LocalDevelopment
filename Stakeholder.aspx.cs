using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class Stakeholder : System.Web.UI.Page
{
    public string UserName; // For loged in user
    public int LoginUser; // For loged in user id
    public string Ret; // For return message
    public static bool IsActive; // For status
    DataTable DtStakeholder = new DataTable(); // For Stakeholder table
    string Sort; // For sorting
    DataTable DtSort; // For Sorting table
    DataView Dv; // For Stakeholder Details View

    /// <summary>
    /// Page load Method
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
        Login objStak = new Login();
        objStak.Start();
        UserName = objStak.LogedInUser;
        LoginUser = objStak.LoginUser;
        Ret = objStak.Ret;
        if (!Page.IsPostBack)
        {
            IsActive = true;
            // To sort defaulty by Ascending order
            ViewState["Sort"] = "ASC";
            // To fetch Program Lead details having active status
            DataTable DtStakeholder = SActiveDetails(IsActive);
            ViewState["DtStakeholder"] = DtStakeholder;
            if (DtStakeholder.Rows.Count > 0)
            {
                BindStak(DtStakeholder);
            }
            else
            {
                GrdStakeholder.DataSource = null;
                GrdStakeholder.DataBind();
            }
        }
    }

    /// <summary>
    /// To get Stakeholder having active status
    /// </summary>
    /// <param name="IsActive"></param>
    /// <returns></returns>
    protected DataTable SActiveDetails(bool IsActive)
    {
        StakeHolderBAL StakeHolderBAL = new StakeHolderBAL();
        DataTable DtSActDet = new DataTable();
        try
        {
            DtSActDet = StakeHolderBAL.LoadActiveStakeholder(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeHolderBAL = null;
        }
        return DtSActDet;
    }

    /// <summary>
    /// To bind Stakeholder details in grid
    /// </summary>
    /// <param name="DtStakeholder"></param>
    private void BindStak(DataTable DtStakeholder)
    {
        if (DtStakeholder.Rows.Count > 0 )
        {
            GrdStakeholder.DataSource = DtStakeholder;
            GrdStakeholder.DataBind();
            for (int i = 0; i < GrdStakeholder.Rows.Count; i++)
            {
                Label lblPLUser = (GrdStakeholder.Rows[i].FindControl("lblUser") as Label);
                Label lblStatus = (GrdStakeholder.Rows[i].FindControl("lnkStatus") as Label);
                LinkButton lnkStatus = (GrdStakeholder.Rows[i].FindControl("lnkEdit") as LinkButton);
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
            GrdStakeholder.DataSource = null;
            GrdStakeholder.DataBind();
        }
    }

    /// <summary>
    ///  To bind Stakeholder in dropdownlist
    /// </summary>
    public void BindStakUser()
    {
        IsActive = true;
        DataTable DtUser = UserPerDetails();
        if (DtUser.Rows.Count > 0 || DtUser != null)
        {
            ddlStakUser.DataSource = DtUser;
            ddlStakUser.DataTextField = "UserName";
            ddlStakUser.DataValueField = "UserID";
            ddlStakUser.DataBind();
            ddlStakUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlStakUser.SelectedIndex = 0;
        }
        else
        {
            ddlStakUser.DataSource = null;
            ddlStakUser.DataTextField = "UserName";
            ddlStakUser.DataValueField = "UserID";
            ddlStakUser.DataBind();
            ddlStakUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlStakUser.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// To get User details
    /// </summary>
    /// <returns></returns>
    protected DataTable UserPerDetails()
    {
        IsActive = true;
        UserBAL UserBAL = new UserBAL();
        DataTable DtUserDet = new DataTable();
        try
        {
            DtUserDet = UserBAL.LoadActiveUser(IsActive, LoginUser, Ret);
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
    /// To edit Stakeholder details in grid
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
        int StakID;
        StakeHolderBAL StakeHolderBAL = new StakeHolderBAL();
        LinkButton lblIsActive = (GrdStakeholder.Rows[Idx].FindControl("lnkEdit") as LinkButton);
        Label lblStatus = (GrdStakeholder.Rows[Idx].FindControl("lnkStatus") as Label);
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
            StakID = Convert.ToInt32(lnk.CommandArgument.ToString());
            lblSelectID.Text = StakID.ToString();
            Session["StakID"] = lblSelectID.Text;
            IntResult = StakeHolderBAL.UpdateStakeholder(StakID, Status, LoginUser, Ret);
        }
    }

    /// <summary>
    /// To get specific Stakeholder details 
    /// </summary>
    /// <param name="StakID"></param>
    /// <returns></returns>
    protected DataTable GetUserDetails(int StakID)
    {
        StakeHolderBAL StakeHolderBAL = new StakeHolderBAL();
        DataTable DtGetUser = new DataTable();
        try
        {
            DtGetUser = StakeHolderBAL.SelectStakeholderID(StakID, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally 
        {
            StakeHolderBAL = null;
        }

        return DtGetUser;
    }
  
    /// <summary>
    /// To get Stakeholder details from Stakeholder Business access layer
    /// </summary>
    /// <returns></returns>
    protected DataTable StakDetails()
    {
        StakeHolderBAL StakeHolderBAL = new StakeHolderBAL();
        DataTable DtStakDet = new DataTable();
        try
        {
            DtStakDet = StakeHolderBAL.LoadAllStakeholder(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeHolderBAL = null;
        }
        return DtStakDet;
    }

    /// <summary>
    ///  To save and update Stakeholder details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        StakeHolderBAL StakeHolderBAL = new StakeHolderBAL();
        int UserID = Convert.ToInt32(ddlStakUser.SelectedValue.ToString());
        string Status = ddlStakStatus.SelectedValue.ToString();
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
                int Result = StakeHolderBAL.InsertStakeholder(UserID, IsActive, LoginUser, Ret);
                DtStakeholder = StakDetails();
                ViewState["DtStakeholder"] = DtStakeholder;
                BindStak(DtStakeholder);
                MsgStak.Msg = "Record added successfully";
                MsgStak.showmsg();
            }
            catch (Exception ee)
            {
                if (ee.Message == "Duplicate Entry")
                {
                    MsgStak.Msg = "Stakeholder already exists";
                    MsgStak.showmsg();
                    ClearStak();
                }
            }
            finally
            {
                StakeHolderBAL = null;
            }
        }
    }

    /// <summary>
    /// To Cancel current operation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearStak();
        DtStakeholder = StakDetails();
        ViewState["DtStakeholder"] = DtStakeholder;
        BindStak(DtStakeholder);
        MPopUpStak.Hide();
    }
    
    /// <summary>
    /// To Clear dropdonlist 
    /// </summary>
    public void ClearStak()
    {
        ddlStakUser.SelectedIndex = 0;
        ddlStakStatus.SelectedIndex = 0;
        ddlStakUser.Enabled = true;
    }

    /// <summary>
    /// To search Stakeholder on different conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        string Col = ddlCol.SelectedValue; // For selected column in dropdownlist for search
        string Ope = ddlOpe.Text; // For selected operator in dropdownlist for search
        string Val = ddlVal.Text; // For selected value in dropdownlist for search
        DataView DvFilter = new DataView();
        if (Col == "IsActive")
        {
            if (Val == "Active" || Val == "active")
            {
                Val = "true";
                if (Ope == "=")
                {
                    DataTable DtFilter = SActiveDetails(true);
                    DvFilter = DtFilter.DefaultView;
                    FilterDataview(DvFilter, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable DtFilter = SActiveDetails(false);
                    DvFilter = DtFilter.DefaultView;
                    FilterDataview(DvFilter, Col, Ope, Val);
                }
            }
            else if (Val == "InActive" || Val == "Inactive" || Val == "inactive")
            {
                Val = "false";
                if (Ope == "=")
                {
                    DataTable DtFilter = SActiveDetails(false);
                    DvFilter = DtFilter.DefaultView;
                    FilterDataview(DvFilter, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable DtFilter = SActiveDetails(true);
                    DvFilter = DtFilter.DefaultView;
                    FilterDataview(DvFilter, Col, Ope, Val);
                }
            }
        }
    }

    /// <summary>
    /// To show active status Stakeholder details in gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRef_Click(object sender, ImageClickEventArgs e)
    {
        IsActive = true;
        DataTable DtStakeholder = SActiveDetails(IsActive);
        ViewState["DtStakeholder"] = DtStakeholder;
        BindStak(DtStakeholder);
        ddlCol.SelectedIndex = 0;
        ddlOpe.SelectedIndex = 0;
        ddlVal.SelectedIndex = 0;
    }

    /// <summary>
    /// To search Stakeholder details by different conditions 
    /// </summary>
    /// <param name="Dv"></param>
    /// <param name="Column"></param>
    /// <param name="Operator"></param>
    /// <param name="Value"></param>
    public void FilterDataview(DataView Dv, string Column, string Operator, string Value)
    {
        Dv.RowFilter = Column + " " + Operator + "'" + Value + "'";
        if (Dv.ToTable().Rows.Count == 0)
        {
            MsgStak.Msg = "Record(s) not found";
            MsgStak.showmsg();
            ViewState["DtStakeholder"] = Dv.ToTable();
            BindStak(Dv.ToTable());
            ddlCol.SelectedIndex = 0;
            ddlOpe.SelectedIndex = 0;
            ddlVal.SelectedIndex = 0;
        }
        else
        {
            ViewState["DtStakeholder"] = Dv.ToTable();
            BindStak(Dv.ToTable());
        }
    }

    /// <summary>
    ///  To Sort Stakeholder details by username ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkUserName_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtStakeholder"];
            DtSort.DefaultView.Sort = "UserID" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("UserID" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtStakeholder"] = Dv.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtStakeholder"];
            DtSort.DefaultView.Sort = "UserID" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("UserID" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtStakeholder"] = Dv.ToTable();
        }
        BindStak(Dv.ToTable());
    }

    /// <summary>
    /// To Sort Stakeholder details by Status ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtStakeholder"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtStakeholder"] = Dv.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtStakeholder"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtStakeholder"] = Dv.ToTable();
        }
        BindStak(Dv.ToTable());
    }

    /// <summary>
    /// To add new Stakeholder details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        MPopUpStak.Show();
        BindStakUser();
        ClearStak();
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GrdStakeholder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdStakeholder.PageIndex = e.NewPageIndex;
        DataTable DtStakeholder = (DataTable)ViewState["DtStakeholder"];
        BindStak(DtStakeholder);
    }

    /// <summary>
    /// Help for Stakeholder KAS Audit Master
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbStakeholderHelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/StakeholderHelp.pdf");
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