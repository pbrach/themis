using AppDomain.Requests;
using Xunit;

namespace AppDomain.UnitTests.Requests
{
    public class GetIntervalTypesRequestTest
    {
        [Fact]
        public void ReturnsAllUsableIntervalTypes()
        {
            var results = GetIntervalTypesRequest.GetTypes();
            
            
        }
    }
}