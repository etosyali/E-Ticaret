<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Kah_Satis.Admin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 30px;
        }
        .auto-style3 {
            width: 102px;
        }
        .auto-style4 {
            margin-left: 64px;
        }
        .auto-style5 {
            margin-left: 9px;
        }
        .auto-style6 {
            width: 19%;
        }
        .auto-style7 {
            width: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="Kullanici_Adi" runat="server" Text="Kullanıcı ADI :"></asp:Label>
                        <asp:TextBox ID="Txt_Kullanici" runat="server" CssClass="auto-style5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="sifre" runat="server" Text="Şifre :"></asp:Label>
                        <asp:TextBox ID="Txt_Sifre" runat="server" CssClass="auto-style4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Rolü :"></asp:Label>
                        <asp:DropDownList ID="DD_Rol" runat="server" CssClass="auto-style4">
                            <asp:ListItem Value="0">Admin</asp:ListItem>
                            <asp:ListItem Value="1">User</asp:ListItem>
                            <asp:ListItem Value="2">Quest</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table class="auto-style6">
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="Kaydet" runat="server" OnClick="Kaydet_Click" Text="Kaydet" />
                        <asp:Button ID="Btn_Guncelle" runat="server" OnClick="Btn_Guncelle_Click" Text="Güncelle" />
                    </td>
                    <td class="auto-style7">
                        <asp:Button ID="Btn_Listele" runat="server" OnClick="Btn_Listele_Click" Text="Listele" />
&nbsp;&nbsp; </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="Lbl_Sonuc" runat="server"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Kullanıcı Adı" />
                <asp:BoundField DataField="pass" HeaderText="Şifre" />
                <asp:BoundField DataField="Rol" HeaderText="Rolü" />
                <asp:ButtonField CommandName="Guncelle" Text="Güncelle" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </form>
</body>
</html>
