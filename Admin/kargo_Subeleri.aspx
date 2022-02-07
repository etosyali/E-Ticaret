<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="kargo_Subeleri.aspx.cs" Inherits="Kah_Satis.Admin.kargo_Subeleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 175px;
        }
        .auto-style5 {
            width: 332px;
        }
        .auto-style6 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">


        <asp:View ID="View1" runat="server">
            
            <table>
                <tr>
                    <td class="auto-style4">Kargo Şube No</td>
                    <td>:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Kargo</td>
                    <td>:</td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="DropDownList2" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Adres - İletişim</td>
                    <td>:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Il</td>
                    <td>:</td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table class="auto-style6">
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Oku" />
                                </td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Kaydet" />
                                </td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="Vazgeç" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
        </asp:View>


        <asp:View ID="View2" runat="server">

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="425px" OnRowCommand="GridView1_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Kargo_Sube_Id" HeaderText="Kargo Şube ID" />
                    <asp:BoundField DataField="Kargo_Id" HeaderText="Kargo_Id" />
                    <asp:BoundField DataField="Adres_İletisim_Bilgileri" HeaderText="Adres- İletişim" />
                    <asp:BoundField DataField="Il_Id" HeaderText="Il_Id" />
                    <asp:ButtonField ButtonType="Button" Text="Seç" />
                    <asp:ButtonField Text="Güncelle" ButtonType="Image" CommandName="Guncelle" ImageUrl="~/Admin/Iconlar/edit-save-disk-file-icone-8170-32.png">
                        <ItemStyle Height="5px" Width="5px" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Image" CommandName="Yeni" ImageUrl="~/Admin/Iconlar/_active__save_as.png" Text="Kaydet" />
                    <asp:ButtonField ButtonType="Image" CommandName="Sil" HeaderText="Sil" ImageUrl="~/Admin/Iconlar/delete.png" Text="Sil" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </asp:View>


    </asp:MultiView>






</asp:Content>
