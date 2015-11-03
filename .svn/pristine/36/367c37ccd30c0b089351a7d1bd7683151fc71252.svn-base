<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Basic_Dict_List.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Basic_Dict_List" %>

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
    <%=this.Kind.GetDictKindText()%>列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
    <table>
        <tr>
            <td style="width: 200px; vertical-align: middle;">
                <a href="Basic_Dict_Edit.aspx?UserId=<%=this.UserId%>&Kind=<%=this.Kind%>" class="tools_btn">
                    <span><b class="add">添加数据</b></span></a> <a href="javascript:void(0);" onclick="checkAll(this);"
                        class="tools_btn"><span><b class="all">全选</b></span></a> <a href="javascript:batchDelete();"
                            class="tools_btn"><span><b class="delete">批量删除</b></span></a><span style="display: none">
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
        GridLines="None" EmptyDataText="暂无数据" ShowHeaderWhenEmpty="True" DataKeyNames="PkId">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="cbSelect" CssClass="checkall" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="字典数据键">
                <ItemTemplate>
                    <%#Eval("DictKey")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="字典数据值">
                <ItemTemplate>
                    <%#Eval("DictValue")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href='<%#"Basic_Dict_Edit.aspx?UserId=" + this.UserId + "&Kind=" + this.Kind + "&PkId=" + Eval("PkId").ToString()%>'>
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
</asp:Content>
