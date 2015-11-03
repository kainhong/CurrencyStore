<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="User_Info_List.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.User_Info_List" %>

<%@ Import Namespace="CurrencyStore.Entity" %>
<%@ Import Namespace="CurrencyStore.DataConvert" %>
<%@ Import Namespace="CurrencyStore.Common.ExtensionMethod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function batchDelete() {
            ExePostBack("#<%=this.btnDelete.ClientID%>");
        }
        function setOrgSearchValue(orgId, orgName) {
            $("#<%=this.hfOrgId.ClientID%>").attr("value", orgId);
            $("#<%=this.txtOrgName.ClientID%>").attr("value", orgName);
            $.ligerDialog.close();
        }     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    用户信息列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
    <table>
        <tr>
            <td style="width: 200px; vertical-align: middle;">
                <a href="User_Info_Edit.aspx?UserId=<%=this.UserId%>" class="tools_btn"><span><b
                    class="add">添加数据</b></span></a> <a href="javascript:void(0);" onclick="checkAll(this);"
                        class="tools_btn"><span><b class="all">全选</b></span></a> <a href="javascript:batchDelete();"
                            class="tools_btn"><span><b class="delete">批量删除</b></span></a> <span style="display: none">
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" /></span>
            </td>
            <td>
                网点机构：
                <asp:TextBox ID="txtOrgName" MaxLength="32" runat="server" ReadOnly="true" CssClass="txtInput"
                    Width="250px"></asp:TextBox>
                <asp:HiddenField ID="hfOrgId" runat="server" />
                <br />
                用户账户：
                <asp:TextBox ID="txtUserAccount" MaxLength="16" runat="server" CssClass="txtInput"></asp:TextBox>
                用户昵称：
                <asp:TextBox ID="txtUserNickName" MaxLength="16" runat="server" CssClass="txtInput"></asp:TextBox>
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
            <asp:TemplateField HeaderText="用户账户">
                <ItemTemplate>
                    <%#Eval("UserAccount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用户昵称">
                <ItemTemplate>
                    <%#Eval("UserNickName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="电子邮件">
                <ItemTemplate>
                    <%#Eval("UserEmail")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="联系电话">
                <ItemTemplate>
                    <%# Eval("UserPhone")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用户角色">
                <ItemTemplate>
                    <%#Eval("RoleId").ToString().GetRoleName()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="网点机构">
                <ItemTemplate>
                    <%#Eval("OrgId").ToString().GetOrgName()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用户状态">
                <ItemTemplate>
                    <%#Eval("UserStatus").ToString().GetUserStatusText()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href='<%# "User_Info_Edit.aspx?UserId=" + this.UserId + "&PkId=" + Eval("PkId").ToString() %>'>
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
