<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserDetails.aspx.cs" Inherits="User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntplh" runat="Server">
    <asp:UpdatePanel runat="server" ID="upnl">
        <ContentTemplate>
            <table align="center" bgcolor="White" width="100%">
                <tr>
                    <td>
                        <table align="center" width="600px" style="border: 1px none #153E7E;" cellpadding="5"
                            id="tblSetSize" cellspacing="5">
                            <tr>
                                <td align="center" colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="50px">
                                    &nbsp;
                                </td>
                                <td align="left" width="100px">
                                    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFName" runat="server" Width="250px"></asp:TextBox>
                                </td>
                                <td align="left" valign="bottom" width="150px">
                                    <asp:ImageButton ID="imbSearch" runat="server" ImageUrl="~/images/imgSearchIcon.png" OnClick="imbSearch_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="50px">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtLastName" runat="server" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="50px">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblUserEmail" runat="server" Text="Email :"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="50px">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtUserName" runat="server" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="50px">
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblUserStatus" runat="server" Text="User Status:"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:DropDownList ID="ddlUserStatus" runat="server">
                                        <asp:ListItem><< Select >></asp:ListItem>
                                        <asp:ListItem>InActive</asp:ListItem>
                                        <asp:ListItem Selected="True">Active</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="50px">
                                    
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblIsAdmin" runat="server" Text="Is Admin:"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:DropDownList ID="ddlIsAdmin" runat="server" Height="19px">
                                        <asp:ListItem><< Select >></asp:ListItem>
                                        <asp:ListItem>True</asp:ListItem>
                                        <asp:ListItem Selected="True">False</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" width="50px">
                                    &nbsp;
                                </td>
                                <td align="left" valign="top">
                                    <asp:Label ID="lblRemark" runat="server" Text="Remarks:"></asp:Label>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtRemarks" runat="server" Height="70px" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="u" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                                    &nbsp;
                                    <asp:Button ID="btnUserGroRol" runat="server" OnClick="btnUserGroRol_Click" Text="User - Group Roles"
                                        ValidationGroup="u" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;
                                </td>
                                <td align="center" colspan="3">
                                    <asp:RequiredFieldValidator ID="rfvFName" runat="server" ControlToValidate="txtFName"
                                        Display="None" ErrorMessage="Enter First Name" ValidationGroup="u"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceFName" runat="server" TargetControlID="rfvFName">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="rfvLName" runat="server" ControlToValidate="txtLastName"
                                        Display="None" ErrorMessage="Enter Last name" ValidationGroup="u"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceLName" runat="server" TargetControlID="rfvLName">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                        Display="None" ErrorMessage="Enter Email Address" ValidationGroup="u"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceEmail" runat="server" TargetControlID="rfvEmail">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                        Display="None" ErrorMessage="Enter UserName" ValidationGroup="u"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceUserName" runat="server" TargetControlID="rfvUserName">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtRemarks"
                                        Display="None" ErrorMessage="Enter Remarks" ValidationGroup="u"></asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="vceRemarks" runat="server" TargetControlID="rfvRemarks">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvStatus" runat="server" ControlToValidate="ddlUserStatus"
                                        Display="None" ErrorMessage="Select Status" Operator="NotEqual" ToolTip="Select Status"
                                        ValidationGroup="u" ValueToCompare="<< Select >>"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceStatus" runat="server" TargetControlID="cvStatus">
                                    </asp:ValidatorCalloutExtender>
                                    <asp:CompareValidator ID="cvAdmin" runat="server" ControlToValidate="ddlIsAdmin" Display="None"
                                        ErrorMessage="Select IsAdmin" Operator="NotEqual" ToolTip="Select IsAdmin" ValidationGroup="u"
                                        ValueToCompare="<< Select >>"></asp:CompareValidator>
                                    <asp:ValidatorCalloutExtender ID="vceAdmin" runat="server"
                                        TargetControlID="cvAdmin">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlUserDe" runat="server" BackColor="White" BorderColor="Black" SkinID="popuppan">
                <table width="100%" align="center">
                    <tr>
                        <td align="right" valign="top">
                            <asp:ImageButton ID="imbClose" runat="server" ImageUrl="~/images/imgPopupCloseButton.png"
                                SkinID="closepop" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <div style="width: 750px; height: 450px; overflow: auto" align="center">
                                <asp:GridView ID="grdUserDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                    AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grdUserDetails_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSrNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="First Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFName" runat="server" Text='<%# Eval("fname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLName" runat="server" Text='<%# Eval("lname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UserName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("displayName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("mail") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkSelect" runat="server" CommandArgument='<%# Eval("mail") %>'
                                                    OnClick="lnkSelect_Click" CssClass='<%# Eval("fname")+" "+Eval("lname")+" "+Eval("displayName") %>'>Select</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Label ID="lblTarget" runat="server" Text=""></asp:Label>
            <asp:ModalPopupExtender ID="mpopUser" PopupControlID="pnlUserDe" TargetControlID="lblTarget"
                CancelControlID="imbClose" runat="server" SkinID="modelpop">
            </asp:ModalPopupExtender>
            <uc:message ID="msgUser" runat="server" />
            <asp:Label ID="lbltar" runat="server" Text=""></asp:Label>
            <uc:loader ID="loaderu" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
