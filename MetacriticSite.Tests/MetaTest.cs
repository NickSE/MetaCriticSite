using System;
using System.Collections.Generic;
using MetacriticSite.Klassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetacriticSite.Tests
{
    [TestClass]
    public class MetaTest
    {
        [TestMethod]
        public void TestLogin()
        {
            Klassen.Account acc = new Klassen.Account("test123");
            bool ac = acc.LogIn("test123", "Test123"); //looks if you can login with test123 / Test123
            Assert.AreEqual(true, ac, "Try to login");
            bool fakeAcc = acc.LogIn("Fake", "Fake"); //fake account so can't login
            Assert.AreEqual(false, fakeAcc, "Fake acc");
        }

        [TestMethod]
        public void TestGetGame()
        {
            Game game = new Game(1, 10, "game", "genre", "some text", "xbox", DateTime.Now, 10);
            game = game.getGame("Fallout4"); //get the game fallout4
            Assert.AreEqual("Fallout4", game.Name, "Check if name is equal");
        }

        [TestMethod]
        public void TestGetMovie()
        {
            Movie movie = new Movie(10, 10, "name", "genre", "resume", "director", 10, 10);
            movie = movie.getMovie("Sinister");
            Assert.AreEqual("Sinister", movie.Name, "Check if movie name is equal");
        }

        [TestMethod]
        public void TestGetMusic()
        {
            Klassen.Music music = new Klassen.Music(10, 10, "name", "genre", "resume", DateTime.Now, "record");
            music = music.getMusic("Eminem");
            Assert.AreEqual("Eminem", music.Name, "Check if music name is equal");
        }

        [TestMethod]
        public void TestGetReviews()
        {
            List<Review> reviews = new List<Review>();
            MetaReview meta = new MetaReview("name", "content", DateTime.Now, "spoiler", 10);
            reviews = meta.getMetaReviews(1);
            Assert.AreEqual(4, reviews.Count, "Count list items"); // gets all reviews with category 2 (games)
            List<Review> userReviews = new List<Review>();
            UserReview user = new UserReview("name", "content", DateTime.Now, "spoiler", 10, 1);
            userReviews = user.getUserReviews(1);
            Assert.AreEqual(4, userReviews.Count);
        }
    }
}
