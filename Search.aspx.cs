using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Data.SqlClient;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string query = "SELECT *"
                    + " FROM Posts join Replies on Posts.Id=Replies.IdPost";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader reader = com.ExecuteReader();
                GridView1.DataSource = reader; 
                GridView1.DataBind(); 

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
    protected void Search_Click(object sender, EventArgs e)
    {
        string data = Data.Text.ToString();

        string query = "";

        if (data != "")
        {
            query = "SELECT * FROM Posts join Replies on Posts.Id=Replies.IdPost where Posts.title like @data OR Replies.Context like @data";
        }

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        con.Open();
        try
        {
            SqlCommand com = new SqlCommand(query, con);
            if (data != "")
            {
                com.Parameters.AddWithValue("data", "%" + data + "%");
            }
            else
            {
                com.Parameters.AddWithValue("data", "%%");
            }

            SqlDataReader reader = com.ExecuteReader();
            GridView1.DataSource = reader; 
            GridView1.DataBind(); 
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