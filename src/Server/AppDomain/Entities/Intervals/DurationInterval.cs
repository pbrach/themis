using System;
using System.Collections.Generic;

namespace AppDomain.Entities.Intervals
{
    public class DurationInterval : Interval
    {
        public override uint? GetCurrentTurnNumber()
        {
            var today = DateTime.Now.Date;
            var elapsed = today - StartDay;

            if (elapsed < TimeSpan.Zero)
            {
                return null; // the StartDay is in the future, so it is no ones turn yet!
            }

            if (elapsed < Duration)
            {
                return 0;
            }

            var currentTurnNumber = elapsed / Duration;
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
            throw new NotImplementedException();
        }
    }
}