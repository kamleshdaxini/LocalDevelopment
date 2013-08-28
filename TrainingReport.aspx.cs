//using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using AjaxControlToolkit;


public partial class Report : System.Web.UI.Page
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
        masteracc.SelectedIndex = inx - 1;
        Login obj = new Login();
        obj.Start();
        Useraname = obj.LogedInUser;
        LoginUser = obj.LoginUser;
        Ret = obj.Ret;
        if (!IsPostBack)
        {
            bind();
        }
    }
    public void bind()
    {
        rptvwer.ServerReport.ReportServerUrl = new System.Uri("http://pun-kpmg-qa/ReportServer");
        rptvwer.ServerReport.ReportPath = @"/TrainingPipeline";
        rptvwer.ShowParameterPrompts = false;
        rptvwer.ShowPrintButton = true;
        rptvwer.ProcessingMode = ProcessingMode.Remote;
        rptvwer.ServerReport.Refresh();
    }
}