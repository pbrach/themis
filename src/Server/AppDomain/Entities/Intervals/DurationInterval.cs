using System;
using System.Collections.Generic;

namespace AppDomain.Entities.Intervals
{
    /// <summary>
    /// Duration Intervals:
    /// - some duration in days (min 1 day) for which a user is assigned is given
    /// - directly after the duration ends, the next assignement interval begins
    ///
    /// </summary>
    public class DurationInterval : Interval
    {
        public override uint? GetCurrentTurnNumber()
        {
            var today = DateTime.Now.Date;
            return GetTurnNumber(today);
        }

        private uint? GetTurnNumber(DateTime dayOfSomeTurn)
        {
            var elapsedSinceStart = dayOfSomeTurn - StartDay;

            if (elapsedSinceStart < TimeSpan.Zero)
            {
                return null; // the StartDay is in the future, so it is no ones turn yet!
            }

            if (elapsedSinceStart < Duration)
            {
                return 0;
            }

            var currentTurnNumber = elapsedSinceStart / Duration;
            return (uint)currentTurnNumber;
        }

        public override AssignmentPeriod GetAssignmentPeriod(uint turnNumber)
        {
            var firstDayOfDuty = StartDay + (Duration - TimeSpan.FromDays(1)) * turnNumber;
            var lastDayOfDuty = firstDayOfDuty + Duration;

            return new AssignmentPeriod
            {
                AssignmentNumber = turnNumber,
                FirstActiveDay = firstDayOfDuty,
                LastActiveDay = lastDayOfDuty
            };
        }

        public override IEnumerable<AssignmentPeriod> GetAssignmentsBetween(DateTime firstDay, DateTime lastDay)
        {
            var result = new List<AssignmentPeriod>();
            
            var activeDay = firstDay;
            while (activeDay <= lastDay)
            {
                var turnNumber = GetTurnNumber(activeDay);
                if (turnNumber == null)
                {
                    break;
                }

                var assPi = GetAssignmentPeriod(turnNumber.Value);
                result.Add(assPi);
                activeDay = assPi.LastActiveDay + TimeSpan.FromDays(1);
            }

            return result;
        }
    }
}