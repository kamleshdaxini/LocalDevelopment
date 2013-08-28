<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RoleList.aspx.cs" Inherits="RoleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="imguserhelp" />
        </Triggers>
        <ContentTemplate>
            <table style="border: 1px none #7F9DB9; height: 650px;" width="100%" cellpadding="5"
                cellspacing="5" id="tblSetSize">
                <tr>
                    <td valign="top">
                        <table align="center" width="100%">
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Label ID="lblSelectID" runat="server" Visible="False"></asp:Label>
                                    <asp:ImageButton ID="imguserhelp" runat="server" ImageUrl="~/images/imgHelpIcon.png" OnClick="imguserhelp_Click" Style="width: 26px" />
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
                                                                <asp:CompareValidator ID="cvRoleColumn" runat="server" ControlToValidate="ddlRoleCol"
                                                                    Display="None" ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="rl"
                                                                    ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceRoleColumn" runat="server" TargetControlID="cvRoleColumn">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CompareValidator ID="cvRoleOperator" runat="server" ControlToValidate="ddlRoleOpe"
                                                                    Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                                                                    ValidationGroup="rl" ValueToCompare="Select Operator"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceRoleOperator" runat="server" TargetControlID="cvRoleOperator">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlRoleCol" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoleCol_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True">Select Column</asp:ListItem>
                                                                    <asp:ListItem Value="RoleName">Role Name</asp:ListItem>
                                                                    <asp:ListItem Value="IsActive">Status</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" id="td1" runat="server" visible="true">
                                                                <asp:DropDownList ID="ddlRoleOpe" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="LIKE">Like</asp:ListItem>
                                                                    <asp:ListItem Value="NOT LIKE">Not like</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="<>">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" id="td2" runat="server" visible="false">
                                                                <asp:DropDownList ID="ddlRoleOpeSta" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="<>">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" id="td3" runat="server" visible="true" valign="top">
                                                                <asp:TextBox ID="txtRoleValue" runat="server"></asp:TextBox>
                                                                <asp:TextBoxWatermarkExtender ID="tbwatmarkRoleValue" runat="server" TargetControlID="txtRoleValue"
                                                                    WatermarkText="Type Value Here" />
                                                            </td>
                                                            <td align="left" id="td4" runat="server" visible="false">
                                                                <asp:DropDownList ID="ddlRoleStatus" runat="server">
                                                                    <asp:ListItem Selected="True">Select Status</asp:ListItem>
                                                                    <asp:ListItem Value="true">Active</asp:ListItem>
                                                                    <asp:ListItem Value="false">InActive</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" width="10%" valign="top">
                                                                <asp:ImageButton ID="imbFilter" runat="server" OnClick="imbFilter_Click" ValidationGroup="rl"
                                                                    ImageUrl="~/images/imgSearchIcon.png" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="imbRefresh" runat="server" ImageUrl="~/images/imgRefreshIcon.png"
                                                                    OnClick="imbRefresh_Click" ToolTip="Refresh" />
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
                                <td align="right" width="93%">
                                    <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New" OnClick="lnkAddNew_Click"></asp:LinkButton>
                                </td>
                                <td align="left" valign="top" width="6%">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan ="2">
                                    <div style="width: 90%; height: 450px; overflow: auto;">
                                        <asp:GridView ID="grdRoleDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                            AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grdRoleDetails_PageIndexChanging">
                                            <PagerSettings Mode="Numeric" PageButtonCount="15" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSrNo" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="RoleId" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRID" runat="server" Text='<%# Eval("RoleId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Role Name" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkrolename" runat="server" OnClick="lnkrolename_Click" Text="Role Name"
                                                            ForeColor="White"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRN" runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Role Description" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkroledesc" runat="server" ForeColor="White" OnClick="lnkroledesc_Click">Role Description</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRD" runat="server" Text='<%# Eval("RoleDescription") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkstatussort" runat="server" OnClick="lnkstatussort_Click" ForeColor="White">Status</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("IsActive") %>' CssClass='<%# Eval("IsActive") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ConfirmButtonExtender ID="cbtnedit" runat="server" ConfirmText="Are you sure you want to edit record? "
                                                            TargetControlID="imbEdit">
                                                        </asp:ConfirmButtonExtender>
                                                        <asp:ImageButton ID="imbEdit" runat="server" CommandArgument='<%# Eval("RoleId") %>'
                                                            ImageUrl="~/images/imgEditIcon.png" OnClick="imbEdit_Click" ToolTip="Edit Role" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:CompareValidator ID="cvRoleOpe" runat="server" ControlToValidate="ddlRoleOpeSta"
                                        Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                                        ValidationGroup="rl" ValueToCompare="Select Operator"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceRoleOpe" runat="server" TargetControlID="cvRoleOpe">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvRoleOpeSta" runat="server" ControlToValidate="ddlRoleStatus"
                                        Display="None" Enabled="False" ErrorMessage="Select Status" Operator="NotEqual"
                                        ValidationGroup="rl" ValueToCompare="Select Status"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceRoleOpeSta" runat="server" TargetControlID="cvRoleOpeSta">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="rfvRoleValue" runat="server" ControlToValidate="txtRoleValue"
                                        Display="None" ErrorMessage="Enter Value" ValidationGroup="rl"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceRoleName" runat="server" TargetControlID="rfvRoleValue">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <uc:message ID="msgRole" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <uc:loader ID="loaderu" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
