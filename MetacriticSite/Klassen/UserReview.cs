using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetacriticSite.Klassen
{
    public class UserReview : Review
    {
        Database.Database db = new Database.Database();
        public int Score { get; set; }
        public int Helpfull { get; set; }

        public UserReview(string name, string content, DateTime date, string spoiler, int score, int helpfull) : base(name, content, date, spoiler)
        {
            this.Score = score;
            this.Helpfull = helpfull;
        }

        /// <summary>
        /// returns all userreviews with a given categorienumber
        /// </summary>
        /// <param name="categorienr">1=game, 2=movie, 3=show, 4=music</param>
        /// <returns></returns>
        public List<Review> getUserReviews(int categorienr)
        {
            List<Review> userReviews = new List<Review>(); 
            string name = "";
            int score = 0;
            string text = "";
            DateTime date = DateTime.Today;
            string spoiler = "";

            foreach (Dictionary<string, object> D in db.getReviews(categorienr))
            {
                name = (string)D["naam"];
                score = Convert.ToInt32(D["score"]);
                text = (string) D["inhoud"];
                date = (DateTime) D["datum"];
                spoiler = (string) D["spoiler"];
                Review review = new UserReview(name, text, date, spoiler, score, 1);
                userReviews.Add(review);
            }
            return userReviews;
        }

        //was used to get latest review, but don't need it anymore. Still stands here for if ever needed.
       /* public List<Review> getLatestReview(int categorienr)
        {
            string name = "";
            int score = 0;
            string text = "";
            DateTime date = DateTime.Today;
            string spoiler = "";

            foreach (Dictionary<string, object> D in db.getLatestReview(categorienr))
            {
                name = (string)D["naam"];
                score = Convert.ToInt32(D["score"]);
                text = (string)D["inhoud"];
                date = (DateTime)D["datum"];
                spoiler = (string)D["spoiler"];
                Review review = new UserReview(name, text, date, spoiler, score, 1);
                userReviews.Add(review);
            }
            return userReviews;
        }*/
    }
}