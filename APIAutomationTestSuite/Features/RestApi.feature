Feature: RestApiSteps


Scenario: Get API reponse using given endpoint
	Given I have an endpint /users/
	When I call get method of api
	Then I get API response with list of users


Scenario: New User Registration
Given I have an endpint /register/
When I call post user infromation using details
| email                  |  | password |
| george.bluth@reqres.in |  | George  |
Then I will get user information with email, password and token


Scenario: New User Registration with email
Given I have an endpint /register/
When I call post user infromation using details
| email                  | password |
| george.bluth@reqres.in |          |
Then I will get error


