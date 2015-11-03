<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Currency_Info_List.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Currency_Info_List" %>

<%@ Import Namespace="CurrencyStore.Entity" %>
<%@ Import Namespace="CurrencyStore.DataConvert" %>
<%@ Import Namespace="CurrencyStore.Common.ExtensionMethod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script src="Script/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function setOrgSearchValue(orgId, orgName) {
            $("#<%=this.hfOrgId.ClientID%>").attr("value", orgId);
            $("#<%=this.txtOrgName.ClientID%>").attr("value", orgName);
            $.ligerDialog.close();
        }
        function setTimeValue(timeType) {
            var startTimeValue = "";
            var endTimeValue = "";

            if (timeType == 1) { startTimeValue = "<%=this.GetStartTime(1)%>"; endTimeValue = "<%=this.GetEndTime(1)%>"; }
            if (timeType == 2) { startTimeValue = "<%=this.GetStartTime(2)%>"; endTimeValue = "<%=this.GetEndTime(2)%>"; }
            if (timeType == 3) { startTimeValue = "<%=this.GetStartTime(3)%>"; endTimeValue = "<%=this.GetEndTime(3)%>"; }
            if (timeType == 4) { startTimeValue = "<%=this.GetStartTime(4)%>"; endTimeValue = "<%=this.GetEndTime(4)%>"; }

            $("#<%=this.txtStartTime.ClientID%>").attr("value", startTimeValue);
            $("#<%=this.txtEndTime.ClientID%>").attr("value", endTimeValue);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    纸币信息列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
    <table>
        <tr>
            <td style="width: 200px; vertical-align: middle;">
                <asp:LinkButton ID="btnExport" runat="server" CssClass="tools_btn" OnClick="btnExport_Click">
                <span><b class="export">导出Excel</b></span></asp:LinkButton>
            </td>
            <td>
                <span id="spanOrg" runat="server">网点机构：
                    <asp:TextBox ID="txtOrgName" ReadOnly="true" MaxLength="32" runat="server" CssClass="txtInput"
                        Width="250px"></asp:TextBox>
                    <asp:HiddenField ID="hfOrgId" runat="server" />
                    <br />
                </span>操作时间：
                <asp:TextBox ID="txtStartTime" MaxLength="10" runat="server" CssClass="txtInput"></asp:TextBox>
                至
                <asp:TextBox ID="txtEndTime" MaxLength="10" runat="server" CssClass="txtInput"></asp:TextBox>
                <a href="javascript:setTimeValue(0)">清空</a> <a href="javascript:setTimeValue(1)">本日</a>
                <a href="javascript:setTimeValue(2)">昨日</a> <a href="javascript:setTimeValue(3)">本月</a>
                <a href="javascript:setTimeValue(4)">上月</a>
                <br />
                设备号码：
                <asp:TextBox ID="txtDeviceNumber" MaxLength="13" runat="server" CssClass="txtInput"></asp:TextBox>
                纸币号码：
                <asp:TextBox ID="txtCurrencyNumber" MaxLength="16" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btnSearch" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphList" runat="server">
    <div class="msgtable_container">
        <asp:GridView ID="gvList" CssClass="msgtable2" runat="server" AutoGenerateColumns="False"
            GridLines="None" EmptyDataText="暂无数据" ShowHeaderWhenEmpty="True" DataKeyNames="PkId">
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
                <asp:TemplateField HeaderText="设备类别">
                    <ItemTemplate>
                        <%#Eval("DeviceKindCode").ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceKind)%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="设备型号">
                    <ItemTemplate>
                        <%# Eval("DeviceModelCode").ToString().GetDictValue((int)BasicDictionary.DictKindEnum.DeviceModel)%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作员号码">
                    <ItemTemplate>
                        <%#Eval("OperatorNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作时间">
                    <ItemTemplate>
                        <%#Eval("OperateTime")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="业务类型">
                    <ItemTemplate>
                        <%#Eval("BusinessType").ToString().GetDictValue((int)BasicDictionary.DictKindEnum.BusinessType)%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="客户卡号">
                    <ItemTemplate>
                        <%#Eval("ClientCardNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="批次号码">
                    <ItemTemplate>
                        <%#Eval("BatchNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="纸币顺序号">
                    <ItemTemplate>
                        <%#Eval("OrderNumber")%>
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
                <asp:TemplateField HeaderText="纸币类型">
                    <ItemTemplate>
                        <%#Eval("CurrencyType").ToString().GetDictValue((int)BasicDictionary.DictKindEnum.CurrencyType)%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="钞口号码">
                    <ItemTemplate>
                        <%#Eval("PortNumber").ToString().GetDictValue((int)BasicDictionary.DictKindEnum.PortNumber)%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否可疑">
                    <ItemTemplate>
                        <%#Eval("IsSuspicious").ToString().GetSuspiciousText()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="纸币号码">
                    <ItemTemplate>
                        <%#Eval("CurrencyNumber")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="纸币号码图像">
                    <ItemTemplate>
                        <%#Eval("CurrencyImageType").ToString() == "0" ? "暂无图像" : "<img src=\"../Public/CurrencyImage.aspx?CurrencyNumber={0}\" title=\"{1}\" />".FormatWith(Eval("CurrencyNumber").ToString(), Eval("CurrencyNumber").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageBox" runat="server">
    <webdiyer:AspNetPager ID="objANP" runat="server" HorizontalAlign="Right" Width="100%"
        ShowPageIndexBox="Never" Font-Size="12px" Wrap="False" AlwaysShow="True" FirstPageText="首页"
        LastPageText="末页" NextPageText="下一页" PageSize="15" PagingButtonSpacing="10px"
        PrevPageText="上一页" CustomInfoTextAlign="Left" ShowCustomInfoSection="Left" CustomInfoHTML="&amp;nbsp;&amp;nbsp;第&amp;nbsp;&lt;span style='color:Red'&gt;%CurrentPageIndex%&lt;/span&gt;&amp;nbsp;页&amp;nbsp;/&amp;nbsp;共&amp;nbsp;&lt;span style='color:Red'&gt;%PageCount%&lt;/span&gt;&amp;nbsp;页，共&amp;nbsp;&lt;span style='color:Red'&gt;%RecordCount%&lt;/span&gt;&amp;nbsp;条">
    </webdiyer:AspNetPager>
</asp:Content>
