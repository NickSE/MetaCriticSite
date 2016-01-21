using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetacriticSite.Database;

namespace MetacriticSite.Klassen
{
    public class Account
    {
        public static Account LoggedInUser { get; set; }
        public string Name { get; set; }

        public Account(string name)
        {
            this.Name = name;
        }

        Database.Database db = new Database.Database();

        /// <summary>
        /// a simple login method that uses the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LogIn(string username, string password)
        {
            foreach (Dictionary<string, object> D in db.Getuserpassword(username))
            {
                if ((string)D["wachtwoord"] == password)
                {
                    LoggedInUser = new Account((string)D["naam"]);
                    return true;
                }
            }
            return false;
        }
    }
}