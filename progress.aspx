<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="progress.aspx.cs" Inherits="progress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" Runat="Server">
     <table style="border: 1px none #7F9DB9; height: 650px;" width="100%" cellpadding="5"
        id="tblSetSize" cellspacing="5">
        <tr>
            <td align="center">
                <h1>
                    Under Construction.....</h1>
                <asp:Image ID="imgConstruction" runat="server" ImageUrl="~/images/imgUnderConstruction.jpg" />
            </td>
        </tr>
    </table>
</asp:Content>

