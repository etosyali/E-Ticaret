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
    public partial class Aksesuarlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Renk Tablosu okunuyor ..
                    DataTable Dt_Renk = Z29_Ka.TabloOlustur("select * from renkler", Z29_Ka.Baglan());
                    GridView2.DataSource = Dt_Renk;
                    GridView2.DataBind();

                }
                catch (Exception ex)
                {
                    lblSonuc.Text = ex.ToString();
                }

            }
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {
            switch (MultiView1.ActiveViewIndex)
            {
                case 0:
                    btnKaydet.Text = "Kaydet";
                    break;
                case 1:
                    AksesuarListele();
                    break;
                default:
                    break;
            }
        }

        private void AksesuarListele()
        {
            SqlConnection AksCnn = Z29_Ka.Baglan();
            string AksSorgu = "Select * from Aksesuar";
            DataTable Dt_Aks = Z29_Ka.TabloOlustur(AksSorgu, AksCnn);
            GridView1.DataSource = Dt_Aks;
            GridView1.DataBind();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string Aks_Kaydet = "";
            string Aks_Guncelle = "";
            string Aks_Sil = "";


            switch (btnKaydet.Text)
            {
                case "Kaydet":
                    Aks_Kaydet = "INSERT INTO [dbo].[Aksesuar] ";
                    Aks_Kaydet += "([Aksesuar_Adi],  [Aksesuar_Rengi_Id], [Aksesuar_Resmi_Yolu], [Kod]) ";
                    Aks_Kaydet += " VALUES ('" + TextBox1.Text + "' , '" + TextBox2.Text + "' , '" + Label1.Text + "' , '" + TextBox4.Text + "')";
                    lblSonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Aks_Kaydet);
                    MultiView1.ActiveViewIndex = 1;

                    break;
                case "Guncelle":
                    Aks_Guncelle = "  UPDATE[dbo].[Aksesuar]   SET[Aksesuar_Adi] ='" + TextBox1.Text;
                    Aks_Guncelle += "'  ,[Aksesuar_Rengi_Id] ='" + TextBox2.Text + "' ,[Aksesuar_Resmi_Yolu] = '" + Label1.Text + "'   ,[Kod] = '" + TextBox4.Text;
                    Aks_Guncelle += "'  WHERE [Aksesuar_Id] ='" + lblSonuc.Text + "'";
                    lblSonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Aks_Guncelle);
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "Sil":

                    Aks_Sil = "DELETE FROM [dbo].[Aksesuar] WHERE [Aksesuar_Id] ='" + lblSonuc.Text + "'";
                    lblSonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Aks_Sil);
                    MultiView1.ActiveViewIndex = 1;
                    break;

            }

        }

        protected void btnListele_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            AksesuarListele();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Yeni":
                    MultiView1.ActiveViewIndex = 0;
                    TextBox1.Text = null;
                    btnKaydet.Text = "Kaydet";

                    break;
                case "Guncelle":
                    lblSonuc.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[0].Text.ToString());
                    TextBox1.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    TextBox2.Text= GridView1.Rows[rowIndex].Cells[2].Text.ToString();
                    Label1.Text = GridView1.Rows[rowIndex].Cells[3].Text.ToString();
                    TextBox4.Text = GridView1.Rows[rowIndex].Cells[4].Text.ToString();
                    MultiView1.ActiveViewIndex = 0;
                    btnKaydet.Text = "Guncelle";

                    break;
                case "Sil":
                    lblSonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TextBox1.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    TextBox2.Text = GridView1.Rows[rowIndex].Cells[2].Text.ToString();
                    Label1.Text = GridView1.Rows[rowIndex].Cells[3].Text.ToString();
                    TextBox4.Text = GridView1.Rows[rowIndex].Cells[4].Text.ToString();
                    MultiView1.ActiveViewIndex = 0;
                    btnKaydet.Text = "Sil";

                    break;

                default:
                    break;
            }
        }

        protected void MultiView1_ActiveViewChanged1(object sender, EventArgs e)
        {
            switch (MultiView1.ActiveViewIndex)
            {
                case 1:
                    AksesuarListele();
                    break;
                default:
                    break;
            }
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
                            FileUpload1.SaveAs(Server.MapPath("~/Admin/Aksesuar_Resimleri/") + FileUpload1.FileName);
                            lblSonuc.Text = "Dosya Adı: " +
                                FileUpload1.PostedFile.FileName +
                                "<br />Dosya Boyutu: " +
                                FileUpload1.PostedFile.ContentLength +
                                "<br />Dosya Türü: " +
                                FileUpload1.PostedFile.ContentType;
                            Image_Path = "~/Admin/Aksesuar_Resimleri/" + FileUpload1.FileName.ToString();

                            Label1.Text = Image_Path;
                            Label1.Enabled = false;

                        }
                        else
                        {
                            lblSonuc.Text = "Maksimum boyut 100 KB olmalı.";
                        }
                    }
                    else
                    {
                        lblSonuc.Text = "Resim dosyası seçin.";
                    }

                }
                catch (Exception ex)
                {
                    lblSonuc.Text = "Hata Oluştu: " + ex.Message.ToString();
                }
            else
            {
                lblSonuc.Text = "Dosya Seçin ve GÖNDER Butonuna Tıklayın.";
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Sec":
                    TextBox2.Text = GridView2.Rows[rowIndex].Cells[0].Text.ToString();
                    GridView2.Visible = false;
                    TextBox2.Enabled = false;
                 break;
                case "Yeni_renk":
                    // Aksesuar Safasından Renk Ekleme

                    break;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Enabled = false;
            GridView2.Visible = true;
        }
    }
}
