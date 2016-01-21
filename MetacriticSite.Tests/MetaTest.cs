﻿using System;
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
    }
}
