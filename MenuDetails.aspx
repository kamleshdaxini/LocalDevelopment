<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MenuDetails.aspx.cs" Inherits="MenuDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <table width="100%" id="tblSetSize">
                <tr>
                    <td>
                        <table align="center">
                            <tr>
                                <td>
                                    <table align="left" width="500px" cellpadding="5" cellspacing="5">
                                        <tr>
                                            <td align="center" colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="150px">
                                                <asp:Label ID="lblMenuName" runat="server" Text="Menu Name:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMenuName" runat="server" Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="150px" valign="top">
                                                <asp:Label ID="lblSubMenu" runat="server" Text="Menu Description:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMenuDesc" runat="server" Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="150px" valign="top">
                                                <asp:Label ID="Label1" runat="server" Text="Status:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlMenuStatus" runat="server">
                                                    <asp:ListItem>&lt;&lt; Select &gt;&gt;</asp:ListItem>
                                                    <asp:ListItem>InActive</asp:ListItem>
                                                    <asp:ListItem Selected="True">Active</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                                                    ValidationGroup="Menu" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:RequiredFieldValidator ID="rfvMenuName" runat="server" ControlToValidate="txtMenuName"
                                                    ValidationGroup="Menu" ErrorMessage="Enter Menu Name" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceMenuName" TargetControlID="rfvMenuName" runat="server">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:RequiredFieldValidator ID="rfvMenuDesc" runat="server" ControlToValidate="txtMenuDesc"
                                                    ValidationGroup="Menu" ErrorMessage="Enter Menu Description" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceMenuDesc" TargetControlID="rfvMenuDesc" runat="server">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:CompareValidator ID="cvMenuStatus" runat="server" Operator="NotEqual" ErrorMessage="Select Menu Status"
                                                    ValidationGroup="Menu" Display="None" ValueToCompare="&lt;&lt; Select &gt;&gt;"
                                                    ControlToValidate="ddlMenuStatus"></asp:CompareValidator>
                                                <asp:ValidatorCalloutExtender ID="vceMenuStatus" TargetControlID="cvMenuStatus"
                                                    runat="server">
                                                </asp:ValidatorCalloutExtender>
                                                <uc:message ID="msgMenu" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <uc:loader ID="lsoaderMenu" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
