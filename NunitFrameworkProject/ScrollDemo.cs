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
    public class ScrollDemo {

        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Go to URL
            driver.Navigate().GoToUrl("https://www.amazon.in/");

            driver.Manage().Window.Maximize();

        }
        [Test]
        public void Test1()
        {
            
            //scripting languages all supports Eclipse IDE,Visual Studio 

            // Create IJavaScriptExecutor object
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            // Scroll Down Page using Second way
            jse.ExecuteScript("window.scrollBy(0,5000)");

            // Implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Scroll Up Page using Second way
            jse.ExecuteScript("window.scrollBy(0,-5000)");


            //driver.Close();
        }
    }
}
