using GamerLibrary.Common.API.Extensions;
using GamerLibrary.Common.Repository;
using GamerLibrary.Game.Repository;
using GamerLibrary.Game.Service;
using Hellang.Middleware.ProblemDetails;

namespace GamerLibrary.Game.API
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            RegisterConfiguration(services, configuration, webHostEnvironment);
            RegisterServices(services);
            RegisterRepositories(services);
        }

        public static void RegisterConfiguration(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            services.AddProblemDetails(opt => opt.ConfigureProblemDetails(webHostEnvironment));

            services.Configure<DbOptions>(configuration.GetSection(DbOptions.BaseSettingsKey));
            services.AddSingleton<IDbSettings, DbSettings>();

        }

        public static void RegisterServices(this IServiceCollection services)
        {
            //Mapper

            //Services
            services.AddScoped<IGameService, GameService>();

            //Validators
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddDbContext<GameDbContext>();
            services.AddScoped<IGameRepository, GameRepository>();
        }
    }
}
