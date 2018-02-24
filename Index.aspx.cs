using System;
using System.Web.Configuration;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CategoriesDataSource.ConnectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    }
}