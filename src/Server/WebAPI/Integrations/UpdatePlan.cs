using AppDomain.Entities;
using AutoMapper;
using Persistence;
using WebAPI.Models;

namespace WebAPI.Integrations
{
    public class UpdatePlan
    {
        private readonly string _id;
        private readonly string _token;
        private static readonly IMapper Mapper = DataMapper.MapperConfig.CreateMapper();

        private PlanFormViewModel PlanFormViewModel { get; }
        private PlanRepository PlanRepo { get; }

        public UpdatePlan(PlanFormViewModel planFormViewModel, string id, string token)
        {
            _id = id;
            _token = token;
            PlanFormViewModel = planFormViewModel;
            PlanRepo = new PlanRepository();
        }

        public object Run()
        {
            var dbPLan = PlanRepo.RetrievePlan(_id);
            if (dbPLan.Token != _token)
            {
                return new ErrorViewModel {ErrorMessage = "Invalid access token"};
            }
            
            var inputBlPlan = Mapper.Map<Plan>(PlanFormViewModel);
            inputBlPlan.Id = _id;
            inputBlPlan.Token = _token;
            
            var planWasDeleted = PlanRepo.DeletePlan(_id);
            if (!planWasDeleted)
            {
                return new ErrorViewModel {ErrorMessage = "Could not update plan, because a plan with that ID does not exist anymore"};
            }
            
            var planWasStored = PlanRepo.StoreNewPlan(inputBlPlan);
            if (!planWasStored)
            {
                return new ErrorViewModel {ErrorMessage = "Update failed: the plan was deleted"}; // TODO: NOT COOL!!!
            }

            return new SuccessViewModel {Id = _id, Token = _token};
        }
    }
}