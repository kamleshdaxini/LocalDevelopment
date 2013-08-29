<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MenuList.aspx.cs" Inherits="MenuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="imbApplyFilter" />
            <asp:PostBackTrigger ControlID="imbMenuhelp"></asp:PostBackTrigger>
        </Triggers>
        <ContentTemplate>
            <table style="border: 1px none #7F9DB9; height: 650px;" width="100%" cellpadding="5"
                cellspacing="5" id="tblSetSize">
                <tr>
                    <td valign="top">
                        <table align="center" width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblSelectID" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="imbMenuhelp" runat="server" ImageUrl="~/images/imgHelpIcon.png"
                                        OnClick="imbMenuhelp_Click" Height="26px" />
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
                                                        <tr align="left">
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblColumn" runat="server" Text="Column"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblOperator" runat="server" Text="Operator"></asp:Label>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblValue" runat="server" Text="Value"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CompareValidator ID="cvMenuCol" runat="server" ControlToValidate="ddlMenuColumn"
                                                                    Display="None" ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="M"
                                                                    ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceMenuColumn" runat="server" TargetControlID="cvMenuCol">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td align="left">
                                                                <asp:RequiredFieldValidator ID="rfvMenuValue" runat="server" ControlToValidate="txtValue"
                                                                    Display="None" ErrorMessage="Enter Value" ValidationGroup="M"></asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceMenuName" runat="server" TargetControlID="rfvMenuValue">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" valign="top">
                                                                <asp:DropDownList ID="ddlMenuColumn" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMenuColumn_SelectedIndexChanged"
                                                                    ToolTip="Select Column">
                                                                    <asp:ListItem Selected="True" Value="Select Operator">Select Column</asp:ListItem>
                                                                    <asp:ListItem Value="MenuName">Menu Name</asp:ListItem>
                                                                    <asp:ListItem Value="IsActive">Status</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="tdMenuName" runat="server" align="center" valign="top" visible="True">
                                                                <asp:DropDownList ID="ddlOperator" runat="server" ToolTip="Select Operator">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Text="Like" Value="Like"></asp:ListItem>
                                                                    <asp:ListItem Text="Not like" Value="Not like"></asp:ListItem>
                                                                    <asp:ListItem Text="Equal to" Value="="></asp:ListItem>
                                                                    <asp:ListItem Text="Not equal to" Value="&lt;&gt;"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="tdStatus" runat="server" align="center" valign="top" visible="false">
                                                                <asp:DropDownList ID="ddlStatusOpe" runat="server" ToolTip="Select Operator">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Text="Equal to" Value="="></asp:ListItem>
                                                                    <asp:ListItem Text="Not equal to" Value="&lt;&gt;"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="tdValText" runat="server" align="center" valign="top">
                                                                <asp:TextBox ID="txtValue" runat="server" ToolTip="Enter Value"></asp:TextBox>
                                                                <asp:TextBoxWatermarkExtender ID="tbwatmarkValueBox" runat="server" TargetControlID="txtValue"
                                                                    WatermarkText="Enter Value here">
                                                                </asp:TextBoxWatermarkExtender>
                                                            </td>
                                                            <td id="tdVal" runat="server" valign="top" visible="False">
                                                                <asp:DropDownList ID="ddlVal" runat="server" AutoPostBack="True">
                                                                    <asp:ListItem Selected="True">Select Status</asp:ListItem>
                                                                    <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                                                    <asp:ListItem Text="InActive" Value="InActive"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:ImageButton ID="imbApplyFilter" runat="server" OnClick="imbApplyFilter_Click"
                                                                    ValidationGroup="M" ImageUrl="~/images/imgSearchIcon.png" />
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
                                    <div style="width: 90%; height: 450px; overflow: auto;">
                                        <asp:GridView ID="grdMenuList" runat="server" AutoGenerateColumns="False" Width="100%"
                                            AllowPaging="True" OnPageIndexChanging="grdMenuList_PageIndexChanging">
                                            <PagerSettings PageButtonCount="10" />
                                              <HeaderStyle HorizontalAlign ="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Menu ID" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMeID" runat="server" Text='<%# Eval("MenuId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sr. No." ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSrNOMenu" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Menu Name" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkMname" runat="server" Text="Menu Name" ForeColor="White" OnClick="lnkMname_Click"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkIDClick" runat="server" CommandArgument='<%# Eval("MenuId") %>'
                                                            Text='<%# Eval("MenuName") %>' CssClass='<%# Eval("MenuName") %>' OnClick="lnkIDClick"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Menu Description" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkMDescription" runat="server" Text="Menu Description" ForeColor="White"
                                                            OnClick="lnkMDescription_Click"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lnkMDesc" runat="server" Text='<%# Eval("MenuDescription") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkMStatus" runat="server" Text="Status" ForeColor="White" OnClick="lnkMStatus_Click"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lnkStatus" runat="server" Text='<%# Eval("IsActive") %>' CssClass='<%# Eval("IsActive") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:ConfirmButtonExtender ID="cbeEdit" runat="server" ConfirmText="Are you sure you want to edit record?"
                                                            TargetControlID="imbEdit">
                                                        </asp:ConfirmButtonExtender>
                                                        <asp:ImageButton ID="imbEdit" runat="server" CommandArgument='<%# Eval("MenuId") %>'
                                                            ImageUrl="~/images/imgEditIcon.png" ToolTip="Edit Menu" OnClick="imbEdit_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="cvMenuOpe" runat="server" ControlToValidate="ddlOperator"
                                        Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                                        ValidationGroup="M" ValueToCompare="Select Operator"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceMenuOpe" runat="server" TargetControlID="cvMenuOpe">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvMenuOpeSta" runat="server" ControlToValidate="ddlStatusOpe"
                                        Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                                        ValidationGroup="M" ValueToCompare="Select Operator"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceMenuOpeSta" runat="server" TargetControlID="cvMenuOpeSta">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvVal" runat="server" ControlToValidate="ddlVal" Display="None"
                                        ErrorMessage="Select Status" Operator="NotEqual" ValidationGroup="M" ValueToCompare="Select Status"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceVal" runat="server" TargetControlID="cvVal">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlMenu" runat="server" BackColor="White" BorderColor="Black" SkinID="popuppan"
                            Width="700px">
                            <table align="center" width="100%">
                                <tr>
                                    <td align="right" valign="top" colspan="2">
                                        <asp:ImageButton ID="imbClose" runat="server" ImageUrl="~/images/imgPopupCloseButton.png"
                                            SkinID="closepop" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblMeNa" runat="server" Font-Bold="True" Font-Size="20px" Text="Menu Name:"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblMenu" runat="server" Font-Bold="True" Font-Size="20px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <div style="width: 500px; height: 300px; overflow: auto" align="center">
                                            <asp:GridView ID="grdSubmenu" runat="server" AutoGenerateColumns="False" Width="400px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SubMenu Name">
                                                        <HeaderTemplate>
                                                            <asp:LinkButton ID="lnkSMName" runat="server" Text="SubMenu Name" ForeColor="White"
                                                                OnClick="lnkSMName_Click" CommandArgument='<%# Eval("MenuId") %>'></asp:LinkButton>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSuMeNa" runat="server" Text='<%# Eval("SubMenuName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <asp:Label ID="lbtarget" runat="server" Text=""></asp:Label>
                <asp:ModalPopupExtender ID="mpopMenu" PopupControlID="pnlMenu" TargetControlID="lbtarget"
                    CancelControlID="imbClose" runat="server" SkinID="modelpop">
                </asp:ModalPopupExtender>
            </table>
            <uc:message ID="MsgMenu" runat="server" />
            <uc:loader ID="LoaderML" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
