using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SESAW.Domain
{
	public enum ScheduleMonthType
	{
		Consecutive,
		List_Months
	}

	public enum ScheduleWeekType
	{
		Consecutive,
		List_Weeks,
	}

	public enum ScheduleDayType
	{
		Consecutive,
		List_Days,
		List_Weekdays
	}

	public enum ScheduleTimeType
	{
		Consecutive,
		List_Times,
		Single
	}

	public class Schedule
	{
		public Guid Id { get; set; }

		public MonthScheduleSegment MonthSegment { get; set; }
		public WeekScheduleSegment WeekSegment { get; set; }
		public DayScheduleSegment DaySegment { get; set; }
		public TimeScheduleSegment TimeSegment { get; set; }
	}

	public class MonthScheduleSegment
	{
		public ScheduleMonthType ScheduleType { get; set; }
		public string AssignedValue { get; set; }
	}

	public class WeekScheduleSegment
	{
		public ScheduleWeekType ScheduleType { get; set; }
		public string AssignedValue { get; set; }
		public int AssignedValueQualifier { get; set; }
	}

	public class DayScheduleSegment
	{
		public ScheduleDayType ScheduleType { get; set; }
		public string AssignedValue { get; set; }
	}

	public class TimeScheduleSegment
	{
		public ScheduleTimeType ScheduleType { get; set; }
		public string AssignedValueQualifier { get; set; }
		public string AssignedValue { get; set; }
	}
}
