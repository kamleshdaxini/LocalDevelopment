using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using AjaxControlToolkit;
using System.IO;


public partial class GroupList : System.Web.UI.Page
{ 
    // Initialization of public variables
    public string Useraname;// For logged in username
    public int LoginUser;// For loged in User ID
    public string Ret;// For Return message
    string Ope, Col, Val, Sort;// For operator, Column, value, Sorting perpose
    DataTable DtSort;// For Sorting in Table
    DataView DvGroup;// For Group table
 
    /// <summary>
    ///  Page Load Method 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int GroupInd = MasterAcc.SelectedIndex;
        int GroupIndex = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = GroupIndex - 1;
        // To select loginuser id and login username
        Login objGroup = new Login();
        objGroup.Start();
        Useraname = objGroup.LogedInUser;
        LoginUser = objGroup.LoginUser;
        Ret = objGroup.Ret;
        if (!Page.IsPostBack)
        {
           // To sort defaulty by Ascending order
            ViewState["grpSort"] = "ASC";
            // To fetch Group details having active status
            DataTable DtGrp = ActivegetGroupDetails();
            ViewState["grpdtNewGroup"] = DtGrp;
            BindGrid(DtGrp);          
        }
    }

    /// <summary>
    ///  To bind Group details to Grid 
    /// </summary>
    /// <param name="DtGroup"></param>
    private void BindGrid(DataTable DtGroup)
    {
        if (DtGroup.Rows.Count > 0 || DtGroup != null)
        {
            grdGroupDetails.DataSource = DtGroup;
            grdGroupDetails.DataBind();
            for (int i = 0; i < grdGroupDetails.Rows.Count; i++)
            {
                Label lblIsActive = (grdGroupDetails.Rows[i].FindControl("lblIsActive") as Label);
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
            grdGroupDetails.DataSource = null;
            grdGroupDetails.DataBind();
        }
    }

    /// <summary>
    ///  To clear data
    /// </summary>
    private void ClearGroup()
    {
        txtGrpValue.Text = "";
    }
    
    /// <summary>
    /// To load Group details form database 
    /// </summary>
    /// <returns></returns>
    private DataTable getGroupDetails()
    {
        GroupBAL GroupBAL = new GroupBAL();
        DataTable DtGroupGet = new DataTable();
        try
        {
            DtGroupGet = GroupBAL.LoadAllGroup(LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            GroupBAL = null;
        }
        return DtGroupGet;
    }

    /// <summary>
    ///  To get Active Group details
    /// </summary>
    /// <returns></returns>
    private DataTable ActivegetGroupDetails()
    {
        GroupBAL g = new GroupBAL();
        DataTable DtActiveGroup = new DataTable();
        try
        {
            DtActiveGroup = g.LoadActiveGroup(true, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            g = null;
        }
        return DtActiveGroup;
    }

    /// <summary>
    /// To filter group details by specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbFilter_Click(object sender, ImageClickEventArgs e)
    {
        Col = ddlGrpCol.Text;   // For selected column in dropdownlist for search     
        Val = txtGrpValue.Text.ToLower();// For selected value in textbox for search
        DataTable dt = getGroupDetails();// For get all group details in grid
        DataView DvGroup = dt.DefaultView;// For View of group details
        if (Col == "IsActive")
        {
            Ope = ddlGrpOpeSta.Text;// For operator in search condition
            Val = ddlStatus.SelectedValue;// For value in search condition
            if (Val == "true" || Val == "active")
            {
                Val = "true";
            }
            else if (Val == "false" || Val == "inactive")
            {
                Val = "false";
            }
        }
        else
        {
            Ope = ddlGrpOpe.Text;
        }
        if (Ope == "LIKE")
        {
            string filterLike= Col + " " + Ope + "'%" + Val + "%' ";
            DvGroup.RowFilter = filterLike;
            if (DvGroup.ToTable().Rows.Count == 0)
            {
                msgGroup.Msg = "Record(s) not found";
                msgGroup.showmsg();
                BindGrid(DvGroup.ToTable());
            }
            else
            {
                ViewState["grpdtNewGroup"] = DvGroup.ToTable();
                BindGrid(DvGroup.ToTable());
            }
        }
        else if (Ope == "=")
        {
            DvGroup.RowFilter = Col + Ope + "'" + Val + "'";
            if (DvGroup.ToTable().Rows.Count == 0)
            {
                msgGroup.Msg = "Record(s) not found";
                msgGroup.showmsg();
                BindGrid(DvGroup.ToTable());
            }
            else
            {
                ViewState["grpdtNewGroup"] = DvGroup.ToTable();
                BindGrid(DvGroup.ToTable());
            }
        }
        else if (Ope == "<>")
        {
            DvGroup.RowFilter = Col + Ope + "'" + Val + "'";
            if (DvGroup.ToTable().Rows.Count == 0)
            {
                msgGroup.Msg = "Record(s) not found";
                msgGroup.showmsg();
                BindGrid(DvGroup.ToTable());
            }
            else
            {
                ViewState["grpdtNewGroup"] = DvGroup.ToTable();
                BindGrid(DvGroup.ToTable());
            }
        }
        else if (Ope == "NOT LIKE")
        {
            string FilterNotLike = Col + " " + Ope + "'%" + Val + "%' ";
            DvGroup.RowFilter = FilterNotLike;
            if (DvGroup.ToTable().Rows.Count == 0)
            {
                msgGroup.Msg = "Record(s) not found";
                msgGroup.showmsg();
                BindGrid(DvGroup.ToTable());
            }
            else
            {
                ViewState["grpdtNewGroup"] = DvGroup.ToTable();
                BindGrid(DvGroup.ToTable());
            }
        }       
    }

    /// <summary>
    /// To change dropdown value for specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlGrpCol_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearGroup();
        if (ddlGrpCol.Text == "GroupName")
        {
            td1.Visible = true;
            td2.Visible = false;
            td3.Visible = true;
            td4.Visible = false;
            cvGrpOpeSta.Enabled = false;
            cvGrpOpe.Enabled = true;
            cvGrpSta.Enabled = false;
            ddlStatus.Visible = false;
        }
        else if (ddlGrpCol.Text == "IsActive")
        {
            td2.Visible = true;
            td1.Visible = false;
            td3.Visible = false;
            td4.Visible = true;
            cvGrpOpeSta.Enabled = false;
            cvGrpOpe.Enabled = true;
            cvGrpSta.Enabled = true;
            ddlStatus.Visible = true;       
        }
    }

    /// <summary>
    /// To show active group details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRefresh_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        DataTable grpdtNew = ActivegetGroupDetails();
        ViewState["grpdtNewGroup"] = grpdtNew;
        BindGrid(grpdtNew);
    }

    /// <summary>
    ///  To sort grid group name wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkgrp_Click(object sender, EventArgs e)
    {
        if (ViewState["grpSort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["grpdtNewGroup"];
            DtSort.DefaultView.Sort = "GroupName" + " ASC";
            DvGroup = new DataView(DtSort);
            DvGroup.Sort = ("GroupName" + " ASC");
            Sort = "DESC";
            ViewState["grpdtNewGroup"] = DvGroup.ToTable();
            ViewState["grpSort"] = Sort;
        }
        else if (ViewState["grpSort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["grpdtNewGroup"];
            DtSort.DefaultView.Sort = "GroupName" + " DESC";
            DvGroup = new DataView(DtSort);
            DvGroup.Sort = ("GroupName" + " DESC");
            Sort = "ASC";
            ViewState["grpdtNewGroup"] = DvGroup.ToTable();
            ViewState["grpSort"] = Sort;
        }
        BindGrid(DvGroup.ToTable());
    }

    /// <summary>
    /// To Sort grid group description wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkgrpdesc_Click(object sender, EventArgs e)
    {
        if (ViewState["grpSort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["grpdtNewGroup"];
            DtSort.DefaultView.Sort = "GroupDescription" + " ASC";
            DvGroup = new DataView(DtSort);
            DvGroup.Sort = ("GroupDescription" + " ASC");
            Sort = "DESC";
            ViewState["grpdtNewGroup"] = DvGroup.ToTable();
            ViewState["grpSort"] = Sort;
        }
        else if (ViewState["grpSort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["grpdtNewGroup"];
            DtSort.DefaultView.Sort = "GroupDescription" + " DESC";
            DvGroup = new DataView(DtSort);
            DvGroup.Sort = ("GroupDescription" + " DESC");
            Sort = "ASC";
            ViewState["grpdtNewGroup"] = DvGroup.ToTable();
            ViewState["grpSort"] = Sort;
        }
        BindGrid(DvGroup.ToTable());
    }

    /// <summary>
    /// To Sort grid group status wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkgrpstatus_Click(object sender, EventArgs e)
    {
        if (ViewState["grpSort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["grpdtNewGroup"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            DvGroup = new DataView(DtSort);
            DvGroup.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["grpdtNewGroup"] = DvGroup.ToTable();
            ViewState["grpSort"] = Sort;
        }
        else if (ViewState["grpSort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["grpdtNewGroup"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            DvGroup = new DataView(DtSort);
            DvGroup.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["grpdtNewGroup"] = DvGroup.ToTable();
            ViewState["grpSort"] = Sort;
        }
        BindGrid(DvGroup.ToTable());
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdGroupDetails_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        grdGroupDetails.PageIndex = e.NewPageIndex;
        DataTable grpedt1 = (DataTable)ViewState["grpdtNewGroup"];
        BindGrid(grpedt1);       
    }

    /// <summary>
    /// To add new group details 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Session["GroupId"] = null;
        Response.Redirect("GroupDetails.aspx", false);
    }

    /// <summary>
    ///  To Edit group details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imb = sender as ImageButton;
        int GroupId = Convert.ToInt32(imb.CommandArgument.ToString());
        lblSelectID.Text = GroupId.ToString();
        Session["GroupId"] = lblSelectID.Text;
        Response.Redirect("GroupDetails.aspx", false);   
    }
    protected void imguserhelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/GroupListHelp.pdf");
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