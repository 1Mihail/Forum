using System;
using System.Web.UI;
using System.Web.Configuration;
using System.Data.SqlClient;
public partial class Administrator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["role"] == null || !Request.Cookies["role"].Value.ToString().Equals("admin")) {
            Response.Redirect("index.aspx");
        }
        CategoriesDS.ConnectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        UsersDS.ConnectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    }
    protected void CreeazaCategorie_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            bool valid = true;

            string _NumeCategorie = NumeCategorie.Text;
            string _DescriereCategorie = DescriereCategorie.Text;

            if (_NumeCategorie == "")
            {
                valid = false;
                Response.Write("Eroare: Numele nu poate fi gol");
            }
            else if (_DescriereCategorie == "") {
                valid = false;
                Response.Write("Eroare: Descrierea nu poate fi goala");
            }

            if (valid)
            {
                string query = "INSERT INTO Categories(Category, Description) OUTPUT INSERTED.Category "
                   + " VALUES (@numeCategorie, @descriereCategorie)";

                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
                con.Open();

                try
                {
                    SqlCommand com = new SqlCommand(query, con);
                    com.Parameters.AddWithValue("numeCategorie", _NumeCategorie);
                    com.Parameters.AddWithValue("descriereCategorie", _DescriereCategorie);

                    String category = (String)com.ExecuteScalar();

                    if (category != "")
                    {
                        EroareBazaDate.Text = "Informatiile au fost adaugate";
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        EroareBazaDate.Text = "Informatiile nu au fost adaugate";
                    }

                }
                catch (Exception ex)
                {
                    EroareBazaDate.Text = "Eroare din baza de date: " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }


        }
    }
}