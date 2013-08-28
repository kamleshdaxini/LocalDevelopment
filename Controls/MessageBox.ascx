<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MessageBox.ascx.cs"
    Inherits="WebUserControl" %>
<asp:Panel ID="pnlMessage" runat="server" BorderColor="#336699" BorderWidth="2px" Width="400px"
    BorderStyle="Solid" SkinID="msgshow">
    <table width="100%" bgcolor="White">
        <tr>
            <td align="right" colspan="2" bgcolor="#26759E" height="30px">
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblmessage" runat="server" Text="Message" ForeColor="White"
                                Font-Bold="True" Font-Size="12pt"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="imbPopClose" runat="server" ImageUrl="~/images/imgPopupCloseButton.png"
                                SkinID="closepop" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td align="center" width="50px">
                <asp:Image ID="imginfo" runat="server"
                    ImageUrl="~/images/imgInfoIcon.png" />
            </td>
            <td align="center" height="70px">
                <asp:Label ID="lblmsg" runat="server" Font-Size="11pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="35px">
                <asp:Button runat="server" Text="Ok" OnClick="btnok_Click" ID="btnok"
                    Width="50px" EnableTheming="True" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Label ID="lbltarget" runat="server" Text=""></asp:Label>
<asp:ModalPopupExtender ID="mpop" runat="server" TargetControlID="lbltarget" PopupControlID="pnlMessage"
    OkControlID="btnok" CancelControlID="imbPopClose">
</asp:ModalPopupExtender>
