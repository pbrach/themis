using System;

namespace AppDomain.Entities
{
    public class Chore
    {
        public string Title { get; set; } = "No Title";
        public string Description { get; set; } = "";
        public TimeSpan Duration { get; set; } = TimeSpan.Zero;
        public DateTime StartTime { get; set; } = DateTime.MinValue;
        public string[] Users { get; set; } = { };
    }
}