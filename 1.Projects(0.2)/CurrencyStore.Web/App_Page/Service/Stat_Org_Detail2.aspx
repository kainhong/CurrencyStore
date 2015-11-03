<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stat_Org_Detail2.aspx.cs"
    Inherits="CurrencyStore.Web.App_Page.Service.Stat_Org_Detail2" %>

<%@ Import Namespace="CurrencyStore.Common.ExtensionMethod" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @media Print
        {
            .noprn
            {
                display: none;
            }
        }
    </style>
    <link href="Css/basic.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function preview() {
            window.print();
            parent.closeDetail();
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!--startprint-->
    <table id="tblDetail" cellpadding="5px" cellspacing="5px" border="0px" style="width: 650px;
        margin: 10px auto; font-size: 12px; table-layout: fixed;">
        <tr style="text-align: center">
            <td colspan="2">
                <h2>
                    <asp:Literal ID="lelReportTitle" runat="server"></asp:Literal></h2>
            </td>
        </tr>
        <tr style="text-align: left">
            <td style="padding-left: 70px">
                <asp:Literal ID="lelOperationTime" runat="server"></asp:Literal>
            </td>
            <td style="padding-left: 70px">
                <asp:Literal ID="lelCurrencyKind" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr style="text-align: left">
            <td style="padding-left: 70px">
                <asp:Literal ID="lelDeviceKind" runat="server"></asp:Literal>
            </td>
            <td style="padding-left: 70px">
                <asp:Literal ID="lelDeviceModel" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr style="text-align: center">
            <td colspan="2">
                <asp:Chart ID="chartDetailt" runat="server" BorderlineColor="157, 192, 230" Width="600px"
                    Height="350px">
                    <Series>
                        <asp:Series Name="defaultSeries" IsValueShownAsLabel="True" ChartArea="defaultChartArea"
                            CustomProperties="PointWidth=0.5">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="defaultChartArea">
                            <AxisY Title="总额" TextOrientation="Horizontal">
                                <MajorGrid LineColor="Silver" LineDashStyle="Dash" />
                                <LabelStyle Enabled="False" />
                            </AxisY>
                            <AxisX Title="面额">
                                <MajorGrid LineDashStyle="NotSet" />
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
        <tr style="text-align: center">
            <td colspan="2">
                <asp:GridView ID="gvList" CssClass="msgtable" runat="server" AutoGenerateColumns="False"
                    GridLines="None" EmptyDataText="暂无数据" ShowHeaderWhenEmpty="True">
                    <Columns>
                        <asp:TemplateField HeaderText="面额">
                            <ItemTemplate>
                                <%#Eval("FaceAmount")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="数量">
                            <ItemTemplate>
                                <%# Eval("Count").ToString().ToInt().ToString("#,###")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="总额">
                            <ItemTemplate>
                                <%# Eval("Sum").ToString().ToInt().ToString("#,##0.00")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <!--endprint-->
    <table cellpadding="5px" cellspacing="5px" border="0px" class="noprn" style="width: 650px;
        margin: 10px auto; font-size: 12px; table-layout: fixed;">
        <tr style="text-align: center">
            <td>
                <asp:Button ID="btnPrint" runat="server" Text="打印" OnClientClick="preview()" CssClass="btnSubmit" />
                <asp:Button ID="btnClose" runat="server" Text="关闭" OnClientClick="parent.closeDetail();return false;"
                    CssClass="btnSubmit" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
