using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetacriticSite
{
    public partial class MainPage : System.Web.UI.Page
    {
        InfoPage info = new InfoPage();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void sinisterMainpage_Click(object sender, ImageClickEventArgs e)
        {
            Session["imageClicked"] = "Sinister";
            Response.Redirect("InfoPage.aspx");
        }

        protected void falloutMainpage_Click(object sender, ImageClickEventArgs e)
        {
            Session["imageClicked"] = "Fallout4";
            Response.Redirect("InfoPage.aspx");
        }
    }
}