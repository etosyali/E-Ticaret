<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="anlasmalibanka.aspx.cs" Inherits="Kah_Satis.Admin.anlasmalibanka" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            width: 412px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">
        <asp:View ID="Giris" runat="server">
            <table class="auto-style4">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label1" runat="server" Text="Sube Kodu"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" Text="Hesap No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label3" runat="server" Text="Iban"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table class="auto-style4">
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Kaydet" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Listele" OnClick="Button2_Click" />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </asp:View>
        <asp:View ID="Listele" runat="server">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="471px">
                <Columns>
                    <asp:BoundField DataField="Sube_Kodu" HeaderText="Sube Kodu" />
                    <asp:BoundField DataField="Hesap_No" HeaderText="Hesap No" />
                    <asp:BoundField DataField="Iban" HeaderText="Iban" />
                    <asp:ButtonField CommandName="Guncelle" Text="Duzelt" />
                    <asp:ButtonField CommandName="Yeni" Text="Yeni" />
                    <asp:ButtonField CommandName="Sil" Text="Sil" />
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
