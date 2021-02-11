using OpenQA.Selenium;

namespace TestingAssessment.UI.PageObject
{
    public abstract class BasePage
    {
        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebDriver WebDriver { get; }

    }
}
