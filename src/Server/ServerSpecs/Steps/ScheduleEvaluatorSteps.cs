using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Should;
using SESAW.Domain;
using SESAW.Scheduler;

namespace ServerSpecs.Steps
{
	[Binding]
	public class ScheduleEvaluatorSteps
	{
		private DateTime lastExecuteTime = DateTime.MinValue;
		private DateTime nextExecuteTime = DateTime.MinValue;

		[Given(@"I have last execute time of '(.*)'")]
		public void a(DateTime lastExecuteTime) {
			this.lastExecuteTime = lastExecuteTime;
		}

		[When(@"I get the next execution date for the schedule with the id of '(.*)'")]
		public void g(string scheduleId) {
			var schedule = ScenarioContext.Current.Get<Schedule>(scheduleId);

			nextExecuteTime = new ScheduleEvaluator().GetNextExecutionTime(schedule, lastExecuteTime);
		}

		[Then(@"I should have an execution date of '(.*)'")]
		public void h(DateTime desiredNextExecuteTime) {
			nextExecuteTime.ShouldEqual(desiredNextExecuteTime);
		}
	}
}
