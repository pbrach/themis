using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace persistence
{
    public class Plan
    {
        public string Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Title { get; set; }
        
        [MaxLength]
        public string Description { get; set; }

        public IEnumerable<Chore> Chores { get; set; }
        
        public string UserListText { get; set; }
    }
}