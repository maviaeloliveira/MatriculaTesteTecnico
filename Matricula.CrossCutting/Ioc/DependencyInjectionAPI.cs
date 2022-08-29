using Matricula.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Matricula.CrossCutting.Ioc
{
    public static class DependencyInjectionAPI
    {
        private static string _CORSPoliceName = "Phidelis-Matricula";
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole().AddDebug(); });
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                        configuration.GetConnectionString("DefaultConnection"), 
                        ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                   .EnableSensitiveDataLogging(true)
                   .UseLoggerFactory(loggerFactory)
                );

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();


            #region CORS
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: configuration.GetSection("CORSPoliceName").Value,
                    builder =>
                    {
                        builder.AllowAnyMethod()
                               .AllowAnyHeader()
                               .WithOrigins(configuration.GetSection("CORS").GetChildren().Select(c => c.Value).ToArray());
                    }
                );
            });
            #endregion

            return services;
        }
    }
}
