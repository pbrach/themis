using System;
using System.Linq;
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
            _token = token;
            _planRepo = new PlanRepository();
        }

        public object Run()
        {
            var request = new RetrievePlanRequest(_planRepo.DoesPlanIdExist, _planRepo.RetrievePlan, _id);
            var response = request.Handle();

            if (response.Plan.Token != _token)
            {
                return new ErrorViewModel {ErrorMessage = "Invalid access token for editing the plan"};
            }
            
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                return new ErrorViewModel {ErrorMessage = response.ErrorMessage};
            }

            var result = Mapper.Map<PlanFormViewModel>(response.Plan);
            
            var choreOne = result.Chores.FirstOrDefault();
            result.StartDate = choreOne?.StartDay ?? DateTime.Now;
            
            return result;
        }  
    }
}