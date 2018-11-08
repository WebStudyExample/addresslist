<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ModifyPwd.aspx.cs" Inherits="ModifyPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        修改我的登录密码</h1>
    <b>欢迎</b><span style="color: #F00">
        <asp:Literal ID="Literal1" runat="server">
        </asp:Literal></span> <b>登录通讯录管理系统</b>
    <table>
        <tr>
            <td style="width: 100px" align="right">
                旧密码：
            </td>
            <td style="width: 372px">
                <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" CssClass="contact_input"
                    Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPwd"
                    Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 100px" align="right">
                新密码：
            </td>
            <td style="width: 372px">
                <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" CssClass="contact_input"
                    Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPwd"
                    Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNewPwd"
                    Display="Dynamic" ErrorMessage="请检查输入密码长度" ValidationExpression="\S{6,12}"></asp:RegularExpressionValidator><br />
                请输入长度在6-12位之间的密码
            </td>
        </tr>
        <tr>
            <td style="width: 100px" align="right">
                确认新密码：
            </td>
            <td style="width: 372px">
                <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password" CssClass="contact_input"
                    Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPwd"
                    Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPwd"
                    ControlToValidate="txtConfirmPwd" Display="Dynamic" ErrorMessage="输入密码不符"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 26px">
                <asp:Button ID="btnSubmit" runat="server" Text="确认" OnClick="btnSubmit_Click" />
                &nbsp;<asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click"
                    CausesValidation="False" />
            </td>
        </tr>
    </table>
</asp:Content>
