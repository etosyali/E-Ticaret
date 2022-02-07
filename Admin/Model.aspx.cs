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
    public partial class Model : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Veri Tabanına bağlan
                try
                {

                   modellistele();


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
            modellistele();

        }
        protected void Btn_Kaydet_Click(object sender, EventArgs e)
        {
            string model_kaydet = " ";
            switch (Btn_Kaydet.Text)
            {
                case "Kaydet":
                    
                    model_kaydet = " INSERT INTO[dbo].[Model_Tablosu] ([Model_Adi]) VALUES ('" + TextBox1.Text + "')";
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(model_kaydet);

                    break;
                case "Güncelle":
                    model_kaydet = "UPDATE [dbo].[Model_Tablosu] SET[Model_Adi] = '" + TextBox1.Text + "'";
                    model_kaydet += " WHERE Model_Id= '" + Lbl_Sonuc.Text + "'";
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(model_kaydet);
               

                    break;
                case "Sil":
                   
                    Veri_sil(Lbl_Sonuc.Text);
                    modellistele();
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
                    break;
                case 1:
                    MultiView1.ActiveViewIndex = 1;
                    break;
                default:
                    break;
            }
        }

        private void modellistele()
        {
            SqlConnection modelconn = Z29_Ka.Baglan();
            String model_sorgu = "SELECT *FROM [dbo].[Model_Tablosu]";
            DataTable Dt_model = Z29_Ka.TabloOlustur(model_sorgu, modelconn);
            GridView1.DataSource = Dt_model;
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
                    Btn_Kaydet.Text = "Kaydet";
                  
                    break;
                case "Guncelle":
                    MultiView1.ActiveViewIndex = 0;
                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TextBox1.Text= HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[1].Text.ToString());
                    Btn_Kaydet.Text = "Güncelle";
                  
                    break;
                case "Sil":
                    MultiView1.ActiveViewIndex = 0;
                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TextBox1.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[1].Text.ToString());
                    Btn_Kaydet.Text = "Sil";

                    

                    break;

                default:
                    break;
            }




        }

        private void Veri_sil(string satir_id)
        {

           // string silinecek_satirid = GridView1.Rows[satir_id].Cells[0].Text.ToString();
            string sorgu_sil = "DELETE FROM [dbo].[Model_Tablosu]  WHERE Model_Id ='" + satir_id + "'";
            Z29_Ka.Kaydet_Guncelle_Sil(sorgu_sil);
            MultiView1.ActiveViewIndex = 1;
       
           

        }

        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}