using System;
using System.Collections.Generic;

namespace AppDomain.Entities.Intervals
{
    /// <summary>
    /// Duration Intervals:
    /// - some duration in days (at least 1 day) for which a user is assigned is given
    /// - directly after the duration ends, the next assignement interval begins
    ///
    /// </summary>
    public class DurationInterval : Interval
    {
        public override string FriendlyName => "Duration Interval";
        
        private TimeSpan? _turnDuration;

        protected virtual TimeSpan TurnDuration
        {
            get
            {
                if (!_turnDuration.HasValue)
                    _turnDuration = TimeSpan.FromDays(Duration);
                
                return _turnDuration.Value; 
            }
        }

        private DateTime? _startDate;

        protected virtual DateTime IntervalStart
        {
            get
            {
                if (!_startDate.HasValue)
                    _startDate = StartDay.Date;
                
                return _startDate.Value; 
            }
        }
        
        public override uint? GetTurnNumber(DateTime date)
        {
            var elapsedSinceStart = date - IntervalStart;

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
            var firstDayOfDuty = IntervalStart + TurnDuration * turnNumber;
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