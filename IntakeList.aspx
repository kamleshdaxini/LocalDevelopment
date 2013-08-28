<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="IntakeList.aspx.cs" Inherits="IntakeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="imguserhelp" />
        </Triggers>
        <ContentTemplate>
            <table style="border: 1px none #7F9DB9; height: 650px; width: 100%;" cellpadding="5"
                cellspacing="5" id="tblSetSize">
                <tr>
                    <td valign="top">
                        <table align="center" width="100%">
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:ImageButton ID="imguserhelp" runat="server" ImageUrl="~/images/imgHelpIcon.png" OnClick="imguserhelp_Click" Style="width: 26px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" height="100px">
                                    <table align="center" width="90%">
                                        <tr>
                                            <td width="100%">
                                                <fieldset>
                                                    <legend>
                                                        <asp:Label ID="Label2" runat="server" Text="Search"></asp:Label>
                                                    </legend>
                                                    <table width="600px" align="center" cellspacing="2" cellpadding="2">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblifcolumn" runat="server" Text="Column"></asp:Label>
                                                                <asp:CompareValidator ID="cfvIFcolumn0" runat="server" ControlToValidate="ddlIFcolumn" Display="None" ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="if" ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="cfvIFcolumn0_ValidatorCalloutExtender" runat="server" TargetControlID="cfvIFcolumn0">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblifoperator" runat="server" Text="Operator"></asp:Label>
                                                                <asp:CompareValidator ID="cvIFOpe0" runat="server" ControlToValidate="ddlifoperator" Display="None" ErrorMessage="Select Operator" Operator="NotEqual" ValidationGroup="if" ValueToCompare="Select Operator"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="cvIFOpe0_ValidatorCalloutExtender" runat="server" TargetControlID="cvIFOpe0">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblifvalue" runat="server" Text="Value"></asp:Label>
                                                                <asp:RequiredFieldValidator ID="rfvIFValue0" runat="server" ControlToValidate="txtifValue" Display="None" ErrorMessage="Enter Value" ValidationGroup="if"></asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="rfvIFValue0_ValidatorCalloutExtender" runat="server" TargetControlID="rfvIFValue0">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlIFcolumn" runat="server" AutoPostBack="True">
                                                                    <asp:ListItem Selected="True">Select Column</asp:ListItem>
                                                                    <asp:ListItem Value="TrainingNeedName">Training Need Name</asp:ListItem>
                                                                    <asp:ListItem Value="StakeholderRelationshipManager">SRM</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td runat="server" align="left">
                                                                <asp:DropDownList ID="ddlifoperator" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="LIKE">Like</asp:ListItem>
                                                                    <asp:ListItem Value="NOT LIKE">Not like</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="&lt;&gt;">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td runat="server" align="left" id="tdvalue" visible="true" valign="top">
                                                                <asp:TextBox ID="txtifValue" runat="server"></asp:TextBox>
                                                                <asp:TextBoxWatermarkExtender ID="tbwatmark" runat="server" TargetControlID="txtifValue" WatermarkText="Type Value Here" />
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:ImageButton ID="btnFilter" runat="server" ImageUrl="~/images/imgSearchIcon.png" OnClick="btnFilter_Click" ValidationGroup="if" />
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:ImageButton ID="imgrefresh" runat="server" ImageUrl="~/images/imgRefreshIcon.png" ToolTip="Refresh" />
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
                                <td align="right" colspan="2" width="95%">
                                    <asp:Label ID="lblSelectID" runat="server" Visible="False"></asp:Label>
                                    <asp:LinkButton ID="btnAddNew" runat="server" Text="Add New"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <div style="width: 90%; height: 450px; overflow: auto;">
                                        <asp:GridView ID="grdIntakeDetails" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grdIntakeDetails_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSrNOMenu" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="IF ID" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfname" ForeColor="White" runat="server" Text='<%# Eval("IntakeId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="IF Date">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkDate" ForeColor="White" runat="server" OnClick="lnkDate_Click">IF Date</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbllname" runat="server" Text='<%# Eval("Origin_MeetingDate", "{0:MM/d/yyyy}")%>'   ></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Training Need Name">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkTrainingNeedName" ForeColor="White" runat="server" OnClick="lnkTrainingNeedName_Click">TrainingNeedName</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblusername" runat="server" Text='<%# Eval("TrainingNeedName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Stakeholder Relationship Manager">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkStkRelmng" ForeColor="White" runat="server" OnClick="lnkStkRelmng_Click">StakeholderRelationshipManager</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmail" runat="server" Text='<%# FormatCombinedAccessions((Convert.ToString(Eval("StakeholderRelationshipManager")))) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ConfirmButtonExtender ID="cbtnedit" runat="server" ConfirmText="Are you sure you want to edit record? "
                                                            TargetControlID="imbEdit">
                                                        </asp:ConfirmButtonExtender>
                                                        <asp:ImageButton ID="imbEdit" runat="server" CommandArgument='<%# Eval("IntakeId") %>'
                                                            ImageUrl="~/images/imgEditIcon.png" OnClick="imbEdit_Click" ToolTip="Edit Group" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <uc:loader ID="loadif" runat="server" />
            <uc:message ID="msgIf" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
