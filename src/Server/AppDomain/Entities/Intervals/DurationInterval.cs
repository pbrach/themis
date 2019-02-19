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
        public override string FriendlyName => "Duration Interval";
        
        private TimeSpan? _turnDuration;

        protected override TimeSpan TurnDuration
        {
            get
            {
                if (!_turnDuration.HasValue)
                    _turnDuration = TimeSpan.FromDays(Duration);
                
                return _turnDuration.Value; 
            }
        }

        private DateTime? _startDate;

        protected override DateTime IntervalStart
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
    }
}