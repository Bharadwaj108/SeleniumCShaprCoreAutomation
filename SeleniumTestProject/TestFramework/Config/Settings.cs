using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Base;
using TestFramework.Reporter;

namespace TestFramework.Config
{
    public class Settings
    {
        public static string TestEnvironment { get; set; }
        public static string AUT { get; set; }
        public static BrowserType Browser { get; set; }
        public static string TestType { get; set; }
        public static string IsLog { get; set; }
        public static string LogPath { get; set; }                
        public static string ReportPath { get; set; }
        public static ReportTarget TestReportTarget { get; set; }


    }
}
