using Api.Middlewares;
using Application;
using Data;
using DefaultNamespace;
using Transversal.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<DatabaseOptions>()
    .Bind(builder.Configuration.GetSection(DatabaseOptions.Section))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();

builder.Services.AddTransversalServices();

builder.Services.AddDataServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.Run();