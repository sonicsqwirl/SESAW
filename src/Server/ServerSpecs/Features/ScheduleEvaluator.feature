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

Scenario: Determine the next execution or schedule by list of week days that runs on schedule
	Given I have last execute time of '2011-03-21 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of weekdays '1,2,3' with a weekly interval of '1'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-22 02:00:00.000'

Scenario: Determine the next execution or schedule by list of week days that runs on schedule and skips days
	Given I have last execute time of '2011-03-21 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of weekdays '1,4,7' with a weekly interval of '1'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-24 02:00:00.000'

Scenario: Determine the next execution or schedule by list of week days that runs on schedule and runs on the last weekday in the list
	Given I have last execute time of '2011-03-19 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of weekdays '4,6' with a weekly interval of '1'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-24 02:00:00.000'
	
Scenario: Determine the next execution or schedule by list of week days that runs on schedule and skips days with skip a week
	Given I have last execute time of '2011-03-19 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of weekdays '4,6' with a weekly interval of '2'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-03-31 02:00:00.000'
		
Scenario: Determine the next execution or schedule by list of week days that runs on schedule and skips days with skip a large week interval
	Given I have last execute time of '2011-03-19 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of weekdays '4,6' with a weekly interval of '8'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-05-12 02:00:00.000'

Scenario: Determine the next execution of once a day schedule that runs at a single time for a specified month
	Given I have last execute time of '2011-03-31 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
  And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of months '3,5,12'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' day
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of times '02:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-05-01 02:00:00.000'

Scenario: Determine the next execution of once a day schedule that runs at a single time for a specified month of february
	Given I have last execute time of '2011-05-31 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
  And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of months '2,5'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' day
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of times '02:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2012-02-01 02:00:00.000'

Scenario: Determine the next execution of a list of days schedule that runs at a single time for a specified list of months that calculates the last day
	Given I have last execute time of '2011-01-31 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
  And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of months '1,2'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of days '0'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of times '02:00'
	When I get the next execution date for the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then I should have an execution date of '2011-02-28 02:00:00.000'

Scenario: Determine the next 10 executions of a default every hour schedule
	Given I have last execute time of '2011-03-09 00:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs every '1' 'hr'
	When I get the next execution date for the next '10' schedules with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then for run number '0' I should have an execution date of '2011-03-09 01:01:02.000'
	Then for run number '1' I should have an execution date of '2011-03-09 02:01:02.000'
	Then for run number '2' I should have an execution date of '2011-03-09 03:01:02.000'
	Then for run number '3' I should have an execution date of '2011-03-09 04:01:02.000'
	Then for run number '4' I should have an execution date of '2011-03-09 05:01:02.000'
	Then for run number '5' I should have an execution date of '2011-03-09 06:01:02.000'
	Then for run number '6' I should have an execution date of '2011-03-09 07:01:02.000'
	Then for run number '7' I should have an execution date of '2011-03-09 08:01:02.000'
	Then for run number '8' I should have an execution date of '2011-03-09 09:01:02.000'
	Then for run number '9' I should have an execution date of '2011-03-09 10:01:02.000'

Scenario: Determine the next 10 executions of schedule by list of week days that runs on schedule and skips days
	Given I have last execute time of '2011-03-21 02:01:02.000'
	And I have a schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at this list of weekdays '1,4,6' with a weekly interval of '1'
	And the schedule with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A' runs at the specific time of '02:00:00'
	When I get the next execution date for the next '10' schedules with the id of '1FF02F94-ED9C-43D4-B5DD-96C13C6C607A'
	Then for run number '0' I should have an execution date of '2011-03-24 02:00:00.000'
	Then for run number '1' I should have an execution date of '2011-03-26 02:00:00.000'
	Then for run number '2' I should have an execution date of '2011-03-28 02:00:00.000'
	Then for run number '3' I should have an execution date of '2011-03-31 02:00:00.000'
	Then for run number '4' I should have an execution date of '2011-04-02 02:00:00.000'
	Then for run number '5' I should have an execution date of '2011-04-04 02:00:00.000'
	Then for run number '6' I should have an execution date of '2011-04-07 02:00:00.000'
	Then for run number '7' I should have an execution date of '2011-04-09 02:00:00.000'
	Then for run number '8' I should have an execution date of '2011-04-11 02:00:00.000'
	Then for run number '9' I should have an execution date of '2011-04-14 02:00:00.000'

