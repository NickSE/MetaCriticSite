using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MetacriticSite.Klassen;

namespace MetacriticSite
{
    public partial class TV : System.Web.UI.Page
    {
        InfoPage info = new InfoPage();
        Database.Database db = new Database.Database();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void power_Click(object sender, ImageClickEventArgs e)
        {
            Session["imageClicked"] = "Power";
            Response.Redirect("InfoPage.aspx");
        }

        protected void scandal_Click(object sender, ImageClickEventArgs e)
        {
            Session["imageClicked"] = "Scandal";
            Response.Redirect("InfoPage.aspx");
        }
    }
}