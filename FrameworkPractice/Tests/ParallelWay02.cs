using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameworkPractice.Tests
{
    //Parallel way of execution..
    [Parallelizable(ParallelScope.Children)]
    public  class ParallelWay02
    {
        //remove below code 
        //public IWebDriver driver;
        //implement ThreadLocal class concept for paraallel test execution.
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [Test, TestCaseSource("AddTestConfig")]
        
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


        [Test]
        public void DropdownTest()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            driver.Value = new ChromeDriver();

            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://www.facebook.com/";
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement create_button = driver.Value.FindElement(By.XPath("//a[contains(text(),'Create new account')]"));
            create_button.Click();

            Thread.Sleep(5000);

            //Days dropdown code
            string dayOfTheWeek = "20";
            SelectElement dropDown = new SelectElement(driver.Value.FindElement(By.Id("day")));
            dropDown.SelectByValue(dayOfTheWeek);

            string monthOfTheWeek = "Jun";
            SelectElement dropDown_month = new SelectElement(driver.Value.FindElement(By.Id("month")));
            dropDown_month.SelectByText(monthOfTheWeek);

            int yearofDD = 20;
            SelectElement dropDown_year = new SelectElement(driver.Value.FindElement(By.Id("year")));
            dropDown_year.SelectByIndex(yearofDD);
            //driver.Close();
        }
    }
}
