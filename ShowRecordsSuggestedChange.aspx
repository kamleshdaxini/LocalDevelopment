<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation ="true" 
    CodeFile="ShowRecordsSuggestedChange.aspx.cs" Inherits="SuggestedChangeShowRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <table style="border: 1px none #7F9DB9; height: 650px;" width="100%" cellpadding="5"
                cellspacing="5" id="tblSetSize">
                <tr>
                    <td valign="top">
                        <table align="center" width="100%">
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Label ID="lblSelectID" runat="server" Text="Label" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" height="100px" valign="top" colspan="2">
                                    <table align="center" width="90%">
                                        <tr>
                                            <td width="100%">
                                                <fieldset>
                                                    <legend>
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label>
                                                    </legend>
                                                    <table align="center" cellpadding="2" cellspacing="2" width="600px">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblColName" runat="server" Text="Column Name"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblOpe" runat="server" Text="Operator"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblVal" runat="server" Text="Value"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:CompareValidator ID="cvCol" runat="server" ControlToValidate="ddlColumn"
                                                                    Display="None" ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="gl"
                                                                    ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceCol" runat="server" TargetControlID="cvCol">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:CompareValidator ID="cvOpe" runat="server" ControlToValidate="ddlOperator"
                                                                    Display="None" ErrorMessage="Select Operator" Operator="NotEqual" ValidationGroup="gl"
                                                                    ValueToCompare="Select Operator"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceOpe" runat="server" TargetControlID="cvOpe">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="rfvValue" runat="server" ControlToValidate="txtValue"
                                                                    Display="None" ErrorMessage="Enter Value" ValidationGroup="gl"></asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceValue" runat="server" TargetControlID="rfvValue">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlColumn" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlColumn_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True">Select Column</asp:ListItem>
                                                                    <asp:ListItem Value="ID">ID</asp:ListItem>
                                                                    <asp:ListItem Value="Suggested Change Title">Suggested Change Title</asp:ListItem>
                                                                    <asp:ListItem Value="Suggested Change Date">Suggested Change Date</asp:ListItem>
                                                                    <asp:ListItem Value="IsActive">Status</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="td1" runat="server" align="left" visible="true">
                                                                <asp:DropDownList ID="ddlOperator" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="LIKE">Like</asp:ListItem>
                                                                    <asp:ListItem Value="NOT LIKE">Not like</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="&lt;&gt;">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="td2" runat="server" align="left" visible="false">
                                                                <asp:DropDownList ID="ddlOperSta" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="&lt;&gt;">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="td3" runat="server" align="left" valign="top" visible="true">
                                                                <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                                                                <asp:TextBoxWatermarkExtender ID="tbwatmark" runat="server" TargetControlID="txtValue"
                                                                    WatermarkText="Type Value Here" />
                                                            </td>
                                                            <td id="td4" runat="server" align="left" valign="top" visible="false">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" Visible="False">
                                                                    <asp:ListItem Selected="True">Select Status</asp:ListItem>
                                                                    <asp:ListItem Value="true">Active</asp:ListItem>
                                                                    <asp:ListItem Value="false">InActive</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td valign="top" align="left" width="10%">
                                                                <asp:ImageButton ID="imbSearch" runat="server" OnClick="imbSearch_Click" ValidationGroup="gl"
                                                                     ImageUrl="~/images/imgSearchIcon.png" />
                                                            </td>
                                                            <td valign="top">
                                                                <asp:ImageButton ID="imbRefresh" runat="server" ImageUrl="~/images/imgRefreshIcon.png" OnClick="imbRefresh_Click"
                                                                    Style="height: 32px" ToolTip="Refresh" />
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
                                <td align="right" width="95%">
                                    <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New" OnClick="lnkAddNew_Click"></asp:LinkButton>
                                </td>
                                <td align="right">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" colspan="2">
                                    <div style="width: 90%; height: 450px; overflow: auto;">
                                        <asp:GridView ID="GrdSuggestedChangeSR" runat="server" Width="100%" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSrNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSuggID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Suggested Change Title">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSuggChanTitle" runat="server" Text='<%# Eval("Suggested Change Title") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Suggested Change Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSuggChanDate" runat="server" Text='<%# Eval("Suggested Change Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imbEdit" runat="server" ImageUrl="~/images/imgEditIcon.png"
                                                            ToolTip="Edit Scope Document Program" OnClick="imbEdit_Click" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
