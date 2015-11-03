<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stat_Org_Detail.aspx.cs"
    Inherits="CurrencyStore.Web.App_Page.Service.Stat_Org_Detail" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
        }
        .ReportViewer
        {
            margin: 0px auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="smDetail" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="rvDetail" runat="server" BackColor="#E9F0F1" Font-Names="Verdana"
        Font-Size="12px" Height="100%" ShowBackButton="False" ShowFindControls="False"
        PageCountMode="Actual" ShowZoomControl="False" WaitMessageFont-Names="Verdana"
        WaitMessageFont-Size="12px" Width="100%" CssClass="ReportViewer" ShowExportControls="False"
        ShowPageNavigationControls="False">
    </rsweb:ReportViewer>
    </form>
</body>
</html>
