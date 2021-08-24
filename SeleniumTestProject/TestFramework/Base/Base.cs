using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace TestFramework.Base
{
    public class Base
    {        
        public BasePage CurrentPage
        {
            get
            {
                return (BasePage)ScenarioContext.Current["currentPage"];
                //return (BasePage)BasePage._scenarioContext["currentPage"];
            }
            set
            {
                //BasePage._scenarioContext["currentPage"] = value;
                ScenarioContext.Current["currentPage"] = value;
            }           
        }
        
        private IWebDriver _driver;

        public TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
