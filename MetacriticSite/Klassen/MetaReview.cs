using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetacriticSite.Klassen
{
    public class MetaReview : Review
    {
        Database.Database db = new Database.Database();
        List<Review> metaReviews = new List<Review>(); 
        public int Score { get; set; }

        public MetaReview(string name, string content, DateTime date, string spoiler, int score) : base(name, content, date, spoiler)
        {
            this.Score = score;
        }

        /// <summary>
        /// metareviews are not in use right now (metareviewers are proffesional writers)
        /// </summary>
        /// <param name="categorienr">1=game, 2=movie, 3=show, 4=music</param>
        /// <returns></returns>
        
        public List<Review> getMetaReviews(int categorienr)
        {
            string name = "";
            int score = 0;
            string text = "";
            DateTime date = DateTime.Today;
            string spoiler = "";

            foreach (Dictionary<string, object> D in db.getReviews(categorienr))
            {
                name = (string)D["naam"];
                score = Convert.ToInt32(D["score"]);
                text = (string)D["inhoud"];
                date = (DateTime)D["datum"];
                spoiler = (string)D["spoiler"];
                Review review = new MetaReview(name, text, date, spoiler, score);
                metaReviews.Add(review);
            }
            return metaReviews;
        }
    }
}