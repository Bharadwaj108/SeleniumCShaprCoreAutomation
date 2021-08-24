using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TestFramework.Base;
using TestFramework.Config;
using TestFramework.Reporter;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using BrowserStack;
using System.Collections.Generic;
using System;

namespace WebTests.SpecflowHook
{
    [Binding]
    public sealed class TestHooks
    {
        private FeatureContext _featureContext;
        private ScenarioContext _scenarioContext;
        private ReportHelper<ExtentReportManager> _reportHelper;
        private static Local local;
        public TestHooks(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _reportHelper = new ReportHelper<ExtentReportManager>(_featureContext, _scenarioContext);            
        }
        
        public static void ConfigureReport()
        {            
            ReportHelper<ExtentReportManager>.InitializeTestReport();
        }
        
        [BeforeTestRun]
        public static void TestSettings()
        {

            /*
            // creates an instance of Local
            local = new Local();

            // replace <browserstack-accesskey> with your key. You can also set an environment variable - "BROWSERSTACK_ACCESS_KEY".
            List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
              new KeyValuePair<string, string>("key", "wUB6WExyKnrppXpUJqpK"),
            };

            // starts the Local instance with the required arguments
            local.start(bsLocalArgs);

            // check if BrowserStack local instance is running
            Console.WriteLine("Browser Tack Local is running ..." + local.isRunning());     
            
            */

            ConfigReader.SetFrameworkSettings();
            ConfigureReport();
        }

        [AfterTestRun]
        public static void TestRunTearDown()
        {            
            ReportHelper<ExtentReportManager>.FlushReport();
            // stop the Local instance
            //local.stop();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Browser.OpenBrowser(Settings.Browser);
            //Record feature Name and scenario name                     
            ReportHelper<ExtentReportManager>.CreateReport();
        }

        [AfterScenario]
        public void closeBrowser()
        {            
            DriverContext.Driver.Quit();
        }
    
        [AfterStep]
        public void AfterEachStep()
        {            
            ReportHelper<ExtentReportManager>.LogToReport();
        }
    }
}
