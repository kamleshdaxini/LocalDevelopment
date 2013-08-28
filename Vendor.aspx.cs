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
    public  string Useraname;// For loged in username
    public int LoginUser;// For loged in user id
    public string Ret;// For return message
    public static bool IsActive;// For user status
    DataTable DtVen = new DataTable();//For vendor table
    int VenID;// For vender Id
    string Sort;// For sorting 
    DataTable DtSort;// For Sorting in Vendor table
    DataView DvFilter;// For filter View

    /// <summary>
    ///  Page Load Method 
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
        Login objVendor = new Login();
        objVendor.Start();
        Useraname = objVendor.LogedInUser;
        LoginUser = objVendor.LoginUser;
        Ret = objVendor.Ret;
        if (!Page.IsPostBack)
        {        
            IsActive = true;
            // To sort defaulty by Ascending order
            ViewState["Sort"] = "ASC";
            // To fetch Group details having active status
            DataTable DtVen = VenActiveDetails(IsActive);
            ViewState["DtVen"] = DtVen;
            if (DtVen.Rows.Count > 0)
            {               
                BindVen(DtVen);
            }
            else
            {               
                GrdVendor.DataSource = null;
                GrdVendor.DataBind();
            }
        }
    }

    /// <summary>
    /// To Load Active Status Vedor details from 'Vendor Business Access Layer'
    /// </summary>
    /// <param name="IsActive"></param>
    /// <returns></returns>
    protected DataTable VenActiveDetails(bool IsActive)
    {
        VendorBAL VendorBAL = new VendorBAL();
        DataTable DtVenActDet = new DataTable();
        try
        {
            DtVenActDet = VendorBAL.LoadActiveVendor(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            VendorBAL = null;
        }

        return DtVenActDet;
    }

    /// <summary>
    /// To bind vendor details in gridview
    /// </summary>
    /// <param name="DtVen"></param>
    private void BindVen(DataTable DtVen)
    {
        if (DtVen.Rows.Count > 0)
        {
            GrdVendor.DataSource = DtVen;
            GrdVendor.DataBind();
            for (int i = 0; i < GrdVendor.Rows.Count; i++)
            {
                Label lblVenUser = (GrdVendor.Rows[i].FindControl("lblUser") as Label);
                Label lblStatus = (GrdVendor.Rows[i].FindControl("lnkStatus") as Label);
                LinkButton lnkStatus = (GrdVendor.Rows[i].FindControl("lnkEdit") as LinkButton);
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
            GrdVendor.DataSource = null;
            GrdVendor.DataBind();
        }
    }

    /// <summary>
    /// To fetch active status users from User Business Access Layer having Vendor role
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
    /// To edit content developer details in grid
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
        int VenID;
        VendorBAL VendorBAL = new VendorBAL();
        LinkButton lblIsActive = (GrdVendor.Rows[Idx].FindControl("lnkEdit") as LinkButton);
        Label lblStatus = (GrdVendor.Rows[Idx].FindControl("lnkStatus") as Label);
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
            VenID = Convert.ToInt32(lnk.CommandArgument.ToString());
            lblSelectID.Text = VenID.ToString();
            Session["VenID"] = lblSelectID.Text;
            IntResult = VendorBAL.UpdateVendor(VenID, Status, LoginUser, Ret);
        }
    }

    /// <summary>
    /// To bind Active directory users in dropdown list
    /// </summary>
    public void BindVenUser()
    {
        DataTable Dtuser = UserPerDetails();
        if (Dtuser.Rows.Count > 0 || Dtuser != null)
        {
            ddlVenUser.DataSource = Dtuser;
            ddlVenUser.DataTextField = "UserName";
            ddlVenUser.DataValueField = "UserID";
            ddlVenUser.DataBind();
            ddlVenUser.Items.Insert(0, new ListItem("Select User", ""));
            ddlVenUser.SelectedIndex = 0;
        }
        else
        {
            ddlVenUser.DataSource = null;
            ddlVenUser.DataTextField = "UserName";
            ddlVenUser.DataValueField = "UserID";
            ddlVenUser.DataBind();
            ddlVenUser.Items.Insert(0, new ListItem("Select User", ""));
            ddlVenUser.SelectedIndex = 0;
        }
    }
    /// <summary>
    /// To save Vendor details 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        VendorBAL VendorBAL = new VendorBAL();
        int UserID = Convert.ToInt32(ddlVenUser.SelectedValue.ToString());
        string Status = ddlVenStatus.SelectedValue.ToString();
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
                int Result = VendorBAL.InsertVendor(UserID, IsActive, LoginUser, Ret);
                DtVen = VenDetails();
                ViewState["DtVen"] = DtVen;
                BindVen(DtVen);
                MsgVen.Msg = "Record added successfully";
                MsgVen.showmsg();
            }
            catch (Exception ee)
            {
                if (ee.Message == "Duplicate Entry")
                {
                    MsgVen.Msg = "Duplicate Entry!";
                    MsgVen.showmsg();
                    ClearVen();
                }
            }
            finally
            {
                VendorBAL = null;
            }
        }
    }

    /// <summary>
    ///  To bind Vendor of 'Active' and 'InActive' Status
    /// </summary>
    /// <returns></returns>
    protected DataTable VenDetails()
    {
        VendorBAL VendorBAL = new VendorBAL();
        DataTable DtVenDet = new DataTable();
        try
        {
            DtVenDet = VendorBAL.LoadAllVendor(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            VendorBAL = null;
        }
        return DtVenDet;
    }

    /// <summary>
    /// To Cancel current operation 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearVen();
        MPopUpVen.Hide();
        DtVen = VenDetails();
        ViewState["DtVen"] = DtVen;
        BindVen(DtVen);       
    }

    /// <summary>
    /// To get specific Vendor details 
    /// </summary>
    /// <param name="VenID"></param>
    /// <returns></returns>
    protected DataTable GetUserDetails(int VenID)
    {
        VendorBAL VendorBAL = new VendorBAL();
        DataTable DtGetUser = new DataTable();
        try
        {
            DtGetUser = VendorBAL.SelectVendorID(VenID, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            VendorBAL = null;
        }
        return DtGetUser;
    }

    /// <summary>
    /// To clearVendor dropdown selected value
    /// </summary>
    public void ClearVen()
    {
        ddlVenUser.SelectedIndex = 0;
        ddlVenStatus.SelectedIndex = 0;
        ddlVenUser.Enabled = true;
    }

    /// <summary>
    /// To search specified match case vendor
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        string Col = ddlCol.SelectedValue;
        string Ope = ddlOpe.Text;
        string Val = ddlVal.Text;
        DataView DvFilter = new DataView();
        if (Col == "IsActive")
        {
            if (Val == "Active" || Val == "active")
            {
                Val = "true";
                if (Ope == "=")
                {
                    DataTable DtFilter = VenActiveDetails(true);
                    DvFilter = DtFilter.DefaultView;
                    FilterDataview(DvFilter, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable DtFilter = VenActiveDetails(false);
                    DvFilter = DtFilter.DefaultView;
                    FilterDataview(DvFilter, Col, Ope, Val);
                }
            }
            else if (Val == "InActive" || Val == "Inactive" || Val == "inactive")
            {
                Val = "false";
                if (Ope == "=")
                {
                    DataTable DtFilter = VenActiveDetails(false);
                    DvFilter = DtFilter.DefaultView;
                    FilterDataview(DvFilter, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable DtFilter = VenActiveDetails(true);
                    DvFilter = DtFilter.DefaultView;
                    FilterDataview(DvFilter, Col, Ope, Val);
                }
            }
        }
    }

    /// <summary>
    /// To show 'Active ' and 'Inactive' status type Vendor details in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRef_Click(object sender, ImageClickEventArgs e)
    {
        bool IsActive = true;
        DataTable DtVen = VenActiveDetails(IsActive);
        ViewState["DtVen"] = DtVen;  
        BindVen(DtVen);
        ddlCol.SelectedIndex = 0;
        ddlOpe.SelectedIndex = 0;
        ddlVal.SelectedIndex = 0;
    }

    /// <summary>
    /// To filter details in grid on different conditions selected by user
    /// </summary>
    /// <param name="DvFilter"></param>
    /// <param name="Column"></param>
    /// <param name="Operator"></param>
    /// <param name="Value"></param>
    public void FilterDataview(DataView DvFilter, string Column, string Operator, string Value)
    {
        DvFilter.RowFilter = Column + " " + Operator + "'" + Value + "'";
        if (DvFilter.ToTable().Rows.Count == 0)
        {
            MsgVen.Msg = "Record(s) not found";
            MsgVen.showmsg();
            ViewState["DtVen"] = DvFilter.ToTable();
            BindVen(DvFilter.ToTable());
            ddlCol.SelectedIndex = 0;
            ddlOpe.SelectedIndex = 0;
            ddlVal.SelectedIndex = 0;
        }
        else
        {
            ViewState["DtVen"] = DvFilter.ToTable();
            BindVen(DvFilter.ToTable());
        }
    }

    /// <summary>
    /// To sort Vendor details on Username by Ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkUserName_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtVen"];
            DtSort.DefaultView.Sort = "UserID" + " ASC";
            DvFilter = new DataView(DtSort);
            DvFilter.Sort = ("UserID" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtVen"] = DvFilter.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtVen"];
            DtSort.DefaultView.Sort = "UserID" + " DESC";
            DvFilter = new DataView(DtSort);
            DvFilter.Sort = ("UserID" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtVen"] = DvFilter.ToTable();
        }
        BindVen(DvFilter.ToTable());
    }

    /// <summary>
    /// To sort Vendor grid details on Status Ascending and descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtVen"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            DvFilter = new DataView(DtSort);
            DvFilter.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtVen"] = DvFilter.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtVen"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            DvFilter = new DataView(DtSort);
            DvFilter.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtVen"] = DvFilter.ToTable();
        }
        BindVen(DvFilter.ToTable());
    }

    /// <summary>
    /// To Add new Vendor details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        BindVenUser();
        ClearVen();
        MPopUpVen.Show();
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GrdVendor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdVendor.PageIndex = e.NewPageIndex;
        DataTable DtVen = (DataTable)ViewState["DtVen"];
        BindVen(DtVen);
    }

    /// <summary>
    ///  Help for Vendor KBS Audit Master
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbVendorHelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/VendorHelp.pdf");
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