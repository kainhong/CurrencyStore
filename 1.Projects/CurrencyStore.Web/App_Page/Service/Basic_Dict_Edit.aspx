<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/EditPage.Master"
    AutoEventWireup="true" CodeBehind="Basic_Dict_Edit.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Basic_Dict_Edit" %>

<%@ Import Namespace="CurrencyStore.DataConvert" %>
<%@ Import Namespace="CurrencyStore.Utility.Extension" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    <a href="Basic_Dict_List.aspx?UserId=<%=this.UserId%>&Kind=<%=this.Kind%>" class="back">
        后退</a>
    <%=this.Kind.GetDictKindText()%>编辑
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
                    字典数据键：
                </th>
                <td>
                    <asp:TextBox ID="txtDictKey" runat="server" CssClass="txtInput normal" MaxLength="2" />
                    <asp:RequiredFieldValidator ID="rfvDictKey" runat="server" ControlToValidate="txtDictKey"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空" /><asp:RegularExpressionValidator
                            ID="revDictKey" ControlToValidate="txtDictKey" ValidationGroup="Submit" ValidationExpression="^(0|100|\d{1,2})$"
                            runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="只能是0-99的正整数" />
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    字典数据值：
                </th>
                <td>
                    <asp:TextBox ID="txtDictValue" runat="server" CssClass="txtInput normal" MaxLength="32" />
                    <asp:RequiredFieldValidator ID="rfvDictValue" runat="server" ControlToValidate="txtDictValue"
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
