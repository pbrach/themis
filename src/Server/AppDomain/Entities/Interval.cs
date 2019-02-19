using System;
using System.Collections.Generic;

namespace AppDomain.Entities
{
    public abstract class Interval
    {
        public uint Duration { get; set; } = 0;

        protected abstract TimeSpan TurnDuration {get;}
        
        protected abstract DateTime IntervalStart { get; }
        public DateTime StartDay { get; set; } = DateTime.MinValue;

        public DayOfWeek StartOfWeek { get; set; } = DayOfWeek.Monday;

        public abstract string FriendlyName { get; }

        public uint? GetCurrentTurnNumber => GetTurnNumber(DateTime.Now);

        public abstract uint? GetTurnNumber(DateTime date);

        public Assignment GetAssignmentPeriod(uint turnNumber)
        {
            var firstDayOfDuty = IntervalStart + TurnDuration * turnNumber;
            var lastDayOfDuty = firstDayOfDuty + (TurnDuration - TimeSpan.FromDays(1));

            return new Assignment
            {
                TurnNumber = turnNumber,
                FirstActiveDay = firstDayOfDuty,
                LastActiveDay = lastDayOfDuty
            };
        }

        /// <summary>
        /// Returns only 'Assignments' that start at or after 'firstDay' and end at or before 'lastDay'
        /// </summary>
        public IEnumerable<Assignment> GetAssignmentsBetween(DateTime firstDay, DateTime lastDay)
        {
            var result = new List<Assignment>();
            if (lastDay < IntervalStart)
            {
                return result;
            }
            
            var activeDay = firstDay;
            while (activeDay <= lastDay)
            {
                var turnNumber = GetTurnNumber(activeDay);
                if (turnNumber == null)
                {
                    activeDay += TurnDuration;
                    continue;
                }

                var assPi = GetAssignmentPeriod(turnNumber.Value);
                result.Add(assPi);

                activeDay += TurnDuration;
            }

            return result;
        }
    }
}