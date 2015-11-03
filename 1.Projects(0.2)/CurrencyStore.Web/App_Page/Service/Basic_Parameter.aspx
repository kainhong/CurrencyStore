<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Basic_Parameter.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Basic_Parameter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    业务参数
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphList" runat="server">
    <table cellpadding="5" cellspacing="5" border="0" style="width: 100%; margin: 20px;">
        <col width="150px" />
        <tbody>
            <tr>
                <td>
                    数据保存天数
                </td>
                <td>
                    <asp:TextBox ID="txtDataStorageDays" MaxLength="2" runat="server" CssClass="txtInput"
                        Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    数据清理时间
                </td>
                <td>
                    <asp:TextBox ID="txtDataClearTime" MaxLength="8" runat="server" CssClass="txtInput"
                        Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    文件保存数量
                </td>
                <td>
                    <asp:TextBox ID="txtFileStorageCount" MaxLength="3" runat="server" CssClass="txtInput"
                        Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    纸币信息字段
                </td>
                <td>
                    <table cellpadding="3" cellspacing="3" style="width: 520px; table-layout: fixed;">
                        <tr>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn1" Text="网点机构" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn2" Text="设备号码" runat="server" Enabled="false" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn3" Text="设备类别" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn4" Text="设备型号" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn5" Text="操作员号码" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn6" Text="操作时间" runat="server" Enabled="false" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn7" Text="业务类型" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn8" Text="客户卡号" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn9" Text="批次号码" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn10" Text="纸币顺序号" runat="server" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn11" Text="纸币种类" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn12" Text="纸币面额" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn13" Text="纸币版本" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn14" Text="纸币类型" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn15" Text="钞口号码" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn16" Text="是否可疑" runat="server" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn17" Text="纸币号码" runat="server" Enabled="false" />
                            </td>
                            <td>
                                <asp:CheckBox ID="cbCurrencyInfoColumn18" Text="纸币号码图像" runat="server" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
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
