<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="infoDelete.aspx.cs" Inherits="infoDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        删除好友信息</h1>
    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
        CellPadding="4" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
        ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <Columns>
            <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="缩略图">
                <ItemTemplate>
                   <asp:Image ID="Image1" runat="server"  ImageUrl='<%#Bind("frdImageUrl","~/Pictures/{0}") %>' Width="40" Height="40" />
                </ItemTemplate>
            </asp:TemplateField>            
            
            <asp:BoundField DataField="frdName" HeaderText="好友姓名" />
            <asp:BoundField DataField="frdPhone" HeaderText="电话"  />
            <asp:BoundField DataField="frdQQ" HeaderText="QQ" />
            <asp:BoundField DataField="CreateDate" HeaderText="创建时间" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
        </Columns>
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <h2>
        <span style="color: #F00">
            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
        </span>
    </h2>
    </asp:Content>
