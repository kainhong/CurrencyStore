<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/EditPage.Master"
    AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.ModifyPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    密码修改
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
                    旧密码：
                </th>
                <td>
                    <asp:TextBox ID="txtOldPwd" TextMode="Password" runat="server" CssClass="txtInput normal"
                        MaxLength="16" />
                    <asp:RequiredFieldValidator ID="rfvOldPwd" runat="server" ControlToValidate="txtOldPwd"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空" />
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    新密码：
                </th>
                <td>
                    <asp:TextBox ID="txtNewPwd" TextMode="Password" runat="server" CssClass="txtInput normal"
                        MaxLength="16" />
                    <asp:RequiredFieldValidator ID="rfvNewPwd" runat="server" ControlToValidate="txtNewPwd"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空" />
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    确认新密码：
                </th>
                <td>
                    <asp:TextBox ID="txtNewPwd2" TextMode="Password" runat="server" CssClass="txtInput normal"
                        MaxLength="16" />
                    <asp:RequiredFieldValidator ID="rfvNewPwd2" runat="server" ControlToValidate="txtNewPwd2"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空" /><asp:CompareValidator
                            ID="cvNewPwd2" runat="server" ErrorMessage="两次新密码输入不一致" ControlToCompare="txtNewPwd"
                            ControlToValidate="txtNewPwd2" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFormFoot" runat="server">
    <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btnSubmit" ValidationGroup="Submit"
        OnClick="btnSubmit_Click" />
</asp:Content>
