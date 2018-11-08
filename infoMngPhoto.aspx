<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="infoMngPhoto.aspx.cs" Inherits="infoMngPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        更新好友近期照片</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" AllowPaging="True"
        OnPageIndexChanging="GridView1_PageIndexChanging" ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="编号" />
            <asp:TemplateField HeaderText="缩略图">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Bind("frdImageUrl","~/Pictures/{0}") %>'
                        Width="40" Height="40" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="frdName" HeaderText="好友姓名" />
            <asp:BoundField DataField="CreateDate" HeaderText="创建时间" />
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" HeaderText="上传照片" />
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="Showfriend.aspx?UseId={0}"
                HeaderText="详细资料" Text="详细资料" />
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
            <asp:Literal ID="ltrMsg" runat="server" Visible="False"></asp:Literal>
        </span>
    </h2>
    <asp:Panel ID="pnlUpdata" runat="server" Visible="false">
        上传 <b><asp:Literal ID="ltrfrdinf" runat="server" /></b> 
        近期照片: &nbsp;<input id="Uploadpri" type="file" runat="server" />
        <br />
        <asp:Button runat="server" Text="上传照片" ID="BtnPhoto" OnClick="BtnPhoto_Click" />
    </asp:Panel>
</asp:Content>
