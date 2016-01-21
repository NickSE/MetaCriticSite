using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MetacriticSite.Database;
using MetacriticSite.Klassen;

namespace MetacriticSite
{
    public partial class Games : System.Web.UI.Page
    {
        InfoPage info = new InfoPage();
        Database.Database db = new Database.Database();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void fallout_Click(object sender, ImageClickEventArgs e)
        {
            Session["imageClicked"] = "Fallout4";
            Response.Redirect("InfoPage.aspx");
        }

        protected void dishonored_Click(object sender, ImageClickEventArgs e)
        {
            Session["imageClicked"] = "Dishonored";
            Response.Redirect("InfoPage.aspx");
        }
    }
}