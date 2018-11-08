<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="infoEdit.aspx.cs" Inherits="infoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <h1>修改好友信息</h1>
<asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
        CellPadding="4"  AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
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
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="infoEditSave.aspx?UserId={0}"
                HeaderText="修改" Text="操作" />
        </Columns>
        <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
</asp:Content>

