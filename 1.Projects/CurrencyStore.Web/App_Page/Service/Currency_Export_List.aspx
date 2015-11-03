<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Currency_Export_List.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Currency_Export_List" %>

<%@ Import Namespace="CurrencyStore.Entity" %>
<%@ Import Namespace="CurrencyStore.DataConvert" %>
<%@ Import Namespace="CurrencyStore.Utility.Extension" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function batchDelete() {
            ExePostBack("#<%=this.btnDelete.ClientID%>");
        }    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    数据导出列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
    <table>
        <tr>
            <td style="width: 200px; vertical-align: middle;">
                <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b
                    class="all">全选</b></span></a> <a href="javascript:batchDelete();" class="tools_btn">
                        <span><b class="delete">批量删除</b></span></a> <span style="display: none">
                            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" /></span>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphList" runat="server">
    <asp:GridView ID="gvList" CssClass="msgtable" runat="server" AutoGenerateColumns="False"
        GridLines="None" EmptyDataText="暂无数据" ShowHeaderWhenEmpty="True" DataKeyNames="PkId,ExportStatus"
        OnRowDataBound="gvList_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="cbSelect" CssClass="checkall" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="网点机构">
                <ItemTemplate>
                    <%#Eval("OrgId").ToString().GetOrgName(true)%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="设备号码">
                <ItemTemplate>
                    <%#Eval("DeviceNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作开始时间">
                <ItemTemplate>
                    <%#Eval("OperateStartTime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作结束时间">
                <ItemTemplate>
                    <%#Eval("OperateEndTime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="纸币号码">
                <ItemTemplate>
                    <%#Eval("CurrencyNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="创建时间">
                <ItemTemplate>
                    <%#Eval("CreateTime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="导出状态">
                <ItemTemplate>
                    <%#Eval("ExportStatus").ToString().GetExportStatusText()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数据量">
                <ItemTemplate>
                    <%#Eval("DataCount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="文件大小">
                <ItemTemplate>
                    <%#Eval("FileSize")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a id="aDownload" runat="server" href='<%# this.ResolveClientUrl("~/App_File/Export/") + Eval("FileName").ToString("") %>'
                        target="_blank">
                        <img src="Image/download.png" title="下载" /></a>
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
