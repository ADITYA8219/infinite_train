using System;
using System.Web.UI.WebControls;

namespace Products
{
    public partial class ProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.Items.Add(new ListItem("Laptop", "50000"));
                ddlProducts.Items.Add(new ListItem("Smartphone", "30000"));
                ddlProducts.Items.Add(new ListItem("Headphones", "2000"));
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrice.Text = "Selected Price: ₹" + ddlProducts.SelectedValue;
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            lblPrice.Text = "Price: ₹" + ddlProducts.SelectedValue;

            switch (ddlProducts.SelectedItem.Text)
            {
                case "Laptop":
                    imgProduct.ImageUrl = "~/img/laptop.jpg";
                    break;
                case "Smartphone":
                    imgProduct.ImageUrl = "~/img/sphone.jpg";
                    break;
                case "Headphones":
                    imgProduct.ImageUrl = "~/img/headphone.jpg";
                    break;
                default:
                    imgProduct.ImageUrl = "";
                    break;
            }
        }
    }
}
