Feature: Page check
	In order to check if expected text is displayed on webpage
	as a user
	I want Sing in text to be loaded for less than 10 seconds

Scenario: Page check
	Given I navigato to website
	Then Expected text 'Sign in' will appear on page for less than '10' seconds
