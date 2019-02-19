using System;
using System.Collections.Generic;
using System.Globalization;

namespace AppDomain.Entities.Intervals
{
    public class WeekInterval: Interval
    {
        public override string FriendlyName => "Week Interval";

        private TimeSpan? _turnDuration = null;
        private TimeSpan TurnDuration
        {
            get
            {
                if (!_turnDuration.HasValue)
                    _turnDuration = TimeSpan.FromDays(7 * Duration);
                
                return _turnDuration.Value; 
            }
        }

        private DateTime? _weekStartDay = null;
        private DateTime IntervalStartDay
        {
            get
            {
                if (!_weekStartDay.HasValue)
                {
                    _weekStartDay = GetWeekStart();
                }

                return _weekStartDay.Value;
            }
        }
        
        private DateTime GetWeekStart()
        {
            if (IsFirstWeekDay(StartDay))
            {
                return StartDay;
            }
            var dow = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(StartDay);
            var dayDiff = Math.Abs(StartOfWeek - dow);
            return StartDay.Date - TimeSpan.FromDays(dayDiff);
        }

        private bool IsFirstWeekDay(DateTime dayDate)
        {
            var dow = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dayDate);
            return dow == StartOfWeek;
        }

        public override uint? GetTurnNumber(DateTime date)
        {
            var elapsedSinceStart = date - IntervalStartDay;
            
            if (elapsedSinceStart < TimeSpan.Zero)
            {
                return null; // the StartDay is in the future, so it is no ones turn yet!
            }

            if (elapsedSinceStart < TurnDuration)
            {
                return 0;
            }

            var currentTurnNumber = elapsedSinceStart / TurnDuration;
            return (uint) currentTurnNumber;
        }
        
        public override Assignment GetAssignmentPeriod(uint turnNumber)
        {
            var firstDayOfDuty = IntervalStartDay + TurnDuration * turnNumber;
            var lastDayOfDuty = firstDayOfDuty + (TurnDuration - TimeSpan.FromDays(1));

            return new Assignment
            {
                TurnNumber = turnNumber,
                FirstActiveDay = firstDayOfDuty,
                LastActiveDay = lastDayOfDuty
            };
        }

        public override IEnumerable<Assignment> GetAssignmentsBetween(DateTime firstDay, DateTime lastDay)
        {
            var result = new List<Assignment>();
            if (lastDay < IntervalStartDay)
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