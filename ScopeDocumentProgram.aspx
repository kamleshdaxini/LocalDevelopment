<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation ="true" 
    CodeFile="ScopeDocumentProgram.aspx.cs" Inherits="ScopeDocumentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <div style="border: 1px none #7F9DB9; width: 100%; overflow: auto; text-align: center;"
                id="tblSetSize">
                <table style="border: 1px none #7F9DB9; width: 100%;" cellpadding="2" cellspacing="2"
                    align="center">
                    <tr>
                        <td valign="top">
                            <table width="100%" align="center">
                                <tr>
                                    <td align="center">
                                        <fieldset>
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="30%">
                                                        <asp:Label ID="Label127" runat="server" Text="Scope Document ID:"></asp:Label>
                                                    </td>
                                                    <td align="left" width="40%">
                                                        <asp:Label ID="lblScopeID" runat="server" Text="905"></asp:Label>
                                                    </td>
                                                    <td align="left" rowspan="9" valign="top" width="30%">
                                                        <fieldset>
                                                            <legend>
                                                                <asp:Label ID="Label128" runat="server" Text="Operations"></asp:Label>
                                                            </legend>
                                                            <table style="height: 170px" width="100%">
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Button ID="Button32" runat="server" Text="Scoping Complete" Width="100%" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Button ID="Button33" runat="server" Text="Complete used as parent file" Width="100%" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Button ID="Button34" runat="server" Text="Mark Ws1 Phase as Suggested Change"
                                                                            Width="100%" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Button ID="Button35" runat="server" Style="margin-bottom: 0px" Text="Map Program to Courses"
                                                                            Width="100%" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Button ID="Button36" runat="server" Text="Map Intake Form ID(s)" Width="100%" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="30%">
                                                                        <asp:Button ID="Button37" runat="server" Text="Map Suggested Change ID(s)" Width="100%" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </fieldset>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="30%">
                                                        <asp:Label ID="Label129" runat="server" Text="WS Status :"></asp:Label>
                                                    </td>
                                                    <td align="left" width="40%">
                                                        <asp:DropDownList ID="DropDownList77" runat="server" Width="70%">
                                                            <asp:ListItem>&lt;&lt; Select &gt;&gt;</asp:ListItem>
                                                            <asp:ListItem>Active</asp:ListItem>
                                                            <asp:ListItem>Dead</asp:ListItem>
                                                            <asp:ListItem>Retired</asp:ListItem>
                                                            <asp:ListItem>Inactive</asp:ListItem>
                                                            <asp:ListItem>Delivered / Complete</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="30%">
                                                        <asp:Label ID="Label130" runat="server" Text="WS-1 Phase:"></asp:Label>
                                                    </td>
                                                    <td align="left" width="40%">
                                                        <asp:DropDownList ID="DropDownList78" runat="server" Width="70%">
                                                            <asp:ListItem>&lt;&lt; Select &gt;&gt;</asp:ListItem>
                                                            <asp:ListItem>Capture Needs</asp:ListItem>
                                                            <asp:ListItem>Analyze Needs</asp:ListItem>
                                                            <asp:ListItem>Complete-Move to WS2</asp:ListItem>
                                                            <asp:ListItem>Need Closed</asp:ListItem>
                                                            <asp:ListItem>Suggested Change</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="30%">
                                                        <asp:Label ID="Label131" runat="server" Text="WS -2 Phase:"></asp:Label>
                                                    </td>
                                                    <td align="left" width="40%">
                                                        <asp:DropDownList ID="DropDownList79" runat="server" Width="70%">
                                                            <asp:ListItem>&lt;&lt; Select &gt;&gt;</asp:ListItem>
                                                            <asp:ListItem>Prioritize</asp:ListItem>
                                                            <asp:ListItem>Plan</asp:ListItem>
                                                            <asp:ListItem>Resource</asp:ListItem>
                                                            <asp:ListItem>Complete - Move to WS3 &amp; WS5</asp:ListItem>
                                                            <asp:ListItem>Complete used as parent file</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="30%">
                                                        <asp:Label ID="Label132" runat="server" Text="Scope Type :"></asp:Label>
                                                    </td>
                                                    <td align="left" width="40%">
                                                        <asp:DropDownList ID="DropDownList80" runat="server" Width="70%">
                                                            <asp:ListItem>&lt;&lt; Select &gt;&gt;</asp:ListItem>
                                                            <asp:ListItem>Program</asp:ListItem>
                                                            <asp:ListItem>Courses</asp:ListItem>
                                                            <asp:ListItem>Standalone Courses</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="30%">
                                                        <asp:Label ID="Label133" runat="server" Text="Intake Form ID:"></asp:Label>
                                                    </td>
                                                    <td align="left" width="40%">
                                                        <asp:TextBox ID="TextBox46" runat="server" Width="70%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="30%">
                                                        <asp:Label ID="Label134" runat="server" Text="Suggested Changes ID :"></asp:Label>
                                                    </td>
                                                    <td align="left" width="40%">
                                                        <asp:TextBox ID="TextBox47" runat="server" Width="70%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="30%">
                                                        <asp:Label ID="Label135" runat="server" Text="Scope Document Date :"></asp:Label>
                                                    </td>
                                                    <td align="left" width="40%">
                                                        <asp:TextBox ID="TextBox48" runat="server" Width="120px"></asp:TextBox>
                                                        <asp:CalendarExtender ID="TextBox48_CalendarExtender" runat="server" PopupButtonID="img4"
                                                            TargetControlID="TextBox48">
                                                        </asp:CalendarExtender>
                                                        <asp:ImageButton ID="img4" runat="server" SkinID="Calimg" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" width="30%">
                                                        <asp:Label ID="Label136" runat="server" Text="Suggested Change Delivery Date :"></asp:Label>
                                                    </td>
                                                    <td align="left" width="40%">
                                                        <asp:TextBox ID="TextBox49" runat="server" Width="120px"></asp:TextBox>
                                                        <asp:CalendarExtender ID="TextBox49_CalendarExtender" runat="server" PopupButtonID="img5"
                                                            TargetControlID="TextBox49">
                                                        </asp:CalendarExtender>
                                                        <asp:ImageButton ID="img5" runat="server" SkinID="Calimg" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <asp:TabContainer ID="TabContainer134" runat="server" ActiveTabIndex="2" ScrollBars="Auto" Style="margin-top: 0px;visibility:visible;"
                                            Width="100%">
                                            <asp:TabPanel ID="TabPanel25" runat="server" HeaderText="Questions for a new Course">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="left" style="text-align: left" width="30%">
                                                                <asp:Label ID="Label122" runat="server" Text="Training Need Name"></asp:Label>
                                                            </td>
                                                            <td align="left" style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox3" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="text-align: left" width="30%">
                                                                <asp:Label ID="Label8" runat="server" Text="Related Need ID#"></asp:Label>
                                                            </td>
                                                            <td align="left" style="text-align: left" width="70%">
                                                                <asp:DropDownList ID="DropDownList72" runat="server" Width="70%">
                                                                    <asp:ListItem>&lt;&lt; Select &gt;&gt;</asp:ListItem>
                                                                    <asp:ListItem>901</asp:ListItem>
                                                                    <asp:ListItem>903</asp:ListItem>
                                                                    <asp:ListItem>904</asp:ListItem>
                                                                    <asp:ListItem>905</asp:ListItem>
                                                                    <asp:ListItem>906</asp:ListItem>
                                                                    <asp:ListItem>907</asp:ListItem>
                                                                    <asp:ListItem>908</asp:ListItem>
                                                                    <asp:ListItem>909</asp:ListItem>
                                                                    <asp:ListItem>910</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="text-align: left" width="30%">
                                                                <asp:Label ID="Label91" runat="server" Text="Origin/Meeting Date with Stakeholder"></asp:Label>
                                                            </td>
                                                            <td align="left" style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox4" runat="server" Width="120px"></asp:TextBox>
                                                                <asp:CalendarExtender ID="cal2" runat="server" Enabled="True" PopupButtonID="img2"
                                                                    TargetControlID="TextBox4">
                                                                </asp:CalendarExtender>
                                                                <asp:ImageButton ID="img2" runat="server" SkinID="Calimg" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Course/Program Information">
                                                <HeaderTemplate>
                                                    Course/Program Information
                                                </HeaderTemplate>
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label16" runat="server" Text="Innovation Date"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="TextBox6" runat="server" Width="120px"></asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" PopupButtonID="ImageButton1"
                                                                    TargetControlID="TextBox6">
                                                                </asp:CalendarExtender>
                                                                <asp:ImageButton ID="ImageButton1" runat="server" SkinID="Calimg" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label17" runat="server" Text="Course/Program Title"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="TextBox7" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label18" runat="server" Text="Is This the Program?"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:DropDownList ID="DropDownList3" runat="server" Width="70%">
                                                                    <asp:ListItem Value="No"></asp:ListItem>
                                                                    <asp:ListItem Value="Yes"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label19" runat="server" Text="In Which Program is this Course Expected to be Delivered?"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:DropDownList ID="DropDownList6" runat="server" Width="70%">
                                                                    <asp:ListItem>&lt;&lt; Select &gt;&gt;</asp:ListItem>
                                                                    <asp:ListItem>AICS I</asp:ListItem>
                                                                    <asp:ListItem>AICS</asp:ListItem>
                                                                    <asp:ListItem>AICS II</asp:ListItem>
                                                                    <asp:ListItem>IFRS</asp:ListItem>
                                                                    <asp:ListItem>ICA</asp:ListItem>
                                                                    <asp:ListItem>AIT</asp:ListItem>
                                                                    <asp:ListItem>AICS III </asp:ListItem>
                                                                    <asp:ListItem>IND 1</asp:ListItem>
                                                                    <asp:ListItem>IND 2</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label20" runat="server" Text="Curriculam Keywords"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <uc:MultiselectList ID="mlttarget_cur_keyword" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label21" runat="server" Text="Delivery Method"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:DropDownList ID="DropDownList10" runat="server" Width="70%">
                                                                    <asp:ListItem>&lt;&lt; Select &gt;&gt;</asp:ListItem>
                                                                    <asp:ListItem>Blended(Program Only)</asp:ListItem>
                                                                    <asp:ListItem>MSO</asp:ListItem>
                                                                    <asp:ListItem>Resource Page</asp:ListItem>
                                                                    <asp:ListItem>WBT Rel</asp:ListItem>
                                                                    <asp:ListItem>Podcast</asp:ListItem>
                                                                    <asp:ListItem>WBT Vendor</asp:ListItem>
                                                                    <asp:ListItem>Klearn Live</asp:ListItem>
                                                                    <asp:ListItem>Klearn on Demand</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label22" runat="server" Text="Target Audience"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <uc:MultiselectList ID="mlttarget_audience" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label23" runat="server" Text="Industries"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <uc:MultiselectList ID="mlttarget_Industries" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label24" runat="server" Text="Specialities"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <uc:MultiselectList ID="mlttarget_Specialities" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label25" runat="server" Text="Applicable to other Functions?"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <uc:MultiselectList ID="mlttarget_functions" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label26" runat="server" Text="Target Audience Description"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="TextBox12" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label27" runat="server" Text="CPE Worthy"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList15" runat="server" Width="70%">
                                                                    <asp:ListItem Value="Yes"></asp:ListItem>
                                                                    <asp:ListItem Value="No"></asp:ListItem>
                                                                    <asp:ListItem Value="MayBe"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label28" runat="server" Text="Make or Buy"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList16" runat="server" Width="70%">
                                                                    <asp:ListItem Value="Make"></asp:ListItem>
                                                                    <asp:ListItem Value="Buy"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label36" runat="server" Text="Expiration Date"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="TextBox13" runat="server" Width="120px"></asp:TextBox>
                                                                <asp:CalendarExtender ID="cal3" runat="server" Enabled="True" PopupButtonID="img3"
                                                                    TargetControlID="TextBox13">
                                                                </asp:CalendarExtender>
                                                                <asp:ImageButton ID="img3" runat="server" SkinID="Calimg" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel11" runat="server" HeaderText="Stakeholder Resources">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label10" runat="server" Text="Resource needeed from Stakeholder "></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox41" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label12" runat="server" Text="Resources Stakeholder will Provide"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <uc:MultiselectList ID="mlttarget_stkresource" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label124" runat="server" Text="Stakeholder Commitment"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:DropDownList ID="DropDownList7" runat="server" Width="70%">
                                                                    <asp:ListItem Value="Yes"></asp:ListItem>
                                                                    <asp:ListItem Value="No"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label31" runat="server" Text="Compliance Requirements"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox8" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label123" runat="server" Text="Comments"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox9" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label125" runat="server" Text="Attachments"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:FileUpload ID="FileUpload1" runat="server" Width="70%" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanl1" runat="server" HeaderText="Prioritization Tool">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label2" runat="server" Text="Alignment with ALD Strategy:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList40" runat="server" Width="70%" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="DropDownList40_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label78" runat="server" Text="Alignment with KPMG Strategy:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList2" runat="server" Width="70%" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label9" runat="server" Text="Business Impact on People"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList5" runat="server" Width="70%" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label79" runat="server" Text="Business Impact on Processes"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList42" runat="server" Width="70%" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="DropDownList42_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label80" runat="server" Text="Business Impact on Bottom Line"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList43" runat="server" Width="70%" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="DropDownList43_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label81" runat="server" Text="Cost Budget Impact:"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList44" runat="server" Width="70%" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="DropDownList44_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label82" runat="server" Text="Cost Reasonableness :"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList17" runat="server" Width="70%" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="DropDownList17_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label83" runat="server" Text="Risk to KPMG :"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList46" runat="server" Width="70%" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="DropDownList46_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label84" runat="server" Text="Risk to ALD :"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList47" runat="server" Width="70%" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="DropDownList47_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label85" runat="server" Text="WS2 Prioritization :"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtWs2PF" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label197" runat="server" Text="WS2 output :"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:Label ID="lblWS2FO" runat="server" Text="Training need doesn't meet citeria to develop training"
                                                                    Width="70%"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label87" runat="server" Text="WS2 Prioritization Score :"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:TextBox ID="txtWs2PS" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label13" runat="server" Text="WS2 Conditional Priority Tiers :"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:Label ID="lblWS2COPT" runat="server" Text="Killer variable or missed question"
                                                                    Width="80%"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                &nbsp;
                                                            </td>
                                                            <td width="70%">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Content Information">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label34" runat="server" Text="Performance Outcomes Expected from this Course/Program"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="TextBox14" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label37" runat="server" Text="Business Outcomes Expected from this Course/Program"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="TextBox15" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label60" runat="server" Text="Incoming Knowledge Expected"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="TextBox31" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label39" runat="server" Text="Topics"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="TextBox27" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label35" runat="server" Text="Blooms Taxonomy Levels"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:DropDownList ID="DropDownList28" runat="server" Width="70%">
                                                                    <asp:ListItem Value="Analysis,Synthesis,Evaluation"></asp:ListItem>
                                                                    <asp:ListItem Value="Application"></asp:ListItem>
                                                                    <asp:ListItem Value="Knowledge,Comphrehension"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label38" runat="server" Text="MTAG"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="TextBox20" runat="server" Style="margin-top: 0px" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label59" runat="server" Text="Are their Materials that could be Leveraged?"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:DropDownList ID="DropDownList30" runat="server" Width="70%">
                                                                    <asp:ListItem Value="Yes"></asp:ListItem>
                                                                    <asp:ListItem Value="No"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="30%">
                                                                <asp:Label ID="Label61" runat="server" Text="What Materials can be Leveraged?"></asp:Label>
                                                            </td>
                                                            <td align="left" width="70%">
                                                                <asp:TextBox ID="TextBox32" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Course/Program/Planning/Innovation Team">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label30" runat="server" Text="Stakeholder Relationship Manager"></asp:Label>
                                                            </td>
                                                            <td class="style3" width="70%">
                                                                <asp:DropDownList ID="DropDownList26" runat="server" Width="70%">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label55" runat="server" Text="Portfolio Manager"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <asp:DropDownList ID="DropDownList27" runat="server" Width="70%">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label62" runat="server" Text="Instructional Designer"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <uc:MultiselectList ID="ddlmultistk_ID" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label86" runat="server" Text="Content Developer"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <uc:MultiselectList ID="ddlmultistk_CD" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label88" runat="server" Text="Program Lead"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <uc:MultiselectList ID="ddlmultistk_PL" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:Label ID="Label90" runat="server" Text="Delivery Lead"></asp:Label>
                                                            </td>
                                                            <td width="70%">
                                                                <uc:MultiselectList ID="ddlmultistk_DL" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel9" runat="server" HeaderText="Project Management Information - other Project Management Information">
                                                <ContentTemplate>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label40" runat="server" Text="Recommended Reviewer Types"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <uc:MultiselectList ID="mlttarget_rec_review" runat="server" panWidth="300" txtWidth="300" />
                                                            </td>
                                                            <td colspan="2">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label42" runat="server" Text="Project Risks"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox16" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label41" runat="server" Text="Budget Allocation:This functionality is coming soon"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox10" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label43" runat="server" Text="Project Constraints"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox17" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <%--     <asp:TabPanel ID="TabPanel7" runat="server" HeaderText="Project Management Information - Cycle Plan Items">
                                                    <ContentTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left" width="30%">
                                                                    <asp:Label ID="Label115" runat="server" Text="Session Number:"></asp:Label>
                                                                </td>
                                                                <td align="left" width="70%">
                                                                    <asp:DropDownList ID="DropDownList70" runat="server" Width="70%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="30%">
                                                                    <asp:Label ID="Label116" runat="server" Text="Location:"></asp:Label>
                                                                </td>
                                                                <td align="left" width="70%">
                                                                    <asp:TextBox ID="TextBox38" runat="server" Width="70%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="30%">
                                                                    <asp:Label ID="Label117" runat="server" Text="Max Pax:"></asp:Label>
                                                                </td>
                                                                <td align="left" width="70%">
                                                                    <asp:DropDownList ID="DropDownList71" runat="server" Width="70%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="30%">
                                                                    <asp:Label ID="Label118" runat="server" Text="Start Time:"></asp:Label>
                                                                </td>
                                                                <td align="left" width="70%">
                                                                    <asp:TextBox ID="TextBox39" runat="server" Width="70%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="30%">
                                                                    <asp:Label ID="Label119" runat="server" Text="End Time:"></asp:Label>
                                                                </td>
                                                                <td align="left" width="70%">
                                                                    <asp:TextBox ID="TextBox40" runat="server" Width="70%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:TabPanel>--%>
                                        </asp:TabContainer>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="100%">
                                        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="150px"
                                            ScrollBars="Auto" Width="100%">
                                            <asp:TabPanel ID="tab1" runat="server" HeaderText="Course Calender">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grdCalender" runat="server" AutoGenerateColumns="False" Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr. No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label11" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Name of Course or Program">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblfname" runat="server" Text='<%# Eval("Name of Course or Program") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Session#">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbllname" runat="server" Text='<%# Eval("Session#") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Max Pax">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusername" runat="server" Text='<%# Eval("Max Pax") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Start Time">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblmail" runat="server" Text='<%# Eval("Start Time") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="End Time">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusername1" runat="server" Text='<%# Eval("End Time") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Required learning">
                                                <ContentTemplate>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label48" runat="server" Text="Is this Course Required /Strongly Recommended, or Elective"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox1" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label49" runat="server" Text="Required learning Field:"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:DropDownList ID="DropDownList31" runat="server" Width="70%">
                                                                    <asp:ListItem Value="Trainers"></asp:ListItem>
                                                                    <asp:ListItem Value="Reviewers"></asp:ListItem>
                                                                    <asp:ListItem Value="Funding"></asp:ListItem>
                                                                    <asp:ListItem Value="Materials/Content"></asp:ListItem>
                                                                    <asp:ListItem Value="SMPs"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label50" runat="server" Text="What is due date? :"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:DropDownList ID="DropDownList32" runat="server" Width="70%">
                                                                    <asp:ListItem Value="Yes"></asp:ListItem>
                                                                    <asp:ListItem Value="No"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label51" runat="server" Text="will the assignment be announced through the required learning:"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox2" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label52" runat="server" Text="Will the reminders be on regular schedule?:"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox5" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;" width="30%">
                                                                <asp:Label ID="Label53" runat="server" Text="Provisional plan details:"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left" width="70%">
                                                                <asp:TextBox ID="TextBox30" runat="server" Width="70%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Measurement Plan Form">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grdmeasurement" runat="server" AutoGenerateColumns="False" Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr. No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label11" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Levels">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblfname" runat="server" Text='<%# Eval("Levels") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Session#">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbllname" runat="server" Text='<%# Eval("What") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Max Pax">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusername" runat="server" Text='<%# Eval("To Whom") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Start Time">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblmail" runat="server" Text='<%# Eval("When Launched Date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="End Time">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusername" runat="server" Text='<%# Eval("Launch Description") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="End Time">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusername" runat="server" Text='<%# Eval("Format Vehicle") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="End Time">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusername" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Communication Plan Form">
                                                <ContentTemplate>
                                                    <asp:GridView ID="grdcommunication_plnaDetails" runat="server" AutoGenerateColumns="False"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr. No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label11" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="What">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblfname" runat="server" Text='<%# Eval("What") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Who">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbllname" runat="server" Text='<%# Eval("Who") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="When">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusername" runat="server" Text='<%# Eval("When") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Format/Vehicle">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblmail" runat="server" Text='<%# Eval("Format/Vehicle") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Other logistics">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusername" runat="server" Text='<%# Eval("Other logistics") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Review Requirements/final Approver">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusername" runat="server" Text='<%# Eval("Review Requirements/final Approver") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="DH#">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusername" runat="server" Text='<%# Eval("DH#") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td align="left">
                                        <asp:Button ID="Button38" runat="server" Text="Save" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="Button39" runat="server" Text="Cancel" OnClick="Button4_Click" />
                                    </td>
                                    <td align="right">
                                        <table width="300px">
                                            <tr>
                                                <td>
                                                    <fieldset>
                                                        <legend>
                                                            <asp:Label ID="Label196" runat="server" Text="Print"></asp:Label>
                                                        </legend>
                                                        <table align="center" width="300px">
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Button ID="Button40" runat="server" Text="Scope Document" />
                                                                </td>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Button ID="Button41" runat="server" Text="Measurement Plan" />
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Button ID="Button42" runat="server" Text="Intake Form" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
