using System;
using System.Globalization;

namespace AppDomain.Entities.Intervals
{
    /// <summary>
    /// 'Duration' is here the number of weeks
    ///
    /// The 'StartDay' can be any day within the week, but with the 'StartOfWeek' property
    /// the actual week and the firstday of the week is derived.
    ///
    /// This allows to store the original data (perhaps the day the plan was started)
    /// in the DB while still providing the correct functionality.
    /// </summary>
    public class WeekInterval: DurationInterval
    {
        public override string FriendlyName => "Week Interval";

        private TimeSpan? _turnDuration = null;

        protected override TimeSpan TurnDuration
        {
            get
            {
                if (!_turnDuration.HasValue)
                    _turnDuration = TimeSpan.FromDays(7 * Duration);
                
                return _turnDuration.Value; 
            }
        }

        private DateTime? _weekStartDay = null;

        protected override DateTime IntervalStart
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