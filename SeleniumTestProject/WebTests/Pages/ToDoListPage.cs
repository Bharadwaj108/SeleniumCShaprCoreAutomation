using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TestFramework.Base;
using TestFramework.Config;
using TestFramework.Extensions;

namespace WebTests.Pages
{
    public class ToDoListPage : BasePage
    {
        private IWebElement _lblToDo(string labelText) => DriverContext.Driver.WaitUntilElementIsReady(By.XPath($"//label[contains(text(),'{labelText}')]"), 2000, 500, $"Unable to locate the ToDo item {labelText}");
        private IWebElement _textToDo => DriverContext.Driver.WaitUntilElementIsReady(By.XPath("//input[@placeholder='What needs to be done?']"), 10000, 1000, "Unable to locate the ToDo text box");
        private IWebElement _actionButton(string buttonName) => DriverContext.Driver.FindElement(By.XPath($"//a[text()='{buttonName}']"));
        private IWebElement _completedListItem(string labelText) => DriverContext.Driver.WaitUntilElementIsReady(By.XPath($"//li[@class='completed']//label[text()='{labelText}']"), 2000, 500, $"Unable to locate the completed ToDo item {labelText}");
        
        internal void InputToDoItem(string toDoItem)
        {
            _textToDo.SendKeys(toDoItem);            
        }

        internal void AddToDoItem()
        {
            //press enter to add the list item
            _textToDo.SendKeys(Keys.Enter);
        }

        internal bool ValidateToDoListItem(string expectedToDoItem)
        {
            bool flag = true;
            try
            {
                IWebElement actualToDo = this._lblToDo(expectedToDoItem);
                if (actualToDo == null)
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            
            return flag;
        }
    
        internal void AddToDoItem(string toDoItem)
        {
            DriverContext.Driver.Navigate().GoToUrl(Settings.AUT);
            this.InputToDoItem(toDoItem);
            this.AddToDoItem();
        }

        internal void SelectToDoItem(string toDoItem)
        {
            IWebElement toDoItemLabel = this._lblToDo(toDoItem);
            IWebElement toDoItemDiv = toDoItemLabel.FindElement(By.XPath(".."));
            IWebElement toDoItemRadioButton = toDoItemDiv.FindElement(By.XPath("//input[@type='checkbox' and @class='toggle']"));
            toDoItemRadioButton.Click();
        }

        internal void ClickOnToDoActionButton(string buttonName)
        {
            _actionButton(buttonName).Click();
        }

        internal bool IsToDoItemCrossed(string crossedToDoItem)
        {
            bool flag = true;
            try
            {
                IWebElement actualCrossedToDo = this._completedListItem(crossedToDoItem);
                if (actualCrossedToDo == null)
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                return false;
            }

            return flag;
        }
    }
}
