using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetacriticSite.Klassen
{
    public abstract class Category
    {
        public int Metascore { get; set; }
        public int Userscore { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Resume { get; set; }

        public Category(int metascore, int userscore, string name, string genre, string resume)
        {
            this.Metascore = metascore;
            this.Userscore = userscore;
            this.Name = name;
            this.Genre = genre;
            this.Resume = resume;
        }
    }
}