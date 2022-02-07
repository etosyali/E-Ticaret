using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Kah_Satis
{
    public class Z29_Ka
    {
        public static SqlConnection Baglan()
        {
            SqlConnection Kopru = new SqlConnection(ConfigurationManager.ConnectionStrings["kahConnectionString"].ConnectionString);
            return Kopru;
        }
        public static string Kaydet_Guncelle_Sil(string Kaydet_islev)
        {
            string sonuc = "";
            try
            {
                SqlConnection Anahtar = Z29_Ka.Baglan();
                SqlCommand Komut = new SqlCommand();
                Komut.CommandType = CommandType.Text;
                Komut.CommandText = Kaydet_islev;
                Komut.Connection = Anahtar;
                Anahtar.Open();
                Komut.ExecuteNonQuery();
                Anahtar.Close();
                sonuc = "İşlem Başarılı";
            }
            catch (Exception Hata)
            {
                sonuc = Hata.ToString();
            }
            return sonuc;

        }
        public static DataTable TabloOlustur(string sorgu, SqlConnection Anahtar)
        {
            DataTable P_Liste = new DataTable();
            SqlCommand Komut = new SqlCommand();
            Komut.CommandType = CommandType.Text;
            Komut.CommandText = sorgu;
            Komut.Connection = Anahtar;
            Anahtar.Open();
            SqlDataAdapter Adap = new SqlDataAdapter(Komut);
            Komut.ExecuteNonQuery();
            Adap.Fill(P_Liste);
            Anahtar.Close();
            return P_Liste;

        }
        public static void DDDoldur(DropDownList DD, DataTable P_list, string ValueField, string TextField)
        {
            DD.DataSource = P_list;
            DD.DataValueField = ValueField;
            DD.DataTextField = TextField;
            DD.DataBind();
            DD.Items.Insert(0, new ListItem("Seçiniz...", "0"));
        }
    }
}