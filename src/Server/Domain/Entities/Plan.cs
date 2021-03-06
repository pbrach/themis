using System.Collections.Generic;

namespace AppDomain.Entities
{
    public class Plan
    {
        public string Id { get; set; }
        
        public string Token { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<Chore> Chores { get; set; } = new List<Chore>();
    }
}