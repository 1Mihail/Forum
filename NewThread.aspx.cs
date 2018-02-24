using System;
using System.Web.Configuration;
using System.Data.SqlClient;
public partial class NewThread : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Request.Params["category"] == null)
         {
            Response.Redirect("Index.aspx");
         }
    }

    protected void TrimiteThread_Click(object sender, EventArgs e)
    {
        if (Request.Params["category"] != null && Request.Cookies["idUser"] != null)
        {
            String category = Request.Params["category"];
            String title = ThreadTitle.Text;
            String context = ThreadContext.Text;
            DateTime date = DateTime.Now;
            int idUser = Convert.ToInt32(Request.Cookies["idUser"].Value);
            string query = "INSERT INTO Posts(category, title, context, date, idUser) OUTPUT INSERTED.ID "
   + " VALUES (@category, @title, @context, @date, @idUser)";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            con.Open();

            try
            {
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("category", category);
                com.Parameters.AddWithValue("title", title);
                com.Parameters.AddWithValue("context", context);
                com.Parameters.AddWithValue("date", date);
                com.Parameters.AddWithValue("idUser", idUser);

                int id = (int)com.ExecuteScalar();

                if (id > 0)
                {
                    EroareBazaDate.Text = "Informatiile au fost adaugate";
                    Response.Redirect("Forum.aspx?category=" + category);
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
        else if (Request.Cookies["idUser"] == null) {
            EroareBazaDate.Text = "Va rugam sa va autentificati!";
        }
    }
}