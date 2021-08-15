using TechTalk.SpecFlow;
using TQP.QA.Automation.UI.Test.Pages;

namespace TQP.QA.Automation.UI.Test.Features
{
    [Binding]
    public class NavigateToSteps
    {
        private readonly NavigateToPage _navigateToPage;
        private readonly ScenarioContext _scenarioContext;

        public NavigateToSteps(
            ScenarioContext scenarioContext,
            NavigateToPage navigateToPage)
        {
            _scenarioContext = scenarioContext;
            _navigateToPage = navigateToPage;
        }

        

        [Given(@"I am on the home page for (.*)")]
        public void GivenIAmOnTheHomePageFor(string environment)
        {
            _navigateToPage.Navigate();
        }

        [When(@"I navigate to (.*)")]
        public void WhenINavigateTo(string url)
        {
            _navigateToPage.navigateToLink(url);
        }

        [Then(@"I should see title (.*)")]
        public void ThenIShouldSeeTitle(string title)
        {
            string currentTitel = _navigateToPage.getWindowTitle();
            System.Console.WriteLine("Current Title" + currentTitel);
        }

        [Then(@"I validate UI with previous version of (.*) and (.*)")]
        public void ThenIValidateUIWithPreviousVersion(string environment, string url)
        {
            _navigateToPage.validateUIWithPreviousVerison(environment, url);
        }
    }
}
