using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for IntakeFormDAL
/// </summary>
public class IntakeFormDAL
{
    string ConnStr = ConfigurationManager.ConnectionStrings["LocalConnectionString"].ToString();
    public IntakeFormDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //  To insert 'Intake Form' record in database by stored procedure
    public int InsertIntakeForm(int WS1PhaseId, int WS1StatusId, int StakeholderRelationshipManagerId, string IntakeFormStakeholderID, string DecisionMaker, DateTime Origin_MeetingDate,
        string TrainingNeedName, string BackgroundInformation, string ProblemStatement, string BusinessReasonsAndDrivers, string StakeholderPerceptionOfPriority, string RequestedSolution,
        DateTime RequestedTrainingImplementationDate, DateTime RequestedTrainingCompletationDate, string CommentsOnRequestedTimeline, string TargetAudienceByLevel, string Industries,
        string Specialites, string ApplicableToOtherFunctions, string TargetAudienceDescription, string ResourcesStakeholderCanPotentiallyProvide, int ReviewCourseOutlines,
        string RecomendedReviewerTypes, string CurrentBusinessAndPerformanceState, string SignificantImpactOnTraining, string DesiredBusinessAndPerformanceOutcomes,
        string CauseOfGap, string SummarizeGapAssessment, string AnalyzeSolution, string AnalyzeSolutionDescription, string CurriculumKeywords, string DescriptionOfTheTopics,
        string ImpactedBusinessGoal, string SummaryofImpactonALDcurriculumALDFirmresources, string OtherComments, DateTime ProposedDateofTrainingImplementation,
        DateTime ProposedDateofTrainingCompletion, string CommentsonProposedTimeline, int WS1PlanValidated, int AlignmentWithKBSAStrategyId, int AlignmentWithKPMGStrategyId,
        int BusinessImpactOnProcessId, int BusinessImpactOnPeopleId, int BusinessImpactOnBottomLineId, int CostBudgetImpactId, int CostReasonablenessId, int RiskToKPMGId,
        int RiskToKBSAId, int WS2PrioritizationFlag, int WS2FlagOutput, int WS2PrioritizationScore, string WS2ConditionalPriorityTiers, int LoginUser, string Ret)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        Conn.Open();
        //  'uspInsertIntakeForm' stored procedure is used to insert record in Instructional Designer table
        SqlCommand DCmd = new SqlCommand("uspInsertIntakeForm", Conn);
        DCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            DCmd.Parameters.AddWithValue("@WS1PhaseId", WS1PhaseId);
            DCmd.Parameters.AddWithValue("@WS1StatusId", WS1StatusId);
            DCmd.Parameters.AddWithValue("@StakeholderRelationshipManagerId", StakeholderRelationshipManagerId);
            DCmd.Parameters.AddWithValue("@IntakeFormStakeholderID", IntakeFormStakeholderID);
            DCmd.Parameters.AddWithValue("@DecisionMaker", DecisionMaker);
            DCmd.Parameters.AddWithValue("@Origin_MeetingDate", Origin_MeetingDate.ToString("yyyy-MM-dd HH:mm:ss"));
            DCmd.Parameters.AddWithValue("@TrainingNeedName", TrainingNeedName);
            DCmd.Parameters.AddWithValue("@BackgroundInformation", BackgroundInformation);
            DCmd.Parameters.AddWithValue("@ProblemStatement", ProblemStatement);
            DCmd.Parameters.AddWithValue("@BusinessReasonsAndDrivers", BusinessReasonsAndDrivers);
            DCmd.Parameters.AddWithValue("@StakeholderPerceptionOfPriority", StakeholderPerceptionOfPriority);
            DCmd.Parameters.AddWithValue("@RequestedSolution", RequestedSolution);
            DCmd.Parameters.AddWithValue("@RequestedTrainingImplementationDate", RequestedTrainingImplementationDate.ToString("yyyy-MM-dd HH:mm:ss"));
            DCmd.Parameters.AddWithValue("@RequestedTrainingCompletationDate", RequestedTrainingCompletationDate.ToString("yyyy-MM-dd HH:mm:ss"));
            DCmd.Parameters.AddWithValue("@CommentsOnRequestedTimeline", CommentsOnRequestedTimeline);
            DCmd.Parameters.AddWithValue("@TargetAudienceByLevel", TargetAudienceByLevel);
            DCmd.Parameters.AddWithValue("@Industries", Industries);
            DCmd.Parameters.AddWithValue("@Specialties", Specialites);
            DCmd.Parameters.AddWithValue("@ApplicableToOtherFunctions", ApplicableToOtherFunctions);
            DCmd.Parameters.AddWithValue("@TargetAudienceDescription", TargetAudienceDescription);
            DCmd.Parameters.AddWithValue("@ResourcesStakeholderCanPotentiallyProvide", ResourcesStakeholderCanPotentiallyProvide);
            DCmd.Parameters.AddWithValue("@ReviewCourseOutlines", ReviewCourseOutlines);
            DCmd.Parameters.AddWithValue("@RecomendedReviewerTypes", RecomendedReviewerTypes);
            DCmd.Parameters.AddWithValue("@CurrentBusinessAndPerformanceState", CurrentBusinessAndPerformanceState);
            DCmd.Parameters.AddWithValue("@SignificantImpactOnTraining", SignificantImpactOnTraining);
            DCmd.Parameters.AddWithValue("@DesiredBusinessAndPerformanceOutcomes", DesiredBusinessAndPerformanceOutcomes);
            DCmd.Parameters.AddWithValue("@CauseOfGap", CauseOfGap);
            DCmd.Parameters.AddWithValue("@SummarizeGapAssessment", SummarizeGapAssessment);
            DCmd.Parameters.AddWithValue("@AnalyzeSolution", AnalyzeSolution);
            DCmd.Parameters.AddWithValue("@AnalyzeSolutionDescription", AnalyzeSolutionDescription);
            DCmd.Parameters.AddWithValue("@CurriculumKeywords", CurriculumKeywords);
            DCmd.Parameters.AddWithValue("@DescriptionOfTheTopics", DescriptionOfTheTopics);
            DCmd.Parameters.AddWithValue("@ImpactedBusinessGoal", ImpactedBusinessGoal);
            DCmd.Parameters.AddWithValue("@SummaryofImpactonALDcurriculumALDFirmresources", SummaryofImpactonALDcurriculumALDFirmresources);
            DCmd.Parameters.AddWithValue("@OtherComments", OtherComments);
            DCmd.Parameters.AddWithValue("@ProposedDateofTrainingImplementation", ProposedDateofTrainingImplementation.ToString("yyyy-MM-dd HH:mm:ss"));
            DCmd.Parameters.AddWithValue("@ProposedDateofTrainingCompletion", ProposedDateofTrainingCompletion.ToString("yyyy-MM-dd HH:mm:ss"));
            DCmd.Parameters.AddWithValue("@CommentsonProposedTimeline", CommentsonProposedTimeline);
            DCmd.Parameters.AddWithValue("@WS1PlanValidated", WS1PlanValidated);
            DCmd.Parameters.AddWithValue("@AlignmentWithKBSAStrategyId", AlignmentWithKBSAStrategyId);
            DCmd.Parameters.AddWithValue("@AlignmentWithKPMGStrategyId", AlignmentWithKPMGStrategyId);
            DCmd.Parameters.AddWithValue("@BusinessImpactOnProcessId", BusinessImpactOnProcessId);
            DCmd.Parameters.AddWithValue("@BusinessImpactOnPeopleId", BusinessImpactOnPeopleId);
            DCmd.Parameters.AddWithValue("@BusinessImpactOnBottomLineId", BusinessImpactOnBottomLineId);
            DCmd.Parameters.AddWithValue("@CostBudgetImpactId", CostBudgetImpactId);
            DCmd.Parameters.AddWithValue("@CostReasonablenessId", CostReasonablenessId);
            DCmd.Parameters.AddWithValue("@RiskToKPMGId", RiskToKPMGId);
            DCmd.Parameters.AddWithValue("@RiskToKBSAId", RiskToKBSAId);
            DCmd.Parameters.AddWithValue("@WS2PrioritizationFlag", WS2PrioritizationFlag);
            DCmd.Parameters.AddWithValue("@WS2FlagOutput", WS2FlagOutput);
            DCmd.Parameters.AddWithValue("@WS2PrioritizationScore", WS2PrioritizationScore);
            DCmd.Parameters.AddWithValue("@WS2ConditionalPriorityTiers", WS2ConditionalPriorityTiers);
            DCmd.Parameters.AddWithValue("@LoggedInUser", LoginUser);
            DCmd.Parameters.AddWithValue("@RetMsg", Ret);
            return DCmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            DCmd.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }
    //  To get 'Intake Form' record of 'Active' or 'InActive' from database by stored procedure
    public DataTable LoadAllIntakeForm(int LoggedInUser, string returnmsg)
    {       
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormDetails' stored procedure is used to select Active and InActive type records From Intake Form table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID",DBNull.Value);
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To select 'IntakeForm' records specific IntakeFormId from database by stored procedure
    public DataTable SelectIntakeFormId(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupDetails' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormDetails", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To select Intake form Stakeholder details from specific IntakeFormId from database by stored procedure
    public DataTable SelectStakeholderDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetGroupDetails' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormStakeholder", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To select Intake form AnalyzeSolution from specific IntakeFormId from database by stored procedure
    public DataTable SelectAnalyzeSolutionDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormAnalyzeSolution' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormAnalyzeSolution", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }
    //  To select Intake form Curriculum details from specific IntakeFormId from database by stored procedure
    public DataTable SelectCurriculumDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormCurriculum' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormCurriculum", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To select Intake form Functions details from specific IntakeFormId from database by stored procedure
    public DataTable SelectFunctionDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormFunctions' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormFunctions", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }
    //  To select Intake form Functions details from specific IntakeFormId from database by stored procedure
    public DataTable SelectIndustriesDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormIndustries' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormIndustries", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To select Intake form ReviewerType details from specific IntakeFormId from database by stored procedure
    public DataTable SelectIntakeFormReviewerTypeDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormReviewerType' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormReviewerType", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }
    
    //  To select Intake form Specialties details from specific IntakeFormId from database by stored procedure
    public DataTable SelectSpecialtiesDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormSpecialties' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormSpecialties", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

     //  To select Intake form Specialties details from specific IntakeFormId from database by stored procedure
    public DataTable SelectStakeholderResourcesDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormStakeholderResources' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormStakeholderResources", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To select Intake form Specialties details from specific IntakeFormId from database by stored procedure
    public DataTable SelectTargetAudienceDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormStakeholderResources' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormTargetAudience", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }
 

    //  To select Intake form TrainingImpactOn details from specific IntakeFormId from database by stored procedure
    public DataTable SelectTrainingImpactOnDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspGetIntakeFormTrainingImpactOn' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspGetIntakeFormTrainingImpactOn", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }

    //  To select Intake form StakeholderInsert details from specific IntakeFormId from database by stored procedure
    public DataTable SelectTargetStakeholderInsertDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        SqlConnection Conn = new SqlConnection(ConnStr);
        //  'uspIntakeFormStakeholderInsert' stored procedure is used to select record from Intake table
        SqlDataAdapter DAdapter = new SqlDataAdapter("Transactions.uspIntakeFormStakeholderInsert", Conn);
        DAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        DAdapter.SelectCommand.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
        DAdapter.SelectCommand.Parameters.AddWithValue("@IntakeID", IntakeFormId);
        DAdapter.SelectCommand.Parameters.AddWithValue("@RetMsg", returnmsg);
        DataSet DSet = new DataSet();
        try
        {
            DAdapter.Fill(DSet, "IntakeForm");
            return DSet.Tables["IntakeForm"];
        }
        catch
        {
            throw;
        }
        finally
        {
            DSet.Dispose();
            DAdapter.Dispose();
            Conn.Close();
            Conn.Dispose();
        }
    }
}