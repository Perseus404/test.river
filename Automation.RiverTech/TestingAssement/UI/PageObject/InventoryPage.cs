using OpenQA.Selenium;
using System.Collections.Generic;

namespace TestingAssessment.UI.PageObject
{
    public class InventoryPage : BasePage
    {
        public InventoryPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public IEnumerable<IWebElement> Items => WebDriver.FindElements(By.ClassName("inventory_item"));
    }
}