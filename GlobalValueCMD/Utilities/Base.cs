using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;

namespace FrameworkPractice.Utilities
{
    public  class Base
    {
        public IWebDriver driver;
        String browsername;
        [SetUp]
        public void StartBrowser()
        {        
           
            browsername = TestContext.Parameters["browserName"];
            if (browsername == null)
            {

                browsername = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browsername);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://demo.guru99.com/V4/index.php";
        }

        public void InitBrowser(String browserName)
        {

            switch (browserName)
            {
                case "chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "ie":

                    new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
                    driver = new InternetExplorerDriver();
                    break;

            }
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }

        
        public IWebDriver getDriver()
        {
            return driver;
        }

       
    }
}
