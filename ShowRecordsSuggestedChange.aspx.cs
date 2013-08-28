using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

public partial class SuggestedChangeShowRecords : System.Web.UI.Page
{
    public string UserName;
    public int LoginUser;
    public string Ret; 

    protected void Page_Load(object sender, EventArgs e)
    {
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int Ind = MasterAcc.SelectedIndex;
        int Index = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = Index - 1;      
        Login objSuggChange = new Login();
        objSuggChange.Start();
        UserName = objSuggChange.LogedInUser;
        LoginUser = objSuggChange.LoginUser;
        Ret = objSuggChange.Ret;      
        if (!Page.IsPostBack)
        {
            grdSuggChangeBind();
        }
    }

    public void grdSuggChangeBind()
    {
        DataTable DtSuggChange = new DataTable();
        DataColumn DcID = new DataColumn("ID");
        DataColumn DcSuggChanTit = new DataColumn("Suggested Change Title");
        DataColumn DcSuggChanDate = new DataColumn("Suggested Change Date");
        DataColumn DcStatus = new DataColumn("Status");
        DtSuggChange.Columns.Add(DcID);
        DtSuggChange.Columns.Add(DcSuggChanTit);
        DtSuggChange.Columns.Add(DcSuggChanDate);
        DtSuggChange.Columns.Add(DcStatus);
        DataRow DrSuggCha;
        DrSuggCha = DtSuggChange.NewRow();
        DrSuggCha["ID"] = "1";
        DrSuggCha["Suggested Change Title"] = "Test Record 1";
        DrSuggCha["Suggested Change Date"] = "4/25/2012";
        DrSuggCha["Status"] = "Active";
        DtSuggChange.Rows.Add(DrSuggCha);
        DrSuggCha = DtSuggChange.NewRow();
        DrSuggCha["ID"] = "2";
        DrSuggCha["Suggested Change Title"] = "Test Record 2";
        DrSuggCha["Suggested Change Date"] = "7/13/2012";
        DrSuggCha["Status"] = "Active";
        DtSuggChange.Rows.Add(DrSuggCha);
        DrSuggCha = DtSuggChange.NewRow();
        DrSuggCha["ID"] = "3";
        DrSuggCha["Suggested Change Title"] = "Test Record 3";
        DrSuggCha["Suggested Change Date"] = "9/30/2012";
        DrSuggCha["Status"] = "Active";
        DtSuggChange.Rows.Add(DrSuggCha);
        DrSuggCha = DtSuggChange.NewRow();
        DrSuggCha["ID"] = "4";
        DrSuggCha["Suggested Change Title"] = "Test Record 4";
        DrSuggCha["Suggested Change Date"] = "2/15/2012";
        DrSuggCha["Status"] = "Active";
        DtSuggChange.Rows.Add(DrSuggCha);
        if (DtSuggChange.Rows.Count > 0)
        {
            GrdSuggestedChangeSR.DataSource = DtSuggChange;
            GrdSuggestedChangeSR.DataBind();
        }
        Session["DtSuggChange"] = DtSuggChange;
    }

    protected void imbSearch_Click(object sender, EventArgs e)
    {

    }
    protected void imbRefresh_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ddlColumn_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkAddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("SuggestedChange.aspx", false);
    }
    protected void imbEdit_Click(object sender, ImageClickEventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        //int SCID = Convert.ToInt32(lnk.CommandArgument.ToString());
        //lblSelectID.Text = SCID.ToString();
        Session["SuggChanID"] = 1108;
        Response.Redirect("SuggestedChange.aspx", false); 
    }
 
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("SuggestedChange.aspx", false);
    }
}