using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFramework.Base
{
    public static class DriverContext
    {
        private static IWebDriver _driver;
        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }
    }
}
