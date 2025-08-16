using System;

public partial class Validator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Response.Redirect("Success.aspx");
        }
    }
}
