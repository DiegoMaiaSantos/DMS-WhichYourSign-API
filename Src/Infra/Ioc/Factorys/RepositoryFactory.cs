using DMS_WhichYourSign_API.Src.Infra.Data.Contexts.Interface;
using DMS_WhichYourSign_API.Src.Infra.Data.Contexts;
using DMS_WhichYourSign_API.Src.Infra.Data.Repositories;
using DMS_WhichYourSign_API.Src.Domain.Interfaces.Repositories;

namespace DMS_WhichYourSign_API.Src.Infra.Ioc.Factorys
{
    public static class RepositoryFactory
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IUnitOfWork, UnitOfWork>();
            repositories.AddScoped<IWhichYourSignRepository, WhichYourSignRepository>();

            return repositories;
        }
    }
}
