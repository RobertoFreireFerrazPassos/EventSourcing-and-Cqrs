using AutoMapper;
using Inventory.Application.Infra.AutoMapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Application.Infra.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings(IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ItemProfile());
            });


            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
