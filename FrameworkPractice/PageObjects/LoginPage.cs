using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FrameworkPractice.PageObjects
{
    public  class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PageObject Factory

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        public IWebElement getUsername()
        {
            return username;
        }
    }
}
