<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Currency_Blacklist_List.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Currency_Blacklist_List" %>

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
    黑名单列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
    <table>
        <tr>
            <td style="width: 250px; vertical-align: middle;">
                <a href="Currency_Blacklist_Edit.aspx?UserId=<%=this.UserId%>" class="tools_btn"><span>
                    <b class="add">添加数据</b></span></a> <a href="javascript:void(0);" onclick="checkAll(this);"
                        class="tools_btn"><span><b class="all">全选</b></span></a> <a href="javascript:batchDelete();"
                            class="tools_btn"><span><b class="delete">批量删除</b></span></a> <span style="display: none">
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" /></span>
                <asp:LinkButton ID="btnUpdateVersion" runat="server" CssClass="tools_btn" OnClick="btnUpdateVersion_Click"><span><b class="send">更新版本</b></span></asp:LinkButton>
            </td>
            <td>
                纸币号码：
                <asp:TextBox ID="txtCurrencyNumber" MaxLength="16" runat="server" CssClass="txtInput"></asp:TextBox>
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
            <asp:TemplateField HeaderText="纸币种类">
                <ItemTemplate>
                    <%#Eval("CurrencyKindCode").ToString().GetDictValue((int)BasicDictionary.DictKindEnum.CurrencyKind)%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="纸币面额">
                <ItemTemplate>
                    <%#Eval("FaceAmount")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="纸币版本">
                <ItemTemplate>
                    <%#Eval("CurrencyVersion")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="纸币号码">
                <ItemTemplate>
                    <%#Eval("CurrencyNumber")%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
        <RowStyle HorizontalAlign="Left" VerticalAlign="Middle" />
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageBox" runat="server">
    <webdiyer:AspNetPager ID="objANP" runat="server" HorizontalAlign="Right" Width="100%"
        ShowPageIndexBox="Never" Font-Size="12px" Wrap="False" AlwaysShow="True" FirstPageText="首页"
        LastPageText="末页" NextPageText="下一页" PageSize="15" PagingButtonSpacing="10px"
        PrevPageText="上一页" CustomInfoTextAlign="Left" ShowCustomInfoSection="Left" CustomInfoHTML="&amp;nbsp;&amp;nbsp;第&amp;nbsp;&lt;span style='color:Red'&gt;%CurrentPageIndex%&lt;/span&gt;&amp;nbsp;页&amp;nbsp;/&amp;nbsp;共&amp;nbsp;&lt;span style='color:Red'&gt;%PageCount%&lt;/span&gt;&amp;nbsp;页，共&amp;nbsp;&lt;span style='color:Red'&gt;%RecordCount%&lt;/span&gt;&amp;nbsp;条">
    </webdiyer:AspNetPager>
</asp:Content>
