<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="infoShow.aspx.cs" Inherits="infoShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        查询好友信息</h1>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>好友姓名</asp:ListItem>
        <asp:ListItem>好友QQ号</asp:ListItem>
        <asp:ListItem>好友手机</asp:ListItem>
        <asp:ListItem>地址</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="BtnSelect" runat="server" Text="查询" OnClick="BtnSelect_Click" Width="80px" />
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        Width="100%" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
        ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
            <asp:TemplateField HeaderText="缩略图">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Bind("frdImageUrl","~/Pictures/{0}") %>'
                        Width="40" Height="40" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="frdName" HeaderText="好友姓名" />
            <asp:BoundField DataField="frdPhone" HeaderText="电话" />
            <asp:BoundField DataField="frdQQ" HeaderText="QQ" />
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="Showfriend.aspx?UseId={0}"
                HeaderText="详细信息" Text="详细信息" />
        </Columns>
        <EmptyDataTemplate>
            <h2><b>该类还没有好友，赶紧添加一个吧！</b></h2>
        </EmptyDataTemplate>
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
<h2><span style="color:#F00">
                        <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
                        </span></h2>
</asp:Content>
