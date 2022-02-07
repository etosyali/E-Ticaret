<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Urunler.aspx.cs" Inherits="Kah_Satis.Admin.Urunler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 100%;
    }
    .auto-style5 {
        height: 23px;
    }
    .auto-style6 {
        margin-left: 0px;
    }
    .auto-style7 {
        height: 26px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">
    <asp:View ID="Giriş" runat="server">
        <table class="auto-style4">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Urun Adı"></asp:Label>
                    :</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style6" Width="182px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label3" runat="server" Text="Stok Mİktarı"></asp:Label>
                    :</td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style6" Width="183px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label2" runat="server" Text="Üretim Süresi"></asp:Label>
                    :</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="auto-style6" Width="183px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">:<asp:Label ID="Label12" runat="server" Text="Fiyat listesi ID"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="auto-style6" Width="183px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label5" runat="server" Text="Ölçü ID"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox7" runat="server" CssClass="auto-style6" Width="183px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label6" runat="server" Text="Kategori ID"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="18px" Width="184px">
                        <asp:ListItem>kategori 1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Renk ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server" CssClass="auto-style6" Width="183px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Aksesuar ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" CssClass="auto-style6" Width="183px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label10" runat="server" Text="Model ID"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox11" runat="server" CssClass="auto-style6" Width="183px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label11" runat="server" Text="Cep sayısı"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style6" Width="183px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Button ID="btn_kaydet" runat="server" BackColor="#99CCFF" OnClick="btn_kaydet_Click" Text="Kaydet" />
                </td>
                <td class="auto-style5">
                    <asp:Button ID="btn_Listele" runat="server" BackColor="#99CCFF" Text="Listele" OnClick="btn_Listele_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label13" runat="server"></asp:Label>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="Listele" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1237px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Urun_Id" HeaderText="Ürün ID" />
                <asp:BoundField DataField="Stok_Miktari" HeaderText="Stok Miktarı" />
                <asp:BoundField DataField="Urun_Adi" HeaderText="Ürün Adı" />
                <asp:BoundField DataField="Uretim_Suresi" HeaderText="Üretim Süresi" />
                <asp:BoundField DataField="Fiyat_Listesi_Id" HeaderText="Fiyat listesi ID" />
                <asp:BoundField DataField="Olcu_Id" HeaderText="Ölçü ID" />
                <asp:BoundField DataField="Kategori_Id" HeaderText="Kategori ID" />
                <asp:BoundField DataField="Renk_Id" HeaderText="Renk ID" />
                <asp:BoundField DataField="Aksesuar_Id" HeaderText="Aksesuar ID" />
                <asp:BoundField DataField="Model_Id" HeaderText="Model ID" />
                <asp:BoundField DataField="Cep_Sayisi" HeaderText="Cep sayısı" />
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
    </asp:View>
    <br />
    <br />
</asp:MultiView>
</asp:Content>
