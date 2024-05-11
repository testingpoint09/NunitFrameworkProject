using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkPractice.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace GlobalValueCMD.Tests
{
    public  class GuruLoginTestcase:Base
    {

        [Test, Category("Smoke")]
        public void loginTest() 
        {
            
            //"mngr568996", "rAsAtUd"
            //dotnet test GlobalValueCMD.csproj --TestRunParameters.Parameter\(name =\"browserName\",value=\"chrome\"\)
           

            IWebElement username = driver.FindElement(By.XPath("//input[@name=\"uid\"]"));


            IWebElement password = driver.FindElement(By.XPath("//input[@name=\"password\"]"));

            IWebElement loginButton = driver.FindElement(By.XPath("//input[@value=\"LOGIN\"]"));


            username.SendKeys("mngr568996");
            password.SendKeys("rAsAtUd");
            loginButton.Click();


        }
    }
}
