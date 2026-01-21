using Data.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Transversal.Configurations;

namespace Data;

public static class ServicesExtension
{
    public static void AddDataServices(this IServiceCollection services)
    {
        services.AddDbContext<CampusContext>((sp, options) =>
        {
            var dbOptions = sp
                .GetRequiredService<IOptions<DatabaseOptions>>()
                .Value;
            options.UseSqlServer(dbOptions.SqlServerConnection);
        });
        services.AddScoped<IRepository, Repository.Repository>();
    }
}