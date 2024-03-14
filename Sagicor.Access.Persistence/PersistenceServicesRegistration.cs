using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sagicor.Access.Application.Contracts.Persistence;
using Sagicor.Access.Persistence.Repositories;

namespace Sagicor.Access.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<SagicorAccessDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("SagicorAccessDbConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IPLCategoryRepository, PLCategoryRepository>();

        return services;
    }
}
