using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.IO;

public partial class Instructional_Designer : System.Web.UI.Page
{
    public  string UserName;// For loged in username
    public  int LoginUser;// For login user id
    public  string Ret;// For return message
    public static bool IsActive;// for user status
    int InsID;//For Instructional Id
    string Sort;// For Sorting 
    DataTable DtSort;// For sort table
    DataTable DtInsDes = new DataTable();// For instructional datatable
    DataView DvInsDes;// for instructional data view

   /// <summary>
    /// Page Load Method
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int InsDesInd = MasterAcc.SelectedIndex;
        int InsDesIndex = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = InsDesIndex - 1;
        // To select loginuser id and login username
        Login objInsDes = new Login();
        objInsDes.Start();
        UserName = objInsDes.LogedInUser;
        LoginUser = objInsDes.LoginUser;
        Ret = objInsDes.Ret;
        if (!Page.IsPostBack)
        {       
            IsActive = true;
            ViewState["Sort"] = "ASC";
            DataTable DtInsDes = InsDesActiveDetails(IsActive);
            ViewState["DtInsDes"] = DtInsDes;
            if (DtInsDes.Rows.Count > 0)
            {
                BindInsDes(DtInsDes);
            }
            else
            {
                GrdInsDes.DataSource = null;
                GrdInsDes.DataBind();
            }
        }
    }

   
    /// <summary>
    /// To bind Instructional Designer of active status 
    /// </summary>
    /// <param name="IsActive"></param>
    /// <returns></returns>
    protected DataTable InsDesActiveDetails(bool IsActive)
    {

        InstructionalDesignerBAL InstructionalDesignerBAL = new InstructionalDesignerBAL();
        DataTable DtInsDesDet = new DataTable();
        try
        {
            DtInsDesDet = InstructionalDesignerBAL.LoadActiveInstructionalDesigner(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            InstructionalDesignerBAL = null;
        }

        return DtInsDesDet;
    }

    /// <summary>
    /// To bind Instructional Designer of active status in gridview 
    /// </summary>
    /// <param name="DtInsDes"></param>
    private void BindInsDes(DataTable DtInsDes)
    {
        if (DtInsDes.Rows.Count > 0 )
        {
            GrdInsDes.DataSource = DtInsDes;
            GrdInsDes.DataBind();
            for (int i = 0; i < GrdInsDes.Rows.Count; i++)
            {
                Label lblPLUser = (GrdInsDes.Rows[i].FindControl("lblUser") as Label);
                Label lblStatus = (GrdInsDes.Rows[i].FindControl("lnkStatus") as Label);
                LinkButton lnkStatus = (GrdInsDes.Rows[i].FindControl("lnkEdit") as LinkButton);
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
            GrdInsDes.DataSource = null;
            GrdInsDes.DataBind();
        }
    }

    /// <summary>
    ///  To get user from user business access level
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
    ///  To edit intructional designer details
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
        int InsID;
        InstructionalDesignerBAL InstructionalDesignerBAL = new InstructionalDesignerBAL();
        LinkButton lblIsActive = (GrdInsDes.Rows[Idx].FindControl("lnkEdit") as LinkButton);
        Label lblStatus = (GrdInsDes.Rows[Idx].FindControl("lnkStatus") as Label);
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
            InsID = Convert.ToInt32(lnk.CommandArgument.ToString());
            lblSelectID.Text = InsID.ToString();
            Session["InsID"] = lblSelectID.Text;
            IntResult = InstructionalDesignerBAL.UpdateInstructionalDesigner(InsID, Status, LoginUser, Ret);
        }
    }
  
    /// <summary>
    ///  To bind instructional designer in dropdownlist
    /// </summary>
    public void BindInsDesUser()
    {
        DataTable DtUser = UserPerDetails();
        if (DtUser.Rows.Count > 0 || DtUser != null)
        {
            ddlInsDesUser.DataSource = DtUser;
            ddlInsDesUser.DataTextField = "UserName";
            ddlInsDesUser.DataValueField = "UserID";
            ddlInsDesUser.DataBind();
            ddlInsDesUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlInsDesUser.SelectedIndex = 0;
        }
        else
        {
            ddlInsDesUser.DataSource = null;
            ddlInsDesUser.DataTextField = "UserName";
            ddlInsDesUser.DataValueField = "UserID";
            ddlInsDesUser.DataBind();
            ddlInsDesUser.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlInsDesUser.SelectedIndex = 0;
        }
    }

    /// <summary>
    ///  To save instructional designer details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        InstructionalDesignerBAL InstructionalDesignerBAL = new InstructionalDesignerBAL();
        int UserID = Convert.ToInt32(ddlInsDesUser.SelectedValue.ToString());
        string Status = ddlInsDesStatus.SelectedValue.ToString();
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
                // 'InsertInstructionalDesigner' is Instructional Designer business Access Layer function called
                // to insert Instructional Designer details
                int Result = InstructionalDesignerBAL.InsertInstructionalDesigner(UserID, IsActive, LoginUser, Ret);
                DtInsDes = IDDetails();
                ViewState["DtInsDes"] = DtInsDes;
                BindInsDes(DtInsDes);
                MsgInsDes.Msg = "Record added successfully";
                MsgInsDes.showmsg();
            }
            catch (Exception ee)
            {
                // Duplicate Entry is catched when inserting Instructional Designer
                if (ee.Message == "Duplicate Entry")
                {
                    MsgInsDes.Msg = "Duplicate Entry!";
                    MsgInsDes.showmsg();
                    ClearInsDes();
                }
            }
            finally
            {
                InstructionalDesignerBAL = null;
            }
        }
    }

    /// <summary>
    /// To get Instructional Designer details 
    /// </summary>
    /// <returns></returns>
    protected DataTable IDDetails()
    {

        InstructionalDesignerBAL idBAL = new InstructionalDesignerBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = idBAL.LoadAllInstructionalDesigner(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            idBAL = null;
        }

        return dTable;
    }
    /// <summary>
    /// To cancel current operation     
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearInsDes();      
        DtInsDes = IDDetails();
        ViewState["DtInsDes"] = DtInsDes;
        BindInsDes(DtInsDes);
        MPopUpInsDes.Hide();
    }

    /// <summary>
    ///  To get specific instructional designer details 
    /// </summary>
    /// <param name="InsID"></param>
    /// <returns></returns>
    protected DataTable GetUserDetails(int InsID)
    {
        InstructionalDesignerBAL InstructionalDesignerBAL = new InstructionalDesignerBAL();
        DataTable DtGetUser = new DataTable();
        try
        {
            DtGetUser = InstructionalDesignerBAL.SelectInstructionalDesignerID(InsID, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            InstructionalDesignerBAL = null;
        }

        return DtGetUser;
    }

   /// <summary>
    ///  Clear instructional Designer dropdownlist 
   /// </summary>
    public void ClearInsDes()
    {
        ddlInsDesUser.SelectedIndex = 0;
        ddlInsDesStatus.SelectedIndex = 0;
        ddlInsDesUser.Enabled = true;
    }

    /// <summary>
    ///  To get 'Active' and 'InActive' status instructional designer details 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbRef_Click(object sender, ImageClickEventArgs e)
    {
        bool IsActive = true;
        DataTable DtInsDes = InsDesActiveDetails(IsActive);
        ViewState["DtInsDes"] = DtInsDes;
        BindInsDes(DtInsDes);
        ddlCol.SelectedIndex = 0;
        ddlOpe.SelectedIndex = 0;
        ddlVal.SelectedIndex = 0;
    }

    /// <summary>
    /// To search records in grid on selected conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        string Col = ddlCol.SelectedValue;
        string Ope = ddlOpe.Text;
        string Val = ddlVal.Text;
        DataView DvInsDes = new DataView();
        if (Col == "IsActive")
        {
            if (Val == "Active" || Val == "active")
            {
                Val = "true";
                if (Ope == "=")
                {
                    DataTable dt = InsDesActiveDetails(true);
                    DvInsDes = dt.DefaultView;
                    FilterDataview(DvInsDes, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable dt = InsDesActiveDetails(false);
                    DvInsDes = dt.DefaultView;
                    FilterDataview(DvInsDes, Col, Ope, Val);
                }
            }
            else if (Val == "InActive" || Val == "Inactive" || Val == "inactive")
            {
                Val = "false";
                if (Ope == "=")
                {
                    DataTable dt = InsDesActiveDetails(false);
                    DvInsDes = dt.DefaultView;
                    FilterDataview(DvInsDes, Col, Ope, Val);
                }
                else if (Ope == "<>")
                {
                    DataTable dt = InsDesActiveDetails(true);
                    DvInsDes = dt.DefaultView;
                    FilterDataview(DvInsDes, Col, Ope, Val);
                }
            }

        }
    }

    /// <summary>
    ///  To filter dataview by selected operator, column and value
    /// </summary>
    /// <param name="DvInsDes"></param>
    /// <param name="Column"></param>
    /// <param name="Operator"></param>
    /// <param name="Value"></param>
    public void FilterDataview(DataView DvInsDes, string Column, string Operator, string Value)
    {
        DvInsDes.RowFilter = Column + " " + Operator + "'" + Value + "'";
        if (DvInsDes.ToTable().Rows.Count == 0)
        {
            MsgInsDes.Msg = "Record(s) not found";
            MsgInsDes.showmsg();
            ViewState["DtInsDes"] = DvInsDes.ToTable();
            BindInsDes(DvInsDes.ToTable());
            ddlCol.SelectedIndex = 0;
            ddlOpe.SelectedIndex = 0;
            ddlVal.SelectedIndex = 0;           
        }
        else
        {
            ViewState["DtInsDes"] = DvInsDes.ToTable();
            BindInsDes(DvInsDes.ToTable());
        }
    }

    /// <summary>
    ///  To Sort Instructional designer status by Ascending ans descending way
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtInsDes"];
            DtSort.DefaultView.Sort = "IsActive" + " ASC";
            DvInsDes = new DataView(DtSort);
            DvInsDes.Sort = ("IsActive" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtInsDes"] = DvInsDes.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtInsDes"];
            DtSort.DefaultView.Sort = "IsActive" + " DESC";
            DvInsDes = new DataView(DtSort);
            DvInsDes.Sort = ("IsActive" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtInsDes"] = DvInsDes.ToTable();
        }
        BindInsDes(DvInsDes.ToTable());
    }

   /// <summary>
   /// To Sort username by ascending and descending way
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
    protected void lnkUserName_Click(object sender, EventArgs e)
    {
        if (ViewState["Sort"].ToString() == "ASC")
        {
            DtSort = (DataTable)ViewState["DtInsDes"];
            DtSort.DefaultView.Sort = "UserID" + " ASC";
            DvInsDes = new DataView(DtSort);
            DvInsDes.Sort = ("UserID" + " ASC");
            Sort = "DESC";
            ViewState["Sort"] = Sort;
            ViewState["DtInsDes"] = DvInsDes.ToTable();
        }
        else if (ViewState["Sort"].ToString() == "DESC")
        {
            DtSort = (DataTable)ViewState["DtInsDes"];
            DtSort.DefaultView.Sort = "UserID" + " DESC";
            DvInsDes = new DataView(DtSort);
            DvInsDes.Sort = ("UserID" + " DESC");
            Sort = "ASC";
            ViewState["Sort"] = Sort;
            ViewState["DtInsDes"] = DvInsDes.ToTable();
        }
        BindInsDes(DvInsDes.ToTable());
    }
    /// <summary>
    /// To add new instructional Designer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        BindInsDesUser();
        MPopUpInsDes.Show();
        ClearInsDes();
    }

    /// <summary>
    /// For paging in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GrdInsDes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdInsDes.PageIndex = e.NewPageIndex;
        DataTable DtInsDes = (DataTable)ViewState["DtInsDes"];
        BindInsDes(DtInsDes);
    }

    /// <summary>
    /// Help for Instructional Designer Audit Master
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbInsDesHelp_Click(object sender, ImageClickEventArgs e)
    {
        string fPath = Server.MapPath("Help/InstructionalDesignerHelp.pdf");
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