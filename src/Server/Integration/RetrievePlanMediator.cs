using AutoMapper;
using AppDomain.Entities;
using AppDomain.Requests;
using Persistence;
using ViewModel.Models;

namespace Integration
{
    public class RetrievePlanMediator
    {
        private readonly string _id;
        private readonly PlanRepository _planRepo;
        private static readonly IMapper Mapper = DataMapper.MapperConfig.CreateMapper();

        public RetrievePlanMediator(string id)
        {
            _id = id;
            _planRepo = new PlanRepository();
        }

        public object Run()
        {
            var request = new RetrievePlanRequest(_planRepo.DoesPlanIdExist, MappedGetPlanById, _id);
            var response = request.Handle();

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                return new ErrorViewModel {ErrorMessage = response.ErrorMessage};
            }

            return Mapper.Map<PlanViewModel>(response.Plan);
        }

        private Plan MappedGetPlanById(string id)
        {
            var dbPlan = _planRepo.RetrivePlanById(id);
            return Mapper.Map<Plan>(dbPlan);
        }
     }
}