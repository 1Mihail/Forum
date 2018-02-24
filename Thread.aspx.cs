using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Data.SqlClient;

public partial class Thread : System.Web.UI.Page
{
protected void Page_Load(object sender, EventArgs e)
    {
        RepliesDataSource.ConnectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        if (!Page.IsPostBack && Request.Params["id"] != null)
        {
            int ID = int.Parse(Request.Params["id"].ToString());
            if (Request.Cookies["role"]!=null && (Request.Cookies["role"].Value.Equals("admin") || Request.Cookies["role"].Value.Equals("moderator")))
            {
                EditThread.HRef = "EditThread.aspx?id=" + ID;
                DeleteThread.HRef = "DeleteThread.aspx?id=" + ID;
                EditThread.Visible = true;
                DeleteThread.Visible = true;
            }
            else {
                EditThread.Visible = false;
                DeleteThread.Visible = false;
            }
            RepliesDataSource.SelectParameters.Add("id", ID.ToString());
            RepliesDataSource.SelectCommand = "select * from Replies join Users on Replies.idUser = Users.id where idPost = @id";
            string query = "SELECT *"
                    + " FROM Posts join Users on Posts.idUser=Users.Id"
                    + " WHERE Posts.id = @id";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("id", ID);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    ThreadTitle.Text = reader["Title"].ToString();
                    ThreadUser.Text = reader["FirstName"].ToString() +" "+ reader["LastName"].ToString();
                    ThreadDate.Text = reader["Date"].ToString();
                    ThreadContext.Text = reader["Context"].ToString();
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
        if (Request.Cookies["idUser"] == null) {
            replyBox.Visible = false;
        }
        else { replyBox.Visible = true; }
    }
    protected void Raspunde_Click(object sender, EventArgs e) {
        bool valid = false;
        if (Raspuns.Text != "")
        {
            valid = true;
        }
        else {
            valid = false;
        }
        if (Request.Params["id"]!=null && valid) {
            int idUser = Convert.ToInt32(Request.Cookies["idUser"].Value);
            String context = Raspuns.Text;
            DateTime date = DateTime.Now;
            int idPost = Convert.ToInt32(Request.Params["id"]);

            string query = "INSERT INTO Replies(idUser, Context, Date, idPost) OUTPUT INSERTED.ID "
       + " VALUES (@idUser, @context, @date, @idPost)";

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            con.Open();

            try
            {
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("idUser", idUser);
                com.Parameters.AddWithValue("context", context);
                com.Parameters.AddWithValue("date", date);
                com.Parameters.AddWithValue("idPost", idPost);

                int id = (int)com.ExecuteScalar();

                if (id > 0)
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