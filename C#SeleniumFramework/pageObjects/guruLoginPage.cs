using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace C_SeleniumFramework.pageObjects
{
    public  class guruLoginPage
    {

        public  IWebDriver driverG;

        public guruLoginPage(IWebDriver driver)
        {
            this.driverG = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.XPath,Using = "//input[@name=\"uid\"]")]
        private IWebElement username;

        [FindsBy(How = How.XPath, Using = "//input[@name=\"password\"]")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//input[@value=\"LOGIN\"]")]
        private IWebElement loginButton;

        public IWebElement getUsername() { 
            
            return username; 
        }

        public IWebElement getPassword()
        {

            return password;
        }

        public IWebElement getLoginButton()
        {

            return loginButton;
        }


    }
}
