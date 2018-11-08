<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>狂龙通讯录管理系统09版</title>
    <link rel=stylesheet href="Styles/Style.css" type="text/css" />
</head>
<body  background="image/bg.gif">
    <form id="form1" runat="server" >
    <div >
    <p>&nbsp;</p>
     <p>&nbsp;</p>
      <p>&nbsp;</p>
     <p>&nbsp;</p>
        <table align=center style="width: 339px" bgcolor=white  border=2>
            <tr>
                <td  colspan=2 align=center style="height: 14px" >
                    <asp:Image ID="Image1" runat="server" Height="288px" ImageUrl="~/image/Login.jpg"
                        Width="421px" />
            </tr>
            <tr>
                <td style="width: 169px; height: 26px; text-align: center;" >
                    <strong>用户名：</strong></td>
                <td style="height: 26px; width: 246px;">
                    <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td style="width: 169px; text-align: center;">
                    <strong>口 &nbsp;&nbsp; 令：</strong></td>
                <td style="width: 246px">
                    <asp:TextBox ID="txtUserPwd" runat="server" TextMode="Password" Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
            <td colspan=2 align=center style="position: static;">
                <asp:Button ID="btnLogin" runat="server" Text="确认" OnClick="btnLogin_Click" Width="80px" />
                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HLregister" runat="server" NavigateUrl="~/Register.aspx" Width="80px" Font-Bold="True">注册</asp:HyperLink></td>
            </tr>
        </table>
    
    </div>
    </form>
 
</body>
</html>
