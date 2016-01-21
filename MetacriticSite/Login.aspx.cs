using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MetacriticSite.Klassen;

namespace MetacriticSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //logs a user in if he can find the username/password combination in the database
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            Klassen.Account acc = new Klassen.Account(tbUsername.Text);
            if (acc.LogIn(tbUsername.Text, tbPassword.Text))
            {
                Label username = (Label)this.Master.FindControl("lblUsername");
                username.Text = acc.Name;
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('Kan niet inloggen. Controleer gebruikersnaam en wachtwoord.')", true);
            }
        }
    }
}