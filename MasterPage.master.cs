using System;
using System.Web.Configuration;

using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["name"] != null && Request.Cookies["role"] != null) 
        {
            logInBox.Visible = false;
            logOutBox.Visible = true;
            signUpLink.Visible = false;
            profilLink.Visible = true;
            logat.Text = "Bun venit " + Request.Cookies["name"].Value + "! Gradul tau: " + Request.Cookies["role"].Value;
            if (Request.Cookies["role"].Value.ToString().Equals("admin"))
            {
                administratorLink.Visible = true;
            }
            else {
                administratorLink.Visible = false;
            }
        }
        else {
            logInBox.Visible = true;
            logOutBox.Visible = false;
            signUpLink.Visible = true;
            profilLink.Visible = false;
            administratorLink.Visible = false;
        }
    }
    protected void Logout_Click(object sender, EventArgs e) {
        Response.Cookies["name"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["role"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["idUser"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect(Request.RawUrl);
    }
    protected void Login_Click(object sender, EventArgs e)
    {
        if (Email.Text != "" && Parola.Text != "")
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from users where Email=@email and Password=@password", con);
            cmd.Parameters.AddWithValue("@email", Email.Text);
            cmd.Parameters.AddWithValue("@password", Parola.Text);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (dt.Rows.Count > 0)
            {
                SaveDataInCookies();
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Eroare.Text = "Your username or password is incorrect";
            }
        }
        else {
            Eroare.Text = "Va rugam sa completati campurile!";
        }
    }

    protected void SaveDataInCookies()
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand("select * from users where Email=@email and Password=@password", con);
        try
        {
            com.Parameters.AddWithValue("@email", Email.Text);
            com.Parameters.AddWithValue("@password", Parola.Text);
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                Response.Cookies["name"].Value = reader["FirstName"].ToString();
                Response.Cookies["name"].Expires = DateTime.Now.AddDays(30);

                Response.Cookies["role"].Value = reader["Role"].ToString();
                Response.Cookies["role"].Expires = DateTime.Now.AddDays(30);

                Response.Cookies["idUser"].Value = reader["Id"].ToString();
                Response.Cookies["idUser"].Expires = DateTime.Now.AddDays(30);
            }
        }
        catch (Exception ex)
        {
            Eroare.Text = "Eroare din baza de date: " + ex.Message;
        }
        finally
        {
            con.Close();
        }
    }

}
