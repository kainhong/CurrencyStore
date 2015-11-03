<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Stat_Device_List.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Stat_Device_List" %>

<%@ Import Namespace="CurrencyStore.Entity" %>
<%@ Import Namespace="CurrencyStore.DataConvert" %>
<%@ Import Namespace="CurrencyStore.Utility.Extension" %>
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
    网点设备统计列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
    <table>
        <tr>
            <td style="width: 200px; vertical-align: middle;">
                <asp:LinkButton ID="btnExport" runat="server" CssClass="tools_btn" OnClick="btnExport_Click">
                <span><b class="export">导出Excel</b></span></asp:LinkButton>
            </td>
            <td>
                网点机构：
                <asp:TextBox ID="txtOrgName" MaxLength="32" runat="server" CssClass="txtInput" Width="250px"></asp:TextBox>
                <asp:HiddenField ID="hfOrgId" runat="server" />
                <br />
                设备类别：
                <asp:DropDownList ID="ddlDeviceKind" CssClass="select2" runat="server">
                </asp:DropDownList>
                设备型号：
                <asp:DropDownList ID="ddlDeviceModel" CssClass="select2" runat="server">
                </asp:DropDownList>
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
            <asp:TemplateField HeaderText="设备类别">
                <ItemTemplate>
                    <%#Eval("KindCode").ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceKind)%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="设备型号">
                <ItemTemplate>
                    <%#Eval("ModelCode").ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceModel)%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="设备数量">
                <ItemTemplate>
                    <%# Eval("Count").ToString().ToInt().ToString("#,###")%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageBox" runat="server">
    <webdiyer:AspNetPager ID="objANP" runat="server" HorizontalAlign="Right" Width="100%"
        ShowPageIndexBox="Never" Font-Size="12px" Wrap="False" AlwaysShow="True" FirstPageText="首页"
        LastPageText="末页" NextPageText="下一页" PageSize="15" PagingButtonSpacing="10px"
        PrevPageText="上一页" CustomInfoTextAlign="Left" ShowCustomInfoSection="Left" CustomInfoHTML="&amp;nbsp;&amp;nbsp;第&amp;nbsp;&lt;span style='color:Red'&gt;%CurrentPageIndex%&lt;/span&gt;&amp;nbsp;页&amp;nbsp;/&amp;nbsp;共&amp;nbsp;&lt;span style='color:Red'&gt;%PageCount%&lt;/span&gt;&amp;nbsp;页，共&amp;nbsp;&lt;span style='color:Red'&gt;%RecordCount%&lt;/span&gt;&amp;nbsp;条">
    </webdiyer:AspNetPager>
</asp:Content>
