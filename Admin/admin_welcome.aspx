<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="admin_welcome.aspx.cs" Inherits="Kah_Satis.Admin.admin_welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style5 {
        width: 214px;
    }
    .auto-style6 {
        width: 217px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Pnl_1" runat="server" Height="335px" Width="637px">
    <table>
        <tr>
            <td class="auto-style5">Hoş Geldiniz </td>
            <td>:</td>
            <td class="auto-style6">
                <asp:Label ID="Lbl_UserName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Rol</td>
            <td>:</td>
            <td class="auto-style6">
                <asp:Label ID="Lbl_Rol" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>
