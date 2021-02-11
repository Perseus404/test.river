using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestingAssessment.Steps.Models;
using TestingAssessment.Steps.Models.UI;
using TestingAssessment.UI.Models;
using TestingAssessment.UI.PageObject;
using Xunit;

namespace TestingAssessment.Steps
{
    [Binding]
    public class ShoppingCartSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver webDriver;
        private LoginPage loginPage;
        private InventoryPage inventoryPage;
        private ShoppingCartPage shoppingCartPage;

        public ShoppingCartSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            webDriver = new ChromeDriver();
        }

        [Given(@"that '(.*)' is on '(.*)'")]
        public void GivenThatIsOn(string persona, string url)
        {
            webDriver.Url = url;
            webDriver.Navigate();
        }
        
        [Given(@"'(.*)' is logged in")]
        public void GivenIsLoggedIn(string persona)
        {
            loginPage = new LoginPage(webDriver);

            loginPage.UserTextBox.SendKeys("standard_user");
            loginPage.PasswordTextBox.SendKeys("secret_sauce");

            loginPage.LoginButton.Click();
        }
        
        [When(@"'(.*)' adds '(.*)' into the cart")]
        public void WhenAddsIntoTheCart(string persona, string itemName)
        {
            inventoryPage =  new InventoryPage(webDriver);
            var items = inventoryPage.Items;

            foreach (var item in items)
            {
                var name = item.FindElement(By.ClassName("inventory_item_name")).Text;

                if (!itemName.Equals(name))
                    continue;

                item.FindElement(By.ClassName("btn_inventory")).Click();

                if (!_scenarioContext.TryGetValue<Dictionary<string, Product>>($"{persona}.ItemsInCart", out var itemsInCart))
                    itemsInCart = new Dictionary<string, Product>();

                if (itemsInCart.TryGetValue(itemName, out var prod)) 
                {
                    prod.Amount++;
                }
                else
                {
                    var priceText = item.FindElement(By.ClassName("inventory_item_price")).Text;
                    var price = Convert.ToDecimal(Regex.Match(priceText,@"[0-9]+(\.[0-9]+)?").Value);
                    
                    itemsInCart.Add(itemName,new Product(1, itemName, price));
                }
                // This could be used to dynamically assert the cart
                _scenarioContext.TryAdd($"{persona}.ItemsInCart", itemsInCart);
            }
        }
        
        [When(@"'(.*)' clicks on the cart icon and is navigated to it")]
        public void WhenClicksOnTheCartIconAndIsNavigatedToIt(string persona)
        {
            shoppingCartPage = new ShoppingCartPage(webDriver);
            shoppingCartPage.ShoppingCart.Click();
        }
        
        [When(@"'(.*)' clicks on checkout")]
        public void WhenClicksOnCheckout(string persona)
        {
            shoppingCartPage.CheckoutButton.Click();
        }

        [When(@"'(.*)' enters his shipping details:")]
        public void WhenEndtersHisShippingDetails(string persona, Table table)
        {
            var shippingDetails = table.CreateInstance<ShippingDetails>();

            shoppingCartPage.FirstNameText.SendKeys(shippingDetails.FirstName);
            shoppingCartPage.LastNameText.SendKeys(shippingDetails.LastName);
            shoppingCartPage.PostCodeText.SendKeys(shippingDetails.ZipCode);

            shoppingCartPage.ContinueButton.Click();

        }
        
        [When(@"'(.*)' clicks on finish")]
        public void WhenClicksOnFinish(string persona)
        {
            shoppingCartPage.ContinueButton.Click();
        }
        
        [Then(@"'(.*)' is in '(.*)' cart")]
        public void ThenIsInCart(string itemName, string persona)
        {
            if (!_scenarioContext.TryGetValue<Dictionary<string, Product>>($"{persona}.ItemsInCart", out var itemsInCart))
                itemsInCart = new Dictionary<string, Product>();
            //  Assert.Fail(); does not seem to be available 
            // throw cause nothing was logged

            if (itemsInCart.Count == 0)
                throw new Exception($"Check test! No items were found in {persona}.ItemsInCart");

            // do not really like this
            if(!(shoppingCartPage.ItemsInCart.Count > 0))
                throw new Exception($"No items found in the shopping cart!");
            
            var productNamesInCart = new List<string>();
            
            foreach (var item in shoppingCartPage.ItemsInCart)
            {
                productNamesInCart.Add(item.FindElement(By.ClassName("inventory_item_name")).Text);
            }

            Assert.Contains(itemName, productNamesInCart);
        }
       
        
        [Then(@"the overall page displayed the following:")]
        public void ThenThePageDisplayedThFollowing(Table table)
        {
            var overviewDetails = table.CreateInstance<OverviewDetails>();

            var total = Convert.ToDecimal(Regex.Match(shoppingCartPage.Total.Text, @"[0-9]+(\.[0-9]+)?").Value);
            var tax = Convert.ToDecimal(Regex.Match(shoppingCartPage.Tax.Text, @"[0-9]+(\.[0-9]+)?").Value);
            var ItemTotal = Convert.ToDecimal(Regex.Match(shoppingCartPage.ItemTotal.Text, @"[0-9]+(\.[0-9]+)?").Value);

            Assert.Equal(overviewDetails.Total, total);
            Assert.Equal(overviewDetails.Tax, tax);
            Assert.Equal(overviewDetails.ItemTotal, ItemTotal);

        }
        
        [Then(@"'(.*)' notices that his order has been dispatched")]
        public void ThenNoticesThatHisOrderHasBeenDispatched(string persona)
        {
            Assert.True(shoppingCartPage.OrderCompletedContainer.Displayed);

            var header = shoppingCartPage.OrderCompletedContainer.FindElement(By.ClassName("complete-header"));
            var text = shoppingCartPage.OrderCompletedContainer.FindElement(By.ClassName("complete-text"));
            var img = shoppingCartPage.OrderCompletedContainer.FindElement(By.ClassName("pony_express"));

            Assert.True(header.Displayed);
            Assert.Equal("THANK YOU FOR YOUR ORDER", header.Text);
            Assert.True(text.Displayed);
            Assert.Equal("Your order has been dispatched, and will arrive just as fast as the pony can get there!", text.Text);
            Assert.True(img.Displayed);
        }

        [AfterScenario]
        public void TearDown() 
        {
            webDriver.Close();
        }
    }
}
