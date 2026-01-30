using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServicesExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAlumnService, AlumnService>();
    }
}