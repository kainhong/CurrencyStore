<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/EditPage.Master"
    AutoEventWireup="true" CodeBehind="User_Role_Edit.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.User_Role_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .treeview td
        {
            padding: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    <a href="User_Role_List.aspx?UserId=<%=this.UserId%>" class="back">后退</a>角色信息编辑
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
                    角色名称：
                </th>
                <td>
                    <asp:TextBox ID="txtRoleName" runat="server" CssClass="txtInput normal" MaxLength="16" />
                    <asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ControlToValidate="txtRoleName"
                        ValidationGroup="Submit" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    数据过滤：
                </th>
                <td>
                    <asp:DropDownList ID="ddlDataFilter" CssClass="select2" runat="server" Width="150px">
                        <asp:ListItem Text="过滤" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="不过滤" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    角色状态：
                </th>
                <td>
                    <asp:DropDownList ID="ddlRoleStatus" CssClass="select2" runat="server" Width="150px">
                        <asp:ListItem Text="启用" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    角色权限：
                </th>
                <td>
                    <asp:TreeView ID="tvPermission" CssClass="treeview" runat="server" ShowCheckBoxes="Leaf"
                        ShowLines="True" ShowExpandCollapse="False">
                    </asp:TreeView>
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
