<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h1>注册新会员</h1>
    <table align="center" width="100%">
        <tr>
            <td align="left" colspan="2">
                注：带**号的内容为必填项，否则无法完成注册
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
                登录名：
            </td>
            <td style="width: 487px; height: 26px;">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox><span style="color: red">(**)</span><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="此项不能为空"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName"
                    ErrorMessage="请检查输入的格式" ValidationExpression="\w{6,14}" SetFocusOnError="True"></asp:RegularExpressionValidator><br />
                输入的登录必须是6-14位且属于(a-z),(A-Z),(0-9)中的任意字符
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="height: 19px">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:Button ID="btnValidate" runat="server" Text="登录名是否被占用" OnClick="btnValidate_Click"
                    CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 26px;">
                登录密码：
            </td>
            <td style="width: 487px; height: 26px;">
                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" onkeyup="pwStrength(this.value)"
                    onblur="pwStrength(this.value)"></asp:TextBox><span style="color: red">(**)</span><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" ErrorMessage="您不能输入空密码"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPwd"
                    ErrorMessage="请检查输入密码的长度" ValidationExpression="\S{6,12}" SetFocusOnError="True"></asp:RegularExpressionValidator><br />
                请输入长度在6-12位之间的密码
                <table border="1" cellspacing="0" cellpadding="1" style="background: #ccc; height: 23px;
                    width: 217px">
                    <tr align="center" style="background: #eeeeee">
                        <td style="width: 50px; height: 22px;" id="strength_L">
                            弱
                        </td>
                        <td style="width: 50px; height: 22px;" id="strength_M">
                            中
                        </td>
                        <td style="width: 50px; height: 22px;" id="strength_H">
                            强
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                确认密码：
            </td>
            <td style="width: 487px">
                <asp:TextBox ID="txtPwd2" runat="server" TextMode="Password" Width="149px"></asp:TextBox><span
                    style="color: red">(**)</span><asp:CompareValidator ID="CompareValidator1" runat="server"
                        ControlToCompare="txtPwd" ControlToValidate="txtPwd2" ErrorMessage="请您再次输入口令"
                        SetFocusOnError="True"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                真实姓名：
            </td>
            <td style="width: 487px">
                <asp:TextBox ID="txtUname" runat="server"></asp:TextBox><span style="color: red">(**)</span><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUname" ErrorMessage="请输入您的真实姓名"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 25px;">
                性别：
            </td>
            <td style="width: 487px; height: 25px;">
                <asp:RadioButtonList ID="rltSex" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="height: 21px">
                生日：
            </td>
            <td style="height: 21px; width: 487px;">
                <asp:DropDownList ID="ddlYear" runat="server">
                </asp:DropDownList>
                年
                <asp:DropDownList ID="ddlmonth" runat="server">
                </asp:DropDownList>
                月
                <asp:DropDownList ID="ddlDay" runat="server">
                </asp:DropDownList>
                日
            </td>
        </tr>
        <tr>
            <td style="height: 28px">
                宅电：
            </td>
            <td style="width: 487px; height: 28px;">
                <asp:TextBox ID="txtUtel2" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtUtel2"
                    ErrorMessage="请输入7位或8位电话号码" ValidationExpression="(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                移动电话：
            </td>
            <td style="width: 487px">
                <asp:TextBox ID="txtUtel3" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtUtel3"
                    ErrorMessage="请输入11位手机号码" ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                通讯地址：
            </td>
            <td style="width: 487px">
                <asp:TextBox ID="txtUaddr" runat="server" Width="425px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                邮政编码：
            </td>
            <td style="width: 487px">
                <asp:TextBox ID="txtUzip" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtUzip"
                    ErrorMessage="请输入六位邮政编码" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                E_mail：
            </td>
            <td style="width: 487px">
                <asp:TextBox ID="txtUemail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtUemail"
                    ErrorMessage="请输入正确E_mail地址" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                QQ：
            </td>
            <td style="width: 487px">
                <asp:TextBox ID="txtUQQ" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Btnland" runat="server" CausesValidation="False" OnClick="Btnland_Click"
                    Text="返回登录框" Width="80px" />
                <asp:Button ID="btnSubmit" runat="server" Text="注册" OnClick="btnSubmit_Click" Width="80px" />
                <asp:Label ID="lblshow" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
