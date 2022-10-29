Feature: Compare Bournemouth's tomorrow's temperature

Scenario: User can log in with valid credentials
	Given the user is on BBC Weather page
	And he types in Bournemouth into the search field
	When he clicks search 
	Then he navigates to Bournemouth's weather results page
	And he varifies high and low temperatures for the following day