using OpenQA.Selenium;
using System.Collections.Generic;

namespace TestingAssessment.UI.PageObject
{
    public class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public IWebElement ShoppingCart => WebDriver.FindElement(By.Id("shopping_cart_container"));
        public IWebElement FirstNameText => WebDriver.FindElement(By.Id("first-name"));
        public IWebElement LastNameText => WebDriver.FindElement(By.Id("last-name"));
        public IWebElement PostCodeText => WebDriver.FindElement(By.Id("postal-code"));
        public IWebElement CheckoutButton => WebDriver.FindElement(By.ClassName("checkout_button"));
        public IWebElement ContinueButton => WebDriver.FindElement(By.ClassName("cart_button"));
        public IWebElement OrderCompletedContainer => WebDriver.FindElement(By.Id("checkout_complete_container"));
        public IReadOnlyList<IWebElement> ItemsInCart => WebDriver.FindElements(By.ClassName("cart_list"));

        public IWebElement ItemTotal => WebDriver.FindElement(By.ClassName("summary_subtotal_label"));
        public IWebElement Total => WebDriver.FindElement(By.ClassName("summary_total_label"));
        public IWebElement Tax => WebDriver.FindElement(By.ClassName("summary_tax_label"));
    }
}
