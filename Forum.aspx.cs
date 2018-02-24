using System;
using System.Web.Configuration;
using System.Web.UI;

public partial class Forum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PostsDataSource.ConnectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        if (!Page.IsPostBack && Request.Params["category"] != null)
        {
            PostsDataSource.SelectParameters.Add("category", Request.Params["category"].ToString());
            PostsDataSource.SelectCommand = "select * from Posts where Category = @category";
        }
        if (Request.Cookies["idUser"] != null)
        {
            DiscutieNoua.Visible = true;
        }
        else
        {
            DiscutieNoua.Visible = false;
        }
    }
    protected void DiscutieNoua_Click(object sender, EventArgs e)
    {
        if (Request.Params["category"] != null)
        {
            Response.Redirect("NewThread.aspx?category=" + Request.Params["category"]);
        }
    }
    protected void SortareAsc(object sender, EventArgs e)
    {
        if (Request.Params["category"] != null)
        {
            PostsDataSource.SelectCommand = "select * from Posts where Category = @category order by title ASC";
        }
        if (Request.Cookies["idUser"] != null)
        {
            DiscutieNoua.Visible = true;
        }
        else
        {
            DiscutieNoua.Visible = false;
        }

    }
    protected void SortareDesc(object sender, EventArgs e)
    {
        if (Request.Params["category"] != null)
        {
            PostsDataSource.SelectCommand = "select * from Posts where Category = @category order by title DESC";
        }
        if (Request.Cookies["idUser"] != null)
        {
            DiscutieNoua.Visible = true;
        }
        else
        {
            DiscutieNoua.Visible = false;
        }
    }
}