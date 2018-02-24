using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Data.SqlClient;

public partial class EditReply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["role"] != null && (!Request.Cookies["role"].Value.Equals("admin") && !Request.Cookies["role"].Value.Equals("moderator")))
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        else if (Request.Cookies["role"] == null)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        if (!Page.IsPostBack && Request.Params["id"] != null)
        {
            int ID = int.Parse(Request.Params["id"].ToString());
            string query = "SELECT *"
                    + " FROM Replies"
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
                    Raspuns.Text = reader["Context"].ToString();
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
        else if (Request.Params["id"] == null)
        {
            Response.Redirect("index.aspx");
        }
    }
    protected void ActualizareRaspuns_Click(object sender, EventArgs e)
    {
        if (Page.IsValid && Request.Params["id"] != null)
        {
            int ID = int.Parse(Request.Params["id"].ToString());

            string _Raspuns = Raspuns.Text;

            string query = "UPDATE Replies "
               + "SET context = @raspuns"
               + " WHERE Id = @id";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            con.Open();

            try
            {
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("raspuns", _Raspuns);
                com.Parameters.AddWithValue("id", ID);
                int afectate = com.ExecuteNonQuery(); 
                if (afectate > 0)
                {
                    EroareBazaDate.Text = "Informatiile au fost modificate";
                    Response.Redirect(Request.UrlReferrer.ToString());
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