using AppDomain.Entities.Intervals;

namespace AppDomain.Entities
{
    public class Chore
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        
        /// <summary>
        /// Users that are assigned to this chore (might not be all users from the plan)
        /// </summary>
        public string[] Users { get; set; } = { };
        public Interval Interval { get; set; }

        public string GetCurrentAssignedUser()
        {
            var turnNumber = Interval.GetCurrentTurnNumber();
            if (!turnNumber.HasValue)
            {
                return "No one: Chore did not start yet";
            }

            var assignmentId = turnNumber.Value % Users.Length;
            
            return Users[assignmentId];
        }

        public AssignmentPeriod GetCurrentAssignmentPeriod()
        {
            var turnNumber = Interval.GetCurrentTurnNumber();
            
            if (turnNumber == null)
            {
                return Interval.GetAssignmentPeriod(0);
            }
            
            return Interval.GetAssignmentPeriod(turnNumber.Value);
        }
    }
}