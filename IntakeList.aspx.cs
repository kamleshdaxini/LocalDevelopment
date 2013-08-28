using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IntakeList : System.Web.UI.Page
{
    public string Useraname;// For loged in username
    public int LoginUser;// For Loged in user id
    public string Ret;// For return message
    public bool IsActive;// For User status
    int IntakeFormId;// For IntakeForm id   
    DataTable DtSort;// For sorting in table
    DataView DvIF;// For Sorting view
    DataView DvIntForm;// For sorting Intake Form view
    string Ope, Col, Val, Sort;// For operator, Column, value, Sorting perpose 
   
    /// <summary>
    /// On Page Load 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion masteracc = (Accordion)Master.FindControl("acdnMaster");
        int ind = masteracc.SelectedIndex;
        int inx = Convert.ToInt16(Session["SrNo"]);
        IsActive = true;
        masteracc.SelectedIndex = inx - 1;
        Login obj = new Login();
        obj.Start();
        Useraname = obj.LogedInUser;
        LoginUser = obj.LoginUser;
        Ret = obj.Ret;
        // To select loginuser id and login username
        if (!Page.IsPostBack)
        {
            IsActive = true;
            // To sort defaulty by Ascending order
            ViewState["DtSortIntakeForm"] = "ASC";
            // To fetch IntakeForm details having active status
            DataTable DtIntForm = GetIntakeFormdetails();
            ViewState["DtIntakeForm"] = DtIntForm;
            BindGrid(DtIntForm);
            if (Session["IntakeFormId"] != null)
            {
                IntakeFormId = Convert.ToInt32(Session["IntakeFormId"].ToString());
            }
        }
       
    }


    protected string FormatCombinedAccessions(string value)
    {
        string[] Separator = new string[] { "@kpmg.aptaracorp.com" };
        string[] StrSplitArr = value.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
        return StrSplitArr[0].ToString();
    }
    /// <summary>
    ///  To bind IntakeForm details in Grid 
    /// </summary>
    /// <param name="DtIntakeForm"></param>
    private void BindGrid(DataTable DtIntakeForm)
    {
        if (DtIntakeForm.Rows.Count > 0 || DtIntakeForm != null)
        {
            grdIntakeDetails.DataSource = DtIntakeForm;
            grdIntakeDetails.DataBind();           
        }
        else
        {
            grdIntakeDetails.DataSource = null;
            grdIntakeDetails.DataBind();
        }
    }

    /// <summary>
    /// To load Intake Form details from database 
    /// </summary>
    /// <returns></returns>
    private DataTable GetIntakeFormdetails()
    {
        IntakeFormBAL  IntakeFormBAL=new IntakeFormBAL();
        DataTable DtIntakeGet = new DataTable();
        try
        {
            DtIntakeGet = IntakeFormBAL.LoadAllIntakeForm(LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            IntakeFormBAL = null;
        }
        return DtIntakeGet;
    }


  /// <summary>
  /// For paging in grid 
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    protected void grdIntakeDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdIntakeDetails.PageIndex = e.NewPageIndex;
        DataTable DtIntakeTable = (DataTable)ViewState["DtIntakeForm"];
        BindGrid(DtIntakeTable);   
    }
    protected void imbEdit_Click(object sender, ImageClickEventArgs e)
    { 
        ImageButton imbIntFrm=sender as ImageButton;       
        int IntFmId = Convert.ToInt32(imbIntFrm.CommandArgument.ToString());
        lblSelectID.Text = IntFmId.ToString();
        Session["IntakeFormId"] = lblSelectID.Text;
        Response.Redirect("IntakeForm.aspx", false);      
    }
    /// <summary>
    /// For user help 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imguserhelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/UserGroupRoleListHelp.docx");
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
   /// <summary>
    /// To sort grid Intake Form Date wise
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void lnkDate_Click(object sender, EventArgs e)
    {
        if (ViewState["DtSortIntakeForm"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtIntakeForm"];
            DtSort.DefaultView.Sort = "Origin_MeetingDate" + " ASC";
            DvIF = new DataView(DtSort);
            DvIF.Sort = ("Origin_MeetingDate" + " ASC");
            Sort = "DESC";
            ViewState["DtIntakeForm"] = DvIF.ToTable();
            ViewState["DtSortIntakeForm"] = Sort;
        }
        else if (ViewState["DtSortIntakeForm"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtIntakeForm"];
            DtSort.DefaultView.Sort = "Origin_MeetingDate" + " DESC";
            DvIF = new DataView(DtSort);
            DvIF.Sort = ("Origin_MeetingDate" + " DESC");
            Sort = "ASC";
            ViewState["DtIntakeForm"] = DvIF.ToTable();
            ViewState["DtSortIntakeForm"] = Sort;
        }
        BindGrid(DvIF.ToTable());    
    }

    /// <summary>
    ///  To clear data
    /// </summary>
    private void ClearGroup()
    {
        txtifValue.Text = "";
    }
    /// <summary>
    /// To filter Intake Form details by specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFilter_Click(object sender, ImageClickEventArgs e)
    {
        Col =ddlIFcolumn.Text;   // For selected column in dropdownlist for search     
        Val = txtifValue.Text.ToLower();// For selected value in textbox for search
        DataTable DtIF = GetIntakeFormdetails();// For get all Intake Form details in grid
        DvIntForm = DtIF.DefaultView;// For View of group details
        Ope = ddlifoperator.Text; // For   
        
        if (Ope == "LIKE")
        {
            string filterLike = Col + " " + Ope + "'%" + Val + "%' ";
            DvIntForm.RowFilter = filterLike;
            if (DvIntForm.ToTable().Rows.Count == 0)
            {
                msgIf.Msg = "Record(s) not found";
                msgIf.showmsg();
                BindGrid(DvIntForm.ToTable());
            }
            else
            {
                ViewState["DtIntakeForm"] = DvIntForm.ToTable();
                BindGrid(DvIntForm.ToTable());
            }
        }
        else if (Ope == "=")
        {
            DvIntForm.RowFilter = Col + Ope + "'" + Val + "'";
            if (DvIntForm.ToTable().Rows.Count == 0)
            {
                msgIf.Msg = "Record(s) not found";
                msgIf.showmsg();
                BindGrid(DvIntForm.ToTable());
            }
            else
            {
                ViewState["DtIntakeForm"] = DvIntForm.ToTable();
                BindGrid(DvIntForm.ToTable());
            }
        }
        else if (Ope == "<>")
        {
            DvIntForm.RowFilter = Col + Ope + "'" + Val + "'";
            if (DvIntForm.ToTable().Rows.Count == 0)
            {
                msgIf.Msg = "Record(s) not found";
                msgIf.showmsg();
                BindGrid(DvIntForm.ToTable());
            }
            else
            {
                ViewState["DtIntakeForm"] = DvIntForm.ToTable();
                BindGrid(DvIntForm.ToTable());
            }
        }
        else if (Ope == "NOT LIKE")
        {
            string FilterNotLike = Col + " " + Ope + "'%" + Val + "%' ";
            DvIntForm.RowFilter = FilterNotLike;
            if (DvIntForm.ToTable().Rows.Count == 0)
            {
                msgIf.Msg = "Record(s) not found";
                msgIf.showmsg();
                BindGrid(DvIntForm.ToTable());
            }
            else
            {
                ViewState["DtIntakeForm"] = DvIntForm.ToTable();
                BindGrid(DvIntForm.ToTable());
            }
        }       
    }

    /// <summary>
    /// To sort grid Intake Form Stakeholder Relationship Manager wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStkRelmng_Click(object sender, EventArgs e)
    {
         if (ViewState["DtSortIntakeForm"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtIntakeForm"];
            DtSort.DefaultView.Sort = "StakeholderRelationshipManager" + " ASC";
            DvIF = new DataView(DtSort);
            DvIF.Sort = ("StakeholderRelationshipManager" + " ASC");
            Sort = "DESC";
            ViewState["DtIntakeForm"] = DvIF.ToTable();
            ViewState["DtSortIntakeForm"] = Sort;
        }
        else if (ViewState["DtSortIntakeForm"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtIntakeForm"];
            DtSort.DefaultView.Sort = "StakeholderRelationshipManager" + " DESC";
            DvIF = new DataView(DtSort);
            DvIF.Sort = ("StakeholderRelationshipManager" + " DESC");
            Sort = "ASC";
            ViewState["DtIntakeForm"] = DvIF.ToTable();
            ViewState["DtSortIntakeForm"] = Sort;
        }
        BindGrid(DvIF.ToTable());    
    }
    /// <summary>
    /// To sort grid Intake Form TrainingNeedName wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkTrainingNeedName_Click(object sender, EventArgs e)
    {
        if (ViewState["DtSortIntakeForm"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtIntakeForm"];
            DtSort.DefaultView.Sort = "TrainingNeedName" + " ASC";
            DvIF = new DataView(DtSort);
            DvIF.Sort = ("TrainingNeedName" + " ASC");
            Sort = "DESC";
            ViewState["DtIntakeForm"] = DvIF.ToTable();
            ViewState["DtSortIntakeForm"] = Sort;
        }
        else if (ViewState["DtSortIntakeForm"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtIntakeForm"];
            DtSort.DefaultView.Sort = "TrainingNeedName" + " DESC";
            DvIF = new DataView(DtSort);
            DvIF.Sort = ("TrainingNeedName" + " DESC");
            Sort = "ASC";
            ViewState["DtIntakeForm"] = DvIF.ToTable();
            ViewState["DtSortIntakeForm"] = Sort;
        }
        BindGrid(DvIF.ToTable());
    }
}