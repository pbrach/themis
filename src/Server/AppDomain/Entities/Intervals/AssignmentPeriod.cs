using System;

namespace AppDomain.Entities.Intervals
{
    public class AssignmentPeriod
    {
        public uint AssignmentNumber { get; set; }
        public DateTime FirstActiveDay { get; set; }
        public DateTime LastActiveDay { get; set; }
    }
}