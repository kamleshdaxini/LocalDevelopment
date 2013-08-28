using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AjaxControlToolkit;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;


public partial class IntakeForm1 : System.Web.UI.Page
{
    // Initialization of Public Variables
    int IntakeFormId;// For Group Id 
    public string UserName;// For Loged in username
    public int LoginUser;// For Loged in userId
    public string Ret;// For return message 
    public  bool IsActive;
    DataTable dtCL = new DataTable();
    string connStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        rngfvalOrigin_MeetingDate.MaximumValue = DateTime.Now.Date.ToShortDateString();
        rngfvalOrigin_MeetingDate.MinimumValue = new DateTime(1800, 1, 1).ToShortDateString();
        Accordion masteracc = (Accordion)Master.FindControl("acdnMaster");
        int ind = masteracc.SelectedIndex;
        int inx = Convert.ToInt16(Session["SrNo"]);
        IsActive = true;
        masteracc.SelectedIndex = inx - 1;
        Login obj = new Login();
        obj.Start();
        UserName = obj.LogedInUser;
        LoginUser = obj.LoginUser;
        Ret = obj.Ret;
        if (!Page.IsPostBack)
        {
            DataTable dtS = SActiveDetails(IsActive);
            BindStakeholder(dtS);
            DataTable dtSRM = SRMActiveDetails(IsActive);
            BindSRM(dtSRM);
            DataTable dtWS = WS1StatusDetails();
            BindWS1S(dtWS);
            DataTable dtIFAS = LoadIFAS(LoginUser, Ret);
            BindIFAS(dtIFAS);
            DataTable dtIFC = LoadIFC(LoginUser, Ret);
            BindIFC(dtIFC);
            DataTable dtIFF = LoadIFF(LoginUser, Ret);
            BindIFF(dtIFF);
            DataTable dtIFID = LoadIFI(LoginUser, Ret);
            BindIFID(dtIFID);
            DataTable dtIFRT = LoadIFRT(LoginUser, Ret);
            BindIFRT(dtIFRT);
            DataTable dtIFSpec = LoadIFSpec(LoginUser, Ret);
            BindIFSpec(dtIFSpec);
            DataTable dtIFSR = LoadIFSR(LoginUser, Ret);
            BindIFSR(dtIFSR);
            DataTable dtIFTAD = LoadIFTA(LoginUser, Ret);
            BindIFTAD(dtIFTAD);
            DataTable dtIFTIO = LoadIFTIO(LoginUser, Ret);
            BindIFTIO(dtIFTIO);
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
            DataTable dtCR= LoadCR(LoginUser, Ret);
            BindCR(dtCR);
            DataTable dtCBI = LoadCBI(LoginUser, Ret);
            BindCBI(dtCBI);
            DataTable dtRTK = LoadRTK(LoginUser, Ret);
            BindRTK(dtRTK);
            DataTable dtRTKPMG = LoadRTKPMG(LoginUser, Ret);
            BindRTKPMG(dtRTKPMG);
            if (Session["IntakeFormId"] != null)
            {
                CheckIntakeFormId();
                IntakeFormId = Convert.ToInt32(Session["IntakeFormId"].ToString());
            }
        }                         
        else
        {
            if (Session["IntakeFormId"] != null)
            {
                IntakeFormId = Convert.ToInt32(Session["IntakeFormId"].ToString());
            }

        }
    }

    /// <summary>
    /// To show specific IntakeForm Details
    /// </summary>
    protected void CheckIntakeFormId()
    {
        IntakeFormId = Convert.ToInt32(Session["IntakeFormId"].ToString());
        DataTable DtSelectId = GetIntakeFormDetails(IntakeFormId);
        if (btnSave.Text == "Save")
        {
            if (DtSelectId.Rows.Count > 0)
            {
                lblIntakeId.Text = DtSelectId.Rows[0][0].ToString();
                lblWs1Phase.Text = DtSelectId.Rows[0][2].ToString();
                ddlWSStatus.SelectedValue = DtSelectId.Rows[0][3].ToString();
                ddlSRM.SelectedValue = DtSelectId.Rows[0][5].ToString();
                txtDesicionMaker.Text = DtSelectId.Rows[0][7].ToString();      
                txtOrigin_MeetingDate.Text = DtSelectId.Rows[0][8].ToString();                    
                txtTrainingNeedName.Text = DtSelectId.Rows[0][9].ToString();
                txtBackgroundInformation.Text = DtSelectId.Rows[0][10].ToString();
                txtProblemStatement.Text = DtSelectId.Rows[0][11].ToString();
                txtBusinessReasonsAndDrivers.Text = DtSelectId.Rows[0][12].ToString();
                txtStakeholderPerceptionOfPriority.Text = DtSelectId.Rows[0][13].ToString();
                txtRequestedSolution.Text = DtSelectId.Rows[0][14].ToString();
                txtRequestedTrainingImplementationDate.Text = DtSelectId.Rows[0][15].ToString();
                txtRequestedTrainingCompletationDate.Text = DtSelectId.Rows[0][16].ToString();
                txtCommentsOnRequestedTimeline.Text = DtSelectId.Rows[0][16].ToString();
                string ReviewCourseOutlines = DtSelectId.Rows[0][18].ToString();
                if (ReviewCourseOutlines == "True")
                {
                    chkReviewCourseOutlines.Checked = true;
                }
                else if (ReviewCourseOutlines == "False")
                {
                    chkReviewCourseOutlines.Checked = false;
                }
                txtCurrentBusinessAndPerformanceState.Text = DtSelectId.Rows[0][19].ToString();
                txtDesiredBusinessAndPerformanceOutcomes.Text = DtSelectId.Rows[0][20].ToString();
                txtCauseOfGap.Text = DtSelectId.Rows[0][21].ToString();
                txtSummarizeGapAssessment.Text = DtSelectId.Rows[0][22].ToString();
                txtDescriptionOfTheTopics.Text = DtSelectId.Rows[0][23].ToString();
                txtImpactedBusinessGoal.Text = DtSelectId.Rows[0][24].ToString();
                txtSummaryofImpactonALDcurriculumALDFirmresources.Text = DtSelectId.Rows[0][25].ToString();
                txtOtherComments.Text = DtSelectId.Rows[0][26].ToString();
                txtProposedDateofTrainingImplementation.Text = DtSelectId.Rows[0][27].ToString();
                txtProposedDateofTrainingCompletion.Text = DtSelectId.Rows[0][28].ToString();
                txtCommentsOnRequestedTimeline.Text = DtSelectId.Rows[0][29].ToString();
                string WS1PlanValidated = DtSelectId.Rows[0][30].ToString();
                if (WS1PlanValidated == "True")
                {
                    ddlWS1PlanValidated.SelectedIndex = 2;
                }
                else if (WS1PlanValidated == "False")
                {
                    ddlWS1PlanValidated.SelectedIndex = 1;
                    
                }
                txtTargetAudienceDescription.Text = DtSelectId.Rows[0][31].ToString();
                btnSave.Text = "Update";
                DataTable DtStkDetails = GetIntakeFormStakeholderDetails(Convert.ToInt16(lblIntakeId.Text));
                ddlmslStakeholder.SetValue(DtStkDetails);
                DataTable DtTargetAudience = GetIntakeFormTargetAudienceDetails(Convert.ToInt16(lblIntakeId.Text));
                ddlmslTargetAudience.SetValue(DtTargetAudience);
                DataTable DtIndustries = GetIntakeFormIndustriesDetails(Convert.ToInt16(lblIntakeId.Text));
                ddlmslIndustries.SetValue(DtTargetAudience);
                 DataTable DtSpecialities = GetIntakeFormSpecialtiesDetails(Convert.ToInt16(lblIntakeId.Text));
                ddlmslSpecialities.SetValue(DtSpecialities);
                DataTable DtFunction= GetIntakeFormFunctionDetails(Convert.ToInt16(lblIntakeId.Text));
                ddlmslFunctions.SetValue(DtSpecialities);
                DataTable DtReviewerType = GetReviewerTypeDetails(Convert.ToInt16(lblIntakeId.Text));
                ddlmslRecomendedReviewerTypes.SetValue(DtReviewerType);
                DataTable DtTrainingImpactOn = GetTrainingImpactOnDetails(Convert.ToInt16(lblIntakeId.Text));
                ddlmslImpactOnTraining.SetValue(DtTrainingImpactOn);
                DataTable DtAnalyzeSolution = GetIntakeFormAnalyzeSolutionDetails(Convert.ToInt16(lblIntakeId.Text));
                ddlmslAnalyzeSolution.SetValue(DtAnalyzeSolution);
                DataTable DtCurriculumDetails = GetCurriculumDetails(Convert.ToInt16(lblIntakeId.Text));
                 ddlmlttarget_cur_keyword.SetValue(DtTrainingImpactOn);
            }
        }
    }

    /// <summary>
    /// To get details of particular Intake Form ID
    /// </summary>
    /// <param name="IntFmId"></param>
    /// <returns></returns>
    private DataTable GetIntakeFormDetails(int IntFmId)
    {
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        DataTable DtIntakeDet = new DataTable();
        try
        {
            DtIntakeDet = IntakeFormBAL.SelectIntakeFormId(IntFmId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
           IntakeFormBAL = null;
        }

        return DtIntakeDet;
    }

    /// <summary>
    /// To get details of particular Intake Form ID Stakeholder Details
    /// </summary>
    /// <param name="IntFmId"></param>
    /// <returns></returns>
    private DataTable GetIntakeFormStakeholderDetails(int IntFmId)
    {
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        DataTable DtStkholderDet = new DataTable();
        try
        {
            DtStkholderDet = IntakeFormBAL.SelectStakeholderDetails(IntFmId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            IntakeFormBAL = null;
        }

        return DtStkholderDet;
    }

    /// <summary>
    /// To get details of particular Intake Form ID Stakeholder Details
    /// </summary>
    /// <param name="IntFmId"></param>
    /// <returns></returns>
    private DataTable GetIntakeFormTargetAudienceDetails(int IntFmId)
    {
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        DataTable DtStkholderDet = new DataTable();
        try
        {
            DtStkholderDet = IntakeFormBAL.SelectTargetAudienceDetails(IntFmId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            IntakeFormBAL = null;
        }

        return DtStkholderDet;
    }
    

     /// <summary>
    /// To get details of particular Intake Form ID Stakeholder Details
    /// </summary>
    /// <param name="IntFmId"></param>
    /// <returns></returns>
    private DataTable GetIntakeFormIndustriesDetails(int IntFmId)
    {
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        DataTable DtStkholderDet = new DataTable();
        try
        {
            DtStkholderDet = IntakeFormBAL.SelectIndustriesDetails(IntFmId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            IntakeFormBAL = null;
        }

        return DtStkholderDet;
    }

      /// <summary>
    /// To get details of particular Intake Form ID Stakeholder Details
    /// </summary>
    /// <param name="IntFmId"></param>
    /// <returns></returns>
    private DataTable GetIntakeFormSpecialtiesDetails(int IntFmId)
    {
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        DataTable DtStkholderDet = new DataTable();
        try
        {
            DtStkholderDet = IntakeFormBAL.SelectSpecialtiesDetails(IntFmId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            IntakeFormBAL = null;
        }

        return DtStkholderDet;
    }

        /// <summary>
    /// To get details of particular Intake Form ID Stakeholder Details
    /// </summary>
    /// <param name="IntFmId"></param>
    /// <returns></returns>
    private DataTable GetIntakeFormFunctionDetails(int IntFmId)
    {
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        DataTable DtStkholderDet = new DataTable();
        try
        {
            DtStkholderDet = IntakeFormBAL.SelectFunctionDetails(IntFmId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            IntakeFormBAL = null;
        }

        return DtStkholderDet;
    }

         /// <summary>
    /// To get details of particular Intake Form ID Stakeholder Details
    /// </summary>
    /// <param name="IntFmId"></param>
    /// <returns></returns>
    private DataTable GetReviewerTypeDetails(int IntFmId)
    {
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        DataTable DtStkholderDet = new DataTable();
        try
        {
            DtStkholderDet = IntakeFormBAL.SelectIntakeFormReviewerTypeDetails(IntFmId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            IntakeFormBAL = null;
        }

        return DtStkholderDet;
    }

          /// <summary>
    /// To get details of particular Intake Form ID Stakeholder Details
    /// </summary>
    /// <param name="IntFmId"></param>
    /// <returns></returns>
    private DataTable GetTrainingImpactOnDetails(int IntFmId)
    {
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        DataTable DtStkholderDet = new DataTable();
        try
        {
            DtStkholderDet = IntakeFormBAL.SelectTrainingImpactOnDetails(IntFmId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            IntakeFormBAL = null;
        }

        return DtStkholderDet;
    }


    /// <summary>
    /// To get details of particular Intake Form ID Stakeholder Details
    /// </summary>
    /// <param name="IntFmId"></param>
    /// <returns></returns>
    private DataTable GetIntakeFormAnalyzeSolutionDetails(int IntFmId)
    {
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        DataTable DtStkholderDet = new DataTable();
        try
        {
            DtStkholderDet = IntakeFormBAL.SelectAnalyzeSolutionDetails(IntFmId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            IntakeFormBAL = null;
        }

        return DtStkholderDet;
    }


    /// <summary>
    /// To get details of particular Intake Form ID Stakeholder Details
    /// </summary>
    /// <param name="IntFmId"></param>
    /// <returns></returns>
    private DataTable GetCurriculumDetails(int IntFmId)
    {
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        DataTable DtStkholderDet = new DataTable();
        try
        {
            DtStkholderDet = IntakeFormBAL.SelectCurriculumDetails(IntFmId, LoginUser, Ret);
        }
        catch
        {

        }
        finally
        {
            IntakeFormBAL = null;
        }

        return DtStkholderDet;
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

    public void BindStakeholder(DataTable dtSta)
    {
        if (dtSta.Rows.Count > 0)
        {

            ddlmslStakeholder.ChkBind(dtSta, "StakeholderId", "Name");

        }
        else
        {
            ddlmslStakeholder.ChkBind(dtSta, "StakeholderId", "Name");
        }
    }

    protected DataTable SActiveDetails(bool IsActive)
    {
        StakeHolderBAL sBAL = new StakeHolderBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = sBAL.LoadActiveStakeholder(LoginUser, Ret, IsActive);
        }
        catch
        {
            throw;
        }
        finally
        {
            sBAL = null;
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

    protected DataTable WS1StatusDetails()
    {
        WS1StatusBAL WSBAL = new WS1StatusBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = WSBAL.LoadWS1Status(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            WSBAL = null;
        }

        return dTable;
    }

    public void BindWS1S(DataTable dtWSsta)
    {
        if (dtWSsta.Rows.Count > 0)
        {
            ddlWSStatus.DataSource = dtWSsta;
            ddlWSStatus.DataTextField = "WS1Status";
            ddlWSStatus.DataValueField = "WS1StatusID";
            ddlWSStatus.DataBind();
            ddlWSStatus.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
        }
        else
        {
            ddlWSStatus.DataSource = null;
            ddlWSStatus.DataTextField = "WS1Status";
            ddlWSStatus.DataValueField = "WS1StatusID";
            ddlWSStatus.DataBind();
            ddlWSStatus.Items.Insert(0, new ListItem("<< Select >>", "<< Select >>"));
            ddlWSStatus.SelectedIndex = 0;
        }
    }

    protected DataTable WS1PhaseDetails()
    {
        WS1PhaseBAL WSpBAL = new WS1PhaseBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = WSpBAL.LoadWS1Phase(LoginUser, Ret);
        }
        catch (Exception ee)
        {
            throw;
        }
        finally
        {
            WSpBAL = null;
        }

        return dTable;
    }

    //protected DataTable IFASDetails()
    //{
    //    IFAnalyzeSolutionBAL IFASBAL = new IFAnalyzeSolutionBAL();
    //    DataTable dTable = new DataTable();
    //    try
    //    {
    //        dTable = IFASBAL.LoadIFAS(LoginUser, Ret);
    //    }
    //    catch (Exception ee)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        IFASBAL = null;
    //    }

    //    return dTable;
    //}
    public void BindIFAS(DataTable dtIFas)
    {
        if (dtIFas.Rows.Count > 0)
        {
            ddlmslAnalyzeSolution.ChkBind(dtIFas, "AnalyzeSolutionId", "AnalyzeSolution");          
        }
        else
        {
            ddlmslAnalyzeSolution.ChkBind(dtIFas, "AnalyzeSolutionId", "AnalyzeSolution"); 
        }
    }
    //protected DataTable IFCDetails()
    //{
    //    IFCurriculumBAL IFCBAL = new IFCurriculumBAL();
    //    DataTable dTable = new DataTable();
    //    try
    //    {
    //        dTable = IFCBAL.LoadIFC(LoginUser, Ret);
    //    }
    //    catch (Exception ee)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        IFCBAL = null;
    //    }

    //    return dTable;
    //}
    public void BindIFC(DataTable dtIFc)
    {
        if (dtIFc.Rows.Count > 0)
        {
            ddlmlttarget_cur_keyword.ChkBind(dtIFc, "CurriculumId", "Curriculum");
        }
        else
        {
            ddlmlttarget_cur_keyword.ChkBind(dtIFc, "CurriculumId", "Curriculum");
        }
    }
    //  Bind Applicable to Other Functions to Dropdown list
    //protected DataTable IFFDetails()
    //{
    //    IFFunctionsBAL IFFBAL = new IFFunctionsBAL();
    //    DataTable dTable = new DataTable();
    //    try
    //    {
    //        dTable = IFFBAL.LoadIFF(LoginUser, Ret);
    //    }
    //    catch (Exception ee)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        IFFBAL = null;
    //    }

    //    return dTable;
    //}
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
   
    public void BindIFRT(DataTable dtIFrt)
    {
        if (dtIFrt.Rows.Count > 0)
        {
            ddlmslRecomendedReviewerTypes.ChkBind(dtIFrt, "ReviewerTypeId", "ReviewerType");
        }
        else
        {
            ddlmslRecomendedReviewerTypes.ChkBind(dtIFrt, "ReviewerTypeId", "ReviewerType");
        }
    }
    protected DataTable IFSpecDetails()
    {
        SpecialitiesBAL IFSpecBAL = new SpecialitiesBAL();
        DataTable dTable = new DataTable();
        try
        {
            dTable = IFSpecBAL.LoadSpecialities(LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {
            IFSpecBAL = null;
        }

        return dTable;
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
   
    public void BindIFSR(DataTable dtIFSr)
    {
        if (dtIFSr.Rows.Count > 0)
        {
            ddlmslResStakCanPotProvide.ChkBind(dtIFSr, "StakeholderResourcesID", "StakeholderResources");           
        }
        else
        {
            ddlmslResStakCanPotProvide.ChkBind(dtIFSr, "StakeholderResourcesID", "StakeholderResources");                    
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

 
    public void BindIFTIO(DataTable dtIFtio)
    {
        if (dtIFtio.Rows.Count > 0)
        {
            ddlmslImpactOnTraining.ChkBind(dtIFtio, "TrainingImpactOnId", "TrainingImpactOn");        
        }
        else
        {
            ddlmslImpactOnTraining.ChkBind(dtIFtio, "TrainingImpactOnId", "TrainingImpactOn");       
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("IntakeList.aspx", false);
    }


    public DataTable LoadIFAS(int LoggedInUser, string returnmsg)
    {
        SqlConnection conn = new SqlConnection(connStr);
        SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.AnalyzeSolution", conn);
        dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet dSet = new DataSet();
        try
        {
            dAd.Fill(dSet, "AnalyzeSolution");
            return dSet.Tables["AnalyzeSolution"];
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


    public DataTable LoadIFTIO(int LoggedInUser, string returnmsg)
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter dAd = new SqlDataAdapter("Select * from Masters.TrainingImpactOn", conn);
            dAd.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
            dAd.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "TrainingImpactOn");
                return dSet.Tables["TrainingImpactOn"];
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
                 ddlAlignmentWithKBSAStrategy.DataSource = dtali;
                 ddlAlignmentWithKBSAStrategy.DataTextField = "AlignmentWithKBSAStrategy";
                 ddlAlignmentWithKBSAStrategy.DataValueField = "StrategyValue";
                 ddlAlignmentWithKBSAStrategy.DataBind();
                 ddlAlignmentWithKBSAStrategy.Items.Insert(0, new ListItem("<< Select >>", "0"));
             }
             else
             {
                 ddlAlignmentWithKBSAStrategy.DataSource = null;
                 ddlAlignmentWithKBSAStrategy.DataTextField = "AlignmentWithKBSAStrategy";
                 ddlAlignmentWithKBSAStrategy.DataValueField = "StrategyValue";
                 ddlAlignmentWithKBSAStrategy.DataBind();
                 ddlAlignmentWithKBSAStrategy.Items.Insert(0, new ListItem("<< Select >>", "0"));
                 ddlAlignmentWithKBSAStrategy.SelectedIndex = 0;
             }

         }

    public void BindALIKPMG(DataTable dtali)
    {
        if (dtali.Rows.Count > 0)
        {
            ddlAlignmentWithKPMGStrategy.DataSource = dtali;
            ddlAlignmentWithKPMGStrategy.DataTextField = "AlignmentWithKPMGStrategy";
            ddlAlignmentWithKPMGStrategy.DataValueField = "StrategyValue";
            ddlAlignmentWithKPMGStrategy.DataBind();
            ddlAlignmentWithKPMGStrategy.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlAlignmentWithKPMGStrategy.DataSource = null;
            ddlAlignmentWithKPMGStrategy.DataTextField = "AlignmentWithKPMGStrategy";
            ddlAlignmentWithKPMGStrategy.DataValueField = "StrategyValue";
            ddlAlignmentWithKPMGStrategy.DataBind();
            ddlAlignmentWithKPMGStrategy.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlAlignmentWithKPMGStrategy.SelectedIndex = 0;
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
            ddlBusinessImpactOnPeople.DataSource = dtali;
            ddlBusinessImpactOnPeople.DataTextField = "BusinessImpactOnPeople";
            ddlBusinessImpactOnPeople.DataValueField = "BusinessImpactValue";
            ddlBusinessImpactOnPeople.DataBind();
            ddlBusinessImpactOnPeople.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlBusinessImpactOnPeople.DataSource = null;
            ddlBusinessImpactOnPeople.DataTextField = "BusinessImpactOnPeople";
            ddlBusinessImpactOnPeople.DataValueField = "BusinessImpactValue";
            ddlBusinessImpactOnPeople.DataBind();
            ddlBusinessImpactOnPeople.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlBusinessImpactOnPeople.SelectedIndex = 0;
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
            ddlBusinessImpactOnBottomLine.DataSource = dtali;
            ddlBusinessImpactOnBottomLine.DataTextField = "BusinessImpactOnBottomLine";
            ddlBusinessImpactOnBottomLine.DataValueField = "Value";
            ddlBusinessImpactOnBottomLine.DataBind();
            ddlBusinessImpactOnBottomLine.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlBusinessImpactOnBottomLine.DataSource = null;
            ddlBusinessImpactOnBottomLine.DataTextField = "BusinessImpactOnBottomLine";
            ddlBusinessImpactOnBottomLine.DataValueField = "Value";
            ddlBusinessImpactOnBottomLine.DataBind();
            ddlBusinessImpactOnBottomLine.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlBusinessImpactOnBottomLine.SelectedIndex = 0;
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
            ddlBusinessImpactOnProcess.DataSource = dtali;
            ddlBusinessImpactOnProcess.DataTextField = "BusinessImpactOnProcess";
            ddlBusinessImpactOnProcess.DataValueField = "Value";
            ddlBusinessImpactOnProcess.DataBind();
            ddlBusinessImpactOnProcess.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlBusinessImpactOnProcess.DataSource = null;
            ddlBusinessImpactOnProcess.DataTextField = "BusinessImpactOnProcess";
            ddlBusinessImpactOnProcess.DataValueField = "Value";
            ddlBusinessImpactOnProcess.DataBind();
            ddlBusinessImpactOnProcess.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlBusinessImpactOnProcess.SelectedIndex = 0;
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
            ddlCostBudgetImpact.DataSource = dtali;
            ddlCostBudgetImpact.DataTextField = "CostBudgetImpact";
            ddlCostBudgetImpact.DataValueField = "Value";
            ddlCostBudgetImpact.DataBind();
            ddlCostBudgetImpact.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlCostBudgetImpact.DataSource = null;
            ddlCostBudgetImpact.DataTextField = "CostBudgetImpact";
            ddlCostBudgetImpact.DataValueField = "Value";
            ddlCostBudgetImpact.DataBind();
            ddlCostBudgetImpact.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlCostBudgetImpact.SelectedIndex = 0;
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
            ddlCostReasonableness.DataSource = dtali;
            ddlCostReasonableness.DataTextField = "CostReasonableness";
            ddlCostReasonableness.DataValueField = "Value";
            ddlCostReasonableness.DataBind();
            ddlCostReasonableness.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlCostReasonableness.DataSource = null;
            ddlCostReasonableness.DataTextField = "CostReasonableness";
            ddlCostReasonableness.DataValueField = "Value";
            ddlCostReasonableness.DataBind();
            ddlCostReasonableness.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlCostReasonableness.SelectedIndex = 0;
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
            ddlRiskToKPMG.DataSource = dtali;
            ddlRiskToKPMG.DataTextField = "RiskToKBSA";
            ddlRiskToKPMG.DataValueField = "Value";
            ddlRiskToKPMG.DataBind();
            ddlRiskToKPMG.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlRiskToKPMG.DataSource = null;
            ddlRiskToKPMG.DataTextField = "RiskToKBSA";
            ddlRiskToKPMG.DataValueField = "Value";
            ddlRiskToKPMG.DataBind();
            ddlRiskToKPMG.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlRiskToKPMG.SelectedIndex = 0;
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
            ddlRiskToKBSA.DataSource = dtali;
            ddlRiskToKBSA.DataTextField = "RiskToKPMG";
            ddlRiskToKBSA.DataValueField = "Value";
            ddlRiskToKBSA.DataBind();
            ddlRiskToKBSA.Items.Insert(0, new ListItem("<< Select >>", "0"));
        }
        else
        {
            ddlRiskToKBSA.DataSource = null;
            ddlRiskToKBSA.DataTextField = "RiskToKPMG";
            ddlRiskToKBSA.DataValueField = "Value";
            ddlRiskToKBSA.DataBind();
            ddlRiskToKBSA.Items.Insert(0, new ListItem("<< Select >>", "0"));
            ddlRiskToKBSA.SelectedIndex = 0;
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
    protected void ddlRiskToKBSA_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
  
    protected void ddlAlignmentWithKBSAStrategy_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }

    public void Cal()
    {
        int d1 = Convert.ToInt32(ddlAlignmentWithKPMGStrategy.SelectedValue);
        int d2 = Convert.ToInt32(ddlAlignmentWithKBSAStrategy.SelectedValue);
        int d3 = Convert.ToInt32(ddlBusinessImpactOnProcess.SelectedValue);
        int d4 = Convert.ToInt32(ddlBusinessImpactOnPeople.SelectedValue);
        int d5 = Convert.ToInt32(ddlBusinessImpactOnBottomLine.SelectedValue);
        int d6 = Convert.ToInt32(ddlCostBudgetImpact.SelectedValue);
        int d7 = Convert.ToInt32(ddlCostReasonableness.SelectedValue);
        int d8 = Convert.ToInt32(ddlRiskToKPMG.SelectedValue);
        int d9 = Convert.ToInt32(ddlRiskToKBSA.SelectedValue);
        int test = d1 + d2 + d3 + d4 + d5 + d6 + d7 + d8 + d9;
        int test1 = d1 * d2 * d3 * d4 * d5 * d6 * d7 * d8 * d9;
        txtWS2PrioritizationScore.Text = test.ToString();
        txtWS2PrioritizationFlag.Text = test1.ToString();
        int t1 = Convert.ToInt32(txtWS2PrioritizationFlag.Text);
        if (t1 == 0)
        {
            lblWS2FO.Text = "Training need doesn't meet citeria to develop training";          
        }
        else
        {
            lblWS2FO.Text = "Okay to proceed";     
        }

        int t2 = Convert.ToInt32(txtWS2PrioritizationScore.Text);
        if (t2 < 6)
        {
            lblWS2ConditionalPriorityTiers.Text = "Killer variable or missed question";
            lblWS2ConditionalPriorityTiers.Font.Bold = true;
            lblWS2ConditionalPriorityTiers.Font.Size = 14;
        }
        else if ( t2 >= 6 & t2 <= 12)
        {
            lblWS2ConditionalPriorityTiers.Text = "Low Priority Tier";
            lblWS2ConditionalPriorityTiers.Font.Bold = true;
            lblWS2ConditionalPriorityTiers.Font.Size = 14;
        }
        else if (t2 >= 12 & t2 <= 22)
        {
            lblWS2ConditionalPriorityTiers.Text = "Mid Priority Tier  ";
            lblWS2ConditionalPriorityTiers.Font.Bold = true;
            lblWS2ConditionalPriorityTiers.Font.Size = 14;        
        }
        else if (t2 >= 22)
        {
            lblWS2ConditionalPriorityTiers.Text = " High Priority Tier";
            lblWS2ConditionalPriorityTiers.Font.Bold = true;
            lblWS2ConditionalPriorityTiers.Font.Size = 14;  
        }
    }
    protected void ddlAlignmentWithKPMGStrategy_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlBusinessImpactOnProcess_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlBusinessImpactOnPeople_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlBusinessImpactOnBottomLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlCostBudgetImpact_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlCostReasonableness_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }
    protected void ddlRiskToKPMG_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cal();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        int Result;
        int WS1PhaseId,
            WS1StatusId,
            StakeholderRelationshipManagerId,
            ReviewCourseOutlines,
            WS1PlanValidated,
            AlignmentWithKBSAStrategyId,
            AlignmentWithKPMGStrategyId,
            BusinessImpactOnProcessId,
            BusinessImpactOnPeopleId,
            BusinessImpactOnBottomLineId,
            CostBudgetImpactId,
            CostReasonablenessId,
            RiskToKPMGId,
            RiskToKBSAId,
            WS2PrioritizationFlag,
            WS2PrioritizationScore,
            WS2FlagOutput;
        string DecisionMaker,
            TrainingNeedName,
            BackgroundInformation,
            ProblemStatement,
            BusinessReasonsAndDrivers,
            StakeholderPerceptionOfPriority,
            RequestedSolution,
            CommentsOnRequestedTimeline,
            TargetAudienceDescription,
            CurrentBusinessAndPerformanceState,
            DesiredBusinessAndPerformanceOutcomes,
            CauseOfGap,
            SummarizeGapAssessment,
            AnalyzeSolutionDescription,
            DescriptionOfTheTopics,
            ImpactedBusinessGoal,
            SummaryofImpactonALDcurriculumALDFirmresources,
            OtherComments,
            CommentsonProposedTimeline,
            WS2ConditionalPriorityTiers;
        DateTime Origin_MeetingDate,
            ProposedDateofTrainingImplementation,
            ProposedDateofTrainingCompletion,
            RequestedTrainingCompletationDate,
            RequestedTrainingImplementationDate;
        // fields with multivalue
        string IntakeFormStakeholderID,
            TargetAudienceByLevel,
            Industries,
            Specialites,
            ApplicableToOtherFunctions,
            ResourcesStakeholderCanPotentiallyProvide,
            RecomendedReviewerTypes,
            SignificantImpactOnTraining,
            AnalyzeSolution,
            CurriculumKeywords;
        WS1PhaseId = 1;
        WS1StatusId = Convert.ToInt32(ddlWSStatus.SelectedValue);
        StakeholderRelationshipManagerId = Convert.ToInt32(ddlSRM.SelectedValue);
        DecisionMaker = txtDesicionMaker.Text;
        Origin_MeetingDate = Convert.ToDateTime(txtOrigin_MeetingDate.Text);
        TrainingNeedName = txtTrainingNeedName.Text;
        BackgroundInformation = txtBackgroundInformation.Text;
        ProblemStatement = txtProblemStatement.Text;
        BusinessReasonsAndDrivers = txtBusinessReasonsAndDrivers.Text;
        StakeholderPerceptionOfPriority = txtStakeholderPerceptionOfPriority.Text;
        RequestedSolution = txtRequestedSolution.Text;
        RequestedTrainingImplementationDate = Convert.ToDateTime(txtRequestedTrainingImplementationDate.Text);
        RequestedTrainingCompletationDate = Convert.ToDateTime(txtRequestedTrainingCompletationDate.Text);
        CommentsOnRequestedTimeline = txtCommentsOnRequestedTimeline.Text;
        TargetAudienceDescription = txtTargetAudienceDescription.Text;
        ReviewCourseOutlines = 0;
        CurrentBusinessAndPerformanceState = txtCurrentBusinessAndPerformanceState.Text;
        DesiredBusinessAndPerformanceOutcomes = txtDesiredBusinessAndPerformanceOutcomes.Text;
        CauseOfGap = txtCauseOfGap.Text;
        SummarizeGapAssessment = txtSummarizeGapAssessment.Text;
        AnalyzeSolutionDescription = txtAnalyzeSolutionDescription.Text;
        DescriptionOfTheTopics = txtDescriptionOfTheTopics.Text;
        ImpactedBusinessGoal = txtImpactedBusinessGoal.Text;
        SummaryofImpactonALDcurriculumALDFirmresources = txtSummaryofImpactonALDcurriculumALDFirmresources.Text;
        OtherComments = txtOtherComments.Text;
        ProposedDateofTrainingImplementation = Convert.ToDateTime(txtProposedDateofTrainingImplementation.Text);
        ProposedDateofTrainingCompletion = Convert.ToDateTime(txtProposedDateofTrainingCompletion.Text);
        CommentsonProposedTimeline = txtCommentsonProposedTimeline.Text;
        WS1PlanValidated = Convert.ToInt32(ddlWS1PlanValidated.SelectedValue);
        AlignmentWithKBSAStrategyId = Convert.ToInt32(ddlAlignmentWithKBSAStrategy.SelectedValue);
        AlignmentWithKPMGStrategyId = Convert.ToInt32(ddlAlignmentWithKPMGStrategy.SelectedValue);
        BusinessImpactOnProcessId = Convert.ToInt32(ddlBusinessImpactOnProcess.SelectedValue);
        BusinessImpactOnPeopleId = Convert.ToInt32(ddlBusinessImpactOnPeople.SelectedValue);
        BusinessImpactOnBottomLineId = Convert.ToInt32(ddlBusinessImpactOnBottomLine.SelectedValue);
        CostBudgetImpactId = Convert.ToInt32(ddlCostBudgetImpact.SelectedValue);
        CostReasonablenessId = Convert.ToInt32(ddlCostReasonableness.SelectedValue);
        RiskToKPMGId = Convert.ToInt32(ddlRiskToKPMG.SelectedValue);
        RiskToKBSAId = Convert.ToInt32(ddlRiskToKBSA.SelectedValue);
        WS2PrioritizationFlag = 1;
        WS2PrioritizationScore = 2;
        WS2FlagOutput = 1;
        WS2ConditionalPriorityTiers = lblWS2ConditionalPriorityTiers.Text;
        IntakeFormBAL IntakeFormBAL = new IntakeFormBAL();
        IntakeFormStakeholderID = GetStakeholderXml();
        TargetAudienceByLevel = GetTargetAudienceByLevelXml();
        Industries = GetIndustriesXml();
        Specialites = GetSpecialitesXml();
        ApplicableToOtherFunctions = GetApplicableToOtherFunctionsXml();
        ResourcesStakeholderCanPotentiallyProvide = GetResourcesStakeholderCanPotentiallyProvideXml();
        RecomendedReviewerTypes = GetRecomendedReviewerTypesXml();
        SignificantImpactOnTraining = GetSignificantImpactOnTrainingXml();
        AnalyzeSolution = GetAnalyzeSolutionXml();
        CurriculumKeywords = GetCurriculumKeywordsXml();
        if (chkReviewCourseOutlines.Checked == true)
        {
            ReviewCourseOutlines = 1;
        }
        else if (chkReviewCourseOutlines.Checked == false)
        {
            ReviewCourseOutlines = 0;
        }
                 
            Result = IntakeFormBAL.InsertIntakeForm(WS1PhaseId, WS1StatusId, StakeholderRelationshipManagerId,
                IntakeFormStakeholderID, DecisionMaker, Origin_MeetingDate,
                TrainingNeedName, BackgroundInformation, ProblemStatement, BusinessReasonsAndDrivers,
                StakeholderPerceptionOfPriority, RequestedSolution, RequestedTrainingImplementationDate,
                RequestedTrainingCompletationDate, CommentsOnRequestedTimeline, TargetAudienceByLevel, Industries,
                Specialites, ApplicableToOtherFunctions, TargetAudienceDescription,
                ResourcesStakeholderCanPotentiallyProvide, ReviewCourseOutlines, RecomendedReviewerTypes,
                CurrentBusinessAndPerformanceState, SignificantImpactOnTraining,
                DesiredBusinessAndPerformanceOutcomes, CauseOfGap, SummarizeGapAssessment, AnalyzeSolution,
                AnalyzeSolutionDescription, CurriculumKeywords, DescriptionOfTheTopics,
                ImpactedBusinessGoal, SummaryofImpactonALDcurriculumALDFirmresources, OtherComments,
                ProposedDateofTrainingImplementation, ProposedDateofTrainingCompletion,
                CommentsonProposedTimeline, WS1PlanValidated, AlignmentWithKBSAStrategyId, AlignmentWithKPMGStrategyId,
                BusinessImpactOnProcessId, BusinessImpactOnPeopleId,
                BusinessImpactOnBottomLineId, CostBudgetImpactId, CostReasonablenessId, RiskToKPMGId, RiskToKBSAId,
                WS2PrioritizationFlag, WS2FlagOutput, WS2PrioritizationScore,
                WS2ConditionalPriorityTiers, LoginUser, Ret);
       
        
    }


    protected string GetTargetAudienceByLevelXml()
    {
        DataTable DtTargetAudience = ddlmslTargetAudience.GetTable("TargetAudienceID", "Name");
        DynamicXml DynXml=new DynamicXml();
        string RetXml = DynXml.GetXml(DtTargetAudience, "NAME", "TARGETAUDIENCEID", "TargetAudience.xml");       
        return RetXml;       
    }


    protected string GetStakeholderXml()
    {
        DataTable DtStakeholder = ddlmslStakeholder.GetTable("StakeholderId", "Name");
        DynamicXml DynXml=new DynamicXml();
        string RetXml = DynXml.GetXml(DtStakeholder, "NAME", "STAKEHOLDERID", "Stakeholder.xml");       
        return RetXml;
    }

    protected string GetIndustriesXml()
    {
        DataTable DtIndustries = ddlmslIndustries.GetTable("IndustriesID", "Name");      
        DynamicXml DynXml = new DynamicXml();
        string RetXml = DynXml.GetXml(DtIndustries, "NAME", "INDUSTRIESID", "Industries.xml");
        return RetXml;             
    }

    protected string GetSpecialitesXml()
    {
        DataTable DtIndustries = ddlmslSpecialities.GetTable("SpecialtiesID", "Name");
        DynamicXml DynXml = new DynamicXml();
        string RetXml = DynXml.GetXml(DtIndustries, "NAME", "SPECIALTIESID", "Specialties.xml");
        return RetXml;                                    
    }


    protected string GetResourcesStakeholderCanPotentiallyProvideXml()
    {
        DataTable DtStakeholderResources = ddlmslResStakCanPotProvide.GetTable("StakeholderResourcesID", "Name");
        DynamicXml DynXml = new DynamicXml();
        string RetXml = DynXml.GetXml(DtStakeholderResources, "NAME", "STAKEHOLDERRESOURCESID", "StakeholderResources.xml");
        return RetXml;                                                 
    }

    protected string GetApplicableToOtherFunctionsXml()
    {
        DataTable DtIndustries = ddlmslFunctions.GetTable("FunctionsID", "Name");
        DynamicXml DynXml = new DynamicXml();
        string RetXml = DynXml.GetXml(DtIndustries, "NAME", "FUNCTIONSID", "ApplicableToOtherFunctions.xml");
        return RetXml;         
    }

    protected string GetRecomendedReviewerTypesXml()
    {
        DataTable DtRecomendedReviewerTypes = ddlmslRecomendedReviewerTypes.GetTable("ReviewerTypeId", "Name");
        DynamicXml DynXml = new DynamicXml();
        string RetXml = DynXml.GetXml(DtRecomendedReviewerTypes, "NAME", "REVIEWERTYPEID", "ReviewerType.xml");
        return RetXml;          
    }

    protected string GetSignificantImpactOnTrainingXml()
    {
        DataTable DtSignificantImpactOnTraining = ddlmslImpactOnTraining.GetTable("TrainingImpactOnId", "Name");
        DynamicXml DynXml = new DynamicXml();
        string RetXml = DynXml.GetXml(DtSignificantImpactOnTraining, "NAME", "TRAININGIMPACTONID", "SignificantImpactOnTraining.xml");
        return RetXml;            
    }


    protected string GetAnalyzeSolutionXml()
    {
        DataTable DtAnalyzeSolution = ddlmslAnalyzeSolution.GetTable("AnalyzeSolutionId", "Name");
        DynamicXml DynXml = new DynamicXml();
        string RetXml = DynXml.GetXml(DtAnalyzeSolution, "NAME", "ANALYZESOLUTIONID", "AnalyzeSolution.xml");
        return RetXml;       
    }


    protected string GetCurriculumKeywordsXml()
    {
        DataTable DtCurriculumKeywords = ddlmslAnalyzeSolution.GetTable("CurriculumId", "Name");
        DynamicXml DynXml = new DynamicXml();
        string RetXml = DynXml.GetXml(DtCurriculumKeywords, "NAME", "CURRICULUMID", "CurriculumKeywords.xml");
        return RetXml;       
    }
}
    

    
