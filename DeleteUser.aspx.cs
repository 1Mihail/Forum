using System;
using System.Web.Configuration;
using System.Data.SqlClient;
public partial class DeleteUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["role"] == null || !Request.Cookies["role"].Value.Equals("admin"))
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        else if (Request.Cookies["role"] == null)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        else
        {
            int ID = int.Parse(Request.Params["id"].ToString());
            string query = "DELETE"
                    + " FROM Users"
                    + " WHERE id = @id";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("id", ID);

                int deleted = com.ExecuteNonQuery();

                if (deleted > 0)
                {
                    Response.Write("Intrarea a fost stearsa din baza de date");
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    Response.Write("Intrarea nu a fost stearsa. Va rugam incercati din nou");
                }

            }
            catch (Exception ex)
            {
                Response.Write("Eroare din baza de date: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}