using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using YG.Server.UserDataStorage.DataBase;
using YG.Server.UserDataStorage.Services;
using YG.Server.UserDataStorage.Services.Runtime;

namespace YG.Server.UserDataStorage.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddUserDataStorage(this IServiceCollection services, string dataBase)
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

    public static SwaggerGenOptions AddUserDataStorage(this SwaggerGenOptions options)
    {
        options.SwaggerDoc(name: "UserDataStorage", new OpenApiInfo { Title = "UserDataStorage", Version = "UserDataStorage" });
        return options;
    }

    public static SwaggerUIOptions AddUserDataStorage(this SwaggerUIOptions options)
    {
        options.SwaggerEndpoint(url: $"/swagger/UserDataStorage/swagger.json", name: "UserDataStorage");
        return options;
    }

    public static IEndpointRouteBuilder UseUserDataStorage(this IEndpointRouteBuilder builder)
    {
        return builder;
    }
}
