using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetacriticSite.Klassen
{
    public class Show : Category
    {
        Database.Database db = new Database.Database();
        public DateTime Date { get; set; }
        public int Length { get; set; }
        public int Time { get; set; }

        public Show(int metascore, int userscore, string name, string genre, string resume, DateTime date, int length,
            int time) : base(metascore, userscore, name, genre, resume)
        {
            this.Genre = "Show";
            this.Date = date;
            this.Length = length;
            this.Time = time;
        }

        //returns a show from the database
        public Show getShow(string show)
        {
            string name = "";
            int metascore = 0;
            int userscore = 0;
            string resume = "";
            string genre = "";
            DateTime date = DateTime.Today;
            int length = 0;
            int time = 0;
            foreach (Dictionary<string, object> D in db.getSerie(show))
            {
                name = (string)D["naam"];
                metascore = Convert.ToInt32(D["metascore"]);
                userscore = Convert.ToInt32(D["userscore"]);
                resume = (string)D["samenvatting"];
                genre = (string)D["genre"];
                date = (DateTime)D["datum"];
                length = Convert.ToInt32(D["lengte"]);
                time = Convert.ToInt32(D["tijdstip"]);
            }

            Show newShow = new Show(metascore, userscore, name, genre, resume, date, length, time);
            return newShow;
        }
    }
}