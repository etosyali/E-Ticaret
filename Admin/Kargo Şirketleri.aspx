<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Kargo Şirketleri.aspx.cs" Inherits="Kah_Satis.Admin.Kargo_Şirketleri" %>
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
    .auto-style10 {
        width: 195px;
    }
        .auto-style11 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">
    <asp:View ID="Giris" runat="server">
        <table>
            <tr>
                <td class="auto-style4">Kargo Unvanı</td>
                <td>:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="Txt_Unvan" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Kargo Adresi</td>
                <td>:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="Txt_Adres" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Vergi Dairesi</td>
                <td>:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="Txt_Ver_Dairesi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Vergi No</td>
                <td>:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="Txt_Ver_No" runat="server"></asp:TextBox>
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
                            <td colspan="2" class="auto-style11">
                                Sonuç :<asp:Label ID="Lbl_Sonuc" runat="server" Text="Label"></asp:Label>
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
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableSortingAndPagingCallbacks="True" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Kargo_Id" HeaderText="Kargo No" />
                            <asp:BoundField DataField="Unvani" HeaderText="Kargo Unvanı" />
                            <asp:BoundField DataField="Adresi" HeaderText="Kargo Adresi" />
                            <asp:BoundField DataField="Vergi_Dairesi" HeaderText="Vergi Dairesi" />
                            <asp:BoundField DataField="Vergi_No" HeaderText="Vergi No" />
                            <asp:ButtonField ButtonType="Image" CommandName="Guncelle" ImageUrl="~/Admin/Iconlar/edit-save-disk-file-icone-8170-32.png" ShowHeader="True" Text="Güncelle" />
                            <asp:ButtonField ButtonType="Image" CommandName="Yeni" ImageUrl="~/Admin/Iconlar/_active__save_as.png" ShowHeader="True" Text="Yeni Şube" />
                            <asp:ButtonField ButtonType="Image" CommandName="Sil" ImageUrl="~/Admin/Iconlar/sil.jpg" Text="Sil" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <EmptyDataTemplate>
                            Veri Yok...
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
