using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkPractice.Utilities;
using FrameworkPractice.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using C_SeleniumFramework.pageObjects;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace C_SeleniumFramework.Tests
{
    public  class GuruLoginTestcase
    {
        public IWebDriver driver;
        [Test]
        [TestCase("mngr568996", "rAsAtUd")]
        [TestCase("mngr568996", "rAsAtUd")]
        [TestCase("mngr568996", "rAsAtUd")]
        public void loginTest(string userdata,string passworddata) 
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Url = "https://demo.guru99.com/V4/index.php";
            driver.Manage().Window.Maximize();

            IWebElement username = driver.FindElement(By.XPath("//input[@name=\"uid\"]"));


            IWebElement password = driver.FindElement(By.XPath("//input[@name=\"password\"]"));

            IWebElement loginButton = driver.FindElement(By.XPath("//input[@value=\"LOGIN\"]"));


            username.SendKeys(userdata);
            password.SendKeys(passworddata);
            loginButton.Click();


        }
    }
}
