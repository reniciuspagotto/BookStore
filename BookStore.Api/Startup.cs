using BookStore.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureMVC();
            services.ConfigureDatabase(Configuration);
            services.ConfigureRepositories();
            services.ConfigureHandlers();
            services.ConfigureServices();
            services.ConfigureSwagger();
            services.ConfigureCache();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataContext context)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwaggerUI(c =>
            {
                string Url = "/swagger/v1/swagger.json";
                c.SwaggerEndpoint(Url, "API V1");
            });

            app.UseSwagger();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.ConfigureMigrations(context);
            app.UseMvc();
        }
    }
}
