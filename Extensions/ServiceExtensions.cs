using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YG.Server.UserDataStorage.DataBase;
using YG.Server.UserDataStorage.Services;
using YG.Server.UserDataStorage.Services.Runtime;

namespace YG.Server.UserDataStorage.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection UseUserDataStorage(this IServiceCollection services, string dataBase)
        {
            Configurate.DataBaseConnection = dataBase;

            services.AddDbContext<GeneralContext>(_ =>
            {
                _.UseNpgsql(Configurate.DataBaseConnection);
            });

            services
                .AddScoped<IRootService, RootService>()
                .AddScoped<IFieldService, FieldService>();

            return services;
        }
    }
}
