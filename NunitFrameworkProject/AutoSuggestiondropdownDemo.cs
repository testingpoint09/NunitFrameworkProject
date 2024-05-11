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
    public class AutoSuggestiondropdownDemo
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
            driver.Url = "https://rahulshettyacademy.com/dropdownsPractise/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement search_box = driver.FindElement(By.Id("autosuggest"));
            search_box.SendKeys("Ind");

            Thread.Sleep(5000);

            IList<IWebElement> options=driver.FindElements(By.CssSelector(".ui-menu-item a"));

            foreach(IWebElement option in options) {
                
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }
            }

            TestContext.Progress.WriteLine
                (driver.FindElement(By.Id("autosuggest")).GetAttribute("value"));

           
            //driver.Close();
        }
    }
}
