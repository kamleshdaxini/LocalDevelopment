<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ContentLead.aspx.cs" Inherits="Content_Lead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="imbConLeadHelp" />
        </Triggers>
        <ContentTemplate>
            <table style="border: 1px none #7F9DB9; height: 650px;" width="100%" cellpadding="5"
                id="tblSetSize" cellspacing="5">
                <tr>
                    <td valign="top">
                        <table align="center" width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblSelectID" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="imbConLeadHelp" runat="server" ImageUrl="~/images/imgHelpIcon.png"
                                        OnClick="imbConLeadHelp_Click" Style="width: 26px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" height="100px" colspan="2">
                                    <table align="center" width="90%">
                                        <tr>
                                            <td width="100%">
                                                <fieldset>
                                                    <legend>
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label></legend>
                                                    <table width="600px" align="center" cellspacing="2" cellpadding="2">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblCol" runat="server" Text="Column"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblOpe" runat="server" Text="Operator"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblVal" runat="server" Text="Value"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvcolumn" runat="server" ControlToValidate="ddlCol" Display="None"
                                                                    ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="CL" ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceColumn" runat="server" TargetControlID="cvcolumn">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvOpe" runat="server" ControlToValidate="ddlOpe" Display="None"
                                                                    ErrorMessage="Select Operator" Operator="NotEqual" ValidationGroup="CL" ValueToCompare="Select Operator"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceOpe" runat="server" TargetControlID="cvOpe">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCol" runat="server">
                                                                    <asp:ListItem Selected="True">Select Column</asp:ListItem>
                                                                    <asp:ListItem Value="IsActive" Text="Status"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlOpe" runat="server" AutoPostBack="True">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="=" Text="Equal to"></asp:ListItem>
                                                                    <asp:ListItem Text="Not equal to" Value="<>"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlVal" runat="server" AutoPostBack="True">
                                                                    <asp:ListItem Selected="True">Select Status</asp:ListItem>
                                                                    <asp:ListItem Value="Active" Text="Active"></asp:ListItem>
                                                                    <asp:ListItem Text="InActive" Value="InActive"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" width="10%" valign="top">
                                                                <asp:ImageButton ID="imbSearch" runat="server" OnClick="imbSearch_Click" ValidationGroup="CL"
                                                                    ImageUrl="~/images/imgSearchIcon.png" ToolTip="Search" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="imbRef" runat="server" ImageUrl="~/images/imgRefreshIcon.png"
                                                                    OnClick="imbRef_Click" ToolTip="Refresh" />
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
                                <td align="right" valign="top" width="93%">
                                    <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New" OnClick="lnkAddNew_Click"></asp:LinkButton>
                                </td>
                                <td align="right" valign="top" width="6%">
                                </td>
                                <td align="right" valign="top" width="6%">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" colspan="2">
                                    <div style="width: 90%; height: 450px; overflow: auto; text-align: left;">
                                        <asp:GridView ID="GrdContentLead" runat="server" AutoGenerateColumns="False" Width="100%"
                                            AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GrdContentLead_PageIndexChanging">
                                              <HeaderStyle HorizontalAlign ="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. No." ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSrNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Content Lead">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkUserName" runat="server" Text="Content Lead" ForeColor="White"
                                                            OnClick="lnkUserName_Click"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUser" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkStatus" runat="server" Text="Status" ForeColor="White" OnClick="lnkStatus_Click"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lnkStatus" runat="server" Text='<%# Eval("IsActive") %>' CssClass='<%# Eval("IsActive") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("ContentLeadId") %>'
                                                            OnClick="lnkEdit_Click">Activate/Deactivate</asp:LinkButton>
                                                        <asp:ConfirmButtonExtender ID="cbeConLeadEdit" runat="server" ConfirmText="Are you sure you want to change status?"
                                                            TargetControlID="lnkEdit">
                                                        </asp:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="cvVal" runat="server" ControlToValidate="ddlVal" Display="None"
                                        ErrorMessage="Select Status" Operator="NotEqual" ValidationGroup="CL" ValueToCompare="Select Status"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceVal" runat="server" TargetControlID="cvVal">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlContentLead" runat="server" Width="400px" align="center" Height="250px"
                            SkinID="popuppan">
                            <table width="100%" cellpadding="6" cellspacing="6">
                                <tr>
                                    <td colspan="2" align="right">
                                        <asp:ImageButton ID="imbClose" runat="server" ImageUrl="~/images/imgPopupCloseButton.png"
                                            SkinID="closepop" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Label ID="lblTitle" runat="server" Text="Content Lead Details"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="160px" valign="top">
                                        <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlConLeadUser" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" width="160px" valign="top">
                                        <asp:Label ID="l" runat="server" Text="Status:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlConLeadStatus" runat="server">
                                            <asp:ListItem Selected="True">Active</asp:ListItem>
                                            <asp:ListItem>InActive</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Content"
                                            OnClick="btnSave_Click" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:CompareValidator ID="cvConLeadUser" runat="server" Operator="NotEqual" ErrorMessage="Select User"
                                            ValidationGroup="Content" Display="None" ValueToCompare="&lt;&lt; Select &gt;&gt;"
                                            ControlToValidate="ddlConLeadUser"></asp:CompareValidator>
                                        <asp:ValidatorCalloutExtender ID="vceConLeadUser" TargetControlID="cvConLeadUser"
                                            runat="server">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Label ID="lblpane" runat="server"></asp:Label>
                        <asp:ModalPopupExtender ID="MpopUpConLead" PopupControlID="pnlContentLead" TargetControlID="lblpane"
                            CancelControlID="imbClose" runat="server" SkinID="modelpop">
                        </asp:ModalPopupExtender>
                        <uc:message ID="MsgConLead" runat="server" />
                        <uc:loader ID="LoaderConLead" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
