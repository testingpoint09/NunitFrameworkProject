using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitFrameworkProject
{
    public class MouseMove {

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
            driver.Url = "https://www.amazon.in/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Actions actions = new Actions(driver);

            // Menu Link xpath
            IWebElement menuLink = driver.FindElement(By.XPath("//div[@id=\"nav-tools\"]/a[2]/div/span"));

            actions.MoveToElement(menuLink).Build().Perform();

            IWebElement subMenuLink = driver.FindElement(By.XPath("//div[@id=\"nav-flyout-ya-signin\"]/a"));
            subMenuLink.Click();
            //driver.Close();
        }
    }
}
