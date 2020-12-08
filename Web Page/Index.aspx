<%@ Page Language="C#" AutoEventWireup="true" Inherits="Web_Page.index" Codebehind="Index.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/Index.css" />
</head>
<body class="container">
    <form runat="server">
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
                <div class="article">
                    该平台是利用ASP.NET+SQL Server搭建的一个在线商店平台
                    <br />
                    1. 顾客使用说明：第一次进入平台的顾客需要先进行注册，使用注册后的账号密码登陆平台之后可以进行个人信息修改，浏览商品，添加订单操作，添加完订单后可以在订单管理界面进行删除订单的操作，在订单管理界面也会显示店铺联系方式，如确认无误请联系店铺付款，店铺付款成功后，订单状态会变为已支付，在受到货物后，请在订单管理界面中点击确认收货，订单状态会变为已收货。
                    <br />
                    2. 店铺使用说明：第一次进入平台的商家需要先进行店铺注册，使用注册的账号密码登陆平台之后可以进行店铺信息修改，添加商品，管理订单等操作，若有顾客添加订单，可以在订单管理界面中查看顾客信息，在联系顾客付款之后请在订单管理中点击确认收款，订单状态会变为已付款，在顾客确认收到货物之后，订单状态会变为已收货。
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
