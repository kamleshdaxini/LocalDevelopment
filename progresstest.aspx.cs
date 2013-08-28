using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;


public partial class progress : System.Web.UI.Page
{

    public  string Useraname;
    public  int LoginUser;
    public  string Ret;
    public  bool IsActive;
    protected void Page_Load(object sender, EventArgs e)
    {
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
        if (!Page.IsPostBack)
        {
           
        }
    }
}