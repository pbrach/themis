using System;
using System.Collections.Generic;
using AppDomain.Entities.Intervals;

namespace AppDomain.Entities
{
    public abstract class Interval
    {
        public TimeSpan Duration { get; set; } = TimeSpan.Zero;
        public DateTime StartDay { get; set; } = DateTime.MinValue;
        
        public abstract uint? GetCurrentTurnNumber();

        public abstract AssignmentPeriod GetAssignmentPeriod(uint turnNumber);

        public abstract IEnumerable<AssignmentPeriod> GetAssignmentsBetween(DateTime firstDay, DateTime lastDay);
    }
}