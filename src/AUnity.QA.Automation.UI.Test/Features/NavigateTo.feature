Feature: Australian Unity
    Navigating and validating UI

   Scenario Outline: Navigate and Validate UI
      Given I am on the home page for <environment>
      When I navigate to <url>
      Then I should see title <text>
      And I validate UI with previous version of <environment> and <url>
  
  Examples:
    | environment | url    | text |
    | production      | banking/bankaccounts |   Bank Accounts   |
    | production      | banking/home-loans |   Home Loans   |
