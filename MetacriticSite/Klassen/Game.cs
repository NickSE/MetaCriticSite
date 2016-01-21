using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetacriticSite.Database;

namespace MetacriticSite.Klassen
{
    public class Game : Category
    {
        Database.Database db = new Database.Database();
        public string Console { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }

        public Game(int metascore, int userscore, string name, string genre, string resume, string console,
            DateTime date, int rating) : base(metascore, userscore, name, genre, resume)
        {
            this.Genre = "Game";
            this.Console = console;
            this.Date = date;
            this.Rating = rating;
        }

        //return a game out the database
        public Game getGame(string game)
        {
            string name = "";
            int metascore = 0;
            int userscore = 0;
            string resume = "";
            string genre = "";
            string console = "";
            DateTime date = DateTime.Today;
            int rating = 0;
            foreach (Dictionary<string, object> D in db.getGame(game))
            {
                name = (string)D["naam"];
                metascore = Convert.ToInt32(D["metascore"]);
                userscore = Convert.ToInt32(D["userscore"]);
                resume = (string)D["samenvatting"];
                genre = (string)D["genre"];
                console = (string)D["spelcomputer"];
                date = (DateTime)D["datum"];
                rating = Convert.ToInt32(D["rating"]);
            }

            Game newGame = new Game(metascore, userscore, name, genre, resume, console, date, rating);
            return newGame;
        }
    }
}