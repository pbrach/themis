using System;

namespace AppDomain.Entities.Intervals
{
    public class AssignmentPeriod : IEquatable<AssignmentPeriod>
    {
        public uint AssignmentNumber { get; set; }
        public DateTime FirstActiveDay { get; set; }
        public DateTime LastActiveDay { get; set; }

        public bool Equals(AssignmentPeriod other)
        {
            return AssignmentNumber == other.AssignmentNumber &&
                   FirstActiveDay == other.FirstActiveDay &&
                   LastActiveDay == other.LastActiveDay;
        }
    }
}