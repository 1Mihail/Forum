using System;
using System.Web.UI;
using System.Web.Configuration;
using System.Data.SqlClient;
public partial class EditUserRole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RoleDS.ConnectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        if (Request.Cookies["role"] != null && !Request.Cookies["role"].Value.Equals("admin"))
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        else if (Request.Cookies["role"] == null)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        else if (!Page.IsPostBack && Request.Params["id"] != null)
        {
            int ID = int.Parse(Request.Params["id"].ToString());
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
                    userEmail.InnerHtml = "Editare rol pentru utilizatorul: " + reader["email"].ToString();
                    RoleDD.DataBind(); 
                    RoleDD.Items.FindByValue(reader["role"].ToString()).Selected = true;
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
    protected void EditareRol_Click(object sender, EventArgs e)
    {
        if (Page.IsValid && Request.Params["id"] != null)
        {
            int ID = int.Parse(Request.Params["id"].ToString());

            string _Role = RoleDD.SelectedValue;

            string query = "UPDATE Users "
               + "SET role = @role"
               + " WHERE Id = @id";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            con.Open();

            try
            {
                SqlCommand com = new SqlCommand(query, con);

                com.Parameters.AddWithValue("role", _Role);
                com.Parameters.AddWithValue("id", ID);

                int afectate = com.ExecuteNonQuery(); 
                if (afectate > 0)
                {
                    EroareBazaDate.Text = "Informatiile au fost modificate";
                    Response.Redirect("Administrator.aspx");
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