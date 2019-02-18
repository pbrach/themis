using AppDomain.Requests;
using AutoMapper;
using Persistence;
using WebAPI.Models;
using ErrorViewModel = WebAPI.Models.ErrorViewModel;

namespace WebAPI.Integrations
{
    public class RetrievePlanIntegrator
    {
        private readonly string _id;
        private readonly PlanRepository _planRepo;
        private static readonly IMapper Mapper = DataMapper.MapperConfig.CreateMapper();

        public RetrievePlanIntegrator(string id)
        {
            _id = id;
            _planRepo = new PlanRepository();
        }

        public object Run()
        {
            var request = new RetrievePlanRequest(_planRepo.DoesPlanIdExist, _planRepo.RetrievePlanById, _id);
            var response = request.Handle();

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                return new ErrorViewModel {ErrorMessage = response.ErrorMessage};
            }

            return Mapper.Map<PlanFormViewModel>(response.Plan);
        }
     }
}