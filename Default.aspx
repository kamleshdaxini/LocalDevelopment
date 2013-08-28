<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <table width="800px" style="height: 300px" cellpadding="5" cellspacing="5" id="tblSetSize">
        <tr>
            <td colspan="2" align="center"></td>
        </tr>
        <tr>
            <td valign="middle">
                <asp:Image ID="imgHome" runat="server" ImageUrl="~/images/imgHomeIcon.png" />

            </td>
            <td valign="middle" align="left">
                <asp:Label ID="imgwelcome" runat="server" Text="Welcome to KPMG Data Hub" Font-Bold="True" Font-Names="Calibri" Font-Size="15pt" ForeColor="#0072BA"></asp:Label>              
            </td>
        </tr>
    </table>
</asp:Content>

