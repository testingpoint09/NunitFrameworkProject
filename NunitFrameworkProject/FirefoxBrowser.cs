using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;

namespace NunitFrameworkProject
{
    internal class FirefoxBrowser
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());

            driver = new FirefoxDriver();

            driver.Manage().Window.Maximize();

        }
        [Test]
        public void Test1()
        {
            driver.Url = "https://demo.guru99.com/V4/index.php";
            TestContext.Progress.WriteLine("Site Title is :" + driver.Title);
            TestContext.Progress.WriteLine("Site URL is :" + driver.Url);
            driver.Close();
        }
    }
}
