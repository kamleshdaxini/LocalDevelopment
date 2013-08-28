<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RoleDetails.aspx.cs" Inherits="RoleDetails" %>

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
                                            <td align="left" width="155px">
                                                <asp:Label ID="lblRoleName" runat="server" Text="Role Name:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtRoleName" runat="server" Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="155px" valign="top">
                                                <asp:Label ID="lblRoleDesc" runat="server" Text="Role description :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtRoleDesc" runat="server" Height="50px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" width="155px">
                                                <asp:Label ID="lblRoleStatus" runat="server" Text="Role Status :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlRoleStatus" runat="server">
                                                    <asp:ListItem><< Select >></asp:ListItem>
                                                    <asp:ListItem>InActive</asp:ListItem>
                                                    <asp:ListItem Selected="True">Active</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                                                    ValidationGroup="r" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:CompareValidator ID="cvRoleStatus" runat="server" ControlToValidate="ddlRoleStatus"
                                                    ErrorMessage="Select Status" Operator="NotEqual" ValidationGroup="r" Display="None"
                                                    ValueToCompare="<< Select >>"></asp:CompareValidator>
                                                <asp:ValidatorCalloutExtender ID="vceRoleStatus" runat="server" TargetControlID="cvRoleStatus">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ControlToValidate="txtRoleName"
                                                    Display="None" ErrorMessage="Enter Role Name" ValidationGroup="r"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceRoleName" runat="server" TargetControlID="rfvRoleName">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:RequiredFieldValidator ID="rfvRoleDesc" runat="server" ControlToValidate="txtRoleDesc"
                                                    Display="None" ErrorMessage="Enter Role Description" ValidationGroup="r"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceRoleDesc" runat="server"
                                                    TargetControlID="rfvRoleDesc">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <uc:message ID="msgRole" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <uc:loader ID="loaderRole" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
