namespace AppDomain.Responses
{
    public abstract class BaseResponse
    {
        public BaseResponse()
        {
            ErrorMessage = null;
        }
        
        public string ErrorMessage { get; set; }
    }
}