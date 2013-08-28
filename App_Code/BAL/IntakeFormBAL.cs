using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IntakeFormBAL
/// </summary>
public class IntakeFormBAL
{
	public IntakeFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

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
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.InsertIntakeForm(WS1PhaseId, WS1StatusId, StakeholderRelationshipManagerId, IntakeFormStakeholderID, DecisionMaker, Origin_MeetingDate,
            TrainingNeedName, BackgroundInformation, ProblemStatement, BusinessReasonsAndDrivers, StakeholderPerceptionOfPriority, RequestedSolution,RequestedTrainingImplementationDate, 
            RequestedTrainingCompletationDate, CommentsOnRequestedTimeline, TargetAudienceByLevel, Industries,Specialites, ApplicableToOtherFunctions, TargetAudienceDescription, 
            ResourcesStakeholderCanPotentiallyProvide, ReviewCourseOutlines,RecomendedReviewerTypes, CurrentBusinessAndPerformanceState, SignificantImpactOnTraining,
            DesiredBusinessAndPerformanceOutcomes, CauseOfGap, SummarizeGapAssessment, AnalyzeSolution, AnalyzeSolutionDescription, CurriculumKeywords, DescriptionOfTheTopics,
            ImpactedBusinessGoal, SummaryofImpactonALDcurriculumALDFirmresources, OtherComments, ProposedDateofTrainingImplementation,ProposedDateofTrainingCompletion,
            CommentsonProposedTimeline, WS1PlanValidated, AlignmentWithKBSAStrategyId, AlignmentWithKPMGStrategyId,BusinessImpactOnProcessId, BusinessImpactOnPeopleId, 
            BusinessImpactOnBottomLineId, CostBudgetImpactId, CostReasonablenessId, RiskToKPMGId, RiskToKBSAId, WS2PrioritizationFlag, WS2FlagOutput, WS2PrioritizationScore, 
            WS2ConditionalPriorityTiers, LoginUser, Ret);
        }
        catch
        {
            throw;
        }
        finally
        {

            IntakeFormDAL = null;
        }
    }

    // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show records
    public DataTable LoadAllIntakeForm(int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.LoadAllIntakeForm(LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }

    // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectIntakeFormId(int IntakeFormId, int LoggedInUser, string returnmsg)
    {      
        IntakeFormDAL IntakeFormDAL=new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectIntakeFormId(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }


     // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectStakeholderDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {      
        IntakeFormDAL IntakeFormDAL=new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectStakeholderDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }

    // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectAnalyzeSolutionDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectAnalyzeSolutionDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }

    // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectCurriculumDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectCurriculumDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }


      // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectFunctionDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectFunctionDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }

    
    // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectIndustriesDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectIndustriesDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }
    // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectIntakeFormReviewerTypeDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectIntakeFormReviewerTypeDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }
    // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectSpecialtiesDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectIntakeFormReviewerTypeDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }
    // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectStakeholderResourcesDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectStakeholderResourcesDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }
    // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectTargetAudienceDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectTargetAudienceDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }
    // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectTrainingImpactOnDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectAnalyzeSolutionDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }

      // To pass 'IntakeForm' data in IntakeFormDAL Data Access Layer to show selected IntakeFormId record
    public DataTable SelectTargetStakeholderInsertDetails(int IntakeFormId, int LoggedInUser, string returnmsg)
    {
        IntakeFormDAL IntakeFormDAL = new IntakeFormDAL();
        try
        {
            return IntakeFormDAL.SelectTargetStakeholderInsertDetails(IntakeFormId, LoggedInUser, returnmsg);
        }
        catch
        {
            throw;
        }
        finally
        {
            IntakeFormDAL = null;
        }
    }
}