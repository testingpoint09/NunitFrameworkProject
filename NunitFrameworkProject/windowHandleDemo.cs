using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitFrameworkProject
{
    public class windowHandleDemo {

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
            driver.Url = "https://demo.guru99.com/popup.php";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
          

            driver.FindElement(By.XPath("//a[text()='Click Here']")).Click();

            // Single window id--Unique id's
            string parent_Window = driver.CurrentWindowHandle;
            Console.WriteLine(parent_Window);

            // Multiple window id's 
            ReadOnlyCollection<string> set = driver.WindowHandles; // 1,2 id's--abc,xyz
                                                                   // Using Iterator to iterate with in windows replicate of for loop  
            IEnumerator<string> itr = set.GetEnumerator(); // 1,2,3,4
            while (itr.MoveNext()) // conditional check+loop either yes/or
            {
                string ChildWindow = itr.Current; // next index number id get
                Console.WriteLine(ChildWindow);

                if (!parent_Window.Equals(ChildWindow, StringComparison.OrdinalIgnoreCase))
                {
                    // Switching to Child window
                    //driver.SwitchTo().Alert()
                    driver.SwitchTo().Window(ChildWindow);

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    driver.FindElement(By.Name("emailid")).SendKeys("gaurav.3n@gmail.com");
                    driver.FindElement(By.Name("btnLogin")).Click();

                    // Closing the Child Window.
                    //driver.Close();
                }
            }
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // This is  switch back to the main window/parent window
            driver.SwitchTo().Window(parent_Window);


            //driver.Close();
        }
    }
}
