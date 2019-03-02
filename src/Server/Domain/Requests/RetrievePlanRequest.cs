using System;
using AppDomain.Entities;
using AppDomain.Responses;

namespace AppDomain.Requests
{
    public class RetrievePlanRequest
    {
        private readonly Func<string, bool> _doesPlanIdExist;
        private readonly Func<string, Plan> _getPlanById;
        private readonly string _planId;

        public RetrievePlanRequest(
            Func<string, bool> doesPlanIdExist, 
            Func<string, Plan> getPlanById,
            string planId)
        {
            _doesPlanIdExist = doesPlanIdExist;
            _getPlanById = getPlanById;
            _planId = planId;
        }

        public RetrievePlanResponse Handle()
        {
            if (!_doesPlanIdExist(_planId))
            {
                return new RetrievePlanResponse
                {
                    Plan = null,
                    ErrorMessage = "That plan does not exist"
                };
            }
            
            return new RetrievePlanResponse
            {
                ErrorMessage = null,
                Plan = _getPlanById(_planId)
            };
        }
    }
}