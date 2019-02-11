using System;
using AutoMapper;
using AppDomain.Entities;
using AppDomain.Requests;
using Persistence;
using Persistence.DbTypes;
using ViewModel.Models;

namespace Integration
{
    public class CreatePlanMediator
    {
        private static readonly IMapper Mapper = DataMapper.MapperConfig.CreateMapper();

        private PlanViewModel PlanViewModel { get; }
        private PlanRepository PlanRepo { get; } 
        
        public CreatePlanMediator(PlanViewModel planViewModel)
        {
            PlanViewModel = planViewModel;
            PlanRepo = new PlanRepository(); // BAD: Dependency hiding!!!
        }

        public object Run()
        {
            Plan inputBlPlan = Mapper.Map<Plan>(PlanViewModel);
            var request = new CreatePlanRequest(PlanRepo.DoesPlanIdExist, MappedStorePlan, inputBlPlan); // map Viewmodel-Data to BL-Data
            
            var response = request.Handle();

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                return new ErrorViewModel {ErrorMessage = response.ErrorMessage};
            }

            return new SuccessViewModel {Id = response.PlanId, AuthToken = string.Empty};
        }

        private bool MappedStorePlan(Plan blPlan)
        {
            DbPlan dbPlan = Mapper.Map<DbPlan>(blPlan);
            return PlanRepo.StorePlan(dbPlan);
        }
    }
}