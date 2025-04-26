using GymFlex.Infrastructure.Data.Context;
using GymFlex.Presentation.Filters;
using Microsoft.AspNetCore.Identity;

namespace GymFlex.Presentation.Configurations
{
    public static class ControllersConfiguration
    {
        public static IServiceCollection AddAndConfigureControllers(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services
                .AddControllers(options
                    => options.Filters.Add(typeof(ApiGlobalExceptionFilter))
                );
            services.AddProblemDetails();
            services.AddDocumentation();
            services.AddAndConfigureCors(configuration);
            return services;
        }

        private static IServiceCollection AddDocumentation(
            this IServiceCollection services
        )
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "GymFlex API",
                    Version = "v1",
                    Description = "API para o sistema GymFlex"
                });
            });
            return services;
        }

        public static WebApplication UseDocumentation(
            this WebApplication app
        )
        {
            if (app.Environment.IsDevelopment())
            {   
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GymFlex API V1");
                    c.RoutePrefix = "docs";
                });
            }
            return app;
        }

        private static IServiceCollection AddUserIdentity(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthorization();
            return services;
        }


        private static IServiceCollection AddAndConfigureCors(
            this IServiceCollection services, 
            IConfiguration configuration
        )
        {
            // Obtém as origens permitidas da configuração
            var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>();

            // Configura a política de CORS utilizando os valores do appsettings.json
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    if (allowedOrigins == null || allowedOrigins.Length == 0)
                    {
                        throw new ArgumentException("Allowed origins are not configured in appsettings.json.");
                    }
                    policy.WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}


