using System.Collections.Generic;

namespace AppDomain.Responses
{
    public class IntervalTypesResponse : BaseResponse
    {
        public IEnumerable<string> IntervalTypes { get; set; }
    }
}