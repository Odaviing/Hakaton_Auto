Feature: Authorization and sending the letter
	As a user
	I want to sign in my account
	In order to get access to my email

	As a user
	I want to send the letter to myself
	In order to save important information as a letter

	As a user
	I want to open the letter
	In order to check it's content

Background: 
	Given user is on the homepage
	When user enters "Odaviing" into Login field
	And user enters "theelderscrolls5" into Password field
	And user clicks on Sign in button

Scenario: Sign in email account
	Then user is on the Incoming letters page

Scenario Outline: Send the letter
	Then user is on the Incoming letters page
	When user clicks on the Create letter link
	Then user is on the letter creation page
	When user enters "odaviing@i.ua" into Recipient field
	And user enters '<Theme>' into Subject field
	And user enters '<Text>' into content textbox
	And user clicks Send button
	Then user on the sending confirmation page
	When user clicks on the Letters link
	Then user is on the Incoming letters page
	And user sees the new letter

Examples: 
| Theme | Text |
| test1 | 123  |
| test2 | 345  |
| test3 | 678  |

Scenario: Check the content of the letters
	Then user is on the Incoming letters page
	When user clicks on the letter
	Then user is on the page with the letter's content
	And user sees the text in the letter
