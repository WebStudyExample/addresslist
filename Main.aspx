<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main"
    MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>���ѷ���</h1>
    <asp:DropDownList ID="DDLmostly" runat="server" OnSelectedIndexChanged="DDLmostly_SelectedIndexChanged"
        Width="60px">
    </asp:DropDownList>
    <asp:Button ID="Btndata" runat="server" Text="����鿴" OnClick="Btndata_Click" />
    <br />
    <br />
    <asp:GridView ID="GVdata" runat="server" AutoGenerateColumns="False" CellPadding="4"
        AllowPaging="True" OnPageIndexChanging="GVdata_PageIndexChanging" Width="100%"
        ForeColor="#333333" GridLines="None" EnableTheming="False" EnableViewState="False">
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
            <asp:BoundField DataField="userId" HeaderText="�û���" Visible="False" />
            <asp:BoundField DataField="sortname" HeaderText="���" />
            <asp:BoundField DataField="frdName" HeaderText="��������" />
            <asp:BoundField DataField="frdQQ" HeaderText="���ѣѣ�" />
            <asp:BoundField DataField="frdEmail" HeaderText="E-mail" />
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="Showfriend.aspx?UseId={0}"
                HeaderText="��ϸ����" Text="��ϸ����" />
        </Columns>
        <RowStyle ForeColor="#333333" HorizontalAlign="Center" BackColor="#F7F6F3" />
        <EmptyDataTemplate>
            <h2>
                <b>���໹û�к��ѣ��Ͻ����һ���ɣ�</b></h2>
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</asp:Content>