using System;
using System.Reflection;
using TechTalk.SpecFlow;
using TestFramework.Config;

namespace TestFramework.Reporter
{
    public class ReportHelper<T>
    {
        public static T reportManager;
        public static FeatureContext SpecFlowFeatureContext { get; set; }
        public static ScenarioContext SpecFlowScenarioContext { get; set; }

        public ReportHelper(FeatureContext featureCxt, ScenarioContext scenarioCxt)
        {
            SpecFlowFeatureContext = featureCxt;
            SpecFlowScenarioContext = scenarioCxt;
        }

        public static void InitializeTestReport()
        {
            reportManager = (T)Activator.CreateInstance(typeof(T),new object[] { Settings.ReportPath});
            var type = reportManager.GetType();
            var method = type.GetMethod("ConfigureReport");
            method.Invoke(reportManager, new object[] { Settings.ReportPath});
        }

        public static void CreateReport()
        {            
            var type = reportManager.GetType();
            var method = type.GetMethod("CaptureNodes");
            method.Invoke(reportManager, new object[] { SpecFlowFeatureContext , SpecFlowScenarioContext });
        }
    
        public static void LogToReport()
        {
            var type = reportManager.GetType();
            var method = type.GetMethod("LogToReport");
            method.Invoke(reportManager, new object[] { });
        }

        public static void FlushReport()
        {
            var type = reportManager.GetType();
            var method = type.GetMethod("FlushReport");
            method.Invoke(reportManager, new object[] { });
        }
    }
}
