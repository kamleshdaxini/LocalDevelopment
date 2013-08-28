<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Loader.ascx.cs" Inherits="Controls_Loader" %>

<asp:UpdateProgress ID="upgrs" runat="server" AssociatedUpdatePanelID="upnl" DisplayAfter="0" DynamicLayout="true">
    <ProgressTemplate>
        <div class="overlay">
            <table width="100%" style="height: 100%">
                <tr>
                    <td align="center" valign="middle">
                        <asp:Panel ID="pnlLoader"
                            runat="server" Height="80px" Width="130px" SkinID="loaderpan">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblLoaoder" runat="server"
                                            Text="Loading...."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Image ID="imbLoader" runat="server" ImageUrl="~/images/imgLoaderIcon.gif" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
