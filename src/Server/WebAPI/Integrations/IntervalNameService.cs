using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Integrations
{
    public static class IntervalNameService
    {
        private static readonly Dictionary<string, string> DisplayIntervalNames = new Dictionary<string, string>
        {
            {"Days", "Duration Interval"},
            {"Weeks", "Week Interval"},
            {"Months", "Month Interval"},
        };
        
        public static IEnumerable<(string display, string value)> Get()
        {
            return DisplayIntervalNames.Select(pair => (pair.Key, pair.Value));
        }
    }
}