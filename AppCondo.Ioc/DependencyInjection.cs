
namespace AppCondo.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAutoMapper(typeof(DomainToDTOMapping));

            services.AddScoped<IAnuncioServices, AnuncioServices>();
            services.AddScoped<IAnunciosRepository, AnunciosRepository>();


            return services;
        }
    }
}
