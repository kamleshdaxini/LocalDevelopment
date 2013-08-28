using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class Content_Lead : System.Web.UI.Page
{
    public  string UserName;// For loged in Username
    public  int LoginUser;// For Loged in userId
    public  string Ret; // Fro return message
    public static bool IsActive;// For User Status
    DataTable DtConLead = new DataTable();// For Content Lead Table
    int ConLeadID;// Conttent Lead ID
    string Sort;// For Sorting
    DataTable DtSort;// For sorting table
    DataView DvConDev;// For Content Developer view

    /// <summary>
    /// Page Load Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int ConLeadInd = MasterAcc.SelectedIndex;
        int ConLeadIndex = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = ConLeadIndex - 1;
        // To select loginuser id and login username
        Login objConLead = new Login();
        objConLead.Start();
        UserName = objConLead.LogedInUser;
        LoginUser = objConLead.LoginUser;
        Ret = objConLead.Ret;
        if (!Page.IsPostBack)
        {       
            IsActive = true;
            // To sort defaulty by Ascending order
            ViewState["Sort"] = "ASC";
            // To fetch Content Lead details having active status
            DataTable DtConLead = ConLeadActiveDetails(IsActive);
            ViewState["DtConLead"] = DtConLead;
            if (DtConLead.Rows.Count > 0)
            {
                BindConLead(DtConLead);
            }
            else
            {
                GrdContentLead.DataSource = null;
                GrdContentLead.DataBind();
            }
        }
    }

    /// <summary>
    ///  To Load Active Status Content Lead details from 'Content Lead Business Access Layer'
    /// </summary>
    /// <param name="IsActive"></param>
    /// <returns></returns>
    protected DataTable ConLeadActiveDetails(bool IsActive)
    {

        ContentLeadBAL ContentLeadBAL = new ContentLeadBAL();
        DataTable DtConLeadDet = new DataTable();
        try
        {
            DtConLeadDet = ContentLeadBAL.LoadActiveContentLead(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentLeadBAL = null;
        }

        return DtConLeadDet;
    }

    /// <summary>
    ///  To bind Content Lead details in gridview
    /// </summary>
    /// <param name="DtConLead"></param>
    private void BindConLead(DataTable DtConLead)
    {
        if (DtConLead.Rows.Count > 0 )
        {
            GrdContentLead.DataSource = DtConLead;
            GrdContentLead.DataBind();
            for (int i = 0; i < GrdContentLead.Rows.Count; i++)
            {
                Label lblConLeadUser = (GrdContentLead.Rows[i].FindControl("lblUser") as Label);
                Label lblStatus = (GrdContentLead.Rows[i].FindControl("lnkStatus") as Label);
                LinkButton lnkStatus = (GrdContentLead.Rows[i].FindControl("lnkEdit") as LinkButton);
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
            GrdContentLead.DataSource = null;
            GrdContentLead.DataBind();
        }
    }

    /// <summary>
    /// To fetch active status users from User Business Access Layer having content Lead role
    /// </summary>
    /// <returns></returns>
    protected DataTable UserPerDetails()
    {
        UserBAL UserBAL = new UserBAL();
        DataTable DtUserConLead = new DataTable();
        try
        {
            DtUserConLead = UserBAL.LoadActiveUser(IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            UserBAL = null;
        }

        return DtUserConLead;
    }

    /// <summary>
    ///  To edit content lead details in grid
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
        int ConLeadID;
        ContentLeadBAL ContentLeadBAL = new ContentLeadBAL();
        LinkButton lblIsActive = (GrdContentLead.Rows[Idx].FindControl("lnkEdit") as LinkButton);
        Label lblStatus = (GrdContentLead.Rows[Idx].FindControl("lnkStatus") as Label);
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
            ConLeadID = Convert.ToInt32(lnk.CommandArgument.ToString());
            lblSelectID.Text = ConLeadID.ToString();
            Session["ConLeadID"] = lblSelectID.Text;
            IntResult = ContentLeadBAL.UpdateContentLead(ConLeadID, Status, LoginUser, Ret);
        }
    }

    /// <summary>
    ///  To bind Active directory users in dropdown list
    /// </summary>
    public void BindConLeadUser()
    {
        DataTable DtUser = UserPerDetails();
        if (DtUser.Rows.Count > 0 || DtUser != null)
        {
            ddlConLeadUser.DataSource = DtUser;
            ddlConLeadUser.DataTextField = "UserName";
            ddlConLeadUser.DataValueField = "UserID";
            ddlConLeadUser.DataBind();
            ddlConLeadUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlConLeadUser.SelectedIndex = 0;
        }
        else
        {
            ddlConLeadUser.DataSource = null;
            ddlConLeadUser.DataTextField = "UserName";
            ddlConLeadUser.DataValueField = "UserID";
            ddlConLeadUser.DataBind();
            ddlConLeadUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlConLeadUser.SelectedIndex = 0;
        }
    }

    /// <summary>
    ///  To save content lead details 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ContentLeadBAL ContentLeadBAL = new ContentLeadBAL();
        int UserID = Convert.ToInt32(ddlConLeadUser.SelectedValue.ToString());
        string Status = ddlConLeadStatus.SelectedValue.ToString();
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
                // 'InsertContentLead' is Content lead business Access Layer function called
                // to insert Content lead details
                int Result = ContentLeadBAL.InsertContentLead(UserID, IsActive, LoginUser, Ret);
                DtConLead = ConLeadDetails();
                ViewState["DtConLead"] = DtConLead;
                BindConLead(DtConLead);
                MsgConLead.Msg = "Record added successfully";
                MsgConLead.showmsg();
            }
            catch(Exception ee)
            {
                // Duplicate Entry is catched when inserting Content Developer       
                if (ee.Message == "Duplicate Entry")
                {
                    MsgConLead.Msg = "Duplicate Entry!";
                    MsgConLead.showmsg();
                    ClearConLead();
                }
            }
            finally
            {
                // Object is closed after use
                ContentLeadBAL = null;
            }
        }
    }

    /// <summary>
    /// To bind Content lead of 'Active' and 'InActive' Status
    /// </summary>
    /// <returns></returns>
    protected DataTable ConLeadDetails()
    {
        ContentLeadBAL ContentLeadBAL = new ContentLeadBAL();
        DataTable DtConLeadDet = new DataTable();
        try
        {
            DtConLeadDet = ContentLeadBAL.LoadContentLeadAll(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentLeadBAL = null;
        }

        return DtConLeadDet;
    }

    /// <summary>
    ///  To Cancel current operation 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearConLead();
        DtConLead = ConLeadDetails();
        ViewState["DtConLead"] = DtConLead;
        BindConLead(DtConLead);
        MpopUpConLead.Hide();   
    }

    /// <summary>
    ///  To get specific Content lead details
    /// </summary>

    protected void CheckConLeadId()
    {
        ConLeadID = Convert.ToInt32(Session["ConLeadID"].ToString());
        DataTable SelectIdDt = GetUserDetails(ConLeadID);
        if (btnSave.Text == "Save")
        {
            if (SelectIdDt.Rows.Count > 0)
            {
                string idx = SelectIdDt.Rows[0][10].ToString();
                ddlConLeadUser.SelectedValue = idx;
                ddlConLeadUser.Enabled = false;
                string status = SelectIdDt.Rows[0][2].ToString();
                if (status == "True")
                {
                    ddlConLeadStatus.SelectedIndex = 0;
                }
                else
                {
                    ddlConLeadStatus.SelectedIndex = 1;
                }
                btnSave.Text = "Update";
            }
        }
    }

    /// <summary>
    ///  To get specific Content developer details 
    /// </summary>
    /// <param name="ConLeadID"></param>
    /// <returns></returns>
 
    protected DataTable GetUserDetails(int ConLeadID)
    {
        ContentLeadBAL ContentLeadBAL = new ContentLeadBAL();
        DataTable DtGetUserDet = new DataTable();
        try
        {
            DtGetUserDet = ContentLeadBAL.SelectContentLeadId(ConLeadID, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentLeadBAL = null;
        }

        return DtGetUserDet;
    }

    /// <summary>
    ///  To clear Content lead dropdown selected value
    /// </summary>
    public void ClearConLead()
    {
        ddlConLeadUser.SelectedIndex = 0;
        ddlConLeadStatus.SelectedIndex = 0;
        ddlConLeadUser.Enabled = true;
    }

    /// <summary>
    ///  To search specified match case Content Lead
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {       
        string Col = ddlCol.SelectedValue;
        string Ope = ddlOpe.Text;
        string Val = ddlVal.Text;
        DataView DvConDev = new DataView();
        if (Col == "IsActive")
        {
            if (Val == "Active" || Val == "active")
            {
                Val = "true";
                if (Ope == "=")
                {
                    DataTable dt = ConLeadActiveDetails(true);
                    DvConDev = dt.DefaultView;
                    filterDataview(DvConDev, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable dt = ConLeadActiveDetails(false);
                    DvConDev = dt.DefaultView;
                    filterDataview(DvConDev, Col, Ope, Val);
                }
            }
            else if (Val == "InActive" || Val == "Inactive" || Val == "inactive")
            {
                Val = "false";
                if (Ope == "=")
                {
                    DataTable dt = ConLeadActiveDetails(false);
                    DvConDev = dt.DefaultView;
                    filterDataview(DvConDev, Col, Ope, Val);                   
                }
                else if (Ope == "<>")
                {
                    DataTable dt = ConLeadActiveDetails(true);
                    DvConDev = dt.DefaultView;
                    filterDataview(DvConDev, Col, Ope, Val);
                }
            }

        }
    }

    /// <summary>
    ///  To filter details in grid on different conditions selected by user
    /// </summary>
    /// <param name="DvConDev"></param>
    /// <param name="Column"></param>
    /// <param name="Operator"></param>
    /// <param name="Value"></param>
    public void filterDataview(DataView DvConDev, string Column, string Operator, string Value)
    { 
      DvConDev.RowFilter = Column + " " + Operator + "'" + Value + "'";
      if (DvConDev.ToTable().Rows.Count == 0)
      {
       MsgConLead.Msg = "Record(s) not found";
       MsgConLead.showmsg();
       ViewState["DtConLead"] = DvConDev.ToTable();
       BindConLead(DvConDev.ToTable());
       ddlCol.SelectedIndex = 0;
       ddlOpe.SelectedIndex = 0;
       ddlVal.SelectedIndex = 0;   
      }
      else
      {
       ViewState["DtConLead"] = DvConDev.ToTable();    
       BindConLead(DvConDev.ToTable());
      }   
    }

    /// <summary>
    ///  To show 'Active ' and 'Inactive' status type content lead details in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRef_Click(object sender, ImageClickEventArgs e)
    {
        bool IsActive = true;
        DataTable DtConLead = ConLeadActiveDetails(IsActive);
        ViewState["DtConLead"] = DtConLead;
        BindConLead(DtConLead);
        ddlCol.SelectedIndex = 0;
        ddlOpe.SelectedIndex = 0;
        ddlVal.SelectedIndex = 0;
    }

    /// <summary>
    ///  To sort Content lead grid details on Username by Ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkUserName_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtConLead"];
            DtSort.DefaultView.Sort = "UserID" + " ASC";
            DvConDev = new DataView(DtSort);
            DvConDev.Sort = ("UserID" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtConLead"] = DvConDev.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtConLead"];
            DtSort.DefaultView.Sort = "UserID" + " DESC";
            DvConDev = new DataView(DtSort);
            DvConDev.Sort = ("UserID" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtConLead"] = DvConDev.ToTable();
        }
        BindConLead(DvConDev.ToTable());
    }

    /// <summary>
    ///  To sort Content lead grid details on Status Ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtConLead"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            DvConDev = new DataView(DtSort);
            DvConDev.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtConLead"] = DvConDev.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtConLead"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            DvConDev = new DataView(DtSort);
            DvConDev.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtConLead"] = DvConDev.ToTable();
        }
        BindConLead(DvConDev.ToTable());
    }

    /// <summary>
    ///  To Add new Content lead details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        BindConLeadUser();
        ClearConLead();
        MpopUpConLead.Show();
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GrdContentLead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdContentLead.PageIndex = e.NewPageIndex;
        DataTable DtConLead = (DataTable)ViewState["DtConLead"];
        BindConLead(DtConLead);
    }

    /// <summary>
    /// Help for Content Lead Audit Master
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbConLeadHelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/ContentLeadHelp.pdf");
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