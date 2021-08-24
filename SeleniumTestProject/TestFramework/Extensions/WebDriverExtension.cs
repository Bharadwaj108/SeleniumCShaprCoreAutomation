using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFramework.Extensions
{
    public static class WebDriverExtension
    {
        public static IWebElement WaitUntilElementIsReady(this IWebDriver driver, By by, int waitTimeInMs = 30000, int pollingIntervalInMs = 1000, string errorMessage = "Unable to click on the element")
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromMilliseconds(waitTimeInMs);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalInMs);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = errorMessage;
            fluentWait.Until(condition =>
            {
                try
                {
                    IWebElement element = driver.FindElement(by);
                    return element.Displayed && element.Enabled;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return driver.FindElement(by);
        }

    }
}
