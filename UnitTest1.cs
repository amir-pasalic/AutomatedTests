using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Linq;

namespace AutomatedTests
{
    public class Tests
    {
        ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(".");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }

        [Test]
        public void CanOpenGithub()
        {
            driver.Navigate().GoToUrl("https://github.com");

            var title = driver.FindElement(By.CssSelector("h1")).Text;

            Assert.AreEqual(title, "Built for developers");
        }


        [Test]
        public void ContainsAllMyRepositories()
        {
            driver.Navigate().GoToUrl("https://github.com/amir-pasalic?tab=repositories");

            var repoLiElements = driver.FindElements(By.CssSelector("[data-filterable-for=\"your-repos-filter\"] > li"));

            Assert.AreEqual(1, repoLiElements.Count);
        }
    }
}
//testtest