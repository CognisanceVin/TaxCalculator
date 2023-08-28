using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Application.Interfaces;
using TaxCalculator.Application.Services;
using TaxCalculator.Domain.Entities;
using TaxCalculator.Domain.Entities.ReferenceData;
using TaxCalculator.Domain.Interfaces;
using TaxCalculator.Infrastructure.Persistence;
using TaxCalculator.Infrastructure.Repository;

namespace TaxCalculator.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            var connectionstring = configuration.GetConnectionString("TaxCalculatorConnectionString");
              services.AddDbContext<TaxCalculatorContext>(options =>
            options.UseSqlServer(connectionstring,
            b =>
            {
                b.MigrationsAssembly(typeof(TaxCalculatorContext).Assembly.FullName);
                //b.MigrationsHistoryTable("__EFMigrationHistory", "admin");
            }));
            return services;

        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //Application Layer 

            services.AddScoped<ICalculatedTaxRepository, CalculatedTaxRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();

            return services;
        }
    }
}