using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;

namespace NunitFrameworkProject
{
    internal class EdgeBrowser
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());

            driver = new EdgeDriver();

            driver.Manage().Window.Maximize();

        }
        [Test]
        public void Test1()
        {
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/";
            TestContext.Progress.WriteLine("Site Title is :" + driver.Title);
            TestContext.Progress.WriteLine("Site URL is :" + driver.Url);
            driver.Close();
        }
    }
}
