using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_SeleniumFramework.pageObjects;
using C_SeleniumFramework.utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace C_SeleniumFramework.Tests
{
    internal class GuruLoginTestcase:BaseClass
    {
        [Test]
        public void loginTest() 
        {

            /*IWebElement userId = driver.FindElement(By.XPath("//input[@name=\"uid\"]"));
            userId.SendKeys("mngr568996");

            IWebElement password = driver.FindElement(By.XPath("//input[@name=\"password\"]"));
            password.SendKeys("rAsAtUd");

            IWebElement loginButton = driver.FindElement(By.XPath("//input[@value=\"LOGIN\"]"));
            loginButton.Click();*/

            guruLoginPage login = new guruLoginPage(getDriver());
            login.getUsername().SendKeys("mngr568996");
            login.getPassword().SendKeys("rAsAtUd");
            login.getLoginButton().Click();


        }
    }
}
