<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GroupRoleDetails.aspx.cs" Inherits="RoleDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
         <table width="100%" align="center">
                <tr>
                    <td>
                        <table align="center"  width="550px">
                            <tr>
                                <td >
                              
                                    <table align="center" 
                                        cellpadding="5" cellspacing="5">
                                        <tr>
                                            <td align="center" colspan="2">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 150px" width="300px">
                                                <asp:Label ID="lblGroupName" runat="server" Text="Group Name:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                  <asp:DropDownList ID="ddlGroupName" runat="server" Width="300px">                                                    
                                              </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblRoleName" runat="server" Text="Role Name:"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlRoleName" runat="server" Width="300px">
                                                    
                                               </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblGroupRoleStatus" runat="server" Text="Group Role Status :"></asp:Label>
                                            </td>
                                            <td align="left" >
                                               
                                                <asp:DropDownList ID="ddlGroupRoleStatus" runat="server">
                                                    <asp:ListItem><< Select >></asp:ListItem>
                                                    <asp:ListItem >InActive</asp:ListItem>
                                                    <asp:ListItem Selected="True">Active</asp:ListItem>
                                               </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" valign="middle">
                                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" 
                                                    ValidationGroup="gr" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                                                    Text="Cancel" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:CompareValidator ID="cvGroupName" runat="server" 
                                                    ControlToValidate="ddlGroupName" Display="None" ErrorMessage="Select Group Name" 
                                                    Operator="NotEqual" ValidationGroup="gr" ValueToCompare="&lt;&lt; Select &gt;&gt;"></asp:CompareValidator>
                                                <asp:ValidatorCalloutExtender ID="vceGroupName" runat="server" 
                                                    TargetControlID="cvGroupName">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:CompareValidator ID="cvRoleName" runat="server" 
                                                    ControlToValidate="ddlRoleName" Display="None" ErrorMessage="Select Role Name" 
                                                    Operator="NotEqual" ValidationGroup="gr" ValueToCompare="&lt;&lt; Select &gt;&gt;"></asp:CompareValidator>
                                                <asp:ValidatorCalloutExtender ID="vceRoleName" 
                                                    runat="server" TargetControlID="cvRoleName">
                                                </asp:ValidatorCalloutExtender>
                                                <asp:CompareValidator ID="cvStatus" runat="server" 
                                                    ControlToValidate="ddlGroupRoleStatus" Display="None" 
                                                    ErrorMessage="Select Status" Operator="NotEqual" ValidationGroup="gr" 
                                                    ValueToCompare="<< Select >>"></asp:CompareValidator>
                                                <asp:ValidatorCalloutExtender ID="vceStatus" 
                                                    runat="server" TargetControlID="cvStatus">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <uc:message ID="msgGroupRole" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                 
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
             <uc:loader ID="loaderGroupRole" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
