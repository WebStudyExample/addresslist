<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="infoNew.aspx.cs" Inherits="infoNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>添加<asp:Label ID="lblID" runat="server"></asp:Label>好友信息</h1>
    类别：<asp:DropDownList ID="DDLsrot" runat="server" Width="100px">
    </asp:DropDownList>
    <span style="color: red">＊注意确认为所显示的类别！＊</span><br />
    姓名：<asp:TextBox ID="textName" runat="server" cssclass="contact_input"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textName"
        ErrorMessage="姓名不能为空"></asp:RequiredFieldValidator><br />
    电话号码：<asp:TextBox ID="textPhone" runat="server" cssclass="contact_input"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="textPhone"
        ErrorMessage="请输入7位或8位电话号码" ValidationExpression="(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}"></asp:RegularExpressionValidator><br />
    手机号码：<asp:TextBox ID="textMobile" runat="server" cssclass="contact_input"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="textMobile"
        ErrorMessage="请输入11位的手机号" ValidationExpression="\d{11}"></asp:RegularExpressionValidator><br />
    地 址：<asp:TextBox ID="textAddress" runat="server" cssclass="contact_input"></asp:TextBox><br />
    Q&nbsp; Q：<asp:TextBox ID="TextQQ" runat="server" cssclass="contact_input"></asp:TextBox><br />
    Email：<asp:TextBox ID="textEmail" runat="server" cssclass="contact_input"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textEmail"
        ErrorMessage="邮箱格式不对" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
    上传照片：
    <input id="Uploadpri" style="width: 333px" runat="server" type="file" /><br />
    好友概况:
    <br />
    <asp:TextBox ID="txtgeneral" runat="server" Height="120px" TextMode="MultiLine" Width="370px"></asp:TextBox><br />
    <asp:Button ID="BtnAdddata" runat="server" Text="添加" OnClick="BtnAdddata_Click" Width="80px" />
    &nbsp;<asp:Button ID="Button1" runat="server" CausesValidation="False" OnClick="Button1_Click"  Text="重置" Width="80px" />
    &nbsp;<asp:Button ID="Button2" runat="server" CausesValidation="False" OnClick="Button2_Click"  Text="刷新" Width="80px" />
</asp:Content>
