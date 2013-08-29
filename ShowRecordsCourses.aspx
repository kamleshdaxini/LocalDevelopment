<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation ="false" 
    CodeFile="ShowRecordsCourses.aspx.cs" Inherits="ShowRecords_Program" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <table style="border: 1px none #7F9DB9; height: 650px; width: 100%;" cellpadding="5"
                cellspacing="5" id="tblSetSize">
                <tr>
                    <td valign="top">
                        <table align="center" width="100%">
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" colspan="3" height="100px">
                                    <table align="center" width="90%">
                                        <tr>
                                            <td width="100%">
                                                <fieldset>
                                                    <legend>
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label></legend>
                                                    <table width="600px" align="center" cellspacing="2" cellpadding="2">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblCol" runat="server" Text="Column Name"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblOpe" runat="server" Text="Operator"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblValue" runat="server" Text="Value"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:CompareValidator ID="cvCol" runat="server" ControlToValidate="ddlCol" Display="None"
                                                                    ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="gl" ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceCol" runat="server" TargetControlID="cvCol">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:CompareValidator ID="cvOpe" runat="server" ControlToValidate="ddlOpe" Display="None"
                                                                    ErrorMessage="Select Operator" Operator="NotEqual" ValidationGroup="gl" ValueToCompare="Select Operator"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceOpe" runat="server" TargetControlID="cvOpe">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                                <asp:RequiredFieldValidator ID="rfvValue" runat="server" ControlToValidate="txtValue"
                                                                    Display="None" ErrorMessage="Enter Value" ValidationGroup="gl"></asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceValue" runat="server" TargetControlID="rfvValue">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td valign="top">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlCol" runat="server" AutoPostBack="True" Width="220px">
                                                                    <asp:ListItem Selected="True">Select Column</asp:ListItem>
                                                                    <asp:ListItem Value="DH ID#">DH ID#</asp:ListItem>
                                                                    <asp:ListItem Value="Training Need Name">Training Need Name</asp:ListItem>
                                                                    <asp:ListItem Value="Course/Program Title">Course/Program Title</asp:ListItem>
                                                                    <asp:ListItem Value="Portfolio Manager">Portfolio Manager</asp:ListItem>
                                                                    <asp:ListItem Value="Statckeholder Relationship Manager">Statckeholder Relationship Manager</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="td1" runat="server" align="left" visible="true">
                                                                <asp:DropDownList ID="ddlOpe" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="LIKE">Like</asp:ListItem>
                                                                    <asp:ListItem Value="NOT LIKE">Not like</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="&lt;&gt;">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="td2" runat="server" align="left" visible="false">
                                                                <asp:DropDownList ID="ddlOpeSta" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="&lt;&gt;">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="td3" runat="server" align="left" visible="true" valign="top">
                                                                <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                                                                <asp:TextBoxWatermarkExtender ID="tbwatmark" runat="server" TargetControlID="txtValue"
                                                                    WatermarkText="Type Value Here" />
                                                            </td>
                                                            <td id="td4" runat="server" align="left" visible="false" valign="top">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" Visible="False">
                                                                    <asp:ListItem Selected="True">Select Status</asp:ListItem>
                                                                    <asp:ListItem Value="true">Active</asp:ListItem>
                                                                    <asp:ListItem Value="false">InActive</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td valign="top" align="left" width="10%">
                                                                <asp:ImageButton ID="imbSearch" runat="server" OnClick="imbSearch_Click" ValidationGroup="gl"
                                                                    ImageUrl="~/images/imgSearchIcon.png" />
                                                            </td>
                                                            <td valign="top">
                                                                <asp:ImageButton ID="imbRefresh" runat="server" ImageUrl="~/images/imgRefreshIcon.png"
                                                                    OnClick="imbRefresh_Click" Style="height: 32px" ToolTip="Refresh" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="95%">
                                    <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New" OnClick="lnkAddNew_Click"></asp:LinkButton>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <div style="width: 90%; height: 450px; overflow: auto;">
                                        <asp:GridView ID="grdShowRecordsScope" runat="server" AutoGenerateColumns="False"
                                            Width="100%">
                                            <HeaderStyle HorizontalAlign ="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="DH ID#" ItemStyle-HorizontalAlign ="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDHID" runat="server" Text='<%# Eval("DH ID#") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Training Need Name" ItemStyle-HorizontalAlign ="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTraNeeNam" runat="server" Text='<%# Eval("Training Need Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Course/Program Title" ItemStyle-HorizontalAlign ="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCouTit" runat="server" Text='<%# Eval("Course/Program Title") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Portfolio Manager" ItemStyle-HorizontalAlign ="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPortMana" runat="server" Text='<%# Eval("Portfolio Manager") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Statckeholder Relationship Manager" ItemStyle-HorizontalAlign ="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRM" runat="server" Text='<%# Eval("Statckeholder Relationship Manager") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign ="Center">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imbEdit" runat="server" ImageUrl="~/images/imgEditIcon.png"
                                                             ToolTip="Edit Scope Document Course" onclick="imbEdit_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDuplicate" runat="server" OnClick="lnkDuplicate_Click">Duplicate</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <uc:message ID="msgScope" runat="server" />
            <uc:loader ID="loaderScope" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
