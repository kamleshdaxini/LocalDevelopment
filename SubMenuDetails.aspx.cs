using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using AjaxControlToolkit;

public partial class SubMenuDetails : System.Web.UI.Page
{
    // Initialization of public variables
    int SubMenuID; // For SubMenu ID
    public string UserName;// For logged in username
    public int LoginUser;// For Logged in user Id
    public string Ret;// For return message
    public  bool IsActive;// For status

    /// <summary>
    ///  Page load method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int Ind = MasterAcc.SelectedIndex;
        int Index = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = Index - 1;
        // To select loginuser id and login username
        Login objSubMenu = new Login();
        objSubMenu.Start();
        UserName = objSubMenu.LogedInUser;
        LoginUser = objSubMenu.LoginUser;
        Ret = objSubMenu.Ret;
        if (!Page.IsPostBack)
        {       
            IsActive = true;
            BindMenu(true);
            if (Session["SubMenuID"] != null)
            {
                CheckSubMenuId();
                SubMenuID = Convert.ToInt32(Session["SubMenuId"].ToString());
            }
        }
        else
        {
            if (Session["SubMenuID"] != null)
            {               
                SubMenuID = Convert.ToInt32(Session["SubMenuId"].ToString());
            }
        }
    }

    /// <summary>
    /// To bind Menu dropdown list
    /// </summary>
    /// <param name="IsActive"></param>
    protected void BindMenu(bool IsActive)
    {
     DataTable DtBindMenu = GetMenuDetails(IsActive); //conenction path for database
     if (DtBindMenu.Rows.Count > 0 || DtBindMenu != null)
     {
         ddlMenu.DataSource = DtBindMenu;
         ddlMenu.DataTextField = "MenuName";
         ddlMenu.DataValueField = "MenuId";
         ddlMenu.DataBind();
         ddlMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
         ddlMenu.SelectedIndex = 0;
     }
     else
     {
         ddlMenu.DataSource = null;
         ddlMenu.DataTextField = "MenuName";
         ddlMenu.DataValueField = "MenuId";
         ddlMenu.DataBind();
         ddlMenu.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
         ddlMenu.SelectedIndex = 0;
     }

    }

    /// <summary>
    /// CheckSubMenuId is a function which is used for Edit functionality
    /// </summary>
    protected void CheckSubMenuId()
    {
        SubMenuID = Convert.ToInt32(Session["SubMenuID"].ToString());
        DataTable DtSelectId = GetSubmenuDetails();
        if (btnSave.Text == "Save")
        {
            if (DtSelectId.Rows.Count > 0)
            {
                ddlMenu.SelectedValue = DtSelectId.Rows[0][0].ToString();
                txtSubMenuName.Text = DtSelectId.Rows[0][3].ToString();
                txtSubMenuDesc.Text = DtSelectId.Rows[0][4].ToString();
                txtURL.Text = DtSelectId.Rows[0][5].ToString();
                string Status = DtSelectId.Rows[0][6].ToString();
                if (Status == "True")
                {
                    ddlSubMenuStatus.SelectedIndex = 1;
                }
                else
                {
                    ddlSubMenuStatus.SelectedIndex = 2;
                }
                btnSave.Text = "Update";
            }
        }
    }

    /// <summary>
    /// To get active Menu Details from database
    /// </summary>
    /// <param name="IsActive"></param>
    /// <returns></returns>
    private DataTable GetMenuDetails(bool IsActive)
    {
        MenuBAL MenuBAL = new MenuBAL();
        DataTable DtGetMenu = new DataTable();
        try
        {
            DtGetMenu = MenuBAL.LoadActiveMenu(IsActive, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            MenuBAL = null;
        }
        return DtGetMenu;
    }

    /// <summary>
    ///  To get SubMenu Details from database
    /// </summary>
    /// <returns></returns>
    private DataTable GetSubmenuDetails()
    {
        SubMenuBAL SubMenuBAL = new SubMenuBAL();
        DataTable DtGetSubMenu = new DataTable();
        try
        {
            DtGetSubMenu = SubMenuBAL.SelectSubMenuID(SubMenuID, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            SubMenuBAL = null;
        }
        return DtGetSubMenu;
    }

    /// <summary>
    /// To save and update SubMenu Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Status = ddlSubMenuStatus.SelectedItem.Text;
        int MenuID = Convert.ToInt16(ddlMenu.SelectedValue);
        int SubMenustatus =1;
        if (ddlSubMenuStatus.SelectedItem.Text != "Select SubMenu")
        {
            if (Status == "Active")
            {
                SubMenustatus = 1;
            }
            else
            {
                SubMenustatus = 0;
            }
        }
        if (btnSave.Text == "Save")
        {
            int IntResult = 0;
            SubMenuBAL SubMenuBAL = new SubMenuBAL();
            string SubMenuName = txtSubMenuName.Text;
            string SubMenuDesc = txtSubMenuDesc.Text;
            string SubMenuURL = txtURL.Text;
            try
            {
                if (txtSubMenuName.Text.Trim() != "" && ddlSubMenuStatus.SelectedItem.Value != null)
                {
                    // 'InsertSubMenu' is SubMenu business Access Layer function called
                    // to Insert SubMenu details
                    IntResult = SubMenuBAL.InsertSubMenu(MenuID, SubMenuName, SubMenuDesc, SubMenuURL, SubMenustatus, LoginUser, Ret);
                    ClearSubMenu();
                   // Response.Redirect("SubMenuList.aspx", false);
                    msgSubMenu.Msg = "Menu details submited successfully";
                    msgSubMenu.showmsg();                   
                }
            }
            catch (Exception ee)
            {
                // Duplicate Entry is catched when inserting SubMenu      
                if (ee.Message == "Duplicate Entry")
                {
                    msgSubMenu.Msg = "Menu already exists";
                    msgSubMenu.showmsg();
                }
            }
            finally
            {
                SubMenuBAL = null;
            }
        }
        else if (btnSave.Text == "Update")
        {
            int IntResult = 0;
            SubMenuBAL SubMenuBAL = new SubMenuBAL(); 
            string SubMenuName = txtSubMenuName.Text;
            string SubMenuDesc = txtSubMenuDesc.Text;
            string SubMenuURL = txtURL.Text;
            try
            {
                // 'UpdateSubMenu' is SubMenu business Access Layer function called
                // to update SubMenu details
                IntResult = SubMenuBAL.UpdateSubMenu(SubMenuID, SubMenuName, SubMenuDesc, SubMenuURL, SubMenustatus, LoginUser, Ret);
                ClearSubMenu();            
                //Response.Redirect("SubMenuList.aspx",false );
                Session["SubMenuID"] = null;
                btnSave.Text = "Save";
                msgSubMenu.Msg = "Menu details updated successfully";
                msgSubMenu.showmsg();
            }
            catch (Exception ee)
            {
                // Duplicate Entry is catched when updating SubMenu
                if (ee.Message == "Duplicate Entry")
                {
                    msgSubMenu.Msg = "Menu already exists";
                    msgSubMenu.showmsg();
                }
            }
            finally
            {
                SubMenuBAL = null;
            }
        }
    }
    
    /// <summary>
    /// To cancel current operation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearSubMenu();
        Response.Redirect("SubMenuList.aspx",false );
    }

    /// <summary>
    /// Clear data
    /// </summary>
    protected void ClearSubMenu()
    {
        txtSubMenuName.Text = "";
        txtSubMenuDesc.Text = "";
        txtURL.Text = "";
        ddlSubMenuStatus.SelectedIndex = 0;
        ddlMenu.SelectedIndex = 0;
    }
}