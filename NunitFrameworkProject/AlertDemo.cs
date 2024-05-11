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
    public class AlertDemo {

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
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/delete_customer.php");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();

            
      

            IWebElement custId = driver.FindElement(By.XPath("//input[@name='cusid']"));
            custId.SendKeys("0012145");

            IWebElement submitBtn = driver.FindElement(By.XPath("//input[@name='submit']"));
            submitBtn.Click();

            IAlert alert = driver.SwitchTo().Alert();

            // Capturing alert message
            string alertMessage = driver.SwitchTo().Alert().Text;

            // Displaying alert message
            Console.WriteLine(alertMessage);
            Thread.Sleep(3000);

            // Accepting alert (Yes/Ok)
            alert.Accept();
            //driver.Close();
        }
    }
}
