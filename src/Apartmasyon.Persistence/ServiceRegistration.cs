using Apartmasyon.Application.Common.Interfaces;
using Apartmasyon.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Apartmasyon.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApartmentDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        services.AddScoped<IApartmentDbContext>(provider => provider.GetRequiredService<ApartmentDbContext>());
    }
}