<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManagementStore.aspx.cs" Inherits="Web_Page.AdminManagemenStore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/AdminManagementStore.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">Online Shopping</div>

        <div class="wrapper">
            <div class="leftwrapper">
                <div class="barcontent">
                    <div class="bartitle">功能选择</div>
                    <div class="linkrow">
                        <a href="AdminManagementCustomer.aspx" class="link">顾客管理</a>
                    </div>
                    <div class="linkrow">
                        <a href="AdminManagementStore.aspx" class="link">店铺管理</a>
                    </div>
                    <div class="linkrow">
                        <a href="AdminManagementProduct.aspx" class="link">商品管理</a>
                    </div>
                    <div class="linkrow">
                        <a href="AdminManagementOrder.aspx" class="link">订单管理</a>
                    </div>
                    <div class="linkrow">
                        <asp:Button ID="Button2" runat="server" Text="退出登陆" class="btn" OnClick="Button2_Click"/>
                    </div>
                </div>
            </div>
            <div class="rightwrapper">
                <div class="infobox">
                    <div class="title">店铺管理</div>
                    <div class="tablerow">
                        <div class="property">店铺ID</div>
                        <div class="value">
                            <asp:Label ID="ID" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="tablerow">
                        <div class="property">店铺名</div>
                        <div class="value">
                            <asp:Label ID="Name" runat="server" Text="Label"></asp:Label>
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
                        <div class="property">手机号码</div>
                        <div class="value">
                            <asp:Label ID="Phone" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="btnrow">
                        <div class="leftbtnwrapper">
                            <asp:Button ID="Button1" runat="server" Text="上一个店铺" class="leftbtn" OnClick="Button1_Click"/>
                        </div>
                        <div class="pageinfo">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="rightbtnwrapper">
                            <asp:Button ID="Button3" runat="server" Text="下一个店铺" class="rightbtn" OnClick="Button3_Click"/>
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
