﻿using AjaxControlToolkit;
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
        Login obj = new Login();
        IsActive = true;
        obj.Start();
        Useraname = obj.LogedInUser;
        LoginUser = obj.LoginUser;
        Ret = obj.Ret;
        if (!IsPostBack)
        {            
           communicationbind();
            Calenderbind();
            Mesurementbind();
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
            DataTable dtDL = LoadDL(LoginUser, Ret,IsActive);
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
    public void Mesurementbind()
    {
        DataTable dtable = new DataTable();
        DataTable dtt = new DataTable();
        DataColumn dt = new DataColumn("Levels");
        DataColumn dt1 = new DataColumn("What");
        DataColumn dt2 = new DataColumn("To Whom");
        DataColumn dt3 = new DataColumn("When Launched Date");
        DataColumn dt4 = new DataColumn("Launch Description");
        DataColumn dt5 = new DataColumn("Format Vehicle");
        DataColumn dt6 = new DataColumn("Other logistics");
        DataColumn dt7 = new DataColumn("ID");
        dtable.Columns.Add(dt);
        dtable.Columns.Add(dt1);
        dtable.Columns.Add(dt2);
        dtable.Columns.Add(dt3);
        dtable.Columns.Add(dt4);
        dtable.Columns.Add(dt5);
        dtable.Columns.Add(dt6);
        dtable.Columns.Add(dt7);
        DataRow dr;
        dr = dtable.NewRow();
        dr["Levels"] = "level-1 Reaction/Evalution";
        dr["What"] = "";
        dr["To Whom"] = "test";
        dr["When Launched Date"] = "";
        dr["Launch Description"] = "";
        dr["Format Vehicle"] = "";
        dr["Other logistics"] = "";
        dr["ID"] = "1349";
        dtable.Rows.Add(dr);
        if (dtable.Rows.Count > 0)
        {
            grdMeasurement.DataSource = dtable;
            grdMeasurement.DataBind();
        }
    }
    public void Calenderbind()
    {
        DataTable dtable = new DataTable();
        DataTable dtt = new DataTable();
        DataColumn dt = new DataColumn("Name of Course or Program");
        DataColumn dt1 = new DataColumn("Session#");
        DataColumn dt2 = new DataColumn("Max Pax");
        DataColumn dt3 = new DataColumn("Start Time");
        DataColumn dt4 = new DataColumn("End Time");   
        dtable.Columns.Add(dt);
        dtable.Columns.Add(dt1);
        dtable.Columns.Add(dt2);
        dtable.Columns.Add(dt3);
        dtable.Columns.Add(dt4);    
        DataRow dr;
        dr = dtable.NewRow();
        dr["Name of Course or Program"] = "Test";
        dr["Session#"] = "n/a";
        dr["Max Pax"] = "";
        dr["Start Time"] = "4/12/2013";
        dr["End Time"] = "4/12/2013";       
        dtable.Rows.Add(dr);
        if (dtable.Rows.Count > 0)
        {
            grdCalender.DataSource = dtable;
            grdCalender.DataBind();
        }
    }
    public void communicationbind()        
{

    DataTable dtable = new DataTable();
    DataTable dtt = new DataTable();
    DataColumn dt = new DataColumn("What");
    DataColumn dt1 = new DataColumn("Who");
    DataColumn dt2 = new DataColumn("When");
    DataColumn dt3 = new DataColumn("Format/Vehicle");
    DataColumn dt4 = new DataColumn("Other logistics");
    DataColumn dt5 = new DataColumn("Review Requirements/final Approver");
    DataColumn dt6 = new DataColumn("DH#");
    dtable.Columns.Add(dt);
    dtable.Columns.Add(dt1);
    dtable.Columns.Add(dt2);
    dtable.Columns.Add(dt3);
    dtable.Columns.Add(dt4);
    dtable.Columns.Add(dt5);
    dtable.Columns.Add(dt6);
    DataRow dr;
    dr = dtable.NewRow();
    dr["What"] = "Heads up Change Management";
    dr["Who"] = "Test";
    dr["When"] = "4/12/2013";
    dr["Format/Vehicle"] = "";
    dr["Other logistics"] = "";
    dr["Review Requirements/final Approver"] = "";   
    dr["DH#"] = "1349";      
    dtable.Rows.Add(dr);
    if (dtable.Rows.Count > 0)
    {
        grdcommunication_plnaDetails.DataSource = dtable;
        grdcommunication_plnaDetails.DataBind();
    }
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
            ddlSRM.DataSource = dtSRM;
            ddlSRM.DataTextField = "Name";
            ddlSRM.DataValueField = "StakeholderRelationshipManagerId";
            ddlSRM.DataBind();
            ddlSRM.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
        }
        else
        {
            ddlSRM.DataSource = null;
            ddlSRM.DataTextField = "Name";
            ddlSRM.DataValueField = "StakeholderRelationshipManagerId";
            ddlSRM.DataBind();
            ddlSRM.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlSRM.SelectedIndex = 0;
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
            ddlPortMana.DataSource = dtpm;
            ddlPortMana.DataTextField = "Name";
            ddlPortMana.DataValueField = "PortfolioManagerId";
            ddlPortMana.DataBind();
            ddlPortMana.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
        }
        else
        {
            ddlPortMana.DataSource = null;
            ddlPortMana.DataTextField = "Name";
            ddlPortMana.DataValueField = "PortfolioManagerId";
            ddlPortMana.DataBind();
            ddlPortMana.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlPortMana.SelectedIndex = 0;
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
            ddlmslInsDes.ChkBind(dtid, "InstructionalDesignerId", "Name");
        }
        else
        {
            ddlmslInsDes.ChkBind(dtid, "InstructionalDesignerId", "Name");
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
            ddlmslConDev.ChkBind(dtcd, "ContentDeveloperId", "Name");
        }
        else
        {
            ddlmslConDev.ChkBind(dtcd, "ContentDeveloperId", "Name");
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
        catch
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
            ddlmslPrgLead.ChkBind(dtpl, "ProgramLeadId", "Name");
        }
        else
        {
            ddlmslPrgLead.ChkBind(dtpl, "ProgramLeadId", "Name");
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
            ddlmslDelLead.ChkBind(dtdl, "ContentLeadId", "Name");
        }
        else
        {
            ddlmslDelLead.ChkBind(dtdl, "ContentLeadId", "Name");
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
            ddlmslCurrKey.ChkBind(dtIFc, "CurriculumId", "Curriculum");
        }
        else
        {
            ddlmslCurrKey.ChkBind(dtIFc, "CurriculumId", "Curriculum");
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
            ddlmslIndustries.ChkBind(dtIFid, "IndustriesID", "Industries");
        }
        else
        {
            ddlmslIndustries.ChkBind(dtIFid, "IndustriesID", "Industries");
        }
    }

    public void BindIFF(DataTable dtIFf)
    {
        if (dtIFf.Rows.Count > 0)
        {
            ddlmslFunctions.ChkBind(dtIFf, "FunctionsID", "Functions");

        }
        else
        {
            ddlmslFunctions.ChkBind(dtIFf, "FunctionsID", "Functions");
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
            ddlmslSpecialities.ChkBind(dtIFSPEC, "SpecialtiesID", "Specialties");
        }
        else
        {
            ddlmslSpecialities.ChkBind(dtIFSPEC, "SpecialtiesID", "Specialties");
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
            ddlmslTargetAudience.ChkBind(dtIFtad, "TargetAudienceID", "TargetAudience");
        }
        else
        {
            ddlmslTargetAudience.ChkBind(dtIFtad, "TargetAudienceID", "TargetAudience");
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
            ddlmslStkResource.ChkBind(dtIFSr, "StakeholderResourcesID", "StakeholderResources");
        }
        else
        {
            ddlmslStkResource.ChkBind(dtIFSr, "StakeholderResourcesID", "StakeholderResources");
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
            ddlAligALD.DataSource = dtali;
            ddlAligALD.DataTextField = "AlignmentWithKBSAStrategy";
            ddlAligALD.DataValueField = "StrategyValue";
            ddlAligALD.DataBind();
            ddlAligALD.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlAligALD.DataSource = null;
            ddlAligALD.DataTextField = "AlignmentWithKBSAStrategy";
            ddlAligALD.DataValueField = "StrategyValue";
            ddlAligALD.DataBind();
            ddlAligALD.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlAligALD.SelectedIndex = 0;
        }

    }

    public void BindALIKPMG(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            ddlAligKPMG.DataSource = dtali;
            ddlAligKPMG.DataTextField = "AlignmentWithKPMGStrategy";
            ddlAligKPMG.DataValueField = "StrategyValue";
            ddlAligKPMG.DataBind();
            ddlAligKPMG.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlAligKPMG.DataSource = null;
            ddlAligKPMG.DataTextField = "AlignmentWithKPMGStrategy";
            ddlAligKPMG.DataValueField = "StrategyValue";
            ddlAligKPMG.DataBind();
            ddlAligKPMG.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlAligKPMG.SelectedIndex = 0;
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
            ddlBusImpOnPeo.DataSource = dtali;
            ddlBusImpOnPeo.DataTextField = "BusinessImpactOnPeople";
            ddlBusImpOnPeo.DataValueField = "BusinessImpactValue";
            ddlBusImpOnPeo.DataBind();
            ddlBusImpOnPeo.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlBusImpOnPeo.DataSource = null;
            ddlBusImpOnPeo.DataTextField = "BusinessImpactOnPeople";
            ddlBusImpOnPeo.DataValueField = "BusinessImpactValue";
            ddlBusImpOnPeo.DataBind();
            ddlBusImpOnPeo.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlBusImpOnPeo.SelectedIndex = 0;
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
            ddlBusImpOnBottLine.DataSource = dtali;
            ddlBusImpOnBottLine.DataTextField = "BusinessImpactOnBottomLine";
            ddlBusImpOnBottLine.DataValueField = "Value";
            ddlBusImpOnBottLine.DataBind();
            ddlBusImpOnBottLine.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlBusImpOnBottLine.DataSource = null;
            ddlBusImpOnBottLine.DataTextField = "BusinessImpactOnBottomLine";
            ddlBusImpOnBottLine.DataValueField = "Value";
            ddlBusImpOnBottLine.DataBind();
            ddlBusImpOnBottLine.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlBusImpOnBottLine.SelectedIndex = 0;
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
            ddlBusImpOnProcess.DataSource = dtali;
            ddlBusImpOnProcess.DataTextField = "BusinessImpactOnProcess";
            ddlBusImpOnProcess.DataValueField = "Value";
            ddlBusImpOnProcess.DataBind();
            ddlBusImpOnProcess.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlBusImpOnProcess.DataSource = null;
            ddlBusImpOnProcess.DataTextField = "BusinessImpactOnProcess";
            ddlBusImpOnProcess.DataValueField = "Value";
            ddlBusImpOnProcess.DataBind();
            ddlBusImpOnProcess.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlBusImpOnProcess.SelectedIndex = 0;
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
            ddlCostBugImp.DataSource = dtali;
            ddlCostBugImp.DataTextField = "CostBudgetImpact";
            ddlCostBugImp.DataValueField = "Value";
            ddlCostBugImp.DataBind();
            ddlCostBugImp.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlCostBugImp.DataSource = null;
            ddlCostBugImp.DataTextField = "CostBudgetImpact";
            ddlCostBugImp.DataValueField = "Value";
            ddlCostBugImp.DataBind();
            ddlCostBugImp.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlCostBugImp.SelectedIndex = 0;
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
            ddlCostReaso.DataSource = dtali;
            ddlCostReaso.DataTextField = "CostReasonableness";
            ddlCostReaso.DataValueField = "Value";
            ddlCostReaso.DataBind();
            ddlCostReaso.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlCostReaso.DataSource = null;
            ddlCostReaso.DataTextField = "CostReasonableness";
            ddlCostReaso.DataValueField = "Value";
            ddlCostReaso.DataBind();
            ddlCostReaso.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlCostReaso.SelectedIndex = 0;
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
            ddlRiskALD.DataSource = dtali;
            ddlRiskALD.DataTextField = "RiskToKBSA";
            ddlRiskALD.DataValueField = "Value";
            ddlRiskALD.DataBind();
            ddlRiskALD.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlRiskALD.DataSource = null;
            ddlRiskALD.DataTextField = "RiskToKBSA";
            ddlRiskALD.DataValueField = "Value";
            ddlRiskALD.DataBind();
            ddlRiskALD.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlRiskALD.SelectedIndex = 0;
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
            ddlRiskKPMG.DataSource = dtali;
            ddlRiskKPMG.DataTextField = "RiskToKPMG";
            ddlRiskKPMG.DataValueField = "Value";
            ddlRiskKPMG.DataBind();
            ddlRiskKPMG.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlRiskKPMG.DataSource = null;
            ddlRiskKPMG.DataTextField = "RiskToKPMG";
            ddlRiskKPMG.DataValueField = "Value";
            ddlRiskKPMG.DataBind();
            ddlRiskKPMG.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlRiskKPMG.SelectedIndex = 0;
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

    protected void ddlAligALD_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlAligKPMG_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlBusImpOnPeo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlBusImpOnProcess_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlBusImpOnBottLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlCostBugImp_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlCostReaso_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlRiskKPMG_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlRiskALD_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }

    public void Cal()
    {
        int d1 = Convert.ToInt32(ddlAligALD.SelectedValue);
        int d2 = Convert.ToInt32(ddlAligKPMG.SelectedValue);
        int d3 = Convert.ToInt32(ddlBusImpOnPeo.SelectedValue);
        int d4 = Convert.ToInt32(ddlBusImpOnProcess.SelectedValue);
        int d5 = Convert.ToInt32(ddlBusImpOnBottLine.SelectedValue);
        int d6 = Convert.ToInt32(ddlCostBugImp.SelectedValue);
        int d7 = Convert.ToInt32(ddlCostReaso.SelectedValue);
        int d8 = Convert.ToInt32(ddlRiskALD.SelectedValue);
        int d9 = Convert.ToInt32(ddlRiskKPMG.SelectedValue);
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
            ddlmslRecRevType.ChkBind(dtIFrt, "ReviewerTypeId", "ReviewerType");
        }
        else
        {
            ddlmslRecRevType.ChkBind(dtIFrt, "ReviewerTypeId", "ReviewerType");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowRecordsStandalone.aspx", false);
    }
}