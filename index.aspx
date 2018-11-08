<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户登录</title>
    <link href="images/Style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
         table
        {
            border: 1px solid #A9CF9C;
        } 
        input.contact_input
        {
            width: 253px;
            height: 18px;
            background-color: #fff;
            color: #000;
            border: 1px solid #F00;
        }

        </style>

    <script language="javascript" type="text/javascript">

        function chkform() {
            if (document.form.UserName.value == "") {
                alert("请填写用户名！");
                document.form.UserName.focus();
                return false;
            }
            if (document.form.PassWord.value == "") {
                alert("请填写密码！");
                document.form.PassWord.focus();
                return false;
            }
            return true;
        }

    </script>

</head>
<body>
<table cellspacing="1" cellpadding="4" width="600" align="center">
    <form id="form1" runat="server" onsubmit="return chkform();">
    <tbody>
        <tr>
            <td align="right" width="165">
                &nbsp;
            </td>
            <td valign="bottom" width="596">
                请输入您的用户名和密码登录通信录管理系统
                <hr align="left" width="90%" size="1" noshade color="#cccccc">
            </td>
        </tr>
        <tr>
            <td rowspan="3" align="right">
                <img height="80" src="images/login-welcome.gif" width="71">
            </td>
            <td>
                用户名：
                <asp:textbox id="UserName" runat="server" name="UserName" cssclass="contact_input"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>
                密&nbsp;&nbsp;&nbsp;&nbsp;码：
                <asp:textbox id="PassWord" runat="server" cssclass="contact_input" textmode="Password"
                    name="PassWord"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:button id="btnLogin" runat="server" text="我要登录" onclick="btnLogin_Click" 
                    onclientclick="chkform();"  />
                <input  type="reset" value="重埴" name="Submit2">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <img height="16" src="images/icon_user.gif" width="16">
                <a href="Register.aspx">新会员注册</a>
                <img height="16" src="images/padlock-closed.gif" width="16">
                <a href="#">忘记密码了？</a>
            </td>
        </tr>
    </form>
    </TBODY>
</table>
</body>
</html>
