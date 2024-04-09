Feature: Create Business Case
create a new business using the API interface


 
Scenario: create a new business case with a valid inputs using API
	Given business case payload "CreateBusiness.json"
	When send API request to create Business Case
	Then validate business case is created



Scenario: get business case by id
	Given I have entered into the calculator