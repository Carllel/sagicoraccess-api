using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sagicor.Access.Application.Contracts.Email;
using Sagicor.Access.Application.Contracts.Logging;
using Sagicor.Access.Application.Models.Email;
using Sagicor.Access.Infrastructure.EmailService;
using Sagicor.Access.Infrastructure.Logging;

namespace Sagicor.Access.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}