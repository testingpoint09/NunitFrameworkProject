using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitFrameworkProject
{
    public class BrowserDemo
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            
        }
        [Test]
        public void Test1()
        {
            driver.Url="https://www.google.com/";
            TestContext.Progress.WriteLine("Site Title is :"+driver.Title);
            TestContext.Progress.WriteLine("Site URL is :"+driver.Url);
            driver.Close();
        }
    }
}
