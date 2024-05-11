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
    public class MouseDoubleCLick {

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
            driver.Url = "https://www.google.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();

            IWebElement searchTextBox = driver.FindElement(By.XPath("//textarea[@name='q']"));

            searchTextBox.SendKeys("citibank");

            searchTextBox.SendKeys(OpenQA.Selenium.Keys.Enter);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Actions actions = new Actions(driver);
            IWebElement searchXpath = driver.FindElement(By.XPath("//a[contains(text(),'Internet Banking')]"));

            actions.DoubleClick(searchXpath).Build().Perform();

            //driver.Close();
        }
    }
}
