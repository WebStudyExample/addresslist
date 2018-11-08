<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="manageSort.aspx.cs" Inherits="manageSort" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>管理我的好友分类</h1>
    <h2><b>*注意:不能有重复的类别编号</b></h2>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        Height="268px" HorizontalAlign="Center" ShowFooter="True" Width="100%" CellPadding="4"
        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"
        OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting"
        OnRowUpdating="GridView1_RowUpdating" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="wid" FooterText="ID" Visible="False" />
            <asp:TemplateField HeaderText="类别编号">
                <EditItemTemplate>
                    <asp:TextBox ID="txtnumber" runat="server" Text='注意此项不可修改' Enabled="False"></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtnewno" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblnumber" runat="server" Text='<%#Bind("sortnumber") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="类别名称">
                <EditItemTemplate>
                    <asp:TextBox ID="txtname" runat="server" Text='<%#Bind("sortname") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtnewname" runat="server"></asp:TextBox>&nbsp;
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" Text='<%#Bind("sortname") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <EditItemTemplate>
                    <asp:Button ID="Btnupdate" runat="server" CommandName="Update" Text="修改" />
                    <asp:Button ID="Btncancel" runat="server" CommandName="Cancel" Text="取消" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Btninsert" runat="server" CommandName="Insert" Text="新增" ValidationGroup="Insert" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Button ID="Btnedit" runat="server" CommandName="Edit" Text="修改" />
                    <asp:Button ID="Btndelete" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="删除" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
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
