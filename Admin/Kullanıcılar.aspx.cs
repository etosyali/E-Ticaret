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
    public partial class WebForm1 : System.Web.UI.Page
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

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            string kayit = "";
            SqlConnection user_cnn = Z29_Ka.Baglan();
            kayit = "INSERT INTO [dbo].[Kullanici]";
            kayit += "([Username],[pass], [Rol])";
            kayit += " VALUES('" + Txt_Kullanici.Text + "','" + Txt_Sifre.Text + "','";
            kayit += DD_Rol.SelectedValue.ToString() + "' )"; 
            Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(kayit);



        }

        protected void Btn_Listele_Click(object sender, EventArgs e)
        {
            SqlConnection kayit_cnn = Z29_Ka.Baglan();
            string Kullanici = "Select * from Kullanici";
            DataTable dt_kayit = Z29_Ka.TabloOlustur(Kullanici, kayit_cnn);
            GridView1.DataSource = dt_kayit;
            GridView1.DataBind();
        }

        protected void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            guncelle();
        }
        private void guncelle() 
        {


            string komut = "UPDATE [dbo].[Kullanici]";
            komut += "SET [Username]='" + Txt_Kullanici.Text + "'";
            komut += ",[pass]='" + Txt_Sifre.Text + "'";
            komut += ",[Rol]='" + DD_Rol.SelectedValue.ToString()+ "'";
            komut += "WHERE UserId ='" + Lbl_Sonuc.Text + "'";
            Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(komut);

            
            


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Guncelle":
                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    Txt_Kullanici.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[1].Text.ToString());

                    
                    break;




            }
        }
    }
}