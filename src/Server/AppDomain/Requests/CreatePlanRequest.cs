using System;
using AppDomain.Entities;
using AppDomain.Lib;
using AppDomain.Responses;

namespace AppDomain.Requests
{
    public class CreatePlanRequest
    {
        private const int MaxIdTries = 5;
        private const int HashLength = 32;
        private readonly Func<string, bool> _doesPlanIdExist;
        private readonly Func<Plan, bool> _storePlan;
        private readonly Plan _plan;

        public CreatePlanRequest(Func<string, bool> doesPlanIdExist, Func<Plan, bool> storePlan, Plan plan)
        {
            _doesPlanIdExist = doesPlanIdExist;
            _storePlan = storePlan;
            _plan = plan;
        }

        public CreatePlanResponse Handle()
        {
            var planDataErrorMsg = ValidatePlanData(_plan);
            if (planDataErrorMsg != null)
            {
                return new CreatePlanResponse {ErrorMessage = planDataErrorMsg};
            }

            _plan.Id = TryGetPlanId();
            if (_plan.Id == null)
            {
                return new CreatePlanResponse {ErrorMessage = "Could not create an unique ID for the plan"};
            }

            var storeWasSuccessful = _storePlan(_plan);
            if (!storeWasSuccessful)
            {
                return new CreatePlanResponse {ErrorMessage = "Error: Could not store the plan"};
            }

            return new CreatePlanResponse
            {
                PlanId = _plan.Id
            };
        }

        private string TryGetPlanId()
        {
            for (var tryCount = 0; tryCount < MaxIdTries; tryCount++)
            {
                var id = HashGenerator.NewHash(HashLength);
                if (_doesPlanIdExist(id))
                {
                    continue;
                }

                return id;
            }

            return null;
        }

        private static string ValidatePlanData(Plan plan)
        {
            if (plan == null)
            {
                return "Error: Empty plan data";
            }

            return null;
        }
    }
}