using DMS_WhichYourSign_API.Config.Environments;
using DMS_WhichYourSign_API.Src.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DMS_WhichYourSign_API.Src.Infra.Ioc.Factorys
{
    public static class ConnectionDbFactory
    {
        public static IServiceCollection RegisterDbConnections(this IServiceCollection connections)
        {
            connections.AddDbContext<WhichYourSignDBContext>(options =>
            {
                options.UseSqlServer(Constants.ConnectionStringWhichYourSign);
            });

            return connections;
        }
    }
}
