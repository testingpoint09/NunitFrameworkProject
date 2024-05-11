using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace C_SeleniumFramework.utilities
{
    public class BaseClass
    {

        public IWebDriver driver;
        String browserName;
        //public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
       

        [TearDown]
        public void close() {

            driver.Quit();
        }

        public void InitBrowser(String browserName) {

            String Browser_Name = ConfigurationManager.AppSettings["browser"];

            switch(Browser_Name)
                {
                case "chrome":                    

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver= new ChromeDriver();
                    break;

            }        
        }
        [Test]
        public void startBrowser()
        {
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {

                browserName = ConfigurationManager.AppSettings["browser"];
            }
            
            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://demo.guru99.com/V4/index.php";

        }

        public IWebDriver getDriver() {

            return driver;

        }
    }
}
