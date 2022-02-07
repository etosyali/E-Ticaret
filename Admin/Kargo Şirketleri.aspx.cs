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
    public partial class Kargo_Şirketleri : System.Web.UI.Page
    {
        SqlConnection KargoCon = Z29_Ka.Baglan();
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void Btn_Kaydet_Click(object sender, EventArgs e)
        {

            string Kargo_Kaydet = "";
            switch (Btn_Kaydet.Text)
            {
                case "Kaydet":
                    Kargo_Kaydet = "Insert Into [dbo].[Anlasmalı_Kargo_Sirketleri] ";
                    Kargo_Kaydet += "([Unvani],[Adresi],[Vergi_Dairesi],[Vergi_No])";
                    Kargo_Kaydet+= " values ('"+ Txt_Unvan.Text.ToString() + "','" + Txt_Adres.Text.ToString() + "','" + Txt_Ver_Dairesi.Text.ToString() + "','" + Txt_Ver_No.Text.ToString() +"')";
                    
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Kargo_Kaydet);
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "Guncelle":


                    Kargo_Kaydet = "UPDATE [dbo].[Anlasmalı_Kargo_Sirketleri] ";
                    Kargo_Kaydet += "SET [Unvani]='"+ Txt_Unvan.Text.ToString() + "',"+"[Adresi]='" + Txt_Adres.Text.ToString() +"',"+" [Vergi_Dairesi]='" + Txt_Ver_Dairesi.Text.ToString() +"',"+"[Vergi_No]='" + Txt_Ver_No.Text.ToString() +"'"; 
                    Kargo_Kaydet += "WHERE  [Kargo_Id] ='" + Lbl_Sonuc.Text + "'";
                    
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Kargo_Kaydet);
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case  "Sil":
                    Kargo_Kaydet = "DELETE FROM [dbo].[Anlasmalı_Kargo_Sirketleri]   WHERE  [Kargo_Id] ='";
                    Kargo_Kaydet += Lbl_Sonuc.Text + "'";
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Kargo_Kaydet);
                    MultiView1.ActiveViewIndex = 1;
                    break;
                default:
                    break;
            }

        }

        protected void Btn_List_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {
            switch (MultiView1.ActiveViewIndex)
            {
                case 0:
                    // Yeni Giriş Ekranı


                    break;
                case 1:
                    SqlConnection KargoCon = Z29_Ka.Baglan();
                    string Kargo_Sir_Sorgu = "Select * from Anlasmalı_Kargo_Sirketleri";
                    DataTable Dt_Kargo_Sir = Z29_Ka.TabloOlustur(Kargo_Sir_Sorgu, KargoCon);
                    GridView1.DataSource = Dt_Kargo_Sir;
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
                    Txt_Unvan.Text = null;
                    Txt_Adres.Text = null;
                    Txt_Ver_Dairesi.Text = null;
                    Txt_Ver_No.Text = null;
                    Btn_Kaydet.Text = "Kaydet";

                    break;
                case "Guncelle":
                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    Txt_Unvan.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    Txt_Unvan.Text = HttpUtility.HtmlEncode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());
                    Txt_Adres.Text = GridView1.Rows[rowIndex].Cells[2].Text.ToString();
                    Txt_Adres.Text = HttpUtility.HtmlEncode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());
                    Txt_Ver_Dairesi.Text = GridView1.Rows[rowIndex].Cells[3].Text.ToString();
                    Txt_Ver_Dairesi.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());
                    Txt_Ver_No.Text = GridView1.Rows[rowIndex].Cells[4].Text.ToString();
                    Txt_Ver_No.Text = HttpUtility.HtmlEncode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());
                    MultiView1.ActiveViewIndex = 0;
                    Btn_Kaydet.Text = "Guncelle";

                    break;
                case "Sil":

                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    Txt_Unvan.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    Txt_Unvan.Text = HttpUtility.HtmlEncode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());
                    Txt_Adres.Text = GridView1.Rows[rowIndex].Cells[2].Text.ToString();
                    Txt_Adres.Text = HttpUtility.HtmlEncode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());
                    Txt_Ver_Dairesi.Text = GridView1.Rows[rowIndex].Cells[3].Text.ToString();
                    Txt_Ver_Dairesi.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());
                    Txt_Ver_No.Text = GridView1.Rows[rowIndex].Cells[4].Text.ToString();
                    Txt_Ver_No.Text = HttpUtility.HtmlEncode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());
                    MultiView1.ActiveViewIndex = 0;
                    Btn_Kaydet.Text = "Sil";

                    break;



                default:
                    break;
            }
        }

        
    }
}