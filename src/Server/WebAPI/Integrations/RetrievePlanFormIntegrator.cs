using AppDomain.Requests;
using AutoMapper;
using Persistence;
using WebAPI.Models;

namespace WebAPI.Integrations
{
    public class RetrievePlanFormIntegrator
    {
        private readonly string _id;
        private readonly string _token;
        private readonly PlanRepository _planRepo;
        private static readonly IMapper Mapper = DataMapper.MapperConfig.CreateMapper();

        public RetrievePlanFormIntegrator(string id, string token)
        {
            _id = id;
            _token = token; //TODO: use this to verify access
            _planRepo = new PlanRepository();
        }

        public object Run()
        {
            var request = new RetrievePlanRequest(_planRepo.DoesPlanIdExist, _planRepo.RetrievePlan, _id);
            var response = request.Handle();

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                return new ErrorViewModel {ErrorMessage = response.ErrorMessage};
            }

            return Mapper.Map<PlanFormViewModel>(response.Plan);
        }  
    }
}