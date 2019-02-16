using AppDomain.Entities;
using AutoMapper;
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
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        });       
    }
}