using Apartmasyon.Infrastructure.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;

namespace Apartmasyon.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddHostedService<InvoiceGeneratorHostedService>();
    }
}