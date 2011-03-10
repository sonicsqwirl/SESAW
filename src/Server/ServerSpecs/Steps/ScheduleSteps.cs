using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SESAW.Domain;

namespace ServerSpecs.Steps
{
	[Binding]
	public class ScheduleSteps
	{
		//private Schedule schedule;

		//[BeforeScenario]
		//public void Setup() {
		//  schedule = new Schedule();
		//  ScenarioContext.Current.Set(schedule);
		//}

		[Given(@"I have a schedule with the id of '(.*)'")]
		public void b(string scheduleId) {
			var schedule = new Schedule { Id = new Guid(scheduleId) };
			ScenarioContext.Current.Set(schedule, scheduleId);
		}

		[Given(@"the schedule with the id of '(.*)' runs every '(.*)' month")]
		public void c(string scheduleId, string months) {
			var schedule = ScenarioContext.Current.Get<Schedule>(scheduleId);
			schedule.MonthSegment = new MonthScheduleSegment { AssignedValue = months, ScheduleType = ScheduleMonthType.Consecutive };

			ScenarioContext.Current.Set(schedule, scheduleId);
		}

		[Given(@"the schedule with the id of '(.*)' runs every '(.*)' week starting on '(.*)'")]
		public void d(string scheduleId, string weeks, int startDate) {
			var schedule = ScenarioContext.Current.Get<Schedule>(scheduleId);
			schedule.WeekSegment = new WeekScheduleSegment { AssignedValue = weeks, ScheduleType = ScheduleWeekType.Consecutive, AssignedValueQualifier=startDate };

			ScenarioContext.Current.Set(schedule, scheduleId);
		}

		[Given(@"the schedule with the id of '(.*)' runs every '(.*)' day")]
		public void e(string scheduleId, string days) {
			var schedule = ScenarioContext.Current.Get<Schedule>(scheduleId);
			schedule.DaySegment = new DayScheduleSegment { AssignedValue = days, ScheduleType = ScheduleDayType.Consecutive };

			ScenarioContext.Current.Set(schedule, scheduleId);
		}

		[Given(@"the schedule with the id of '(.*)' runs every '(.*)' '(.*)'")]
		public void f(string scheduleId, string hours, string qualifier) {
			var schedule = ScenarioContext.Current.Get<Schedule>(scheduleId);
			schedule.TimeSegment = new TimeScheduleSegment { AssignedValue = hours, ScheduleType = ScheduleTimeType.Consecutive, AssignedValueQualifier=qualifier };

			ScenarioContext.Current.Set(schedule, scheduleId);
		}

		[Given(@"the schedule with the id of '(.*)' runs at the specific time of '(.*)'")]
		public void g(string scheduleId, string time) {
			var schedule = ScenarioContext.Current.Get<Schedule>(scheduleId);
			schedule.TimeSegment = new TimeScheduleSegment { AssignedValue = time, ScheduleType = ScheduleTimeType.Single};

			ScenarioContext.Current.Set(schedule, scheduleId);
		}

		[Given(@"the schedule with the id of '(.*)' runs at this list of times '(.*)'")]
		public void h(string scheduleId, string time) {
			var schedule = ScenarioContext.Current.Get<Schedule>(scheduleId);
			schedule.TimeSegment = new TimeScheduleSegment { AssignedValue = time, ScheduleType = ScheduleTimeType.List_Times };

			ScenarioContext.Current.Set(schedule, scheduleId);
		}

	}
}
