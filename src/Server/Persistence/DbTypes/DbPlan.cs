using System.Collections.Generic;

namespace Persistence.DbTypes
{
    public class DbPlan
    {
        public string Id { get; set; }
        
        public string Token { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public ICollection<DbChore> Chores { get; set; } = new List<DbChore>();
    }
}