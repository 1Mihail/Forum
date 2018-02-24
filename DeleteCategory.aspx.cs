using System;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class DeleteCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Params["category"] != null)
        {
            string query = "DELETE"
                    + " FROM Categories"
                    + " WHERE Category = @category";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("category", Request.Params["category"].ToString());

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