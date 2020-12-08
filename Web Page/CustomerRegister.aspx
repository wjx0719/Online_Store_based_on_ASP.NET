<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web_Page.CustomerRegister" Codebehind="CustomerRegister.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/CustomerRegister.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">Online Shopping</div>

        <div class="wrapper">
            <div class="leftwrapper">
                <div class="barcontent">
                    <div class="bartitle">功能选择</div>
                    <div class="linkrow">
                        <a href="Index.aspx" class="link">首页</a>
                    </div>
                    <div class="linkrow">
                        <a href="CustomerLogin.aspx" class="link">顾客登陆</a>
                    </div>
                    <div class="linkrow">
                        <a href="StoreLogin.aspx" class="link">店铺登陆</a>
                    </div>
                    <div class="linkrow">
                        <a href="AdminLogin.aspx" class="link">管理员登陆</a>
                    </div>
                    <div class="linkrow">
                        <a href="CustomerRegister.aspx" class="link">顾客注册</a>
                    </div>
                    <div class="linkrow">
                        <a href="StoreRegister.aspx" class="link">店铺注册</a>
                    </div>
                </div>
            </div>
            <div class="rightwrapper">
                <div class="registerbox">
                    <div class="title">顾客注册</div>
                    <div class="tablerow">
                        <input id="Name" type="text" runat="server" class="textbox" placeholder="用户名（必填，用于登陆系统）" />
                    </div>
                    <div class="tablerow">
                        <input id="Password" type="password" runat="server" class="textbox" placeholder="密码（不允许出现空格）" />
                    </div>
                    <div class="tablerow">
                        <input id="Password1" type="password" runat="server" class="textbox" placeholder="再次确认密码" />
                    </div>
                    <div class="tablerow">
                        <input id="Phone" type="text" runat="server" class="textbox" placeholder="手机号码（必填）" />
                    </div>
                    <div class="tablerow">
                        <input id="Email" type="text" runat="server" class="textbox" placeholder="电子邮箱（必填）" />
                    </div>
                    <div class="tablerow">
                        <input id="Address" type="text" runat="server" class="textbox" placeholder="家庭住址（必填）" />
                    </div>
                    <div class="tablerow">
                        <asp:Button ID="Button1" runat="server" Text="确认注册" OnClick="Button1_Click" class="btn" />
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
