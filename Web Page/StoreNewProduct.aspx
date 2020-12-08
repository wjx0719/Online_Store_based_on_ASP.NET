<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreNewProduct.aspx.cs" Inherits="Web_Page.StoreNewProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/StoreNewProduct.css" />
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
                    <div class="title">添加商品</div>
                    <div class="cardbox">
                        <div class="imgcard">
                            <div class="imguploadlabel">
                                上传商品图片
                                (JPG格式)</div>
                            <div class="imgupload">
                                <asp:FileUpload ID="FileUpload1" runat="server"/>
                            </div>
                        </div>
                        <div class="infocard">
                            <div class="name">
                                <input id="Name" type="text" class="textbox" placeholder="商品名称" runat="server"/>
                            </div>
                            <div class="price">
                                <input id="Price" type="text" class="textbox" placeholder="价格" runat="server"/>
                            </div>
                            <div class="description">
                                <textarea id="Description" cols="20" rows="6" class="textbox" placeholder="商品介绍" runat="server"></textarea>
                            </div>
                        </div>
                        <div class="floatclear"></div>
                        <div class="btnrow">
                            <div class="btnwrapper">
                                <asp:Button ID="Button3" runat="server" Text="确认添加" OnClick="Button3_Click" class="btn"/>
                            </div>
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
