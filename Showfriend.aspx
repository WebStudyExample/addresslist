<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Showfriend.aspx.cs" Inherits="Showfriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        ������ϸ��Ϣ
    </h1>
    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" />
    <p>
        <b>����š���<asp:Literal ID="ltrUserID" runat="server"></asp:Literal></b>
        <br />
        ����������
        <asp:Literal ID="ltrFrdName" runat="server"></asp:Literal><br />
        ���绰����
        <asp:Literal ID="ltrFrdPhone" runat="server"></asp:Literal><br />
        ��Q Q����
        <asp:Literal ID="ltrFrdQQ" runat="server"></asp:Literal><br />
        ���ֻ��š���
        <asp:Literal ID="ltrFrdMobilePhone" runat="server"></asp:Literal><br />
        ����ͥסַ����
        <asp:Literal ID="ltrFrdAddress" runat="server"></asp:Literal><br />
        ���������䡿��
        <asp:Literal ID="ltrFrdEmail" runat="server"></asp:Literal><br />
        ����Ƭ����ʱ�䡿��
        <asp:Literal ID="ltrFrdTime" runat="server"></asp:Literal><br />
        �������ſ�����
        <asp:Literal ID="ltrFrdGeneral" runat="server"></asp:Literal>
    </p>
    <asp:Button ID="Button" runat="server" OnClick="Button_Click" Text="������һҳ" />
</asp:Content>
