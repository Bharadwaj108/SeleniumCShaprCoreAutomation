using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Config;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework.Base
{
    public abstract class TestInitializeHook
    {
        private BrowserType BrowserType;
        public TestInitializeHook(BrowserType browser) => BrowserType = browser;
        public void InitializeTestSettings()
        {
            //Set up the test settings
            ConfigReader.SetFrameworkSettings();

            //Set up the test browser and open it
            ConfigureBrowser(BrowserType);

        }

        public void ConfigureBrowser(BrowserType browser)
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
