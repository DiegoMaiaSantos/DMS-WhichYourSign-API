using DMS_WhichYourSign_API.Src.Domain.Interfaces.Services;
using DMS_WhichYourSign_API.Src.Domain.Mappings;
using DMS_WhichYourSign_API.Src.Service;

namespace DMS_WhichYourSign_API.Src.Infra.Ioc.Factorys
{
    public static class ServiceFactory
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DTOToEntityMapping));
            services.AddScoped<IWhichYourSignService, WhichYourSignService>();

            return services;
        }
    }
}
