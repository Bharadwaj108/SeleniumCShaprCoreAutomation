using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;
using TestFramework.Base;

namespace TestFramework.Reporter
{
    public class ExtentReportManager
    {
        public ExtentHtmlReporter ExtentHtmlReporter { get; set; } = null;
        public ExtentReports ExtentReport { get; set; }
        private ExtentTest FeatureName { get; set; }
        private ExtentTest CurrentScenarioName { get; set; }
        private FeatureContext SpecFlowFeatureContext { get; set; }
        private ScenarioContext SpecFlowScenarioContext { get; set; }
        private string _reportLocation;

        public ExtentReportManager(string reportPath)
        {            
            _reportLocation = reportPath;
        }

        public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        }

        public void ConfigureReport(string reportfolderLocation)
        {
            if (!Directory.Exists(reportfolderLocation))
            {
                Directory.CreateDirectory(reportfolderLocation);
            }
            string htmlReport = Path.Combine(reportfolderLocation, "TestReport.html");
            ExtentHtmlReporter = new ExtentHtmlReporter(htmlReport);
            ExtentHtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            ExtentHtmlReporter.Config.DocumentTitle = "Test Automation Report";
            ExtentHtmlReporter.Config.ReportName = "Test Automation Report";
            ExtentReport = new ExtentReports();
            ExtentReport.AttachReporter(ExtentHtmlReporter);
        }

        public void CaptureNodes(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            SpecFlowFeatureContext = featureContext;
            SpecFlowScenarioContext = scenarioContext;

            FeatureName =  ExtentReport.CreateTest<Feature>(SpecFlowFeatureContext.FeatureInfo.Title);
            CurrentScenarioName = FeatureName.CreateNode<Scenario>(SpecFlowScenarioContext.ScenarioInfo.Title);
        }

        public void LogToReport()
        {
            var stepType = SpecFlowScenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            if (SpecFlowScenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    CurrentScenarioName.CreateNode<Given>(SpecFlowScenarioContext.StepContext.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    CurrentScenarioName.CreateNode<When>(SpecFlowScenarioContext.StepContext.StepInfo.Text);
                }
                else if (stepType == "Then")
                {
                    CurrentScenarioName.CreateNode<Then>(SpecFlowScenarioContext.StepContext.StepInfo.Text);
                }
                else if (stepType == "And")
                {
                    CurrentScenarioName.CreateNode<And>(SpecFlowScenarioContext.StepContext.StepInfo.Text);
                }
            }
            else if (SpecFlowScenarioContext.TestError != null) //in case of scenario failure
            {
                var mediaEntity = CaptureScreenshotAndReturnModel(SpecFlowScenarioContext.ScenarioInfo.Title.Trim());
                if (stepType == "Given")
                    CurrentScenarioName.CreateNode<Given>(SpecFlowScenarioContext.StepContext.StepInfo.Text).Fail(SpecFlowScenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "When")
                    CurrentScenarioName.CreateNode<When>(SpecFlowScenarioContext.StepContext.StepInfo.Text).Fail(SpecFlowScenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "Then")
                    CurrentScenarioName.CreateNode<Then>(SpecFlowScenarioContext.StepContext.StepInfo.Text).Fail(SpecFlowScenarioContext.TestError.Message, mediaEntity);
            }
            else if (SpecFlowScenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    CurrentScenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    CurrentScenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    CurrentScenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }
        }
    
        public void FlushReport()
        {
            ExtentReport.Flush();
        }
    }
}
