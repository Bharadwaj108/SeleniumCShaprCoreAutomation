using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework.Base
{
    public class Browser
    {
        public static void OpenBrowser(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.IE:
                    break;
                case BrowserType.Chrome:
                    //ToDo : Read the ChromeOptions as part of the Test Settings for centralized control
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("start-maximized");
                    options.AddArguments("--disable-gpu");
                    options.AddAdditionalCapability("browserstack.user", "bradpappu_4KEkoR", true);
                    options.AddAdditionalCapability("browserstack.key", "wUB6WExyKnrppXpUJqpK", true);
                    options.AddAdditionalCapability("browserstack.local", "true", true);
                    options.AddAdditionalCapability("os", "Windows", true);
                    options.AddAdditionalCapability("os_version", "10", true);
                    options.AddAdditionalCapability("browser", "Chrome", true);
                    //options.AddAdditionalCapability("browser_version", "latest", true);
                    options.AddAdditionalCapability("browserstack.debug", "true", true);  // for enabling visual logs
                    options.AddAdditionalCapability("browserstack.console", "info", true);  // to enable console logs at the info level. You can also use other log levels here
                    options.AddAdditionalCapability("browserstack.networkLogs", "true", true);  // to enable network logs to be logged
                    //options.AddArguments("-headless");
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    DriverContext.Driver = new ChromeDriver(options);                    
                    break;
                case BrowserType.Firefox:
                    break;
                case BrowserType.Safari:
                    break;
                default:
                    break;
            }           
        }
    
    }
}
