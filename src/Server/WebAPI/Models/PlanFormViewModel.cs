using System.Collections.Generic;

namespace WebAPI.Models
{
    public class PlanFormViewModel
    {
        public string Title { get; set; }
        
        public string Description { get; set; }

        public virtual IEnumerable<ChoreFormViewModel> Chores { get; set; } = new List<ChoreFormViewModel>();
    }
}