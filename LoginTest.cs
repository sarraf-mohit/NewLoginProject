using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestLoginProject
{
    internal class LoginTest
    {
        private IWebDriver driver;
        private LoginPage login;

        public static void Main()
        {
            LoginTest loginTest = new LoginTest();
            loginTest.Setup();
            loginTest.Login();
            loginTest.HomePage();   
        }

        public string getTextFromXML(string value)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string xmlFilePath = Path.Combine(basePath, @"..\..\..\..\LoginProject\TestData.xml");

            XDocument document = XDocument.Load(xmlFilePath);
            var user = document.Descendants("User").FirstOrDefault();
            return user.Element(value)?.Value;
        }

        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(getTextFromXML("Url"));
            login = new LoginPage(driver);
        }

        public void Login()
        {
            login.loginApplication(getTextFromXML("Username"), getTextFromXML("Password"));
        }

        public void HomePage() 
        {
            login.verifyPageUrl();
            login.verifyLoggedInText();
            login.verifyLogOutBtn();
        }
    }
}
