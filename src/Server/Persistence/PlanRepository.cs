using System;
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

        public bool StorePlan(DbPlan plan)
        {
            var wasSuccess = false;
            using (var ctx = new ThemisContext())
            {
                ctx.Plans.Add(plan);
                var result = ctx.SaveChanges();

                wasSuccess = result != 0;
            }

            return wasSuccess;
        }

        public DbPlan RetrivePlanById(string Id)
        {
            DbPlan result = null;
            using (var ctx = new ThemisContext())
            {
                result = ctx.Plans.Find(Id);
            }

            return result;
        }
    }
}