using System;

namespace WebAPI.Models
{
    public class ChoreFormViewModel
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public TimeSpan Duration { get; set; } = TimeSpan.Zero;
        public DateTime StartDay { get; set; } = DateTime.Now;
        public string IntervalType { get; set; }
    }
}