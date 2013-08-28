using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class Content_Developer : System.Web.UI.Page
{
    public string UserName;// For loged in username 
    public int LoginUser;// For loged in user id 
    public string Ret;// For return message 
    public static bool IsActive;// For user status
    DataTable DtConDev = new DataTable();// For Content Developer Table
    string Sort;//For sorting action 
    DataTable DtSort;//For sort table
    DataView Dv;//For sorting view

    /// <summary>
    /// Page Load Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int ConDevInd = MasterAcc.SelectedIndex;
        int ConDevIndex = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = ConDevIndex - 1;
        // To select loginuser id and login username
        Login objConDev = new Login();
        objConDev.Start();
        UserName = objConDev.LogedInUser;
        LoginUser = objConDev.LoginUser;
        Ret = objConDev.Ret;
        if (!Page.IsPostBack)
        {              
            IsActive = true;
            // To sort defaulty by Ascending order
            ViewState["Sort"] = "ASC";
            // To fetch Content Developer details having active status
            DataTable DtConDev = ConDevActiveDetails(IsActive);
            ViewState["DtConDev"] = DtConDev;
            if (DtConDev.Rows.Count > 0)
            {
                BindConDev(DtConDev);
            }
            else
            {
                GrdContentDeveloper.DataSource = null;
                GrdContentDeveloper.DataBind();
            }
        }
    }

    /// <summary>
    ///  To Load Active Status Content Developer details from 'Content Developer Business Access Layer'
    /// </summary>
    /// <param name="IsActive"></param>
    /// <returns></returns>
    protected DataTable ConDevActiveDetails(bool IsActive)
    {
         ContentDeveloperBAL ContentDeveloperBAL = new ContentDeveloperBAL();
        DataTable DtConDeve = new DataTable();
        try
        {
            DtConDeve = ContentDeveloperBAL.LoadActiveContentDeveloper(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentDeveloperBAL = null;
        }

        return DtConDeve;
    }

    /// <summary>
    ///  To bind Content developer details in gridview
    /// </summary>
    /// <param name="DtConDev"></param>
    private void BindConDev(DataTable DtConDev)
    {
        if (DtConDev.Rows.Count > 0)
        {
            GrdContentDeveloper.DataSource = DtConDev;
            GrdContentDeveloper.DataBind();
            for (int i = 0; i < GrdContentDeveloper.Rows.Count; i++)
            {
                Label lblCDUser = (GrdContentDeveloper.Rows[i].FindControl("lblUser") as Label);
                Label lblStatus = (GrdContentDeveloper.Rows[i].FindControl("lnkStatus") as Label);
                LinkButton lnkStatus = (GrdContentDeveloper.Rows[i].FindControl("lnkEdit") as LinkButton);
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
           // BindddlUser(DtConDev);
            GrdContentDeveloper.DataSource = null;
            GrdContentDeveloper.DataBind();
        }
    }


    /// <summary>
    ///  To fetch active status users from User Business Access Layer having content developer role
    /// </summary>
    /// <returns></returns>
    protected DataTable UserPerDetails()
    {
        UserBAL UserBAL = new UserBAL();
        DataTable DtUserDe = new DataTable();
        try
        {
            DtUserDe = UserBAL.LoadActiveUser(IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserBAL = null;
        }

        return DtUserDe;
    }

    /// <summary>
    ///  To edit content developer details in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        GridViewRow row = (GridViewRow)lnk.Parent.Parent;
        int idx = row.RowIndex;
        int intResult = 0;
        bool Status;
        int CDID;
        ContentDeveloperBAL ContentDeveloperBAL = new ContentDeveloperBAL();
        LinkButton lblIsActive = (GrdContentDeveloper.Rows[idx].FindControl("lnkEdit") as LinkButton);
        Label lblstatus = (GrdContentDeveloper.Rows[idx].FindControl("lnkStatus") as Label);
        {
            if (lblstatus.Text == "Active" || lblstatus.Text == "True")
            {
                Status = false;
                lblstatus.Text = "InActive";
                lblIsActive.Text = "Activate";
            }
            else
            {
                Status = true;
                lblstatus.Text = "Active";
                lblIsActive.Text = "Deactivate";
            }
            CDID = Convert.ToInt32(lnk.CommandArgument.ToString());
            lblSelectID.Text = CDID.ToString();
            Session["CDID"] = lblSelectID.Text;
            intResult = ContentDeveloperBAL.UpdateContentDeveloper(CDID, Status, LoginUser, Ret);
        }
    }
  
    /// <summary>
    ///  To bind Active directory users in dropdown list
    /// </summary>
    public void BindConDevUser()
    {
        DataTable dtuser = UserPerDetails();
        if (dtuser.Rows.Count > 0 || dtuser != null)
        {
            ddlConDevUser.DataSource = dtuser;
            ddlConDevUser.DataTextField = "UserName";
            ddlConDevUser.DataValueField = "UserID";
            ddlConDevUser.DataBind();
            ddlConDevUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
        }
        else
        {
            ddlConDevUser.DataSource = null;
            ddlConDevUser.DataTextField = "UserName";
            ddlConDevUser.DataValueField = "UserID";
            ddlConDevUser.DataBind();
            ddlConDevUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
        }
    }

    /// <summary>
    /// To save content developer details 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ContentDeveloperBAL ContentDeveloperBAL = new ContentDeveloperBAL();
        int UserID = Convert.ToInt32(ddlConDevUser.SelectedValue.ToString());
        string Status = ddlConDevStatus.SelectedValue.ToString();
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
                // 'InsertContentDeveloper' is Content developer business Access Layer function called
                // to insert Content Developer details
                int Result = ContentDeveloperBAL.InsertContentDeveloper(UserID, IsActive, LoginUser, Ret);
                DtConDev = ConDevDetails();
                ViewState["DtConDev"] = DtConDev;
                BindConDev(DtConDev);
                msgConDev.Msg = "Record added successfully";
                msgConDev.showmsg();
            }
            catch (Exception ee)
            {
                // Duplicate Entry is catched when inserting Content Developer       
                if (ee.Message == "Duplicate Entry")
                {
                    msgConDev.Msg = "Duplicate Entry!";
                    msgConDev.showmsg();
                    ClearConDev();
                }
            }
            finally
            {
                // Object is closed after use
                ContentDeveloperBAL = null;
            }
        }
    }

    /// <summary>
    ///  To bind Content developer of 'Active' and 'InActive' Status
    /// </summary>
    /// <returns></returns>
    protected DataTable ConDevDetails()
    {
        ContentDeveloperBAL ContentDeveloperBAL = new ContentDeveloperBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = ContentDeveloperBAL.LoadAllContentDeveloper(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentDeveloperBAL = null;
        }

        return dTable;
    }

    /// <summary>
    ///  To Cancel current operation 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearConDev();
        DtConDev = ConDevDetails();
        ViewState["DtConDev"] = DtConDev;
        BindConDev(DtConDev);
        mPopupConDev.Hide();
    }

    /// <summary>
    ///  To get specific Content developer details 
    /// </summary>
    /// <param name="ConDevID"></param>
    /// <returns></returns>
 
    protected DataTable GetUserDetails(int ConDevID)
    {
        ContentDeveloperBAL ContentDeveloperBAL = new ContentDeveloperBAL();
        DataTable DtConDevGetDet = new DataTable();
        try
        {
            // 'SelectContentDeveloperID' is called from Content developer BAL 
            //to fetch specific ContentDeveloper details by passing ContentDeveloperID
            DtConDevGetDet = ContentDeveloperBAL.SelectContentDeveloperID(ConDevID, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentDeveloperBAL = null;
        }

        return DtConDevGetDet;
    }

    /// <summary>
    ///  To clear Content developer dropdown selected value
    /// </summary>
    public void ClearConDev()
    {
        ddlConDevUser.SelectedIndex = 0;
        ddlConDevStatus.SelectedIndex = 0;
        ddlConDevUser.Enabled = true;
    }
   
    /// <summary>
    /// To search specified match case Content Developer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        string Col = ddlCol.SelectedValue;// For selected column in dropdownlist for search
        string Ope = ddlOpe.Text;// For selected operator in dropdownlist for search
        string Val = ddlVal.Text;// For selected value in dropdownlist for search
        DataView DvSearch = new DataView();
        if (Col == "IsActive")
        {
            if (Val == "Active" || Val == "active")
            {
                Val = "true";
                if (Ope == "=")
                {
                    DataTable DtSearch = ConDevActiveDetails(true);
                    DvSearch = DtSearch.DefaultView;
                    filterDataview(DvSearch, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable DtSearch = ConDevActiveDetails(false);
                    DvSearch = DtSearch.DefaultView;
                    filterDataview(DvSearch, Col, Ope, Val);
                }
            }
            else if (Val == "InActive" || Val == "Inactive" || Val == "inactive")
            {
                Val = "false";
                if (Ope == "=")
                {
                    DataTable DtSearch = ConDevActiveDetails(false);
                    DvSearch = DtSearch.DefaultView;
                    filterDataview(DvSearch, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable DtSearch = ConDevActiveDetails(true);
                    DvSearch = DtSearch.DefaultView;
                    filterDataview(DvSearch, Col, Ope, Val);
                }
            }

        }
    }

    /// <summary>
    ///  To filter details in grid on different conditions selected by user
    /// </summary>
    /// <param name="DvFilter"></param>
    /// <param name="Column"></param>
    /// <param name="Operator"></param>
    /// <param name="Value"></param>
    public void filterDataview(DataView DvFilter, string Column, string Operator, string Value)
    {
        DvFilter.RowFilter = Column + " " + Operator + "'" + Value + "'";
        if (DvFilter.ToTable().Rows.Count == 0)
        {
            msgConDev.Msg = "Record(s) not found";
            msgConDev.showmsg();
            ViewState["DtConDev"] = DvFilter.ToTable();
            BindConDev(DvFilter.ToTable());
            ddlCol.SelectedIndex = 0;
            ddlOpe.SelectedIndex = 0;
            ddlVal.SelectedIndex = 0;
        }
        else
        {
            ViewState["DtConDev"] = DvFilter.ToTable();
            BindConDev(DvFilter.ToTable());
        }
    }

    /// <summary>
    ///  To show 'Active ' and 'Inactive' status type content developer details in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRef_Click(object sender, ImageClickEventArgs e)
    {
        bool IsActive = true;
        DataTable DtConDev = ConDevActiveDetails(IsActive);
        ViewState["DtConDev"] = DtConDev;
        BindConDev(DtConDev);
        ddlCol.SelectedIndex = 0;
        ddlOpe.SelectedIndex = 0;
        ddlVal.SelectedIndex = 0;
    }

    /// <summary>
    ///  To sort Content developer grid details on Username by Ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkUserName_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtConDev"];
            DtSort.DefaultView.Sort = "UserID" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("UserID" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtConDev"] = Dv.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtConDev"];
            DtSort.DefaultView.Sort = "UserID" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("UserID" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtConDev"] = Dv.ToTable();
        }
        BindConDev(Dv.ToTable());
    }

    /// <summary>
    ///  To sort Content developer grid details on Status Ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtConDev"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtConDev"] = Dv.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtConDev"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtConDev"] = Dv.ToTable();
        }
        BindConDev(Dv.ToTable());
    }

    /// <summary>
    ///  To Add new Content Developer details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        BindConDevUser();
        ClearConDev();
        mPopupConDev.Show();
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GrdContentDeveloper_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GrdContentDeveloper.PageIndex = e.NewPageIndex;
        DataTable DtConDev = (DataTable)ViewState["DtConDev"];
        BindConDev(DtConDev);
    }

    /// <summary>
    /// Help for Content Developer Audit Master
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbConDeveHelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/ContentDeveloperHelp.pdf");
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