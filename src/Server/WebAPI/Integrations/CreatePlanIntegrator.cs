using AppDomain.Entities;
using AppDomain.Requests;
using AutoMapper;
using Integration;
using Persistence;
using ErrorViewModel = WebAPI.Models.ErrorViewModel;
using PlanViewModel = WebAPI.Models.PlanViewModel;
using SuccessViewModel = WebAPI.Models.SuccessViewModel;

namespace WebAPI.Integrations
{
    public class CreatePlanIntegrator
    {
        private static readonly IMapper Mapper = DataMapper.MapperConfig.CreateMapper();

        private PlanViewModel PlanViewModel { get; }
        private PlanRepository PlanRepo { get; }

        public CreatePlanIntegrator(PlanViewModel planViewModel)
        {
            PlanViewModel = planViewModel;
            PlanRepo = new PlanRepository(); // BAD: Dependency hiding!!!
        }

        public object Run()
        {
            var inputBlPlan = Mapper.Map<Plan>(PlanViewModel);
            
            var request = new CreatePlanRequest(PlanRepo.DoesPlanIdExist, PlanRepo.StoreNewPlan, inputBlPlan);

            var response = request.Handle();

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                return new ErrorViewModel {ErrorMessage = response.ErrorMessage};
            }

            return new SuccessViewModel {Id = response.PlanId, AuthToken = string.Empty};
        }
    }
}