using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TST
{
    public class Tests

    {
        private IWebDriver driver;
        private WebDriverWait wait;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


        }

        [Test]
        public void TestLog()
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            Assert.AreEqual("Home page", driver.FindElement(By.CssSelector("h2")).Text);


        }

        [Test]
        public void TestAdd()
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("All Products")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector("#ProductName")).SendKeys("Kungaloosh");
            IWebElement category = driver.FindElement(By.CssSelector("#CategoryId"));
            new Actions (driver).Click().Click(category).SendKeys("Beverages").Build().Perform();
            IWebElement supplier = driver.FindElement(By.CssSelector("#SupplierId"));
            new Actions(driver).Click().Click(supplier).SendKeys("Exotic Liquids").Build().Perform();
            driver.FindElement(By.Id("UnitPrice")).SendKeys("25,000");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("5");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("20");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("100");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("75");
            driver.FindElement(By.CssSelector(".btn")).Click();
            Assert.AreEqual("All Products", driver.FindElement(By.CssSelector("h2")).Text);
        }

        [Test]
        public void TestOut()
        {
            IWebElement mylogin = driver.FindElement(By.Id("Name"));
            new Actions(driver).Click().Click(mylogin).SendKeys("user").Build().Perform();
            IWebElement mypass = driver.FindElement(By.Id("Password"));
            new Actions(driver).Click().Click(mypass).SendKeys("user").Build().Perform();
            IWebElement go = driver.FindElement(By.CssSelector(".btn"));
            new Actions(driver).Click().Click(go).Click().Build().Perform();
            IWebElement away = driver.FindElement(By.LinkText("Logout"));
            new Actions(driver).Click().Click(away).Click().Build().Perform();
            Assert.AreEqual("Login", driver.FindElement(By.CssSelector("h2")).Text);

        }


        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

    }
}