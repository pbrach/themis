using System.Linq;
using AppDomain.Requests;
using Xunit;

namespace AppDomain.UnitTests.Requests
{
    public class GetIntervalTypesRequestTest
    {
        [Fact]
        public void ReturnsAllUsableIntervalTypes()
        {
            var results = IntervalService.GetIntervalFriendlyNames();
            Assert.Equal(3, results.Count());
            Assert.True(results.All(x=> !string.IsNullOrEmpty(x)));
        }
    }
}