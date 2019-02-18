using System;

namespace Persistence.DbTypes
{
    public class DbChore
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string DbPlanId { get; set; }
        
        public string AssignedUsers { get; set; }
        
        public TimeSpan Duration { get; set; } = TimeSpan.Zero;
        
        public DateTime StartDay { get; set; } = DateTime.MinValue;
        
        public string IntervalType { get; set; }
    }
}