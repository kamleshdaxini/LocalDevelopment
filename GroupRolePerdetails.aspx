<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GroupRolePerdetails.aspx.cs" Inherits="GroupRolePerdetails" MaintainScrollPositionOnPostback="true"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <table style="border: 1px solid #7F9DB9; height: 650px;" width="100%" cellpadding="5"
                cellspacing="5" align="center" id="tblSetSize">
                <tr>
                    <td valign="top">
                        <table align="center" width="100%">
                            <tr>
                                <td valign="top" align="left">
                                    <table align="left" cellpadding="5" cellspacing="5">
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="lbltitle" runat="server" SkinID="large" Text="Group Role Permission Details"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="300px">
                                                <asp:Label ID="lblRoleName0" runat="server" Text="Group Name:"></asp:Label>
                                            </td>
                                            <td width="600px">
                                                <asp:DropDownList ID="cmbGroupName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbGroupName_SelectedIndexChanged"
                                                    Width="250px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <div style="width: 90%; height: 450px; overflow: auto;">
                                                    <asp:GridView ID="grdgrpdetails" runat="server" AutoGenerateColumns="False" o=""
                                                        Width="100%" AllowPaging="True" OnPageIndexChanging="grdgrpdetails_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr. No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label16" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Role Name">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="cmbRoleName" runat="server" Width="200px">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgrstatus" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkIsActive" runat="server" CommandArgument='<%# Eval("IsActive") %>'
                                                                        CssClass='<%# Eval("GroupRoleID") %>' OnClick="lnkIsActive_Click" Text='<%# Eval("IsActive") %>'
                                                                        ToolTip="Change Status"></asp:LinkButton>
                                                                    <asp:ConfirmButtonExtender ID="cbtnedit" runat="server" ConfirmText="Are you sure you want to change the status? "
                                                                        TargetControlID="lnkIsActive">
                                                                    </asp:ConfirmButtonExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkPermission" runat="server" CommandArgument='<%# Eval("GroupRoleID") %>'
                                                                        OnClick="lnkPermission_Click" ToolTip="Group Role Permission">Permission</asp:LinkButton>
                                                                    <asp:ConfirmButtonExtender ID="cbtnper" runat="server" ConfirmText="Are you sure you want to edit permission? "
                                                                        TargetControlID="lnkPermission">
                                                                    </asp:ConfirmButtonExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </div>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Panel ID="panel" runat="server" BackColor="White" BorderColor="Black" SkinID="popuppan"
                            Height="600px" Width="1200px">
                            <table style="height: 500px">
                                <tr>
                                    <td>
                                        <table width="100%" align="center">
                                            <tr>
                                                <td align="right" valign="top" colspan="4">
                                                    &nbsp;
                                                </td>
                                                <td align="right" colspan="3" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" colspan="3" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" colspan="3" valign="top">
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/imgPopupCloseButton.png"
                                                        SkinID="closepop" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2" valign="top">
                                                    <asp:Label ID="Label13" runat="server" SkinID="large" Text="Group :"></asp:Label>
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblGroup" runat="server" SkinID="large"></asp:Label>
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="Label15" runat="server" SkinID="large" Text="Role :"></asp:Label>
                                                    <asp:Label ID="lblRole" runat="server" SkinID="large"></asp:Label>
                                                </td>
                                                <td align="left" colspan="9" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top" colspan="2">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top" colspan="2">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top" colspan="2">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" colspan="2" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="center" valign="top">
                                                    <asp:LinkButton ID="LinkAddnNewp" runat="server" Font-Underline="True" OnClick="LinkAddnNewp_Click" ValidationGroup="grp"
                                                        >Add New</asp:LinkButton>
                                                </td>
                                                <td align="right" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="13">
                                                    <div style="width: 1100px; height: 450px; overflow: auto" align="center">
                                                        <asp:GridView ID="grdGrpView" runat="server" AutoGenerateColumns="False" Width="98%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr. No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label11" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Menu">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="cmbMenu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbMenu_SelectedIndexChanged"
                                                                            DropDownStyle="DropDownList" Width="300px">
                                                                        </asp:DropDownList>
                                                                        <asp:CompareValidator ID="cfvMenu" runat="server" ControlToValidate="cmbMenu" ErrorMessage="Select Menu"
                                                                            ValidationGroup="grp" ValueToCompare="<< Select >>" Operator="NotEqual" ToolTip="Select Menu"
                                                                            Display="None"></asp:CompareValidator>
                                                                        <asp:ValidatorCalloutExtender ID="vcMenu" runat="server" TargetControlID="cfvMenu">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sub Menu">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="cmbSubMenu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSubMenu_SelectedIndexChanged"
                                                                            Width="300px">
                                                                        </asp:DropDownList>
                                                                        <asp:CompareValidator ID="cfvSubMenu" runat="server" ControlToValidate="cmbSubMenu"
                                                                            ErrorMessage="Select SubMenu" ValidationGroup="grp" ValueToCompare="<< Select >>"
                                                                            Operator="NotEqual" ToolTip="Select SubMenu" Display="None"></asp:CompareValidator>
                                                                        <asp:ValidatorCalloutExtender ID="vcSubMenu" runat="server" TargetControlID="cfvSubMenu">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Permission">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="cmbPermission" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:CompareValidator ID="cfvPermission" runat="server" ControlToValidate="cmbPermission"
                                                                            ErrorMessage="Select Permission" ValidationGroup="grp" ValueToCompare="<< Select >>"
                                                                            ToolTip="Select Permission" Operator="NotEqual" Display="None"></asp:CompareValidator>
                                                                        <asp:ValidatorCalloutExtender ID="vcPermission" runat="server" TargetControlID="cfvPermission">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkisActive1" runat="server" CommandArgument='<%# Eval("IsActive") %>'
                                                                            ValidationGroup="grp" CssClass='<%# Eval("GroupRolePermissionID") %>' OnClick="lnkisActive1_Click"
                                                                            ToolTip="Status">Activate</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerSettings PageButtonCount="5" />
                                                            <RowStyle HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="13">
                                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="grp" />
                                                    &nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel0_Click" Text="Cancel" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="13">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Label ID="lbtarget" runat="server" Text=""></asp:Label>
                        <asp:ModalPopupExtender ID="mpop1" PopupControlID="panel" TargetControlID="lbtarget"
                            CancelControlID="ImageButton2" runat="server" SkinID="modelpop">
                        </asp:ModalPopupExtender>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <uc:message ID="msg1" runat="server" Visible="False" />
                    </td>
                </tr>
            </table>
            <uc:loader ID="loaderu" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
