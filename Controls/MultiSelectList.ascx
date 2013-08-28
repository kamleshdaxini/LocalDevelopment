<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MultiSelectList.ascx.cs" Inherits="Controls_MultiselectList" %>
<link href="../App_Themes/StyleSheet.css" rel="stylesheet" />
<asp:UpdatePanel ID="upnlMultiSelectlist" UpdateMode="Always" ChildrenAsTriggers="true" EnableViewState="true" runat="server">
    <ContentTemplate>
        <div class="Myclass" style="z-index:2;" >
            <asp:TextBox ID="txtMultiSelectlist" runat="server" Width="80%" SkinID="multiselectddl" ></asp:TextBox>
            <asp:PopupControlExtender ID="popcntexMultiSelectlist" runat="server"
                Enabled="True" TargetControlID="txtMultiSelectlist" PopupControlID="pnlMultiSelectlist"
                OffsetY="24">
            </asp:PopupControlExtender>
            <asp:Panel ID="pnlMultiSelectlist" runat="server" Height="116px" Width="30%" BorderStyle="Solid"
                BorderWidth="1px" Direction="LeftToRight" ScrollBars="Auto" BackColor="White"
                Style="display: none;z-index:-1;" BorderColor="#174760" SkinID="pos">
                <asp:CheckBoxList ID="cblMultiSelectlist" runat="server"
                    AutoPostBack="true" OnSelectedIndexChanged="cblMultiSelectlist_SelectedIndexChanged">
                </asp:CheckBoxList>
            </asp:Panel>
            <asp:RequiredFieldValidator ID="rfvMultiSelectlist" runat="server" ControlToValidate="txtMultiSelectlist" Display="None" ErrorMessage="Select Names" ValidationGroup="if"></asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="vceMultiSelectlist" runat="server" TargetControlID="rfvMultiSelectlist">
            </asp:ValidatorCalloutExtender>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
