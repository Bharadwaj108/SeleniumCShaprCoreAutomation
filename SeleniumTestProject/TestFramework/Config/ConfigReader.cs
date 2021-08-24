using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TestFramework.Base;
using TestFramework.Reporter;

namespace TestFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        { 
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false);
            IConfigurationRoot configurationRoot = builder.Build();

            Settings.TestEnvironment = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestEnvironment;
            Settings.AUT = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUT ;
            Settings.Browser = (BrowserType)Enum.Parse(typeof(BrowserType), configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser.ToString(), true);
            Settings.TestType = configurationRoot.GetSection("testSettings").Get<TestSettings>().TestType;
            Settings.IsLog = configurationRoot.GetSection("testSettings").Get<TestSettings>().IsLog; ;
            Settings.LogPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),configurationRoot.GetSection("testSettings").Get<TestSettings>().LogPath);
            Settings.ReportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), configurationRoot.GetSection("testSettings").Get<TestSettings>().ReportPath + @"\Report_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @"\");
            Settings.TestReportTarget = (ReportTarget)Enum.Parse(typeof(ReportTarget),configurationRoot.GetSection("testSettings").Get<TestSettings>().ReportType.ToString(), true);
        }
    }
}
