<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Bankahesapları.aspx.cs" Inherits="Kah_Satis.Admin.Bankahesapları" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 191px;
    }
    .auto-style5 {
        width: 354px;
    }
    .auto-style6 {
        width: 100%;
    }
    .auto-style8 {
        text-align: left;
    }
        .auto-style9 {
            width: 9px;
        }
        .auto-style10 {
            text-align: center;
            height: 30px;
        }
        .auto-style11 {
            text-align: left;
            height: 30px;
        }
        .auto-style12 {
            height: 30px;
        }
        .auto-style13 {
            width: 9px;
            height: 30px;
        }
        .auto-style14 {
            width: 191px;
            height: 26px;
        }
        .auto-style15 {
            height: 26px;
        }
        .auto-style16 {
            width: 354px;
            height: 26px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">
    <asp:View ID="Giris" runat="server">
        <table>
            <tr>
                <td class="auto-style4">Banka</td>
                <td>:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Şube Kodu</td>
                <td>:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TxtKod" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">Hesap No</td>
                <td class="auto-style15">:</td>
                <td class="auto-style16">
                    <asp:TextBox ID="Txt_hesapno" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">Iban</td>
                <td class="auto-style15"></td>
                <td class="auto-style16">
                    <asp:TextBox ID="txt_iban" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table class="auto-style6">
                        <tr>
                            <td class="auto-style10">
                                <asp:Button ID="Btn_Kaydet" runat="server" OnClick="Btn_Kaydet_Click" Text="Kaydet" />
                            </td>
                            <td class="auto-style10">
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
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style13">
                    </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" EnableSortingAndPagingCallbacks="True" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Banka_Kodu" HeaderText="Banka No" />
                            <asp:BoundField DataField="Banka_Adi" HeaderText="Banka Adı" />
                            <asp:BoundField DataField="Sube_Kodu" HeaderText="Şube Kodu" SortExpression="Sehir" />
                            <asp:BoundField DataField="Hesap_No" HeaderText="Hesap No" SortExpression="Kod" />
                            <asp:BoundField DataField="Iban" HeaderText="Iban" />
                            <asp:ButtonField ButtonType="Image" CommandName="Yeni" ImageUrl="~/Admin/Iconlar/_active__save_as.png" ShowHeader="True" Text="Yeni Banka" />
                            <asp:ButtonField ButtonType="Image" CommandName="Guncelle" ImageUrl="~/Admin/Iconlar/edit-save-disk-file-icone-8170-32.png" ShowHeader="True" Text="Güncelle" />
                            <asp:ButtonField CommandName="Sil" Text="Sil" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <EmptyDataTemplate>
                            veri yok
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
                <td class="auto-style9">&nbsp;</td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>



</asp:Content>
