using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.DbTypes
{
    public class DbPlan
    {
        public string Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public IEnumerable<DbChore> Chores { get; set; }
        
        public string UserListText { get; set; }
    }
}