using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MetacriticSite.Klassen;
using System.Web.SessionState;

namespace MetacriticSite
{
    public partial class InfoPage : System.Web.UI.Page
    {
        //fields and declarations for a couple of classes
        public List<int> grades = new List<int>(); 
        private int number;
        Game game = new Game(1, 1, "1", "1", "1", "1", DateTime.Today, 0);
        Movie movie = new Movie(1, 1, "1", "1", "1", "1", 1, 1);
        Klassen.Music music = new Klassen.Music(1, 1, "1", "1", "1", DateTime.Today, "1");
        Show show = new Show(1, 1, "1", "1", "1", DateTime.Today, 1, 1);
        UserReview userReview = new UserReview("1", "1", DateTime.Today, "1", 1, 1);
        MetaReview metaReview = new MetaReview("1", "1", DateTime.Today, "1", 1);
        Database.Database db = new Database.Database();
        private string color = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //make sure everything only loads once
            if (!IsPostBack)
            {
                getInfo();
            }
        }
      
        public void getInfo()
        {
            //check session to see what image is clicked then fill the page with the information
            //uses InnerHtml tag to write data to the asp page.
            switch ((string) Session["imageClicked"])
            {
                case "Fallout4":
                    game = game.getGame("Fallout4");
                    info.InnerHtml += "Naam:" + game.Name + ", Userscore: <font color=\"" +getColor(getAverage(3)) + "\">" + getAverage(3) + "</font>" + ", Metascore: <font color=\"" + getColor(game.Metascore) + "\">" + game.Metascore + "</font>";
                    samenvatting.InnerHtml += game.Resume;
                    reviews.InnerHtml += getReviews(3);
                    Session["categorienr"] = 3;
                    break;
                case "Sinister":
                    movie = movie.getMovie("Sinister");
                    info.InnerHtml += "Naam:" + movie.Name + ", Userscore: <font color=\"" + getColor(getAverage(1)) + "\">" + getAverage(1) + "</font>" + ", Metascore: <font color=\"" + getColor(movie.Metascore) + "\">" + movie.Metascore + "</font>";
                    samenvatting.InnerHtml += movie.Resume;
                    reviews.InnerHtml += getReviews(1);
                    Session["categorienr"] = 1;
                    break;
                case "Thedrop":
                    movie = movie.getMovie("TheDrop");
                    info.InnerHtml += "Naam:" + movie.Name + ", Userscore: <font color=\"" + getColor(getAverage(2)) + "\">" + getAverage(2) + "</font>" + ", Metascore: <font color=\"" + getColor(movie.Metascore) + "\">" + movie.Metascore + "</font>";
                    samenvatting.InnerHtml += movie.Resume;
                    reviews.InnerHtml += getReviews(2);
                    Session["categorienr"] = 2;
                    break;
                case "Dishonored":
                    game = game.getGame("Dishonored");
                    info.InnerHtml += "Naam:" + game.Name + ", Userscore: <font color=\"" + getColor(getAverage(4)) + "\">" + getAverage(4) + "</font>" + ", Metascore: <font color=\"" + getColor(game.Metascore) + "\">" + game.Metascore + "</font>";
                    samenvatting.InnerHtml += game.Resume;
                    reviews.InnerHtml += getReviews(4);
                    Session["categorienr"] = 4;
                    break;
                case "Power":
                    show = show.getShow("Power");
                    info.InnerHtml += "Naam:" + show.Name + ", Userscore: <font color=\"" + getColor(getAverage(5)) + "\">" + getAverage(5) + "</font>" + ", Metascore:<font color=\"" + getColor(show.Metascore) + "\">" + show.Metascore + "</font>";
                    samenvatting.InnerHtml += show.Resume;
                    reviews.InnerHtml += getReviews(5);
                    Session["categorienr"] = 5;
                    break;
                case "Scandal":
                    show = show.getShow("Scandal");
                    info.InnerHtml += "Naam:" + show.Name + ", Userscore: <font color=\"" + getColor(getAverage(6)) + "\">" + getAverage(6) + "</font>" + ", Metascore: <font color=\"" + getColor(show.Metascore) + "\">" + show.Metascore + "</font>";
                    samenvatting.InnerHtml += show.Resume;
                    reviews.InnerHtml += getReviews(6);
                    Session["categorienr"] = 6;
                    break;
                case "Blackmill":
                    music = music.getMusic("Blackmill");
                    info.InnerHtml += "Naam:" + music.Name + ", Userscore:<font color=\"" + getColor(getAverage(7)) + "\">" + getAverage(7) + "</font>" + ", Metascore: <font color=\"" + getColor(music.Metascore) + "\">" + music.Metascore + "</font>";
                    samenvatting.InnerHtml += music.Resume;
                    reviews.InnerHtml += getReviews(7);
                    Session["categorienr"] = 7;
                    break;
                case "Eminem":
                    music = music.getMusic("Eminem");
                    info.InnerHtml += "Naam:" + music.Name + ", Userscore: <font color=\"" + getColor(getAverage(8)) + "\">" + getAverage(8) + "</font>" + ", Metascore: <font color=\"" + getColor(music.Metascore) + "\">" + music.Metascore + "</font>";
                    samenvatting.InnerHtml += music.Resume;
                    reviews.InnerHtml += getReviews(8);
                    Session["categorienr"] = 8;
                    break;
            }
        }
      
        //gets the color of the score
        public string getColor(int score)
        {
            if (score >= 75)
            {
                color = "green";
            }
            else if (score >= 50 && score < 75)
            {
                color = "yellow";
            }
            else if (score < 50)
            {
                color = "red";
            }
            return color;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categorienr">1=game, 2=movie, 3=show, 4=music</param>
        /// <returns></returns>
        public string getReviews(int categorienr)
        {
            string reviews = "";
            foreach (UserReview r in userReview.getUserReviews(categorienr))
            {
                reviews += "<div class=\"reviews\" runat=\"server\"> Naam: " + r.Name + " Review: " + r.Content + " Datum: " + r.Date + " Spoiler: " + r.Spoiler + " Score: " + r.Score + "</div> <br />  ";
                grades.Add(r.Score);
            }
            return reviews;
        }
        /// <summary>
        /// get average score (only of the User scores)
        /// </summary>
        /// <param name="categorienr"></param>
        /// <returns></returns>
        public int getAverage(int categorienr)
        {
            int averageScore = 0;
            List<int> totalScores = new List<int>();
            foreach (UserReview r in userReview.getUserReviews(categorienr))
            {
                totalScores.Add(r.Score);
            }
            averageScore = userReview.AverageScore(totalScores);
            return averageScore;
        }
        
        protected void btnWriteReview_Click(object sender, EventArgs e)
        {
            //show textboxes for reviews
            lblRate.Visible = true;
            tbRate.Visible = true;
            tbReview.Visible = true;
            btnSubmit.Visible = true;
            cbSpoiler.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //hide textboxes for reviews
            string spoiler = "";
            lblRate.Visible = false;
            tbRate.Visible = false;
            tbReview.Visible = false;
            btnSubmit.Visible = false;
            cbSpoiler.Visible = false;
            try
            {
                //run a couple of checks (not empty, number, spoiler)
                if (tbRate.Text != "")
                {
                    bool result = Int32.TryParse(tbRate.Text, out number);
                    if (result)
                    {
                        if (cbSpoiler.Checked)
                        {
                            spoiler = "Y";
                        }
                        else if (!cbSpoiler.Checked)
                        {
                            spoiler = "N";
                        }
                        //try to commit the review, if yes update page, if not an error message is shown
                        if (db.commitReview("test123@live.nl", Convert.ToInt32(Session["categorienr"]),
                            Klassen.Account.LoggedInUser.Name, Convert.ToInt32(tbRate.Text), tbReview.Text, spoiler))
                        {
                            info.InnerHtml = "";
                            samenvatting.InnerHtml = "";
                            reviews.InnerHtml = "";
                            getInfo();
                            ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('Review toegevoegd!')", true);
                            
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "myalert",
                                "alert('Mogen geen 2 dezelfde reviews komen te staan!')", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "myalert",
                            "alert('Je moet een cijfer geven, geen tekst!')", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('Cijfer mag niet leef zijn!')", true);
                }
            }
            catch (NullReferenceException) //this is to catch if someone is logged in or not
            {
                ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('Je moet inloggen om een review te mogen schrijven!')", true);
            }
            //put everything back to it's default state
            tbRate.Text = "";
            tbReview.Text = "There is a 150 character minimum for reviews. If your review contains spoilers, please check the Spoiler box. Please do not use ALL CAPS. There is no linking or other HTML allowed. Your review may be edited for content.";
            cbSpoiler.Checked = false;
        }
    }
}