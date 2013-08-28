<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TrainingReport.aspx.cs" Inherits="Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:Panel ID="pnltrainingreport" runat="server" ScrollBars="None">  
        <rsweb:ReportViewer ID="rptvwer" runat="server">
        </rsweb:ReportViewer>
    </asp:Panel>
</asp:Content>

