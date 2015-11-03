<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Login" %>

<%@ Import Namespace="CurrencyStore.Business" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=SystemParameter.CollectSystemName%></title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link rel="icon" href="/favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />
    <link href="Css/login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        if (top.location != location) {
            top.location.href = location.href;
        }
        var browser = navigator.appName;
        var b_version = navigator.appVersion;
        var version = b_version.split(";");
        var trim_Version = version[1].replace(/[ ]/g, "");
        if (browser == "Microsoft Internet Explorer" && trim_Version == "MSIE6.0") {
            window.location.href = 'IE6Update.html';
        }
        function GetCheckCode() {
            document.getElementById("imgCheckCode").src = '../Public/CheckCode.aspx?Random=' + Math.random();
        }
    </script>
</head>
<body>
    <form id="objForm" runat="server">
    <div id="login">
        <div id="login_header">
            <div class="login_headerContent">
                <h2 class="login_title">
                    <img src="Image/login_title.png" alt="" /></h2>
            </div>
        </div>
        <div id="login_content">
            <div class="loginForm">
                <p>
                    <label>
                        账户：</label>
                    <asp:TextBox ID="txtUserAccount" MaxLength="20" Width="140px" runat="server"></asp:TextBox>
                </p>
                <p>
                    <label>
                        密码：</label>
                    <asp:TextBox ID="txtUserPwd" MaxLength="16" TextMode="Password" Width="140px" runat="server"></asp:TextBox>
                </p>
                <p>
                    <label>
                        验证码：</label>
                    <asp:TextBox ID="txtCheckCode" MaxLength="4" CssClass="code" runat="server" Width="70px"></asp:TextBox>
                    <span>
                        <img id="imgCheckCode" style="cursor: pointer;" onclick="GetCheckCode()" src="../Public/CheckCode.aspx"
                            alt="" title="看不清，点我换一张" /></span>
                </p>
                <div class="login_bar">
                    <asp:Button ID="btnLogin" runat="server" CssClass="sub" OnClick="btnLogin_Click" />
                </div>
                <div class="login_bar" style="padding-top: 15px;">
                    <asp:Label ID="lblMessage" ForeColor="Red" EnableViewState="false" runat="server"></asp:Label>
                </div>
            </div>
            <div class="login_banner">
                <img src="Image/login_banner.jpg" alt="" /></div>
            <div class="login_main">
                <div class="login_inner">
                </div>
            </div>
        </div>
        <div id="login_footer">
            Copyright&nbsp;&nbsp;&copy;&nbsp;&nbsp;<%=SystemParameter.CollectSystemName%>&nbsp;&nbsp;版权所有
        </div>
    </div>
    </form>
</body>
</html>
