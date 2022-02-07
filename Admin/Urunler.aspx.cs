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
    public partial class Urunler : System.Web.UI.Page
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
                    Label13.Text = ex.ToString();

                }
            }
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {
            switch (MultiView1.ActiveViewIndex)
            {
                case 0:
                  


                    break;
                case 1:
                    SqlConnection uruncnn = Z29_Ka.Baglan();
                    string Urunsorgu = "Select * from Urunler";
                    DataTable Dt_urun = Z29_Ka.TabloOlustur(Urunsorgu, uruncnn);
                    GridView1.DataSource = Dt_urun;
                    GridView1.DataBind();
                    break;
                default:
                    break;
            }
        }

        private void Urunler_listele()
        {

            // string Urun_Sorgu = "SELECT TOP (1000) [Urun_Id],[Urun_Adi],[Fiyat_Listesi_Id],[Stok_Miktari],[Uretim_Suresi],[Olcu_Id],[Kategori_Id],[Renk_Id],[Aksesuar_Id],[Cep_Sayisi],[Model_Id] FROM [dbo].[Urunler]";

            string Urun_Sorgu = "SELECT * FROM Urunler";
            SqlConnection Rcc = Z29_Ka.Baglan();
            DataTable Dt_Urun = Z29_Ka.TabloOlustur(Urun_Sorgu, Rcc);
            GridView1.DataSource = Dt_Urun;
            GridView1.DataBind();
        }

        protected void btn_kaydet_Click(object sender, EventArgs e)
        {
            string Urun_Kaydet = "";

            Urun_Kaydet = "INSERT INTO [dbo].[Urunler] ";
            Urun_Kaydet += "([Urun_Adi],[Stok_Miktari] ,[Uretim_Suresi],[Fiyat_Listesi_Id],[Olcu_Id],[Kategori_Id],[Renk_Id],[Aksesuar_Id],[Model_Id],[Cep_Sayisi])";
            Urun_Kaydet += "Values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + DropDownList1.SelectedValue.ToString() + "','";
            Urun_Kaydet += TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox4.Text + "')";
            Label13.Text = Z29_Ka.Kaydet_Guncelle_Sil(Urun_Kaydet);

        }

        protected void btn_Listele_Click(object sender, EventArgs e)
        {

            MultiView1.ActiveViewIndex = 1;

        }
    }
}