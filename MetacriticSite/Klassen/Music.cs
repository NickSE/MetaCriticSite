using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetacriticSite.Klassen
{
    public class Music : Category
    {
        Database.Database db = new Database.Database();
        public DateTime Date { get; set; }
        public string RecordLabel { get; set; }

        public Music(int metascore, int userscore, string name, string genre, string resume, DateTime date,
            string recordLabel) : base(metascore, userscore, name, genre, resume)
        {
            this.Genre = "Music";
            this.Date = date;
            this.RecordLabel = recordLabel;
        }

        //return a piece of music out the database
        public Music getMusic(string music)
        {
            string name = "";
            int metascore = 0;
            int userscore = 0;
            string resume = "";
            string genre = "";
            string recordLabel = "";
            DateTime date = DateTime.Today;
            foreach (Dictionary<string, object> D in db.getMusic(music))
            {
                name = (string)D["naam"];
                metascore = Convert.ToInt32(D["metascore"]);
                userscore = Convert.ToInt32(D["userscore"]);
                resume = (string)D["samenvatting"];
                genre = (string)D["genre"];
                recordLabel = (string)D["recordlabel"];
                date = (DateTime)D["datum"];
            }

            Klassen.Music newMusic = new Klassen.Music(metascore, userscore, name, genre, resume, date, recordLabel);
            return newMusic;
        }

    }
}