using System;
using System.Collections.Generic;

namespace AppDomain.Entities
{
    public abstract class Interval
    {
        public uint Duration { get; set; } = 0;

        public DateTime StartDay { get; set; } = DateTime.MinValue;

        public DayOfWeek StartOfWeek { get; set; } = DayOfWeek.Monday;

        public abstract string FriendlyName { get; }

        public uint? GetCurrentTurnNumber => GetTurnNumber(DateTime.Now);

        public abstract uint? GetTurnNumber(DateTime date);

        public abstract Assignment GetAssignmentPeriod(uint turnNumber);

        /// <summary>
        /// Returns 'Assignments' that end at or after 'firstDay' and start at or before 'lastDay'
        /// </summary>
        public abstract IEnumerable<Assignment> GetAssignmentsBetween(DateTime firstDay, DateTime lastDay);
    }
}