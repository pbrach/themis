using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AppDomain.Entities;

namespace AppDomain.Requests
{
    public static class IntervalService
    {
        private static readonly Dictionary<string, Type> AvailableIntervals = ReflectIntervalTypes();
        private static Dictionary<string, Type> ReflectIntervalTypes()
        {
            var thisAssembly = Assembly.GetAssembly(typeof(IntervalService));


            var results = new Dictionary<string, Type>();
            foreach (var type in thisAssembly.GetTypes())
            {
                if (!typeof(Interval).IsAssignableFrom(type) || type.IsAbstract)
                    continue;

                var intervalInst = (Interval) Activator.CreateInstance(type);
                var friendlyName = (string)type.GetProperty("FriendlyName").GetValue(intervalInst);
                
                results.Add(friendlyName, type);
            }

            return results;
        }

        public static IEnumerable<string> GetIntervalFriendlyNames()
        {
            return AvailableIntervals.Keys.ToList();
        }

        public static Interval CreateNew(string friendlyName)
        {
            var intervalType = AvailableIntervals[friendlyName];

            if (intervalType == null)
            {
                throw new KeyNotFoundException($"The given interval types: '{friendlyName}' does not exist.");
            }
            
            var intervalInst = (Interval) Activator.CreateInstance(intervalType);
            return intervalInst;
        }
    }
}