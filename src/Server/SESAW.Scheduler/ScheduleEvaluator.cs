using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SESAW.Domain;

namespace SESAW.Scheduler
{
	public class ScheduleEvaluator
	{
		private DateTime nextExecution = DateTime.MinValue;

		public DateTime GetNextExecutionTime(Schedule schedule, DateTime lastExecutionTime) {
			nextExecution = lastExecutionTime;

			if (schedule.TimeSegment.ScheduleType == ScheduleTimeType.Single) {
				var span = TimeSpan.Parse(schedule.TimeSegment.AssignedValue);
				Console.WriteLine(span);
				var prospectiveRunTime = nextExecution.Date.AddSeconds(span.TotalSeconds);
				Console.WriteLine(prospectiveRunTime);
				if (prospectiveRunTime < nextExecution) {
					if (schedule.DaySegment != null) {
						if (schedule.DaySegment.ScheduleType == ScheduleDayType.Consecutive) {
							var days = AddDays(schedule);
							Console.WriteLine(days);
							prospectiveRunTime = prospectiveRunTime.AddDays(days);
						}
					}
				}
				nextExecution = prospectiveRunTime;


			} else if (schedule.TimeSegment.ScheduleType == ScheduleTimeType.Consecutive) {
				var minutes = AddMinutes(schedule.TimeSegment);
				Console.WriteLine(minutes);
				nextExecution = nextExecution.AddMinutes(minutes);
			} else if (schedule.TimeSegment.ScheduleType == ScheduleTimeType.List_Times) {
				var times = schedule.TimeSegment.AssignedValue.Split(',').Select(x => TimeSpan.Parse(x));
				var executionTime = TimeSpan.Parse(nextExecution.ToString("HH:mm"));
				var validTime = times.Where(x => x > executionTime).OrderBy(x=>x.TotalSeconds);
				
				if (validTime == null || validTime.Count() == 0) {
					var days = AddDays(schedule);
					var time = times.OrderBy(x => x.TotalSeconds).FirstOrDefault();

					Console.WriteLine(time);
					Console.WriteLine(days);
					nextExecution = nextExecution.Date.AddDays(days).AddSeconds(time.TotalSeconds);
				} else {

					Console.WriteLine(validTime);
					nextExecution = nextExecution.Date.AddSeconds(validTime.First().TotalSeconds);
				}

			}
			
			return nextExecution;
		}

		private int AddMonths(MonthScheduleSegment segment){
			int offset = 0;
			if (segment == null) return offset;
			if (segment.ScheduleType == ScheduleMonthType.Consecutive) {
				int.TryParse(segment.AssignedValue, out offset);
			} else {

			}
			return offset;
		}

		private int AddDaysFromWeek(WeekScheduleSegment segment) {
			int offset = 0;
			if (segment == null) return offset;
			if (segment.ScheduleType == ScheduleWeekType.Consecutive) {
				int.TryParse(segment.AssignedValue, out offset);

				offset = offset * 7;
			} else {

			}
			return offset;
		}

		private int AddDays(Schedule segment) {
			int offset = 0;
			if (segment == null || segment.DaySegment == null) return offset;
			if (segment.DaySegment.ScheduleType == ScheduleDayType.Consecutive) {
				int.TryParse(segment.DaySegment.AssignedValue, out offset);

			} else {

			}
			return offset;
		}

		private int AddMinutes(TimeScheduleSegment segment) {
			int offset = 0;
			if (segment == null) return offset;
			if (segment.ScheduleType == ScheduleTimeType.Consecutive) {
				int.TryParse(segment.AssignedValue, out offset);
				if (segment.AssignedValueQualifier == "hr") {
					offset = offset * 60;
				} else if (segment.AssignedValueQualifier == "mm") {
					offset = offset * 1;
				}
			} else if (segment.ScheduleType == ScheduleTimeType.Single) {
				// todo : parse time and justify next run by telling how many minutes to add till next time
			} else {

			}
			return offset;
		}

	}
}
