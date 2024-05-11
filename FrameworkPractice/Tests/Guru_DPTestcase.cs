﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameworkPractice.Tests
{
    public class Guru_DPTestcase
    {
        public IWebDriver driver;
        [Test,TestCaseSource("AddTestConfig")]
       
        public void loginTest(string userdata, string passworddata)
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

        public static IEnumerable<TestCaseData> AddTestConfig() {
            yield return new TestCaseData("mngr568996", "rAsAtUd");
            yield return new TestCaseData("mngr568996", "rAsAtUd");
        }
    }
}
