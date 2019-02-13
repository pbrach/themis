using System;
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
                ctx.Plans.Add(new DbPlan{
                    Id = plan.Id,
                    Title = plan.Title,
                    Description = plan.Description,
                    UserListText = string.Join(";", plan.Users),
                    Chores = null
                    });
                var result = ctx.SaveChanges();

                wasSuccess = result != 0;
            }

            return wasSuccess;
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
            plan.AddRange(result.UserListText.Split(";"));

            return plan;
        }
    }
}