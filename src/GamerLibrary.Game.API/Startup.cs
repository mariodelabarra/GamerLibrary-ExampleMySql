using GamerLibrary.Common.API.Extensions;
using GamerLibrary.Common.Domain;
using Hellang.Middleware.ProblemDetails;
using Hellang.Middleware.ProblemDetails.Mvc;
using Microsoft.OpenApi.Models;

namespace GamerLibrary.Game.API
{
    public class Startup 
    {
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjection.ConfigureDependencies(services, Configuration, WebHostEnvironment);

            services
                .AddControllers()
                .AddProblemDetailsConventions();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GamerLibrary.Game.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Transfor exceptions status codes to ProblemDetails model
            app.UseProblemDetails();

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GamerLibrary.Game.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
   
}
