<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GroupList.aspx.cs" Inherits="GroupList" %>

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
                                <td align="right" colspan="2">
                                    <asp:Label ID="lblSelectID" runat="server" Visible="False"></asp:Label>
                                    <asp:ImageButton ID="imguserhelp" runat="server" ImageUrl="~/images/imgHelpIcon.png"
                                        OnClick="imguserhelp_Click" Style="width: 26px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" height="100px" colspan="2">
                                    <table align="center" width="90%">
                                        <tr>
                                            <td width="100%">
                                                <fieldset>
                                                    <legend>
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label></legend>
                                                    <table width="600px" align="center" cellspacing="2" cellpadding="2">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblCol" runat="server" Text="Column"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblOpe" runat="server" Text="Operator"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblVal" runat="server" Text="Value"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CompareValidator ID="cfvGrpcolumn" runat="server" ControlToValidate="ddlGrpCol"
                                                                    Display="None" ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="gl"
                                                                    ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="Vcerolecolumn" runat="server" TargetControlID="cfvGrpcolumn">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CompareValidator ID="cvGrpOpe" runat="server" ControlToValidate="ddlGrpOpe"
                                                                    Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                                                                    ValidationGroup="gl" ValueToCompare="Select Operator"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceGrpOpe" runat="server" TargetControlID="cvGrpOpe">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td></td>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlGrpCol" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGrpCol_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True">Select Column</asp:ListItem>
                                                                    <asp:ListItem Value="GroupName">Group Name</asp:ListItem>
                                                                    <asp:ListItem Value="IsActive">Status</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="td1" runat="server" align="left" visible="true">
                                                                <asp:DropDownList ID="ddlGrpOpe" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="LIKE">Like</asp:ListItem>
                                                                    <asp:ListItem Value="NOT LIKE">Not like</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="&lt;&gt;">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="td2" runat="server" align="left" visible="false">
                                                                <asp:DropDownList ID="ddlGrpOpeSta" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="&lt;&gt;">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="td3" runat="server" align="left" visible="true" valign="top">
                                                                <asp:TextBox ID="txtGrpValue" runat="server"></asp:TextBox>
                                                                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtGrpValue"
                                                                    WatermarkText="Type Value Here" />
                                                            </td>
                                                            <td id="td4" runat="server" align="left" visible="false">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" Visible="False">
                                                                    <asp:ListItem Selected="True">Select Status</asp:ListItem>
                                                                    <asp:ListItem Value="true">Active</asp:ListItem>
                                                                    <asp:ListItem Value="false">InActive</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:TextBoxWatermarkExtender ID="tbwatmark" runat="server" TargetControlID="txtGrpValue"
                                                                    WatermarkText="Type Value Here" />
                                                            </td>
                                                            <td align="left" width="10%" valign="top">
                                                                <asp:ImageButton ID="imbFilter" runat="server" OnClick="imbFilter_Click" ValidationGroup="gl"
                                                                    ImageUrl="~/images/imgSearchIcon.png" />
                                                            </td>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="imbRefresh" runat="server" ImageUrl="~/images/imgRefreshIcon.png"
                                                    OnClick="imbRefresh_Click" Style="height: 32px" ToolTip="Refresh" />
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
                        <asp:LinkButton ID="lnkAddNew0" runat="server" OnClick="lnkAddNew_Click" Text="Add New"></asp:LinkButton>
                    </td>
                    <td align="left" valign="top" width="6%"></td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <div style="width: 90%; height: 450px; overflow: auto;">
                            <asp:GridView ID="grdGroupDetails" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" OnPageIndexChanging="grdGroupDetails_PageIndexChanging"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSrNo" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GroupId" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGID" runat="server" Text='<%# Eval("GroupId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Name" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lnkgrp" runat="server" ForeColor="White" OnClick="lnkgrp_Click">Group Name</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGN" runat="server" Text='<%# Eval("GroupName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Description" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lnkgrpdesc" runat="server" ForeColor="White" OnClick="lnkgrpdesc_Click">Group Description</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGD" runat="server" Text='<%# Eval("GroupDescription") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lnkgrpstatus" runat="server" ForeColor="White" OnClick="lnkgrpstatus_Click">Status</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsActive" runat="server" CssClass='<%# Eval("IsActive") %>' Text='<%# Eval("IsActive") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ConfirmButtonExtender ID="cbtnedit" runat="server" ConfirmText="Are you sure you want to edit record? "
                                                TargetControlID="imbEdit">
                                            </asp:ConfirmButtonExtender>
                                            <asp:ImageButton ID="imbEdit" runat="server" CommandArgument='<%# Eval("GroupId") %>'
                                                ImageUrl="~/images/imgEditIcon.png" OnClick="imbEdit_Click" ToolTip="Edit Group" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:CompareValidator ID="cvGrpOpeSta" runat="server" ControlToValidate="ddlGrpOpeSta"
                            Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                            ValidationGroup="gl" ValueToCompare="Select Operator"></asp:CompareValidator>
                        <asp:CompareValidator ID="cvGrpSta" runat="server" ControlToValidate="ddlStatus"
                            Display="None" Enabled="False" ErrorMessage="Select Status" Operator="NotEqual"
                            ValidationGroup="gl" ValueToCompare="Select Status"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="rfvGrpValue" runat="server" ControlToValidate="txtGrpValue"
                            Display="None" ErrorMessage="Enter Value" ValidationGroup="gl"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfvGrpValue_ValidatorCalloutExtender" runat="server"
                            TargetControlID="rfvGrpValue">
                        </asp:ValidatorCalloutExtender>
                        <asp:ValidatorCalloutExtender ID="cvGrpSta_ValidatorCalloutExtender" runat="server"
                            TargetControlID="cvGrpSta">
                        </asp:ValidatorCalloutExtender>
                        <asp:ValidatorCalloutExtender ID="cvGrpOpeSta_ValidatorCalloutExtender" runat="server"
                            TargetControlID="cvGrpOpeSta">
                        </asp:ValidatorCalloutExtender>
                    </td>
                    <td></td>
                </tr>
            </table>
         
            <uc:message ID="msgGroup" runat="server" />
            <uc:loader ID="loaderGroup" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
