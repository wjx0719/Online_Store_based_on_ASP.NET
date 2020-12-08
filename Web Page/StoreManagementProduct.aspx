<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreManagementProduct.aspx.cs" Inherits="Web_Page.StoreManagementProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/StoreManagementProduct.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">Online Shopping</div>

        <div class="wrapper">
            <div class="leftwrapper">
                <div class="barcontent">
                    <div class="bartitle">功能选择</div>
                    <div class="linkrow">
                        <a href="StoreManagementProduct.aspx" class="link">商品管理</a>
                    </div>
                    <div class="linkrow">
                        <a href="StoreManagementOrder.aspx" class="link">订单管理</a>
                    </div>
                    <div class="linkrow">
                        <a href="StoreInfo.aspx" class="link">店铺信息</a>
                    </div>
                    <div class="linkrow">
                        <a href="StoreSetting.aspx" class="link">信息设置</a>
                    </div>
                    <div class="linkrow">
                        <asp:Button ID="Button2" runat="server" Text="退出登陆" class="btn" OnClick="Button2_Click"/>
                    </div>
                </div>
            </div>
            <div class="rightwrapper">
                <div class="infobox">
                    <div class="title">商品管理</div>
                    <div class="cardbox">
                        <div class="imgcard">
                            <asp:Image ID="Image" runat="server" Width="95%"/>
                        </div>
                        <div class="infocard">
                            <div class="infotitle">商品名称</div>
                            <div class="name">
                                <asp:Label ID="Name" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="infotitle">商品价格</div>
                            <div class="price">
                                <asp:Label ID="Price" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="infotitle">商品描述</div>
                            <div class="description">
                                <asp:Label ID="Description" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="opbtnwrapper">
                                <asp:Button ID="Button5" runat="server" Text="添加新商品" OnClick="Button5_Click" class="opbtn"/>
                            </div>
                            <div class="opbtnwrapper">
                                <asp:Button ID="Button6" runat="server" Text="修改商品信息" OnClick="Button6_Click" class="opbtn"/>
                            </div>
                            <div class="opbtnwrapper">
                                <asp:Button ID="Button4" runat="server" Text="删除该商品" OnClick="Button4_Click" class="opbtn"/>
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
