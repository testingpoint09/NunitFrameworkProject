using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

using OpenQA.Selenium.Support.UI;

namespace NunitFrameworkProject
{
    public class dropdownDemo
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
            driver.Url = "https://www.facebook.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement create_button = driver.FindElement(By.XPath("//a[contains(text(),'Create new account')]"));
            create_button.Click();

            Thread.Sleep(5000);

            //Days dropdown code
            string dayOfTheWeek = "20";
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Id("day")));
            dropDown.SelectByValue(dayOfTheWeek);

            string monthOfTheWeek = "Jun";
            SelectElement dropDown_month = new SelectElement(driver.FindElement(By.Id("month")));
            dropDown_month.SelectByText(monthOfTheWeek);

            int yearofDD= 20;
            SelectElement dropDown_year = new SelectElement(driver.FindElement(By.Id("year")));
            dropDown_year.SelectByIndex(yearofDD);
            //driver.Close();
        }
    }
}
