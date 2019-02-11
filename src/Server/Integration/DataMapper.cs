using AutoMapper;
using AppDomain.Entities;
using Persistence.DbTypes;
using ViewModel.Models;

namespace Integration
{
    public static class DataMapper
    {
        public static readonly MapperConfiguration MapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMissingTypeMaps = true;
            cfg.AllowNullDestinationValues = true;

            cfg.CreateMap<DbPlan, Plan>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            
            cfg.CreateMap<PlanViewModel, Plan>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        });       
    }
}