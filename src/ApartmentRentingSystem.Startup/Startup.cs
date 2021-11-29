namespace ApartmentRentingSystem.Startup
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Infrastructure;
    using Application;
    using Web.Middleware;
    using Domain;
    using Web;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDomain();
            services.AddApplication(this.Configuration);
            services.AddInfrastructure(this.Configuration);
            services.AddWebComponents();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(opt =>
                {
                    
                });
                app.UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                    opt.RoutePrefix = string.Empty;
                });
            }

            app.UseValidationExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(opt =>
            {
                opt.AllowAnyMethod();
                opt.AllowAnyOrigin();
                opt.AllowAnyHeader();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.Initialize();
        }
    }
}