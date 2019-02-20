using System;
using System.Linq;
using AppDomain.Entities;
using AppDomain.Requests;
using AutoMapper;
using WebAPI.Models;

namespace WebAPI.Integrations
{
    public static class DataMapper
    {
        public static readonly MapperConfiguration MapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMissingTypeMaps = true;
            cfg.AllowNullDestinationValues = true;

            cfg.CreateMap<PlanFormViewModel, Plan>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .MaxDepth(3);

            cfg.CreateMap<ChoreFormViewModel, Chore>()
                .ForMember(m => m.Interval,
                    e => e.MapFrom(model => ThemisMap(model)));

            cfg.CreateMap<Plan, PlanViewModel>()
                .ForMember(m => m.Chores,
                    e => e.MapFrom(model => model.Chores.Select(ThemisMap)));
        });

        private static ChoreViewModel ThemisMap(Chore chore)
        {
            var assignment = chore.AssignmentAt(DateTime.Now);

            var firstDayOfNext = assignment.LastActiveDay + TimeSpan.FromDays(1);
            var nextAssi = chore.AssignmentAt(firstDayOfNext).AssigneeName;
            
            return new ChoreViewModel
            {
                Title = chore.Title,
                Description = chore.Description,
                CurrentAssignee = assignment.AssigneeName,
                NextAssignee = nextAssi,
                Start = assignment.FirstActiveDay,
                End = assignment.LastActiveDay
            };
        }
            
                
        private static Interval ThemisMap(ChoreFormViewModel model)
        {
            var result = IntervalService.CreateNew(model.IntervalType);
            result.Duration = (uint)model.Duration;
            result.StartDay = model.StartDay;
            result.StartOfWeek = model.StartOfWeek;
            return result;
        }
    }
    

}