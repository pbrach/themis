using AppDomain.Entities;
using AutoMapper;
using Persistence.DbTypes;
using PlanViewModel = WebAPI.Models.PlanViewModel;

namespace WebAPI.Integrations
{
    public static class DataMapper
    {
        public static readonly MapperConfiguration MapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMissingTypeMaps = true;
            cfg.AllowNullDestinationValues = true;

            cfg.CreateMap<DbPlan, Plan>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
            
            cfg.CreateMap<PlanViewModel, Plan>()
                .ReverseMap()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        });       
    }
}