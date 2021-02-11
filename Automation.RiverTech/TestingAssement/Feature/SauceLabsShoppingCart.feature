@UI
@Browser:Chrome
@Meduim
Feature: Shopping Cart
	Simple demo of the user using the shopping cart.

@ShoppingCartFeature
Scenario: User using the shopping cart
	Given that 'peter' is on 'https://www.saucedemo.com/'
	And 'peter' is logged in
	When 'peter' adds 'Sauce Labs Fleece Jacket' into the cart
	And 'peter' clicks on the cart icon and is navigated to it
	Then 'Sauce Labs Fleece Jacket' is in 'peter' cart
	When 'peter' clicks on checkout
	And 'peter' enters his shipping details:
	| FirstName | LastName | ZipCode |
	| Peter     | Smith    | 5785758 |
	Then the overall page displayed the following:
	| ItemTotal | Tax  | Total |
	| 49.99     | 4.00 | 53.99 |
	When 'peter' clicks on finish
	Then 'peter' notices that his order has been dispatched