using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Infrastructure.Data.Repositories;
using Api.Service.Services;

namespace Api.Application.IOC;

public static class ConfigurationIOC
{

    public static IServiceCollection RegisterServicesIOC(this IServiceCollection services)
    {
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IDayService, DayService>();
        return services;
    }

    public static IServiceCollection RegisterRepositoriesIOC(this IServiceCollection services)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IDayRepository, DayRepository>();
        return services;
    }
}