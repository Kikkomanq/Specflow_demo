Feature: Page check
	In order to check if expected text is displayed on webpage
	as a user
	I want Sing in text to be loaded for less than 10 seconds

	#Idea was to check for Sign in text on Yahoo home page, for load time of 10 sec
	#Two parameters you mentioned in the task, text and load time, were passed from Then condition

Scenario: Page check
	Given I navigato to website
	Then Expected text 'Sign in' will appear on page for less than '10' seconds
