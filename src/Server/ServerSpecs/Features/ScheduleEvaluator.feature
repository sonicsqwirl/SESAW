Feature: Schedule Evaluator
	In determine when next to execute a task
	As a developer
	I want to be told what the next execution time should be

#And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' month
#And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' week starting on '1'
#And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' day
#And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' 'hr'

Scenario: Determine the next execution of a default every hour schedule
	Given I have last execute time of '2011-03-09 00:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' 'hr'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-09 01:01:02.000'

Scenario: Determine the next execution of an every 20 minutes schedule
	Given I have last execute time of '2011-03-09 00:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '20' 'mm'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-09 00:21:02.000'

Scenario: Determine the next execution of an every 12 hour schedule
	Given I have last execute time of '2011-03-09 00:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '12' 'hr'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-09 12:01:02.000'

Scenario: Determine the next execution of once a day schedule that runs prior to the normal start time
	Given I have last execute time of '2011-03-09 00:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' day
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-09 02:00:00.000'

Scenario: Determine the next execution of once a day schedule that runs on schedule
	Given I have last execute time of '2011-03-09 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' day
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-10 02:00:00.000'

Scenario: Determine the next execution of once a day schedule that runs at a list times
	Given I have last execute time of '2011-03-09 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' day
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of times '02:00, 12:00, 18:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-09 12:00:00.000'

Scenario: Determine the next execution of once a day schedule that runs at a list times that ran for the last time for the day
	Given I have last execute time of '2011-03-09 18:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' day
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of times '02:00, 12:00, 18:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-10 02:00:00.000'

Scenario: Determine the next execution of an every 2 day schedule that runs at a list times that ran for the last time for the day
	Given I have last execute time of '2011-03-09 18:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '2' day
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of times '02:00, 12:00, 18:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-11 02:00:00.000'

Scenario: Determine the next execution of an every 2 day schedule that runs at a list times
	Given I have last execute time of '2011-03-09 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '2' day
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of times '02:00, 12:00, 18:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-09 12:00:00.000'
	
Scenario: Determine the next execution of list of days schedule that runs on schedule
	Given I have last execute time of '2011-03-01 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of days '1,10,20,0'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-10 02:00:00.000'

Scenario: Determine the next execution of list of days schedule that runs on schedule for the last day of the month
	Given I have last execute time of '2011-03-31 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of days '1,10,20,0'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-04-01 02:00:00.000'

Scenario: Determine the next execution of list of days schedule that runs on schedule and should run on the last day of the month
	Given I have last execute time of '2011-03-20 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of days '1,10,20,0'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-31 02:00:00.000'