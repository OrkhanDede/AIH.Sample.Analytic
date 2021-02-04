using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AIH.ERP.Analytic.Application.Services;

namespace AIH.ERP.Analytic.Application
{   
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureServices();
            return services;
        }
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ICompanyService, CompanyService>();
            return services;
        }
    }
}
