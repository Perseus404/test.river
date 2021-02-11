using OpenQA.Selenium;

namespace TestingAssessment.UI.PageObject
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public IWebElement UserTextBox => WebDriver.FindElement(By.Id("user-name"));
        public IWebElement PasswordTextBox => WebDriver.FindElement(By.Id("password"));
        public IWebElement LoginButton => WebDriver.FindElement(By.Id("login-button"));
   
    }
}
