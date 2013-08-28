using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;


public partial class MenuDetails : System.Web.UI.Page
{
  
    int MenuID;// For Menu id
    public  string UserName;// For logedin username
    public int LoginUser;// For logedin user id
    public  string Ret;// For return message

    /// <summary>
    /// Page Load Method
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int MenuInd = MasterAcc.SelectedIndex;
        int MenuIndex = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = MenuIndex - 1;
        // To select loginuser id and login username
        Login objMenu = new Login();
        objMenu.Start();
        UserName = objMenu.LogedInUser;
        LoginUser = objMenu.LoginUser;
        Ret = objMenu.Ret;
        if (!Page.IsPostBack)
        {        
            if (Session["MenuId"] != null)
            {
                CheckMenuId();
                MenuID = Convert.ToInt32(Session["MenuId"].ToString());
            }
        }
        else
        {
            if (Session["MenuId"] != null)
            {
                MenuID = Convert.ToInt32(Session["MenuId"].ToString());
            }
        }
    }

    /// <summary>
    /// CheckMenuId is a function which is used to Edit Menu Details
    /// </summary>
    protected void CheckMenuId()
    {      
        MenuID = Convert.ToInt32(Session["MenuId"].ToString());
        DataTable DtSelectId = GetMenuDetails(MenuID);
        if (btnSave.Text == "Save")
        {
            if (DtSelectId.Rows.Count > 0)
            {
                txtMenuName.Text = DtSelectId.Rows[0][1].ToString();
                txtMenuDesc.Text = DtSelectId.Rows[0][2].ToString();
                string status = DtSelectId.Rows[0][3].ToString();
                if (status == "True")
                {
                    ddlMenuStatus.SelectedIndex = 2;
                }
                else
                {
                   ddlMenuStatus.SelectedIndex = 1;
                }                
                btnSave.Text = "Update";
            }
        }
    }

    /// <summary>
    /// To get details of particular Menu ID
    /// </summary>
    private DataTable GetMenuDetails(int GroupId)
    {
        MenuBAL MenuBAL = new MenuBAL();
        DataTable DtMenuDet = new DataTable();
        try
        {
            DtMenuDet = MenuBAL.SelectMenuID(MenuID, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            MenuBAL = null;
        }
        return DtMenuDet;
    }

    /// <summary>
    /// To save and update Menu details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Status = ddlMenuStatus.SelectedItem.Text;
        int MenuStatus = 1;
        if (Status == "Active")
        {
            MenuStatus = 1;
        }
        else
        {
            MenuStatus = 0;
        }
        if (btnSave.Text == "Save")
        {
            int IntResult = 0;
            MenuBAL MenuBAL = new MenuBAL();
            string MenuName = txtMenuName.Text;
            string MenuDesc = txtMenuDesc.Text;
            try
            {
                if (txtMenuName.Text.Trim() != "" && ddlMenuStatus.SelectedItem.Value != null)
                {
                    IntResult = MenuBAL.InsertMenu(MenuName, MenuDesc, MenuStatus, LoginUser, Ret);
                    ClearMenu();
                    msgMenu.Msg = "Menu details submited successfully";
                    msgMenu.showmsg();
                    //Response.Redirect("MenuList.aspx",false);
                }
            }
            catch (Exception ee)
            {
                if (ee.Message == "Duplicate Entry")
                {
                    msgMenu.Msg = "Duplicate Entry!";
                    msgMenu.showmsg();
                }
            }
            finally
            {
                MenuBAL = null;
            }
        }
        else if (btnSave.Text == "Update")
        {
            int IntResult = 0;
            MenuBAL MenuBAL = new MenuBAL();
            string MenuName = txtMenuName.Text;
            string MenuDesc = txtMenuDesc.Text;
            try
            {
                if (txtMenuName.Text.Trim() != "" && ddlMenuStatus.SelectedItem.Value != null)
                {
                    IntResult = MenuBAL.UpdateMenu(MenuID, MenuName, MenuDesc, MenuStatus, LoginUser, Ret);
                    ClearMenu();
                    msgMenu.Msg = "Menu details updated successfully";
                    msgMenu.showmsg();
                    //Response.Redirect("MenuList.aspx",false);
                    Session["MenuId"] = null;
                    btnSave.Text = "Save";
                }
            }
            catch (Exception ee)
            {
                if (ee.Message == "Duplicate Entry")
                {
                    msgMenu.Msg = "Duplicate Entry!";
                    msgMenu.showmsg();
                }
            }
            finally
            {
                MenuBAL = null;
            }
        }
    }

    /// <summary>
    /// To Clear data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearMenu();
        Response.Redirect("MenuList.aspx",false);
    }

    /// <summary>
    /// To cancel current operation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ClearMenu()
    {
        txtMenuDesc.Text = "";
        txtMenuName.Text = "";
        ddlMenuStatus.SelectedIndex = 0;
    }
}
