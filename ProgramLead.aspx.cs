using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;


public partial class ProgramLead : System.Web.UI.Page
{

    public string UserName; // For loged in user
    public int LoginUser; // For loged in user id
    public string Ret; // For return message
    public static bool IsActive; // For status
    DataTable DtProLead = new DataTable(); // For Program Lead table
    int ProLeadID; // For Program Lead Id
    string Sort; // For sorting
    DataTable DtSort; // For Sorting table
    DataView DvProLead; // For Program Lead Details View

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
        Login objProLead = new Login();
        objProLead.Start();
        UserName = objProLead.LogedInUser;
        LoginUser = objProLead.LoginUser;
        Ret = objProLead.Ret;
        if (!Page.IsPostBack)
        {
            IsActive = true;
            // To sort defaulty by Ascending order
            ViewState["Sort"] = "ASC";
            // To fetch Program Lead details having active status
            DataTable DtProLead = ProLeadActiveDetails(IsActive);
            ViewState["DtProLead"] = DtProLead;
            BindProLead(DtProLead);
            if (DtProLead.Rows.Count > 0)
            {
                BindProLead(DtProLead);
            }
            else
            {
                GrdProgramLead.DataSource = null;
                GrdProgramLead.DataBind();
            }
        }
    }

    /// <summary>
    /// To bind Program Lead in dropdownlist
    /// </summary>
    public void BindProLeadUser()
    {
        DataTable DtUser = UserPerDetails();
        if (DtUser.Rows.Count > 0 || DtUser != null)
        {
            ddlProLeadUser.DataSource = DtUser;
            ddlProLeadUser.DataTextField = "UserName";
            ddlProLeadUser.DataValueField = "UserID";
            ddlProLeadUser.DataBind();
            ddlProLeadUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlProLeadUser.SelectedIndex = 0;
        }
        else
        {
            ddlProLeadUser.DataSource = null;
            ddlProLeadUser.DataTextField = "UserName";
            ddlProLeadUser.DataValueField = "UserID";
            ddlProLeadUser.DataBind();
            ddlProLeadUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlProLeadUser.SelectedIndex = 0;
        }  
    }

    /// <summary>
    /// To get User details
    /// </summary>
    /// <returns></returns>
    protected DataTable UserPerDetails()
    {
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
    /// To edit Program Lead details in grid
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
        int ProLeadID;
        ProgramLeadBAL ProgramLeadBAL = new ProgramLeadBAL();
        LinkButton lblIsActive = (GrdProgramLead.Rows[Idx].FindControl("lnkEdit") as LinkButton);
        Label lblStatus = (GrdProgramLead.Rows[Idx].FindControl("lnkStatus") as Label);
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
            ProLeadID = Convert.ToInt32(lnk.CommandArgument.ToString());
            lblSelectID.Text = ProLeadID.ToString();
            Session["ProLeadID"] = lblSelectID.Text;
            IntResult = ProgramLeadBAL.UpdateProgramLead(ProLeadID, Status, LoginUser, Ret);
        }
    }

    /// <summary>
    /// To save and update Program Lead details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ProgramLeadBAL ProgramLeadBAL = new ProgramLeadBAL();
        int UserID = Convert.ToInt32(ddlProLeadUser.SelectedValue.ToString());
        string Status = ddlProLeadStatus.SelectedValue.ToString();
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
                int Result = ProgramLeadBAL.InsertProgramLead(UserID, IsActive, LoginUser, Ret);
                DtProLead = ProLeadDetails();
                ViewState["DtProLead"] = DtProLead;
                BindProLead(DtProLead);
                MsgProLead.Msg = "Program Lead added successfully";
                MsgProLead.showmsg();
            }
            catch (Exception ee)
            {
                if (ee.Message == "DuProLeadicate Entry")
                {
                    MsgProLead.Msg = "Program Lead already exists";
                    MsgProLead.showmsg();
                    ClearProLead();
                }
            }
            finally
            {
                ProgramLeadBAL = null;
            }
        }
    }

    /// <summary>
    /// To get Program Lead details from Program Lead Business access layer
    /// </summary>
    /// <returns></returns>
    protected DataTable ProLeadDetails()
    {
        ProgramLeadBAL ProgramLeadBAL = new ProgramLeadBAL();
        DataTable DtProLeadDet = new DataTable();
        try
        {
            DtProLeadDet = ProgramLeadBAL.LoadAllProgramLead(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            ProgramLeadBAL = null;
        }
        return DtProLeadDet;
    } 

    /// <summary>
    /// To get Program Lead having active status
    /// </summary>
    /// <param name="IsActive"></param>
    /// <returns></returns>
    protected DataTable ProLeadActiveDetails(bool IsActive)
    {
        ProgramLeadBAL ProgramLeadBAL = new ProgramLeadBAL();
        DataTable DtProLeadADet = new DataTable();
        try
        {
            DtProLeadADet = ProgramLeadBAL.LoadActiveProgramLead(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            ProgramLeadBAL = null;
        }
        return DtProLeadADet;
    }

    /// <summary>
    /// To bind Program Lead details in grid
    /// </summary>
    /// <param name="DtProLead"></param>
    private void BindProLead(DataTable DtProLead)
    {
        if (DtProLead.Rows.Count > 0)
        {
            GrdProgramLead.DataSource = DtProLead;
            GrdProgramLead.DataBind();
            for (int i = 0; i < GrdProgramLead.Rows.Count; i++)
            {
                Label lblProLeadUser = (GrdProgramLead.Rows[i].FindControl("lblUser") as Label);
                Label lblStatus = (GrdProgramLead.Rows[i].FindControl("lnkStatus") as Label);
                LinkButton lnkStatus = (GrdProgramLead.Rows[i].FindControl("lnkEdit") as LinkButton);
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
            GrdProgramLead.DataSource = null;
            GrdProgramLead.DataBind();
        }

    }

   /// <summary>
   ///  To get specific Program Lead details 
   /// </summary>
   /// <param name="ProLeadUserID"></param>
   /// <returns></returns>
   protected DataTable GetUserDetails(int ProLeadUserID)
   {
       ProgramLeadBAL ProgramLeadBAL = new ProgramLeadBAL();
       DataTable DtGetUser = new DataTable();
       try
       {
           DtGetUser = ProgramLeadBAL.SelectProgramLeadID(ProLeadUserID, LoginUser, Ret);
       }
       catch
       {
           throw;
       }
       finally
       {
           ProgramLeadBAL = null;
       }
       return DtGetUser;
   }

   /// <summary>
   ///  To Cancel current operation
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
   protected void btnCancel_Click(object sender, EventArgs e)
   {
       MPopUpProLead.Hide();
       ClearProLead();
       DtProLead = ProLeadDetails();
       ViewState["DtProLead"] = DtProLead;
       BindProLead(DtProLead);    
   }
   
   /// <summary>
   /// To Clear dropdonlist 
   /// </summary>
   public void ClearProLead()
   {
       ddlProLeadUser.SelectedIndex = 0;
       ddlProLeadStatus.SelectedIndex = 0;
       ddlProLeadUser.Enabled = true;
   }

    /// <summary>
    ///  To search Program Lead on different conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
   protected void imbSearch_Click(object sender, ImageClickEventArgs e)
   {
       string Col = ddlCol.SelectedValue; // For selected column in dropdownlist for search
       string Ope = ddlOpe.Text; // For selected operator in dropdownlist for search
       string Val = ddlVal.Text; // For selected value in dropdownlist for search
       DataView DvProLead = new DataView();
       if (Col == "IsActive")
       {
           if (Val == "Active" || Val == "active")
           {
               Val = "true";
               if (Ope == "=")
               {
                   DataTable DtSearch = ProLeadActiveDetails(true);
                   DvProLead = DtSearch.DefaultView;
                   FilterDataview(DvProLead, Col, Ope, Val);
               }
               else if (Ope == "<>")
               {
                   DataTable DtSearch = ProLeadActiveDetails(false);
                   DvProLead = DtSearch.DefaultView;
                   FilterDataview(DvProLead, Col, Ope, Val);
               }
           }
           else if (Val == "InActive" || Val == "Inactive" || Val == "inactive")
           {
               Val = "false";
               if (Ope == "=")
               {
                   DataTable DtSearch = ProLeadActiveDetails(false);
                   DvProLead = DtSearch.DefaultView;
                   FilterDataview(DvProLead, Col, Ope, Val);
               }
               else if (Ope == "<>")
               {
                   DataTable DtSearch = ProLeadActiveDetails(true);
                   DvProLead = DtSearch.DefaultView;
                   FilterDataview(DvProLead, Col, Ope, Val);
               }
           }
       }
   }

   /// <summary>
   /// To show active status Program Lead details in gridview
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
   protected void imbRef_Click(object sender, ImageClickEventArgs e)
   {
       bool IsActive = true;
       DataTable DtProLead = ProLeadActiveDetails(IsActive);
       ViewState["DtProLead"] = DtProLead;
       BindProLead(DtProLead);
       ddlCol.SelectedIndex = 0;
       ddlOpe.SelectedIndex = 0;
       ddlVal.SelectedIndex = 0;
   }

   /// <summary>
   /// To search Program Lead details by different conditions 
   /// </summary>
   /// <param name="DvProLead"></param>
   /// <param name="Column"></param>
   /// <param name="Operator"></param>
   /// <param name="Value"></param>
   public void FilterDataview(DataView DvProLead, string Column, string Operator, string Value)
   {
       DvProLead.RowFilter = Column + " " + Operator + "'" + Value + "'";
       if (DvProLead.ToTable().Rows.Count == 0)
       {
           MsgProLead.Msg = "Record(s) not found";
           MsgProLead.showmsg();
           ViewState["DtProLead"] = DvProLead.ToTable();
           BindProLead(DvProLead.ToTable());
           ddlCol.SelectedIndex = 0;
           ddlOpe.SelectedIndex = 0;
           ddlVal.SelectedIndex = 0;
       }
       else
       {
           ViewState["DtProLead"] = DvProLead.ToTable();
           BindProLead(DvProLead.ToTable());
       }
   }

   /// <summary>
   ///  To Sort Program Lead details by username ascending and descending way
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
   protected void lnkUserName_Click(object sender, EventArgs e)
   {
       if (ViewState["Sort"].ToString() == "ASC")
       {
           DtSort = (DataTable)ViewState["DtProLead"];
           DtSort.DefaultView.Sort = "UserID" + " ASC";
           DvProLead = new DataView(DtSort);
           DvProLead.Sort = ("UserID" + " ASC");
           Sort = "DESC";
           ViewState["Sort"] = Sort;
           ViewState["DtProLead"] = DvProLead.ToTable();
       }
       else if (ViewState["Sort"].ToString() == "DESC")
       {
           DtSort = (DataTable)ViewState["DtProLead"];
           DtSort.DefaultView.Sort = "UserID" + " DESC";
           DvProLead = new DataView(DtSort);
           DvProLead.Sort = ("UserID" + " DESC");
           Sort = "ASC";
           ViewState["Sort"] = Sort;
           ViewState["DtProLead"] = DvProLead.ToTable();
       }
       BindProLead(DvProLead.ToTable());
   }

   /// <summary>
   /// To Sort Program Lead details by Status ascending and descending way
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
   protected void lnkStatus_Click(object sender, EventArgs e)
   {
       if (ViewState["Sort"].ToString() == "ASC")
       {
           DtSort = (DataTable)ViewState["DtProLead"];
           DtSort.DefaultView.Sort = "IsActive" + " ASC";
           DvProLead = new DataView(DtSort);
           DvProLead.Sort = ("IsActive" + " ASC");
           Sort = "DESC";
           ViewState["Sort"] = Sort;
           ViewState["DtProLead"] = DvProLead.ToTable();
       }
       else if (ViewState["Sort"].ToString() == "DESC")
       {
           DtSort = (DataTable)ViewState["DtProLead"];
           DtSort.DefaultView.Sort = "IsActive" + " DESC";
           DvProLead = new DataView(DtSort);
           DvProLead.Sort = ("IsActive" + " DESC");
           Sort = "ASC";
           ViewState["Sort"] = Sort;
           ViewState["DtProLead"] = DvProLead.ToTable();
       }
       BindProLead(DvProLead.ToTable());
   }

   /// <summary>
   /// To add new Program Lead details
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
   protected void lnkAddNew_Click(object sender, EventArgs e)
   {
       BindProLeadUser();
       ClearProLead();
       MPopUpProLead.Show();

   }

   /// <summary>
   /// For paging in grid
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
   protected void GrdProgramLead_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
       GrdProgramLead.PageIndex = e.NewPageIndex;
       DataTable DtProLead = (DataTable)ViewState["DtProLead"];
       BindProLead(DtProLead);
   }

   /// <summary>
   /// Help for Program Lead KBS Audit Master
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
   protected void imbProgLeadHelp_Click(object sender, ImageClickEventArgs e)
   {
       string fPath = Server.MapPath("Help/ProgramLeadHelp.pdf");
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