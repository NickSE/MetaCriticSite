using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetacriticSite
{
    public partial class Music : System.Web.UI.Page
    {
        InfoPage info = new InfoPage();
        Database.Database db = new Database.Database();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void blackmill_Click(object sender, ImageClickEventArgs e)
        {
            Session["imageClicked"] = "Blackmill";
            Response.Redirect("InfoPage.aspx");
        }

        protected void eminem_Click(object sender, ImageClickEventArgs e)
        {
            Session["imageClicked"] = "Eminem";
            Response.Redirect("InfoPage.aspx");
        }
    }
}