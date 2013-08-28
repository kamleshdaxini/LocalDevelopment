<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserGroupRoleDetails.aspx.cs" Inherits="UserPermissionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="imguserhelp" />
        </Triggers>
        <ContentTemplate>
            <table style="border: 1px none #7F9DB9; height: 650px;" width="100%" cellpadding="5"
                cellspacing="5" id="tblSetSize" align="center">
                <tr>
                    <td valign="top">
                        <table width="100%" align="center">
                            <tr>
                                <td align="right">&nbsp;
                                    <asp:ImageButton ID="imguserhelp" runat="server" ImageUrl="~/images/imgHelpIcon.png" OnClick="imguserhelp_Click" Style="width: 26px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table align="center">
                                        <tr>
                                            <td align="center" width="20%" valign="top">
                                                <asp:Label ID="lblUser" runat="server" Text="User: "></asp:Label>
                                            </td>
                                            <td align="left" width="80%">
                                                <asp:DropDownList ID="ddlUserName" runat="server" AutoPostBack="True"
                                                    Width="380px"
                                                    OnSelectedIndexChanged="ddlUserName_SelectedIndexChanged1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="95%">

                                    <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New"
                                        OnClick="lnkAddNew_Click" ValidationGroup="gr"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <div style="width: 90%; overflow: auto;">
                                        <asp:GridView ID="grdUserPerDetails" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSrNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Group Role">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlGroupRoleDetails" runat="server" Width="450px" AutoPostBack="True"
                                                            CssClass="<%# Container.DataItemIndex +1 %>" MaxLength="0" OnSelectedIndexChanged="ddlGroupRoleDetails_SelectedIndexChanged1">
                                                        </asp:DropDownList>
                                                        <asp:CompareValidator ID="ddlGroupRole" runat="server" ControlToValidate="ddlGroupRoleDetails"
                                                            ValueToCompare="<< Select >>" ErrorMessage="Select Group Role" ValidationGroup="gr"
                                                            Operator="NotEqual" ToolTip="Select Group Role" Display="Dynamic">
                                                            <asp:ValidatorCalloutExtender ID="VCEGroupRole" TargetControlID="ddlGroupRole" runat="server">
                                                            </asp:ValidatorCalloutExtender>
                                                        </asp:CompareValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                         <asp:ConfirmButtonExtender ID="cbeper" runat="server" ConfirmText="Are you sure you want to change status of user? "
                                                            TargetControlID="lblisactive">
                                                        </asp:ConfirmButtonExtender>
                                                        <asp:LinkButton ID="lblisactive" runat="server" CommandArgument='<%# Eval("IsActive") %>'
                                                            CssClass='<%# Eval("UserGroupRoleID") %>' OnClick="lblisactive_Click1">Activate/DeActivate</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">&nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                                    ValidationGroup="gr" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <uc:message ID="MsgGroup" runat="server" />
                                    <uc:loader ID="LoaderUGRD" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CompareValidator ID="cvUser" runat="server" ControlToValidate="ddlUserName"
                                        Display="None" ErrorMessage="Select User" Operator="NotEqual" ToolTip="Select User"
                                        ValidationGroup="gr" ValueToCompare="&lt;&lt; Select &gt;&gt;"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceUser" runat="server" TargetControlID="cvUser">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
