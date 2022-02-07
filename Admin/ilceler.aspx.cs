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
    public partial class ilceler : System.Web.UI.Page
    {
        SqlConnection Ilcon = Z29_Ka.Baglan();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Iller tablosu alınıyor.
            if (!IsPostBack)
            {
             
                string IlSorgusu = "Select * from iller";
                DataTable Dt_Iller = Z29_Ka.TabloOlustur(IlSorgusu, Ilcon);
                Z29_Ka.DDDoldur(DD_Iller, Dt_Iller, "il_no", "Il_Adi");
                Z29_Ka.DDDoldur(DD_Iller_List, Dt_Iller, "il_no", "Il_Adi");

            }
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {
           
            switch (MultiView1.ActiveViewIndex)
            {
                case 0:
                    break;
                case 1:
                    IlceListele();


                    break;
                default:
                    break;
            }
        }

        private void IlceListele()
        {
            string Ilce_Liste_Sorgu = "";
            if (DD_Iller_List.SelectedIndex <= 0)
            {
                Ilce_Liste_Sorgu = "SELECT iller.Il_Adi AS Sehir, ilceler.ilce_no AS Kod, ";
                Ilce_Liste_Sorgu += "ilceler.isim AS Ilce, ilceler.il_no as Plaka";
                Ilce_Liste_Sorgu += " FROM     ilceler INNER JOIN iller ON ilceler.il_no = iller.il_no";
            }
            else
            {
                Ilce_Liste_Sorgu = "SELECT iller.Il_Adi AS Sehir, ilceler.ilce_no AS Kod, ";
                Ilce_Liste_Sorgu += "ilceler.isim AS Ilce , ilceler.il_no as Plaka";
                Ilce_Liste_Sorgu += " FROM     ilceler INNER JOIN iller ON ilceler.il_no = iller.il_no";
                Ilce_Liste_Sorgu += " where ilceler.il_no = '" + DD_Iller_List.SelectedValue.ToString() + "'";
            }
            DataTable Dt_Ilceler = Z29_Ka.TabloOlustur(Ilce_Liste_Sorgu, Ilcon);
            GridView1.DataSource = Dt_Ilceler;
            GridView1.DataBind();
            MultiView1.ActiveViewIndex = 1;
        }

        protected void DD_Iller_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            IlceListele();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Yeni":
                    MultiView1.ActiveViewIndex = 0;
                    Btn_Kaydet.Text = "Kaydet";

                    break;
                case "Guncelle":
                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TxtAd.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());
                    
                    TxtKod.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[2].Text.ToString());
                    string plaka = (GridView1.Rows[rowIndex].Cells[0].Text.ToString()); ;
                    DD_Iller.SelectedIndex = -1;
                    for (int i = 0; i < DD_Iller_List.Items.Count; i++)
                    {
                        if (DD_Iller.Items[i].Value == plaka)
                        {
                            DD_Iller.Items[i].Selected = true;
                            break;
                        }
                    }
                    TxtKod.Enabled = false;
                    DD_Iller.Enabled = false;
                    Btn_Kaydet.Text = "Guncelle";
                    MultiView1.ActiveViewIndex = 0;

                    break;
                case "Sil":
                    Lbl_Sonuc.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TxtAd.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[3].Text.ToString());

                    TxtKod.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[2].Text.ToString());
                     plaka = (GridView1.Rows[rowIndex].Cells[0].Text.ToString()); ;
                    DD_Iller.SelectedIndex = -1;
                    for (int i = 0; i < DD_Iller_List.Items.Count; i++)
                    {
                        if (DD_Iller.Items[i].Value == plaka)
                        {
                            DD_Iller.Items[i].Selected = true;
                            break;
                        }
                    }
                    TxtKod.Enabled = false;
                    DD_Iller.Enabled = false;
                    Btn_Kaydet.Text = "Sil";
                    MultiView1.ActiveViewIndex = 0;
                    break;

                default:
                    break;
            }

        }

        protected void Btn_List_Click(object sender, EventArgs e)
        {
            IlceListele();
        }

        protected void Btn_Kaydet_Click(object sender, EventArgs e)
        {
            // Kaydet-Güncelle-Sil
            switch (Btn_Kaydet.Text)
            {
                case "Kaydet":
                    string Ilce_Kaydet = "INSERT INTO [dbo].[ilceler]([ilce_no],[isim],[il_no]) VALUES";
                    Ilce_Kaydet += "('" + TxtKod.Text.ToString() + "','" + TxtAd.Text.ToString() + "','" + DD_Iller.SelectedValue.ToString() + "')";
                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Ilce_Kaydet);
                    break;
                case "Guncelle":
                    string Ilce_Guncelle = "UPDATE [dbo].[ilceler] SET [isim] = '" + TxtAd.Text.ToString() + 
                        "' WHERE [ilce_no] ='" + TxtKod.Text + "'";

                    Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Ilce_Guncelle);
                    break;
                case "Sil":

                    string Ilce_Sil = "Delete from [dbo].[ilceler] ";
                           Ilce_Sil += " WHERE [ilce_no] ='" + TxtKod.Text + "'";
                           Lbl_Sonuc.Text = Z29_Ka.Kaydet_Guncelle_Sil(Ilce_Sil);
                    break;

                default:
                    break;
            }
        }
    }
}