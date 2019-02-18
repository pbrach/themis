using System.Linq;
using AppDomain.Entities;
using AppDomain.Requests;
using Persistence.DbTypes;

namespace Persistence
{
    public class PlanRepository
    {
        public bool DoesPlanIdExist(string planId)
        {
            var exists = false;
            using (var ctx = new ThemisContext())
            {
                var result = ctx.SaveChanges();

                exists = ctx.Plans.Find(planId) != null;
            }

            return exists;        
        }
        
        public IEnumerable<string> AllPlanIds()
        {
            var idList = new List<string>();
            using (var ctx = new ThemisContext())
            {
                idList.AddRange(ctx.Plans.Select(x => x.Id));
            }

            return idList;        
        }

        public bool StoreNewPlan(Plan plan)
        {
            var wasSuccess = false;
            using (var ctx = new ThemisContext())
            {
                var dbPlan = MapFromBl(plan);
                ctx.Plans.Add(dbPlan);
                var result = ctx.SaveChanges();

                wasSuccess = result != 0;
            }

            return wasSuccess;
        }

        private static DbPlan MapFromBl(Plan plan)
        {
            return new DbPlan
            {
                Id = plan.Id,
                Title = plan.Title,
                Description = plan.Description,
                Chores = plan.Chores.Select(MapFromBl).ToList()
            };
        }

        private static DbChore MapFromBl(Chore chore)
        {
            return new DbChore
            {
                Title = chore.Title,
                Description = chore.Description,
                AssignedUsers = string.Join(";", chore.AssignedUsers),

                IntervalType = chore.Interval.FriendlyName,
                Duration = chore.Interval.Duration,
                StartDay = chore.Interval.StartDay
            };
        }

        public Plan RetrievePlan(string id)
        {
            DbPlan dbPlan = null;
            using (var ctx = new ThemisContext())
            {
                dbPlan = ctx.Plans.Find(id);
            }

            var plan = new Plan
            {
                Id = dbPlan.Id,
                Title = dbPlan.Title,
                Description = dbPlan.Description,
                Chores = dbPlan.Chores.Select(MapFromDb)
            };

            return plan;
        }
        
        private static Chore MapFromDb(DbChore dbChore)
        {
            var interval = IntervalService.CreateNew(dbChore.IntervalType);
            interval.Duration = dbChore.Duration;
            interval.StartDay = dbChore.StartDay;
            
            return new Chore
            {
                Title = dbChore.Title,
                Description = dbChore.Description,
                AssignedUsers = dbChore.AssignedUsers.Split(";"),
                Interval = interval
            };
        }
    }
}