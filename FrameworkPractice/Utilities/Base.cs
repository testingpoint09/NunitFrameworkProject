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

namespace FrameworkPractice.Utilities
{
    public  class Base
    {

        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()

        {
          
            InitBrowser("chrome");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";


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

        //Json reader method
        public static JsonReader getDataParser() {
            return new JsonReader();
        }
    }
}
