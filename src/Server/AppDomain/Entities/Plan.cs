using System.Collections.Generic;

namespace AppDomain.Entities
{
    public class Plan
    {
        public string Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public ICollection<Chore> Chores { get; } = new List<Chore>();
        
        public ICollection<string> Users { get; } = new List<string>();

        public void AddRange(IEnumerable<string> users)
        {
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }
}