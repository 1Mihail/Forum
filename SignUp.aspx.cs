using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Data.SqlClient;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["idUser"]!=null)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
    protected void AdaugareIntrare_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string _Nume = Nume.Text;
            string _Prenume = Prenume.Text;
            string _Email = Email.Text;
            string _Parola = Parola.Text;

            string query = "INSERT INTO users(LastName, FirstName, Email, Password, Role) OUTPUT INSERTED.ID "
               + " VALUES (@nume, @prenume, @email, @parola, @role)";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            con.Open();

            try
            {
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("nume", _Nume);
                com.Parameters.AddWithValue("prenume", _Prenume);
                com.Parameters.AddWithValue("email", _Email);
                com.Parameters.AddWithValue("parola", _Parola);
                com.Parameters.AddWithValue("role", "user");

                int id = (int)com.ExecuteScalar();
                if (id > 0)
                {
                    EroareBazaDate.Text = "Informatiile au fost adaugate";
                    Response.Redirect("Index.aspx");
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