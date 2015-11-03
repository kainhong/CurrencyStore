<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/ListPage.Master"
    AutoEventWireup="true" CodeBehind="Basic_Logo.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Basic_Logo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    系统标志
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphToolBox" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphList" runat="server">
    <table cellpadding="5" cellspacing="5" border="0" style="width: 100%; margin: 20px;">
        <col width="150px" />
        <tbody>
            <tr>
                <td>
                    系统名称：
                </td>
                <td>
                    <asp:TextBox ID="txtSystemName" MaxLength="32" runat="server" CssClass="txtInput"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    标志图片：
                </td>
                <td>
                    <asp:FileUpload ID="fuLogoPicture" CssClass="txtInput" runat="server" Width="400px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Image ID="imgLogo" runat="server" Visible="false" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPageBox" runat="server">
    <div style="text-align: center">
        <asp:Button ID="btnSubmitSave" runat="server" Text="保存" CssClass="btnSubmit" ValidationGroup="Submit"
            OnClick="btnSubmit_Click" CommandName="Save" />
        <asp:Button ID="btnSubmitClear" runat="server" Text="清除" CssClass="btnSubmit" ValidationGroup="Submit"
            OnClick="btnSubmit_Click" CommandName="Clear" />
    </div>
</asp:Content>
