<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/EditPage.Master"
    AutoEventWireup="true" CodeBehind="Basic_Org_Edit.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Basic_Org_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function setOrgSearchValue(orgId, orgName) {
            $("#<%=this.hfOrgParentId.ClientID%>").attr("value", orgId);
            $("#<%=this.txtOrgParentName.ClientID%>").attr("value", orgName);
            $.ligerDialog.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    <a href="Basic_Org_List.aspx?UserId=<%=this.UserId%>" class="back">后退</a>网点机构编辑
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
                    网点机构号码：
                </th>
                <td>
                    <asp:TextBox ID="txtOrgNumber" runat="server" CssClass="txtInput normal" MaxLength="16" />
                    <asp:RequiredFieldValidator ID="rfvOrgNumber" runat="server" ControlToValidate="txtOrgNumber"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    网点机购名称：
                </th>
                <td>
                    <asp:TextBox ID="txtOrgName" runat="server" CssClass="txtInput normal" MaxLength="32" />
                    <asp:RequiredFieldValidator ID="rfvOrgName" runat="server" ControlToValidate="txtOrgName"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    网点机购地址：
                </th>
                <td>
                    <asp:TextBox ID="txtOrgAddress" runat="server" CssClass="txtInput normal" MaxLength="64" />
                    <asp:RequiredFieldValidator ID="rfvOrgAddress" runat="server" ControlToValidate="txtOrgAddress"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    上级网点机构：
                </th>
                <td>
                    <asp:TextBox ID="txtOrgParentName" runat="server" ReadOnly="true" CssClass="txtInput normal"
                        MaxLength="32" />
                    <asp:HiddenField ID="hfOrgParentId" runat="server" />
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
