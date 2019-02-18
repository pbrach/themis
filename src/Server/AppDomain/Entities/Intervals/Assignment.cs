using System;

namespace AppDomain.Entities.Intervals
{
    public class Assignment : IEquatable<Assignment>
    {
        public string AssigneeName { get; set; }
        public uint? TurnNumber { get; set; }
        public DateTime FirstActiveDay { get; set; }
        public DateTime LastActiveDay { get; set; }

        public bool Equals(Assignment other)
        {
            return AssigneeName == other.AssigneeName &&
                   TurnNumber == other.TurnNumber &&
                   FirstActiveDay == other.FirstActiveDay &&
                   LastActiveDay == other.LastActiveDay;
        }
    }
}