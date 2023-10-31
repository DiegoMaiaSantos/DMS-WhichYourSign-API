using DMS_WhichYourSign_API.Config.Environments;
using DMS_WhichYourSign_API.Src.Infra.Ioc;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace DMS_WhichYourSign_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddJsonOptions(config =>
                config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddCors(options =>
                options.AddPolicy(
                    "AllowAll", p =>
                    {
                        p.AllowAnyOrigin();
                        p.AllowAnyMethod();
                        p.AllowAnyHeader();
                    }));

            services.RegisterConnectionServices();
            services.RegisterDependencies();
            services.RegisterHealthChecks();
            services.AddSwaggerConfig("DMS-WhichYourSign-API",
                                        "Api para retornar o seu signo.");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(swaggerOptions =>
                {
                    swaggerOptions.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                    {
                        swaggerDoc.Servers = new List<OpenApiServer> { new() { Url = Constants.APP_URL } };
                    });
                });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "DMS-WhichYourSign-API v1"));

            }
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks();
            });
        }
    }
}
