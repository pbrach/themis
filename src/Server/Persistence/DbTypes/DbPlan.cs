using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.DbTypes
{
    public class DbPlan
    {
        public string Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Title { get; set; }
        
        [MaxLength(2000)]
        public string Description { get; set; }

        public IEnumerable<DbChore> Chores { get; set; }
        
        public string UserListText { get; set; }
    }
}