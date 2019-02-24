using System;
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
        public string[] AssignedUsers { get; set; } = {};
        public Interval Interval { get; set; }

        public Assignment AssignmentAt(DateTime date)
        {
            Assignment result = null;
            var turnNumber = Interval.GetTurnNumber(date);
            
            if (!turnNumber.HasValue)
            {
                result = new Assignment
                {
                    TurnNumber = null,
                    AssigneeName = "No one: Chore did not start yet",
                    LastActiveDay = DateTime.MinValue,
                    FirstActiveDay = DateTime.MinValue
                };
            }
            else
            {
                result = Interval.GetAssignmentPeriod(turnNumber.Value);
                var numOfUSers = AssignedUsers.Length;

                result.AssigneeName = "No Assignees";
                if (numOfUSers > 0)
                {
                    var assignmentId = turnNumber.Value % AssignedUsers.Length;
                    result.AssigneeName = AssignedUsers[assignmentId];
                }
            }

            return result;
        }
    }
}