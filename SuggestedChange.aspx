<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SuggestedChange.aspx.cs" Inherits="SuggestedChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <table style="border: 1px none #7F9DB9; height: 650px;" width="100%" cellpadding="5"
                cellspacing="5" id="tblSetSize">
                <tr>
                    <td valign="top">
                        <table align="center">
                            <tr>
                                <td>
                                    <fieldset>
                                        <table align="left" cellpadding="2" cellspacing="2" width="100%">
                                            <tr>
                                                <td align="left" width="155px">
                                                    <asp:Label ID="lblSuggChanID" runat="server" Text="Suggested Change ID:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                      <asp:Label ID="lblSuggID" runat="server" Text="1108" Width ="80%"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblSuggChanTitle" runat="server" Text="Suggested Change Title"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSuggChanTitle" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblSuggChanStatus" runat="server" Text="Suggested Change Status:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlSuggChanStatus" runat="server" Width="120px">
                                                        <asp:ListItem Value="true" Text="Active" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="false" Text="InActive"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" width="155px">
                                                    <asp:Label ID="lblSuggChanDate" runat="server" Text="Suggested Change Date:"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:CalendarExtender ID="calSuggChanDate" runat="server" TargetControlID="txtSuggChanDate" PopupButtonID="imgCalendar"
                                                        Enabled="True">
                                                    </asp:CalendarExtender>
                                                    <asp:TextBox ID="txtSuggChanDate" runat="server" Width="150px"></asp:TextBox>
                                                    <asp:ImageButton ID="imgCalendar" runat="server" SkinID="Calimg" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblSuggChanScope" runat="server" Text="Suggested Change Scope Details" SkinID="large"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    <asp:GridView ID="GrdSuggestedChangeSD" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Scope ID">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlSuggChanScopeID" runat="server" Width="60px" OnSelectedIndexChanged="ddlSuggChanScopeID_SelectedIndexChanged"
                                                        AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delivery Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDelDate" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCourseDate" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course Number">
                                                <ItemTemplate>
                                                    <asp:Label ID="ddlCourseNumber" runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stakeholder">
                                                <ItemTemplate>
                                                    <asp:Label ID="ddlStakeholder" runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stakeholder Relationship Manager">
                                                <ItemTemplate>
                                                    <asp:Label ID="ddlSRM" runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Portfolio Manager">
                                                <ItemTemplate>
                                                    <asp:Label ID="ddlPortMana" runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Suggested Change">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlSuggChan" runat="server">
                                                        <asp:ListItem Value="Update Content" Text="Update Content"></asp:ListItem>
                                                        <asp:ListItem Value="Modify Design" Text="Modify Design"></asp:ListItem>
                                                        <asp:ListItem Value="Expand to More Audiences" Text="Expand to More Audiences"></asp:ListItem>
                                                        <asp:ListItem Value="Retire Course" Text="Retire"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Course Evalution">
                                                <ItemTemplate>
                                                    <asp:Label ID="ddlCourseEval" runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" Text="Suggested Change Cite Resolution" SkinID="large"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    <asp:GridView ID="grdSuggChanCiteRes" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Cite Conclusion">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="lblCourseName" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cite Resolution">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="lblCourseDate" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Scope ID">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlScopeID" runat="server">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <fieldset style="float: right">
                                        <legend>Operation</legend>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="su" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                                        onclick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvSuggChanTitle" runat="server" ControlToValidate="txtSuggChanTitle"
                                        Display="None" ErrorMessage="Enter Suggested Change Title" ValidationGroup="su"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceSuggChanTitle" runat="server" TargetControlID="rfvSuggChanTitle">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="rfvSuggChanDate" runat="server" ControlToValidate="txtSuggChanDate"
                                        Display="None" ErrorMessage="Enter Suggested Change Date" ValidationGroup="su"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceSuggChanDate" runat="server" TargetControlID="rfvSuggChanDate">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <uc:message ID="msgSuggChan" runat="server" />
            <uc:loader ID="loaderSuggChan" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
