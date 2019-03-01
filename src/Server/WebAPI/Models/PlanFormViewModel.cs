using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class PlanFormViewModel
    {
        private IEnumerable<ChoreFormViewModel> _chores = new List<ChoreFormViewModel>();
        private DateTime _startDate;
        public string Title { get; set; }
        
        public string Description { get; set; }

        public DateTime StartDate
        {
            get => _startDate;
            set 
            {
                _startDate = value;
                UpdateChoreStartDay();
            }
        }

        public IEnumerable<ChoreFormViewModel> Chores
        {
            get => _chores;
            set
            {
                _chores = value;
                UpdateChoreStartDay();
            }
        }

        private void UpdateChoreStartDay()
        {
            foreach (var chore in Chores)
            {
                if(chore.StartDay != null)
                    continue;

                chore.StartDay = StartDate;
            }   
        }
    }
}