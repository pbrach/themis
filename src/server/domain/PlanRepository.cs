using System;
using persistence;

namespace domain
{
    public class PlanRepository
    {
        public (string, string) CreatePlan(dynamic planVM)
        {
            var newPlan = new Plan
            {
                Id = CreateNewPlanId(-10),
                Title = planVM.Title,
                Description = planVM.Description
            };

            var result = ("no-acc", "no-auth");
            using (var ctx = new ThemisContext())
            {
                ctx.Plans.Add(newPlan);
                ctx.SaveChanges();
            }

            result.Item1 = newPlan.Id;
            return result;
        }

        public Plan GetPlan(string id)
        {
            Plan result = null;
            using (var ctx = new ThemisContext())
            {
                result = ctx.Plans.Find(id);
            }

            return result;
        }

        private string CreateNewPlanId(int length)
        {
            return Guid.NewGuid().ToString();
        }
    }
}