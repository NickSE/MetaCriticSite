using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace MetacriticSite.Database
{
    public class Database
    {
        //fields
        private OracleConnection con;

        /// <summary>
        /// constructor
        /// </summary>

        public Database()
        {
        }

        /// <summary>
        /// doQuery
        /// </summary>
        /// <param name="query">here u need to insert your query </param>
        /// <returns></returns>
        protected int doQuery(string query)
        {
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                OracleTransaction transact = cmd.Connection.BeginTransaction();
                cmd.Transaction = transact;
                int ret = cmd.ExecuteNonQuery();
                transact.Commit();
                Disconnect();
                return ret;

            }
            catch (Exception e) { Console.WriteLine(e.ToString()); return -1; }
            finally { Disconnect(); }
        }

        #region GetQuery
        /// <summary>
        /// GetQuery
        /// </summary>
        /// <param name="query">here u need to insert your query</param>
        /// <returns></returns>
        protected List<Dictionary<string, object>> getQuery(string query)
        {
            List<Dictionary<string, object>> ret = new List<Dictionary<string, object>>();

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                bool read = false;

                OracleDataReader data = cmd.ExecuteReader();


                while (data.Read())
                {
                    read = true;
                    Dictionary<string, object> d = new Dictionary<string, object>();
                    for (int c = 0; c < data.FieldCount; c++)
                        d.Add(data.GetName(c).ToLower(), data.GetValue(c));


                    ret.Add(d);
                }

                if (!read)
                {
                    throw new Exception("An open connection is already active");
                }

                Disconnect();
                return ret;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<Dictionary<string, object>>();
            }
            finally { Disconnect(); }
        }
        #endregion

        /// <summary>
        /// Connect
        /// </summary>
        private void Connect()
        {
            con = new OracleConnection();
            con.ConnectionString = "Data Source=fhictora01.fhict.local/fhictora;Persist Security Info=True;User ID=dbi310866;Password=O4g03ym3r8";
            con.Open();
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        private void Disconnect()
        {
            con.Close();
            con.Dispose();
        }

        //Query's
        public List<Dictionary<string, object>> Getuserpassword(string username) 
        {
            List<Dictionary<string, object>> user = getQuery("SELECT Wachtwoord, Naam FROM Account WHERE Naam = '" + username + "'"); 
            return user;    
        }

        public List<Dictionary<string, object>> getMovie(string movieName)
        {
            List<Dictionary<string, object>> movie =
                getQuery("SELECT c.NAAM, c.METASCORE, c.USERSCORE, c.SAMENVATTING, c.GENRE, f.DIRECTOR, f.FILMTIJD, f.RATING FROM Categorie c, film f where c.CATEGORIENR = f.CATEGORIENR AND c.naam = '" +
                         movieName + "'");
            return movie;
        }

        public List<Dictionary<string, object>> getMusic(string musicName)
        {
            List<Dictionary<string, object>> music =
                getQuery("SELECT c.NAAM, c.METASCORE, c.USERSCORE, c.SAMENVATTING, c.GENRE, m.RECORDLABEL, m.DATUM FROM Categorie c, muziek m where c.CATEGORIENR = m.CATEGORIENR AND c.naam = '" +
                         musicName + "'");
            return music;
        }

        public List<Dictionary<string, object>> getGame(string gameName)
        {
            List<Dictionary<string, object>> game =
                getQuery("SELECT c.NAAM, c.METASCORE, c.USERSCORE, c.SAMENVATTING, c.GENRE, g.SPELCOMPUTER, g.DATUM, g.RATING FROM Categorie c, game g where c.CATEGORIENR = g.CATEGORIENR AND c.naam = '" +
                         gameName + "'");
            return game;
        }

        public List<Dictionary<string, object>> getSerie(string serieName)
        {
            List<Dictionary<string, object>> serie =
                getQuery("SELECT c.NAAM, c.METASCORE, c.USERSCORE, c.SAMENVATTING, c.GENRE, s.DATUM, s.LENGTE, s.TIJDSTIP FROM Categorie c, serie s where c.CATEGORIENR = s.CATEGORIENR AND c.naam = '" +
                         serieName + "'");
            return serie;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categorienr">1=game, 2=movie, 3=show, 4=music</param>
        /// <returns>list of reviews</returns>
        public List<Dictionary<string, object>> getReviews(int categorienr)
        {
            List<Dictionary<string, object>> review =
                getQuery("SELECT NAAM, SCORE, INHOUD, DATUM, SPOILER FROM Review WHERE CATEGORIENR = "+ categorienr);
            return review;
        }

        public int getLatestReviewID()
        {
            int LatestID = 0;
            List<Dictionary<string, object>> id = getQuery("select count(reviewnr) from review");
            foreach (Dictionary<string, object> D in id)
            {
                LatestID = Convert.ToInt32(D["count(reviewnr)"]);
            }
            return LatestID + 2;

        }

        public bool commitReview(string email, int categorienr, string naam, int score, string inhoud, string spoiler)
        {
            try
            {
                string query; // the query will end up in here
                query = "insert into review(reviewnr, email, categorienr, naam, score, inhoud, datum, spoiler) Values(" + getLatestReviewID() + ", '" + email + "', " + categorienr + ", '" + naam + "', " + score + ", '" + inhoud + "', to_date('" + DateTime.Now.ToString("MM-dd-yyyy hh:mm") + "','MM-DD-YYYY hh24:MI'), '" + spoiler + "')";  //replace with INSERT if need
                doQuery(query); //query will be activated
                return true;
            }
            catch
            {
                return false;   // if query fails, return a false.
            }
        }

        public List<Dictionary<string, object>> getLatestReview(int categorienr)
        {
            int latestID = 0;
            List<Dictionary<string,object>> id = getQuery("SELECT max(reviewnr) from review where categorienr = " + categorienr);
            foreach (Dictionary<string, object> D in id)
            {
                latestID = Convert.ToInt32(D["max(reviewnr)"]);
            }
            List<Dictionary<string, object>> review =
                getQuery("SELECT NAAM, SCORE, INHOUD, DATUM, SPOILER FROM Review WHERE CATEGORIENR = " + latestID);
            return review;
        }
    }
}