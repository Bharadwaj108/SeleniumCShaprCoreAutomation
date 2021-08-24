using NUnit.Framework;
using TechTalk.SpecFlow;
using TestFramework.Base;
using TestFramework.Config;
using WebTests.Pages;

namespace WebTests.Steps
{
    [Binding]
    public class ToDoSteps :BaseStep
    {               
        [Given(@"I navigate to the ToDo page")]
        public void NavigateToDoPage()
        {
            DriverContext.Driver.Navigate().GoToUrl(Settings.AUT);
        }

        [Given(@"I add a new to do item ""(.*)"" to the list")]
        public void InputToDo(string toDoItem)
        {
            CurrentPage = GetInstance<ToDoListPage>();
            CurrentPage.As<ToDoListPage>().InputToDoItem(toDoItem);
        }

        [When(@"I click enter button to add to do item")]
        public void AddToDo()
        {
            CurrentPage.As<ToDoListPage>().AddToDoItem();
        }

        [Then(@"The to do item ""(.*)"" should be displayed in the list")]
        public void ValidateToDoItem(string toDoItem)
        {
            bool toDoIsValid = CurrentPage.As<ToDoListPage>().ValidateToDoListItem(toDoItem);
            Assert.IsTrue(toDoIsValid, $"ToDo item {toDoItem} could not be found");
        }

        [Given(@"I add a to do item ""(.*)"" by navigating to the to do page")]
        public void AddToDoItemToList(string toDoItem)
        {
            CurrentPage = GetInstance<ToDoListPage>();
            CurrentPage.As<ToDoListPage>().AddToDoItem(toDoItem);
        }

        [When(@"I check the to do item ""(.*)""")]
        public void SelectTheToDoItem(string toDoItem)
        {
            CurrentPage.As<ToDoListPage>().SelectToDoItem(toDoItem);
        }

        [When(@"I click on ""(.*)"" button")]
        public void ActionToDo(string buttonName)
        {
            CurrentPage.As<ToDoListPage>().ClickOnToDoActionButton(buttonName);
        }

        [Then(@"The to do item ""(.*)"" should be crossed off and radio button checked")]
        public void ItemCrossedOff(string toDoItem)
        {
            bool toDoIsValid = CurrentPage.As<ToDoListPage>().IsToDoItemCrossed(toDoItem);
            Assert.IsTrue(toDoIsValid, $"Completed ToDo item {toDoItem} could not be found");
        }

        [Given(@"I add to do items by navigating to the to do page")]
        public void GivenIAddToDoItemsByNavigatingToTheToDoPage(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Hover on the To Do Item ""(.*)""")]
        public void GivenHoverOnTheToDoItem(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Click on the X button at the right hand side of to do item ""(.*)""")]
        public void WhenClickOnTheXButtonAtTheRightHandSideOfToDoItem(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The to do item ""(.*)"" should be removed from the list")]
        public void ThenTheToDoItemShouldBeRemovedFromTheList(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"To Do Item ""(.*)"" should still exist in the list as active item")]
        public void ThenToDoItemShouldStillExistInTheListAsActiveItem(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I check the to do item ""(.*)""")]
        public void GivenICheckTheToDoItem(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I filter the items by ""(.*)""")]
        public void WhenIFilterTheItemsBy(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The to do items ""(.*)"" should be visible in the list")]
        public void ThenTheToDoItemsShouldBeVisibleInTheList(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The to do items ""(.*)"" should be ""(.*)"" in the list")]
        public void ThenTheToDoItemsShouldBeInTheList(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on Clear Completed")]
        public void WhenIClickOnClearCompleted()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I double click on the to do item ""(.*)""")]
        public void WhenIDoubleClickOnTheToDoItem(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"To do item ""(.*)"" is displayed in a textbox in editable mode")]
        public void ThenToDoItemIsDisplayedInATextboxInEditableMode(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit item to ""(.*)""")]
        public void WhenIEditItemTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }



    }
}
