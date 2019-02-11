using AppDomain.Entities;

namespace AppDomain.Responses
{
    public class RetrievePlanResponse : BaseResponse
    {
        public RetrievePlanResponse()
        {
            Plan = null;
        }
        public Plan Plan { get; set; }
    }
}