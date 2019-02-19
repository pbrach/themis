using System;
using System.Collections.Generic;
using System.Linq;
using AppDomain.Requests;

namespace WebAPI.Models
{
    public class ChoreFormViewModel
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int DayDuration { get; set; } =  1;
        public DateTime StartDay { get; set; } = DateTime.Now;
        public DayOfWeek StartOfWeek { get; set; } = DayOfWeek.Monday;
        public string IntervalType { get; set; } = IntervalService.GetIntervalFriendlyNames().First();
        public IEnumerable<string> AssignedUsers { get; set; } = new List<string>(); 
    }
}