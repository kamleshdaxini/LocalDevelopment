<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Stakeholder.aspx.cs" Inherits="Stakeholder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="imbStakeholderHelp" />
        </Triggers>
        <ContentTemplate>
            <table style="border: 1px none #7F9DB9; height: 650px;" width="100%" cellpadding="5"
                cellspacing="5" id="tblSetSize">
                <tr>
                    <td valign="top">
                        <table align="center" width="100%">
                            <tr>
                                <td align="center" valign="top" colspan="2">
                                    <asp:Label ID="lblSelectID" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="imbStakeholderHelp" runat="server" ImageUrl="~/images/imgHelpIcon.png"
                                        OnClick="imbStakeholderHelp_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" height="100px" colspan="2">
                                    <table align="center" width="90%">
                                        <tr>
                                            <td width="100%">
                                                <fieldset>
                                                    <legend>
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label>
                                                    </legend>
                                                    <table align="center" cellpadding="2" cellspacing="2" width="600px">
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
                                                                <asp:CompareValidator ID="cvColumn" runat="server" ControlToValidate="ddlCol" Display="None"
                                                                    ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="Sta" ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceColoumn" runat="server" TargetControlID="cvColumn">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvOpe" runat="server" ControlToValidate="ddlOpe" Display="None"
                                                                    ErrorMessage="Select Operator" Operator="NotEqual" ValidationGroup="Sta" ValueToCompare="Select Operator"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceOpe" runat="server" TargetControlID="cvOpe">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCol" runat="server">
                                                                    <asp:ListItem Selected="True">Select Column</asp:ListItem>
                                                                    <asp:ListItem Text="Status" Value="IsActive"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlOpe" runat="server" AutoPostBack="True">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Text="Equal to" Value="="></asp:ListItem>
                                                                    <asp:ListItem Text="Not equal to" Value="&lt;&gt;"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlVal" runat="server" AutoPostBack="True">
                                                                    <asp:ListItem Selected="True">Select Status</asp:ListItem>
                                                                    <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                                                    <asp:ListItem Text="InActive" Value="InActive"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" width="10%" valign="top">
                                                                <asp:ImageButton ID="imbSearch" runat="server" OnClick="imbSearch_Click" ValidationGroup="Sta"
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
                    <td align="center" colspan="2">
                        <div style="width: 90%; height: 450px; overflow: auto; text-align: left;">
                            <asp:GridView ID="GrdStakeholder" runat="server" AutoGenerateColumns="False" Width="100%"
                                AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GrdStakeholder_PageIndexChanging">
                                  <HeaderStyle HorizontalAlign ="Center" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No." ItemStyle-HorizontalAlign="Center" HeaderStyle-Width ="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSrNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stakeholder">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lnkUserName" runat="server" ForeColor="White" OnClick="lnkUserName_Click"
                                                Text="Stakeholder"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUser" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lnkStatus" runat="server" ForeColor="White" OnClick="lnkStatus_Click"
                                                Text="Status"></asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lnkStatus" runat="server" CssClass='<%# Eval("IsActive") %>' Text='<%# Eval("IsActive") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate >
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("StakeholderId") %>'
                                                OnClick="lnkEdit_Click">Activate/Deactivate</asp:LinkButton>
                                            <asp:ConfirmButtonExtender ID="CBESEdit" runat="server" ConfirmText="Are you sure you want to change status?"
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
                            ErrorMessage="Select Status" Operator="NotEqual" ValidationGroup="Sta" ValueToCompare="Select Status"></asp:CompareValidator>
                        <asp:ValidatorCalloutExtender ID="vceVal" runat="server" TargetControlID="cvVal">
                        </asp:ValidatorCalloutExtender>
                        <uc:message ID="MsgStak" runat="server" />
                    </td>
                </tr>
                </tr>
            </table>
            <uc:loader ID="LoaderS" runat="server" />
            <asp:Panel ID="pnlStak" runat="server" align="center" Height="250px" SkinID="popuppan"
                Width="400px">
                <table cellpadding="6" cellspacing="6" width="100%">
                    <tr>
                        <td align="right" colspan="2">
                            <asp:ImageButton ID="imbClose" runat="server" ImageUrl="~/images/imgPopupCloseButton.png"
                                SkinID="closepop" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblTitle" runat="server" Text="Stakeholder Details"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="160px">
                            <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlStakUser" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="160px">
                            <asp:Label ID="lblStat" runat="server" Text="Status:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlStakStatus" runat="server">
                                <asp:ListItem Selected="True">Active</asp:ListItem>
                                <asp:ListItem>InActive</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save"
                                ValidationGroup="S" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:CompareValidator ID="cvSUser" runat="server" ControlToValidate="ddlStakUser"
                                Display="None" ErrorMessage="Select User" Operator="NotEqual" ValidationGroup="S"
                                ValueToCompare="&lt;&lt; Select &gt;&gt;"></asp:CompareValidator>
                            <asp:ValidatorCalloutExtender ID="vceSUser" runat="server" TargetControlID="cvSUser">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Label ID="Lblpane" runat="server"></asp:Label>
            <asp:ModalPopupExtender ID="MPopUpStak" runat="server" CancelControlID="imbClose"
                PopupControlID="pnlStak" SkinID="modelpop" TargetControlID="Lblpane">
            </asp:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
