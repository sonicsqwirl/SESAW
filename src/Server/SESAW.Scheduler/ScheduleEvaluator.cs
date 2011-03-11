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
				if (prospectiveRunTime <= nextExecution) {
					var days = AddDays(schedule, lastExecutionTime);
					Console.WriteLine(days);
					prospectiveRunTime = prospectiveRunTime.AddDays(days);
					Console.WriteLine(prospectiveRunTime);
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

		private int AddMonths(MonthScheduleSegment segment, DateTime nextExecution){
			int offset = 0;
			if (segment == null) return offset;
			if (segment.ScheduleType == ScheduleMonthType.List_Months) {
				var months = segment.AssignedValue.Split(',').Select(x => int.Parse(x));
				if (!months.Any(x => x == nextExecution.Month)) {
					var validMonths = months.Where(x => x > nextExecution.Month).OrderBy(x=>x);
					if (validMonths == null || validMonths.Count() == 0) {
						var targetMonth = months.Min();
						var prospectiveDate = new DateTime(nextExecution.Year + 1, targetMonth, nextExecution.Day);

						offset = prospectiveDate.Subtract(nextExecution).Days;
					} else {
						var targetMonth = validMonths.FirstOrDefault();
						var prospectiveDate = new DateTime(nextExecution.Year, targetMonth, nextExecution.Day);
						Console.WriteLine(prospectiveDate);
						offset = prospectiveDate.Subtract(nextExecution).Days;
					}
				}
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

		private int LastDayOfTheMonth(DateTime date) {
			return new DateTime(date.Year, date.Month + 1, 1).AddDays(-1).Day;
		}

		private int AddDays(Schedule segment, DateTime lastExecution) {
			var lastDayOfMonth = LastDayOfTheMonth(lastExecution);
			Console.WriteLine("last DoM : " + lastDayOfMonth);
			var nextExecution = lastExecution.Date;
			
			int offset = 0;
			if (segment == null || segment.DaySegment == null) return offset;
			if (segment.DaySegment.ScheduleType == ScheduleDayType.Consecutive) {
				int.TryParse(segment.DaySegment.AssignedValue, out offset);

				if (lastExecution.Day == lastDayOfMonth) {
					int monthOffset = AddMonths(segment.MonthSegment, lastExecution.AddDays(1));
					offset += monthOffset+1;
				}

			} else if(segment.DaySegment.ScheduleType == ScheduleDayType.List_Days) {
				var daysList = segment.DaySegment.AssignedValue.Split(',')
					.Select(x=>int.Parse(x)).OrderBy(x=>x).ToList();

				if (daysList.Contains(0)) {
					daysList.Remove(0);
					daysList.Remove(lastDayOfMonth);
					daysList.Add(lastDayOfMonth);
				}
				
				var validDays = daysList.Where(x => x > lastExecution.Day);
				Console.WriteLine(validDays.Count());
				if (validDays == null || validDays.Count() == 0) {
					// do next month
					var targetDay = daysList.Min();
					
					Console.WriteLine("target day " + targetDay);

					nextExecution = lastExecution.Date.AddMonths(1);
					var nextLastDayOfMonth = LastDayOfTheMonth(nextExecution);
					if (targetDay > nextLastDayOfMonth) {
						targetDay = nextLastDayOfMonth;
					}

					nextExecution = new DateTime(nextExecution.Year, nextExecution.Month, targetDay);
					Console.WriteLine(nextExecution);
					offset = nextExecution.Date.Subtract(lastExecution.Date).Days;
				} else {
					var targetDay = validDays.Where(x=>x>0).OrderBy(x => x).FirstOrDefault();

					if (targetDay == lastDayOfMonth) {
						if (lastExecution.Day == lastDayOfMonth) {
							targetDay = daysList.FirstOrDefault();
							nextExecution = nextExecution.AddMonths(1);
						}
					}
					
					Console.WriteLine("target day " + targetDay);
					nextExecution = new DateTime(nextExecution.Year, nextExecution.Month, targetDay);
					offset = nextExecution.Date.Subtract(lastExecution.Date).Days;
				}
			} else if (segment.DaySegment.ScheduleType == ScheduleDayType.List_Weekdays) {
				var daysList = segment.DaySegment.AssignedValue.Split(',')
					.Select(x => (int)(DayOfWeek)Enum.Parse(typeof(DayOfWeek),x)).ToList();

				var currentDay = (int)lastExecution.DayOfWeek;
				Console.WriteLine("current day : " + currentDay);
				var validDays = daysList.Where(x => x > currentDay);
				if (validDays == null || validDays.Count() == 0) {
					// do next month
					var targetDay = daysList.Min();
					var firstDayOfWeek = GetFirstDayOfWeek(lastExecution);
					offset = ((7 * segment.DaySegment.Interval) + targetDay) - currentDay;
					//Console.WriteLine("target weekday " + targetDay);
				} else {
					var targetDay = validDays.Where(x => x > 0).OrderBy(x => x).FirstOrDefault();
					Console.WriteLine("target weekday " + targetDay);
					var delta = targetDay - currentDay;
					nextExecution = lastExecution.Date;
					nextExecution = new DateTime(nextExecution.Year, nextExecution.Month, nextExecution.Day).AddDays(delta);
					offset = delta;
				}
			}

			//var monthOffset = AddMonths(segment.MonthSegment, nextExecution);
			//if (monthOffset > 0) {
			//  offset += monthOffset;
			//}

			return offset;
		}

		private int GetFirstDayOfWeek(DateTime date) {
			int day = 0;

			day = date.AddDays(-((int)date.DayOfWeek)).Day;

			return day;
		}

		private int AddMinutes(TimeScheduleSegment segment) {
			int offset = 0;
			if (segment == null) return offset;
			
			int.TryParse(segment.AssignedValue, out offset);
			
			
			if (segment.AssignedValueQualifier == "hr") {
				offset = offset * 60;
			} else if (segment.AssignedValueQualifier == "mm") {
				offset = offset * 1;
			}
			
			return offset;
		}

	}
}
