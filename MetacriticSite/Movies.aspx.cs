using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MetacriticSite.Klassen;

namespace MetacriticSite
{
    public partial class Movies : System.Web.UI.Page
    {
        InfoPage info = new InfoPage();
        Database.Database db = new Database.Database();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void sinister_Click(object sender, ImageClickEventArgs e)
        {
            Session["imageClicked"] = "Sinister";
            Response.Redirect("InfoPage.aspx");
        }

        protected void theDrop_Click(object sender, ImageClickEventArgs e)
        {
            Session["imageClicked"] = "Thedrop";
            Response.Redirect("InfoPage.aspx");
        }
    }
}