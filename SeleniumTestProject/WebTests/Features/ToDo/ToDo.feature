@regression 
Feature: Test ToDo Functionality
	This feature is intended to test the functionality of a ToDo list
	The following features will be tested
	- Add new to do item
	- Complete to do item
	- Clear Completed Item
	- Remove or delete to do item
	- Filter to do items by "All"
	- Filter to do items by "Active"
	- Filter to do items by "Completed"
	- Double click on to do item to edit it

@AddToDoItem @automated
Scenario: Add a single new to do item to the list
	Given I navigate to the ToDo page
	And I add a new to do item "NewToDoItem1" to the list 
	When I click enter button to add to do item
	Then The to do item "NewToDoItem1" should be displayed in the list

@CompleteToDoItem @automated
Scenario: Complete added to do item
	Given I add a to do item "CompleteToDoItem1" by navigating to the to do page
	When I check the to do item "CompleteToDoItem1"		
	Then The to do item "CompleteToDoItem1" should be crossed off and radio button checked

@RemoveToDoItem @manual
Scenario: Delete to do item
	Given I add to do items by navigating to the to do page
	| Items             |
	| "RemoveToDoItem1" |
	| "ToDoItem2"       |
	And Hover on the To Do Item "RemoveToDoItem1"
	When Click on the X button at the right hand side of to do item "RemoveToDoItem1"		
	Then The to do item "RemoveToDoItem1" should be removed from the list
	And To Do Item "ToDoItem2" should still exist in the list as active item

@FilterToDoItem @manual
Scenario: Filter to do item by All
	Given I add to do items by navigating to the to do page
	| Items               |
	| "CompleteToDoItem1" |
	| "ActiveToDoItem1"   |	
	And I check the to do item "CompleteToDoItem1"		
	When I filter the items by "All"
	Then The to do items "CompleteToDoItem1,ActiveToDoItem1" should be visible in the list

@FilterToDoItem @manual
Scenario: Filter to do item by Active
	Given I add to do items by navigating to the to do page
	| Items               |
	| "CompleteToDoItem1" |
	| "ActiveToDoItem1"   |
	| "ActiveToDoItem2"   |
	And I check the to do item "CompleteToDoItem1"		
	When I filter the items by "Active"
	Then The to do items "ActiveToDoItem1,ActiveToDoItem2" should be "visible" in the list
	And The to do items "CompleteToDoItem1" should be "hidden" in the list

@FilterToDoItem @manual
Scenario: Filter to do item by Completed
	Given I add to do items by navigating to the to do page
	| Items               |
	| "CompleteToDoItem1" |
	| "CompleteToDoItem2" |
	| "ActiveToDoItem1"   |
	| "ActiveToDoItem2"   |
	And I check the to do item "CompleteToDoItem1"	
	And I check the to do item "CompleteToDoItem2"	
	When I filter the items by "Completed"
	Then The to do items "CompleteToDoItem1,CompleteToDoItem2" should be "visible" in the list
	And The to do items "ActiveToDoItem1,ActiveToDoItem2" should be "hidden" in the list

@ClearCompleted @manual
Scenario: Clear completed to do item
	Given I add to do items by navigating to the to do page
	| Items                 |
	| "ClearCompletedItem1" |
	| "ActiveToDoItem1"     |
	| "ActiveToDoItem2"     |
	When I check the to do item "ClearCompletedItem1"		
	Then The to do item "ClearCompletedItem1" should be crossed off and radio button checked
	When I click on Clear Completed 
	Then The to do items "ClearCompletedItem1" should be "removed" in the list
	And The to do items "ActiveToDoItem1,ActiveToDoItem2" should be "visible" in the list

Scenario: Edit to do item
	Given I add to do items by navigating to the to do page
	| Items             |
	| "BeforeEditItem1" |	
	When I double click on the to do item "BeforeEditItem1"			
	Then To do item "BeforeEditItem1" is displayed in a textbox in editable mode
	When I edit item to "AfterEditItem1"
	And I click enter button to add to do item
	Then The to do item "AfterEditItem1" should be displayed in the list
	And The to do items "BeforeEditItem1" should be "removed" in the list

	



	
	