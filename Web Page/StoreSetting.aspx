<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreSetting.aspx.cs" Inherits="Web_Page.StoreSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/StoreSetting.css" />
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
                    <div class="title">店铺信息设置</div>
                    <div class="tablerow">
                        <div class="property">手机号码</div>
                        <div class="value">
                            <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="tablerow">
                        <div class="property">电子邮箱</div>
                        <div class="value">
                            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="tablerow">
                        <asp:Button ID="Button1" runat="server" Text="确认修改" class="btn" OnClick="Button1_Click"/>
                    </div>

                
                    <div class="title">密码设置</div>
                    <div class="tablerow">
                        <div class="property">原密码</div>
                        <div class="value">
                            <asp:TextBox ID="OldPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="tablerow">
                        <div class="property">新密码</div>
                        <div class="value">
                            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="tablerow">
                        <div class="property">确认新密码</div>
                        <div class="value">
                            <asp:TextBox ID="NewPassword1" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="floatclear"></div>
                    </div>
                    <div class="tablerow">
                        <asp:Button ID="Button3" runat="server" Text="确认修改" class="btn" OnClick="Button3_Click"/>
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
