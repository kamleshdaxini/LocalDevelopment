using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScopeDocumentDetails : System.Web.UI.Page
{
   
     public string Useraname;
    public int LoginUser;
    public string Ret;
    public bool IsActive;
    string connStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        Accordion masteracc = (Accordion)Master.FindControl("acdnMaster");
        int ind = masteracc.SelectedIndex;
        int inx = Convert.ToInt16(Session["SrNo"]);
        masteracc.SelectedIndex = inx - 1;
        IsActive = true;
        Login obj = new Login();
        obj.Start();
        Useraname = obj.LogedInUser;
        LoginUser = obj.LoginUser;
        Ret = obj.Ret;
        if (!IsPostBack)
        {
            DataTable dtSRM = SRMActiveDetails(IsActive);
            BindSRM(dtSRM);
            DataTable dtPM = PMActiveDetails(IsActive);
            BindPM(dtPM);
            DataTable dtID = IDActiveDetails(IsActive);
            BindID(dtID);
            DataTable dtCD = CDActiveDetails(IsActive);
            BindCD(dtCD);
            DataTable dtPL = PLActiveDetails(IsActive);
            BindPL(dtPL);
            DataTable dtDL = LoadDL(LoginUser, Ret, IsActive);
            BindDL(dtDL);
            DataTable dtIFC = LoadIFC(LoginUser, Ret);
            BindIFC(dtIFC);
            DataTable dtIFF = LoadIFF(LoginUser, Ret);
            BindIFF(dtIFF);
            DataTable dtIFID = LoadIFI(LoginUser, Ret);
            BindIFID(dtIFID);
            DataTable dtIFSpec = LoadIFSpec(LoginUser, Ret);
            BindIFSpec(dtIFSpec);
            DataTable dtIFTAD = LoadIFTA(LoginUser, Ret);
            BindIFTAD(dtIFTAD);
            DataTable dtIFSR = LoadIFSR(LoginUser, Ret);
            BindIFSR(dtIFSR);
            DataTable dtALI = LoadALI(LoginUser, Ret);
            BindALI(dtALI);
            DataTable dtALIKPMG = LoadALIKPMG(LoginUser, Ret);
            BindALIKPMG(dtALIKPMG);
            DataTable dtBIO = LoadBIO(LoginUser, Ret);
            BindBIO(dtBIO);
            DataTable dtBIOL = LoadBIOL(LoginUser, Ret);
            BindBIOL(dtBIOL);
            DataTable dtBIOP = LoadBIOP(LoginUser, Ret);
            BindBIOP(dtBIOP);
            DataTable dtCR = LoadCR(LoginUser, Ret);
            BindCR(dtCR);
            DataTable dtCBI = LoadCBI(LoginUser, Ret);
            BindCBI(dtCBI);
            DataTable dtRTK = LoadRTK(LoginUser, Ret);
            BindRTK(dtRTK);
            DataTable dtRTKPMG = LoadRTKPMG(LoginUser, Ret);
            BindRTKPMG(dtRTKPMG);
            DataTable dtIFRT = LoadIFRT(LoginUser, Ret);
            BindIFRT(dtIFRT);
        }

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowRecordsCourses.aspx", false);
    }

    protected DataTable SRMActiveDetails(bool IsActive)
    {
        StakeholderRelationshipManagerBAL srmBAL = new StakeholderRelationshipManagerBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = srmBAL.LoadActiveStakeholderRelationshipManager(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            srmBAL = null;
        }

        return dTable;
    }

    public void BindSRM(DataTable dtSRM)
    {
        if (dtSRM.Rows.Count > 0)
        {
            DropDownList26.DataSource = dtSRM;
            DropDownList26.DataTextField = "Name";
            DropDownList26.DataValueField = "StakeholderRelationshipManagerId";
            DropDownList26.DataBind();
            DropDownList26.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
        }
        else
        {
            DropDownList26.DataSource = null;
            DropDownList26.DataTextField = "Name";
            DropDownList26.DataValueField = "StakeholderRelationshipManagerId";
            DropDownList26.DataBind();
            DropDownList26.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            DropDownList26.SelectedIndex = 0;
        }
    }

    protected DataTable PMActiveDetails(bool IsActive)
    {
        PortfolioManagerBAL pbal = new PortfolioManagerBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = pbal.LoadActivePortfolioManager(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            pbal = null;
        }

        return dTable;
    }

    public void BindPM(DataTable dtpm)
    {
        if (dtpm.Rows.Count > 0)
        {
            DropDownList27.DataSource = dtpm;
            DropDownList27.DataTextField = "Name";
            DropDownList27.DataValueField = "PortfolioManagerId";
            DropDownList27.DataBind();
            DropDownList27.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
        }
        else
        {
            DropDownList27.DataSource = null;
            DropDownList27.DataTextField = "Name";
            DropDownList27.DataValueField = "PortfolioManagerId";
            DropDownList27.DataBind();
            DropDownList27.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            DropDownList27.SelectedIndex = 0;
        }

    }


    protected DataTable IDActiveDetails(bool IsActive)
    {
        InstructionalDesignerBAL IDBAl = new InstructionalDesignerBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = IDBAl.LoadActiveInstructionalDesigner(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            IDBAl = null;
        }

        return dTable;
    }

    public void BindID(DataTable dtid)
    {
        if (dtid.Rows.Count > 0)
        {
            ddlmultistk_ID.ChkBind(dtid, "InstructionalDesignerId", "Name");
        }
        else
        {
            ddlmultistk_ID.ChkBind(dtid, "InstructionalDesignerId", "Name");
        }
    }


    protected DataTable CDActiveDetails(bool IsActive)
    {
        ContentDeveloperBAL ContentDeveloperBAL = new ContentDeveloperBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = ContentDeveloperBAL.LoadActiveContentDeveloper(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            ContentDeveloperBAL = null;
        }

        return dTable;
    }

    public void BindCD(DataTable dtcd)
    {
        if (dtcd.Rows.Count > 0)
        {
            ddlmultistk_CD.ChkBind(dtcd, "ContentDeveloperId", "Name");
        }
        else
        {
            ddlmultistk_CD.ChkBind(dtcd, "ContentDeveloperId", "Name");
        }
    }

    protected DataTable PLActiveDetails(bool IsActive)
    {
        ProgramLeadBAL plBAL = new ProgramLeadBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = plBAL.LoadActiveProgramLead(LoginUser, Ret, IsActive);
        }
        catch (Exception ee)
        {
            throw;
        }
        finally
        {
            plBAL = null;
        }

        return dTable;
    }

    public void BindPL(DataTable dtpl)
    {
        if (dtpl.Rows.Count > 0)
        {
            ddlmultistk_PL.ChkBind(dtpl, "ProgramLeadId", "Name");
        }
        else
        {
            ddlmultistk_PL.ChkBind(dtpl, "ProgramLeadId", "Name");
        }
    }

    public DataTable LoadDL(int LoggedInUser, string returnmsg, bool isActive)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("uspGetContentLeadDetails", conn);
        dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        dAd.SelectCommand.Parameters.AddWithValue("@IsActive", IsActive);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "ContentLead");
            return dSet.Tables["ContentLead"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindDL(DataTable dtdl)
    {
        if (dtdl.Rows.Count > 0)
        {
            ddlmultistk_DL.ChkBind(dtdl, "ContentLeadId", "Name");
        }
        else
        {
            ddlmultistk_DL.ChkBind(dtdl, "ContentLeadId", "Name");
        }
    }

    public DataTable LoadIFC(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.Curriculum", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "Curriculum");
            return dSet.Tables["Curriculum"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindIFC(DataTable dtIFc)
    {
        if (dtIFc.Rows.Count > 0)
        {
            mlttarget_cur_keyword.ChkBind(dtIFc, "CurriculumId", "Curriculum");
        }
        else
        {
            mlttarget_cur_keyword.ChkBind(dtIFc, "CurriculumId", "Curriculum");
        }
    }

    public DataTable LoadIFF(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.Functions", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "Functions");
            return dSet.Tables["Functions"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public DataTable LoadIFI(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.Industries", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "Industries");
            return dSet.Tables["Industries"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindIFID(DataTable dtIFid)
    {
        if (dtIFid.Rows.Count > 0)
        {
            mlttarget_Industries.ChkBind(dtIFid, "IndustriesID", "Industries");
        }
        else
        {
            mlttarget_Industries.ChkBind(dtIFid, "IndustriesID", "Industries");
        }
    }

    public void BindIFF(DataTable dtIFf)
    {
        if (dtIFf.Rows.Count > 0)
        {
            mlttarget_functions.ChkBind(dtIFf, "FunctionsID", "Functions");

        }
        else
        {
            mlttarget_functions.ChkBind(dtIFf, "FunctionsID", "Functions");
        }
    }

    public DataTable LoadIFSpec(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.Specialties", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "Specialties");
            return dSet.Tables["Specialties"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindIFSpec(DataTable dtIFSPEC)
    {
        if (dtIFSPEC.Rows.Count > 0)
        {
            mlttarget_Specialities.ChkBind(dtIFSPEC, "SpecialtiesID", "Specialties");
        }
        else
        {
            mlttarget_Specialities.ChkBind(dtIFSPEC, "SpecialtiesID", "Specialties");
        }
    }

    public DataTable LoadIFTA(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.TargetAudience", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "TargetAudience");
            return dSet.Tables["TargetAudience"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindIFTAD(DataTable dtIFtad)
    {
        if (dtIFtad.Rows.Count > 0)
        {
            mlttarget_audience.ChkBind(dtIFtad, "TargetAudienceID", "TargetAudience");
        }
        else
        {
            mlttarget_audience.ChkBind(dtIFtad, "TargetAudienceID", "TargetAudience");
        }
    }

    public DataTable LoadIFSR(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.StakeholderResources", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "StakeholderResources");
            return dSet.Tables["StakeholderResources"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindIFSR(DataTable dtIFSr)
    {
        if (dtIFSr.Rows.Count > 0)
        {
            mlttarget_stkresource.ChkBind(dtIFSr, "StakeholderResourcesID", "StakeholderResources");
        }
        else
        {
            mlttarget_stkresource.ChkBind(dtIFSr, "StakeholderResourcesID", "StakeholderResources");
        }
    }

    public DataTable LoadALI(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.AlignmentWithKBSAStrategy", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "AlignmentWithKBSAStrategy");
            return dSet.Tables["AlignmentWithKBSAStrategy"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindALI(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            DropDownList40.DataSource = dtali;
            DropDownList40.DataTextField = "AlignmentWithKBSAStrategy";
            DropDownList40.DataValueField = "StrategyValue";
            DropDownList40.DataBind();
            DropDownList40.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            DropDownList40.DataSource = null;
            DropDownList40.DataTextField = "AlignmentWithKBSAStrategy";
            DropDownList40.DataValueField = "StrategyValue";
            DropDownList40.DataBind();
            DropDownList40.Items.Insert(0, new ListItem("<< Select >>", "0"));
            DropDownList40.SelectedIndex = 0;
        }

    }

    public void BindALIKPMG(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            DropDownList2.DataSource = dtali;
            DropDownList2.DataTextField = "AlignmentWithKPMGStrategy";
            DropDownList2.DataValueField = "StrategyValue";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            DropDownList2.DataSource = null;
            DropDownList2.DataTextField = "AlignmentWithKPMGStrategy";
            DropDownList2.DataValueField = "StrategyValue";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("<< Select >>", "0"));
            DropDownList2.SelectedIndex = 0;
        }

    }

    public DataTable LoadALIKPMG(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.AlignmentWithKPMGStrategy", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "AlignmentWithKPMGStrategy");
            return dSet.Tables["AlignmentWithKPMGStrategy"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindBIO(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            DropDownList5.DataSource = dtali;
            DropDownList5.DataTextField = "BusinessImpactOnPeople";
            DropDownList5.DataValueField = "BusinessImpactValue";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            DropDownList5.DataSource = null;
            DropDownList5.DataTextField = "BusinessImpactOnPeople";
            DropDownList5.DataValueField = "BusinessImpactValue";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, new ListItem("<< Select >>", "0"));
            DropDownList5.SelectedIndex = 0;
        }

    }

    public DataTable LoadBIO(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.BusinessImpactOnPeople", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "BusinessImpactOnPeople");
            return dSet.Tables["BusinessImpactOnPeople"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }


    public void BindBIOL(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            DropDownList43.DataSource = dtali;
            DropDownList43.DataTextField = "BusinessImpactOnBottomLine";
            DropDownList43.DataValueField = "Value";
            DropDownList43.DataBind();
            DropDownList43.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            DropDownList43.DataSource = null;
            DropDownList43.DataTextField = "BusinessImpactOnBottomLine";
            DropDownList43.DataValueField = "Value";
            DropDownList43.DataBind();
            DropDownList43.Items.Insert(0, new ListItem("<< Select >>", "0"));
            DropDownList43.SelectedIndex = 0;
        }

    }

    public DataTable LoadBIOL(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.BusinessImpactOnBottomLine", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "BusinessImpactOnBottomLine");
            return dSet.Tables["BusinessImpactOnBottomLine"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }


    public void BindBIOP(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            DropDownList42.DataSource = dtali;
            DropDownList42.DataTextField = "BusinessImpactOnProcess";
            DropDownList42.DataValueField = "Value";
            DropDownList42.DataBind();
            DropDownList42.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            DropDownList42.DataSource = null;
            DropDownList42.DataTextField = "BusinessImpactOnProcess";
            DropDownList42.DataValueField = "Value";
            DropDownList42.DataBind();
            DropDownList42.Items.Insert(0, new ListItem("<< Select >>", "0"));
            DropDownList42.SelectedIndex = 0;
        }

    }

    public DataTable LoadBIOP(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.BusinessImpactOnProcess", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "BusinessImpactOnProcess");
            return dSet.Tables["BusinessImpactOnProcess"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }


    public void BindCBI(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            DropDownList44.DataSource = dtali;
            DropDownList44.DataTextField = "CostBudgetImpact";
            DropDownList44.DataValueField = "Value";
            DropDownList44.DataBind();
            DropDownList44.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            DropDownList44.DataSource = null;
            DropDownList44.DataTextField = "CostBudgetImpact";
            DropDownList44.DataValueField = "Value";
            DropDownList44.DataBind();
            DropDownList44.Items.Insert(0, new ListItem("<< Select >>", "0"));
            DropDownList44.SelectedIndex = 0;
        }

    }

    public DataTable LoadCBI(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.CostBudgetImpact", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "CostBudgetImpact");
            return dSet.Tables["CostBudgetImpact"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindCR(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            DropDownList17.DataSource = dtali;
            DropDownList17.DataTextField = "CostReasonableness";
            DropDownList17.DataValueField = "Value";
            DropDownList17.DataBind();
            DropDownList17.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            DropDownList17.DataSource = null;
            DropDownList17.DataTextField = "CostReasonableness";
            DropDownList17.DataValueField = "Value";
            DropDownList17.DataBind();
            DropDownList17.Items.Insert(0, new ListItem("<< Select >>", "0"));
            DropDownList17.SelectedIndex = 0;
        }

    }

    public DataTable LoadCR(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.CostReasonableness", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "CostReasonableness");
            return dSet.Tables["CostReasonableness"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindRTK(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            DropDownList47.DataSource = dtali;
            DropDownList47.DataTextField = "RiskToKBSA";
            DropDownList47.DataValueField = "Value";
            DropDownList47.DataBind();
            DropDownList47.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            DropDownList47.DataSource = null;
            DropDownList47.DataTextField = "RiskToKBSA";
            DropDownList47.DataValueField = "Value";
            DropDownList47.DataBind();
            DropDownList47.Items.Insert(0, new ListItem("<< Select >>", "0"));
            DropDownList47.SelectedIndex = 0;
        }

    }

    public DataTable LoadRTK(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.RiskToKBSA", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "RiskToKBSA");
            return dSet.Tables["RiskToKBSA"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindRTKPMG(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            DropDownList46.DataSource = dtali;
            DropDownList46.DataTextField = "RiskToKPMG";
            DropDownList46.DataValueField = "Value";
            DropDownList46.DataBind();
            DropDownList46.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            DropDownList46.DataSource = null;
            DropDownList46.DataTextField = "RiskToKPMG";
            DropDownList46.DataValueField = "Value";
            DropDownList46.DataBind();
            DropDownList46.Items.Insert(0, new ListItem("<< Select >>", "0"));
            DropDownList46.SelectedIndex = 0;
        }

    }

    public DataTable LoadRTKPMG(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.RiskToKPMG", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "RiskToKPMG");
            return dSet.Tables["RiskToKPMG"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    protected void DropDownList40_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void DropDownList42_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void DropDownList43_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void DropDownList44_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void DropDownList17_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void DropDownList46_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void DropDownList47_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }

    public void Cal()
    {
        int d1 = Convert.ToInt32(DropDownList40.SelectedValue);
        int d2 = Convert.ToInt32(DropDownList2.SelectedValue);
        int d3 = Convert.ToInt32(DropDownList5.SelectedValue);
        int d4 = Convert.ToInt32(DropDownList42.SelectedValue);
        int d5 = Convert.ToInt32(DropDownList43.SelectedValue);
        int d6 = Convert.ToInt32(DropDownList44.SelectedValue);
        int d7 = Convert.ToInt32(DropDownList17.SelectedValue);
        int d8 = Convert.ToInt32(DropDownList47.SelectedValue);
        int d9 = Convert.ToInt32(DropDownList46.SelectedValue);
        int test = d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 + d9;
        int test1 = d1 * d2 * d3 * d4 * d5 * d6 * d7 * d8 * d9;
        txtWs2PS.Text = test.ToString();
        txtWs2PF.Text = test1.ToString();
        int t1 = Convert.ToInt32(txtWs2PF.Text);
        if (t1 == 0)
        {
            lblWS2FO.Text = "Training need doesn't meet citeria to develop training";

        }
        else
        {
            lblWS2FO.Text = "Okay to proceed";


        }

        int t2 = Convert.ToInt32(txtWs2PS.Text);
        if (t2 < 6)
        {
            lblWS2COPT.Text = "Killer variable or missed question";
            lblWS2COPT.Font.Bold = true;
            lblWS2COPT.Font.Size = 14;
        }
        else if (t2 >= 6 & t2 <= 12)
        {
            lblWS2COPT.Text = "Low Priority Tier";
            lblWS2COPT.Font.Bold = true;
            lblWS2COPT.Font.Size = 14;
        }
        else if (t2 >= 12 & t2 <= 22)
        {
            lblWS2COPT.Text = "Mid Priority Tier  ";
            lblWS2COPT.Font.Bold = true;
            lblWS2COPT.Font.Size = 14;
        }
        else if (t2 >= 22)
        {
            lblWS2COPT.Text = " High Priority Tier";
            lblWS2COPT.Font.Bold = true;
            lblWS2COPT.Font.Size = 14;
        }
    }

    public DataTable LoadIFRT(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.ReviewerType", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "ReviewerType");
            return dSet.Tables["ReviewerType"];
        }
        catch
        {
            throw;
        }
        finally
        {
            dSet.Dispose();
            dAd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }

    public void BindIFRT(DataTable dtIFrt)
    {
        if (dtIFrt.Rows.Count > 0)
        {
            mlttarget_rec_review.ChkBind(dtIFrt, "ReviewerTypeId", "ReviewerType");
        }
        else
        {
            mlttarget_rec_review.ChkBind(dtIFrt, "ReviewerTypeId", "ReviewerType");
        }
    }
   
}