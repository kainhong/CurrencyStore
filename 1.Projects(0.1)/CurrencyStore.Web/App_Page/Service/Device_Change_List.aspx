<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Device_Change_List.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Device_Change_List" %>

<%@ Import Namespace="CurrencyStore.Entity" %>
<%@ Import Namespace="CurrencyStore.DataConvert" %>
<%@ Import Namespace="CurrencyStore.Common.ExtensionMethod" %>
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
    设备移动列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
    <table>
        <tr>
            <td style="width: 250px; vertical-align: middle;">
                &nbsp;
            </td>
            <td>
                <span id="spanOrg" runat="server">网点机构：
                    <asp:TextBox ID="txtOrgName" MaxLength="32" runat="server" CssClass="txtInput" Width="250px"></asp:TextBox>
                    <asp:HiddenField ID="hfOrgId" runat="server" />
                    <br />
                </span>设备号码：
                <asp:TextBox ID="txtDeviceNumber" MaxLength="16" runat="server" CssClass="txtInput"></asp:TextBox>
                注册地址：
                <asp:TextBox ID="txtRegisterIp" MaxLength="16" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btnSearch" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphList" runat="server">
    <asp:GridView ID="gvList" CssClass="msgtable" runat="server" AutoGenerateColumns="False"
        GridLines="None" EmptyDataText="暂无数据" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:TemplateField HeaderText="网点机构">
                <ItemTemplate>
                    <%#Eval("OrgId").ToString().GetOrgName()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="设备号码">
                <ItemTemplate>
                    <%#Eval("DeviceNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="软件版本">
                <ItemTemplate>
                    <%#Eval("SoftwareVersion")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="注册地址">
                <ItemTemplate>
                    <%#Eval("RegisterIp")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="当前地址">
                <ItemTemplate>
                    <%#Eval("DeviceIp")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="设备类别">
                <ItemTemplate>
                    <%# Eval("KindCode").ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceKind)%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="设备型号">
                <ItemTemplate>
                    <%#Eval("ModelCode").ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceModel)%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageBox" runat="server">
</asp:Content>
