using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using FrameworkPractice.Utilities;

namespace FrameworkPractice.Tests
{
    public  class Guru_JsonData
    {
        public IWebDriver driver;
        [Test, TestCaseSource("AddTestConfig")]

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

        public static IEnumerable<TestCaseData> AddTestConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"),
                getDataParser().extractData("password"));
           
        }

        //Json reader method
        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }
    }
}
