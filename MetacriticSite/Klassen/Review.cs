using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetacriticSite.Klassen
{
    public abstract class Review
    {
        List<Category> categories = new List<Category>(); 
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Spoiler { get; set; }


        public Review(string name, string content, DateTime date, string spoiler)
        {
            this.Name = name;
            this.Content = content;
            this.Date = DateTime.Today;
            this.Spoiler = spoiler;
        }

        /// <summary>
        /// a method for calculating the average score of a list of integers
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        public int AverageScore(List<int> scores)
        {
            int total_scores = 0;
            int counter = 0;
            int averageScore = 0;

            foreach (int i in scores)
            {
                total_scores += i;
                counter++;
            }
            if (counter != 0)
            {
                averageScore = total_scores/counter;
            }
            return averageScore;
        }
    }
}