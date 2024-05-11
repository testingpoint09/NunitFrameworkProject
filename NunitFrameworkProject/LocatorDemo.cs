using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;

namespace NunitFrameworkProject
{
    internal class LocatorDemo
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
            driver.Url = "https://demo.guru99.com/V4/index.php";
            IWebElement userId = driver.FindElement(By.XPath("//input[@name=\"uid\"]"));
            userId.SendKeys("mngr570070");

            IWebElement password = driver.FindElement(By.XPath("//input[@name=\"password\"]"));
            password.SendKeys("vurUsam");

            IWebElement loginButton = driver.FindElement(By.Name("btnLogin"));
            loginButton.Click();
            driver.Close();
        }
    }
}
