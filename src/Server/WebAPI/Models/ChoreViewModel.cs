using System;

namespace WebAPI.Models
{
    public class ChoreViewModel
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; } = DateTime.Now;
        public string CurrentAssignee { get; set; }
        public string NextAssignee { get; set; }
    }
}