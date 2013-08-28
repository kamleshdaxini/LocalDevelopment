<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SubMenuDetails.aspx.cs" Inherits="SubMenuDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <table align="center">
                            <tr>
                                <td>
                                    <table align="left" width="500px" style="border: 1px none #153E7E;" cellpadding="5"
                                        cellspacing="5" id="tblSetSize">
                                        <tr>
                                            <td align="center" colspan="3">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblMenuName" runat="server" Text="Menu Name:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlMenu" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblSubMenuName" runat="server" Text="SubMenu Name:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSubMenuName" runat="server" Width="300px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="160px" valign="top">
                                                <asp:Label ID="lblSubMenu" runat="server" Text="SubMenu Description:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSubMenuDesc" runat="server" Width="300px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="160px" valign="top">
                                                <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlSubMenuStatus" runat="server" Width="150px">
                                                    <asp:ListItem>&lt;&lt; Select &gt;&gt;</asp:ListItem>
                                                    <asp:ListItem Selected="True">Active</asp:ListItem>
                                                    <asp:ListItem>InActive</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" width="160px">
                                                <asp:Label ID="lblURL" runat="server" Text="SubMenu URL:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtURL" runat="server" Width="300px"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                                                    Style="height: 26px" ValidationGroup="SubMenu" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:CompareValidator ID="cvMenu" runat="server" Operator="NotEqual" ErrorMessage="Select Menu Name"
                                                    ValidationGroup="SubMenu" Display="None" ControlToValidate="ddlMenu" ValueToCompare="&lt;&lt; Select &gt;&gt;"></asp:CompareValidator>
                                                <asp:ValidatorCalloutExtender ID="vceMenu" TargetControlID="cvMenu"
                                                    runat="server">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:RequiredFieldValidator ID="rfvSMName" runat="server" ControlToValidate="txtSubMenuName"
                                                    ValidationGroup="SubMenu" ErrorMessage="Enter SubMenu Name" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceSubMenuName" TargetControlID="rfvSMName" runat="server">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:RequiredFieldValidator ID="rfvSMDesc" runat="server" ControlToValidate="txtSubMenuDesc"
                                                    ValidationGroup="SubMenu" ErrorMessage="Enter SubMenu Description" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceSMDesc" TargetControlID="rfvSMDesc" runat="server">
                                                </asp:ValidatorCalloutExtender>
                                                &nbsp;<asp:CompareValidator ID="cvSMStatus" runat="server" Operator="NotEqual" ErrorMessage="Select SubMenu Status"
                                                    ValidationGroup="SubMenu" Display="None" ValueToCompare="&lt;&lt; Select &gt;&gt;" ControlToValidate="ddlSubMenuStatus"></asp:CompareValidator>
                                                <asp:ValidatorCalloutExtender ID="vceSMStatus" TargetControlID="cvSMStatus"
                                                    runat="server">
                                                </asp:ValidatorCalloutExtender>
                                                 <uc:message ID="msgSubMenu" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc:loader ID="loaderSL" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
