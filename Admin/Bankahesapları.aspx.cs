using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kah_Satis.Admin
{
    public partial class Bankahesapları : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Veri Tabanına bağlan
                try
                {   bankalistele(); 
                }
                catch (Exception ex)
                {
                    Lbl_Sonuc.Text = ex.ToString();
                }



            }
        }

        protected void Btn_List_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            bankalistele();
        }
        protected void Btn_Kaydet_Click(object sender, EventArgs e)
        {
            string Banka_Kaydet = "";
            switch (Btn_Kaydet.Text)
            {
                case "Kaydet":
                    Banka_Kaydet = "INSERT INTO[dbo].[Anlasmali_Banka_Hesapları]";
                    Banka_Kaydet += "([Banka_Adi],[Sube_Kodu],[Hesap_No],[Iban])";
                    Banka_Kaydet += " VALUES ('" + TextBox1.Text + "','" + TxtKod.Text + "','" + Txt_hesapno.Text + "','";
                    Banka_Kaydet += txt_iban.Text + "')";
                    string sorgu = Banka_Kaydet;

                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Banka_Kaydet);
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "Guncelle":
                    Banka_Kaydet = "UPDATE [dbo].[Anlasmali_Banka_Hesapları] ";
                    Banka_Kaydet += "SET [Banka_Adi] = '" + TextBox1.Text + "'";
                      Banka_Kaydet += ",[Sube_Kodu] = ' " + TxtKod.Text + "'";
                    Banka_Kaydet += ",[Hesap_No] = ' " + Txt_hesapno.Text + "'";
                    Banka_Kaydet += ",[Iban] = ' " + txt_iban.Text + "'";

                    Banka_Kaydet += "WHERE Banka_Kodu='" + Lbl_Sonuc.Text + "'";
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Banka_Kaydet);
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "Sil":

                    break;
                default:
                    break;
            }
        }
        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {
            switch (MultiView1.ActiveViewIndex)
            {
                case 0:
                    // Yeni Giriş Ekranı
                    break;
                case 1:
                    bankalistele();
                    break;
                default:
                    break;
            }
        }

        private void bankalistele()
        {
            SqlConnection bankaconn = Z29_Ka.Baglan();
            string bankSorgu = "Select * from Anlasmali_Banka_Hesapları";
            DataTable Dt_Bank = Z29_Ka.TabloOlustur(bankSorgu, bankaconn);
            GridView1.DataSource = Dt_Bank;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Yeni":
                    MultiView1.ActiveViewIndex = 0;
                    TextBox1.Text = null;
                    txt_iban.Text = null;
                    TxtKod.Text = null;
                    Txt_hesapno.Text = null;


                    Btn_Kaydet.Text = "Kaydet";

                    break;
                case "Guncelle":
                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TextBox1.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[1].Text.ToString());
                    TxtKod.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[2].Text.ToString());
                    Txt_hesapno.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());
                    txt_iban.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[4].Text.ToString());

                    MultiView1.ActiveViewIndex = 0;
                    Btn_Kaydet.Text = "Guncelle";

                    break;
                case "Sil":
                    veri_sil(rowIndex);
                    break;

                default:
                    break;
            }
        }

        private void veri_sil(int rowIndex)
        {
            string Silinecek_Kaydın_Id = GridView1.Rows[rowIndex].Cells[0].Text.ToString();

            string SilmeKomutu = "DELETE FROM [dbo].[Anlasmali_Banka_Hesapları]";

            SilmeKomutu += " Where Banka_Kodu = '" + Silinecek_Kaydın_Id + "'";
            Z29_Ka.Kaydet_Guncelle_Sil(SilmeKomutu);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}



    