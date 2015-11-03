<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/EditPage.Master"
    AutoEventWireup="true" CodeBehind="Currency_Blacklist_Edit.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Currency_Blacklist_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    <a href="Currency_Blacklist_List.aspx?UserId=<%=this.UserId%>" class="back">后退</a>黑名单编辑
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFormBody" runat="server">
    <table class="form_table">
        <col width="150px" />
        <tbody>
            <tr>
                <th>
                    纸币种类：
                </th>
                <td>
                    <asp:DropDownList ID="ddlCurrencyKind" CssClass="select2" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCurrencyKind" runat="server" ControlToValidate="ddlCurrencyKind"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空" />
                </td>
            </tr>
            <tr>
                <th>
                    纸币面额：
                </th>
                <td>
                    <asp:TextBox ID="txtFaceAmount" runat="server" CssClass="txtInput normal" MaxLength="6" /><label>
                    </label>
                </td>
            </tr>
            <tr>
                <th>
                    纸币版本：
                </th>
                <td>
                    <asp:TextBox ID="txtCurrencyVersion" runat="server" CssClass="txtInput normal" MaxLength="5" /><label>
                    </label>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    纸币号码：
                </th>
                <td>
                    <asp:TextBox ID="txtCurrencyNumber" runat="server" CssClass="txtInput normal" MaxLength="16" />
                    <asp:RequiredFieldValidator ID="rfvCurrencyNumber" runat="server" ControlToValidate="txtCurrencyNumber"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空" />
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
