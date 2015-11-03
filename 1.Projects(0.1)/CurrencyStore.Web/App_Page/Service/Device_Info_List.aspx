<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Device_Info_List.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Device_Info_List" %>

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
    设备信息列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
    <table>
        <tr>
            <td style="width: 250px; vertical-align: middle;">
                <a id="aEdit" runat="server" class="tools_btn"><span><b class="add">添加数据</b></span></a>
                <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b
                    class="all">全选</b></span></a> <a href="javascript:batchDelete();" class="tools_btn">
                        <span><b class="delete">批量删除</b></span></a> <span style="display: none">
                            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" /></span>
                <asp:LinkButton ID="btnExport" runat="server" CssClass="tools_btn" OnClick="btnExport_Click">
                <span><b class="export">导出Excel</b></span></asp:LinkButton>
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
        GridLines="None" EmptyDataText="暂无数据" ShowHeaderWhenEmpty="True" DataKeyNames="PkId">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="cbSelect" CssClass="checkall" runat="server" />
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
            <asp:TemplateField HeaderText="网点机构">
                <ItemTemplate>
                    <%#Eval("OrgId").ToString().GetOrgName()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="上线时间">
                <ItemTemplate>
                    <%#Eval("OnLineTime").ToString().ToDateTime().ToShortDateString()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="设备状态">
                <ItemTemplate>
                    <%#Eval("DeviceStatus").ToString().GetDeviceStatusText()%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <a href='<%# "Device_Info_Edit.aspx?UserId=" + this.UserId + "&UnknowOrg=" + this.UnknowOrg + "&PkId=" + Eval("PkId").ToString() %>'>
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
