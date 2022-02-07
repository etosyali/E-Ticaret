using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kah_Satis;
namespace Kah_Satis.Admin
{
    public partial class kargo_Subeleri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection Cnn = Z29_Ka.Baglan();
                String Il_sorgu = "Select * from iller";
                DataTable Dt_iller = Z29_Ka.TabloOlustur(Il_sorgu, Cnn);
                Z29_Ka.DDDoldur(DropDownList1, Dt_iller, "il_no", "Il_Adi");
                String Kargo = "SELECT        Kargo_Id, Unvani FROM            Anlasmalı_Kargo_Sirketleri ";
                DataTable Dt_Kargo = Z29_Ka.TabloOlustur(Kargo, Cnn);
                Z29_Ka.DDDoldur(DropDownList2, Dt_Kargo, "Kargo_Id", "Unvani");
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection KargoSirket = Z29_Ka.Baglan();
            string Kargo_Subeleri = "Select * from Kargo_Subeleri";
            DataTable Kargo = Z29_Ka.TabloOlustur(Kargo_Subeleri, KargoSirket);//Z29_Ka.VerileriOku("Kargo_Subeleri", KargoSirket);
            if (Kargo.Rows.Count > 0)
            {
                GridView1.DataSource = Kargo;
                GridView1.DataBind();
            }
            else
            {
                Label1.Text = "Hata";
            }

            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Veri_Kontrolu(DropDownList2.SelectedValue.ToString(), TextBox3.Text, DropDownList1.SelectedValue.ToString());
        }

        private void Veri_Kontrolu(string kargoıd, string adres, string IlId)
        {

            string sorgu = "select * from Kargo_Subeleri";

            sorgu += " where ";

            sorgu += " Kargo_Id ='" + kargoıd + "'";
            sorgu += " and Adres_İletisim_Bilgileri ='" + adres + "'";
            sorgu += " and Il_Id ='" + IlId + "'"; 
            SqlConnection Bag = Z29_Ka.Baglan(); 
            DataTable var_Yok = Z29_Ka.TabloOlustur(sorgu, Bag);

            if (var_Yok.Rows.Count > 0)

            {
                Label1.Text = "Girilen değerlere uygun kayıt var!";

                GridView1.DataSource = var_Yok;

                GridView1.DataBind();

                GridView1.Visible = true;
            }

            else

            {
                string islev = "INSERT INTO [dbo].[Kargo_Subeleri]";
                islev += "([Kargo_Id],[Adres_İletisim_Bilgileri],[Il_Id])";
                islev += " VALUES ('" + DropDownList2.SelectedValue.ToString() + "','" + TextBox3.Text + "','" + DropDownList1.SelectedValue.ToString() + "')";

                Label1.Text = Z29_Ka.Kaydet_Guncelle_Sil(islev);

            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DropDownList1.SelectedIndex = -1;
            DropDownList2.SelectedIndex = -1;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Yeni":
                    MultiView1.ActiveViewIndex = 0;

                    Button2.Text = "Kaydet";

                    break;
                case "Guncelle":
                    Label1.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[0].Text.ToString());
                    //  TextBox2.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    TextBox3.Text = HttpUtility.HtmlDecode(GridView1.Rows[rowIndex].Cells[2].Text.ToString());
                    //   TextBox4.Text = GridView1.Rows[rowIndex].Cells[3].Text.ToString();
                    for (int i = 0; i < DropDownList1.Items.Count; i++)
                    {
                        if (DropDownList1.Items[i].Value == GridView1.Rows[rowIndex].Cells[3].Text.ToString())
                        {
                            DropDownList1.Items[i].Selected = true;
                            break;
                        }
                    }
                    for (int i = 0; i < DropDownList2.Items.Count; i++)
                    {
                        if (DropDownList2.Items[i].Value == GridView1.Rows[rowIndex].Cells[1].Text.ToString())
                        {
                            DropDownList2.Items[i].Selected = true;
                            break;
                        }
                    }
                    MultiView1.ActiveViewIndex = 0;

                    Button2.Text = "Guncelle";

                    break;
                case "Sil":
                    TextBox1.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                   // DropDownList1.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    TextBox3.Text = GridView1.Rows[rowIndex].Cells[2].Text.ToString();
                    // TextBox4.Text = GridView1.Rows[rowIndex].Cells[3].Text.ToString();
                    // DropDownList2.Text = GridView1.Rows[rowIndex].Cells[4].Text.ToString();
                    for (int i = 0; i < DropDownList1.Items.Count; i++)
                    {
                        if (DropDownList1.Items[i].Value == GridView1.Rows[rowIndex].Cells[3].Text.ToString())
                        {
                            DropDownList1.Items[i].Selected = true;
                            break;
                        }
                    }
                    for (int i = 0; i < DropDownList2.Items.Count; i++)
                    {
                        if (DropDownList2.Items[i].Value == GridView1.Rows[rowIndex].Cells[1].Text.ToString())
                        {
                            DropDownList2.Items[i].Selected = true;
                            break;
                        }
                    }
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
                    SqlConnection KargoSirket = Z29_Ka.Baglan();
                    string Kargo_Subeleri = "Select * from Kargo_Subeleri";
                    DataTable Kargo = Z29_Ka.TabloOlustur(Kargo_Subeleri, KargoSirket);//Z29_Ka.VerileriOku("Kargo_Subeleri", KargoSirket);
                    if (Kargo.Rows.Count > 0)
                    {
                        GridView1.DataSource = Kargo;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label1.Text = "Hata";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}