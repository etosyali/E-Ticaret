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
    public partial class Ulkeler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        protected void Btn_Kydt_Click(object sender, EventArgs e)
        {
            string Ulke_Kydt = "";
            Ulke_Kydt = "INSERT INTO [dbo].[Ulkeler]";
            Ulke_Kydt += "([UlkeId],[IkiliKod],[UcluKod],[UlkeAdi],[TelKodu])";
            Ulke_Kydt += "VALUES ('" + TextBox1.Text + "' , '" + TextBox2.Text + "' , '" + TextBox3.Text + "' , '" + TextBox4.Text + "' , '" + TextBox5.Text + "' , '" + "')";
            Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Ulke_Kydt);
        }

        protected void Btn_Listele_Click(object sender, EventArgs e)
        {
            SqlConnection UlkeCnn = Z29_Ka.Baglan();
            string UlkeSorgu = "SELECT * FROM Ulkeler";
            DataTable Dt_Ulke = Z29_Ka.TabloOlustur(UlkeSorgu, UlkeCnn);
            GridView1.DataSource = Dt_Ulke;
            GridView1.DataBind();
        }

        protected void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            string Ulke_Guncelle = "";
            Ulke_Guncelle = "[dbo].[Ulkeler] SET [UlkeId] ='" + TextBox1.Text;
            Ulke_Guncelle += "' ,[IkiliKod]='" + TextBox2.Text + "' ,[UcluKod]= '" + TextBox3.Text + "' ,[UlkeAdi] = '" + TextBox4.Text + "'   ,[TelKodu] = '" + TextBox5.Text;
            Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Ulke_Guncelle);
        }
    }
}