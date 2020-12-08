<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs" Inherits="Web_Page.CustomerCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/CustomerInfo.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">Online Shopping</div>

        <div class="wrapper">
            <div class="leftwrapper">
                <div class="barcontent">
                    <div class="bartitle">功能选择</div>
                    <div class="linkrow">
                        <a href="CustomerShopping.aspx" class="link">商城首页</a>
                    </div>
                    <div class="linkrow">
                        <a href="CustomerManagementOrder.aspx" class="link">订单管理</a>
                    </div>
                    <div class="linkrow">
                        <a href="CustomerInfo.aspx" class="link">用户信息</a>
                    </div>
                    <div class="linkrow">
                        <a href="CustomerSetting.aspx" class="link">用户设置</a>
                    </div>
                    <div class="linkrow">
                        <asp:Button ID="Button2" runat="server" Text="退出登陆" class="btn" OnClick="Button2_Click"/>
                    </div>
                </div>
            </div>
            <div class="rightwrapper">
                <div class="infobox">
                    <div class="title">用户信息</div>
                    <div class="tablerow">
                        <div class="property">用户ID</div>
                        <div class="value">
                            <asp:Label ID="ID" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="tablerow">
                        <div class="property">用户名</div>
                        <div class="value">
                            <asp:Label ID="Name" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="tablerow">
                        <div class="property">手机号码</div>
                        <div class="value">
                            <asp:Label ID="Phone" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="tablerow">
                        <div class="property">电子邮箱</div>
                        <div class="value">
                            <asp:Label ID="Email" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="tablerow">
                        <div class="property">家庭住址</div>
                        <div class="value">
                            <asp:Label ID="Address" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                </div>
            </div>
            <div class="floatclear"></div>
        </div>

        <div class="footer">
            《基于Visual C#的windows程序设计》课程作业——Online Shopping
        </div>
    </form>
</body>
</html>
