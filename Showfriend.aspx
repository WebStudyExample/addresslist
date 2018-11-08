<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Showfriend.aspx.cs" Inherits="Showfriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        好友详细信息
    </h1>
    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" />
    <p>
        <b>【编号】：<asp:Literal ID="ltrUserID" runat="server"></asp:Literal></b>
        <br />
        【姓名】：
        <asp:Literal ID="ltrFrdName" runat="server"></asp:Literal><br />
        【电话】：
        <asp:Literal ID="ltrFrdPhone" runat="server"></asp:Literal><br />
        【Q Q】：
        <asp:Literal ID="ltrFrdQQ" runat="server"></asp:Literal><br />
        【手机号】：
        <asp:Literal ID="ltrFrdMobilePhone" runat="server"></asp:Literal><br />
        【家庭住址】：
        <asp:Literal ID="ltrFrdAddress" runat="server"></asp:Literal><br />
        【电子邮箱】：
        <asp:Literal ID="ltrFrdEmail" runat="server"></asp:Literal><br />
        【照片更新时间】：
        <asp:Literal ID="ltrFrdTime" runat="server"></asp:Literal><br />
        【基本概况】：
        <asp:Literal ID="ltrFrdGeneral" runat="server"></asp:Literal>
    </p>
    <asp:Button ID="Button" runat="server" OnClick="Button_Click" Text="返回上一页" />
</asp:Content>
