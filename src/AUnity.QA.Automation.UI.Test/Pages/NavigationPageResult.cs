using OpenQA.Selenium;
using TQP.QA.Automation.UI.Core;
using Applitools;
using Applitools.Selenium;
using Applitools.VisualGrid;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using Configuration = Applitools.Selenium.Configuration;
using ScreenOrientation = Applitools.VisualGrid.ScreenOrientation;
using TQP.QA.Automation.UI.Core.Extensions;

namespace TQP.QA.Automation.UI.Test.Pages
{
    public class NavigationPageResult : PageBase
    {
        private EyesRunner runner;
        private Eyes eyes;
        public NavigationPageResult(BrowserDriver browserDriver) 
            : base(browserDriver) { }

        private IWebElement SearchResultsWrapper
            => WebDriver.WaitAndFindElement(By.Id("search"));

        
        public void EyesCheck(string ennvironment, string url)
        {
            System.Console.WriteLine("Start of Applitools");
            VisualGridRunner runner = new VisualGridRunner(10);
            Eyes eyes = new Eyes(runner);
            Configuration config = new Configuration();

            config.SetApiKey("5WvTsk4pOFOh8kgm9vEavnM58zHwN8REbTR102fOsSQdA110");

            config.SetBatch(new BatchInfo("Ultrafast Batch" + url));

            // Add browsers with different viewports
            config.AddBrowser(800, 600, BrowserType.CHROME);
            config.AddBrowser(700, 500, BrowserType.FIREFOX);
            config.AddBrowser(1600, 1200, BrowserType.IE_11);
            config.AddBrowser(1024, 768, BrowserType.EDGE_CHROMIUM);
            config.AddBrowser(800, 600, BrowserType.SAFARI);

            // Add mobile emulation devices in Portrait mode
            config.AddDeviceEmulation(DeviceName.iPhone_X, ScreenOrientation.Portrait);
            config.AddDeviceEmulation(DeviceName.Pixel_2, ScreenOrientation.Portrait);

            // Set the configuration object to eyes
            eyes.SetConfiguration(config);

            eyes.Open(WebDriver, "Australian Unity", url, new Size(1024, 800));
            System.Console.WriteLine("After Eyes Open");
            eyes.Check(Target.Window().Fully().WithName(url));
            System.Console.WriteLine("After Eyes Check");
            eyes.CloseAsync();
            System.Console.WriteLine("After Eyes Close");
            TestResultsSummary allTestResults = runner.GetAllTestResults(false);
            System.Console.WriteLine(allTestResults);

        }

        public void navigateToLink(string url)
        {
            System.Console.WriteLine("URL here is " + url);
            string currentURL = WebDriver.Url;
            System.Console.WriteLine("currentURL" + currentURL);
            // WebDriver.Navigate().GoToUrl(currentURL + "banking/home-loans");
            WebDriver.Navigate().GoToUrl(currentURL + url);
        }

        public string getWindowTitle()
        {
            return WebDriver.Title;
        }

       
        public void validateUIWithPreviousVerison(string environment, string url)
        {
            EyesCheck(environment, url);
        }
    }
}
