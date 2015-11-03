<%@ Page Title="" Language="C#" MasterPageFile="~/App_Page/Service/EditPage.Master"
    AutoEventWireup="true" CodeBehind="Device_Info_Edit.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Device_Info_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script src="Script/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function setOrgSearchValue(orgId, orgName) {
            $("#<%=this.hfOrgId.ClientID%>").attr("value", orgId);
            $("#<%=this.txtOrgName.ClientID%>").attr("value", orgName);
            $.ligerDialog.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    <a href="Device_Info_List.aspx?UserId=<%=this.UserId%>" class="back">后退</a>设备信息编辑
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFormBody" runat="server">
    <table class="form_table">
        <col width="150px" />
        <tbody>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    设备号码：
                </th>
                <td>
                    <asp:TextBox ID="txtDeviceNumber" runat="server" CssClass="txtInput normal" MaxLength="16" />
                    <asp:RequiredFieldValidator ID="rfvDeviceNumber" runat="server" ControlToValidate="txtDeviceNumber"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    软件版本：
                </th>
                <td>
                    <asp:TextBox ID="txtSoftwareVersion" runat="server" CssClass="txtInput normal" MaxLength="32" />
                    <asp:RequiredFieldValidator ID="rfvSoftwareVersion" runat="server" ControlToValidate="txtSoftwareVersion"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    注册地址：
                </th>
                <td>
                    <asp:TextBox ID="txtRegisterIp" runat="server" CssClass="txtInput normal" MaxLength="16" />
                    <asp:RequiredFieldValidator ID="rfvRegisterIp" runat="server" ControlToValidate="txtRegisterIp"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    设备类别：
                </th>
                <td>
                    <asp:DropDownList ID="ddlDeviceKind" CssClass="select2" runat="server" Width="150px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvOrgAddress" runat="server" ControlToValidate="ddlDeviceKind"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    设备型号：
                </th>
                <td>
                    <asp:DropDownList ID="ddlDeviceModel" CssClass="select2" runat="server" Width="150px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDeviceModel"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    网点机构：
                </th>
                <td>
                    <asp:TextBox ID="txtOrgName" runat="server" ReadOnly="true" CssClass="txtInput normal"
                        MaxLength="32" />
                    <asp:HiddenField ID="hfOrgId" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    上线时间：
                </th>
                <td>
                    <asp:TextBox ID="txtOnLineTime" runat="server" CssClass="txtInput normal" MaxLength="10"
                        onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                    <asp:RequiredFieldValidator ID="rfvOnLineTime" runat="server" ControlToValidate="txtOnLineTime"
                        ValidationGroup="Submit" Display="Dynamic" ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th>
                    <label>
                        *
                    </label>
                    设备状态：
                </th>
                <td>
                    <asp:DropDownList ID="ddlDeviceStatus" CssClass="select2" runat="server" Width="100px">
                        <asp:ListItem Text="启用" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFormFoot" runat="server">
    <asp:Button ID="btnSubmitContinue" runat="server" Text="提交后继续" CssClass="btnSubmit"
        ValidationGroup="Submit" OnClick="btnSubmit_Click" CommandName="SubmitContinue" />
    <asp:Button ID="btnSubmitReturn" runat="server" Text="提交后返回" CssClass="btnSubmit"
        ValidationGroup="Submit" OnClick="btnSubmit_Click" CommandName="SubmitReturn" />
</asp:Content>
