using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ChoreFormViewModel
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int DayDuration { get; set; } =  1;
        public DateTime StartDay { get; set; } = DateTime.Now;
        public string IntervalType { get; set; }
        public string AssignedUsers { get; set; }
    }
}