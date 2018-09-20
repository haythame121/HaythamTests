Feature: Use the website to find restaurants
 		So that I can order food
 		As a hungry customer
 		I want to be able to find restaurants in my area

Scenario Outline: (Positive Scenario) Search for restaurant(s) in an area
 		Given I want food in AR51 1AA
 		When I search for <restaurants>
 		Then I should see some <restaurants> in AR51 1AA

Examples:
| restaurants      |
| Domino's         |
| Papa Johns       |
| Frankie & Bennys |

Scenario Outline: (Negative Scenario) Unable to search for restaurant(s) in an area
 		Given I want food in AR51 1AA
 		When I search for <restaurants>
 		Then I shouldn't see the <restaurants> and I see the following <errorMessage>

Examples:
| restaurants | errorMessage   |
| Nando's     | No match found |