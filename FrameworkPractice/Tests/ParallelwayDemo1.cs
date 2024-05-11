using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace FrameworkPractice.Tests
{
    public  class ParallelwayDemo1
    {
        //remove below code 
        //public IWebDriver driver;
        //implement ThreadLocal class concept for paraallel test execution.
        public ThreadLocal<IWebDriver> driver= new ThreadLocal<IWebDriver>();
        [Test, TestCaseSource("AddTestConfig")]
        [Parallelizable(ParallelScope.All)]
        public void loginTest(string userdata, string passworddata)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver.Value = new ChromeDriver();
            driver.Value.Url = "https://demo.guru99.com/V4/index.php";
            driver.Value.Manage().Window.Maximize();

            IWebElement username = driver.Value.FindElement(By.XPath("//input[@name=\"uid\"]"));


            IWebElement password = driver.Value.FindElement(By.XPath("//input[@name=\"password\"]"));

            IWebElement loginButton = driver.Value.FindElement(By.XPath("//input[@value=\"LOGIN\"]"));


            username.SendKeys(userdata);
            password.SendKeys(passworddata);
            loginButton.Click();


        }

        public static IEnumerable<TestCaseData> AddTestConfig()
        {
            yield return new TestCaseData("mngr568996", "rAsAtUd");
            yield return new TestCaseData("mngr568996", "rAsAtUd");
        }

        
        
    }
}
