using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace NunitFrameworkProject
{
    internal class WaitDemo
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
        public void waitTest()
        {
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/";
            // searchbox
            IWebElement searchBox = driver.FindElement(By.XPath("//input[@type=\"search\"]"));
            searchBox.SendKeys("ber");

            System.Threading.Thread.Sleep(5000); // 1000=1sec

            ReadOnlyCollection<IWebElement> prodCount = driver.FindElements(By.XPath("//div[@class=\"products\"]/div"));
            int count = prodCount.Count;
            Console.WriteLine("total products are :" + count);

            ReadOnlyCollection<IWebElement> addToCartBtns = driver.FindElements(By.XPath("//button[contains(text(),'ADD TO CART')]"));

            foreach (IWebElement btn in addToCartBtns)
            {
                btn.Click();
            }

            IWebElement cartImage = driver.FindElement(By.XPath("//img[@alt=\"Cart\"]"));
            cartImage.Click();

            IWebElement proceedToCheckout = driver.FindElement(By.XPath("//button[contains(text(),'PROCEED TO CHECKOUT')]"));

            // Explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(proceedToCheckout)).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement promoTextbox = driver.FindElement(By.XPath("//input[@class=\"promoCode\"]"));
            promoTextbox.SendKeys("rahulshettyacademy");

            IWebElement applyButton = driver.FindElement(By.XPath("//button[contains(text(),'Apply')]"));
            applyButton.Click();

            // getting the successmessage from the screen
            IWebElement successMsg = driver.FindElement(By.XPath("//span[@class=\"promoInfo\"]"));

            WebDriverWait waitSuccess = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitSuccess.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(successMsg));

            string message = successMsg.Text; //getText() method...
            Console.WriteLine(message);

        }
    }
}
