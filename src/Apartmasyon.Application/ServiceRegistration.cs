using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Apartmasyon.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}