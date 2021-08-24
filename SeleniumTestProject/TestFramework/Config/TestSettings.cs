using Newtonsoft.Json;
using TestFramework.Base;
using TestFramework.Reporter;

namespace TestFramework.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("testEnvironment")]
        public string TestEnvironment { get; set; }

        [JsonProperty("aut")]
        public string AUT { get; set; }

        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }

        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("isLog")]
        public string IsLog { get; set; }

        [JsonProperty("logPath")]
        public string LogPath { get; set; }

        [JsonProperty("reportPath")]
        public string ReportPath { get; set; }

        [JsonProperty("reportTarget")]
        public ReportTarget ReportType { get; set; }
    }
}
