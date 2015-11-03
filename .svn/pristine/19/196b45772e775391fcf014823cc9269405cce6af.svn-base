<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Data_Clear.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Data_Clear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function batchDelete() {
            ExePostBack("#<%=this.btnClear.ClientID%>");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    数据清理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphList" runat="server">
    <table cellpadding="8" cellspacing="8" border="0" style="width: 100%; margin: 20px;">
        <col width="150px" />
        <tbody>
            <tr>
                <td>
                    <asp:CheckBox ID="cbCurrencyInfo" CssClass="checkall" Text="采集明细" runat="server" />
                </td>
                <td rowspan="5" style="vertical-align: middle">
                    <a href="javascript:batchDelete();" class="tools_btn"><span><b class="delete">清理所选</b></span></a>
                    <span style="display: none">
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" />
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbBlackList" CssClass="checkall" Text="黑名单" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbDeviceInfo" CssClass="checkall" Text="设备信息" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbOrg" CssClass="checkall" Text="网点机构" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbUserlogin" CssClass="checkall" Text="登录日志" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageBox" runat="server">
</asp:Content>
