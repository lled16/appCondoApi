using AppCondo.Application.Interfaces;
using AppCondo.Application.Mappings.Doorman;
using AppCondo.Application.Services.PorteiroService;
using AppCondo.Data.Context;
using AppCondo.Data.Repositories;
using AppCondo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppConco.Infra.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });


            services.AddScoped<IDoormanRepository, DoormanRepository>();
            services.AddScoped<IDoormanMap, DoormanMap>();
            services.AddScoped<IDoormanService, DoormanService>();


            return services;
        }
    }
}
