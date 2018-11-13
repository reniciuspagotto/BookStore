using BookStore.Domain.Handlers;
using BookStore.Domain.Repository;
using BookStore.Infra.Context;
using BookStore.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace BookStore.Api
{
    public static class Setup
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
        }

        public static void ConfigureCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }

        public static void ConfigureHandlers(this IServiceCollection services)
        {
            services.AddTransient<BookHandler, BookHandler>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Documentação API",
                    Description = ""
                });
            });
        }

        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("cnstr"), b => b.MigrationsAssembly("BookStore.Api")));
        }

        public static void ConfigureMigrations(this IApplicationBuilder app, DataContext context)
        {
            context.Database.Migrate();
        }

        public static void ConfigureMVC(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
    }
}