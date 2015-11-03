<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Currency_Info_Import.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Currency_Info_Import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    数据导入
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphList" runat="server">
    <table cellpadding="5" cellspacing="5" border="0" style="width: 100%; margin: 20px;
        empty-cells: show;">
        <col width="100px" />
        <tbody>
            <tr>
                <td>
                    数据文件1：
                </td>
                <td>
                    <asp:FileUpload ID="fuDataFile1" CssClass="txtInput" runat="server" Width="400px" />
                    <asp:CheckBox ID="cbIgnoreAlreadyUpload1" Text="忽略已上传的数据" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td id="tdDataUploadResult1" runat="server" style="line-height: 20px">
                </td>
            </tr>
            <tr>
                <td>
                    数据文件2：
                </td>
                <td>
                    <asp:FileUpload ID="fuDataFile2" CssClass="txtInput" runat="server" Width="400px" />
                    <asp:CheckBox ID="cbIgnoreAlreadyUpload2" Text="忽略已上传的数据" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td id="tdDataUploadResult2" runat="server" style="line-height: 20px">
                </td>
            </tr>
            <tr>
                <td>
                    数据文件3：
                </td>
                <td>
                    <asp:FileUpload ID="fuDataFile3" CssClass="txtInput" runat="server" Width="400px" />
                    <asp:CheckBox ID="cbIgnoreAlreadyUpload3" Text="忽略已上传的数据" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td id="tdDataUploadResult3" runat="server" style="line-height: 20px">
                </td>
            </tr>
            <tr>
                <td>
                    数据文件4：
                </td>
                <td>
                    <asp:FileUpload ID="fuDataFile4" CssClass="txtInput" runat="server" Width="400px" />
                    <asp:CheckBox ID="cbIgnoreAlreadyUpload4" Text="忽略已上传的数据" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td id="tdDataUploadResult4" runat="server" style="line-height: 20px">
                </td>
            </tr>
            <tr>
                <td>
                    数据文件5：
                </td>
                <td>
                    <asp:FileUpload ID="fuDataFile5" CssClass="txtInput" runat="server" Width="400px" />
                    <asp:CheckBox ID="cbIgnoreAlreadyUpload5" Text="忽略已上传的数据" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td id="tdDataUploadResult5" runat="server" style="line-height: 20px">
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageBox" runat="server">
    <div style="text-align: center">
        <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" ValidationGroup="Submit"
            OnClick="btnSubmit_Click" /></div>
</asp:Content>
