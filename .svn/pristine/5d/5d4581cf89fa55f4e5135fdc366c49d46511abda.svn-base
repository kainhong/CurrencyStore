<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CurrencyStore.Web.App_Page.Service.Index" %>

<%@ Import Namespace="CurrencyStore.Business" %>
<%@ Import Namespace="CurrencyStore.DataConvert" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=SystemParameter.CollectSystemName%></title>
    <link href="Script/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="Css/basic.css" rel="stylesheet" type="text/css" />
    <script src="Script/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="Script/ui/js/ligerBuild.min.js" type="text/javascript"></script>
    <script src="Script/function.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tab = null;
        var accordion = null;
        $(function () {
            //页面布局
            $("#global_layout").ligerLayout({ leftWidth: 180, height: '100%', topHeight: 65, bottomHeight: 24, allowTopResize: false, allowBottomResize: false, allowLeftCollapse: true, onHeightChanged: f_heightChanged });

            var height = $(".l-layout-center").height();

            //Tab
            $("#framecenter").ligerTab({ height: height });

            //左边导航面板
            $("#global_left_nav").ligerAccordion({ height: height - 25, speed: null });

            $(".l-link").hover(function () {
                $(this).addClass("l-link-over");
            }, function () {
                $(this).removeClass("l-link-over");
            });

            //快捷菜单
            var menu = $.ligerMenu({ width: 120, items:
            [
			    { text: '首页', click: itemclick },
			    { text: '修改密码', click: itemclick },
			    { line: true },
			    { text: '关闭菜单', click: itemclick }
		    ]
            });
            $("#tab-tools-nav").bind("click", function () {
                var offset = $(this).offset(); //取得事件对象的位置
                menu.show({ top: offset.top + 27, left: offset.left - 120 });
                return false;
            });

            tab = $("#framecenter").ligerGetTabManager();
            accordion = $("#global_left_nav").ligerGetAccordionManager();
            $("#pageloading_bg,#pageloading").hide();
        });
        //快捷菜单回调函数
        function itemclick(item) {
            switch (item.text) {
                case "首页":
                    f_addTab('home', '首页', 'Home.aspx?UserId=<%=this.UserId%>');
                    break;
                case "修改密码":
                    f_addTab('manager_pwd', '修改密码', 'ModifyPwd.aspx?UserId=<%=this.UserId%>');
                    break;
                default:
                    //关闭窗口
                    break;
            }
        }
        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }
        //添加Tab，可传3个参数
        function f_addTab(tabid, text, url, iconcss) {
            if (arguments.length == 4) {
                tab.addTabItem({ tabid: tabid, text: text, url: url, iconcss: iconcss });
            } else {
                tab.addTabItem({ tabid: tabid, text: text, url: url });
            }
        }
        //提示Dialog并关闭Tab
        function f_errorTab(tit, msg) {
            $.ligerDialog.open({
                isDrag: false,
                allowClose: false,
                type: 'error',
                title: tit,
                content: msg,
                buttons: [{
                    text: '确定',
                    onclick: function (item, dialog, index) {
                        //查找当前iframe名称
                        var itemiframe = "#framecenter .l-tab-content .l-tab-content-item";
                        var curriframe = "";
                        $(itemiframe).each(function () {
                            if ($(this).css("display") != "none") {
                                curriframe = $(this).attr("tabid");
                                return false;
                            }
                        });
                        if (curriframe != "") {
                            tab.removeTabItem(curriframe);
                            dialog.close();
                        }
                    }
                }]
            });
        }
    </script>
    <style type="text/css">
        HTML
        {
            overflow: hidden;
        }
    </style>
</head>
<body style="padding: 0px;">
    <form id="form1" runat="server">
    <div class="pageloading_bg" id="pageloading_bg">
    </div>
    <div id="pageloading">
        数据加载中，请稍等...</div>
    <div id="global_layout" class="layout" style="width: 100%">
        <!--头部-->
        <div position="top" class="header">
            <div class="header_box">
                <div class="header_right">
                    <span><b>
                        <%=this.CurrentUser.UserNickName%>（<%=this.CurrentUserRole.RoleName%>）</b>&nbsp;您好，欢迎光临</span>
                    <br />
                    <a href="javascript:f_addTab('home','首页','Home.aspx?UserId=<%=this.UserId%>')">首页</a>
                    | <a target="_top" href="Login.aspx">退出</a>
                </div>
                <a class="logo">Logo</a>
            </div>
        </div>
        <!--左边-->
        <div position="left" title="管理菜单" id="global_left_nav">
            <%= this.GetLeftMenuHtml() %>
        </div>
        <div position="center" id="framecenter" toolsid="tab-tools-nav">
            <div tabid="home" title="首页" iconcss="tab-icon-home" style="height: 300px">
                <iframe frameborder="0" name="sysMain" src="Home.aspx?UserId=<%=this.UserId%>"></iframe>
            </div>
        </div>
        <div position="bottom" class="footer">
            <div class="copyright">
                Copyright&nbsp;&nbsp;&copy;&nbsp;&nbsp;<%=SystemParameter.CollectSystemName%>&nbsp;&nbsp;版权所有</div>
        </div>
    </div>
    </form>
</body>
</html>
