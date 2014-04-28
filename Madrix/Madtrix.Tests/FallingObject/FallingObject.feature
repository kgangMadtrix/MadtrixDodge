Feature: Create FallingObject
	In order to create rain drops
	As a system
	I want to create a falling object

@FallingObjects
Scenario: Create a raindrop
	Given I have a falling object factory
	When I create a raindrop
	Then the result should be a rain drop on the screen
