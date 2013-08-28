using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class progress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // To set Selected accordion open 
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int GroupInd = MasterAcc.SelectedIndex;
        int GroupIndex = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = GroupIndex - 1;
    }
}