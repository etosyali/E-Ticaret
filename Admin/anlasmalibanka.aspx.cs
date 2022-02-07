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
    public partial class anlasmalibanka : System.Web.UI.Page
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
                    Label4.Text = ex.ToString();

                }
            }
        }
        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {
            switch (MultiView1.ActiveViewIndex)
            {
                case 0:
                    Button1.Text = "Kaydet";
                    break;
                case 1:
                    BankaListele();
                    break;
                default:
                    break;
            }
        }

        private void BankaListele()
        {
            SqlConnection BankaCnn = Z29_Ka.Baglan();
            string BankaSorgu = "Select * from Anlasmali_Banka_Hesaplari";
            DataTable Dt_Banka = Z29_Ka.TabloOlustur(BankaSorgu, BankaCnn);
            GridView1.DataSource = Dt_Banka;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Banka_Kaydet = "";
            string Banka_Guncelle = "";
            string Banka_Sil = "";


            switch (Button1.Text)
            {
                case "Kaydet":
                    Banka_Kaydet = "INSERT INTO [dbo].[Anlasmali_Banka_Hesaplari] ";
                    Banka_Kaydet += "([Sube_Kodu], [Hesap_No], [Iban]) ";
                    Banka_Kaydet += " VALUES ('" + TextBox1.Text + "' , '" + TextBox2.Text + "' , '" + TextBox3.Text + "')";
                    Label4.Text = Z29_Ka.Kaydet_Goncelle_Sil(Banka_Kaydet);
                    MultiView1.ActiveViewIndex = 1;

                    break;
                case "Guncelle":
                    Banka_Guncelle = "  UPDATE[dbo].[Anlasmali_Banka_Hesaplari]   SET[Sube_Kodu] ='" + TextBox1.Text;
                    Banka_Guncelle += "'  ,[Hesap_No] ='" + TextBox2.Text;
                    Banka_Guncelle += "' ,[Iban] ='" + TextBox3.Text;
                    Banka_Guncelle += "'  WHERE [Sube_Kodu] ='" + Label4.Text + "'";
                    Label4.Text = Z29_Ka.Kaydet_Goncelle_Sil(Banka_Guncelle);
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "Sil":

                    Banka_Sil = "DELETE FROM [dbo].[Anlasmali_Banka_Hesaplari] WHERE [Sube_Kodu] ='" + Label4.Text + "'";
                    Label4.Text = Z29_Ka.Kaydet_Goncelle_Sil(Banka_Sil);
                    MultiView1.ActiveViewIndex = 1;
                    break;

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            BankaListele();
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
                    Button1.Text = "Kaydet";

                    break;
                case "Guncelle":
                    Label4.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TextBox3.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    MultiView1.ActiveViewIndex = 0;
                    Button1.Text = "Guncelle";


                    break;
                case "Sil":
                    Label4.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TextBox1.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    TextBox2.Text = GridView1.Rows[rowIndex].Cells[2].Text.ToString();
                    TextBox3.Text = GridView1.Rows[rowIndex].Cells[3].Text.ToString();
                  
                    MultiView1.ActiveViewIndex = 0;
                    Button1.Text = "Sil";

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
                    BankaListele();
                    break;
                default:
                    break;
            }
        }
    }
}