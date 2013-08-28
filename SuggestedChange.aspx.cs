using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;

public partial class SuggestedChange : System.Web.UI.Page
{
    int SuggChanID;
    public string UserName;
    public int LoginUser;
    public string Ret; 
    protected void Page_Load(object sender, EventArgs e)
    {
        Accordion MasterAcc = (Accordion)Master.FindControl("acdnMaster");
        int Ind = MasterAcc.SelectedIndex;
        int Index = Convert.ToInt16(Session["SrNo"]);
        MasterAcc.SelectedIndex = Index - 1;
        grdScopeIDBind();
        if (!Page.IsPostBack)
        {
            Login objSuggChan = new Login();
            objSuggChan.Start();
            UserName = objSuggChan.LogedInUser;
            LoginUser = objSuggChan.LoginUser;
            Ret = objSuggChan.Ret;
            if (Session["SuggChanID"] != null)
            {
                CheckSuggChangeId();
                SuggChanID = 1108;            
            }
        }
        
    }

    protected void CheckSuggChangeId()
    {
        SuggChanID = 1108;
        DataTable DtSelectId = GetSuggChanDetails(SuggChanID);
        if (DtSelectId.Rows.Count > 0)
        {
            lblSuggID.Text = DtSelectId.Rows[0][0].ToString();
            txtSuggChanTitle.Text = DtSelectId.Rows[0][1].ToString();
            txtSuggChanDate.Text = DtSelectId.Rows[0][2].ToString();
            string status = DtSelectId.Rows[0][3].ToString();
            if (status == "Active")
            {
                ddlSuggChanStatus.SelectedIndex = 0;
            }
            else if (status == "InActive")
            {
                ddlSuggChanStatus.SelectedIndex = 1;
            }
        }
        grdScopeIDBind();
    }

    private DataTable GetSuggChanDetails(int SuggChanID)
    {
        DataTable DtSuggChanDet = (DataTable)Session["DtSuggChange"];
        DataView DvSuggChan = DtSuggChanDet.DefaultView;
        DvSuggChan.RowFilter = "ID = " + SuggChanID;
        DataTable DtSuggChan = DvSuggChan.ToTable();
        return DtSuggChan;
    }

    public void grdScopeIDBind()
    {
        DataTable DtScopeID = new DataTable();
        DataColumn DcScopeID = new DataColumn("ScopeDocuID");
        DtScopeID.Columns.Add(DcScopeID);
        DataRow DrScopeID;
        for (int i = 1; i <= 2; i++)
        {
            DrScopeID = DtScopeID.NewRow();
            DrScopeID["ScopeDocuID"] = i;
            DtScopeID.Rows.Add(DrScopeID);
        }
        BindSDID(DtScopeID);
        Bind_SCCR(DtScopeID);
    }

    private void BindSDID(DataTable DtSuggChanID)
    {
        ViewState["dtSuggChanID"] = DtSuggChanID;
        if (DtSuggChanID.Rows.Count > 0)
        {
            GrdSuggestedChangeSD.DataSource = DtSuggChanID;
            GrdSuggestedChangeSD.DataBind();
            for (int i = 0; i < DtSuggChanID.Rows.Count; i++)
            {
                DropDownList ddlScopeID = (GrdSuggestedChangeSD.Rows[i].FindControl("ddlSuggChanScopeID") as DropDownList);
                ddlScopeID.DataSource = DtSuggChanID;
                ddlScopeID.DataTextField = "ScopeDocuID";
                ddlScopeID.DataValueField = "ScopeDocuID";
                ddlScopeID.DataBind();
            }
        }
    }

    private void Bind_SCCR(DataTable DtSCCR)
    {
        ViewState["dtSCCR"] = DtSCCR;
        if (DtSCCR.Rows.Count > 0)
        {
            grdSuggChanCiteRes.DataSource = DtSCCR;
            grdSuggChanCiteRes.DataBind();
            for (int i = 0; i < DtSCCR.Rows.Count; i++)
            {
                DropDownList ddlSID = (grdSuggChanCiteRes.Rows[i].FindControl("ddlScopeID") as DropDownList);
                ddlSID.DataSource = DtSCCR;
                ddlSID.DataTextField = "ScopeDocuID";
                ddlSID.DataValueField = "ScopeDocuID";
                ddlSID.DataBind();
            }
        }
    }

    protected void ddlSuggChanScopeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drpdwn = sender as DropDownList;
        GridViewRow rw = (GridViewRow)drpdwn.Parent.Parent;
        int Index = rw.RowIndex;
        int Ind = drpdwn.SelectedIndex;
        DataTable DtSugg = (DataTable)ViewState["dtSuggChanID"];
        //GrdSuggestedChangeSD.DataSource = DtSugg;
        //GrdSuggestedChangeSD.DataBind();
        DropDownList CmbSCSD1 = (GrdSuggestedChangeSD.Rows[Index].FindControl("ddlSuggChanScopeID") as DropDownList);
        Label lblDeDate = (GrdSuggestedChangeSD.Rows[Index].FindControl("lblDelDate") as Label);
        Label lblCourseName = (GrdSuggestedChangeSD.Rows[Index].FindControl("lblCourseName") as Label);
        Label lblCourseDate = (GrdSuggestedChangeSD.Rows[Index].FindControl("lblCourseDate") as Label);
        Label ddlCN = (GrdSuggestedChangeSD.Rows[Index].FindControl("ddlCourseNumber") as Label);
        Label ddlS = (GrdSuggestedChangeSD.Rows[Index].FindControl("ddlStakeholder") as Label);
        Label ddlSRM = (GrdSuggestedChangeSD.Rows[Index].FindControl("ddlSRM") as Label);
        Label ddlPM = (GrdSuggestedChangeSD.Rows[Index].FindControl("ddlPortMana") as Label);
        DropDownList ddlSC = (GrdSuggestedChangeSD.Rows[Index].FindControl("ddlSuggChan") as DropDownList);
        Label ddlCE = (GrdSuggestedChangeSD.Rows[Index].FindControl("ddlCourseEval") as Label);       
        lblDeDate.Text = "Test Record";
        lblCourseName.Text = "Test Course";
        lblCourseDate.Text  = "12/04/2012";
        ddlCN.Text = "A1233";
        ddlS.Text = "Prol, Robert";
        ddlPM.Text = "Test";
        ddlSRM.Text = "Gaikwad, Kalawati";
        ddlSRM.Text = "NA";
        ddlSC.SelectedIndex = 2;
        ddlCE.Text = "Test";
        for (int i = 0; i < DtSugg.Rows.Count; i++)
        {
            DropDownList ddlScopeID = (GrdSuggestedChangeSD.Rows[i].FindControl("ddlSuggChanScopeID") as DropDownList);
            ddlScopeID.DataSource = DtSugg;
            ddlScopeID.DataTextField = "ScopeDocuID";
            ddlScopeID.DataValueField = "ScopeDocuID";
            ddlScopeID.DataBind();   
        }
        CmbSCSD1.SelectedIndex = Ind;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        msgSuggChan.Msg = "Record Save Successfully";
        msgSuggChan.showmsg();
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        ClearData();
        Response.Redirect("SuggestedChange.aspx", false);
    }

    public void ClearData()
    {
        lblSuggID.Text = "";
        txtSuggChanTitle.Text = "";
        txtSuggChanDate.Text = "";
        ddlSuggChanStatus.SelectedIndex = 0;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowRecordsSuggestedChange.aspx", false);
    }
}



