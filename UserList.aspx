<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserList.aspx.cs" Inherits="UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
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
                             <td align="right" valign="middle" colspan="2">
                                    <asp:Label ID="lblSelectID" runat="server" Visible="False"></asp:Label>
                                    <asp:ImageButton ID="imguserhelp" runat="server" ImageUrl="~/images/imgHelpIcon.png" OnClick="imguserhelp_Click" Style="width: 26px" />
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
                                                                <asp:Label ID="lblcomn" runat="server" Text="Column"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lbloper" runat="server" Text="Operator"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblval" runat="server" Text="Value"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:CompareValidator ID="cvUserColumn" runat="server" ControlToValidate="ddlUserColumn"
                                                                    Display="None" ErrorMessage="Select Column" Operator="NotEqual" ValidationGroup="ul"
                                                                    ValueToCompare="Select Column"></asp:CompareValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceRoleColumn" runat="server" TargetControlID="cvUserColumn">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td align="left">
                                                            </td>
                                                            <td align="left">
                                                              
                                                            </td>
                                                            <td>
                                                                
                                                                <asp:RequiredFieldValidator ID="rfvUserVal" runat="server" ControlToValidate="txtUserValue"
                                                                    Display="None" ErrorMessage="Enter Value" ValidationGroup="ul" Enabled="False"></asp:RequiredFieldValidator>
                                                                <asp:ValidatorCalloutExtender ID="vceUserVal" runat="server" TargetControlID="rfvUserVal">
                                                                </asp:ValidatorCalloutExtender>
                                                            </td>
                                                            <td>
                                                               
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlUserColumn" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUserColumn_SelectedIndexChanged">
                                                                    <asp:ListItem Selected="True">Select Column</asp:ListItem>
                                                                    <asp:ListItem Value="FirstName">First Name</asp:ListItem>
                                                                    <asp:ListItem Value="LastName">Last Name</asp:ListItem>
                                                                    <asp:ListItem Value="eMail">Email</asp:ListItem>
                                                                    <asp:ListItem Value="IsActive">Status</asp:ListItem>
                                                                    <asp:ListItem Value="IsAdmin">IsAdmin</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" id="td1" runat="server" visible="true">
                                                                <asp:DropDownList ID="ddlUserOperator" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="LIKE">Like</asp:ListItem>
                                                                    <asp:ListItem Value="NOT LIKE">Not like</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="&lt;&gt;">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" id="td2" runat="server" visible="false">
                                                                <asp:DropDownList ID="ddlUserOpeSta" runat="server">
                                                                    <asp:ListItem Selected="True">Select Operator</asp:ListItem>
                                                                    <asp:ListItem Value="=">Equal to</asp:ListItem>
                                                                    <asp:ListItem Value="&lt;&gt;">Not equal to</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" id="td3" runat="server" visible="true" valign="top">
                                                                <asp:TextBox ID="txtUserValue" runat="server"></asp:TextBox>
                                                                <asp:TextBoxWatermarkExtender ID="tbwatmark" runat="server" TargetControlID="txtUserValue"
                                                                    WatermarkText="Type Value Here" />
                                                            </td>
                                                            <td align="left" id="td4" runat="server" visible="false">
                                                                <asp:DropDownList ID="ddlUserStatus" runat="server">
                                                                    <asp:ListItem Selected="True">Select Status</asp:ListItem>
                                                                    <asp:ListItem Value="true">Active</asp:ListItem>
                                                                    <asp:ListItem Value="false">InActive</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td id="td5" runat="server" align="left" visible="false">
                                                                <asp:DropDownList ID="ddlUserIsAdmin" runat="server">
                                                                    <asp:ListItem Selected="True">Select IsAdmin</asp:ListItem>
                                                                    <asp:ListItem Value="true">True</asp:ListItem>
                                                                    <asp:ListItem Value="false">False</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="center" width="10%" valign="top">
                                                                <asp:ImageButton ID="imbFilter" runat="server" OnClick="imbFilter_Click" ValidationGroup="ul"
                                                                    ImageUrl="~/images/imgSearchIcon.png" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="imbRefresh" runat="server" ImageUrl="~/images/imgRefreshIcon.png"
                                                                    OnClick="imbRefresh_Click" />
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
                                <td align="right"  width ="93%">
                                    <asp:LinkButton ID="lnkAddNew" runat="server" OnClick="lnkAddNew_Click" Text="Add New"></asp:LinkButton>
                                </td>
                                  <td align="left" valign="top"  width="6%">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <div style="width: 90%; height: 450px; overflow: auto;">
                                        <asp:GridView ID="grdUserDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                            AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grdUserDetails_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSrNo" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UserId" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="First Name" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkFirstName" runat="server" OnClick="lnkFirstName_Click" ForeColor="White">First Name</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFname" runat="server" Text='<%# Eval("Firstname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkLName" runat="server" OnClick="lnkLName_Click" ForeColor="White">Last Name</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLname" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UserName" Visible="False" ItemStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkEmailId" runat="server" OnClick="lnkEmailId_Click" ForeColor="White">Email</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("eMail") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkStatusUser" runat="server" ForeColor="White" OnClick="lnkStatusUser_Click">Status</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIsActive" runat="server" Text='<%# Eval("IsActive") %>' CssClass='<%# Eval("IsActive") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="IsAdmin">
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="lnkIsAdmin" runat="server" ForeColor="White" OnClick="lnkIsAdmin_Click">IsAdmin</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIsAdmin" runat="server" Text='<%# Eval("IsAdmin") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remark" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:ConfirmButtonExtender ID="cbeedit" runat="server" ConfirmText="Are you sure you want to edit record? "
                                                            TargetControlID="imbEdit">
                                                        </asp:ConfirmButtonExtender>
                                                        <asp:ImageButton ID="imbEdit" runat="server" CommandArgument='<%# Eval("UserId") %>'
                                                            ImageUrl="~/images/imgEditIcon.png" OnClick="imbEdit_Click" ToolTip="Edit User" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Permission">
                                                    <ItemTemplate>
                                                        <asp:ConfirmButtonExtender ID="cbeper" runat="server" ConfirmText="Are you sure you want to edit user permissions? "
                                                            TargetControlID="imbUserGRPer">
                                                        </asp:ConfirmButtonExtender>
                                                        <asp:ImageButton ID="imbUserGRPer" ToolTip="User Group Role Permission" CommandArgument='<%# Eval("UserId") %>'
                                                            runat="server" ImageUrl="~/images/imgPermissionIcon.png" OnClick="imbUserGRPer_Click" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    &nbsp;
                                    <asp:CompareValidator ID="cvUserOperator" runat="server" ControlToValidate="ddlUserOperator"
                                        Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                                        ValidationGroup="ul" ValueToCompare="Select Operator"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceUserOperator" runat="server" TargetControlID="cvUserOperator">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvUserOpeSta" runat="server" ControlToValidate="ddlUserOpeSta"
                                        Display="None" Enabled="False" ErrorMessage="Select Operator" Operator="NotEqual"
                                        ValidationGroup="ul" ValueToCompare="Select Operator"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceUserOpeSta" runat="server" TargetControlID="cvUserOpeSta">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvUserStatus" runat="server" ControlToValidate="ddlUserStatus"
                                        Display="None" Enabled="False" ErrorMessage="Select Status" Operator="NotEqual"
                                        ValidationGroup="ul" ValueToCompare="Select Status"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceUserStatus" runat="server" TargetControlID="cvUserStatus">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvUserIsAdmin" runat="server" ControlToValidate="ddlUserIsAdmin"
                                        Display="None" Enabled="False" ErrorMessage="Select IsAdmin" Operator="NotEqual"
                                        ValidationGroup="ul" ValueToCompare="Select IsAdmin"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceUserIsAdmin" runat="server" TargetControlID="cvUserIsAdmin">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <uc:message ID="msgUser" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <asp:Label ID="lblUs" runat="server" Text=""></asp:Label>
            </table>
            <uc:loader ID="loaderu" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
