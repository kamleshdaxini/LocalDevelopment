<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="IntakeForm.aspx.cs" Inherits="IntakeForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <script type="text/javascript">
        //debugger;
        // To maintain Browser scroll position after multiselectlist postback
        var sScrollX;//Fro x postion of scroll
        var sScroll;//for y position of scroll
        // To get system pagerequestmanager instance
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        //call fucntion after page request is over
        function EndRequestHandler(sender, args) {
            //to restore scroll postion
            restoreScroll();
        }
        //fuction to restore scroll position of browser after multiselectlist postback
        function restoreScroll() {
            var sScroll = document.getElementById('<%=hfldx.ClientID%>').value;
            var sScrollX = document.getElementById('<%=hfldy.ClientID%>').value;
            if (sScroll > 0 || sScrollX > 0) {
                if (document.documentElement && document.documentElement.scrollTop) {
                    document.documentElement.scrollTop = sScroll;
                    document.documentElement.scrollLeft = sScrollX;
                }
                else if (document.body) {
                    if (window.navigator.appName == 'Netscape')
                        window.scroll(sScrollX, sScroll);
                    else {
                        document.body.scrollTop = sScroll;
                        document.body.scrollLeft = sScrollX;
                    }
                }
                else {
                    window.scroll(sScrollX, sScroll);
                }

            }
        }
        //fuction to save scroll position of browser before multiselectlist postback
        function saveScroll() {
            var sScrollX;
            var sScroll;
            if (document.documentElement && document.documentElement.scrollTop) {
                sScroll = document.documentElement.scrollTop;
                sScrollX = document.documentElement.scrollLeft;
            }
            else if (document.body) {
                sScroll = document.body.scrollTop;
                sScrollX = document.body.scrollLeft;
            }
            else {
                sScroll = 0;
                sScrollX = 0;
            }
            document.getElementById('<%=hfldx.ClientID%>').value = sScroll;
            document.getElementById('<%=hfldy.ClientID%>').value = sScrollX;
        }
        // call onscroll function of browser
        window.onscroll = saveScroll;
        // call onresize function of browser
        window.onresize = saveScroll;
    </script>
<%--    set conditional mode to avoid postback--%>
    <asp:UpdatePanel ID="upnl" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:HiddenField ID="hfldx" Value="0" runat="server" />
            <asp:HiddenField ID="hfldy" Value="0" runat="server" />
            <table style="border: 1px none #7F9DB9; height: 650px; width: 100%;" cellpadding="2"
                cellspacing="2" id="tblSetSize" align="left">
                <tr>
                    <td valign="top">
                        <table width="100%" align="center">
                            <tr>
                                <td>
                                    <table width="100%" align="center">
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td width="90%"></td>
                                                        <td align="center">
                                                            <asp:Button ID="btnSave" runat="server" Text="Save"
                                                                OnClick="btnSave_Click" Width="54px" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:Button ID="btnPrint" runat="server" Text="Print " />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="center" width="100%">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Label ID="lblID" runat="server" Text="ID :"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="45%">
                                                                        <asp:Label ID="lblIntakeId" runat="server">904</asp:Label>
                                                                    </td>
                                                                    <td align="left" width="25%" rowspan="6">
                                                                        <table align="left" width="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <fieldset>
                                                                                        <legend>
                                                                                            <asp:Label ID="lblChangeWs1Phase" runat="server" Text="Change WS 1 Phase"></asp:Label>
                                                                                        </legend>
                                                                                        <table align="center" width="100%" style="height: 20px">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <asp:Button ID="btnCaptureNeeds" runat="server" Text="Capture Needs" Width="150px" Font-Size="11px" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <asp:Button ID="btnAnalyzeNeeds" runat="server" Text="Analyze Needs" Width="150px" Font-Size="11px" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <asp:Button ID="btnComleteMoveToWs2" runat="server" Text="Complete - move to WS2" Width="150px" Font-Size="11px" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <asp:Button ID="btnNeedClose" runat="server" Text="Need Closed" Width="150px" Font-Size="11px" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </fieldset>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Label ID="lblWs1_Phase" runat="server" Text="WS 1 Phase:"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="45%">
                                                                        <asp:Label ID="lblWs1Phase" runat="server" Width="80%">Capture Needs</asp:Label>
                                                                    </td>
                                                                    <td align="left" width="21%"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Label ID="lblWs1Status" runat="server" Text="WS 1 Status:"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="45%">
                                                                        <asp:DropDownList ID="ddlWSStatus" runat="server" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" width="21%"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Label ID="lblstkrelMngr" runat="server" Text="Stakeholder Relationship Manager :"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="45%">
                                                                        <asp:DropDownList ID="ddlSRM" runat="server" Width="80%">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td align="left" width="40%"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Label ID="lblStakeholder" runat="server" Text="Stakeholder :"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="45%">
                                                                        <uc:MultiselectList ID="ddlmslStakeholder" runat="server" panWidth="300"
                                                                            txtWidth="300" />
                                                                        <asp:CompareValidator ID="cfvWsStatus3" runat="server" ControlToValidate="ddlWSStatus"
                                                                            Display="None" ErrorMessage="Select WS1 Status" Operator="NotEqual" ValidationGroup="if"
                                                                            ValueToCompare="&lt;&lt; Select &gt;&gt;"></asp:CompareValidator>
                                                                        <asp:ValidatorCalloutExtender ID="vceWsStatus3" runat="server"
                                                                            TargetControlID="cfvWsStatus3">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                    <td align="left" width="40%"></td>
                                                                </tr>
                                                                <tr align="left">
                                                                    <td align="left" width="30%">
                                                                        <asp:Label ID="lblDecisionMaked" runat="server" Text="Decision maker/ Client (if Different than Stakeholder) :"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="45%">
                                                                        <asp:TextBox ID="txtDesicionMaker" runat="server" Width="80%"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvDecisionMaker" runat="server" ControlToValidate="txtdesicionmaker"
                                                                            Display="None" ErrorMessage="Enter Decision Maker" ValidationGroup="if"></asp:RequiredFieldValidator>
                                                                        <asp:ValidatorCalloutExtender ID="vceDecisionMaker" runat="server"
                                                                            TargetControlID="rfvDecisionMaker">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    </td>
                                                                    <td align="left" width="40%"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr align="center">
                                <td align="left" valign="top">
                                    <div style="text-align: left">
                                        <asp:TabContainer runat="server" ID="tabcon" ActiveTabIndex="0" Width="100%"
                                            Style="margin-top: 0px;visibility:visible">
                                            <asp:TabPanel ID="tabpnlCaptureNeeds" runat="server" ScrollBars="Vertical">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblCapture_needs" runat="server" Text="Capture Needs "></asp:Label></a>
                                                </HeaderTemplate>
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblOrgMeetingDate" runat="server" Text="Origin/Meeting Date:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:CalendarExtender ID="cal1" runat="server"
                                                                    TargetControlID="txtOrigin_MeetingDate" PopupButtonID="imgOrigin_MeetingDate" Format="MM/dd/yyyy"
                                                                    Enabled="True">
                                                                </asp:CalendarExtender>
                                                                <asp:TextBox ID="txtOrigin_MeetingDate" runat="server" Width="120px"></asp:TextBox>
                                                                <asp:ImageButton ID="imgOrigin_MeetingDate" runat="server" SkinID="Calimg" />
                                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                                                    TargetControlID="rngfvalOrigin_MeetingDate" Enabled="True">
                                                                </asp:ValidatorCalloutExtender>
                                                                <asp:RangeValidator ID="rngfvalOrigin_MeetingDate" runat="server" ControlToValidate="txtOrigin_MeetingDate" ErrorMessage="Date must be between 01/01/1800 and today" Type="Date" Display="None" ValidationGroup="if"></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblTrainingNeedNames" runat="server" Text="Training Need Name:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtTrainingNeedName" runat="server" Width="80%"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvTrainingNeedName" runat="server" ControlToValidate="txtTrainingNeedName" Display="None" ErrorMessage="Enter Training Need Name" ValidationGroup="if"></asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceTrainingNeedName" runat="server" Enabled="True" TargetControlID="rfvTrainingNeedName">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblBackInfo" runat="server" Text="Background Information:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtBackgroundInformation" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblprobState" runat="server" Text="Problem Statement (stakeholder provided):"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtProblemStatement" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblbusinessReasons" runat="server" Text="Business Reasons and Drivers"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtBusinessReasonsAndDrivers" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblstkper" runat="server" Text="Stakeholder Perception of Priority:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtStakeholderPerceptionOfPriority" runat="server" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblreqsolution" runat="server" Text="Requested Solution:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtRequestedSolution" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblReqDateTrainImp" runat="server" Text="Requested Date of Training Implementation"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:CalendarExtender ID="calextrainingCompletion" runat="server" TargetControlID="txtRequestedTrainingImplementationDate" Format="MM/dd/yyyy"
                                                                    PopupButtonID="imgRequestedTrainingImplementationDate" Enabled="True">
                                                                </asp:CalendarExtender>
                                                                <asp:TextBox ID="txtRequestedTrainingImplementationDate" runat="server"
                                                                    Width="120px"></asp:TextBox>
                                                                <asp:ImageButton ID="imgRequestedTrainingImplementationDate" runat="server" SkinID="Calimg" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label43" runat="server" Text="Requested Date of Training Completion:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:CalendarExtender ID="calexRequestedTrainingCompletationDate" runat="server" TargetControlID="txtRequestedTrainingCompletationDate" Format="MM/dd/yyyy"
                                                                    PopupButtonID="imgRequestedTrainingCompletationDate" Enabled="True">
                                                                </asp:CalendarExtender>
                                                                <asp:TextBox ID="txtRequestedTrainingCompletationDate" runat="server"
                                                                    Width="120px"></asp:TextBox>
                                                                <asp:ImageButton ID="imgRequestedTrainingCompletationDate" runat="server" SkinID="Calimg" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblCommentsOnRequestedTimeline" runat="server" Text="Comments on requested timeline"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtCommentsOnRequestedTimeline" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblTargetAudience" runat="server" Text="Target Audience by Level"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <uc:MultiselectList ID="ddlmslTargetAudience" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblIndustries" runat="server" Text="Industries (m):"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <uc:MultiselectList ID="ddlmslIndustries" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblSpecialities" runat="server" Text="Specialties:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <uc:MultiselectList ID="ddlmslSpecialities" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblFunctions" runat="server" Text="Applicable to other functions?:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <uc:MultiselectList ID="ddlmslFunctions" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblAudienceDescription" runat="server" Text="Target Audience Description:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtTargetAudienceDescription" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblResStakCanPotProvide" runat="server" Text="Resources stakeholder can potentially provide:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <uc:MultiselectList ID="ddlmslResStakCanPotProvide" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblReviewCourseOutlines" runat="server" Text="Does Stakeholder need to review course outlines?"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:CheckBox ID="chkReviewCourseOutlines" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblRecomendedReviewerTypes" runat="server" Text="Recommended Reviewer Types:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <uc:MultiselectList ID="ddlmslRecomendedReviewerTypes" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblCurrentBusinessAndPerformanceState" runat="server" Text="Describe the current business and performance state:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtCurrentBusinessAndPerformanceState" runat="server"
                                                                    Height="80px" TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblImpactOnTraining" runat="server" Text="This training will have a significant impact on:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <uc:MultiselectList ID="ddlmslImpactOnTraining" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblDesiredBusinessAndPerformanceOutcomes" runat="server" Text="Describe the desired business and performance outcomes"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtDesiredBusinessAndPerformanceOutcomes" runat="server"
                                                                    Height="80px" TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="lblCauseOfGap" runat="server" Text="Describe the cause(s) of the gap:"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="txtCauseOfGap" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%"></td>
                                                            <td width="70%"></td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="tabpnlAnalyzeNeeds" runat="server" ScrollBars="Vertical">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblAnalyzeNeeds" runat="server" Text="Analyze Needs "></asp:Label></a>
                                                </HeaderTemplate>
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="30%" valign="top">
                                                                <asp:Label ID="lblSummarizeGapAssessment" runat="server" Text="Summarize gap assessment:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtSummarizeGapAssessment" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblAnalyzeSolution" runat="server" Text="Analyze solution:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <uc:MultiselectList ID="ddlmslAnalyzeSolution" runat="server" />
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblAnalyzeSolutionDescription" runat="server" Text="Analyze Solution description:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtAnalyzeSolutionDescription" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lbltarget_cur_keyword" runat="server" Text="Curriculum Keywords:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <uc:MultiselectList ID="ddlmlttarget_cur_keyword" runat="server" />
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblDescriptionOfTheTopics" runat="server" Text="Description of the topics:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtDescriptionOfTheTopics" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblPrioritizationNeed" runat="server" Text="Prioritization of Need:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtPrioritizationNeed" runat="server" Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblImpactedBusinessGoal" runat="server" Text="Impacted Business Goal:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtImpactedBusinessGoal" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblSummaryofImpactonALDcurriculumALDFirmresources" runat="server" Text="Summary of impact on ALD curriculum ALD Firm"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtSummaryofImpactonALDcurriculumALDFirmresources"
                                                                    runat="server" Height="80px" TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblOtherComments" runat="server" Text="Other Comments:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtOtherComments" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblProposedDateofTrainingImplementation" runat="server" Text="Proposed date of training implementation:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:CalendarExtender ID="calexProposedDateofTrainingImplementation" runat="server" TargetControlID="txtProposedDateofTrainingImplementation" Format="MM/dd/yyyy"
                                                                    PopupButtonID="imgProposedDateofTrainingImplementation" Enabled="True">
                                                                </asp:CalendarExtender>
                                                                <asp:TextBox ID="txtProposedDateofTrainingImplementation" runat="server"
                                                                    Width="120px"></asp:TextBox>
                                                                <asp:ImageButton ID="imgProposedDateofTrainingImplementation" runat="server" SkinID="Calimg" />
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblProposedDateofTrainingCompletion" runat="server" Text="Proposed date of training completion:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:CalendarExtender ID="calexProposedDateofTrainingCompletion" runat="server" TargetControlID="txtProposedDateofTrainingCompletion"
                                                                    PopupButtonID="imgProposedDateofTrainingCompletion" Enabled="True" Format="MM/dd/yyyy">
                                                                </asp:CalendarExtender>
                                                                <asp:TextBox ID="txtProposedDateofTrainingCompletion" runat="server"
                                                                    Width="120px"></asp:TextBox>
                                                                <asp:ImageButton ID="imgProposedDateofTrainingCompletion" runat="server" SkinID="Calimg" />
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="Label96" runat="server" Text="Comments on proposed timeline:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtCommentsonProposedTimeline" runat="server" Height="80px"
                                                                    TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblWS1PlanValidated" runat="server" Text="WS1 Plan Validated:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="ddlWS1PlanValidated" runat="server" Width="80%">
                                                                    <asp:ListItem Selected="True" Text="No" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Yes" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="30%">
                                                                <asp:Label ID="lblAttachedfile" runat="server" Text="Attach File(s):"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtAttachedfile" runat="server" Height="80px" TextMode="MultiLine" Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%"></td>
                                                            <td width="70%"></td>
                                                            <td></td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="tabpnlPrioritization" runat="server" ScrollBars="Vertical">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblPrioritization" runat="server" Text="Prioritization"></asp:Label></a><a href="#"
                                                        class="href"></a>
                                                </HeaderTemplate>
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblAlignmentWithKBSAStrategy" runat="server" Text="Alignment With ALD Strategy:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="ddlAlignmentWithKBSAStrategy" runat="server" Width="80%"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlAlignmentWithKBSAStrategy_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblAlignmentWithKPMGStrategy" runat="server" Text="Alignment With KPMG Strategy:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="ddlAlignmentWithKPMGStrategy" runat="server" Width="80%"
                                                                    AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlAlignmentWithKPMGStrategy_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblBusinessImpactOnProcess" runat="server" Text="Business Impact On Processes:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="ddlBusinessImpactOnProcess" runat="server" Width="80%"
                                                                    AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlBusinessImpactOnProcess_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblBusinessImpactOnPeople" runat="server" Text="Business Impact On people:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="ddlBusinessImpactOnPeople" runat="server" Width="80%"
                                                                    AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlBusinessImpactOnPeople_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblBusinessImpactOnBottomLine" runat="server" Text="Business Impact On Bottom Line:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="ddlBusinessImpactOnBottomLine" runat="server" Width="80%"
                                                                    AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlBusinessImpactOnBottomLine_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblCostBudgetImpact" runat="server" Text="Cost Budget Impact:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="ddlCostBudgetImpact" runat="server" Width="80%"
                                                                    AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlCostBudgetImpact_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblCostReasonableness" runat="server" Text="Cost Reasonableness:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="ddlCostReasonableness" runat="server" Width="80%"
                                                                    AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlCostReasonableness_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblRiskToKPMG" runat="server" Text="Risk To KPMG:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="ddlRiskToKPMG" runat="server" Width="80%"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlRiskToKPMG_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblRiskToKBSA" runat="server" Text="Risk To ALD:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="ddlRiskToKBSA" runat="server" Width="80%"
                                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlRiskToKBSA_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblWS2PrioritizationFlag" runat="server" Text="WS2 Prioritization Flag:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtWS2PrioritizationFlag" runat="server" AutoPostBack="True"
                                                                    Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblWS2_FO" runat="server" Text="WS2 Flag Output:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:Label ID="lblWS2FO" runat="server" Text="Training need doesn't meet citeria to develop training"
                                                                    Width="80%"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblWS2PrioritizationScore" runat="server" Text="WS2 Priotization Scrore:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtWS2PrioritizationScore" runat="server" Width="80%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="lblWS2Conditional_PriorityTiers" runat="server" Text="WS2 Conditional Priority Tiers:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:Label ID="lblWS2ConditionalPriorityTiers" runat="server"
                                                                    Text="Killer variable or missed question"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="middle" height="30px" width="100%">
                                    <table width="100%" align="center">
                                        <tr>
                                            <td align="center"></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
