using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class PlanViewModel
    {
        [MaxLength(150)]
        [Required]
        public string Title { get; set; }
        
        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual IList<ChoreFormViewModel> Chores { get; set; } = new List<ChoreFormViewModel>();
        
        public virtual IList<MyType> Users { get; set; } = new List<MyType>();
    }

    public class MyType
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
}