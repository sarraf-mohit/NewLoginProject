using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace TestLoginProject
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement UserName => driver.FindElement(By.Id("username")); 

        private IWebElement Password => driver.FindElement(By.Id("password"));

        private IWebElement BtnSubmit => driver.FindElement(By.Id("submit"));

        private string LoggedInMsz => driver.FindElement(By.CssSelector("[class=\"post-title\"]")).Text;

        private Boolean BtnLogOut => driver.FindElement(By.CssSelector("[href*=\"practice-test\"]")).Displayed;

        public void loginApplication(string username, string password) 
        {
            UserName.SendKeys(username);
            Console.WriteLine("Username entered successfully");
            Password.SendKeys(password);
            Console.WriteLine("Password entered successfully");
            BtnSubmit.Click();
        }

        public void verifyPageUrl() 
        {
            string getCurrentPageUrl = driver.Url;
            Assert.IsTrue(getCurrentPageUrl.Contains("practicetestautomation.com/logged-in-successfully/"));
            Console.WriteLine("Print the current Url: " + getCurrentPageUrl);
        }

        public void verifyLogOutBtn()
        {
            Assert.IsTrue(BtnLogOut);
        }

        public void verifyLoggedInText()
        {
            Assert.AreEqual("Logged In Successfully", LoggedInMsz);
            Console.WriteLine("Print the message: " + LoggedInMsz);
        }

    }
}