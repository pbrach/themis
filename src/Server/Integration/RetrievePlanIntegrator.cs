using AutoMapper;
using AppDomain.Requests;
using Persistence;
using ViewModel.Models;

namespace Integration
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

            return Mapper.Map<PlanViewModel>(response.Plan);
        }
     }
}