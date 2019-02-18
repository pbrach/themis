using System;
using AppDomain.Entities;
using AppDomain.Requests;
using AutoMapper;
using WebAPI.Models;
using PlanViewModel = WebAPI.Models.PlanViewModel;

namespace WebAPI.Integrations
{
    public static class DataMapper
    {
        public static readonly MapperConfiguration MapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMissingTypeMaps = true;
            cfg.AllowNullDestinationValues = true;

            cfg.CreateMap<PlanViewModel, Plan>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .MaxDepth(3);

            cfg.CreateMap<ChoreFormViewModel, Chore>()
                .ForMember(m => m.Interval,
                    e => e.MapFrom(model => MapInterval(model)));
        });
            
                
        private static Interval MapInterval(ChoreFormViewModel model)
        {
            var result = IntervalService.CreateNew(model.IntervalType);
            result.Duration = TimeSpan.FromDays(model.DayDuration);
            result.StartDay = model.StartDay;
            return result;
        }
    }
    

}