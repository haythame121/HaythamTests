Feature: Use the website to find restaurants
 		So that I can order food
 		As a hungry customer
 		I want to be able to find restaurants in my area


Scenario Outline: (Positive Scenario) Search for restaurant(s) in an area
 		Given I want food in <postcode>
 		When I search for <restaurants>
 		Then I should see some <restaurants> in <postcode>

Examples:
| restaurants | postcode |
|             | AR51 1AA |
| Papa Johns  | AR51 1AA |


Scenario Outline: (Negative Scenario) Unable to search for restaurant(s) in an area
 		Given I want food in <postcode>
 		When I search for <restaurants>
 		Then I shouldn't see the <restaurants> and I see the <errorMessage>

Examples:
| restaurants        | postcode | errorMessage   |
| Unknown-Restaurant | AR51 1AA | No match found |


Scenario Outline: Unable to search in an area using invalid values
 		Given I want food in <postcode>
 		When I search for <invalidValues>
 		Then I shouldn't see the <invalidValues> and I see the <errorMessage>

Examples:
| invalidValues | postcode | errorMessage   |
| £$$£$         | AR51 1AA | No match found |
| 09098         | AR51 1AA | No match found |


Scenario Outline: (Positive Scenario) Search for restaurant(s) through 'Change Location'
 		Given I want food in <postcode>
 		When I search for <restaurants>
 		And I change the area to <secondPostcode> using the 'Change Location' button
		And I search for <restaurants>
		Then I should see some <restaurants> in <secondPostcode>

Examples:
| restaurants  | postcode | secondPostcode |
|              | AR51 1AA | W3 7JL         |
| Adams Lounge | AR51 1AA | W3 7JL         |
| Hot Bread    | AR51 1AA | W3 7JL         |


Scenario Outline: (Negative Scenario) Unable to search for restaurant(s) through 'Change Location'
 		Given I want food in <postcode>
 		When I search for <restaurants>
 		And I change the area to <secondPostcode> using the 'Change Location' button
		And I search for <restaurants>
		Then I shouldn't see the <restaurants> and I see the <errorMessage>

Examples:
| restaurants        | postcode | secondPostcode | errorMessage   |
| Unknown-Restaurant | AR51 1AA | W3 7JL         | No match found |


Scenario Outline: Unable to search through 'Change Location' using invalid values
 		Given I want food in <postcode>
 		When I search for <invalidValues>
 		And I change the area to <secondPostcode> using the 'Change Location' button
		And I search for <invalidValues>
		Then I shouldn't see the <invalidValues> and I see the <errorMessage>

Examples:
| invalidValues | postcode | secondPostcode | errorMessage   |
| £$$£$         | AR51 1AA | W3 7JL         | No match found |
| 09098         | AR51 1AA | W3 7JL         | No match found |