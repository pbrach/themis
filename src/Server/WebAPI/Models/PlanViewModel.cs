using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class PlanViewModel
    {
        public string Title { get; set; }
        
        public string Description { get; set; }

        public virtual IEnumerable<ChoreFormViewModel> Chores { get; set; } = new List<ChoreFormViewModel>();
    }
}