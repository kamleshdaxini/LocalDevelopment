using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowRecords_Program : System.Web.UI.Page
{
    public string UserName;
    public int LoginUser;
    public string Ret;
    DataTable DtScopeDocu = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int Ind = MasterAcc.SelectedIndex;
        int InDex = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = InDex - 1;
        Login objScopeDocu = new Login();
        objScopeDocu.Start();
        UserName = objScopeDocu.LogedInUser;
        LoginUser = objScopeDocu.LoginUser;
        Ret = objScopeDocu.Ret;
        grdScopeDocuBind();
    }

    public void grdScopeDocuBind()
    {  
        DataColumn DcDHID = new DataColumn("DH ID#");
        DataColumn DcTraNeeNam = new DataColumn("Training Need Name");
        DataColumn DcCouTit = new DataColumn("Course/Program Title");
        DataColumn DcPortMana = new DataColumn("Portfolio Manager");
        DataColumn DcSRM = new DataColumn("Statckeholder Relationship Manager");
        DtScopeDocu.Columns.Add(DcDHID);
        DtScopeDocu.Columns.Add(DcTraNeeNam);
        DtScopeDocu.Columns.Add(DcCouTit);
        DtScopeDocu.Columns.Add(DcPortMana);
        DtScopeDocu.Columns.Add(DcSRM);  
        DataRow DrScope;
        DrScope = DtScopeDocu.NewRow();
        DrScope["DH ID#"] = "904";
        DrScope["Training Need Name"] = "Industri and technical training for new Incharges";
        DrScope["Course/Program Title"] = "test Record ";
        DrScope["Portfolio Manager"] = "McVay Andrew";
        DrScope["Statckeholder Relationship Manager"] = "Conroy, Catherine M";
        DtScopeDocu.Rows.Add(DrScope);
        if (DtScopeDocu.Rows.Count > 0)
        {
            grdShowRecordsScope.DataSource = DtScopeDocu;
            grdShowRecordsScope.DataBind();
        }
    }
   
    protected void imbRefresh_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void lnkDuplicate_Click(object sender, EventArgs e)
    {
        Session["DtScopeDocu"] = DtScopeDocu;
        Response.Redirect("ScopeDocumentStandalone.aspx", false);
    }

    protected void imbEdit_Click(object sender, ImageClickEventArgs e)
    {
        Session["DtScopeDocu"] = DtScopeDocu;
        Response.Redirect("ScopeDocumentStandalone.aspx", false);
    }

    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Session["DtScopeDocu"] = DtScopeDocu;
        Response.Redirect("ScopeDocumentStandalone.aspx", false);
    }
}