using AppDomain.Lib;
using Xunit;

namespace AppDomain.UnitTests.Lib
{
    public class HashGeneratorTests
    {
        [Fact]
        public void MultipleCallsGenerateDifferentResults()
        {
            const int hashLength = 16;

            var results = new[] {HashGenerator.NewHash(hashLength), ""};
            for (var i = 0; i < 100000; i++)
            {
                results[1] = HashGenerator.NewHash(hashLength);

                Assert.NotEqual(results[0], results[1]);
            }
        }
    }
}