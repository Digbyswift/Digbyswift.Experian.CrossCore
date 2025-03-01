#if NET6_0_OR_GREATER
using Digbyswift.Experian.CrossCore.Configuration;
using Digbyswift.Experian.CrossCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digbyswift.Experian.CrossCore.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterCrossCoreDependencies(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton(_ => new Endpoints(config.GetValue<string>("Experian:CrossCore:AmlServiceUrl"), config.GetValue<string>("Experian:CrossCore:AuthTokenUrl")));

        var crossCoreConfig = config.GetSection("Experian:CrossCore").Get<ExperianCrossCoreConfig>();
        services.AddSingleton(crossCoreConfig);
        services.AddHttpClient<ExperianClient>();
        services.AddSingleton<IAmlService, ExperianAmlService>();

        return services;
    }
}
#endif
