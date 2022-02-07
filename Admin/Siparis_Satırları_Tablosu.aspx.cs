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
    public partial class Siparis_Satırları_Tablosu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Veri Tabanına bağlan
                try
                {
                    SqlConnection kopru = Z29_Ka.Baglan();
                }
                catch (Exception ex)
                {
                    Lbl_Sonuc.Text = ex.ToString();

                }
            }
        }
        protected void Btn_Listele_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        protected void Btn_Kaydet_Click(object sender, EventArgs e)
        {
            string Siparis_Kaydet = "";
            switch (Btn_Kaydet.Text)
            {
                case "Kaydet":
                    Siparis_Kaydet = " Insert Into Siparis_Satırları_Tablosu  ";
                    //Siparis_Kaydet += "Siparis_Satir_Id  values'" + TextBox1.Text + "')"; - Otomatik olarak atanacak değer
                    //Siparis_Kaydet += "Siparis_Id  values'" + TextBox2.Text + "')"; - Siparis tablosundan atanıp gelecek olan değer
                    //Siparis_Kaydet += "Urun_Id values '" + TextBox3.Text + "')"; - Urunler tablosundan gelecek olan değer
                    Siparis_Kaydet += " Miktar values '" + TextBox4.Text + "')"; //-->değiştirilecek olan kısım => miktar

                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Siparis_Kaydet);
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "Guncelle":
                    Siparis_Kaydet = "UPDATE [dbo].[Siparis_Satırları_Tablosu] ";
                    Siparis_Kaydet += " SET [Miktar] = '" + TextBox4.Text + "'";
                    Siparis_Kaydet += " WHERE Siparis_Id ='" + Lbl_Sonuc.Text + "'"; 
                    //veya " Where Urun_Id = '"+ Lbl_Sonuc.Text + "'";
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Siparis_Kaydet);
                    MultiView1.ActiveViewIndex = 1;
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
                    SqlConnection SiparisCnn = Z29_Ka.Baglan();
                    string SiparisSorgu = "Select * from Siparis_Satırları_Tablosu";
                    DataTable Dt_Siparis = Z29_Ka.TabloOlustur(SiparisSorgu, SiparisCnn);
                    GridView1.DataSource = Dt_Siparis;
                    GridView1.DataBind();
                    break;
                default:
                    break;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Yeni":
                    MultiView1.ActiveViewIndex = 0;
                    TextBox4.Text = null;
                    Btn_Kaydet.Text = "Kaydet";

                    break;
                case "Guncelle":
                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TextBox4.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    MultiView1.ActiveViewIndex = 0;
                    Btn_Kaydet.Text = "Guncelle";

                    break;
                case "Sil":

                    break;

                default:
                    break;
            }
        }
    }
}