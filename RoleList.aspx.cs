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
public partial class RoleList : System.Web.UI.Page
{
    // Initialization of public variables
    public string UserName;// For logged in username
    public int LoginUser;// For logged in User ID
    public string Ret;// For Return message
    string Oper, Col, Value, Sort; // For Operator, Column, Value, Sorting perpose
    DataTable DtSort; // For Sorting in Table
    DataView Dv; // For Role DataView

    /// <summary>
    /// Page Load Method 
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
        Login objRole = new Login();
        objRole.Start();
        UserName = objRole.LogedInUser;
        LoginUser = objRole.LoginUser;
        Ret = objRole.Ret;
        if (!IsPostBack)
        {         
            ViewState["Sort"] = "ASC";
            DataTable DtRoleNew = ActiveGridDataSource();
            ViewState["DtAddNew"] = DtRoleNew;
            BindGrid(DtRoleNew);          
        }
    }

    /// <summary>
    /// To bind Role list Grid
    /// </summary>
    /// <param name="DtRole"></param>
    private void BindGrid(DataTable DtRole)
    {
        if (DtRole.Rows.Count > 0 || DtRole != null)
        {
            grdRoleDetails.DataSource = DtRole;
            grdRoleDetails.DataBind();
            for (int i = 0; i < grdRoleDetails.Rows.Count; i++)
            {
                Label lblIsActive = (grdRoleDetails.Rows[i].FindControl("lblIsActive") as Label);
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
            grdRoleDetails.DataSource = null;
            grdRoleDetails.DataBind();
        }
    }

    /// <summary>
    /// To load Role details from database 
    /// </summary>
    /// <returns></returns>
    private DataTable GridDataSource()
    {
        RoleBAL RoleBAL = new RoleBAL();
        DataTable DtRole = new DataTable();
        try
        {
            DtRole = RoleBAL.LoadAllRole(LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            RoleBAL = null;
        }
        return DtRole;
    }

    /// <summary>
    /// To load active role details from database
    /// </summary>
    /// <returns></returns>
    private DataTable ActiveGridDataSource()
    {
        RoleBAL RoleBAL = new RoleBAL();
        DataTable DtActGrd = new DataTable();
        try
        {
            DtActGrd = RoleBAL.LoadActiveRole(true, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            RoleBAL = null;
        }
        return DtActGrd;
    }
 
    /// <summary>
    /// To filter role details by specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbFilter_Click(object sender, ImageClickEventArgs e)
    {
        Col = ddlRoleCol.Text;
        Value = txtRoleValue.Text;
        DataTable DtFilter = GridDataSource();
        DataView DvFilter = DtFilter.DefaultView;
        if (Col == "IsActive")
        {
            Oper = ddlRoleOpeSta.Text;
            Value = ddlRoleStatus.SelectedValue;
            if (Value == "Active")
            {
                Value = "true";
            }
            else if (Value == "InActive")
            {
                Value = "false";
            }         
        }
        else
        {
            Oper = ddlRoleOpe.Text;
        }
        if (Oper == "LIKE")
        {
            string Filter = Col + " " + Oper + "'%" + Value + "%' ";
            DvFilter.RowFilter = Filter;
            if (DvFilter.ToTable().Rows.Count == 0)
            {
                msgRole.Msg = "Record(s) not found";
                msgRole.showmsg();
                BindGrid(DvFilter.ToTable());
            }
            else
            {
                ViewState["DtAddNew"] = DvFilter.ToTable();
                BindGrid(DvFilter.ToTable());
            }           
        }
        else if (Oper == "=")
        {
            DvFilter.RowFilter = Col + Oper + "'" + Value + "'";
            if (DvFilter.ToTable().Rows.Count == 0)
            {
                msgRole.Msg = "Record(s) not found";
                msgRole.showmsg();
                BindGrid(DvFilter.ToTable());
            }
            else
            {
                ViewState["DtAddNew"] = DvFilter.ToTable();
                BindGrid(DvFilter.ToTable());
                
            }
        }
        else if (Oper == "<>")
        {
            DvFilter.RowFilter = Col + Oper + "'" + Value + "'";
            if (DvFilter.ToTable().Rows.Count == 0)
            {
                msgRole.Msg = "Record(s) not found";
                msgRole.showmsg();
                BindGrid(DvFilter.ToTable());
            }
            else
            {
                BindGrid(DvFilter.ToTable());
                ViewState["DtAddNew"] = DvFilter.ToTable();
            }           
        }
        else if (Oper == "NOT LIKE")
        {
            string Filter = Col + " " + Oper + "'%" + Value + "%' ";
            DvFilter.RowFilter = Filter;
            if (DvFilter.ToTable().Rows.Count == 0)
            {
                msgRole.Msg = "Record(s) not found";
                msgRole.showmsg();
                BindGrid(DvFilter.ToTable());
            }
            else
            {
                ViewState["DtAddNew"] = DvFilter.ToTable();
                BindGrid(DvFilter.ToTable());
            }           
        }     
    }

    /// <summary>
    /// To clear data
    /// </summary>
    public void ClearRole()
    {
        txtRoleValue.Text = "";
        ddlRoleStatus.SelectedIndex = 0;
    }

    /// <summary>
    /// To change dropdown value for specific column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRoleCol_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRoleCol.Text == "RoleName")
        {
            td1.Visible = true;
            td2.Visible = false;
            td3.Visible = true;
            td4.Visible = false;            
            cvRoleOpe.Enabled = false;
            cvRoleOperator.Enabled = true;
            cvRoleOpeSta.Enabled = false;
            ddlRoleStatus.Visible = false;
            txtRoleValue.Text = "";           
        }
        else if (ddlRoleCol.Text == "IsActive")
        {
            td2.Visible = true;
            td1.Visible = false;
            td3.Visible = false;
            td4.Visible =  true;
            cvRoleOperator.Enabled = false;
            cvRoleOpe.Enabled = true;
            cvRoleOpeSta.Enabled = true;
            ddlRoleStatus.Visible = true;
            txtRoleValue.Text = "";         
        }
    }

    /// <summary>
    /// To paging for grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdRoleDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdRoleDetails.PageIndex = e.NewPageIndex;
        DataTable DtRoleDet = (DataTable)ViewState["DtAddNew"];
        BindGrid(DtRoleDet);        
    }

    /// <summary>
    /// To show active role details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRefresh_Click(object sender, ImageClickEventArgs e)
    {
        DataTable DtRoleNew = ActiveGridDataSource();
        ViewState["DtAddNew"] = DtRoleNew;
        BindGrid(DtRoleNew);
    }

    /// <summary>
    /// To sort grid role name wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkrolename_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtAddNew"];
            DtSort.DefaultView.Sort = "RoleName" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("RoleName" + " ASC");
            Sort = "DESC";
            ViewState["DtAddNew"] = Dv.ToTable();
            ViewState["Sort"] = Sort;
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtAddNew"];
            DtSort.DefaultView.Sort = "RoleName" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("RoleName" + " DESC");
            Sort = "ASC";
            ViewState["DtAddNew"] = Dv.ToTable();
            ViewState["Sort"] = Sort;
        }
        BindGrid(Dv.ToTable());
    }
 
    /// <summary>
    /// To sort grid role description wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkroledesc_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtAddNew"];
            DtSort.DefaultView.Sort = "RoleDescription" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("RoleDescription" + " ASC");
            Sort = "DESC";
            ViewState["DtAddNew"] = Dv.ToTable();
            ViewState["Sort"] = Sort;
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtAddNew"];
            DtSort.DefaultView.Sort = "RoleDescription" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("RoleDescription" + " DESC");
            Sort = "ASC";
            ViewState["DtAddNew"] = Dv.ToTable();
            ViewState["Sort"] = Sort;
        }
        BindGrid(Dv.ToTable());
    }

    /// <summary>
    ///  To sort grid role status wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkstatussort_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtAddNew"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("RoleDescription" + " ASC");
            Sort = "DESC";
            ViewState["DtAddNew"] = Dv.ToTable();
            ViewState["Sort"] = Sort;
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtAddNew"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            Dv = new DataView(DtSort);
            Dv.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["DtAddNew"] = Dv.ToTable();
            ViewState["Sort"] = Sort;
        }
        BindGrid(Dv.ToTable());
    }

    /// <summary>
    /// To add new role details 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Session["RoleId"] = null;
        Response.Redirect("RoleDetails.aspx", false);
    }
 
    /// <summary>
    /// To Edit Role details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imb = sender as ImageButton;
        int RoleId = Convert.ToInt32(imb.CommandArgument.ToString());
        lblSelectID.Text = RoleId.ToString();
        Session["RoleId"] = lblSelectID.Text;
        Response.Redirect("RoleDetails.aspx", false);          
    }
    protected void imguserhelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/RoleListHelp.pdf");
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