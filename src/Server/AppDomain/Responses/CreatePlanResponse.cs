namespace AppDomain.Responses
{
    public class CreatePlanResponse : BaseResponse
    {
        public CreatePlanResponse()
        {
            PlanId = null;
        }

        public string PlanId { get; set; }
    }
}