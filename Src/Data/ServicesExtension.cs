using Data.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data;

public static class ServicesExtension
{
    public static void AddDataServices(this IServiceCollection services)
    {
        services.AddDbContext<CampusContext>(options =>
        {
            options.UseSqlServer("");
        });
        services.AddScoped<IRepository, Repository.Repository>();
    }
}