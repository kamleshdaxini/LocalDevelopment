<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GroupRoleList.aspx.cs" Inherits="GroupRoleList" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <script type='text/javascript'>
        //debugger;
        //To Maintain Scrol Position after postback
        var scrollLeft = 0; //for horizontal scroll
        var scrollTop = 0; // For Vertical Scroll
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        function EndRequestHandler(sender, args) {
            document.getElementById('<%= btnTarget.ClientID %>').click();
            setScroll(); //set scroll at specific position
        }
        //function to set scroll position  of panel 
        function setScroll() {
            document.getElementById('<%= pnlPermission.ClientID %>').scrollLeft = scrollLeft;
            if (scrollTop == 0) {
                document.getElementById('<%= pnlPermission.ClientID %>').scrollTop = scrollTop;
            }
            else {
                document.getElementById('<%= pnlPermission.ClientID %>').scrollTop = scrollTop + 20;
            }
        }
        //function to save scroll position of panel 
        function saveScroll() {
            scrollLeft = document.getElementById('<%= pnlPermission.ClientID %>').scrollLeft;
            scrollTop = document.getElementById('<%= pnlPermission.ClientID %>').scrollHeight;
        }
    </script>
    <asp:UpdatePanel ID="upnl" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="imguserhelp" />
        </Triggers>
        <ContentTemplate>
            <table style="border: 1px none #7F9DB9; height: 650px;" width="100%" cellpadding="5"
                cellspacing="5" id="tblSetSize">
                <tr>
                    <td valign="top">
                        <table align="center" width="100%">
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Label ID="lblSelectID" runat="server" Visible="False"></asp:Label>
                                    <asp:ImageButton ID="imguserhelp" runat="server" ImageUrl="~/images/imgHelpIcon.png"
                                        OnClick="imguserhelp_Click" />
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
                                                                <asp:Label ID="lblCol" runat="server" Text="Column"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblOpe" runat="server" Text="Operator"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblVal" runat="server" Text="Value"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvGroupRoleCol" runat="server" ControlToValidate="ddlGroupRoleCol"
                                                                    Display="None" ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="grl"
                                                                    ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceGroupRoleCol" runat="server" TargetControlID="cvGroupRoleCol">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvGroupRoleOpe" runat="server" ControlToValidate="ddlGroupRoleOpe"
                                                                    Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                                                                    ValidationGroup="grl" ValueToCompare="Select Operator"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceGroupRoleOpe" runat="server" TargetControlID="cvGroupRoleOpe">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvGroupRoleVal" runat="server" ControlToValidate="txtGroupRoleVal"
                                                                    Display="None" ErrorMessage="Enter Value" ValidationGroup="grl"></asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceGroupRoleVal" runat="server" TargetControlID="rfvGroupRoleVal">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlGroupRoleCol" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupRoleCol_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True">Select Column</asp:ListItem>
                                                                    <asp:ListItem Value="GroupName">Group Name</asp:ListItem>
                                                                    <asp:ListItem Value="RoleName">Role Name</asp:ListItem>
                                                                    <asp:ListItem Value="IsActive">Status</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" id="td1" runat="server" visible="true">
                                                                <asp:DropDownList ID="ddlGroupRoleOpe" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="LIKE">Like</asp:ListItem>
                                                                    <asp:ListItem Value="NOT LIKE">Not like</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="<>">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" id="td2" runat="server" visible="false">
                                                                <asp:DropDownList ID="ddlGroupRoleOpeSta" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="<>">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" id="td3" runat="server" visible="true" valign="top">
                                                                <asp:TextBox ID="txtGroupRoleVal" runat="server"></asp:TextBox>
                                                                <asp:TextBoxWatermarkExtender ID="tbwatmarkGroupRoleVal" runat="server" TargetControlID="txtGroupRoleVal"
                                                                    WatermarkText="Type Value Here" />
                                                            </td>
                                                            <td align="left" id="td4" runat="server" visible="false">
                                                                <asp:DropDownList ID="ddlGroupRoleSta" runat="server">
                                                                    <asp:ListItem Selected="True">Select Status</asp:ListItem>
                                                                    <asp:ListItem Value="true">Active</asp:ListItem>
                                                                    <asp:ListItem Value="false">InActive</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" width="10%" valign="top">
                                                                <asp:ImageButton ID="imbFilter" runat="server" OnClick="imbFilter_Click" ValidationGroup="grl"
                                                                    ImageUrl="~/images/imgSearchIcon.png" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="imbRefresh" runat="server" ImageUrl="~/images/imgRefreshIcon.png"
                                                                    OnClick="imbRefresh_Click" ToolTip="Refresh" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="95%">
                        <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New" OnClick="lnkAddNew_Click"></asp:LinkButton>
                    </td>
                    <td align="left" valign="top" width="6%">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <div style="width: 90%; height: 450px; overflow: auto;">
                            <asp:GridView ID="grdRoleDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grdRoleDetails_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSrNoRole" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GroupRoleId" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGrpRID" runat="server" Text='<%# Eval("GroupRoleId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Name" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lnkGrpName" runat="server" ForeColor="White" OnClick="lnkGrpName_Click">Group Name</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblGropName" runat="server" Text='<%# Eval("GroupName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Role Name" ItemStyle-HorizontalAlign="Left">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lnkRoleName" runat="server" ForeColor="White" OnClick="lnkRoleName_Click">Role Name</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRlName" runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="lnkGrpRolestStatus" runat="server" ForeColor="White" OnClick="lnkGrpRolestStatus_Click">Status</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("IsActive") %>' CssClass='<%# Eval("IsActive") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:ConfirmButtonExtender ID="cbeEdit" runat="server" ConfirmText="Are you sure you want to edit record? "
                                                TargetControlID="imbEdit">
                                            </asp:ConfirmButtonExtender>
                                            <asp:ImageButton ID="imbEdit" runat="server" CommandArgument='<%# Eval("GroupRoleId") %>'
                                                ImageUrl="~/images/imgEditIcon.png" OnClick="imbEdit_Click" ToolTip="Edit Group Role" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Permission">
                                        <ItemTemplate>
                                            <asp:ConfirmButtonExtender ID="cbePer" runat="server" ConfirmText="Are you sure you want to edit permission? "
                                                TargetControlID="imbPermission">
                                            </asp:ConfirmButtonExtender>
                                            <asp:ImageButton ID="imbPermission" runat="server" CommandArgument='<%# Eval("GroupRoleID") %>'
                                                ImageUrl="~/images/imgPermissionIcon.png" ToolTip="Group Role Permission" OnClick="imbpermission_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CompareValidator ID="cvGrpRoleOpeSta" runat="server" ControlToValidate="ddlGroupRoleOpeSta"
                            Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                            ValidationGroup="grl" ValueToCompare="Select Operator"></asp:CompareValidator>
                        <asp:ValidatorCalloutExtender ID="vceGrpRoleOpeSta" runat="server" TargetControlID="cvGrpRoleOpeSta">
                        </asp:ValidatorCalloutExtender>
                        <asp:CompareValidator ID="cvGrpRoleStatus" runat="server" ControlToValidate="ddlGroupRoleSta"
                            Display="None" Enabled="False" ErrorMessage="Select Status" Operator="NotEqual"
                            ValidationGroup="grl" ValueToCompare="Select Status"></asp:CompareValidator>
                        <asp:ValidatorCalloutExtender ID="vceGrpRoleStatus" runat="server" TargetControlID="cvGrpRoleStatus">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Panel ID="pnlGRper" runat="server" BackColor="White" BorderColor="Black" SkinID="popuppan"
                            Height="600px" Width="1200px">
                            <table style="height: 500px">
                                <tr>
                                    <td>
                                        <table width="100%" align="center">
                                            <tr>
                                                <td align="right" valign="top" colspan="4">
                                                    &nbsp;
                                                </td>
                                                <td align="right" colspan="3" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" colspan="3" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" colspan="3" valign="top">
                                                    <asp:ImageButton ID="imbClosePer" runat="server" ImageUrl="~/images/imgPopupCloseButton.png"
                                                        SkinID="closepop" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2" valign="top">
                                                    <asp:Label ID="lblGrpTitle" runat="server" SkinID="large" Text="Group :"></asp:Label>
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblGroup" runat="server" SkinID="large"></asp:Label>
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:Label ID="lblRolTitle" runat="server" SkinID="large" Text="Role :"></asp:Label>
                                                    <asp:Label ID="lblRole" runat="server" SkinID="large"></asp:Label>
                                                </td>
                                                <td align="left" colspan="9" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top" colspan="2">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top" colspan="2">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top" colspan="2">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" colspan="2" valign="top">
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top">
                                                    <asp:LinkButton ID="lnkAddNewPer" runat="server" Text="Add New" OnClick="lnkAddNewPer_Click"
                                                        OnClientClick="javascript:saveScroll();" ValidationGroup="grp" Font-Underline="True">Add New</asp:LinkButton>
                                                </td>
                                                <td align="right" valign="top">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="13">
                                                    <asp:Panel ID="pnlPermission" onscroll="javascript:saveScroll();" runat="server"
                                                        Height="450px" Width="1100px" Style="position: static; overflow: auto;">
                                                        <asp:GridView ID="grdGrpView" runat="server" AutoGenerateColumns="False" Width="98%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr. No.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSrNoGRper" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Menu">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlMenu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMenu_SelectedIndexChanged"
                                                                            DropDownStyle="DropDownList" Width="300px">
                                                                        </asp:DropDownList>
                                                                        <asp:CompareValidator ID="cvMenu" runat="server" ControlToValidate="ddlMenu" ErrorMessage="Select Menu"
                                                                            ValidationGroup="grp" ValueToCompare="<< Select >>" Operator="NotEqual" ToolTip="Select Menu"
                                                                            Display="None"></asp:CompareValidator>
                                                                        <asp:ValidatorCalloutExtender ID="vceMenu" runat="server" TargetControlID="cvMenu">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sub Menu">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlSubMenu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubMenu_SelectedIndexChanged"
                                                                            Width="300px">
                                                                        </asp:DropDownList>
                                                                        <asp:CompareValidator ID="cvSubMenu" runat="server" ControlToValidate="ddlSubMenu"
                                                                            ErrorMessage="Select SubMenu" ValidationGroup="grp" ValueToCompare="<< Select >>"
                                                                            Operator="NotEqual" ToolTip="Select SubMenu" Display="None"></asp:CompareValidator>
                                                                        <asp:ValidatorCalloutExtender ID="vceSubMenu" runat="server" TargetControlID="cvSubMenu">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Permission">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="ddlPermission" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:CompareValidator ID="cvPermission" runat="server" ControlToValidate="ddlPermission"
                                                                            ErrorMessage="Select Permission" ValidationGroup="grp" ValueToCompare="<< Select >>"
                                                                            ToolTip="Select Permission" Operator="NotEqual" Display="None"></asp:CompareValidator>
                                                                        <asp:ValidatorCalloutExtender ID="vcePermission" runat="server" TargetControlID="cvPermission">
                                                                        </asp:ValidatorCalloutExtender>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkIsActSta" runat="server" CommandArgument='<%# Eval("IsActive") %>'
                                                                            ValidationGroup="grp" CssClass='<%# Eval("GroupRolePermissionID") %>' OnClick="lnkIsActSta_Click"
                                                                            ToolTip="Status">Activate</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerSettings PageButtonCount="5" />
                                                            <RowStyle HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="13">
                                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="grp" />
                                                    &nbsp;
                                                    <asp:Button ID="btnCancelPer" runat="server" OnClick="btnCancelPer_Click" Text="Cancel" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="13">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <div id="divVisible" style="display: none;">
                            <asp:Button ID="btnTarget" runat="server" Text="Button" />
                        </div>
                        <asp:ModalPopupExtender ID="mpopGrpRole" PopupControlID="pnlGRper" TargetControlID="btnTarget"
                            CancelControlID="imbClosePer" runat="server" SkinID="modelpop">
                        </asp:ModalPopupExtender>
                        <uc:message ID="msgGrpRole" runat="server" />
                    </td>
                </tr>
            </table>
            </td> </tr> </table>
            <uc:loader ID="loaderGrpRole" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
