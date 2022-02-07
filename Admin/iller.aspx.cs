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
    public partial class iller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Veri Tabanına bağlan
                try
                {
                    listele();
                    
                }
                catch (Exception ex)
                {
                    Lbl_Sonuc.Text = ex.ToString();

                }



            }

        }

        protected void Btn_List_Click(object sender, EventArgs e)
        {
            listele();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Btn_Kaydet_Click(object sender, EventArgs e)
        {
            string Il_Kaydet = "";
            switch (Btn_Kaydet.Text)
            {
                case "Kaydet":
                    Il_Kaydet = "Insert Into iller ";
                    Il_Kaydet += " (Il_Adi) values('" + TxtIl.Text + "')";
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Il_Kaydet);
                    listele();
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "Guncelle":
                    Il_Kaydet = "UPDATE [dbo].[iller] ";
                    Il_Kaydet += "SET [Il_Adi] = '" + TxtIl.Text + "'";
                    Il_Kaydet += "WHERE il_no ='" + Lbl_Sonuc.Text + "'";
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Il_Kaydet);
                    listele();
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "Sil":
                    Il_Kaydet = "Delete [dbo].[iller] ";
                    Il_Kaydet += "WHERE il_no ='" + Lbl_Sonuc.Text + "'";
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Il_Kaydet);
                    listele();
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
                    listele();
                    break;
                default:
                    break;
            }
        }

        private void listele()
        {
            SqlConnection IlCnn = Z29_Ka.Baglan();
            string IlSorgu = "Select * from iller";
            DataTable Dt_Iller = Z29_Ka.TabloOlustur(IlSorgu, IlCnn);
            GridView1.DataSource = Dt_Iller;
            GridView1.DataBind();
          
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Yeni":
                    MultiView1.ActiveViewIndex = 0;
                    TxtIl.Text = null;
                    Btn_Kaydet.Text = "Kaydet";

                    break;
                case "Guncelle":
                    Btn_Kaydet.Text = "Guncelle";
                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TxtIl.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    MultiView1.ActiveViewIndex = 0; 
                    break;
                case "Sil":
                    Btn_Kaydet.Text = "Sil";
                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TxtIl.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    MultiView1.ActiveViewIndex = 0;
                    break;

                default:
                    break;
            }
            //if (e.CommandName == "Sec")
            //{
            //    Session["Update"] = "1";
            //    MultiView1.ActiveViewIndex = 0;
            //    LblBlokId.Text = GVBlok.Rows[rowIndex].Cells[0].Text.ToString();
            //    txtBlokAdi.Text = GVBlok.Rows[rowIndex].Cells[1].Text.ToString();

            //    DDSite.SelectedIndex = DDSite2.SelectedIndex;


            //    // Güncelle 
            //    ImageButton3.ImageUrl = "~/Admin/image/save-icon.png";




            //}
            //else if (e.CommandName == "Sil")
            //{
            //    // Sil
            //    txtBlokAdi.Text = GVBlok.Rows[rowIndex].Cells[1].Text.ToString();

            //    LblBlokId.Text = GVBlok.Rows[rowIndex].Cells[0].Text.ToString();
            //    DDSite.SelectedIndex = DDSite2.SelectedIndex;
            //    ImageButton3.ImageUrl = "~/Admin/image/delete.png";
            //    Session["Update"] = "2";
            //    MultiView1.ActiveViewIndex = 0;
            //}
            //else if (e.CommandName == "Yeni")
            //{

            //    Session["Update"] = "0";
            //    MultiView1.ActiveViewIndex = 0;
            //    txtBlokAdi.Text = "";
            //    DDSite.SelectedIndex = -1;




        }
    }
}