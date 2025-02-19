using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;

namespace BankingCreditSystem.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IndividualCustomerBusinessRules>();
            services.AddScoped<CorporateCustomerBusinessRules>();
            
            return services;
        }
    }
}