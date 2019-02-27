using System;
using System.Collections.Generic;
using System.Linq;
using AppDomain.Entities;
using AppDomain.Requests;
using Microsoft.EntityFrameworkCore;
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
                exists = ctx.Plans.Find(planId) != null;
            }

            return exists;        
        }
        
        public IEnumerable<Tuple<string, string>> GetAccessInfos()
        {
            var idList = new List<Tuple<string, string>>();
            using (var ctx = new ThemisContext())
            {
                idList.AddRange(ctx.Plans.Select(x => new Tuple<string, string>(x.Id, x.Token)));
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

        public bool DeletePlan(string id)
        {
            var wasSuccess = false;
            using (var ctx = new ThemisContext())
            {
                var plan = ctx.Plans.Include(pl => pl.Chores).FirstOrDefault(pl => pl.Id == id);
                if (plan == null)
                {
                    return false;
                }
                
                ctx.Chores.RemoveRange(plan.Chores);
                ctx.Plans.Remove(plan);
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
                Token = plan.Token,
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
                StartDay = chore.Interval.StartDay,
                StartOfWeek = chore.Interval.StartOfWeek
            };
        }

        public Plan RetrievePlan(string id)
        {
            DbPlan dbPlan = null;
            using (var ctx = new ThemisContext())
            {
                dbPlan = ctx.Plans.Include(pl => pl.Chores).FirstOrDefault(pl => pl.Id == id);
            }

            var plan = new Plan
            {
                Id = dbPlan.Id,
                Token = dbPlan.Token,
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
            interval.StartOfWeek = dbChore.StartOfWeek;
            
            string[] assis= {};
            if (!string.IsNullOrEmpty(dbChore.AssignedUsers))
            {
                assis = dbChore.AssignedUsers.Split(";");
            }
            return new Chore
            {
                Title = dbChore.Title,
                Description = dbChore.Description,
                AssignedUsers = assis,
                Interval = interval
            };
        }
    }
}