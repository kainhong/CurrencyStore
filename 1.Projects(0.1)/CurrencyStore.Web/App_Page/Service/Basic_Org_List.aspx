<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Basic_Org_List.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Basic_Org_List" %>

<%@ Import Namespace="CurrencyStore.Entity" %>
<%@ Import Namespace="CurrencyStore.DataConvert" %>
<%@ Import Namespace="CurrencyStore.Common.ExtensionMethod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function batchDelete() {
            ExePostBack("#<%=this.btnDelete.ClientID%>");
        }
        function setOrgSearchValue(orgId, orgName) {
            $("#<%=this.hfOrgParentId.ClientID%>").attr("value", orgId);
            $("#<%=this.txtOrgParentName.ClientID%>").attr("value", orgName);
            $.ligerDialog.close();
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    网点机构列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
    <table>
        <tr>
            <td style="width: 200px; vertical-align: middle;">
                <a href="Basic_Org_Edit.aspx?UserId=<%=this.UserId%>" class="tools_btn"><span><b
                    class="add">添加数据</b></span></a> <a href="javascript:void(0);" onclick="checkAll(this);"
                        class="tools_btn"><span><b class="all">全选</b></span></a> <a href="javascript:batchDelete();"
                            class="tools_btn"><span><b class="delete">批量删除</b></span></a> <span style="display: none">
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" /></span>
            </td>
            <td>
                上级网点机构：
                <asp:TextBox ID="txtOrgParentName" MaxLength="32" runat="server" ReadOnly="true"
                    CssClass="txtInput" Width="250px"></asp:TextBox>
                <asp:HiddenField ID="hfOrgParentId" runat="server" />
                <br />
                网点机购号码：
                <asp:TextBox ID="txtOrgNumber" MaxLength="16" runat="server" CssClass="txtInput"></asp:TextBox>
                网点机购名称：
                <asp:TextBox ID="txtOrgName" MaxLength="32" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btnSearch" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphList" runat="server">
    <asp:GridView ID="gvList" CssClass="msgtable" runat="server" AutoGenerateColumns="False"
        GridLines="None" EmptyDataText="暂无数据" ShowHeaderWhenEmpty="True" DataKeyNames="PkId,OrgFullPath">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="cbSelect" CssClass="checkall" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="网点机构号码">
                <ItemTemplate>
                    <%#Eval("OrgNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="网点机购名称">
                <ItemTemplate>
                    <%#Eval("OrgName")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="网点机购地址">
                <ItemTemplate>
                    <span title='<%#Eval("OrgAddress")%>' style="cursor: pointer">
                        <%#Eval("OrgAddress").ToString().SubFullString(30, "...")%></span>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="上级号码">
                <ItemTemplate>
                    <%# Eval("OrgParentId").ToString().GetOrgNumber(true)%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="上级名称">
                <ItemTemplate>
                    <%#Eval("OrgParentId").ToString().GetOrgName(true)%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href='<%# "Basic_Org_Edit.aspx?UserId=" + this.UserId + "&PkId=" + Eval("PkId").ToString() %>'>
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
