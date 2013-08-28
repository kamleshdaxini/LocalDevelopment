<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GroupDetails.aspx.cs" Inherits="GroupDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <table width="100%" align="center" id="tblSetSize">
                <tr>
                    <td>
                        <table align="center">
                            <tr>
                                <td>
                                    <table align="left" width="500px" cellpadding="5" cellspacing="5">
                                        <tr>
                                            <td align="center" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="155px">
                                                <asp:Label ID="lblGroupName" runat="server" Text="Group Name:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtGroupName" runat="server" Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" width="155px" valign="top">
                                                <asp:Label ID="lblGroupDesc" runat="server" Text="Group description :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtGroupDesc" runat="server" Height="50px" TextMode="MultiLine"
                                                    Width="300px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top" width="155px">
                                                <asp:Label ID="lblGroupStatus" runat="server" Text="Group Status :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlGroupStatus" runat="server">
                                                    <asp:ListItem><< Select >></asp:ListItem>
                                                    <asp:ListItem>Inactive</asp:ListItem>
                                                    <asp:ListItem Selected="True">Active</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                                                    ValidationGroup="g" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" ControlToValidate="txtGroupName"
                                                    ValidationGroup="g" ErrorMessage="Enter Group Name" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceGroupName" TargetControlID="rfvGroupName" runat="server">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:RequiredFieldValidator ID="rfvGroupDesc" runat="server" ControlToValidate="txtGroupDesc"
                                                    ValidationGroup="g" ErrorMessage="Enter Group Description" Display="None"></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="vceGroupDesc" TargetControlID="rfvGroupDesc" runat="server">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:CompareValidator ID="cvGroupStatus" runat="server" Operator="NotEqual" ErrorMessage="Select Status"
                                                    ValidationGroup="g" Display="None" ValueToCompare="<< Select >>" ControlToValidate="ddlGroupStatus"></asp:CompareValidator>
                                                <asp:ValidatorCalloutExtender ID="vceGroupStatus" TargetControlID="cvGroupStatus" runat="server">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <uc:message ID="msgGroup" runat="server" />
            <uc:loader ID="loaderGroup" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
