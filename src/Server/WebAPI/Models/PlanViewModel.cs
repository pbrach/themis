using System.Collections.Generic;

namespace WebAPI.Models
{
    public class PlanViewModel
    {
        public string Title { get; set; }
        
        public string Description { get; set; }

        public virtual IEnumerable<ChoreViewModel> Chores { get; set; } = new List<ChoreViewModel>();
    }
}