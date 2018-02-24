using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Data.SqlClient;

public partial class Profil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["idUser"]==null)
        {
            Response.Redirect("Index.aspx");
        }
        else if (!Page.IsPostBack)
        {
            int ID = int.Parse(Request.Cookies["idUser"].Value);
            string query = "SELECT *"
                    + " FROM Users"
                    + " WHERE id = @id";
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("id", ID);

                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    NumeUser.Text = reader["LastName"].ToString();
                    PrenumeUser.Text = reader["FirstName"].ToString();
                    EmailUser.Text = reader["Email"].ToString();
                    ParolaUser.Text = reader["Password"].ToString();
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
    protected void ActualizeazaProfil_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["idUser"] == null)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }else if (Page.IsValid)
        {
            int ID = int.Parse(Request.Cookies["idUser"].Value);

            string _Nume = NumeUser.Text;
            string _Prenume = PrenumeUser.Text;
            string _Email = EmailUser.Text;
            string _Parola = ParolaUser.Text;

            string query = "UPDATE Users "
               + "SET FirstName = @prenume, LastName = @nume, Email = @email, Password = @parola"
               + " WHERE Id = @id";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            con.Open();

            try
            {
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("nume", _Nume);
                com.Parameters.AddWithValue("prenume", _Prenume);
                com.Parameters.AddWithValue("email", _Email);
                com.Parameters.AddWithValue("parola", _Parola);
                com.Parameters.AddWithValue("id", ID);

                int afectate = com.ExecuteNonQuery(); 
                if (afectate > 0)
                {
                    EroareBazaDate.Text = "Informatiile au fost modificate";
                    Response.Redirect("Profil.aspx");
                }
                else
                {
                    EroareBazaDate.Text = "Informatiile nu au fost modificate";
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