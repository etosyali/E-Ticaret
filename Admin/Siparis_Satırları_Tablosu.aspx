<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Siparis_Satırları_Tablosu.aspx.cs" Inherits="Kah_Satis.Admin.Siparis_Satırları_Tablosu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 74%;
    }
    .auto-style6 {
        width: 123px;
        height: 23px;
    }
    .auto-style7 {
        height: 23px;
        width: 252px;
    }
    .auto-style9 {
        width: 123px;
    }
    .auto-style10 {
        width: 252px;
    }
        .auto-style11 {
            width: 123px;
            position: absolute;
            z-index: auto;
            height: 23px;
        }
        .auto-style12 {
            width: 252px;
            position: absolute;
            z-index: auto;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1" OnActiveViewChanged="MultiView1_ActiveViewChanged">
    <asp:View ID="View1" runat="server">
        <table class="auto-style4">
            <tr>
                <td class="auto-style9" style="position: absolute; z-index: auto">Siparis Satır ID</td>
                <td class="auto-style10" style="position: absolute; z-index: auto">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" style="position: absolute; z-index: auto">Siparis ID</td>
                <td class="auto-style10" style="position: absolute; z-index: auto">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="position: absolute; z-index: auto">Urun ID</td>
                <td class="auto-style7" style="position: absolute; z-index: auto">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" style="position: absolute; z-index: auto">Miktar</td>
                <td class="auto-style10" style="position: absolute; z-index: auto">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" style="position: absolute; z-index: auto">&nbsp;</td>
                <td class="auto-style10" style="position: absolute; z-index: auto">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9" style="position: absolute; z-index: auto">
                    <asp:Button ID="Btn_Kaydet" runat="server" Text="KAYDET" OnClick="Btn_Kaydet_Click" />
                </td>
                <td class="auto-style10" style="position: absolute; z-index: auto">
                    <asp:Button ID="Btn_Listele" runat="server" Text="LISTELE" OnClick="Btn_Listele_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style12"></td>
            </tr>
            <tr>
                <td class="auto-style9" style="position: absolute; z-index: auto">
                    <asp:Label ID="Lbl_Sonuc" runat="server" Text="SONUC : "></asp:Label>
                </td>
                <td class="auto-style10" style="position: absolute; z-index: auto">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9" style="position: absolute; z-index: auto">&nbsp;</td>
                <td class="auto-style10" style="position: absolute; z-index: auto">&nbsp;</td>
            </tr>
        </table>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="Siparis_Satir_Id" HeaderText="SİPARİŞ SATIR ID" />
                <asp:BoundField DataField="Siparis_Id" HeaderText="SİPARİŞ ID" />
                <asp:BoundField DataField="Urun_Id" HeaderText="URUN ID" />
                <asp:BoundField DataField="Miktar" HeaderText="MİKTAR" />
                <asp:ButtonField ButtonType="Image" HeaderText="KAYDET" ImageUrl="~/Admin/Iconlar/edit-save-disk-file-icone-8170-32.png" CommandName="Guncelle" />
                <asp:ButtonField ButtonType="Image" HeaderText="GUNCELLE" ImageUrl="~/Admin/Iconlar/_active__save_as.png" CommandName="Yeni" />
            </Columns>
            <EmptyDataTemplate>
                VERİ YOKTUR
            </EmptyDataTemplate>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </asp:View>
    <asp:View ID="View3" runat="server">
    </asp:View>
</asp:MultiView>
</asp:Content>
