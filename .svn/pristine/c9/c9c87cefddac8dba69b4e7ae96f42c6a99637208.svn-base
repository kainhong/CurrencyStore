<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/EditPage.Master"
    AutoEventWireup="true" CodeBehind="User_Info_Edit.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.User_Info_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function setOrgSearchValue(orgId, orgName) {
            $("#<%=this.hfOrgId.ClientID%>").attr("value", orgId);
            $("#<%=this.txtOrgName.ClientID%>").attr("value", orgName);
            $.ligerDialog.close();
        }   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    <a href="User_Info_List.aspx?UserId=<%=this.UserId%>" class="back">后退</a>用户信息编辑
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFormBody" runat="server">
    <table class="form_table">
        <col width="150px" />
        <tbody>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    用户帐户：
                </th>
                <td>
                    <asp:TextBox ID="txtUserAccount" runat="server" CssClass="txtInput normal" MaxLength="16" />
                    <asp:RequiredFieldValidator ID="rfvUserAccount" runat="server" ControlToValidate="txtUserAccount"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    用户密码：
                </th>
                <td>
                    <asp:TextBox ID="txtUserPwd" runat="server" CssClass="txtInput normal" MaxLength="16"
                        TextMode="Password" />
                    <asp:RequiredFieldValidator ID="rfvUserPwd" runat="server" ControlToValidate="txtUserPwd"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    用户昵称：
                </th>
                <td>
                    <asp:TextBox ID="txtUserNickName" runat="server" CssClass="txtInput normal" MaxLength="16" />
                    <asp:RequiredFieldValidator ID="rfvUserNickName" runat="server" ControlToValidate="txtUserNickName"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    电子邮件：
                </th>
                <td>
                    <asp:TextBox ID="txtUserEmail" runat="server" CssClass="txtInput normal" MaxLength="32" /><label></label>
                </td>
            </tr>
            <tr>
                <th>
                    联系电话：
                </th>
                <td>
                    <asp:TextBox ID="txtUserPhone" runat="server" CssClass="txtInput normal" MaxLength="16" /><label></label>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    用户角色：
                </th>
                <td>
                    <asp:DropDownList ID="ddlUserRole" CssClass="select2" runat="server" Width="150px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvUserRole" runat="server" ControlToValidate="ddlUserRole"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    网点机构：
                </th>
                <td>
                    <asp:TextBox ID="txtOrgName" runat="server" ReadOnly="true" CssClass="txtInput normal"
                        MaxLength="32" />
                    <asp:HiddenField ID="hfOrgId" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    用户状态：
                </th>
                <td>
                    <asp:DropDownList ID="ddlUserStatus" CssClass="select2" runat="server" Width="150px">
                        <asp:ListItem Text="启用" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFormFoot" runat="server">
    <asp:Button ID="btnSubmitContinue" runat="server" Text="提交后继续" CssClass="btnSubmit"
        ValidationGroup="Submit" OnClick="btnSubmit_Click" CommandName="SubmitContinue" />
    <asp:Button ID="btnSubmitReturn" runat="server" Text="提交后返回" CssClass="btnSubmit"
        ValidationGroup="Submit" OnClick="btnSubmit_Click" CommandName="SubmitReturn" />
</asp:Content>
