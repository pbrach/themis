using AppDomain.Entities;
using AppDomain.Requests;
using AutoMapper;
using Persistence;
using WebAPI.Models;
using ErrorViewModel = WebAPI.Models.ErrorViewModel;
using SuccessViewModel = WebAPI.Models.SuccessViewModel;

namespace WebAPI.Integrations
{
    public class CreatePlanIntegrator
    {
        private static readonly IMapper Mapper = DataMapper.MapperConfig.CreateMapper();

        private PlanFormViewModel PlanFormViewModel { get; }
        private PlanRepository PlanRepo { get; }

        public CreatePlanIntegrator(PlanFormViewModel planFormViewModel)
        {
            PlanFormViewModel = planFormViewModel;
            PlanRepo = new PlanRepository(); // BAD: Dependency hiding!!!
        }

        public object Run()
        {
            var inputBlPlan = Mapper.Map<Plan>(PlanFormViewModel);
            
            var request = new CreatePlanRequest(PlanRepo.DoesPlanIdExist, PlanRepo.StoreNewPlan, inputBlPlan);

            var response = request.Handle();

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                return new ErrorViewModel {ErrorMessage = response.ErrorMessage};
            }

            return new SuccessViewModel {Id = response.PlanId, Token = inputBlPlan.Token};
        }
    }
}