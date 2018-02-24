using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Data.SqlClient;

public partial class EditThread : System.Web.UI.Page
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
        CategoriesDS.ConnectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        if (!Page.IsPostBack && Request.Params["id"] != null)
        {
            int ID = int.Parse(Request.Params["id"].ToString());
            string query = "SELECT *"
                    + " FROM Posts"
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
                    ThreadTitle.Text = reader["title"].ToString();
                    ThreadContext.Text = reader["context"].ToString();
                    CategoriesDD.DataBind(); 
                    CategoriesDD.Items.FindByValue(reader["category"].ToString()).Selected = true;
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
    protected void Editare_Click(object sender, EventArgs e)
    {
        if (Page.IsValid && Request.Params["id"] != null)
        {
            int ID = int.Parse(Request.Params["id"].ToString());

            string _Titlu = ThreadTitle.Text;
            string _Context = ThreadContext.Text;
            string _Category = CategoriesDD.SelectedValue;

            string query = "UPDATE Posts "
               + "SET title = @title, context = @context, category = @category"
               + " WHERE Id = @id";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            con.Open();

            try
            {
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("title", _Titlu);
                com.Parameters.AddWithValue("context", _Context);
                com.Parameters.AddWithValue("category", _Category);
                com.Parameters.AddWithValue("id", ID);

                int afectate = com.ExecuteNonQuery(); 
                if (afectate > 0)
                {
                    EroareBazaDate.Text = "Informatiile au fost modificate";
                    Response.Redirect("Thread.aspx?id=" + ID);
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