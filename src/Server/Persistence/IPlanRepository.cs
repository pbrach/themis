using System;
using System.Collections.Generic;
using AppDomain.Entities;

namespace Persistence
{
    public interface IPlanRepository
    {
        bool DoesPlanIdExist(string planId);
        IEnumerable<Tuple<string, string>> GetAccessInfos();
        bool StoreNewPlan(Plan plan);
        bool DeletePlan(string id);
        Plan RetrievePlan(string id);
    }
}