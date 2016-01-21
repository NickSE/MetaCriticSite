using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetacriticSite.Klassen
{
    public class Movie : Category
    {
        Database.Database db = new Database.Database();
        public string Director { get; set; }
        public int Rating { get; set; }
        public int FilmTime {get; set; }

        public Movie(int metascore, int userscore, string name, string genre, string resume, string director, int rating, int filmTime) : base(metascore, userscore, name, genre, resume)
        {
            this.Genre = "Movie";
            this.Director = director;
            this.Rating = rating;
            this.FilmTime = filmTime;
        }

        //return movie out the database
        public Movie getMovie(string movie)
        {
            string name = "";
            int metascore = 0;
            int userscore = 0;
            string resume = "";
            string genre = "";
            string director = "";
            int filmTime = 0;
            int rating = 0;
            foreach (Dictionary<string, object> D in db.getMovie(movie))
            {
                name = (string)D["naam"];
                metascore = Convert.ToInt32(D["metascore"]);
                userscore = Convert.ToInt32(D["userscore"]);
                resume = (string)D["samenvatting"];
                genre = (string)D["genre"];
                director = (string)D["director"];
                filmTime = Convert.ToInt32(D["filmtijd"]);
                rating = Convert.ToInt32(D["rating"]);
            }

            Movie newMovie = new Movie(metascore, userscore, name, genre, resume, director, rating, filmTime);
            return newMovie;
        }

    }
}