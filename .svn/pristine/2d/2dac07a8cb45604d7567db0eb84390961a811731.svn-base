<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="User_Role_List.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.User_Role_List" %>

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
    角色信息列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
    <table>
        <tr>
            <td style="width: 200px; vertical-align: middle;">
                <a href="User_Role_Edit.aspx?UserId=<%=this.UserId%>" class="tools_btn"><span><b
                    class="add">添加数据</b></span></a> <a href="javascript:void(0);" onclick="checkAll(this);"
                        class="tools_btn"><span><b class="all">全选</b></span></a> <a href="javascript:batchDelete();"
                            class="tools_btn"><span><b class="delete">批量删除</b></span></a> <span style="display: none">
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" /></span>
            </td>
            <td>
                角色名称：
                <asp:TextBox ID="txtRoleName" MaxLength="16" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btnSearch" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphList" runat="server">
    <asp:GridView ID="gvList" CssClass="msgtable" runat="server" AutoGenerateColumns="False"
        GridLines="None" EmptyDataText="暂无数据" ShowHeaderWhenEmpty="True" DataKeyNames="PkId">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="cbSelect" CssClass="checkall" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="角色名称">
                <ItemTemplate>
                    <%#Eval("RoleName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数据过滤">
                <ItemTemplate>
                    <%#Eval("DataFilter").ToString().GetDataFilterText()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="角色状态">
                <ItemTemplate>
                    <%#Eval("RoleStatus").ToString().GetRoleStatusText()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href='<%# "User_Role_Edit.aspx?UserId=" + this.UserId + "&PkId=" + Eval("PkId").ToString() %>'>
                        <img src="Image/edit.png" title="编辑" /></a>
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
