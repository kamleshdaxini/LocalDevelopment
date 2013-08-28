using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class StakeholderRelationshipManager : System.Web.UI.Page
{

    public string UserName; // For loged in user
    public int LoginUser; // For loged in user id
    public string Ret; // For return message
    public static bool IsActive; // For status
    DataTable DtSRM = new DataTable(); // For Stakeholder Relationship Manager table 
    int SRMID; // For Stakeholder Relationship Manager Id
    string Sort; // For sorting
    DataTable DtSort; // For Sorting table
    DataView DvSRM; // For Stakeholder Relationship Manager Details View

    /// <summary>
    /// Page load Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int Ind  = MasterAcc.SelectedIndex;
        int Index = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = Index - 1;
        // To select loginuser id and login username
        Login objSRM = new Login();
        objSRM.Start();
        UserName = objSRM.LogedInUser;
        LoginUser = objSRM.LoginUser;
        Ret = objSRM.Ret;
        if (!Page.IsPostBack)
        {       
            IsActive = true;
            // To sort defaulty by Ascending order
            ViewState["Sort"] = "ASC";
            // To fetch Stakeholder Relationship Manager details having active status
            DataTable DtSRM = SRMActiveDetails(IsActive);
            ViewState["DtSRM"] = DtSRM;
            if (DtSRM.Rows.Count > 0)
            {
                BindSRM(DtSRM);
            }
            else
            {
                GrdSRM.DataSource = null;
                GrdSRM.DataBind();
            }            
        }
    }

    /// <summary>
    /// To edit Stakeholder Relationship Manager details in grid
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
        int SRMID;
        StakeholderRelationshipManagerBAL StakeholderRelationshipManagerBAL = new StakeholderRelationshipManagerBAL();
        LinkButton lblIsActive = (GrdSRM.Rows[Idx].FindControl("lnkEdit") as LinkButton);
        Label lblStatus = (GrdSRM.Rows[Idx].FindControl("lnkStatus") as Label);
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
            SRMID = Convert.ToInt32(lnk.CommandArgument.ToString());
            lblSelectID.Text = SRMID.ToString();
            Session["SRMID"] = lblSelectID.Text;
            IntResult = StakeholderRelationshipManagerBAL.UpdateStakeholderRelationshipManager(SRMID, Status, LoginUser, Ret);
        }

    }

    /// <summary>
    /// To save and update Stakeholder Relationship Manager details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        StakeholderRelationshipManagerBAL StakeholderRelationshipManagerBAL = new StakeholderRelationshipManagerBAL();
        int UserID = Convert.ToInt32(ddlSRMUser.SelectedValue.ToString());
        string Status = ddlSRMStatus.SelectedValue.ToString();
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
                int Result = StakeholderRelationshipManagerBAL.InsertStakeholderRelationshipManager(UserID, IsActive, LoginUser, Ret);
                DtSRM = SRMDetails();
                ViewState["DtSRM"] = DtSRM;
                BindSRM(DtSRM);
                MsgSRM.Msg = "Record added successfully";
                MsgSRM.showmsg();
            }
            catch (Exception ee)
            {
             if (ee.Message == "Duplicate Entry")
                {
                    MsgSRM.Msg = "Stakeholder Relationship Manager already exists";
                    MsgSRM.showmsg();
                    ClearSRM();
                }
            }
            finally
            {
                StakeholderRelationshipManagerBAL = null;
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
        ClearSRM();
        DtSRM = SRMDetails();
        ViewState["DtSRM"] = DtSRM;
        BindSRM(DtSRM);        
        MPopSRM.Hide();      
    }

    /// <summary>
    /// To get Stakeholder Relationship Manager having active status
    /// </summary>
    /// <returns></returns>
    protected DataTable SRMDetails()
    {
        StakeholderRelationshipManagerBAL StakeholderRelationshipManagerBAL = new StakeholderRelationshipManagerBAL();
        DataTable DtSRMDet = new DataTable();
        try
        {
            DtSRMDet = StakeholderRelationshipManagerBAL.LoadAllStakeholderRelationshipManager(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderRelationshipManagerBAL = null;
        }
        return DtSRMDet;
    }

    /// <summary>
    /// To get Stakeholder Relationship Manager having active status
    /// </summary>
    /// <param name="IsActive"></param>
    /// <returns></returns>
    protected DataTable SRMActiveDetails(bool IsActive)
    {
        StakeholderRelationshipManagerBAL StakeholderRelationshipManagerBAL = new StakeholderRelationshipManagerBAL();
        DataTable DtSRMAct = new DataTable();
        try
        {
            DtSRMAct = StakeholderRelationshipManagerBAL.LoadActiveStakeholderRelationshipManager(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderRelationshipManagerBAL = null;
        }
        return DtSRMAct;
    }

    /// <summary>
    /// To bind Stakeholder Relationship Manager details in grid
    /// </summary>
    /// <param name="DtSRM"></param>
    private void BindSRM(DataTable DtSRM)
    {
        if (DtSRM.Rows.Count > 0)
        {
            GrdSRM.DataSource = DtSRM;
            GrdSRM.DataBind();
            for (int i = 0; i < GrdSRM.Rows.Count; i++)
            {
                Label lblPLUser = (GrdSRM.Rows[i].FindControl("lblUser") as Label);
                Label lblStatus = (GrdSRM.Rows[i].FindControl("lnkStatus") as Label);
                LinkButton lnkStatus = (GrdSRM.Rows[i].FindControl("lnkEdit") as LinkButton);
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
            GrdSRM.DataSource = null;
            GrdSRM.DataBind();
        }
    }

    /// <summary>
    ///  To get specific Stakeholder Relationship Manager details 
    /// </summary>
    /// <param name="SRMID"></param>
    /// <returns></returns>
    protected DataTable GetUserDetails(int SRMID)
    {
        StakeholderRelationshipManagerBAL StakeholderRelationshipManagerBAL = new StakeholderRelationshipManagerBAL();
        DataTable DtGetUser = new DataTable();
        try
        {
            DtGetUser = StakeholderRelationshipManagerBAL.SelectStakeholderRelationshipManagerID(SRMID, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            StakeholderRelationshipManagerBAL = null;
        }
        return DtGetUser;
    }

    /// <summary>
    /// To bind Stakeholder Relationship Manager in dropdownlist
    /// </summary>
    public void BindSRMUser()
    {
        DataTable DtUser = UserPerDetails();
        if (DtUser.Rows.Count > 0 || DtUser != null)
        {
            ddlSRMUser.DataSource = DtUser;
            ddlSRMUser.DataTextField = "UserName";
            ddlSRMUser.DataValueField = "UserID";
            ddlSRMUser.DataBind();
            ddlSRMUser.Items.Insert(0, new ListItem("Select User", ""));
            ddlSRMUser.SelectedIndex = 0;
        }
        else
        {
            ddlSRMUser.DataSource = null;
            ddlSRMUser.DataTextField = "UserName";
            ddlSRMUser.DataValueField = "UserID";
            ddlSRMUser.DataBind();
            ddlSRMUser.Items.Insert(0, new ListItem("Select User", ""));
            ddlSRMUser.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// To get User details
    /// </summary>
    /// <returns></returns>
    protected DataTable UserPerDetails()
    {
        UserBAL UserBAL = new UserBAL();
        DataTable DtUserPerDet = new DataTable();
        try
        {
            DtUserPerDet = UserBAL.LoadActiveUser(IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserBAL = null;
        }
        return DtUserPerDet;
    }

    /// <summary>
    ///  To Clear dropdonlist 
    /// </summary>
    public void ClearSRM()
    {
        ddlSRMUser.SelectedIndex = 0;
        ddlSRMStatus.SelectedIndex = 0;
        ddlSRMUser.Enabled = true;
    }

    /// <summary>
    /// To search Stakeholder Relationship Manager on different conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        string Col = ddlCol.SelectedValue;
        string Ope = ddlOpe.Text;
        string Val = ddlVal.Text;
        DataView DvSRM = new DataView();
        if (Col == "IsActive")
        {
            if (Val == "Active")
            {
                Val = "true";
                if (Ope == "=")
                {
                    DataTable DtFilter = SRMActiveDetails(true);
                    DvSRM = DtFilter.DefaultView;
                    FilterDataView(DvSRM, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable DtFilter = SRMActiveDetails(false);
                    DvSRM = DtFilter.DefaultView;
                    FilterDataView(DvSRM, Col, Ope, Val);
                }
            }
            else if (Val == "InActive")
            {
                Val = "false";
                if (Ope == "=")
                {
                    DataTable DtFilter = SRMActiveDetails(false);
                    DvSRM = DtFilter.DefaultView;
                    FilterDataView(DvSRM, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable DtFilter = SRMActiveDetails(true);
                    DvSRM = DtFilter.DefaultView;
                    FilterDataView(DvSRM, Col, Ope, Val);
                }
            }
        }
    }

    /// <summary>
    /// To search Stakeholder Relationship Manager details by different conditions 
    /// </summary>
    /// <param name="DvSRM"></param>
    /// <param name="Column"></param>
    /// <param name="Operator"></param>
    /// <param name="Value"></param>
    public void FilterDataView(DataView DvSRM, string Column, string Operator, string Value)
    {
        DvSRM.RowFilter = Column + " " + Operator + "'" + Value + "'";
        if (DvSRM.ToTable().Rows.Count == 0)
        {
            MsgSRM.Msg = "Record(s) not found";
            MsgSRM.showmsg();
            ViewState["DtSRM"] = DvSRM.ToTable(); ;
            BindSRM(DvSRM.ToTable());
            ddlCol.SelectedIndex = 0;
            ddlOpe.SelectedIndex = 0;
            ddlVal.SelectedIndex = 0;
        }
        else
        {
            ViewState["DtSRM"] = DvSRM.ToTable(); ;
            BindSRM(DvSRM.ToTable());
        }
    }

    /// <summary>
    /// To show active status Stakeholder Relationship Manager details in gridview
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRef_Click(object sender, ImageClickEventArgs e)
    {
        bool IsActive = true;
        DataTable DtSRM = SRMActiveDetails(IsActive);
        ViewState["DtSRM"] = DtSRM;
        BindSRM(DtSRM);
        ddlCol.SelectedIndex = 0;
        ddlOpe.SelectedIndex = 0;
        ddlVal.SelectedIndex = 0;
    }
    
    /// <summary>
    /// To Sort Stakeholder Relationship Manager details by username ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkUserName_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtSRM"];
            DtSort.DefaultView.Sort = "UserID" + " ASC";
            DvSRM = new DataView(DtSort);
            DvSRM.Sort = ("UserID" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtSRM"] = DvSRM.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtSRM"];
            DtSort.DefaultView.Sort = "UserID" + " DESC";
            DvSRM = new DataView(DtSort);
            DvSRM.Sort = ("UserID" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtSRM"] = DvSRM.ToTable();
        }
        BindSRM(DvSRM.ToTable());
    }

    /// <summary>
    /// To Sort Stakeholder Relationship Manager details by Status ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtSRM"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            DvSRM = new DataView(DtSort);
            DvSRM.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtSRM"] = DvSRM.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtSRM"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            DvSRM = new DataView(DtSort);
            DvSRM.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtSRM"] = DvSRM.ToTable();
        }
        BindSRM(DvSRM.ToTable());
    }

    /// <summary>
    /// To add new Stakeholder Relationship Manager details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        MPopSRM.Show();
        BindSRMUser();
        ClearSRM();
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GrdSRM_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdSRM.PageIndex = e.NewPageIndex;
        DataTable DtSRM = (DataTable)ViewState["DtSRM"];
        BindSRM(DtSRM);
    }

    /// <summary>
    /// Help for Stakeholder Relationship Manager KBS Audit Master
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSRMHelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/StakeholderRelationshipManagerHelp.pdf");
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