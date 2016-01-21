using System;
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
        }
    }
}
