
using BankingCreditSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingCreditSystem.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankingCreditSystemDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IIndividualCustomerRepository, IndividualCustomerRepository>();
            services.AddScoped<ICorporateCustomerRepository, CorporateCustomerRepository>();

            return services;
        }
    }
} 