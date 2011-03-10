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
							var days = AddDays(schedule, lastExecutionTime);
							Console.WriteLine(days);
							prospectiveRunTime = prospectiveRunTime.AddDays(days);
							Console.WriteLine(prospectiveRunTime);
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
					var days = AddDays(schedule, lastExecutionTime);
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


		private int AddDays(Schedule segment, DateTime lastExecution) {
			int offset = 0;
			if (segment == null || segment.DaySegment == null) return offset;
			if (segment.DaySegment.ScheduleType == ScheduleDayType.Consecutive) {
				int.TryParse(segment.DaySegment.AssignedValue, out offset);

			} else if(segment.DaySegment.ScheduleType == ScheduleDayType.List_Days) {
				var daysList = segment.DaySegment.AssignedValue.Split(',')
					.Select(x=>int.Parse(x)).ToList();
				
				if (daysList.Contains(0)) {
					var lastDayMonth = new DateTime(lastExecution.Year, lastExecution.Month + 1, 1).AddDays(-1).Day;
					daysList.Remove(0);
					daysList.Add(lastDayMonth);
				}
				
				var validDays = daysList.Where(x => x > lastExecution.Day);
				Console.WriteLine(validDays.Count());
				if (validDays == null || validDays.Count() == 0) {
					// do next month
					var targetDay = daysList.Min();
					Console.WriteLine("target day " + targetDay);

					var nextExecution = lastExecution.Date.AddMonths(1);
					nextExecution = new DateTime(nextExecution.Year, nextExecution.Month, targetDay);
					Console.WriteLine(nextExecution);
					offset = nextExecution.Date.Subtract(lastExecution.Date).Days;
				} else {
					var targetDay = validDays.Where(x=>x>0).OrderBy(x => x).FirstOrDefault();
					Console.WriteLine("target day " + targetDay);
					var nextExecution = lastExecution.Date;
					nextExecution = new DateTime(nextExecution.Year, nextExecution.Month, targetDay);
					offset = nextExecution.Date.Subtract(lastExecution.Date).Days;
				}
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
