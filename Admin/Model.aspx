<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Model.aspx.cs" Inherits="Kah_Satis.Admin.Model" %>
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
    .auto-style7 {
        text-align: center;
    }
    .auto-style8 {
        text-align: left;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1" OnActiveViewChanged="MultiView1_ActiveViewChanged">
    <asp:View ID="Giris" runat="server">
        <table>
            <tr>
                <td class="auto-style4">Model Adı</td>
                <td>:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
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
                            <td class="auto-style8" colspan="2">
                                <asp:Label ID="Lbl_Sonuc" runat="server" Text="Sonuç : "></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="Goruntuleme" runat="server">
        <table class="auto-style6">
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Model_Id" HeaderText="Model no" />
                            <asp:BoundField DataField="Model_Adi" HeaderText="Model Adı" />
                            <asp:ButtonField ButtonType="Image" CommandName="Yeni" ImageUrl="~/Admin/Iconlar/_active__save_as.png" Text="Yeni" />
                            <asp:ButtonField ButtonType="Image" CommandName="Guncelle" ImageUrl="~/Admin/Iconlar/edit-save-disk-file-icone-8170-32.png" Text="Düzelt" />
                            <asp:ButtonField ButtonType="Image" CommandName="Sil" ImageUrl="~/Admin/Iconlar/delete.png" Text="Sil" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <EmptyDataTemplate>
                            veri yok..
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
</asp:Content>
