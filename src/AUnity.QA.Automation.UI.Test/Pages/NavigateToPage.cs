using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using TQP.QA.Automation.Shared;
using TQP.QA.Automation.UI.Core;

namespace TQP.QA.Automation.UI.Test.Pages
{
    public class NavigateToPage : PageBase
    {
        public NavigateToPage(BrowserDriverManager browserDriverManager, IOptions<AppSettings> appSettings) 
            : base(browserDriverManager, appSettings) { }

        

        private NavigationPageResult ResultPage
            => new NavigationPageResult(BrowserDriver);

        public void Navigate()
            => BrowserDriver.Navigate();

        
        public void navigateToLink(string url)
           => ResultPage.navigateToLink(url);

        public string getWindowTitle()
           => ResultPage.getWindowTitle();


      
        public void validateUIWithPreviousVerison(string environment, string url)
            => ResultPage.validateUIWithPreviousVerison(environment, url);

    }
}
