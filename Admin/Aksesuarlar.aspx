<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Aksesuarlar.aspx.cs" Inherits="Kah_Satis.Admin.Aksesuarlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 674px;
        }
        .auto-style5 {
            width: 9px;
        }
        .auto-style8 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged1">
    
    <asp:View ID="GİRİŞ" runat="server">
        <table class="auto-style4">
            <tr>
                <td>Aksesuar Adı</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Aksesuar Rengi ID<asp:Label ID="Lbl_Renk" runat="server" Visible="False"></asp:Label>
                </td>
                <td>:</td>
                <td class="auto-style8">
                    <asp:TextBox ID="TextBox2" runat="server" Width="67px"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="..." Width="32px" />
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="GridView2_RowCommand" Visible="False">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:BoundField DataField="Renk_Id" HeaderText="Renk Kodu" />
                            <asp:BoundField DataField="Renk_Adi" HeaderText="Adı" />
                            <asp:ImageField DataImageUrlField="Renk_Resmi_Yolu" HeaderText="Renk Kataloğu" NullImageUrl="~/Admin/Iconlar/Resim_Yok.png">
                            </asp:ImageField>
                            <asp:ButtonField CommandName="Sec" Text="Seç" />
                        </Columns>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>Aksesuar Resim Yolu</td>
                <td>:</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="RESMİ YÜKLE" />
                </td>
            </tr>
            <tr>
                <td>
                    Kod</td>
                <td>:</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnKaydet" runat="server" OnClick="btnKaydet_Click" Text="KAYDET" Width="115px" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnListele" runat="server" OnClick="btnListele_Click" Text="LİSTELE" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSonuc" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
        </table>
        </asp:View>
    <asp:View ID="LİSTELE" runat="server">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" EnableSortingAndPagingCallbacks="True" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Aksesuar_Id" HeaderText="Aksesuar ID" />
                <asp:BoundField DataField="Aksesuar_Adi" HeaderText="Aksesuar Adı" />
                <asp:BoundField DataField="Aksesuar_Rengi_Id" HeaderText="Aksesuar Rengi ID" />
                <asp:BoundField DataField="Aksesuar_Resmi_Yolu" HeaderText="Aksesuar Resim Yolu" />
                            <asp:BoundField DataField="Kod" HeaderText="Kod" />
                            <asp:ButtonField ButtonType="Image" CommandName="Guncelle" ImageUrl="~/Admin/Iconlar/edit-save-disk-file-icone-8170-32.png" Text="Düzelt" HeaderText="Düzelt" />
                            <asp:ButtonField ButtonType="Image" CommandName="Yeni" ImageUrl="~/Admin/Iconlar/_active__save_as.png" Text="Yeni" HeaderText="Yeni" />
                <asp:ButtonField ButtonType="Image" CommandName="Sil" HeaderText="Sil" ImageUrl="~/Admin/Iconlar/button_cancel.png" Text="Sil" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <EmptyDataTemplate>
                Veri Yok
            </EmptyDataTemplate>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        </asp:View></asp:MultiView>
</asp:Content>
