using System;
using System.Collections.Generic;
using System.Reflection;
using AppDomain.Entities;

namespace AppDomain.Requests
{
    public static class GetIntervalTypesRequest
    {
        public static Dictionary<string, Interval> GetTypes()
        {
            var thisAssembly = Assembly.GetAssembly(typeof(GetIntervalTypesRequest));


            var results = new Dictionary<string, Interval>();
            foreach (var type in thisAssembly.GetTypes())
            {
                if (!typeof(Interval).IsAssignableFrom(type) || type.IsAbstract)
                    continue;

                var intervalInst = (Interval) Activator.CreateInstance(type);
                var friendlyName = (string)type.GetProperty("FriendlyName").GetValue(intervalInst);
                
                results.Add(friendlyName, intervalInst);
            }

            return results;
        }
    }
}