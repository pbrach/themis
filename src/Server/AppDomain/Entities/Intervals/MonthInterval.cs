using System;
using System.Collections.Generic;
using System.Globalization;

namespace AppDomain.Entities.Intervals
{
    public class MonthInterval: Interval
    {
        public override string FriendlyName => "Month Interval";

        private DateTime? _intervalStart = null;
        private DateTime IntervalStart
        {
            get
            {
                if (!_intervalStart.HasValue)
                {
                    _intervalStart = GetMonthStart();
                }

                return _intervalStart.Value;
            }
        }

        private DateTime GetMonthStart()
        {
            if (StartDay.Day == 1)
            {
                return StartDay.Date;
            }

            return new DateTime(StartDay.Year, StartDay.Month, 1);
        }

        private uint _startMonth = 0;
        public uint StartMonth
        {
            get
            {
                if (_startMonth == 0)
                {
                    _startMonth = (uint)StartDay.Month;
                }

                return _startMonth;
            }
        }

        private uint _startYear = 0;
        public uint StartYear
        {
            get
            { 
                if(_startYear == 0)
                {
                    _startYear = (uint) StartDay.Year;
                }

                return _startYear;
            }
        }

        
        public override uint? GetTurnNumber(DateTime date)
        {
            var monthsSinceStart = date.Month - StartMonth + 12 * (date.Year - StartYear);

            if (monthsSinceStart < 0)
            {
                return null; // the StartDay is in the future, so it is no ones turn yet!
            }

            if (monthsSinceStart < Duration)
            {
                return 0;
            }
            
            var currentTurnNumber = monthsSinceStart / Duration;
            return (uint) currentTurnNumber;
        }

        
        public override Assignment GetAssignmentPeriod(uint turnNumber)
        {
            var totalElapsedMonths = turnNumber * Duration;
            var firstActive = IntervalStart.AddMonths((int) totalElapsedMonths);

            return new Assignment
            {
                TurnNumber = turnNumber,
                FirstActiveDay = firstActive,
                LastActiveDay = firstActive.AddMonths((int)Duration) - TimeSpan.FromDays(1)
            };
        }

        public override IEnumerable<Assignment> GetAssignmentsBetween(DateTime firstDay, DateTime lastDay)
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
                    activeDay = activeDay.AddMonths((int)Duration);
                    continue;
                }

                var assPer = GetAssignmentPeriod(turnNumber.Value);
                result.Add(assPer);

                activeDay = activeDay.AddMonths((int)Duration);
            }

            return result;
        }
    }
}