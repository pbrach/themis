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
    }
}