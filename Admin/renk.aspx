<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="renk.aspx.cs" Inherits="Kah_Satis.Admin.renk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 206px;
        }
        .auto-style5 {
            width: 219px;
        }
        .auto-style6 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">
        <asp:View ID="Giriş" runat="server">
            <table>
                <tr>
                    <td class="auto-style4">Renk Adı</td>
                    <td>:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TxtAd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Renk Resmi</td>
                    <td>:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TxtResim_Yol" runat="server" Width="213px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Resmi Yükle" OnClick="Button1_Click" />
                        
                        
                    </td>
                    <td>&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Image ID="Image1" runat="server" Height="200px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table class="auto-style6">
                            <tr>
                                <td>
                                    <asp:Button ID="BtnKaydet" runat="server" Text="Kaydet" />
                                </td>
                                <td>
                                    <asp:Button ID="Btn_Liste" runat="server" Text="Listele" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Lbl_Sonuc" runat="server" Text="Sonuç"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="Listele" runat="server">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Renk_Id" HeaderText="Renk No" />
                    <asp:BoundField DataField="Renk_Adi" HeaderText="Renk Adı" />
                    <asp:ImageField DataAlternateTextFormatString="~/Admin/Iconlar/Resim_Yok.png" DataImageUrlField="Renk_Resmi_Yolu" HeaderText="Renk" NullImageUrl="~/Admin/Iconlar/Resim_Yok.png">
                    </asp:ImageField>
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
    </asp:MultiView>
</asp:Content>
