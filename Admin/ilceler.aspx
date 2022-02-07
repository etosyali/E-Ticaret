<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ilceler.aspx.cs" Inherits="Kah_Satis.Admin.ilceler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 139px;
    }
    .auto-style5 {
        width: 237px;
    }
    .auto-style6 {
        width: 100%;
    }
    .auto-style7 {
        text-align: center;
    }
    .auto-style8 {
        width: 186px;
    }
    .auto-style9 {
        width: 225px;
    }
    .auto-style10 {
        width: 195px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1" OnActiveViewChanged="MultiView1_ActiveViewChanged">
    <asp:View ID="Giris" runat="server">
        <table>
            <tr>
                <td class="auto-style4">İller</td>
                <td>:</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DD_Iller" runat="server" Width="195px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">İlçe Kodu</td>
                <td>:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TxtKod" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">İlçe Adı</td>
                <td>:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TxtAd" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table class="auto-style6">
                        <tr>
                            <td class="auto-style7">
                                <asp:Button ID="Btn_Kaydet" runat="server" OnClick="Btn_Kaydet_Click" Text="Kaydet" />
                            </td>
                            <td class="auto-style7">
                                <asp:Button ID="Btn_List" runat="server" OnClick="Btn_List_Click" Text="Listele" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Lbl_Sonuc" runat="server" Text="Sonu :"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="Listele" runat="server">
        <table>
            <tr>
                <td class="auto-style8">İl Seçiniz </td>
                <td>:</td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DD_Iller_List" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DD_Iller_List_SelectedIndexChanged" Width="190px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableSortingAndPagingCallbacks="True" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Plaka" HeaderText="Plaka" ShowHeader="False" />
                            <asp:BoundField DataField="Sehir" HeaderText="İl" SortExpression="Sehir" />
                            <asp:BoundField DataField="Kod" HeaderText="İlçe Kodu" SortExpression="Kod" />
                            <asp:BoundField DataField="Ilce" HeaderText="İlçe Adı" />
                            <asp:ButtonField ButtonType="Image" CommandName="Yeni" ImageUrl="~/Admin/Iconlar/_active__save_as.png" ShowHeader="True" Text="Yeni İlçe " />
                            <asp:ButtonField ButtonType="Image" CommandName="Guncelle" ImageUrl="~/Admin/Iconlar/edit-save-disk-file-icone-8170-32.png" ShowHeader="True" Text="Güncelle" />
                            <asp:ButtonField ButtonType="Image" CommandName="Sil" ImageUrl="~/Admin/Iconlar/delete.png" Text="Sil" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
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
                </td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
</asp:Content>
