using Microsoft.Extensions.DependencyInjection;
using Transversal.Configurations;

namespace DefaultNamespace;

public static class ServicesExtension
{
    public static void AddTransversalServices(this IServiceCollection services)
    {
        services.AddScoped<DatabaseOptions>();
    }
}