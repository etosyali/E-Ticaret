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
    public partial class renk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {
            switch (MultiView1.ActiveViewIndex)
            {
                case 0:

                    break;
                case 1:
                    Renk_Listele();
                    break;
                default:
                    break;
            }
        }

        private void Renk_Listele()
        {
            string Renk_Sorgu = "SELECT [Renk_Id],[Renk_Adi],[Renk_Resmi_Yolu]  FROM [dbo].[Renkler]";
            SqlConnection Rcc = Z29_Ka.Baglan();
            DataTable Dt_Renk = Z29_Ka.TabloOlustur(Renk_Sorgu, Rcc);
            GridView1.DataSource = Dt_Renk;
            GridView1.DataBind();
        }

        protected void Btn_Liste_Click(object sender, EventArgs e)
        {
            Renk_Listele();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Image_Path = "";
            if (FileUpload1.HasFile)
                try
                {
                    if (FileUpload1.PostedFile.ContentType == "image/jpeg")
                    {
                        if (FileUpload1.PostedFile.ContentLength < 102400)
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/Admin/Renk_Resimleri/") + FileUpload1.FileName);
                            Lbl_Sonuc.Text = "Dosya Adı: " +
                                FileUpload1.PostedFile.FileName +
                                "<br />Dosya Boyutu: " +
                                FileUpload1.PostedFile.ContentLength +
                                "<br />Dosya Türü: " +
                                FileUpload1.PostedFile.ContentType;
                            Image_Path = "~/Admin/Renk_Resimleri/" + FileUpload1.FileName.ToString();
                            // TextBox2.Text = "~/Resimler/Aksesuar_Resimleri/" + FileUpload1.FileName.ToString();

                            TxtResim_Yol.Text = Image_Path;
                            TxtResim_Yol.Enabled = false;

                        }
                        else
                        {
                            Lbl_Sonuc.Text = "Maksimum boyut 100 KB olmalı.";
                        }
                    }
                    else
                    {
                        Lbl_Sonuc.Text = "Resim dosyası seçin.";
                    }

                }
                catch (Exception ex)
                {
                    Lbl_Sonuc.Text = "Hata Oluştu: " + ex.Message.ToString();
                }
            else
            {
                Lbl_Sonuc.Text = "Dosya Seçin ve GÖNDER Butonuna Tıklayın.";
            }
        }
    }
}