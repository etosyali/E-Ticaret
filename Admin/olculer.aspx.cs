using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kah_Satis
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection Olcucon = Z29_Ka.Baglan();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
  
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string olculerkaydet = "";
            olculerkaydet = "Insert Into Olculer ([En],[Boy],[Yukseklik],[Hacim],[Kapasite]) values ";
            olculerkaydet += "('" + TextBox1.Text.ToString() + "','" + TextBox2.Text.ToString() + "','" + TextBox3.Text.ToString() + "','" + TextBox4.Text.ToString() + "','" + TextBox5.Text.ToString() + "')";
            string olculersorgula = "Select * from Olculer";
            string komut = olculerkaydet;
            Label6.Text = Z29_Ka.Kaydet_Guncelle_Sil(olculerkaydet);
            
            DataTable Dt_Olculer = Z29_Ka.TabloOlustur(olculersorgula,Z29_Ka.Baglan());
            GridView1.DataSource = Dt_Olculer;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            string olculerguncelle = "";
           // olculerguncelle = "UPDATE [dbo].[Olculer] SET [En] = '" + TextBox1.Text.ToString() + "'," + "[Boy] = '" + TextBox2.Text.ToString() + "','" + "[Yukseklik] = '" + TextBox3.Text.ToString() + "','" + "[Hacim] = '" + TextBox3.Text.ToString() + "','" + "[Kapasite] = '" + TextBox3.Text.ToString() + "'" ;
            olculerguncelle = "UPDATE[dbo].[Olculer]   SET[En] = '" + TextBox1.Text + "'  ,[Boy] = '" + TextBox2.Text + "'   ,[Yukseklik] = '" + TextBox3.Text + "'      ,[Hacim] = '" + TextBox4.Text + "'  ,[Kapasite] = '" + TextBox5.Text + "' WHERE [Olcu_Id]='"+Label7.Text+"'";
            string olculersorgula = "Select * from Olculer";
            string komut = olculerguncelle;
            Label6.Text = Z29_Ka.Kaydet_Guncelle_Sil(olculerguncelle);
            DataTable Dt_Olculer = Z29_Ka.TabloOlustur(olculersorgula,Z29_Ka.Baglan());
            GridView1.DataSource = Dt_Olculer;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {

                case "Seç":

                    TextBox1.Text = GridView1.Rows[rowIndex].Cells[0].Text.ToString();
                    TextBox2.Text = GridView1.Rows[rowIndex].Cells[1].Text.ToString();
                    TextBox3.Text = GridView1.Rows[rowIndex].Cells[2].Text.ToString();
                    TextBox4.Text = GridView1.Rows[rowIndex].Cells[3].Text.ToString();
                    TextBox5.Text = GridView1.Rows[rowIndex].Cells[4].Text.ToString();
                    break;
              
                default:
                    break;
            }
        }
    }

}