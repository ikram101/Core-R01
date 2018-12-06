
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbFirstUniversity.Controllers;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstUniversity.Tests
{
    [TestClass]

    public class HomeControllerIndexTests
    {
        [TestMethod]

        public void HomeIndexTests()

        {
            HomeController homeController = new HomeController();

            ViewResult result = homeController.Index() as ViewResult;

            Assert.AreNotEqual("Hello",result.ViewData["Hello"]);

        }

    }
}
