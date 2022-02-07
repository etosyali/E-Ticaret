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
    public partial class anlasmalikargo : System.Web.UI.Page
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
                    Label5.Text = ex.ToString();

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
                    SqlConnection kargocnn = Z29_Ka.Baglan();
                    string kargosorgu = "Select * from Anlasmali_Kargo_Sirketleri";
                    DataTable Dt_kargo = Z29_Ka.TabloOlustur(kargosorgu, kargocnn);
                    GridView1.DataSource = Dt_kargo;
                    GridView1.DataBind();
                    break;
                default:
                    break;
            }
        }
        private void kargo_listele()
        {
            string kargo_Sorgu = "SELECT * FROM Anlasmali_Kargo_Sirketleri";
            SqlConnection Rcc = Z29_Ka.Baglan();
            DataTable Dt_kargo = Z29_Ka.TabloOlustur(kargo_Sorgu, Rcc);
            GridView1.DataSource = Dt_kargo;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string kargo_Kaydet = "";

            kargo_Kaydet = "INSERT INTO [dbo].[Anlasmali_Kargo_Sirketleri] ";
            kargo_Kaydet += "([Unvani],[Adresi] ,[Vergi_Dairesi],[Vergi_No])";
            kargo_Kaydet += "Values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')"; 
            Label5.Text = Z29_Ka.Kaydet_Goncelle_Sil(kargo_Kaydet);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            kargo_listele();
        }
    }
}