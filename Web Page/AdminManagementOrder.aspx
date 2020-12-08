<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminManagementOrder.aspx.cs" Inherits="Web_Page.AdminManagementOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/AdminManagementOrder.css" />
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
                    <div class="title">订单管理</div>
                    <div class="cardbox">
                        <div class="imgcard">
                            <asp:Image ID="Image" runat="server" Width="95%"/>
                        </div>
                        <div class="infocard">
                            <div class="infotitle">订单ID</div>
                            <div class="orderid">
                                <asp:Label ID="OrderID" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="infotitle">商品ID</div>
                            <div class="productid">
                                <asp:Label ID="ProductID" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="infotitle">顾客ID</div>
                            <div class="customerid">
                                <asp:Label ID="CustomerID" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="infotitle">店铺ID</div>
                            <div class="storeid">
                                <asp:Label ID="StoreID" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="infotitle">订单状态</div>
                            <div class="state">
                                <asp:Label ID="State" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="floatclear"></div>
                        <div class="btnrow">
                            <div class="leftbtnwrapper">
                                <asp:Button ID="Button1" runat="server" Text="上一件商品" OnClick="Button1_Click" class="leftbtn"/>
                            </div>
                            <div class="pageinfo">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="rightbtnwrapper">
                                <asp:Button ID="Button3" runat="server" Text="下一件商品" OnClick="Button3_Click" class="rightbtn"/>
                            </div>
                            <div class="floatclear"></div>
                        </div>
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
