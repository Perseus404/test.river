@UserApi
@Medium
Feature: User api
	To ensure that the user api endpoint work as they are intended to.

@RetrievingDataOfAParticlarUser
Scenario: Retrieving data of a particular user
	When 'Users/1' endpoint is invoked 
	Then the http status code for 'Users/1' endpoint was '200'
	And the details for 'Users/1' were correct
	## do not like the above assertion as is very ambigous

@RetrievingDataOfAParticlarUserUsingTables
Scenario: Retrieving data of a particular user using tables
	When 'Users/1' endpoint is invoked 
	Then the http status code for 'Users/1' endpoint was '200'
	And the details for 'Users/1' were the following:
	| id | name          | username | email             | street      | suite    | city        | zipcode    | lat      | lng     | phone                 | website       | companyName     | catchPhrase                            | bs                          |
	| 1  | Leanne Graham | Bret     | Sincere@april.biz | Kulas Light | Apt. 556 | Gwenborough | 92998-3874 | -37.3159 | 81.1496 | 1-770-736-8031 x56442 | hildegard.org | Romaguera-Crona | Multi-layered client-server neural-net | harness real-time e-markets |