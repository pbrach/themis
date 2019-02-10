using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class PlanViewModel
    {
        public string Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Title { get; set; }
        
        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}