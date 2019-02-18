using System;
using System.Linq;
using AppDomain.Entities;
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
            var result = new DbPlan
            {
                Id = plan.Id,
                Title = plan.Title,
                Description = plan.Description,
                Chores = plan.Chores.Select(MapFromBl).ToList()
            };

            return result;
        }

        private static DbChore MapFromBl(Chore chore)
        {
            var result = new DbChore
            {
                Title = chore.Title,
                Description = chore.Description,
                AssignedUsers = string.Join(";", chore.AssignedUsers),

                IntervalType = chore.Interval.FriendlyName,
                Duration = chore.Interval.Duration,
                StartDay = chore.Interval.StartDay
            };

            return result;
        }

        public Plan RetrievePlanById(string id)
        {
            DbPlan result = null;
            using (var ctx = new ThemisContext())
            {
                result = ctx.Plans.Find(id);
            }

            var plan = new Plan
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description
            };

            return plan;
        }
    }
}