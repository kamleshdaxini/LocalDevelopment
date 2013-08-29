<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SubMenuList.aspx.cs" Inherits="SubMenuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel ID="upnl" runat="server">
        <Triggers>
            <asp:PostBackTrigger  ControlID="imbSubMenuHelp" />
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
                                    <asp:ImageButton ID="imbSubMenuHelp" runat="server" ImageUrl="~/images/imgHelpIcon.png"
                                        OnClick="imbSubMenuHelp_Click" Height="26px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" colspan="2" height="100px">
                                    <table align="center" width="90%">
                                        <tr>
                                            <td width="100%">
                                                <fieldset>
                                                    <legend>
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label></legend>
                                                    <table width="600px" align="center" cellspacing="2" cellpadding="2">
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="lblcol" runat="server" Text="Column"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblope" runat="server" Text="Operator"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblVal1" runat="server" Text="Value"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CompareValidator ID="cvSMColumn" runat="server" ControlToValidate="ddlCol" Display="None"
                                                                    ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="SubMenu" ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceSMColumn" runat="server" TargetControlID="cvSMColumn">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td colspan="3">
                                                                <asp:RequiredFieldValidator ID="rfvSMValue" runat="server" Display="None" ErrorMessage="Enter Value"
                                                                    ValidationGroup="SubMenu" ControlToValidate="txtValMenuN"></asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceSMName" runat="server" TargetControlID="rfvSMValue">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCol" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCol_SelectedIndexChanged1"
                                                                        ToolTip="Select Column">
                                                                        <asp:ListItem Selected="True">Select Column</asp:ListItem>
                                                                        <asp:ListItem Value="SubMenuName">SubMenu Name</asp:ListItem>
                                                                        <asp:ListItem Value="MenuID">Menu Name</asp:ListItem>
                                                                        <asp:ListItem Value="IsActive">Status</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td id="tdOpeName" runat="server" visible="True">
                                                                    <asp:DropDownList ID="ddlOpeName" runat="server" ToolTip="Select Operator">
                                                                        <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                        <asp:ListItem Text="Like" Value="Like"></asp:ListItem>
                                                                        <asp:ListItem Text="Not like" Value="Not like"></asp:ListItem>
                                                                        <asp:ListItem Text="Equal to" Value="="></asp:ListItem>
                                                                        <asp:ListItem Text="Not equal to" Value="<>"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td id="tdOpeStatus" runat="server" visible="False">
                                                                    <asp:DropDownList ID="ddlOpeStatus" runat="server" ToolTip="Select Operator">
                                                                        <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                        <asp:ListItem Text="Equal to" Value="="></asp:ListItem>
                                                                        <asp:ListItem Text="Not equal to" Value="<>"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td id="tdVal" runat="server" visible="False" valign="middle">
                                                                    <asp:DropDownList ID="ddlVal" runat="server">
                                                                        <asp:ListItem Selected="True">Select Status</asp:ListItem>
                                                                        <asp:ListItem Value="Active" Text="Active"></asp:ListItem>
                                                                        <asp:ListItem Text="InActive" Value="InActive"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td id="tdUserValue" runat="server" valign="top">
                                                                    <asp:TextBox ID="txtValMenuN" runat="server" AutoPostBack="True"></asp:TextBox>
                                                                    <asp:AutoCompleteExtender ID="AutoComplete2" runat="server" BehaviorID="AutoCompleteEx"
                                                                        EnableCaching="true" Enabled="false" MinimumPrefixLength="0" ServiceMethod="GetCompletionList1"
                                                                        ShowOnlyCurrentWordInCompletionListItem="true" TargetControlID="txtValMenuN"
                                                                        UseContextKey="True">
                                                                    </asp:AutoCompleteExtender>
                                                                    <asp:TextBoxWatermarkExtender ID="tbwMenuN" runat="server" TargetControlID="txtValMenuN"
                                                                        WatermarkText="Type Value Here">
                                                                    </asp:TextBoxWatermarkExtender>
                                                                </td>
                                                                <td align="left" width="10%" valign="top">
                                                                    <asp:ImageButton ID="imbSearch" runat="server" OnClick="imbSearch_Click" ValidationGroup="SubMenu"
                                                                         ImageUrl="~/images/imgSearchIcon.png" />
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="imbRef" runat="server" ImageUrl="~/images/imgRefreshIcon.png" OnClick="imbRef_Click"
                                                                        ToolTip="Refresh" />
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
                                <td align="right" width="93%">
                                    <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New" OnClick="lnkAddNew_Click"></asp:LinkButton>
                                </td>
                                 <td align="right" valign="top" width="6%">
                                </td>
                                  <td align="right" valign="top" width="6%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <div style="width: 90%; height: 550px; overflow: auto;">
                                        <asp:GridView ID="grdSubMenuDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                            AllowPaging="True" OnPageIndexChanging="grdSubMenuDetails_PageIndexChanging">
                                            <PagerSettings PageButtonCount="10" />
                                              <HeaderStyle HorizontalAlign ="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SubMenu ID" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSuMeID" runat="server" Text='<%# Eval("SubMenuId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sr. No." ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSrNoSub" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SubMenu Name" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkSMName" runat="server" Text="SubMenu Name" ForeColor="White"
                                                            OnClick="lnkSMName_Click"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSuMeNa" runat="server" Text='<%# Eval("SubMenuName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SubMenu Description" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkSubDes" runat="server" Text="SubMenu Description" ForeColor="White"
                                                            OnClick="lnkSubDes_Click"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSuMeDes" runat="server" Text='<%# Eval("SubMenuDescription") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Menu Name" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkMeName" runat="server" Text="Menu Name" ForeColor="White"
                                                            OnClick="lnkMeName_Click"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMeNa" runat="server" Text='<%# Eval("MenuName") %>' CssClass='<%# Eval("MenuId")%>'>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkSMStatus" runat="server" Text="Status" ForeColor="White" OnClick="lnkSMStatus_Click"></asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIsActive" runat="server" CssClass='<%# Eval("IsActive") %>' Text='<%# Eval("IsActive") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate >
                                                        <%--   <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("SubMenuId") %>'
                                                            OnClick="lnkEdit_Click">Edit</asp:LinkButton>
                                                        <asp:ConfirmButtonExtender ID="cbeEdit" runat="server" ConfirmText="Are you sure you want to Edit record?"
                                                            TargetControlID="lnkEdit">
                                                        </asp:ConfirmButtonExtender>--%>
                                                        <asp:ConfirmButtonExtender ID="cbeEdit" runat="server" ConfirmText="Are you sure you want to edit record?"
                                                            TargetControlID="imbEdit">
                                                        </asp:ConfirmButtonExtender>
                                                        <asp:ImageButton ID="imbEdit" runat="server" CommandArgument='<%# Eval("SubMenuId") %>'
                                                            ImageUrl="~/images/imgEditIcon.png" ToolTip="Edit Menu" OnClick="imbEdit_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="5">
                                    <asp:CompareValidator ID="cvSMOpeartor" runat="server" ControlToValidate="ddlOpeName"
                                        Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                                        ValidationGroup="SubMenu" ValueToCompare="Select Operator"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceSMOpeartor" runat="server"
                                        TargetControlID="cvSMOpeartor">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvSMOpeStatus" runat="server" ControlToValidate="ddlOpeStatus"
                                        Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                                        ValidationGroup="SubMenu" ValueToCompare="Select Operator"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceSMOpeStatus" runat="server"
                                        TargetControlID="cvSMOpeStatus">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvVal" runat="server" ControlToValidate="ddlVal" Display="None"
                                        ErrorMessage="Select Status" Operator="NotEqual" ValidationGroup="SubMenu" ValueToCompare="Select Status">
                                    </asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceVal" runat="server" TargetControlID="cvVal">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc:message ID="MsgSubMenu" runat="server" />
                    </td>
                </tr>
            </table>
            <uc:loader ID="loaderSL" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
