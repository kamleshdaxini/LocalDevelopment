using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices.AccountManagement;
using System.Data;
using AjaxControlToolkit;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public partial class master1 : System.Web.UI.MasterPage
{        
    public string Ret = "temp";// For return message
    public string UserName;// For loged in user name
    public int LoginUser;// For loged in user Id      
    public string ValidUser;// For User status valid or not

    protected void Page_Load(object sender, EventArgs e)
    {
        // To select loginuser id and login username
        Login obj = new Login();
        ValidUser=obj.Start();
        if (ValidUser == "Yes")
        {
            UserName = obj.LogedInUser;
            LoginUser = obj.LoginUser;
            lbluser.Text =  UserName;           
            Ret = obj.Ret;
            accbind();
        }
        else
        {                                
            Msg.Msg = "Invalid User";
            Msg.showmsg();          
        }       

    }

  /// <summary>
  /// To get Submenu details from SubMenu Business Access Layer
  /// </summary>
  /// <param name="menuId"></param>
  /// <returns></returns>
    private DataTable BinSubMenu(int menuId)
    {
        SubMenuBAL SubMenuBAL = new SubMenuBAL();
        DataTable DtSubMenu = new DataTable();
        try
        {
            DtSubMenu = SubMenuBAL.SelectMenuID(menuId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            SubMenuBAL = null;
        }

        return DtSubMenu;
    }

    /// <summary>
    /// To get Menu details from Menu Business Access Layer
    /// </summary>
    /// <param name="menuId"></param>
    /// <returns></returns>
    private DataTable BinMenu()
    {
        UserBAL UserBAL = new UserBAL();
        DataTable DtUser = new DataTable();
        try
        {
            DtUser = UserBAL.LoadUserPermission(LoginUser, true, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            UserBAL = null;
        }

        return DtUser;
    }

    /// <summary>
    /// To bind Dynamic Menu in Accordion 
    /// </summary>
    private void accbind()
  {
        DataTable DtBindMenu = BinMenu();
        DataTable DtMenu = new DataTable();
        DataTable dtMenu1 = new DataTable();
        if (DtBindMenu != null)
        {
            DtMenu = DtBindMenu.DefaultView.ToTable(true, "MenuId", "Menu", "IsActive");
            DataView DvMenu = new DataView(DtMenu);
            DvMenu.Sort = ("MenuId" + " ASC");
            DtMenu = DvMenu.ToTable();
            if (DtMenu.Rows.Count != 0)
            {
                int j = 0;
                AjaxControlToolkit.AccordionPane AccPan;
                int i = 0;     // This is just to use for assigning pane an id
                Label lblMenu;
               //To get Menu Details 
                foreach (DataRow Dr in DtMenu.Rows)
                {
                    lblMenu = new Label();
                    lblMenu.Text = Dr["Menu"].ToString();
                    int MenuId = Convert.ToInt16(Dr["MenuID"].ToString());
                    DataTable DtSubMenu = new DataTable();
                    DataView DvBindMenu = DtBindMenu.DefaultView;
                    DvBindMenu.RowFilter = "MenuID = " + MenuId;
                    DtSubMenu = DvBindMenu.ToTable(true, "SubMenuId", "Menu", "IsActive", "Sub Menu", "SubMenuDescription", "SubMenuURL", "MenuID", "SBSRT");
                    AccPan = new AjaxControlToolkit.AccordionPane();
                    AccPan.ID = "Pane" + j;
                    AccPan.HeaderContainer.Controls.Add(lblMenu);
                    DataView DvMenuBind = new DataView(DtSubMenu);
                    DvMenuBind.Sort = ("SBSRT" + " ASC");
                    DtSubMenu = DvMenuBind.ToTable();
                    //To get SubMenu Details of Specific Menu
                    if (DtSubMenu.Rows.Count > 0)
                    {
                        DataColumn DcSrNo = new DataColumn("Sr. No");
                        DtSubMenu.Columns.Add(DcSrNo);
                        for (int s = 0; s < DtSubMenu.Rows.Count; s++)
                        {
                            DtSubMenu.Rows[s][8] = j + 1;
                        }
                        foreach (DataRow DrSubMenu in DtSubMenu.Rows)
                        {
                            Label NewLine = new Label();
                            NewLine.Text = "<br/>";
                            LinkButton lnkSubMenu = new LinkButton();
                            lnkSubMenu.ID = "lnkSubMenu" + i;
                            lnkSubMenu.Text = DrSubMenu["Sub Menu"].ToString();
                            lnkSubMenu.ToolTip = DrSubMenu["SubMenuDescription"].ToString();
                            lnkSubMenu.CommandArgument = DrSubMenu["Sr. No"].ToString();
                            lnkSubMenu.CssClass = DrSubMenu["SubMenuURL"].ToString();
                            lnkSubMenu.EnableTheming = false;
                            lnkSubMenu.Click += new System.EventHandler(lnkSubMenu_Click);                          
                            AccPan.ContentContainer.Controls.Add(new LiteralControl("<li>"));
                            AccPan.ContentContainer.Controls.Add(lnkSubMenu);
                            i++;
                        }
                    }
                    acdnMaster.Panes.Add(AccPan);
                    ++j;
                }
            }
        }
        else
        {
        }

    }

    /// <summary>
    /// To set postback url of menu in accordion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSubMenu_Click(object sender, EventArgs e)
    {
        LinkButton lnkSbMenu = sender as LinkButton;
        string LnkUrl = lnkSbMenu.CssClass.ToString();
        string SrNo = lnkSbMenu.CommandArgument.ToString();
        Session["SrNo"] = SrNo;
        Response.Redirect(LnkUrl, false);
        lnkSbMenu.PostBackUrl = LnkUrl;
    }

}
